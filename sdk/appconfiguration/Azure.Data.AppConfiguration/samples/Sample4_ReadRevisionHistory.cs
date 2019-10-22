// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample demonstrates how to read the revision history of one or
         * more Configuration Settings in a Configuration Store.
         *
         * To do this, we will create two settings, change them twice to create
         * revisions, then read the revision history first of one of them by
         * itself, and then the revision history of both of them together.
         */
        public async Task ReadRevisionHistory()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create the Configuration Settings to be stored in the Configuration Store.
            var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production");
            var productionInstances = new ConfigurationSetting("instances", "1", "production");

            await client.SetAsync(productionEndpoint);
            await client.SetAsync(productionInstances);

            // Create a first revision.
            productionEndpoint.Value = "https://production.endpoint.com/v1";
            productionInstances.Value = "5";
            await client.SetAsync(productionEndpoint);
            await client.SetAsync(productionInstances);

            // Create a second revision.
            productionEndpoint.Value = "https://production.endpoint.com/v2";
            productionInstances.Value = "10";
            await client.SetAsync(productionEndpoint);
            await client.SetAsync(productionInstances);

            // Retrieve revisions for just the endpoint setting.
            var endpointSettingSelector = new SettingSelector("endpoint", "production");

            Debug.WriteLine("Revisions of production endpoint setting: ");
            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(endpointSettingSelector))
            {
                Debug.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }

            // Retrieve revisions for both production settings.
            var productionSettingSelector = new SettingSelector(SettingSelector.Any, "production");

            Debug.WriteLine("Revisions of production settings: ");
            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(productionSettingSelector))
            {
                Debug.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }

            // Once we don't need the Configuration Settings, we can delete them.
            await client.DeleteAsync(productionEndpoint.Key, productionEndpoint.Label);
            await client.DeleteAsync(productionInstances.Key, productionInstances.Label);
        }
    }
}
