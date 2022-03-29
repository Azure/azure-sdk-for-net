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
        internal ReleaseKeyResult()
        {
        }

        /// <summary>
        /// Gets a signed object containing the released key.
        /// </summary>
        public string Value { get; internal set; }

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
