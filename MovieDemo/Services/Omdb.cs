using MovieDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web.Configuration;
using MovieDemo.Util;
using System.Net.Http;

namespace MovieDemo.Services
{
    public class Omdb : IOmdb
    {
        /// <summary>
        ///     Gets API key from web config
        /// </summary>
        public string ApiKey
        {
            get
            {
                // Get all settings
                var rootWebConfig = WebConfigurationManager.OpenWebConfiguration(AppValues.SITE_NAME);
                if (rootWebConfig.AppSettings.Settings.Count == 0)
                    throw new KeyNotFoundException($"{Config.OMDB_API_KEY} not found.");

                // Get api url
                var customSetting = rootWebConfig.AppSettings.Settings[Config.OMDB_API_KEY];
                if (customSetting == null || string.IsNullOrEmpty(customSetting.Value))
                    throw new KeyNotFoundException($"{Config.OMDB_API_KEY} not found.");

                // Return url
                return customSetting.Value;
            }
        }

        /// <summary>
        ///     Gets base url from web config
        /// </summary>
        public string BaseUrl
        {
            get
            {
                // Get all settings
                var rootWebConfig = WebConfigurationManager.OpenWebConfiguration(AppValues.SITE_NAME);
                if (rootWebConfig.AppSettings.Settings.Count == 0)
                    throw new KeyNotFoundException($"{Config.OMDB_BASE_URL} not found.");

                // Get api url
                var customSetting = rootWebConfig.AppSettings.Settings[Config.OMDB_BASE_URL];
                if (customSetting == null || string.IsNullOrEmpty(customSetting.Value))
                    throw new KeyNotFoundException($"{Config.OMDB_BASE_URL} not found.");

                // Return url
                return customSetting.Value;
            }
        }

        /// <summary>
        ///     Combines url & key into a url for querying
        /// </summary>
        public string BaseQuery
        {
            get
            {
                var fullUrl = $"{BaseUrl}/?apikey={ApiKey}";
                return fullUrl;
            }
        }

        public object QueryTitle(string title)
        {
            var url = $"{BaseQuery}&i={title}";
            var client = new HttpClient();

            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return data;
        }
    }
}