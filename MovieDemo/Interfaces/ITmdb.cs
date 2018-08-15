using MovieDemo.Models;
using System;

namespace MovieDemo.Interfaces
{
    public interface ITmdb
    {
        string ApiKey { get; }
        string BaseUrl { get; }

        TmdbQueryResultsJson Search(string query);
        TmdbQueryResultsJson ParseTmdbQueryResultsJson(string json);

        TmdbMovieDetailsJson Details(int id, string posterPath);
        TmdbMovieDetailsJson ParseTmdbDetailsJson(string json);

        void AddMovie(int tmdbId, string userId);
    }
}