// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// <see cref="Secret"/> is the resource consisting of a value and its <see cref="Properties"/>.
    /// </summary>
    public class Secret : IJsonDeserializable, IJsonSerializable
    {
        private const string ValuePropertyName = "value";

        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode(ValuePropertyName);

        internal Secret()
        {
            Properties = new SecretProperties();
        }

        /// <summary>
        /// Initializes a new instance of the Secret class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="value"/> is null.</exception>
        public Secret(string name, string value)
        {
            Properties = new SecretProperties(name);
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Secret identifier.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// Name of the secret.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// Gets or sets the attributes of the <see cref="Secret"/>.
        /// </summary>
        public SecretProperties Properties { get; }

        /// <summary>
        /// The value of the secret.
        /// </summary>
        public string Value { get; private set; }

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
