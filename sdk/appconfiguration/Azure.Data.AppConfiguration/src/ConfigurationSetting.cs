﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    [JsonConverter(typeof(ConfigurationSettingJsonConverter))]
    public class ConfigurationSetting
    {
        private IDictionary<string, string> _tags;
        private string _value;

        internal ConfigurationSetting()
        {
        }

        /// <summary>
        /// Creates a configuration setting and sets the values from the passed in parameter to this setting.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        public ConfigurationSetting(string key, string value, string label = null)
        {
            Key = key;
            Value = value;
            Label = label;
        }

        /// <summary>
        /// The primary identifier of the configuration setting.
        /// A <see cref="Key"/> is used together with a <see cref="Label"/> to uniquely identify a configuration setting.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A value used to group configuration settings.
        /// A <see cref="Label"/> is used together with a <see cref="Key"/> to uniquely identify a configuration setting.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The configuration setting's value.
        /// </summary>
        public string Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        internal virtual string GetValue()
        {
            return _value;
        }

        internal virtual void SetValue(string value)
        {
            _value = value;
        }

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
        public bool? IsReadOnly { get; internal set; }

        /// <summary>
        /// A dictionary of tags used to assign additional properties to a configuration setting.
        /// These can be used to indicate how a configuration setting may be applied.
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
        /// Get a hash code for the ConfigurationSetting.
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
