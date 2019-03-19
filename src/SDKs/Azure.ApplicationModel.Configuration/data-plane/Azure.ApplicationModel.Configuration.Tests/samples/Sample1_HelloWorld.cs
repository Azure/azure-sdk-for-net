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
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a setting to be stored by the configuration service.
            var setting = new ConfigurationSetting("some_key", "some_value");

            // SetAsyc adds a new setting to the store or overrides an existing setting.
            // Alternativelly you can call AddAsync which only succeeds if the setting does not already exist in the store.
            // Or you can call UpdateAsync to update a setting that is already present in the store.
            await client.SetAsync(setting);

            // Retrieve a previously stored setting by calling GetAsync.
            ConfigurationSetting gotSetting = await client.GetAsync("some_key");
            Debug.WriteLine(gotSetting.Value);

            // Delete the setting when you don't need it anymore.
            await client.DeleteAsync("some_key");
        }
    }
}
