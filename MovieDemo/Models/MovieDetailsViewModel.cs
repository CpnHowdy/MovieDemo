using System.Collections.Generic;
using System.ComponentModel;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movies
    /// </summary>
    public class MovieDetailsViewModel : MovieBasicViewModel
    {
        public MovieDetailsViewModel(TmdbMovieDetailsJson json) : base(json)
        {
            Budget = json.Budget;
            Genres = json.Genres;
            ImdbId = json.Imdb_Id;
            Production_Companies = json.Production_Companies;
            Revenue = json.Revenue;
            Runtime = json.Runtime;
            Status = json.Status;
            Tagline = json.Tagline;
        }

        public int Budget { get; set; }
        public List<TmdbGenreJson> Genres { get; set; }
        public string ImdbId { get; set; }
        public List<TmdbCompanyJson> Production_Companies { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
    }
}