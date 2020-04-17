// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class Snippets
    {
        [Test]
        public void CreateClient()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            #region Snippet:CreateConfigurationClient
            //@@ string connectionString = "<connection_string>";
            var client = new ConfigurationClient(connectionString);
            #endregion Snippet:CreateConfigurationClient
        }

        [Test]
        public void CreateClientTokenCredential()
        {
            var endpoint = AppConfigurationTestEnvironment.Instance.Endpoint;

            #region Snippet:CreateConfigurationClientTokenCredential
            //@@ string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void CreateSetting()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            #region Snippet:CreateConfigurationSetting
            //@@ string connectionString = "<connection_string>";
            var client = new ConfigurationClient(connectionString);
            var settingToCreate = new ConfigurationSetting("some_key", "some_value");
            ConfigurationSetting setting = client.SetConfigurationSetting(settingToCreate);
            #endregion Snippet:CreateConfigurationSetting
        }

        [Test]
        public void GetSetting()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            // Make sure a setting exists.
            var setupClient = new ConfigurationClient(connectionString);
            setupClient.SetConfigurationSetting("some_key", "some_value");


            #region Snippet:GetConfigurationSetting
            //@@ string connectionString = "<connection_string>";
            var client = new ConfigurationClient(connectionString);
            ConfigurationSetting setting = client.GetConfigurationSetting("some_key");
            #endregion Snippet:GetConfigurationSetting
        }

        [Test]
        public void UpdateSetting()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            #region Snippet:UpdateConfigurationSetting
            //@@ string connectionString = "<connection_string>";
            var client = new ConfigurationClient(connectionString);
            ConfigurationSetting setting = client.SetConfigurationSetting("some_key", "new_value");
            #endregion Snippet:UpdateConfigurationSetting
        }

        [Test]
        public void DeleteSetting()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            #region Snippet:DeleteConfigurationSetting
            //@@ string connectionString = "<connection_string>";
            var client = new ConfigurationClient(connectionString);
            client.DeleteConfigurationSetting("some_key");
            #endregion Snippet:DeleteConfigurationSetting
        }

        [Test]
        public void ThrowNotFoundError()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;

            try
            {
                #region Snippet:ThrowNotFoundError
                //@@ string connectionString = "<connection_string>";
                var client = new ConfigurationClient(connectionString);
                ConfigurationSetting setting = client.GetConfigurationSetting("nonexistent_key");
                #endregion Snippet:ThrowNotFoundError
            }
            catch (RequestFailedException)
            {
            }
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            var connectionString = AppConfigurationTestEnvironment.Instance.ConnectionString;
            ConfigurationClient client = new ConfigurationClient(connectionString);
            await client.DeleteConfigurationSettingAsync("some_key");
        }
    }
}
