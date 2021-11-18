// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Contains random bytes returned from <see cref="KeyClient.GetRandomBytes(int, System.Threading.CancellationToken)"/>
    /// or <see cref="KeyClient.GetRandomBytesAsync(int, System.Threading.CancellationToken)"/>.
    /// </summary>
    internal class RandomBytes : IJsonDeserializable
    {
        private const string ValuePropertyName = "value";

        internal RandomBytes()
        {
        }

        /// <summary>
        /// Gets random bytes returned from <see cref="KeyClient.GetRandomBytes(int, System.Threading.CancellationToken)"/>
        /// or <see cref="KeyClient.GetRandomBytesAsync(int, System.Threading.CancellationToken)"/>.
        /// </summary>
        public byte[] Value { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ValuePropertyName:
                        string value = prop.Value.GetString();
                        Value = Base64Url.Decode(value);
                        break;
                }
            }
        }
    }
}
