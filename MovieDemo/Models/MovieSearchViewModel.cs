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
            // Add individual results
            Results = new List<MovieBasicViewModel>();
            if(apiModel.Results != null)
                foreach(var mov in apiModel.Results)
                    Results.Add(new MovieBasicViewModel(mov));

            Page = apiModel.Page;
            TotalResults = 0; //apiModel.TotalResults.Value;
            TotalPages = apiModel.Total_Pages;
            SearchSuccess = true; // todo: set to true/false based on success of request
        }
        public bool SearchSuccess { get; set; }
        public List<MovieBasicViewModel> Results { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}