// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    internal class PolicyCertificateModificationConverter : JsonConverter<PolicyCertificateModification>
    {
        public override PolicyCertificateModification Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string serializedReader = Utilities.SerializeJsonObject(ref reader, options);

            using var document = JsonDocument.Parse(serializedReader);
            return PolicyCertificateModification.DeserializePolicyCertificateModification(document.RootElement);
        }

        public override void Write(Utf8JsonWriter writer, PolicyCertificateModification value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("policyCertificate");
            // Json Web Key value.
            writer.WriteStartObject();
            writer.WriteString("alg", value.InternalPolicyCertificate.Alg);
            writer.WriteString("use", value.InternalPolicyCertificate.Use);
            writer.WriteString("kty", value.InternalPolicyCertificate.Kty);
            writer.WritePropertyName("x5c");
            writer.WriteStartArray();
            foreach (string x5c in value.InternalPolicyCertificate.X5C)
            {
                writer.WriteStringValue(x5c);
            }
            writer.WriteEndArray();

            writer.WriteEndObject(); // PolicyCertificate object.
            writer.WriteEndObject(); // Object.
        }
    }
}
