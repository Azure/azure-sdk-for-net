﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * Sample demonstrates how to use Azure App Configuration to save information about two(2) environments
         * "beta" and "production".
         * To do this, we will create Configuration Settings with the same key,
         * but different labels: one for "beta" and one for "production".
        */
        public async Task HelloWorldExtended()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal or using Azure CLI.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create the Configuration Settings to be stored in the Configuration Store.
            var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta");
            var betaInstances = new ConfigurationSetting("instances", "1", "beta");
            var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production");
            var productionInstances = new ConfigurationSetting("instances", "1", "production");

            // There are two(2) ways to store a Configuration Setting:
            //   -AddAsync creates a setting only if the setting does not already exist in the store.
            //   -SetAsync creates a setting if it doesn't exist or overrides an existing setting
            await client.AddConfigurationSettingAsync(betaEndpoint);
            await client.AddConfigurationSettingAsync(betaInstances);
            await client.AddConfigurationSettingAsync(productionEndpoint);
            await client.AddConfigurationSettingAsync(productionInstances);

            // There is a need to increase the production instances from 1 to 5.
            // The SetAsync will help us with this.
            ConfigurationSetting instancesToUpdate = await client.GetConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
            instancesToUpdate.Value = "5";

            await client.SetConfigurationSettingAsync(instancesToUpdate);

            // We want to gather all the information available for the "production' environment.
            // By calling GetBatchSync with the proper filter for label "production", we will get
            // all the Configuration Settings that satisfy that condition.
            var selector = new SettingSelector(null, "production");

            Debug.WriteLine("Settings for Production environmnet");
            await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
            {
                Debug.WriteLine(setting);
            }

            // Once we don't need the Configuration Setting, we can delete them.
            await client.DeleteConfigurationSettingAsync(betaEndpoint.Key, betaEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(betaInstances.Key, betaInstances.Label);
            await client.DeleteConfigurationSettingAsync(productionEndpoint.Key, productionEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
        }
    }
}
