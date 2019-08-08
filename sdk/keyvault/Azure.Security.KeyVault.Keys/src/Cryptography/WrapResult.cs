using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a wrap operation
    /// </summary>
    public struct WrapResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string EncryptedKeyPropertyName = "value";

        /// <summary>
        /// The key id of the key used to wrap
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The wrapped key
        /// </summary>
        public byte[] EncryptedKey { get; private set; }

        /// <summary>
        /// The algorithm used
        /// </summary>
        public KeyWrapAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case EncryptedKeyPropertyName:
                        EncryptedKey = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
