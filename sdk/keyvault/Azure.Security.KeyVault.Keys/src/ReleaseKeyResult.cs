// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The key release result containing the released key.
    /// </summary>
    public class ReleaseKeyResult : IJsonDeserializable
    {
        private const string ValuePropertyName = "value";

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseKeyResult"/> class.
        /// </summary>
        /// <param name="algorithm">
        /// The <see cref="KeyExportEncryptionAlgorithm"/> passed to <see cref="KeyClient.ReleaseKey(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/>
        /// or <see cref="KeyClient.ReleaseKeyAsync(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/>.
        /// </param>
        internal ReleaseKeyResult(KeyExportEncryptionAlgorithm? algorithm)
        {
            Algorithm = algorithm;
        }

        /// <summary>
        /// Gets a signed object containing the released key.
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Gets the <see cref="KeyExportEncryptionAlgorithm"/> passed to <see cref="KeyClient.ReleaseKey(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/>
        /// or <see cref="KeyClient.ReleaseKeyAsync(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public KeyExportEncryptionAlgorithm? Algorithm { get; private set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ValuePropertyName:
                        Value = prop.Value.GetString();
                        break;
                }
            }
        }
    }
}
