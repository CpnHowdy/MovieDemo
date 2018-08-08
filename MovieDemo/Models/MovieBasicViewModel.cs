using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movie results coming out of TMDB API
    /// </summary>
    [NotMapped]
    public class MovieBasicViewModel
    {
        public MovieBasicViewModel() { }
        public MovieBasicViewModel(TmdbMovieBasicJson jsonObj)
        {
            VoteCount = jsonObj.Vote_Count;
            Id = jsonObj.Id;
            Video = jsonObj.Video;
            VoteAverage = jsonObj.Vote_Average;
            Title = jsonObj.Title;
            Popularity = jsonObj.Popularity;
            PosterPath = jsonObj.Poster_path;
            OriginalLanguage = jsonObj.Original_Language;
            OriginalTitle = jsonObj.Original_Title;
            GenreIds = jsonObj.Genre_Ids;
            BackdropPath = jsonObj.Backdrop_Path;
            Adult = jsonObj.Adult;
            Overview = jsonObj.Overview;
            ReleaseDate = jsonObj.Release_Date;
        }

        public int VoteCount { get; set; }
        public int Id { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public int[] GenreIds { get; set; }
        public string BackdropPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}