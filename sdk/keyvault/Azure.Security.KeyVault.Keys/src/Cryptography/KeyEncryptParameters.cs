// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal struct KeyEncryptParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText s_ivPropertyNameBytes = JsonEncodedText.Encode("iv");
        private static readonly JsonEncodedText s_authenticationDataPropertyNameBytes = JsonEncodedText.Encode("aad");
        private static readonly JsonEncodedText s_authenticationTagPropertyNameBytes = JsonEncodedText.Encode("tag");

        public string Algorithm { get; set; }

        public byte[] Value { get; set; }

        public byte[] Iv { get; set; }

        public byte[] AuthenticationData { get; set; }

        public byte[] AuthenticationTag { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(s_algorithmPropertyNameBytes, Algorithm);
            }
            if (Value != null)
            {
                json.WriteString(s_valuePropertyNameBytes, Base64Url.Encode(Value));
            }
            if (Iv != null)
            {
                json.WriteString(s_ivPropertyNameBytes, Base64Url.Encode(Iv));
            }
            if (AuthenticationData != null)
            {
                json.WriteString(s_authenticationDataPropertyNameBytes, Base64Url.Encode(AuthenticationData));
            }
            if (AuthenticationTag != null)
            {
                json.WriteString(s_authenticationTagPropertyNameBytes, Base64Url.Encode(AuthenticationTag));
            }
        }
    }
}
