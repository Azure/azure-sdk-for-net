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
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
#endif

            #region Snippet:SetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            FeatureFlag flag = client.SetFeatureFlag("some_feature", enabled: true);
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            #endregion Snippet:SetFeatureFlag
        }

        [Test]
        public void GetFeatureFlag()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;

            // Make sure a feature flag exists.
            var setupClient = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:GetFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            FeatureFlag flag = client.GetFeatureFlag("some_feature");
            Console.WriteLine($"Feature flag '{flag.Name}' is enabled: {flag.Enabled}");
            #endregion Snippet:GetFeatureFlag
        }

        [Test]
        public void GetFeatureFlags()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;

            // Make sure a feature flag exists.
            var setupClient = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:GetFeatureFlags
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
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

            // Make sure a feature flag exists.
            var setupClient = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            setupClient.SetFeatureFlag("some_feature", enabled: true);
#endif

            #region Snippet:DeleteFeatureFlag
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            client.DeleteFeatureFlag("some_feature");
            #endregion Snippet:DeleteFeatureFlag
        }

        [Test]
        public void GetLabelsByResourceType()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;

            // Make sure a feature flag with a label exists.
            var setupClient = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            setupClient.SetFeatureFlag("some_feature", enabled: true, label: "some_label");
#endif

            #region Snippet:GetLabelsByResourceType
#if SNIPPET
            string endpoint = "<endpoint>";
#endif
            var client = new FeatureFlagClient(new Uri(endpoint), new DefaultAzureCredential());
            // The FeatureFlagClient only retrieves labels that are associated with feature flags.
            var selector = new FeatureFlagLabelSelector();
            foreach (SettingLabel label in client.GetLabels(selector))
            {
                Console.WriteLine($"Label: {label.Name}");
            }
            #endregion Snippet:GetLabelsByResourceType
        }
    }
}
