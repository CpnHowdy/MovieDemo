using MovieDemo.Models;

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
    }
}