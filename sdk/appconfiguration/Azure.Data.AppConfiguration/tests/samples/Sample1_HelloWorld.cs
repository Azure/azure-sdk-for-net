// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples : SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:AzConfigSample1_CreateConfigurationClient
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
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
