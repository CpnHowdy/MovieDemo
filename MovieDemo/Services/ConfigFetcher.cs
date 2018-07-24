using MovieDemo.Util;
using System.Collections.Generic;
using System.Web.Configuration;

namespace MovieDemo.Services
{
    public class ConfigFetcher
    {
        public string Fetch(string configKey)
        {
            // Get all settings
            var rootWebConfig = WebConfigurationManager.OpenWebConfiguration(AppValues.SITE_NAME);
            if (rootWebConfig.AppSettings.Settings.Count == 0)
                throw new KeyNotFoundException($"{configKey} not found.");

            // Get api url
            var customSetting = rootWebConfig.AppSettings.Settings[configKey];
            if (customSetting == null || string.IsNullOrEmpty(customSetting.Value))
                throw new KeyNotFoundException($"{configKey} not found.");

            // Return url
            return customSetting.Value;
        }
    }
}