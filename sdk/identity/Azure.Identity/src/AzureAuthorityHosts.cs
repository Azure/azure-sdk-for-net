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
        private const string AzureCloudHostUrl = "https://login.microsoftonline.com/";
        private const string AzureChinaCloudHostUrl = "https://login.chinacloudapi.cn/";
        private const string AzureGermanCloudHostUrl = "https://login.microsoftonline.de/";
        private const string AzureGovernmentHostUrl = "https://login.microsoftonline.us/";
        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure Public Cloud.
        /// </summary>
        public static Uri AzureCloud { get; } = new Uri(AzureCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure China Cloud.
        /// </summary>
        public static Uri AzureChinaCloud { get; } = new Uri(AzureChinaCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure German Cloud.
        /// </summary>
        public static Uri AzureGermanCloud { get; } = new Uri(AzureGermanCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure US Government Cloud.
        /// </summary>
        public static Uri AzureGovernment { get; } = new Uri(AzureGovernmentHostUrl);

        internal static Uri GetDefault()
        {
            return EnvironmentVariables.AuthorityHost != null ? new Uri(EnvironmentVariables.AuthorityHost) : AzureAuthorityHosts.AzureCloud;
        }

        internal static string GetDefaultScope(Uri authorityHost)
        {
            switch (authorityHost.ToString())
            {
                case AzureCloudHostUrl:
                    return "https://management.core.windows.net//.default";
                case AzureChinaCloudHostUrl:
                    return "https://management.core.chinacloudapi.cn//.default";
                case AzureGermanCloudHostUrl:
                    return "https://management.core.cloudapi.de//.default";
                case AzureGovernmentHostUrl:
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
