using Azure.Security.KeyVault.Keys.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyVerifyParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText AlgorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText DigestPropertyNameBytes = JsonEncodedText.Encode("value");

        public string Algorithm { get; set; }

        public byte[] Digest { get; set; }

        public byte[] Signature { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(AlgorithmPropertyNameBytes, Algorithm);
            }
            if (Digest != null)
            {
                json.WriteString(DigestPropertyNameBytes, Base64Url.Encode(Digest));
            }
            if (Signature != null)
            {
                json.WriteString(DigestPropertyNameBytes, Base64Url.Encode(Signature));
            }
        }
    }
}