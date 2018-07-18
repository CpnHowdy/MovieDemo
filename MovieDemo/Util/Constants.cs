using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDemo.Util
{
    public class AppValues
    {
        public static readonly string APP_NAME = "Movie Tracker";
        public static readonly string SITE_NAME = "/MovieDemo";
    }

    public class Config
    {
        public static readonly string OMDB_API_KEY = "OmdbApiKey";
        public static readonly string OMDB_BASE_URL = "OmdbBaseUrl";
        public static readonly string IMDB_TITLE_URL = "ImdbTitleUrl";
    }
}