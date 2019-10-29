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
         * This sample demonstrates how to read the revision history of a
         * Configuration Settings in a Configuration Store. To do this, we
         * create a setting, change it twice to create revisions, then read the
         * revision history for that setting.
         */
        public async Task ReadRevisionHistory()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create the Configuration Settings to be stored in the Configuration Store.
            ConfigurationSetting setting = new ConfigurationSetting($"setting_with_revisions-{DateTime.Now.ToString("s")}", "v1");
            ConfigurationSetting settingV1 = await client.SetConfigurationSettingAsync(setting);

            // Create a first revision.
            settingV1.Value = "v2";
            ConfigurationSetting settingV2 = await client.SetConfigurationSettingAsync(settingV1);

            // Create a second revision.
            settingV2.Value = "v3";
            ConfigurationSetting settingV3 = await client.SetConfigurationSettingAsync(settingV2);

            // Retrieve revisions for the setting.
            var selector = new SettingSelector(setting.Key);

            Debug.WriteLine("Revisions of the setting: ");
            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
            {
                Debug.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }

            // Delete the Configuration Settings from the Configuration Store.
            await client.DeleteConfigurationSettingAsync(setting.Key, setting.Label);
        }
    }
}
