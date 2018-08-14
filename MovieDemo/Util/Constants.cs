using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDemo.Util
{
    public class AppValues
    {
        public static readonly string APP_NAME = "NOW PLAYING";
        public static readonly string SITE_NAME = "/MovieDemo";
    }

    public class Config
    {
        //OMDB values
        public static readonly string OMDB_API_KEY = "OmdbApiKey";
        public static readonly string OMDB_BASE_URL = "OmdbBaseUrl";
        public static readonly string IMDB_TITLE_URL = "ImdbTitleUrl";

        //TMDB Values
        public static readonly string TMDB_BASE_URL = "TmdbBaseUrl";
        public static readonly string TMDB_IMAGE_URL = "TmdbImageUrl";
        public static readonly string TMDB_MOVIE_SEARCH_URL = "TmdbMovieSearchUrl";
        public static readonly string TMDB_MOVIE_DETAILS_URL = "TmdbMovieDetailsUrl";
        public static readonly string TMDB_MOVIE_SEARCH_PARAM = "TmdbMovieSearchParam";
        public static readonly string TMDB_API_KEY = "TmdbApiKey";
        public static readonly string TMDB_API_KEY_VALUE = "TmdbApiKeyValue";
        public static readonly string TMDB_VERSION = "TmdbVersion";
    }

    public class Errors
    {
        public static readonly string BAD_LOGIN_KEY = "BadLogin";
    }

    public class RouteValues
    {
        public static readonly string MOVIE_DETAIL = "detail";
        public static readonly string MOVIE_DETAIL_ID = "id";
    }

    public class Controllers
    {
        public static readonly string MOVIE_CONTROLLER = "TmdbVersion";
    }

    public class Tmdb
    {
        public enum IMAGE_SIZES { W154 };
    }
}