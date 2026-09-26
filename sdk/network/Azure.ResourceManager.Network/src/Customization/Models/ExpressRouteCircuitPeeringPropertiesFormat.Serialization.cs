// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("ExpressRouteConnectionId",
        SerializationValueHook = nameof(SerializeExpressRouteConnectionId),
        DeserializationValueHook = nameof(DeserializeExpressRouteConnectionId))]
    internal partial class ExpressRouteCircuitPeeringPropertiesFormat
    {
        private void SerializeExpressRouteConnectionId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, ExpressRouteConnectionId);

        private static void DeserializeExpressRouteConnectionId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
