using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about an dencryption operation
    /// </summary>
    public struct DecryptResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string PlaintextPropertyName = "value";

        /// <summary>
        /// The KeyId of the key used to decrypt
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The plaintext that is the result of the decryption
        /// </summary>
        public byte[] Plaintext { get; private set; }

        /// <summary>
        /// The algorithm used for the decryption
        /// </summary>
        public EncryptionAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case PlaintextPropertyName:
                        Plaintext = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
