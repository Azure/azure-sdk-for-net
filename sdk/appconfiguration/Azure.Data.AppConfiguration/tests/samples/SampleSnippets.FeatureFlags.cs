// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    /// <summary>
    /// Feature flag snippets that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets : SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void SetFeatureFlag()
        {
            #region Snippet:SetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            FeatureFlag flag = client.SetFeatureFlag("some_feature", enabled: true);
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
#endif
            #endregion
        }

        [Test]
        public void GetFeatureFlag()
        {
            #region Snippet:GetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            FeatureFlag flag = client.GetFeatureFlag("some_feature");
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
#endif
            #endregion
        }

        [Test]
        public void GetFeatureFlags()
        {
            #region Snippet:GetFeatureFlags
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            var selector = new FeatureFlagSelector { NameFilter = "some_*" };
            foreach (FeatureFlag flag in client.GetFeatureFlags(selector))
            {
                Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            }
#endif
            #endregion
        }

        [Test]
        public void DeleteFeatureFlag()
        {
            #region Snippet:DeleteFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            client.DeleteFeatureFlag("some_feature");
#endif
            #endregion
        }

        [Test]
        public void GetLabelsByResourceType()
        {
            #region Snippet:GetLabelsByResourceType
#if SNIPPET
            string endpoint = "<endpoint>";
            var client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
            // Only retrieve labels that are associated with feature flags.
            var selector = new SettingLabelSelector { ResourceType = SettingLabelResourceType.FeatureFlag };
            foreach (SettingLabel label in client.GetLabels(selector))
            {
                Console.WriteLine($"Label: {label.Name}");
            }
#endif
            #endregion
        }
    }
}
