using System.Collections.Generic;
using System.ComponentModel;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movies
    /// </summary>
    public class MovieSearchViewModel
    {
        public MovieSearchViewModel(TmdbQueryResultsJson apiModel)
        {
            Results = apiModel.Results ?? new List<TmdbMovieJson>();
            Page = apiModel.Page;
            TotalResults = apiModel.TotalResults;
            TotalPages = apiModel.TotalPages;
            SearchSuccess = true; // todo: set to true/false based on success of request
        }
        public bool SearchSuccess { get; set; }
        public List<TmdbMovieJson> Results { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}