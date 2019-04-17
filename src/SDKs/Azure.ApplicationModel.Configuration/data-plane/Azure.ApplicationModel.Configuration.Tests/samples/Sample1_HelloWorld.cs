// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task HelloWorld()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal or using Azure CLI.
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration Store.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // There are two ways to store a Configuration Setting:
            //   -AddAsync creates a setting only if the setting does not already exist in the store.
            //   -SetAsync creates a setting if it doesn't exist or overrides an existing setting
            await client.SetAsync(setting);

            // Retrieve a previously stored Configuration Setting by calling GetAsync.
            ConfigurationSetting gotSetting = await client.GetAsync("some_key");
            Debug.WriteLine(gotSetting.Value);

            // Delete the Configuration Setting from the Configuration Store when you don't need it anymore.
            await client.DeleteAsync("some_key");
        }
    }
}
