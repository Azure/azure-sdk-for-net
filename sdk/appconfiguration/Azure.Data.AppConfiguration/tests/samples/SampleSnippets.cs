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
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;
#endif

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
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
#endif

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
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;
#endif

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
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;

            // Make sure a setting exists.
            var setupClient = new ConfigurationClient(connectionString);
            setupClient.SetConfigurationSetting("some_key", "some_value");
#endif

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
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;
#endif

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
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;
#endif

            #region Snippet:DeleteConfigurationSetting
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);
            client.DeleteConfigurationSetting("some_key");
            #endregion Snippet:DeleteConfigurationSetting
        }

        [Test]
        public void ThrowError()
        {
            #region Snippet:ThrowNotFoundError
#if !SNIPPET
            var connectionString = TestEnvironment.ConnectionString;
#endif
#if SNIPPET
            string connectionString = "<connection_string>";
#endif
            var client = new ConfigurationClient(connectionString);

            try
            {
                ConfigurationSetting setting = client.GetConfigurationSetting("nonexistent_key");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Key wasn't found.");
            }
            #endregion Snippet:ThrowNotFoundError

            #region Snippet:ThrowAuthenticationError
#if SNIPPET
            // Create a ConfigurationClient using the DefaultAzureCredential
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

            try
            {
                client.GetConfigurationSetting("key");
            }
            catch (AuthenticationFailedException e)
            {
                Console.WriteLine($"Authentication Failed. {e.Message}");
            }
#endif
            #endregion Snippet:ThrowAuthenticationError
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
