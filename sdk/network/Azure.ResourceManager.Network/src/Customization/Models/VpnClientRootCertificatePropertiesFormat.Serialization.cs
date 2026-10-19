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
    [CodeGenSerialization(nameof(PublicCertData), SerializationValueHook = nameof(SerializePublicCertData), DeserializationValueHook = nameof(DeserializeCertificateData))]
    internal partial class VpnClientRootCertificatePropertiesFormat
    {
        private void SerializePublicCertData(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.SerializeCertificateData(writer, PublicCertData);

        private static void DeserializeCertificateData(JsonProperty property, ref BinaryData value)
            => value = BinaryData.FromString(property.Value.GetRawText());
    }
}
