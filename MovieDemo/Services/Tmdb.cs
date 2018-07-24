﻿using MovieDemo.Interfaces;
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
        ///     Perform a general search against the TMDB API and return the first page of results
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public TmdbQueryResultsJson Search(string query)
        {
            // Build query string
            var queryParams = new Dictionary<string, string>();
            try
            {
                queryParams.Add(
                    ConfigFetcher.Fetch(Config.TMDB_MOVIE_SEARCH_PARAM), 
                    query);
                queryParams.Add(
                    ConfigFetcher.Fetch(Config.TMDB_API_KEY), 
                    ConfigFetcher.Fetch(Config.TMDB_API_KEY_VALUE));
            }
            catch( KeyNotFoundException )
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
            var toReturn = new JavaScriptSerializer().Deserialize<TmdbQueryResultsJson>(data);
            return toReturn;
        }
    }
}