// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.AppConfiguration.Tests {
    internal class ConfigurationSettingEqualityComparer : IEqualityComparer<ConfigurationSetting>
    {
        public static IEqualityComparer<ConfigurationSetting> Instance { get; } = new ConfigurationSettingEqualityComparer();

        private ConfigurationSettingEqualityComparer() { }

        public bool Equals(ConfigurationSetting x, ConfigurationSetting y)
        {
            if (x == null || y == null)
                return ReferenceEquals(x, y);
            if (x.ETag != default && y.ETag != default)
            {
                if (x.ETag != y.ETag)
                    return false;
                if (x.LastModified != y.LastModified)
                    return false;
                if (x.IsReadOnly != y.IsReadOnly)
                    return false;
            }
            if (!string.Equals(x.Key, y.Key, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.Value, y.Value, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.Label, y.Label, StringComparison.Ordinal))
                return false;
            if (!string.Equals(x.ContentType, y.ContentType, StringComparison.Ordinal))
                return false;
            if (!TagsEquals(x, y))
                return false;

            return true;
        }

        public int GetHashCode(ConfigurationSetting setting)
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(setting.Key, StringComparer.Ordinal);
            hashCode.Add(setting.Label, StringComparer.Ordinal);
            hashCode.Add(setting.Value, StringComparer.Ordinal);
            hashCode.Add(setting.ContentType, StringComparer.Ordinal);
            hashCode.Add(setting.LastModified);
            hashCode.Add(setting.ETag);
            hashCode.Add(setting.IsReadOnly);
            hashCode.Add(setting.Tags);
            return hashCode.ToHashCode();
        }

        private bool TagsEquals(ConfigurationSetting x, ConfigurationSetting y)
        {
            if (x.Tags == null)
                return y.Tags == null;
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
    }
}
