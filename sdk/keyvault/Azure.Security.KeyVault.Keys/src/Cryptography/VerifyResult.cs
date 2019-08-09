using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a verify operation
    /// </summary>
    public class VerifyResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string ValidPropertyName = "value";

        /// <summary>
        /// The key id of the key used to verify
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// The result of the verification
        /// </summary>
        public bool Valid { get; private set; }

        /// <summary>
        /// The algorithm used
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
                    case ValidPropertyName:
                        Valid = prop.Value.GetBoolean();
                        break;
                }
            }
        }
    }
}
