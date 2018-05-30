using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Build.Tasks.Utilities
{
    /// <summary>
    /// Constants used within the Build.Tasks library
    /// </summary>
    static class Constants
    {

        /// <summary>
        /// Constants, defaults used for Nuget Publish task
        /// </summary>
        public static class NugetDefaults
        {
            public const string NUGET_PATH = "nuget.exe";
            public const string NUGET_PUBLISH_URL = "https://www.nuget.org/api/v2/package/";
            public const string NUGET_SYMBOL_PUBLISH_URL = "https://nuget.smbsrc.net";
            public const int NUGET_TIMEOUT = 60; //Seconds
            public const string DEFAULT_API_KEY = "1234";
            public const string SDK_NUGET_APIKEY_ENV = "NetSdkNugetApiKey";
        }
    }
}
