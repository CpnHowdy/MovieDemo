using System.Collections.Generic;
using System.ComponentModel;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movies
    /// </summary>
    public class OmdbMovieViewModel
    {
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Year")]
        public string Year { get; set; }
        [DisplayName("Rated")]
        public string Rated { get; set; }
        [DisplayName("Released")]
        public string Released { get; set; }
        [DisplayName("Runtime")]
        public string Runtime { get; set; }
        [DisplayName("Genre")]
        public string Genre { get; set; }
        [DisplayName("Director")]
        public string Director { get; set; }
        [DisplayName("Writer")]
        public string Writer { get; set; }
        [DisplayName("Actors")]
        public string Actors { get; set; }
        [DisplayName("Plot")]
        public string Plot { get; set; }
        [DisplayName("Language")]
        public string Language { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Awards")]
        public string Awards { get; set; }
        [DisplayName("Poster")]
        public string Poster { get; set; }
        [DisplayName("IMDB Rating")]
        public string ImdbRating { get; set; }
        [DisplayName("IMDB  Votes")]
        public string ImdbVotes { get; set; }
        [DisplayName("IMDB  ID")]
        public string ImdbID { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }
        [DisplayName("DVD")]
        public string DVD { get; set; }
        [DisplayName("BoxOffice")]
        public string BoxOffice { get; set; }
        [DisplayName("Production")]
        public string Production { get; set; }
        [DisplayName("Website")]
        public string Website { get; set; }
        [DisplayName("Response")]
        public string Response { get; set; }
        [DisplayName("Rotten Tomatoes Score")]
        public string RTRating { get; set; }

        public OmdbMovieViewModel() { }
        public OmdbMovieViewModel(OmdbMovie toConvert)
        {
            Title = toConvert.Title;
            Year = toConvert.Year;
            Rated = toConvert.Rated;
            Released = toConvert.Released;
            Runtime = toConvert.Runtime;
            Genre = toConvert.Genre;
            Director = toConvert.Director;
            Writer = toConvert.Writer;
            Actors = toConvert.Actors;
            Plot = toConvert.Plot;
            Language = toConvert.Language;
            Country = toConvert.Country;
            Awards = toConvert.Awards;
            Poster = toConvert.Poster;
            ImdbRating = toConvert.imdbRating;
            ImdbVotes = toConvert.imdbVotes;
            ImdbID = toConvert.imdbID;
            Type = toConvert.Type;
            DVD = toConvert.DVD;
            BoxOffice = toConvert.BoxOffice;
            Production = toConvert.Production;
            Website = toConvert.Website;
            Response = toConvert.Response;
        }

        //[DisplayName("Ratings")]
        //public List<OmdbRatingViewModel> Ratings { get; set; }
    }

    public class OmdbRatingViewModel
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}