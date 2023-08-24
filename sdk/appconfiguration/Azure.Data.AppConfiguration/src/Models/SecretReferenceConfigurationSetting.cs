// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Represents a configuration setting that references as KeyVault secret.
    /// </summary>
    public class SecretReferenceConfigurationSetting : ConfigurationSetting
    {
        internal const string SecretReferenceContentType = "application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8";

        private string _originalValue;
        private bool _isValidValue;
        private Uri _secretId;

        internal SecretReferenceConfigurationSetting(string jsonValue)
        {
            _originalValue = jsonValue;
            _isValidValue = TryParseValue();
        }

        internal SecretReferenceConfigurationSetting()
        {
        }

        /// <summary>
        /// Creates a <see cref="SecretReferenceConfigurationSetting"/> referencing the provided KeyVault secret.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="secretId">The secret identifier to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        public SecretReferenceConfigurationSetting(string key, Uri secretId, string label = null) : this(key, secretId, label, default)
        {
        }

        /// <summary>
        /// Creates a <see cref="SecretReferenceConfigurationSetting"/> referencing the provided KeyVault secret.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="secretId">The secret identifier to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="etag">The ETag value for the configuration setting.</param>
        public SecretReferenceConfigurationSetting(string key, Uri secretId, string label, ETag etag)
        {
            _isValidValue = true;
            _secretId = secretId;

            Key = key;
            Label = label;
            ETag = etag;
            ContentType = SecretReferenceContentType;
        }

        /// <summary>
        /// The secret identifier.
        /// </summary>
        public Uri SecretId
        {
            get
            {
                CheckValid();
                return _secretId;
            }
            set
            {
               _secretId = value;
            }
        }

        internal override void SetValue(string value)
        {
            _originalValue = value;
            _isValidValue = TryParseValue();
        }

        internal override string GetValue()
        {
            // If the setting was created using the composite constructor, it
            // will not have an original value and it will need to be formatted for
            // the first time.
            if (_originalValue == null && _isValidValue)
            {
                _originalValue = CreateInitialValue();
                return _originalValue;
            }

            // If the value wasn't valid, return it verbatim.
            if (!_isValidValue)
            {
                return _originalValue;
            }

            // Form the value by coping the source JSON and replacing the setting property
            // values.  This will ensure that any custom attributes are preserved.
            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(_originalValue));

            WriteSettingValue(reader, writer);
            writer.Flush();

            _originalValue = Encoding.UTF8.GetString(memoryStream.ToArray());
            return _originalValue;
        }

        private string CreateInitialValue()
        {
            using var memoryStream = new MemoryStream();
            var writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();

            TryWriteKnownProperty("uri", writer);

            writer.WriteEndObject();
            writer.Flush();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        private void WriteSettingValue(Utf8JsonReader settingValueReader, Utf8JsonWriter writer)
        {
            var writtenKnownProperties = new HashSet<string>();
            writer.WriteStartObject();

            while (settingValueReader.Read())
            {
                switch (settingValueReader.TokenType)
                {
                    case JsonTokenType.StartObject when settingValueReader.CurrentDepth > 0:
                        writer.WriteStartObject();
                        break;
                    case JsonTokenType.EndObject when settingValueReader.CurrentDepth > 0:
                        writer.WriteEndObject();
                        break;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        break;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        break;
                    case JsonTokenType.PropertyName:
                        string propertyName = settingValueReader.GetString();

                        // All the well-known property values are on the top-level of the object.  Anything
                        // lower with the same parameter names belong to custom attributes and should be ignored.
                        if ((settingValueReader.CurrentDepth <= 1) && (TryWriteKnownProperty(propertyName, writer, true)))
                        {
                            writtenKnownProperties.Add(propertyName);
                            settingValueReader.Read();
                            settingValueReader.Skip();
                        }
                        else
                        {
                            writer.WritePropertyName(propertyName);
                        }
                        break;
                    case JsonTokenType.String:
                        writer.WriteStringValue(settingValueReader.GetString());
                        break;
                    case JsonTokenType.Number:
                        writer.WriteNumberValue(settingValueReader.GetDecimal());
                        break;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(settingValueReader.GetBoolean());
                        break;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        break;
                }
            }

            // Write any well-known properties that were not already written.
            if (!writtenKnownProperties.Contains("uri"))
            {
                TryWriteKnownProperty("uri", writer);
            }

            writer.WriteEndObject();
        }

        private bool TryWriteKnownProperty(string propertyName, Utf8JsonWriter writer, bool includeOptionalWhenNull = false)
        {
            switch (propertyName)
            {
                case "uri":
                    writer.WriteString(propertyName, _secretId.AbsoluteUri);
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool TryParseValue()
        {
            try
            {
                using var document = JsonDocument.Parse(_originalValue);
                var root = document.RootElement;

                if (!root.TryGetProperty("uri", out var uriProperty))
                {
                    return false;
                }

                if (!Uri.TryCreate(uriProperty.GetString(), UriKind.Absolute, out Uri uriValue))
                {
                    return false;
                }

                _secretId = uriValue;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void CheckValid()
        {
            if (!_isValidValue)
            {
                throw new InvalidOperationException($"The content of the {nameof(Value)} property do not represent a valid secret reference object.");
            }
        }
    }
}
