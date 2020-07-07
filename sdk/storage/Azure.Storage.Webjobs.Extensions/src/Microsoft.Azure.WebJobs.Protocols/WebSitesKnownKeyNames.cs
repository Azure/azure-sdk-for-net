// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Defines well-known environment variable names for Azure Web Sites data.</summary>
#if PUBLICPROTOCOL
    public static class WebSitesKnownKeyNames
#else
    internal static class WebSitesKnownKeyNames
#endif
    {
        /// <summary>An environment variable containing the Web Site name.</summary>
        public const string WebSiteNameKey = "WEBSITE_SITE_NAME";

        /// <summary>An environment variable containing the path to WebJobs data.</summary>
        public const string JobDataPath = "WEBJOBS_DATA_PATH";

        /// <summary>An environment variable containing the WebJobs name.</summary>
        public const string JobNameKey = "WEBJOBS_NAME";

        /// <summary>An environment variable containing the WebJobs type.</summary>
        public const string JobTypeKey = "WEBJOBS_TYPE";

        /// <summary>An environment variable containing the WebJobs run ID.</summary>
        public const string JobRunIdKey = "WEBJOBS_RUN_ID";
    }
}
