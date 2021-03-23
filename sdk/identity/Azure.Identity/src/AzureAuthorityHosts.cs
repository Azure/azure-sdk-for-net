﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Defines fields exposing the well known authority hosts for the Azure Public Cloud and sovereign clouds.
    /// </summary>
    public static class AzureAuthorityHosts
    {
        private const string AzurePublicCloudHostUrl = "https://login.microsoftonline.com/";
        private const string AzureChinaHostUrl = "https://login.chinacloudapi.cn/";
        private const string AzureGermanyHostUrl = "https://login.microsoftonline.de/";
        private const string AzureGovernmentHostUrl = "https://login.microsoftonline.us/";
        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure Public Cloud.
        /// </summary>
        public static Uri AzurePublicCloud { get; } = new Uri(AzurePublicCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure China Cloud.
        /// </summary>
        public static Uri AzureChina { get; } = new Uri(AzureChinaHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure German Cloud.
        /// </summary>
        public static Uri AzureGermany { get; } = new Uri(AzureGermanyHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure US Government Cloud.
        /// </summary>
        public static Uri AzureGovernment { get; } = new Uri(AzureGovernmentHostUrl);

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
            switch (authorityHost.ToString())
            {
                case AzurePublicCloudHostUrl:
                    return "https://management.core.windows.net//.default";
                case AzureChinaHostUrl:
                    return "https://management.core.chinacloudapi.cn//.default";
                case AzureGermanyHostUrl:
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
