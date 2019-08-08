using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal struct KeyWrapParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText AlgorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText KeyPropertyNameBytes = JsonEncodedText.Encode("value");

        public string Algorithm { get; set; }

        public byte[] Key { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(AlgorithmPropertyNameBytes, Algorithm);
            }
            if (Key != null)
            {
                json.WriteString(KeyPropertyNameBytes, Base64Url.Encode(Key));
            }
        }
    }
}
