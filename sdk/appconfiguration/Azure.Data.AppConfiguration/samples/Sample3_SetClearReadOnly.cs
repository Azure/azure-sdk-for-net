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
         * Sample demonstrates how to use Azure App Configuration to make a configuration
         * value read only and set it back to read write.  This corresponds to the
         * lock and unlock operations on the service definition.
         */
        public void SetClearReadOnly()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store
            // to illustrate set and clear read only scenario.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // Add the setting to the Configuration Store.
            client.Set(setting);

            // Make the setting read only.
            client.SetReadOnly(setting.Key);

            // Modify the value to attempt to update it.
            setting.Value = "new_value";

            try
            {
                // Set() should throw because setting is read only and cannot be updated.
                client.Set(setting);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            // Make the setting read write again.
            client.ClearReadOnly(setting.Key);

            // Try to update to the new value again.
            // Set() should now succeed because setting is read write.
            client.Set(setting);
        }
    }
}
