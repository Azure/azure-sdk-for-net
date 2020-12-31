// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task ReadRevisionHistory()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample4_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample4_SetConfigurationSetting
            ConfigurationSetting setting = new ConfigurationSetting($"setting_with_revisions-{DateTime.Now:s}", "v1");
            await client.SetConfigurationSettingAsync(setting);
            #endregion

            #region Snippet:AzConfigSample4_AddRevisions
            setting.Value = "v2";
            await client.SetConfigurationSettingAsync(setting);

            setting.Value = "v3";
            await client.SetConfigurationSettingAsync(setting);
            #endregion

            #region Snippet:AzConfigSample4_GetRevisions
            var selector = new SettingSelector { KeyFilter = setting.Key };

            Debug.WriteLine("Revisions of the setting: ");
            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
            {
                Console.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }
            #endregion

            #region Snippet:AzConfigSample4_GetRevisionsAfterDeletion
            await client.DeleteConfigurationSettingAsync(setting.Key, setting.Label);

            await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
            {
                Console.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
            }
            #endregion
        }
    }
}
