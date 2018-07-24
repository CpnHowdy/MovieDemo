using MovieDemo.Models;

namespace MovieDemo.Interfaces
{
    public interface ITmdb
    {
        string ApiKey { get; }
        string BaseUrl { get; }
        TmdbQueryResultsJson Search(string query);
    }
}