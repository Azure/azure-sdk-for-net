// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal struct SecureKeyUnwrapParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText s_encryptedKeyPropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText s_targetAttestationTokenPropertyNameBytes = JsonEncodedText.Encode("target");

        public string Algorithm { get; set; }

        public byte[] EncryptedKey { get; set; }

        public string TargetAttestationToken { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(s_algorithmPropertyNameBytes, Algorithm);
            }
            if (EncryptedKey != null)
            {
                json.WriteString(s_encryptedKeyPropertyNameBytes, Base64Url.Encode(EncryptedKey));
            }
            if (TargetAttestationToken != null)
            {
                json.WriteString(s_targetAttestationTokenPropertyNameBytes, TargetAttestationToken);
            }
        }
    }
}
