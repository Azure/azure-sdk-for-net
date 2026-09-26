// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    // The SDK exposes scalar IDs, but these REST properties remain object-shaped resource references.
    internal static class ResourceReferenceSerialization
    {
        internal static void Write(Utf8JsonWriter writer, ResourceIdentifier id)
        {
            if (id is null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();
            writer.WriteString("id", id);
            writer.WriteEndObject();
        }

        internal static ResourceIdentifier Read(JsonProperty property)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            return property.Value.TryGetProperty("id", out var id)
                && id.ValueKind != JsonValueKind.Null
                    ? new ResourceIdentifier(id.GetString())
                    : null;
        }
    }
}
