// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Core.Http;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    public sealed class ConfigurationSetting : IEquatable<ConfigurationSetting>
    {
        private IDictionary<string, string> _tags;

        // TODO (pri 3): this is just for deserialization. We can remove after we move to JsonDocument
        internal ConfigurationSetting() { }

        /// <summary>
        /// Creates a configuration setting and sets the values from the passed in parameter to this setting.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        public ConfigurationSetting(string key, string value, string label = null)
        {
            Key = key;
            Value = value;
            Label = label;
        }

        /// <summary>
        /// The primary identifier of a configuration setting.
        /// The key is used in unison with the label to uniquely identify a configuration setting.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A value used to group configuration settings.
        /// The label is used in unison with the key to uniquely identify a configuration setting.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value of the configuration setting.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The content type of the configuration setting's value.
        /// Providing a proper content-type can enable transformations of values when they are retrieved by applications.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// An ETag indicating the state of a configuration setting within a configuration store.
        /// </summary>
        public ETag ETag { get; set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given configuration setting.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// A value indicating whether the configuration setting is locked.
        /// A locked configuration setting may not be modified until it is unlocked.
        /// </summary>
        public bool? Locked { get; internal set; }

        /// <summary>
        /// A dictionary of tags that can help identify what a configuration setting may be applicable for.
        /// </summary>
        public IDictionary<string, string> Tags
        {
            get => _tags ?? (_tags = new Dictionary<string, string>());
            internal set => _tags = value;
        }

        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        public bool Equals(ConfigurationSetting other)
        {
            if (other == null)
                return false;
            if (ETag != default && other.ETag != default)
            {
                if (ETag != other.ETag)
                    return false;
                if (LastModified != other.LastModified)
                    return false;
                if (Locked != other.Locked)
                    return false;
            }
            if (!string.Equals(Key, other.Key, StringComparison.Ordinal))
                return false;
            if (!string.Equals(Value, other.Value, StringComparison.Ordinal))
                return false;
            if (!string.Equals(Label, other.Label, StringComparison.Ordinal))
                return false;
            if (!string.Equals(ContentType, other.ContentType, StringComparison.Ordinal))
                return false;
            if (!TagsEquals(other.Tags))
                return false;

            return true;
        }

        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is ConfigurationSetting other)
            {
                return Equals(other);
            }
            else
                return false;
        }

        private bool TagsEquals(IDictionary<string, string> other)
        {
            if (other == null)
                return false;
            if (Tags.Count != other.Count)
                return false;
            foreach (KeyValuePair<string, string> pair in Tags)
            {
                if (!other.TryGetValue(pair.Key, out string value))
                    return false;
                if (!string.Equals(value, pair.Value, StringComparison.Ordinal))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Get a hash code for the ConfigurationSetting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(Key, StringComparer.Ordinal);
            hashCode.Add(Label, StringComparer.Ordinal);
            hashCode.Add(Value, StringComparer.Ordinal);
            hashCode.Add(ContentType, StringComparer.Ordinal);
            hashCode.Add(LastModified);
            hashCode.Add(ETag);
            hashCode.Add(Locked);
            hashCode.Add(Tags);
            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Creates a (Key,Value) string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
            => $"({Key},{Value})";
    }
}
