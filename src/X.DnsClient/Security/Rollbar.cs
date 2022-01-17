using Microsoft.Extensions.Configuration;
using Rollbar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace X.DnsClient.Security
{
    public static class Rollbar
    {
        public static void LogError(Exception ex)
        {
            string BasePath = Directory.GetCurrentDirectory();
            IConfigurationRoot MyConfiguration = new ConfigurationBuilder().SetBasePath(BasePath).AddJsonFile("appsettings.json").Build();
            string rollBarKey = MyConfiguration["CustomConfig:RollbarConfig:Key"];
            bool rollBarEnabled = Convert.ToBoolean(MyConfiguration["CustomConfig:RollbarConfig:IsEnabled"]);

            if (rollBarEnabled)
            {
                RollbarLocator.RollbarInstance.Configure(new RollbarConfig(rollBarKey));
                RollbarLocator.RollbarInstance.AsBlockingLogger(TimeSpan.FromSeconds(1)).Error(ex);
            }
        }

        public static void LogInfo(string message)
        {
            string BasePath = Directory.GetCurrentDirectory();
            IConfigurationRoot MyConfiguration = new ConfigurationBuilder().SetBasePath(BasePath).AddJsonFile("appsettings.json").Build();
            string rollBarKey = MyConfiguration["CustomConfig:RollbarConfig:Key"];
            bool rollBarEnabled = Convert.ToBoolean(MyConfiguration["CustomConfig:RollbarConfig:IsEnabled"]);

            if (rollBarEnabled)
            {
                RollbarLocator.RollbarInstance.Configure(new RollbarConfig(rollBarKey));
                RollbarLocator.RollbarInstance.Info(message);
            }
        }
    }
}
