// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.Attestation
{
    internal class StoredAttestationPolicyConverter : JsonConverter<StoredAttestationPolicy>
    {
        public StoredAttestationPolicyConverter()
        {
        }

        /// <inheritdoc/>
        public override StoredAttestationPolicy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert != typeof(StoredAttestationPolicy))
            {
                throw new InvalidOperationException();
            }

            string serializedObject = string.Empty;
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            reader.Read();

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected property name in StoredAttestationPolicy.");
            }

            string fieldName = reader.GetString();
            if (fieldName != "AttestationPolicy")
            {
                throw new JsonException($"Expected property name AttestationPolicy, found {fieldName}.");
            }
            reader.Read();

            string fieldValue = reader.GetString();
            reader.Read();

            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            reader.Read();
            return new StoredAttestationPolicy { AttestationPolicy = Base64Url.DecodeString(fieldValue) };
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, StoredAttestationPolicy value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("AttestationPolicy");
            writer.WriteStringValue(Base64Url.EncodeString(value.AttestationPolicy));
            writer.WriteEndObject();
        }
    }
}
