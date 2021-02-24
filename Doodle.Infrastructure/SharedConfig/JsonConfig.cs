using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Doodle.Infrastructure.SharedConfig
{
    public static class JsonConfig
    {
        public static IConfigurationBuilder ConfigurationContainer { get; private set; }
        public static IConfiguration CreateConfigurationContainer()
        {
            var environment = string.Empty;
            try
            {
                //environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                ConfigurationContainer = new ConfigurationBuilder();
                ConfigurationContainer.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                ConfigurationContainer.AddJsonFile($"SharedConfig/sharedsettings.json", true, true);

                return ConfigurationContainer.Build();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
