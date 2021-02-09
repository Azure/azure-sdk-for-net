// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyVerifyParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText s_digestPropertyNameBytes = JsonEncodedText.Encode("digest");
        private static readonly JsonEncodedText s_signaturePropertyNameBytes = JsonEncodedText.Encode("value");

        public string Algorithm { get; set; }

        public byte[] Digest { get; set; }

        public byte[] Signature { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(s_algorithmPropertyNameBytes, Algorithm);
            }
            if (Digest != null)
            {
                json.WriteString(s_digestPropertyNameBytes, Base64Url.Encode(Digest));
            }
            if (Signature != null)
            {
                json.WriteString(s_signaturePropertyNameBytes, Base64Url.Encode(Signature));
            }
        }
    }
}
