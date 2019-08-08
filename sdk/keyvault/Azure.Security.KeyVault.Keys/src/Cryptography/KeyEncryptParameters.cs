using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal struct KeyEncryptParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText AlgorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText ValuePropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText IvPropertyNameBytes = JsonEncodedText.Encode("iv");
        private static readonly JsonEncodedText AuthenticationDataPropertyNameBytes = JsonEncodedText.Encode("aad");
        private static readonly JsonEncodedText AuthenticationTagPropertyNameBytes = JsonEncodedText.Encode("tag");

        public string Algorithm { get; set; }

        public byte[] Value { get; set; }

        public byte[] Iv { get; set; }

        public byte[] AuthenticationData { get; set; }

        public byte[] AuthenticationTag { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(AlgorithmPropertyNameBytes, Algorithm);
            }
            if (Value != null)
            {
                json.WriteString(ValuePropertyNameBytes, Base64Url.Encode(Value));
            }
            if (Iv != null)
            {
                json.WriteString(IvPropertyNameBytes, Base64Url.Encode(Iv));
            }
            if (AuthenticationData != null)
            {
                json.WriteString(AuthenticationDataPropertyNameBytes, Base64Url.Encode(AuthenticationData));
            }
            if (AuthenticationTag != null)
            {
                json.WriteString(AuthenticationTagPropertyNameBytes, Base64Url.Encode(AuthenticationTag));
            }
        }
    }
}
