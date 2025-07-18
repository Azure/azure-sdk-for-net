// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Suppressed generated client options.
    /// <summary>
    /// Options that allow users to configure the requests sent to the App Configuration service.
    /// </summary>
    [CodeGenSuppress("ConfigurationClientOptions", typeof(ServiceVersion))]
    public partial class ConfigurationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_11_01;
        private const string AzConfigUsGovCloudHostName = "azconfig.azure.us";
        private const string AzConfigChinaCloudHostName = "azconfig.azure.cn";
        private const string AppConfigUsGovCloudHostName = "appconfig.azure.us";
        private const string AppConfigChinaCloudHostName = "appconfig.azure.cn";

        /// <summary>
        /// The versions of the App Configuration service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 1.0.
            /// </summary>
            V1_0 = 0,

            /// <summary>
            /// Version 2023-10-01.
            /// </summary>
            V2023_10_01 = 1,

            /// <summary>
            /// Version 2023-11-01.
            /// </summary>
            V2023_11_01 = 2
        }

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Microsoft Entra. The audience is not considered when using a shared key.
        /// </summary>
        public AppConfigurationAudience? Audience { get; set; }

        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public ConfigurationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
                ServiceVersion.V2023_10_01 => "2023-10-01",
                ServiceVersion.V2023_11_01 => "2023-11-01",

                _ => throw new NotSupportedException()
            };
            this.ConfigureLogging();
        }

        internal string GetDefaultScope(Uri uri)
        {
            if (string.IsNullOrEmpty(Audience?.ToString()))
            {
                string host = uri.GetComponents(UriComponents.Host, UriFormat.SafeUnescaped);
                return host switch
                {
                    _ when host.EndsWith(AzConfigUsGovCloudHostName, StringComparison.InvariantCultureIgnoreCase) || host.EndsWith(AppConfigUsGovCloudHostName, StringComparison.InvariantCultureIgnoreCase)
                        => $"{AppConfigurationAudience.AzureGovernment}/.default",
                    _ when host.EndsWith(AzConfigChinaCloudHostName, StringComparison.InvariantCultureIgnoreCase) || host.EndsWith(AppConfigChinaCloudHostName, StringComparison.InvariantCultureIgnoreCase)
                        => $"{AppConfigurationAudience.AzureChina}/.default",
                    _ => $"{AppConfigurationAudience.AzurePublicCloud}/.default"
                };
            }

            return $"{Audience}/.default";
        }
    }
}
