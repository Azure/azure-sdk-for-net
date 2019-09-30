// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class SecretKey : Key
    {
        private const string IdPropertyName = "id";
        private const string ValuePropertyName = "value";
        private const string ContentTypePropertyName = "contentType";

        public SecretKey()
        {
            KeyMaterial = new JsonWebKey();
            KeyMaterial.KeyType = KeyType.Oct;
            KeyMaterial.KeyOps = new[] { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.WrapKey, KeyOperation.UnwrapKey };
        }

        public string ContentType { get; private set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case IdPropertyName:
                    KeyMaterial.KeyId = prop.Value.GetString();
                    Properties.Id = new Uri(KeyMaterial.KeyId);
                    KeyVaultIdentifier kvid = KeyVaultIdentifier.Parse(Properties.Id);
                    Properties.Name = kvid.Name;
                    Properties.VaultUri = kvid.VaultUri;
                    Properties.Version = kvid.Version;
                    break;

                case ContentTypePropertyName:
                    ContentType = prop.Value.GetString();
                    break;

                case ValuePropertyName:
                    byte[] keyBytes = Base64Url.Decode(prop.Value.GetString());
                    KeyMaterial.K = keyBytes;
                    break;

                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }
}
