// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Extensions.Configuration
{
    public static class IConfigurationExtensions
    {
        private const string DefaultConfigurationRootSectionName = "AzureWebJobs";
        private const string ConfigurationRootSectionKey = "AzureWebJobsConfigurationSection";
        private const string ExtensionsSectionKey = "extensions";

        public static string GetWebJobsConnectionString(this IConfiguration configuration, string connectionStringName)
        {
            // first try prefixing
            string prefixedConnectionStringName = GetPrefixedConnectionStringName(connectionStringName);
            string connectionString = GetConnectionStringOrSetting(configuration, prefixedConnectionStringName);

            if (string.IsNullOrEmpty(connectionString))
            {
                // next try a direct unprefixed lookup
                connectionString = GetConnectionStringOrSetting(configuration, connectionStringName);
            }

            return connectionString;
        }

        public static IConfiguration GetWebJobsRootConfiguration(this IConfiguration configuration)
        {
            string configPath = configuration.GetWebJobsRootConfigurationPath();

            if (string.IsNullOrEmpty(configPath))
            {
                return configuration;
            }

            return configuration.GetSection(configPath);
        }

        public static IConfigurationSection GetWebJobsExtensionConfigurationSection(this IConfiguration configuration, string extensionName)
        {
            string configPath = configuration.GetWebJobsExtensionConfigurationSectionPath(extensionName);
            return configuration.GetSection(configPath);
        }

        public static string GetWebJobsRootConfigurationPath(this IConfiguration configuration)
        {
            return configuration[ConfigurationRootSectionKey] ?? DefaultConfigurationRootSectionName;
        }

        public static string GetWebJobsExtensionConfigurationSectionPath(this IConfiguration configuration, string extensionName)
        {
            string configPath = configuration.GetWebJobsRootConfigurationPath();
            configPath = string.IsNullOrEmpty(configPath)
                ? ExtensionsSectionKey
                : ConfigurationPath.Combine(configPath, ExtensionsSectionKey);

            if (extensionName != null)
            {
                configPath = ConfigurationPath.Combine(configPath, extensionName);
            }

            return configPath;
        }

        public static string GetPrefixedConnectionStringName(string connectionStringName)
        {
            return Constants.WebJobsConfigurationSectionName + connectionStringName;
        }

        /// <summary>
        /// Looks for a connection string by first checking the ConfigurationStrings section, and then the root.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="connectionName">The connection string key.</param>
        /// <returns></returns>
        public static string GetConnectionStringOrSetting(this IConfiguration configuration, string connectionName) =>
            configuration.GetConnectionString(connectionName) ?? configuration[connectionName];

        public static bool IsSettingEnabled(this IConfiguration configuration, string settingName)
        {
            // check the target setting and return false (disabled) if the value exists
            // and is "falsey"
            string value = configuration[settingName];
            if (!string.IsNullOrEmpty(value) &&
                (string.Compare(value, "1", StringComparison.OrdinalIgnoreCase) == 0 ||
                 string.Compare(value, "true", StringComparison.OrdinalIgnoreCase) == 0))
            {
                return true;
            }
            
            return false;
        }
    }
}
