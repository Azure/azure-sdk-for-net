// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample demonstrates how to use Azure App Configuration to store
         * two (2) groups of settings with information about two different
         * application environments "beta" and "production". To do this, we will
         * create Configuration Settings with the same key, but different labels:
         * one for "beta" and one for "production".
        */
        public async Task HelloWorldExtended()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create the Configuration Settings to be stored in the Configuration Store.
            var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta");
            var betaInstances = new ConfigurationSetting("instances", "1", "beta");
            var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production");
            var productionInstances = new ConfigurationSetting("instances", "1", "production");

            // There are two ways to create a Configuration Setting:
            //   - AddConfigurationSettingAsync creates a setting only if the setting does not already exist in the store.
            //   - SetConfigurationSettingAsync creates a setting if it doesn't exist or overrides an existing setting with the same key and label.
            await client.AddConfigurationSettingAsync(betaEndpoint);
            await client.AddConfigurationSettingAsync(betaInstances);
            await client.AddConfigurationSettingAsync(productionEndpoint);
            await client.AddConfigurationSettingAsync(productionInstances);

            // In our scenario, there is a need to increase production instances from 1 to 5.
            // We use GetConfigurationSettingAsync to accomplish this.
            ConfigurationSetting instancesToUpdate = await client.GetConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
            instancesToUpdate.Value = "5";

            await client.SetConfigurationSettingAsync(instancesToUpdate);

            // To gather all the information available for the "production" environment, we can
            // call GetConfigurationSettingsAsync a setting selector that filters for settings
            // with the "production" label.  This will retrieve all the Configuration Settings
            // in the store that satisfy that condition.
            var selector = new SettingSelector(SettingSelector.Any, "production");

            Debug.WriteLine("Settings for Production environment:");
            await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
            {
                Debug.WriteLine(setting);
            }

            // Delete the Configuration Settings from the Configuration Store.
            await client.DeleteConfigurationSettingAsync(betaEndpoint.Key, betaEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(betaInstances.Key, betaInstances.Label);
            await client.DeleteConfigurationSettingAsync(productionEndpoint.Key, productionEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
        }
    }
}
