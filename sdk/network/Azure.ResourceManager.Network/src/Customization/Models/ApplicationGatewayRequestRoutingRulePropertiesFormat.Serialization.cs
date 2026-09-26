// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("EntraJwtValidationConfigId",
        SerializationValueHook = nameof(SerializeEntraJwtValidationConfigId),
        DeserializationValueHook = nameof(DeserializeEntraJwtValidationConfigId))]
    internal partial class ApplicationGatewayRequestRoutingRulePropertiesFormat
    {
        private void SerializeEntraJwtValidationConfigId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, EntraJwtValidationConfigId);

        private static void DeserializeEntraJwtValidationConfigId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
