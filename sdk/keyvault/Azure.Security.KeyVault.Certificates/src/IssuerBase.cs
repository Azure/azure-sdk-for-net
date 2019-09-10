// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Contains public properties of a certificate issuer
    /// </summary>
    public class IssuerBase : IJsonDeserializable, IJsonSerializable
    {
        internal IssuerBase() { }

        /// <summary>
        /// Creates a new Issuer with the specified name
        /// </summary>
        /// <param name="name">The name of the issuer</param>
        protected IssuerBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The unique identifier of the certificate issuer
        /// </summary>
        public Uri Id { get; private set; }

        /// <summary>
        /// The name of the certificate issuer
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The provider name of the certificate issuer
        /// </summary>
        public string Provider { get; set; }

        private const string IdPropertyName = "id";
        private const string ProviderPropertyName = "provider";

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case IdPropertyName:
                    var id = prop.Value.GetString();
                    Id = new Uri(id);
                    break;
                case ProviderPropertyName:
                    Provider = prop.Value.GetString();
                    break;
            }
        }

        private static readonly JsonEncodedText ProviderPropertyNameBytes = JsonEncodedText.Encode(ProviderPropertyName);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            WritePropertiesCore(json);
        }

        internal virtual void WritePropertiesCore(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(Provider))
            {
                json.WriteString(ProviderPropertyNameBytes, Provider);
            }
        }
    }
}
