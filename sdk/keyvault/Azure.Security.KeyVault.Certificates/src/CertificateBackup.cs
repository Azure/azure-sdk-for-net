// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class CertificateBackup : IJsonDeserializable, IJsonSerializable
    {
        public byte[] Value { get; set; }

        private const string ValuePropertyName = "value";
        private static readonly JsonEncodedText ValuePropertyNameBytes = JsonEncodedText.Encode(ValuePropertyName);

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty(ValuePropertyName, out JsonElement value))
            {
                Value = Base64Url.Decode(value.GetString());
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(ValuePropertyNameBytes, Base64Url.Encode(Value));
        }
    }
}
