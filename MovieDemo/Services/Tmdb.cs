using MovieDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web.Configuration;
using MovieDemo.Util;
using System.Net.Http;
using System.Web.Script.Serialization;
using MovieDemo.Models;

namespace MovieDemo.Services
{
    /// <summary>
    ///     Specifies implementation for interface with the TMDB API.
    ///     TODO: cache config values instead of per-request lookup
    ///     TODO: private-backed vars for config
    /// </summary>
    public class Tmdb : ITmdb
    {
        private ConfigFetcher _configFetcher { get; set; }
        public ConfigFetcher ConfigFetcher
        {
            get
            {
                if (_configFetcher == null)
                    _configFetcher = new ConfigFetcher();
                return _configFetcher;
            }
        }

        private MovieDbContext _dbContext { get; set; }
        public MovieDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = MovieDbContext.Create();
                return _dbContext;
            }
        }

        /// <summary>
        ///     Gets API key from web config
        /// </summary>
        public string ApiKey
        {
            get
            {
                // Get all settings
                var rootWebConfig = WebConfigurationManager.OpenWebConfiguration(AppValues.SITE_NAME);
                if (rootWebConfig.AppSettings.Settings.Count == 0)
                    throw new KeyNotFoundException($"{Config.TMDB_API_KEY} not found.");

                // Get api url
                var customSetting = rootWebConfig.AppSettings.Settings[Config.TMDB_API_KEY];
                if (customSetting == null || string.IsNullOrEmpty(customSetting.Value))
                    throw new KeyNotFoundException($"{Config.TMDB_API_KEY} not found.");

                // Return url
                return customSetting.Value;
            }
        }

        /// <summary>
        ///     Gets base url from web config
        /// </summary>
        public string BaseUrl
        {
            get
            {
                // Get all settings
                var rootWebConfig = WebConfigurationManager.OpenWebConfiguration(AppValues.SITE_NAME);
                if (rootWebConfig.AppSettings.Settings.Count == 0)
                    throw new KeyNotFoundException($"{Config.TMDB_BASE_URL} not found.");

                // Get api url
                var customSetting = rootWebConfig.AppSettings.Settings[Config.TMDB_BASE_URL];
                if (customSetting == null || string.IsNullOrEmpty(customSetting.Value))
                    throw new KeyNotFoundException($"{Config.TMDB_BASE_URL} not found.");

                // Return url
                return customSetting.Value;
            }
        }

        /// <summary>
        ///     Combines url & key into a url for querying
        /// </summary>
        public string BuildSearchUrl(string queryString)
        {
            var baseUrl = ConfigFetcher.Fetch(Config.TMDB_BASE_URL);
            var version = ConfigFetcher.Fetch(Config.TMDB_VERSION);
            var searchLocation = ConfigFetcher.Fetch(Config.TMDB_MOVIE_SEARCH_URL);

            var toReturn = $"{baseUrl}/{version}/{searchLocation}?{queryString}";
            return toReturn;
        }

        /// <summary>
        ///     Combines url & key into a url for querying by id
        /// </summary>
        public string BuildDetailsUrl(string queryString, int id)
        {
            var baseUrl = ConfigFetcher.Fetch(Config.TMDB_BASE_URL);
            var version = ConfigFetcher.Fetch(Config.TMDB_VERSION);
            var detailsUrl = ConfigFetcher.Fetch(Config.TMDB_MOVIE_DETAILS_URL);

            var toReturn = $"{baseUrl}/{version}/{detailsUrl}/{id}?{queryString}";
            return toReturn;
        }

        /// <summary>
        ///     Perform a general search against the TMDB API and return the first page of results
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public TmdbQueryResultsJson Search(string query)
        {
            // Build query string
            var queryParams = ApiKeyQuery;
            try
            {
                queryParams.Add(
                    ConfigFetcher.Fetch(Config.TMDB_MOVIE_SEARCH_PARAM),
                    query);
            }
            catch (KeyNotFoundException)
            {
                // TODO: throw error to UI
                return null;
            }
            var queryString = QueryBuilder.BuildQuery(queryParams);

            // Make request
            var client = new HttpClient();
            var searchUrl = BuildSearchUrl(queryString);
            var response = client.GetAsync(searchUrl).Result;

            // Parse response and return
            var data = response.Content.ReadAsStringAsync().Result;
            return ParseTmdbQueryResultsJson(data);
        }

        /// <summary>
        ///     Perform a general search against the TMDB API and return the first page of results
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TmdbMovieDetailsJson Details(int id, string posterSize)
        {
            // Build query string
            var queryParams = ApiKeyQuery;
            var queryString = QueryBuilder.BuildQuery(queryParams);

            // Make request
            var client = new HttpClient();
            var searchUrl = BuildDetailsUrl(queryString, id);
            var response = client.GetAsync(searchUrl).Result;

            // Parse response and return
            var data = response.Content.ReadAsStringAsync().Result;
            var toReturn = ParseTmdbDetailsJson(data);
            toReturn.Poster_path = 
                $"{ConfigFetcher.Fetch(Config.TMDB_IMAGE_URL)}/{posterSize}/{toReturn.Poster_path}";
            return toReturn;
        }

        /// <summary>
        ///     Parses TMDB query results into json object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public TmdbQueryResultsJson ParseTmdbQueryResultsJson(string json)
        {
            var toReturn = new JavaScriptSerializer().Deserialize<TmdbQueryResultsJson>(json);
            return toReturn;
        }

        /// <summary>
        ///     Parses TMDB details json string into json object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public TmdbMovieDetailsJson ParseTmdbDetailsJson(string json)
        {
            var toReturn = new JavaScriptSerializer().Deserialize<TmdbMovieDetailsJson>(json);
            return toReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmdbId"></param>
        /// <param name="userId"></param>
        public void AddMovie(int tmdbId, string userId)
        {
            // Do nothing if the record has already been deleted
            var foundMovie = DbContext.Movies.FirstOrDefault(m => m.TmdbId == tmdbId);

            // Create new movie if it doesn't exist
            if (foundMovie == null)
            {
                foundMovie = DbContext.Movies.Create();
                foundMovie.TmdbId = tmdbId;
                foundMovie.IsDeleted = false;
                DbContext.SaveChanges();
            }

            // Return if xref is found
            var foundXref = DbContext.MovieUsers
                .FirstOrDefault(x => x.MovieId == foundMovie.MovieId && x.UserId == userId);
            if (foundXref != null && !foundXref.IsDeleted) return;

            // Create/update xref and save
            if (foundXref == null) foundXref = DbContext.MovieUsers.Create();
            foundXref.MovieId = foundMovie.MovieId;
            foundXref.UserId = userId;
            foundXref.IsDeleted = false;
            DbContext.SaveChanges();
        }

        /// <summary>
        ///     Provides api key parameter, needed on most queries to TMDB API.
        /// </summary>
        private Dictionary<string, string> ApiKeyQuery {
            get
            {
                var queryParams = new Dictionary<string, string>();
                try
                {
                    queryParams.Add(
                        ConfigFetcher.Fetch(Config.TMDB_API_KEY),
                        ConfigFetcher.Fetch(Config.TMDB_API_KEY_VALUE));
                }
                catch (KeyNotFoundException)
                {
                    // TODO: throw error to UI
                    return queryParams;
                }
                return queryParams;
            }
        }
    }
}