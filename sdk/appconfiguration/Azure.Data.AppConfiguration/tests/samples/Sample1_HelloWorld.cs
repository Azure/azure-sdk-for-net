// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    [NonParallelizable]
    public partial class ConfigurationSamples
    {
        [Test]
        public void HelloWorld()
        {
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            #region Snippet:AzConfigSample1_CreateConfigurationClient
            var client = new ConfigurationClient(connectionString);
            #endregion

            #region Snippet:AzConfigSample1_CreateConfigurationSetting
            var setting = new ConfigurationSetting("some_key", "some_value");
            #endregion

            #region Snippet:AzConfigSample1_SetConfigurationSetting
            client.SetConfigurationSetting(setting);
            #endregion

            #region Snippet:AzConfigSample1_RetrieveConfigurationSetting
            ConfigurationSetting retrievedSetting = client.GetConfigurationSetting("some_key");
            Console.WriteLine($"The value of the configuration setting is: {retrievedSetting.Value}");
            #endregion

            #region Snippet:AzConfigSample1_DeleteConfigurationSetting
            client.DeleteConfigurationSetting("some_key");
            #endregion
        }
    }
}
