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
        public void SetClearReadOnly()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:AzConfigSample3_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample3_SetConfigurationSetting
            var setting = new ConfigurationSetting("some_key", "some_value");
            client.SetConfigurationSetting(setting);
            #endregion

            #region Snippet:AzConfigSample3_SetReadOnly
            client.SetReadOnly(setting.Key, true);
            #endregion

            #region Snippet:AzConfigSample3_SetConfigurationSettingReadOnly
            setting.Value = "new_value";

            try
            {
                client.SetConfigurationSetting(setting);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            // Make the setting read write again.
            #region Snippet:AzConfigSample3_SetReadWrite
            client.SetReadOnly(setting.Key, false);
            #endregion

            #region Snippet:AzConfigSample3_SetConfigurationSettingReadWrite
            client.SetConfigurationSetting(setting);
            #endregion

            #region Snippet:AzConfigSample3_DeleteConfigurationSetting
            client.DeleteConfigurationSetting("some_key");
            #endregion
        }
    }
}
