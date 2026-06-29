// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

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
        private const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;
        private const string AzConfigUsGovCloudHostName = "azconfig.azure.us";
        private const string AzConfigChinaCloudHostName = "azconfig.azure.cn";
        private const string AppConfigUsGovCloudHostName = "appconfig.azure.us";
        private const string AppConfigChinaCloudHostName = "appconfig.azure.cn";
        private const string AzConfigPublicCloudHostName = "azconfig.io";
        private const string AppConfigStagingCloudHostName = "appconfig-staging.azure.com";

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
            V2023_11_01 = 2,

            /// <summary>
            /// Version 2024-09-01.
            /// </summary>
            V2024_09_01 = 3,

            /// <summary>
            /// Version 2026-04-01.
            /// </summary>
            V2026_04_01 = 4
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
            Version = GetVersionString(version);
            this.ConfigureLogging();
        }

        [Experimental("SCME0002")]
        internal ConfigurationClientOptions(IConfigurationSection section)
            : base(section, null)
        {
            Version = GetVersionString(LatestVersion);

            string audience = section["Audience"];
            if (!string.IsNullOrEmpty(audience))
            {
                Audience = new AppConfigurationAudience(audience);
            }

            this.ConfigureLogging();
        }

        private static string GetVersionString(ServiceVersion version) => version switch
        {
            ServiceVersion.V1_0 => "1.0",
            ServiceVersion.V2023_10_01 => "2023-10-01",
            ServiceVersion.V2023_11_01 => "2023-11-01",
            ServiceVersion.V2024_09_01 => "2024-09-01",
            ServiceVersion.V2026_04_01 => "2026-04-01",

            _ => throw new NotSupportedException()
        };

        internal string GetDefaultScope(Uri uri)
        {
            if (!string.IsNullOrEmpty(Audience?.ToString()))
            {
                return $"{Audience}/.default";
            }

            string host = uri.GetComponents(UriComponents.Host, UriFormat.SafeUnescaped);
            return host switch
            {
                _ when IsHostInDomain(host, AzConfigUsGovCloudHostName) || IsHostInDomain(host, AppConfigUsGovCloudHostName)
                    => $"{AppConfigurationAudience.AzureGovernment}/.default",
                _ when IsHostInDomain(host, AzConfigChinaCloudHostName) || IsHostInDomain(host, AppConfigChinaCloudHostName)
                    => $"{AppConfigurationAudience.AzureChina}/.default",
                _ when IsHostInDomain(host, AzConfigPublicCloudHostName)
                    => $"{AppConfigurationAudience.AzurePublicCloud}/.default",
                _ when IsHostInDomain(host, AppConfigStagingCloudHostName)
                    => $"https://{AppConfigStagingCloudHostName}/.default",
                _ => $"{GetAudienceFromHost(host)}/.default"
            };
        }

        // CUSTOM: Returns true when the host equals the domain or is a subdomain of it, matching on a
        // DNS label boundary so unrelated hosts such as "myazconfig.io" are not treated as "azconfig.io".
        private static bool IsHostInDomain(string host, string domain) =>
            host.Equals(domain, StringComparison.InvariantCultureIgnoreCase) ||
            host.EndsWith("." + domain, StringComparison.InvariantCultureIgnoreCase);

        // CUSTOM: Derives the Microsoft Entra audience from the endpoint host when no audience
        // is explicitly configured and the host does not match a well-known cloud. The audience
        // domain is anchored on the App Configuration service label ("appconfig"/"azconfig"),
        // searching right-to-left so that leading store/region labels are ignored even if they
        // happen to begin with the marker. For example, "<store>.<region>.appconfig.azure.com"
        // yields "https://appconfig.azure.com". Falls back to the public cloud audience when no
        // recognizable App Configuration marker is present.
        private static string GetAudienceFromHost(string host)
        {
            string[] labels = host.Split('.');
            for (int i = labels.Length - 2; i >= 0; i--)
            {
                if (IsAppConfigLabel(labels[i]))
                {
                    return $"https://{string.Join(".", labels, i, labels.Length - i)}";
                }
            }

            return AppConfigurationAudience.AzurePublicCloud.ToString();
        }

        // CUSTOM: Matches the App Configuration service label exactly ("appconfig"/"azconfig"), so
        // look-alike or hyphenated labels such as "appconfigfoo" or "appconfig-test" are not treated
        // as the service marker.
        private static bool IsAppConfigLabel(string label) =>
            label.Equals("appconfig", StringComparison.InvariantCultureIgnoreCase) ||
            label.Equals("azconfig", StringComparison.InvariantCultureIgnoreCase);
    }
}
