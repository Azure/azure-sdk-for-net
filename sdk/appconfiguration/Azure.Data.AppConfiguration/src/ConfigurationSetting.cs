// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    public sealed class ConfigurationSetting
    {
        private IDictionary<string, string> _tags;

        internal ConfigurationSetting()
        {
        }

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
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given configuration setting.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// A value indicating whether the configuration setting is read only.
        /// A read only configuration setting may not be modified until it is made writable.
        /// </summary>
        public bool? ReadOnly { get; internal set; }

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
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a (Key,Value) string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
            => $"({Key},{Value})";
    }
}
