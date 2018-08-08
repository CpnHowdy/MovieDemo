using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDemo.Models
{
    [NotMapped]
    public class TmdbQueryResultsJson
    {
        public List<TmdbMovieBasicJson> Results { get; set; }
        public int Page { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
    }

    /// <summary>
    ///     Model for movie results coming out of TMDB API
    /// </summary>
    [NotMapped]
    public class TmdbMovieBasicJson
    {
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public int[] Genre_Ids { get; set; }
        public int Id { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public DateTime? Release_Date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public int Vote_Count { get; set; }
    }

    /// <summary>
    ///     Model for movie results coming out of TMDB API
    /// </summary>
    [NotMapped]
    public class TmdbMovieDetailsJson : TmdbMovieBasicJson
    {
        public int Budget { get; set; }
        public List<TmdbGenreJson> Genres { get; set; }
        public string Imdb_Id { get; set; }
        public List<TmdbCompanyJson> Production_Companies { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
    }

    [NotMapped]
    public class TmdbGenreJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [NotMapped]
    public class TmdbCompanyJson
    {
        public int Id { get; set; }
        public string Logo_Path { get; set; }
        public string Name { get; set; }
        public string Origin_Country { get; set; }
    }

    [NotMapped]
    public class TmdbCountryJson
    {
        public string Iso_3166_1 { get; set; }
        public string Name { get; set; }
    }
}