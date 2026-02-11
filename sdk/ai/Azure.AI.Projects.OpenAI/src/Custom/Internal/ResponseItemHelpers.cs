// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

#pragma warning disable SCME0001

internal static partial class ResponseItemHelpers
{
    internal static void DeserializeItemsValue(JsonProperty property, ref IList<ResponseItem> items)
    {
        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            List<ResponseItem> deserializedItems = [];
            foreach (JsonElement serializedResponseItemElement in property.Value.EnumerateArray())
            {
                ResponseItem deserializedItem = ModelReaderWriter.Read<ResponseItem>(
                    BinaryData.FromString(serializedResponseItemElement.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    OpenAIContext.Default);
                deserializedItems.Add(deserializedItem);
            }
            items = deserializedItems;
        }
    }

    internal static void SerializeItemsValue(Utf8JsonWriter writer, IEnumerable<ResponseItem> items, ModelReaderWriterOptions options)
    {
        if (items is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartArray();
            foreach (ResponseItem item in items)
            {
                (item as IJsonModel<ResponseItem>)?.Write(writer, ModelSerializationExtensions.WireOptions);
            }
            writer.WriteEndArray();
        }
    }

    internal static BinaryContent GetItemsRequestContent(IEnumerable<ResponseItem> items)
    {
        MemoryStream memoryStream = new();
        Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();
        writer.WritePropertyName("items"u8);
        SerializeItemsValue(writer, items, ModelSerializationExtensions.WireOptions);
        writer.WriteEndObject();
        writer.Flush();
        memoryStream.Position = 0;
        return BinaryContent.Create(memoryStream);
    }

    internal static ResponseItem GetCopyForInput(this ResponseItem item)
    {
        BinaryData serializedItem = ModelReaderWriter.Write(item, ModelSerializationExtensions.WireOptions, OpenAIContext.Default);
        ResponseItem copiedItem = ModelReaderWriter.Read<ResponseItem>(serializedItem, ModelSerializationExtensions.WireOptions, OpenAIContext.Default);
        copiedItem.Patch.Set("$.id"u8, string.Empty);
        copiedItem.Patch.Set("$.status"u8, string.Empty);
        copiedItem.Patch.Remove("$.id"u8);
        copiedItem.Patch.Remove("$.status"u8);
        return copiedItem;
    }
}
