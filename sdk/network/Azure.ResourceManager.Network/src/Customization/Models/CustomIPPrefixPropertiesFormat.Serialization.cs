// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("ParentCustomIPPrefixId",
        SerializationValueHook = nameof(SerializeParentCustomIPPrefixId),
        DeserializationValueHook = nameof(DeserializeParentCustomIPPrefixId))]
    internal partial class CustomIPPrefixPropertiesFormat
    {
        private void SerializeParentCustomIPPrefixId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, ParentCustomIPPrefixId);

        private static void DeserializeParentCustomIPPrefixId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
