// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Data.AppConfiguration;

namespace Microsoft.Extensions.Configuration.AppConfiguration
{
    /// <summary>
    /// Default implementation of <see cref="AppConfigurationSettingManager"/> that loads all settings
    /// and replaces '--' with ':' in key names.
    /// </summary>
    internal class AppConfigurationSettingManager
    {
        internal static AppConfigurationSettingManager Instance { get; } = new AppConfigurationSettingManager();

        /// <summary>
        /// Maps a setting to a configuration key.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> instance.</param>
        /// <returns>Configuration key name to store setting value.</returns>
        public virtual string GetKey(ConfigurationSetting setting)
        {
            return setting.Key;
        }

        /// <summary>
        /// Converts a loaded list of settings into a corresponding set of configuration key-value pairs.
        /// </summary>
        /// <param name="settings">A set of settings retrieved during <see cref="AppConfigurationProvider.Load"/> call.</param>
        /// <returns>The dictionary of configuration key-value pairs that would be assigned to the <see cref="ConfigurationProvider.Data"/>
        /// and exposed from the <see cref="IConfiguration"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="settings"/> is <code>null</code>.</exception>
        public virtual Dictionary<string, string> GetData(IEnumerable<ConfigurationSetting> settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var setting in settings)
            {
                string key = GetKey(setting);

                data[key] = setting.Value;
            }

            return data;
        }

        /// <summary>
        /// Checks if a <see cref="ConfigurationSetting"/> should be loaded.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> instance.</param>
        /// <returns><code>true</code> if the setting value should be loaded, otherwise <code>false</code>.</returns>
        public virtual bool Load(ConfigurationSetting setting)
        {
            return true;
        }
    }
}
