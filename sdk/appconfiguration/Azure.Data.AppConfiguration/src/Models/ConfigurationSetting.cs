// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Renamed properties.
    // - Apply custom serialization for ETag property.
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    [JsonConverter(typeof(ConfigurationSettingJsonConverter))]
    [CodeGenType("KeyValue")]
    [CodeGenSerialization(nameof(ETag), SerializationValueHook = nameof(SerializationEtag), DeserializationValueHook = nameof(DeserializeEtag))]
    public partial class ConfigurationSetting
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
        public ConfigurationSetting(string key, string value, string label = null): this(key, value, label, default)
        {
        }

        /// <summary>
        /// Creates a configuration setting and sets the values from the passed in parameter to this setting.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="etag">The ETag value for the configuration setting.</param>
        public ConfigurationSetting(string key, string value, string label, ETag etag)
        {
            Key = key;
            Value = value;
            Label = label;
            ETag = etag;
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

        internal static RequestContent ToRequestContent(ConfigurationSetting setting)
        {
            ReadOnlyMemory<byte> serializedSetting = ConfigurationServiceSerializer.SerializeRequestBody(setting);
            return RequestContent.Create(serializedSetting);
        }

        /// <summary>
        /// The content type of the configuration setting's value.
        /// Providing a proper content-type can enable transformations of values when they are retrieved by applications.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// An ETag indicating the state of a configuration setting within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given configuration setting.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// A value indicating whether the configuration setting is read only.
        /// A read only configuration setting may not be modified until it is made writable.
        /// </summary>
        [CodeGenMember("Locked")]
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

        private void SerializationEtag(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteString("etag", ETag.ToString());

        private static void DeserializeEtag(JsonProperty property, ref ETag val)
            => val = new ETag(property.Value.GetString());
    }
}
