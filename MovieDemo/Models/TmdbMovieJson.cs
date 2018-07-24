using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    public class TmdbQueryResultsJson
    {
        [JsonProperty("results")]
        public List<TmdbMovieJson> Results { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    /// <summary>
    ///     Model for movie results coming out of TMDB API
    /// </summary>
    [NotMapped]
    public class TmdbMovieJson
    {
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("video")]
        public bool Video { get; set; }
        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }
        [JsonProperty("poster_path")]
        public string Poster_path { get; set; }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        [JsonProperty("genre_ids")]
        public int[] GenreIds { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }
    }
}