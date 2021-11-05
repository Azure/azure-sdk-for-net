// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Secrets
{
    internal class SecretBackup : IJsonDeserializable, IJsonSerializable
    {
        public byte[] Value { get; set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("value", out JsonElement value))
            {
                Value = Base64Url.Decode(value.GetString());
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString("value", Base64Url.Encode(Value));
        }
    }
}
