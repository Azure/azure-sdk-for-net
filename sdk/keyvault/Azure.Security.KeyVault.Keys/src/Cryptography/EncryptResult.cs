using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about an encryption operation
    /// </summary>
    public class EncryptResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string CiphertextPropertyName = "value";
        private const string IvPropertyName = "iv";
        private const string AuthenticationDataPropertyName = "aad";
        private const string AuthenticationTagPropertyName = "tag";

        /// <summary>
        /// The KeyId of the key used to encrypt
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// The ciphertext that is the result of the encryption
        /// </summary>
        public byte[] Ciphertext { get; internal set; }

        /// <summary>
        /// The initialization vector
        /// </summary>
        public byte[] Iv { get; internal set; }

        /// <summary>
        /// The authentication data
        /// </summary>
        public byte[] AuthenticationData { get; internal set; }

        /// <summary>
        /// The authentication tag
        /// </summary>
        public byte[] AuthenticationTag { get; internal set; }

        /// <summary>
        /// The algorithm used for encryption
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
                    case CiphertextPropertyName:
                        Ciphertext = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case IvPropertyName:
                        Iv = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case AuthenticationDataPropertyName:
                        AuthenticationData = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case AuthenticationTagPropertyName:
                        AuthenticationTag = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
