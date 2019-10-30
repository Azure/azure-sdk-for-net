// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample demonstrates how to use Azure App Configuration to make
         * a configuration value read only and then set it back to read-write.
         * This corresponds to the lock and unlock operations in the Azure portal.
         */
        public void SetClearReadOnly()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store
            // to illustrate the set and clear read only scenario.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // Add the setting to the Configuration Store.
            client.SetConfigurationSetting(setting);

            // Make the setting read only.
            client.SetReadOnly(setting.Key);

            // Modify the value to attempt to update it.
            setting.Value = "new_value";

            try
            {
                // SetConfigurationSetting should throw an exception because
                // the setting is read only and cannot be updated.
                client.SetConfigurationSetting(setting);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            // Make the setting read write again.
            client.ClearReadOnly(setting.Key);

            // Try to update to the new value again.
            // SetConfigurationSetting should now succeed because the setting is read write.
            client.SetConfigurationSetting(setting);

            // Delete the Configuration Setting from the Configuration Store.
            client.DeleteConfigurationSetting("some_key");
        }
    }
}
