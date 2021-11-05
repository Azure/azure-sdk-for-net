// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class KeyVaultSecret : IJsonDeserializable
    {
        private const string ContentTypePropertyName = "contentType";
        private const string ValuePropertyName = "value";

        internal KeyVaultSecret()
        {
        }

        public CertificateContentType? ContentType { get; internal set; }

        public string Value { get; internal set; }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case ContentTypePropertyName:
                    ContentType = prop.Value.GetString();
                    break;

                case ValuePropertyName:
                    Value = prop.Value.GetString();
                    break;
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }
    }
}
