// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample ilustrates how to get a setting from the configuration
         * store only if the version in the configuration store is different
         * from the one held by your client application, as determined by whether
         * the setting ETags match.  Getting a setting only if it has changed
         * allows you to avoid downloading a setting if your client application
         * is already holding the latest value, which saves cost and bandwidth.
         */
        public void GetSettingIfChanged()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store.
            ConfigurationSetting setting = new ConfigurationSetting("some_key", "initial_value");

            // Add the setting to the Configuration Store.
            ConfigurationSetting settingV1 = client.SetConfigurationSetting(setting);

            // Download the setting only if it's changed.
            Response<ConfigurationSetting> response = client.GetConfigurationSetting(settingV1, onlyIfChanged: true);

            // This ConfigurationSetting object will hold the most up-to-date version of the setting.
            ConfigurationSetting latestSetting = null;

            // Check to see whether the setting was changed in the configuration store before accessing its value.
            // If response.Value is accessed when no value was returned, an exception will be thrown.
            Debug.WriteLine($"Received a response code of {response.GetRawResponse().Status}");
            if (response.GetRawResponse().Status == 304)
            {
                // We already have the Nothing to change in local version.
                latestSetting = settingV1;
            }
            else if (response.GetRawResponse().Status == 200)
            {
                // The configuration store held a newer version of this setting.
                // Update the client's version.
                latestSetting = response.Value;
            }

            Debug.WriteLine($"Latest version of setting is {latestSetting}.");

            // Delete the Configuration Setting from the Configuration Store when you don't need it anymore.
            client.DeleteConfigurationSetting("some_key");
        }
    }
}
