// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Properties;

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Settings for authentication with an Azure or Azure Stack service using Active Directory.
    /// </summary>
    public sealed class ActiveDirectoryServiceSettings
    {
        private Uri _authenticationEndpoint;

        private static readonly ActiveDirectoryServiceSettings AzureSettings = new ActiveDirectoryServiceSettings
        {
            AuthenticationEndpoint= new Uri("https://login.microsoftonline.com/"), 
            TokenAudience = new Uri("https://management.core.windows.net/"),
            ValidateAuthority = true
        };

        private static readonly ActiveDirectoryServiceSettings AzureChinaSettings = new ActiveDirectoryServiceSettings
        {
            AuthenticationEndpoint= new Uri("https://login.chinacloudapi.cn/"), 
            TokenAudience = new Uri("https://management.core.chinacloudapi.cn/"),
            ValidateAuthority = true
        };

        private static readonly ActiveDirectoryServiceSettings AzureUSGovernmentSettings = new ActiveDirectoryServiceSettings
        {
            AuthenticationEndpoint = new Uri("https://login.microsoftonline.us/"),
            TokenAudience = new Uri("https://management.core.usgovcloudapi.net/"),
            ValidateAuthority = true
        };
 
        private static readonly ActiveDirectoryServiceSettings AzureGermanCloudSettings = new ActiveDirectoryServiceSettings
        {
            AuthenticationEndpoint = new Uri("https://login.microsoftonline.de/"),
            TokenAudience = new Uri("https://management.core.cloudapi.de/"),
            ValidateAuthority = true
        };

        /// <summary>
        /// Gets the serviceSettings for authentication with Azure
        /// </summary>
        public static ActiveDirectoryServiceSettings Azure { get { return AzureSettings; } }

        /// <summary>
        /// Gets the serviceSettings for authentication with Azure China
        /// </summary>
        public static ActiveDirectoryServiceSettings AzureChina { get { return AzureChinaSettings; } }

        /// <summary>
        /// Gets the serviceSettings for authentication with Azure US Government
        /// </summary>
        public static ActiveDirectoryServiceSettings AzureUSGovernment { get { return AzureUSGovernmentSettings; } }
 
        /// <summary>
        /// Gets the serviceSettings for authentication with Azure Germany
        /// </summary>
        public static ActiveDirectoryServiceSettings AzureGermany { get { return AzureGermanCloudSettings; } }

        /// <summary>
        /// Gets or sets the ActiveDirectory Endpoint for the Azure Environment
        /// </summary>
        public Uri AuthenticationEndpoint 
        {
            get { return _authenticationEndpoint; }
            set { _authenticationEndpoint = EnsureTrailingSlash(value); } 
        }

        /// <summary>
        /// Gets or sets the Token audience for an endpoint
        /// </summary>
        public Uri TokenAudience { get; set; }

        /// <summary>
        /// Gets or sets a value that determines whether the authentication endpoint should be validated with Azure AD
        /// </summary>
        public bool ValidateAuthority { get; set; }

        private static Uri EnsureTrailingSlash(Uri authenticationEndpoint)
        {
            if (authenticationEndpoint == null)
            {
                throw new ArgumentNullException("authenticationEndpoint");
            }

            UriBuilder builder = new UriBuilder(authenticationEndpoint);
            if (!string.IsNullOrEmpty(builder.Query))
            {
                throw new ArgumentOutOfRangeException(nameof(authenticationEndpoint), 
                    Resources.AuthenticationEndpointContainsQuery);
            }

            var path = builder.Path;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = "/";
            }
            else if (!path.EndsWith("/", StringComparison.Ordinal))
            {
                path = path + "/";
            }

            builder.Path = path;
            return builder.Uri;
        }
    }
}
