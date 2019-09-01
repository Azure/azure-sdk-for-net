// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * Sample demonstrates how to use Azure App Configuration to lock and 
         * unlock a configuration setting.
        */
        public void LockUnlockSetting()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store
            // to illustrate lock/unlock scenario.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // Add the setting to the Configuration Store.
            client.Set(setting);

            // Lock the setting.
            client.Lock(setting.Key);

            // Modify the value to attempt to update it.
            setting.Value = "new_value";

            try
            {
                // Set() should throw because setting is locked and cannot be updated.
                client.Set(setting);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
            }

            // Unlock the setting.
            client.Unlock(setting.Key);

            // Try to update to the new value again.
            // Set() should now succeed because setting is unlocked.
            client.Set(setting);
        }
    }
}
