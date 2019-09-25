// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Contains public properties of a certificate issuer
    /// </summary>
    public class IssuerProperties : IJsonDeserializable, IJsonSerializable
    {
        private const string IdPropertyName = "id";
        private const string ProviderPropertyName = "provider";

        private static readonly JsonEncodedText s_providerPropertyNameBytes = JsonEncodedText.Encode(ProviderPropertyName);

        internal IssuerProperties()
        {
        }

        /// <summary>
        /// Creates a new Issuer with the specified name
        /// </summary>
        /// <param name="name">The name of the issuer</param>
        internal IssuerProperties(string name)
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

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal void ReadProperty(JsonProperty prop)
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

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(Provider))
            {
                json.WriteString(s_providerPropertyNameBytes, Provider);
            }
        }
    }
}
