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
    public partial class Snippets : SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void CreateClient()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
#endif

            #region Snippet:CreateConfigurationClient
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
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
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
#endif

            #region Snippet:CreateConfigurationSetting
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            var settingToCreate = new ConfigurationSetting("some_key", "some_value");
            ConfigurationSetting setting = client.SetConfigurationSetting(settingToCreate);
            #endregion Snippet:CreateConfigurationSetting
        }

        [Test]
        public void GetSetting()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };

            // Make sure a setting exists.
            var setupClient = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
            setupClient.SetConfigurationSetting("some_key", "some_value");
#endif

            #region Snippet:GetConfigurationSetting
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            ConfigurationSetting setting = client.GetConfigurationSetting("some_key");
            #endregion Snippet:GetConfigurationSetting
        }

        [Test]
        public void UpdateSetting()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
#endif

            #region Snippet:UpdateConfigurationSetting
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            ConfigurationSetting setting = client.SetConfigurationSetting("some_key", "new_value");
            #endregion Snippet:UpdateConfigurationSetting
        }

        [Test]
        public void DeleteSetting()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
#endif

            #region Snippet:DeleteConfigurationSetting
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            client.DeleteConfigurationSetting("some_key");
            #endregion Snippet:DeleteConfigurationSetting
        }

        [Test]
        public void ThrowNotFoundError()
        {
            #region Snippet:ThrowNotFoundError
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#else
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#endif

            try
            {
                ConfigurationSetting setting = client.GetConfigurationSetting("nonexistent_key");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Key wasn't found.");
            }
            #endregion Snippet:ThrowNotFoundError
        }

        [Test]
        public void ThrowAuthenticationError()
        {
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

        [Test]
        public void SetFeatureFlag()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
#endif

            #region Snippet:SetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            FeatureFlag flag = client.SetFeatureFlag("some_feature", enabled: true);
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            #endregion Snippet:SetFeatureFlag
        }

        [Test]
        public void GetFeatureFlag()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };

            // Make sure a feature flag exists.
            var setupClient = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:GetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            FeatureFlag flag = client.GetFeatureFlag("some_feature");
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            #endregion Snippet:GetFeatureFlag
        }

        [Test]
        public void GetFeatureFlags()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };

            // Make sure a feature flag exists.
            var setupClient = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:GetFeatureFlags
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            var selector = new FeatureFlagSelector { NameFilter = "some_*" };
            foreach (FeatureFlag flag in client.GetFeatureFlags(selector))
            {
                Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            }
            #endregion Snippet:GetFeatureFlags
        }

        [Test]
        public void DeleteFeatureFlag()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };

            // Make sure a feature flag exists.
            var setupClient = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:DeleteFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            client.DeleteFeatureFlag("some_feature");
            #endregion Snippet:DeleteFeatureFlag
        }

        [Test]
        public void GetLabelsByResourceType()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
#endif

            #region Snippet:GetLabelsByResourceType
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
#endif
            // Only retrieve labels that are associated with feature flags.
            var selector = new SettingLabelSelector { ResourceType = SettingLabelResourceType.FeatureFlag };
            foreach (SettingLabel label in client.GetLabels(selector))
            {
                Console.WriteLine($"Label: {label.Name}");
            }
            #endregion Snippet:GetLabelsByResourceType
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            var endpoint = TestEnvironment.Endpoint;
            var options = new ConfigurationClientOptions { Audience = TestEnvironment.GetAudience() };
            ConfigurationClient client = new ConfigurationClient(new Uri(endpoint), TestEnvironment.Credential, options);
            await client.DeleteConfigurationSettingAsync("some_key");
            await client.DeleteFeatureFlagAsync("some_feature");
        }
    }
}
