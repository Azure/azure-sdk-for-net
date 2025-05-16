// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    // This is the fix for issue #49779
    [CodeGenSerialization(nameof(ResourceUri), SerializationValueHook = nameof(WriteResourceUri), DeserializationValueHook = nameof(DeserializeResourceUri))]
    public partial class VirtualHubInboundRoutesContent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteResourceUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (ResourceUri.IsAbsoluteUri)
                writer.WriteStringValue(ResourceUri.AbsoluteUri);
            else
                writer.WriteStringValue(ResourceUri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeResourceUri(JsonProperty property, ref Uri resourceUri)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                if (Uri.TryCreate(property.Value.GetString(), UriKind.Absolute, out resourceUri))
                {
                    resourceUri = new Uri(property.Value.GetString(), UriKind.Absolute);
                }
                else
                {
                    resourceUri = new Uri(property.Value.GetString(), UriKind.Relative);
                }
            }
        }
    }
}
