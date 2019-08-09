using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a sign operation
    /// </summary>
    public class SignResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string SignaturePropertyName = "value";

        /// <summary>
        /// The key id of the key used to sign
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The signature
        /// </summary>
        public byte[] Signature { get; private set; }

        /// <summary>
        /// The algorithm used to sign
        /// </summary>
        public SignatureAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case SignaturePropertyName:
                        Signature = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
