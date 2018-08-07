using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    [NotMapped]
    public class TmdbQueryResultsJson
    {
        public List<TmdbMovieJson> Results { get; set; }
        public int Page { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
    }

    /// <summary>
    ///     Model for movie results coming out of TMDB API
    /// </summary>
    [NotMapped]
    public class TmdbMovieJson
    {
        public int Vote_Count { get; set; }
        public int Id { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public int[] Genre_Ids { get; set; }
        public string Backdrop_Path { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public DateTime? Release_Date { get; set; }
    }
}