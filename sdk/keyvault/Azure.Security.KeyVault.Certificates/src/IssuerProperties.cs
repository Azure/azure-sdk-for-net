// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Properties of a <see cref="CertificateIssuer"/>.
    /// </summary>
    public class IssuerProperties : IJsonDeserializable, IJsonSerializable
    {
        private const string IdPropertyName = "id";
        private const string ProviderPropertyName = "provider";

        private static readonly JsonEncodedText s_providerPropertyNameBytes = JsonEncodedText.Encode(ProviderPropertyName);

        internal IssuerProperties()
        {
        }

        internal IssuerProperties(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the identifier of the certificate issuer.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Gets the name of the certificate issuer.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or sets the provider name of the certificate issuer.
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
                    Name = Id.Segments[Id.Segments.Length - 1];
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
