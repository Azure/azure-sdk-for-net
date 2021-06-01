// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples: SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void CreateFeatureFlag()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            #region Snippet:Sample_CreateFeatureFlag
            var featureFlagSetting = new FeatureFlagConfigurationSetting("feature_id", isEnabled: true);
            #endregion

            #region Snippet:Sample_SetFeatureFlag
            client.SetConfigurationSetting(featureFlagSetting);
            #endregion

            #region Snippet:Sample_GetFeatureFlag
            Response<ConfigurationSetting> response = client.GetConfigurationSetting(FeatureFlagConfigurationSetting.KeyPrefix + "feature_id");
            if (response.Value is FeatureFlagConfigurationSetting featureFlag)
            {
                Console.WriteLine($"Feature flag {featureFlag.FeatureId} IsEnabled: {featureFlag.IsEnabled}");
            }
            #endregion

            #region Snippet:Sample_DeleteFeatureFlag
            client.DeleteConfigurationSetting(featureFlagSetting);
            #endregion
        }
    }
}
