// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.Data.AppConfiguration.Tests {
    internal class FeatureFlagEqualityComparer : IEqualityComparer<FeatureFlag>
    {
        public static IEqualityComparer<FeatureFlag> Instance { get; } = new FeatureFlagEqualityComparer();

        private FeatureFlagEqualityComparer() { }

        public bool Equals(FeatureFlag x, FeatureFlag y)
        {
            if (x == null || y == null)
                return ReferenceEquals(x, y);

            // Compare ETag, LastModified, and IsReadOnly if both are set
            if (x.ETag != default && y.ETag != default)
            {
                if (x.ETag != y.ETag)
                    return false;
                if (x.LastModified != y.LastModified)
                    return false;
                if (x.IsReadOnly != y.IsReadOnly)
                    return false;
            }

            // Compare all FeatureFlag-specific properties
            if (!string.Equals(x.Name, y.Name, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.Alias, y.Alias, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.Label, y.Label, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.Description, y.Description, StringComparison.Ordinal))
                return false;
            if (x.Enabled != y.Enabled)
                return false;
            if (!ConditionsEquals(x.Conditions, y.Conditions))
                return false;
            if (!VariantsEquals(x.Variants, y.Variants))
                return false;
            if (!AllocationEquals(x.Allocation, y.Allocation))
                return false;
            if (!TelemetryEquals(x.Telemetry, y.Telemetry))
                return false;
            if (!TagsEquals(x, y))
                return false;

            return true;
        }

        public int GetHashCode(FeatureFlag setting)
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(setting.Name, StringComparer.Ordinal);
            hashCode.Add(setting.Alias, StringComparer.Ordinal);
            hashCode.Add(setting.Label, StringComparer.Ordinal);
            hashCode.Add(setting.Description, StringComparer.Ordinal);
            hashCode.Add(setting.Enabled);
            hashCode.Add(setting.LastModified);
            hashCode.Add(setting.ETag);
            hashCode.Add(setting.IsReadOnly);
            hashCode.Add(setting.Tags);
            hashCode.Add(setting.Conditions);
            hashCode.Add(setting.Variants);
            hashCode.Add(setting.Allocation);
            hashCode.Add(setting.Telemetry);
            return hashCode.ToHashCode();
        }

        private bool TagsEquals(FeatureFlag x, FeatureFlag y)
        {
            if (x.Tags == null)
                return y.Tags == null;
            if (y.Tags == null)
                return false;
            if (x.Tags.Count != y.Tags.Count)
                return false;
            foreach (var kvp in x.Tags)
            {
                if (!y.Tags.TryGetValue(kvp.Key, out string yValue))
                    return false;
                if (!string.Equals(yValue, kvp.Value, StringComparison.Ordinal))
                    return false;
            }
            return true;
        }

        private bool ConditionsEquals(FeatureFlagConditions x, FeatureFlagConditions y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            // Use serialization to compare complex objects
            return SerializeAndCompare(x, y);
        }

        private bool VariantsEquals(IList<FeatureFlagVariantDefinition> x, IList<FeatureFlagVariantDefinition> y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Count != y.Count)
                return false;

            // Use serialization to compare variants collections
            return SerializeAndCompare(x, y);
        }

        private bool AllocationEquals(FeatureFlagAllocation x, FeatureFlagAllocation y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            // Use serialization to compare complex objects
            return SerializeAndCompare(x, y);
        }

        private bool TelemetryEquals(FeatureFlagTelemetryConfiguration x, FeatureFlagTelemetryConfiguration y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            // Use serialization to compare complex objects
            return SerializeAndCompare(x, y);
        }

        private bool SerializeAndCompare<T>(T x, T y) where T : IPersistableModel<T>
        {
            try
            {
                var options = ModelReaderWriterOptions.Json;
                var serializedX = x.Write(options).ToString();
                var serializedY = y.Write(options).ToString();
                return string.Equals(serializedX, serializedY, StringComparison.Ordinal);
            }
            catch
            {
                // Fallback to reference equality if serialization fails
                return ReferenceEquals(x, y);
            }
        }

        private bool SerializeAndCompare<T>(IList<T> x, IList<T> y) where T : IPersistableModel<T>
        {
            try
            {
                var options = ModelReaderWriterOptions.Json;
                var serializedX = System.Text.Json.JsonSerializer.Serialize(x.Select(item => item.Write(options).ToString()));
                var serializedY = System.Text.Json.JsonSerializer.Serialize(y.Select(item => item.Write(options).ToString()));
                return string.Equals(serializedX, serializedY, StringComparison.Ordinal);
            }
            catch
            {
                // Fallback to element-by-element comparison
                for (int i = 0; i < x.Count; i++)
                {
                    if (!SerializeAndCompare(x[i], y[i]))
                        return false;
                }
                return true;
            }
        }
    }
}
