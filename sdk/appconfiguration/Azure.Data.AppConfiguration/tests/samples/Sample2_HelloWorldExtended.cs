// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task HelloWorldExtended()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample2_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample2_CreateConfigurationSettingAsync
            var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta");
            var betaInstances = new ConfigurationSetting("instances", "1", "beta");
            var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production");
            var productionInstances = new ConfigurationSetting("instances", "1", "production");
            #endregion

            #region Snippet:AzConfigSample2_AddConfigurationSettingAsync
            await client.AddConfigurationSettingAsync(betaEndpoint);
            await client.AddConfigurationSettingAsync(betaInstances);
            await client.AddConfigurationSettingAsync(productionEndpoint);
            await client.AddConfigurationSettingAsync(productionInstances);
            #endregion

            #region Snippet:AzConfigSample2_GetConfigurationSettingAsync
            ConfigurationSetting instancesToUpdate = await client.GetConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
            #endregion

            #region Snippet:AzConfigSample2_SetUpdatedConfigurationSettingAsync
            instancesToUpdate.Value = "5";
            await client.SetConfigurationSettingAsync(instancesToUpdate);
            #endregion

            #region Snippet:AzConfigSample2_GetConfigurationSettingsAsync
            var selector = new SettingSelector { LabelFilter = "production" };

            Console.WriteLine("Settings for Production environment:");
            await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
            {
                Console.WriteLine(setting);
            }
            #endregion

            #region Snippet:AzConfigSample2_GetLabelsAsync
            var labelsSelector = new SettingLabelSelector { NameFilter = "production*" };

            Console.WriteLine("Labels for Production environment:");
            await foreach (SettingLabel label in client.GetLabelsAsync(labelsSelector))
            {
                Console.WriteLine(label.Name);
            }
            #endregion

            // Delete the Configuration Settings from the Configuration Store.
            #region Snippet:AzConfigSample2_DeleteConfigurationSettingAsync
            await client.DeleteConfigurationSettingAsync(betaEndpoint.Key, betaEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(betaInstances.Key, betaInstances.Label);
            await client.DeleteConfigurationSettingAsync(productionEndpoint.Key, productionEndpoint.Label);
            await client.DeleteConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
            #endregion
        }
    }
}
