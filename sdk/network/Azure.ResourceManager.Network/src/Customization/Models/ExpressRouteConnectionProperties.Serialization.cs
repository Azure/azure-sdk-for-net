// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("ExpressRouteCircuitPeeringId",
        SerializationValueHook = nameof(SerializeExpressRouteCircuitPeeringId),
        DeserializationValueHook = nameof(DeserializeExpressRouteCircuitPeeringId))]
    internal partial class ExpressRouteConnectionProperties
    {
        private void SerializeExpressRouteCircuitPeeringId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, ExpressRouteCircuitPeeringId);

        private static void DeserializeExpressRouteCircuitPeeringId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
