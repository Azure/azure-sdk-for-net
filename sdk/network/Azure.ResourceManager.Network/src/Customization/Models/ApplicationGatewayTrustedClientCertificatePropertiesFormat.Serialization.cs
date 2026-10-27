// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // These hooks preserve the pre-TypeSpec JSON-backed BinaryData contract and service PEM responses because the C# bytes mapping incorrectly applies Base64 conversion.
    [CodeGenSerialization(nameof(Data), SerializationValueHook = nameof(SerializeData), DeserializationValueHook = nameof(DeserializeCertificateData))]
    [CodeGenSerialization(nameof(ValidatedCertData), SerializationValueHook = nameof(SerializeValidatedCertData), DeserializationValueHook = nameof(DeserializeCertificateData))]
    internal partial class ApplicationGatewayTrustedClientCertificatePropertiesFormat
    {
        private void SerializeData(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.SerializeCertificateData(writer, Data);

        private void SerializeValidatedCertData(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.SerializeCertificateData(writer, ValidatedCertData);

        private static void DeserializeCertificateData(JsonProperty property, ref BinaryData value)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            value = BinaryData.FromString(property.Value.GetRawText());
        }
    }
}
