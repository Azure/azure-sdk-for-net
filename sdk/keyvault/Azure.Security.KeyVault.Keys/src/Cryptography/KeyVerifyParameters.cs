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
        private static readonly JsonEncodedText s_externalMuPropertyNameBytes = JsonEncodedText.Encode("external_mu");
        private static readonly JsonEncodedText s_contextPropertyNameBytes = JsonEncodedText.Encode("context");

        public string Algorithm { get; set; }

        public byte[] Digest { get; set; }

        public byte[] Signature { get; set; }

        public byte[] ExternalMu { get; set; }

        public byte[] Context { get; set; }

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
            if (ExternalMu != null)
            {
                json.WriteString(s_externalMuPropertyNameBytes, Base64Url.Encode(ExternalMu));
            }
            if (Context != null)
            {
                json.WriteString(s_contextPropertyNameBytes, Base64Url.Encode(Context));
            }
        }
    }
}
