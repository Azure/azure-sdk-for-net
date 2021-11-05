// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets: SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void CreateClient()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:CreateConfigurationClient
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            #endregion Snippet:CreateConfigurationClient
        }

        [Test]
        public void CreateClientTokenCredential()
        {
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:CreateConfigurationClientTokenCredential
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void CreateSetting()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:CreateConfigurationSetting
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            var settingToCreate = new ConfigurationSetting("some_key", "some_value");
            ConfigurationSetting setting = client.SetConfigurationSetting(settingToCreate);
            #endregion Snippet:CreateConfigurationSetting
        }

        [Test]
        public void GetSetting()
        {
            var connectionString = TestEnvironment.ConnectionString;

            // Make sure a setting exists.
            var setupClient = new ConfigurationClient(connectionString);
            setupClient.SetConfigurationSetting("some_key", "some_value");

            #region Snippet:GetConfigurationSetting
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            ConfigurationSetting setting = client.GetConfigurationSetting("some_key");
            #endregion Snippet:GetConfigurationSetting
        }

        [Test]
        public void UpdateSetting()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:UpdateConfigurationSetting
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            ConfigurationSetting setting = client.SetConfigurationSetting("some_key", "new_value");
            #endregion Snippet:UpdateConfigurationSetting
        }

        [Test]
        public void DeleteSetting()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:DeleteConfigurationSetting
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            client.DeleteConfigurationSetting("some_key");
            #endregion Snippet:DeleteConfigurationSetting
        }

        [Test]
        public void ThrowNotFoundError()
        {
            var connectionString = TestEnvironment.ConnectionString;

            try
            {
                #region Snippet:ThrowNotFoundError
#if SNIPPET
                string connectionString = "<connection_string>";
#endif
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
            var connectionString = TestEnvironment.ConnectionString;
            ConfigurationClient client = new ConfigurationClient(connectionString);
            await client.DeleteConfigurationSettingAsync("some_key");
        }
    }
}
