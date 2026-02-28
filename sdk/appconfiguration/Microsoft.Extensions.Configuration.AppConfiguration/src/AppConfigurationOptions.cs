// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Data.AppConfiguration;

namespace Microsoft.Extensions.Configuration.AppConfiguration
{
    /// <summary>
    /// Options class used by the <see cref="AppConfigurationExtensions"/>.
    /// </summary>
    internal class AppConfigurationOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="AppConfigurationOptions"/>.
        /// </summary>
        public AppConfigurationOptions()
        {
            Manager = AppConfigurationSettingManager.Instance;
        }

        /// <summary>
        /// Gets or sets the <see cref="AppConfigurationSettingManager"/> instance used to control setting loading.
        /// </summary>
        public AppConfigurationSettingManager Manager { get; set; }

        /// <summary>
        /// Gets or sets the timespan to wait between attempts at polling Azure App Configuration for changes. <code>null</code> to disable reloading.
        /// </summary>
        public TimeSpan? ReloadInterval { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SettingSelector"/> used to filter which configuration settings are loaded. <code>null</code> to load all settings.
        /// </summary>
        public SettingSelector Selector { get; set; }
    }
}
