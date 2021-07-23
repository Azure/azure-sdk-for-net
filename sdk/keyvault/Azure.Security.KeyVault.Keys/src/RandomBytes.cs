// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    internal class RandomBytes : IJsonDeserializable
    {
        private const string s_valuePropertyName = "value";

        public byte[] Value { get; private set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case s_valuePropertyName:
                        string value = prop.Value.GetString();
                        Value = Base64Url.Decode(value);
                        break;
                }
            }
        }
    }
}
