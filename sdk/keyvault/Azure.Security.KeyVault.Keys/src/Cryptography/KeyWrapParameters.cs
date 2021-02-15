// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal struct KeyWrapParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText s_keyPropertyNameBytes = JsonEncodedText.Encode("value");

        public string Algorithm { get; set; }

        public byte[] Key { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(s_algorithmPropertyNameBytes, Algorithm);
            }
            if (Key != null)
            {
                json.WriteString(s_keyPropertyNameBytes, Base64Url.Encode(Key));
            }
        }
    }
}
