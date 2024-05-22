// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task GetSettingsUsingTags()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample12_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample12_CreateConfigurationSettingAsync
            var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta")
            {
                Tags = { { "someKey", "someValue" } }
            };
            var betaInstances = new ConfigurationSetting("instances", "1", "beta")
            {
                Tags = { { "someKey", "someValue" } }
            };
            var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production")
            {
                Tags = { { "someKey", "otherValue" } }
            };
            var productionInstances = new ConfigurationSetting("instances", "1", "production")
            {
                Tags = { { "someKey", "otherValue" } }
            };
            #endregion

            #region Snippet:AzConfigSample12_AddConfigurationSettingAsync
            await client.AddConfigurationSettingAsync(betaEndpoint);
            await client.AddConfigurationSettingAsync(betaInstances);
            await client.AddConfigurationSettingAsync(productionEndpoint);
            await client.AddConfigurationSettingAsync(productionInstances);
            #endregion

            #region Snippet:AzConfigSample12_GetConfigurationSettingsAsync
            var selector = new SettingSelector { TagsFilter = new string[] { "someKey=otherValue" } };

            Debug.WriteLine("Settings for production filtered by tag:");
            await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
            {
                Console.WriteLine(setting);
            }
            #endregion

            // Delete the Configuration Settings from the Configuration Store.
            #region Snippet:AzConfigSample12_DeleteConfigurationSettingAsync
            await client.DeleteConfigurationSettingAsync(betaEndpoint.Key, betaEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(betaInstances.Key, betaInstances.Label);
            await client.DeleteConfigurationSettingAsync(productionEndpoint.Key, productionEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
            #endregion
        }
    }
}
