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
            var setting = new ConfigurationSetting("revised_setting", "v1");
            await client.SetAsync(setting);

            // Create a first revision.
            setting.Value = "v2";
            await client.SetAsync(setting);

            // Create a second revision.
            setting.Value = "v3";
            await client.SetAsync(setting);

            // Retrieve revisions for just the endpoint setting.
            var selector = new SettingSelector("revised_setting");

            Debug.WriteLine("Revisions of production endpoint setting: ");
            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
            {
                Debug.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }

            // Once we don't need the Configuration Settings, we can delete them.
            await client.DeleteAsync(setting.Key, setting.Label);
        }
    }
}
