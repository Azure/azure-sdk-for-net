// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class SecretKey : KeyVaultKey
    {
        private const string IdPropertyName = "id";
        private const string ValuePropertyName = "value";
        private const string ContentTypePropertyName = "contentType";

        public SecretKey()
        {
            Key = new JsonWebKey(new[] { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.WrapKey, KeyOperation.UnwrapKey })
            {
                KeyType = Keys.KeyType.Oct,
            };
        }

        public string ContentType { get; private set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case IdPropertyName:
                    Key.Id = prop.Value.GetString();
                    Properties.Id = new Uri(Key.Id);
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
                    Key.K = keyBytes;
                    break;

                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }
}
