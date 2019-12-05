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
         * This sample ilustrates the simple scenario of adding a setting to a
         * configuration store, retrieving it from the configuration store, and
         * finally, deleting it from the configuration store.
         */
        public void HelloWorld()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // There are two ways to create a Configuration Setting:
            //   - AddConfigurationSetting creates a setting only if the setting does not already exist in the store.
            //   - SetConfigurationSetting creates a setting if it doesn't exist or overrides an existing setting with the same key and label.
            client.SetConfigurationSetting(setting);

            // Retrieve a previously stored Configuration Setting by calling GetConfigurationSetting.
            ConfigurationSetting retrievedSetting = client.GetConfigurationSetting("some_key");
            Debug.WriteLine($"The value of the configuration setting is: {retrievedSetting.Value}");

            // Delete the Configuration Setting from the Configuration Store.
            client.DeleteConfigurationSetting("some_key");
        }
    }
}
