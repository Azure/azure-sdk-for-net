// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal class KeyBackup : IJsonDeserializable, IJsonSerializable
    {
        private const string ValuePropertyName = "value";
        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode(ValuePropertyName);

        public byte[] Value { get; set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty(ValuePropertyName, out JsonElement value))
            {
                Value = Base64Url.Decode(value.GetString());
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_valuePropertyNameBytes, Base64Url.Encode(Value));
        }
    }
}
