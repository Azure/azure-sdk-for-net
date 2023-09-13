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
        private List<(string Name, JsonElement Json)> _parsedProperties = new(1);

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
            // If the value wasn't valid, return it verbatim.
            if (!_isValidValue)
            {
                return _originalValue;
            }

            var uriWritten = false;

            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();

            for (var index = 0; index < _parsedProperties.Count; ++index)
            {
                var (name, jsonValue) = _parsedProperties[index];

                if (name == "uri")
                {
                    writer.WriteString("uri", _secretId.AbsoluteUri);
                    uriWritten = true;
                }
                else
                {
                    writer.WritePropertyName(name);
                    jsonValue.WriteTo(writer);
                }
            }

            if (!uriWritten)
            {
                writer.WriteString("uri", _secretId.AbsoluteUri);
            }

            writer.WriteEndObject();
            writer.Flush();

            _originalValue = Encoding.UTF8.GetString(memoryStream.ToArray());
            return _originalValue;
        }

        private bool TryParseValue()
        {
            _parsedProperties.Clear();

            try
            {
                var isUriValid = false;
                using var document = JsonDocument.Parse(_originalValue);

                foreach (var item in document.RootElement.EnumerateObject())
                {
                    switch (item.Name)
                    {
                        case "uri":
                            if (Uri.TryCreate(item.Value.GetString(), UriKind.Absolute, out Uri uriValue))
                            {
                                _secretId = uriValue;
                                _parsedProperties.Add((item.Name, default));

                                isUriValid = true;
                            }
                            break;

                        default:
                            _parsedProperties.Add((item.Name, item.Value.Clone()));
                            break;
                    }
                }

                return isUriValid;
            }
            catch (Exception)
            {
                return false;
            }
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
