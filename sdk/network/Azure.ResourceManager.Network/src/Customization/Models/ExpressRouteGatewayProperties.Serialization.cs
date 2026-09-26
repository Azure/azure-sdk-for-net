// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("VirtualHubId",
        SerializationValueHook = nameof(SerializeVirtualHubId),
        DeserializationValueHook = nameof(DeserializeVirtualHubId))]
    internal partial class ExpressRouteGatewayProperties
    {
        private void SerializeVirtualHubId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, VirtualHubId);

        private static void DeserializeVirtualHubId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
