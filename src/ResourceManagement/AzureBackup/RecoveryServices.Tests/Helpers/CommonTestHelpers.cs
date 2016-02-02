using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryServices.Tests.Helpers
{
    public class CommonTestHelper
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static CustomRequestHeaders GetCustomRequestHeaders()
        {
            return new CustomRequestHeaders()
            {
                ClientRequestId = Guid.NewGuid().ToString(),
            };
        }
    }
}
