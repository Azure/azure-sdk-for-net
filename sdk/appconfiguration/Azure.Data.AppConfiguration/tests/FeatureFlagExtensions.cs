// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.AppConfiguration.Tests
{
    public static class FeatureFlagExtensions
    {
        public static FeatureFlag Clone(this FeatureFlag featureFlag)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (string key in featureFlag.Tags.Keys)
            {
                tags.Add(key, featureFlag.Tags[key]);
            }

            var cloned = ConfigurationModelFactory.FeatureFlag(
                featureFlag.Name,
                alias: featureFlag.Alias,
                label: featureFlag.Label,
                description: featureFlag.Description,
                enabled: featureFlag.Enabled,
                conditions: featureFlag.Conditions,
                allocation: featureFlag.Allocation,
                telemetry: featureFlag.Telemetry,
                tags: tags,
                eTag: featureFlag.ETag,
                lastModified: featureFlag.LastModified,
                isReadOnly: featureFlag.IsReadOnly
            );

            // Copy variants
            if (featureFlag.Variants != null)
            {
                foreach (var variant in featureFlag.Variants)
                {
                    cloned.Variants.Add(variant);
                }
            }

            return cloned;
        }
    }
}
