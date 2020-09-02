// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        public void GetSettingIfChanged()
        {
            string connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample5_CreateConfigurationClient
            ConfigurationClient client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample5_SetConfigurationSetting
            ConfigurationSetting setting = client.SetConfigurationSetting("some_key", "initial_value");
            Console.WriteLine($"setting.ETag is '{setting.ETag}'");
            #endregion

            #region Snippet:AzConfigSample5_GetLatestConfigurationSetting
            ConfigurationSetting latestSetting = GetConfigurationSettingIfChanged(client, setting);
            Console.WriteLine($"Latest version of setting is {latestSetting}.");
            #endregion

            #region Snippet:AzConfigSample5_DeleteConfigurationSetting
            client.DeleteConfigurationSetting("some_key");
            #endregion
        }

        #region Snippet:AzConfigSample5_GetConfigurationSettingIfChanged
        public static ConfigurationSetting GetConfigurationSettingIfChanged(ConfigurationClient client, ConfigurationSetting setting)
        {
            Response<ConfigurationSetting> response = client.GetConfigurationSetting(setting, onlyIfChanged: true);
            int httpStatusCode = response.GetRawResponse().Status;
            Console.WriteLine($"Received a response code of {httpStatusCode}");

            return httpStatusCode switch
            {
                200 => response.Value,
                304 => setting,
                _ => throw new InvalidOperationException()
            };
        }
        #endregion
    }
}
