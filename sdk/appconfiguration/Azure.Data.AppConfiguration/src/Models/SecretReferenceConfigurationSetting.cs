// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private string _originalValue;
        private bool _isValidValue;
        private Uri _secretId;
        internal const string SecretReferenceContentType = "application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8";

        internal SecretReferenceConfigurationSetting()
        {
        }

        /// <summary>
        /// Creates a <see cref="SecretReferenceConfigurationSetting"/> referencing the provided KeyVault secret.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="secretId">The secret identifier to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        public SecretReferenceConfigurationSetting(string key, Uri secretId, string label = null)
        {
            Key = key;
            Label = label;
            _isValidValue = true;
            ContentType = SecretReferenceContentType;
            _secretId = secretId;
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
                CheckValidWrite();
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
            return _isValidValue ? FormatValue() : _originalValue;
        }

        private string FormatValue()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();
            writer.WriteString("uri", _secretId.AbsoluteUri);
            writer.WriteEndObject();
            writer.Flush();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
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

        private void CheckValidWrite()
        {
            CheckValid();
            _originalValue = null;
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
