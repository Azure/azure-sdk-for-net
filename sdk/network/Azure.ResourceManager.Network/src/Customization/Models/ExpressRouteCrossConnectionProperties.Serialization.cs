// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("ExpressRouteCircuitId",
        SerializationValueHook = nameof(SerializeExpressRouteCircuitId),
        DeserializationValueHook = nameof(DeserializeExpressRouteCircuitId))]
    internal partial class ExpressRouteCrossConnectionProperties
    {
        private void SerializeExpressRouteCircuitId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, ExpressRouteCircuitId);

        private static void DeserializeExpressRouteCircuitId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
