using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.douglas.automation.Support
{
    public static class ConfigReader
    {
        private static IConfigurationRoot _configuration;

        static ConfigReader()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetSetting(string key)
        {
            return _configuration[$"AppSettings:{key}"];
        }
    }
}
