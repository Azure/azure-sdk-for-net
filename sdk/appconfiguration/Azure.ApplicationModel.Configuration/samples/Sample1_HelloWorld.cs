// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Azure.Data.AppConfiguration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public void HelloWorld()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // There are two ways to store a Configuration Setting:
            //   -AddAsync creates a setting only if the setting does not already exist in the store.
            //   -SetAsync creates a setting if it doesn't exist or overrides an existing setting
            client.Set(setting);

            // Retrieve a previously stored Configuration Setting by calling GetAsync.
            ConfigurationSetting gotSetting = client.Get("some_key");
            Debug.WriteLine(gotSetting.Value);

            // Delete the Configuration Setting from the Configuration Store when you don't need it anymore.
            client.Delete("some_key");
        }
    }
}
