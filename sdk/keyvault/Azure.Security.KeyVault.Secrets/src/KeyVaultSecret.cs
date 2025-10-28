// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// <see cref="KeyVaultSecret"/> is the resource consisting of a value and its <see cref="Properties"/>.
    /// </summary>
    public class KeyVaultSecret : IJsonDeserializable, IJsonSerializable
    {
        private const string ValuePropertyName = "value";

        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode(ValuePropertyName);

        internal KeyVaultSecret(SecretProperties properties = null)
        {
            Properties = properties ?? new SecretProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecret"/> class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="value"/> is null.</exception>
        public KeyVaultSecret(string name, string value)
        {
            Properties = new SecretProperties(name);
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the secret identifier.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// Gets the the name of the secret.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// Gets a test property with improper spelling.
        /// </summary>
        public string ImpropppppperlySepledProperyyyy => "This is a test property with improper spelling";

        /// <summary>
        /// Gets additional properties of the <see cref="KeyVaultSecret"/>.
        /// </summary>
        public SecretProperties Properties { get; }

        /// <summary>
        /// Gets the value of the secret.
        /// </summary>
        /// <value>This property is always null for <see cref="DeletedSecret"/>.</value>
        public string Value { get; internal set; }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case ValuePropertyName:
                    Value = prop.Value.GetString();
                    break;

                default:
                    Properties.ReadProperty(prop);
                    break;
            }
        }

        internal virtual void WriteProperties(Utf8JsonWriter json)
        {
            if (Value != null)
            {
                json.WriteString(s_valuePropertyNameBytes, Value);
            }

            Properties.WriteProperties(json);
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
