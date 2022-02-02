// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Defines fields exposing the well known authority hosts for the Azure Public Cloud and sovereign clouds.
    /// </summary>
    public static class AzureAuthorityHosts
    {
        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure Public Cloud.
        /// </summary>
        public static Uri AzurePublicCloud { get; } = new Uri(Constants.AzurePublicCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure China Cloud.
        /// </summary>
        public static Uri AzureChina { get; } = new Uri(Constants.AzureChinaHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure German Cloud.
        /// </summary>
        public static Uri AzureGermany { get; } = new Uri(Constants.AzureGermanyHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure US Government Cloud.
        /// </summary>
        public static Uri AzureGovernment { get; } = new Uri(Constants.AzureGovernmentHostUrl);

        internal static Uri GetDefault()
        {
            if (EnvironmentVariables.AuthorityHost != null)
            {
                return new Uri(EnvironmentVariables.AuthorityHost);
            }

            return AzurePublicCloud;
        }

        internal static string GetDefaultScope(Uri authorityHost)
        {
            switch (authorityHost.AbsoluteUri)
            {
                case Constants.AzurePublicCloudHostUrl:
                    return "https://management.core.windows.net//.default";
                case Constants.AzureChinaHostUrl:
                    return "https://management.core.chinacloudapi.cn//.default";
                case Constants.AzureGermanyHostUrl:
                    return "https://management.core.cloudapi.de//.default";
                case Constants.AzureGovernmentHostUrl:
                    return "https://management.core.usgovcloudapi.net//.default";
                default:
                    return null;
            }
        }

        internal static Uri GetDeviceCodeRedirectUri(Uri authorityHost)
        {
            return new Uri(authorityHost, "/common/oauth2/nativeclient");
        }
    }
}
