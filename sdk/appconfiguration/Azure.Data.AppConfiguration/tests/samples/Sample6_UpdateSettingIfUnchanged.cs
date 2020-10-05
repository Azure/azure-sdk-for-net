// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        public void UpdateSettingIfUnchanged()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample6_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample6_SetInitialVMs
            client.SetConfigurationSetting("available_vms", "10");
            #endregion

            #region Snippet:AzConfigSample6_CallReleaseVMs
            int releasedVMs = ReleaseVMs(vmsToRelease: 2);
            #endregion

            #region Snippet:AzConfigSample6_CallUpdateAvailableVms
            var availableVms = UpdateAvailableVms(client, releasedVMs);
            Console.WriteLine($"Available VMs after update: {availableVms}");
            #endregion

            #region Snippet:AzConfigSample6_DeleteConfigurationSetting
            client.DeleteConfigurationSetting("available_vms");
            #endregion
        }

        #region Snippet:AzConfigSample6_UpdateAvailableVms
        private static int UpdateAvailableVms(ConfigurationClient client, int releasedVMs)
        {
            while (true)
            {
                ConfigurationSetting setting = client.GetConfigurationSetting("available_vms");
                var availableVmsCount = int.Parse(setting.Value);
                setting.Value = (availableVmsCount + releasedVMs).ToString();

                try
                {
                    ConfigurationSetting updatedSetting = client.SetConfigurationSetting(setting, onlyIfUnchanged: true);
                    return int.Parse(updatedSetting.Value);
                }
                catch (RequestFailedException e) when (e.Status == 412)
                {
                }
            }
        }
        #endregion

        #region Snippet:AzConfigSample6_ReleaseVMs
        private int ReleaseVMs(int vmsToRelease)
        {
            // TODO
            return vmsToRelease;
        }
        #endregion
    }
}
