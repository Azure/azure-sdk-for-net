// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Static helpers for serializing and deserializing Foundry storage request/response envelopes.
/// </summary>
internal static class StorageEnvelopeSerializer
{
    private static readonly ModelReaderWriterOptions JsonOptions = ModelReaderWriterOptions.Json;

    /// <summary>
    /// Serializes a <see cref="CreateResponseRequest"/> to a JSON byte array.
    /// Input items and history item IDs are always serialized as arrays, never null.
    /// </summary>
    public static ReadOnlyMemory<byte> SerializeCreateRequest(CreateResponseRequest request)
    {
        using var ms = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(ms);

        writer.WriteStartObject();
        writer.WritePropertyName("response");
        ((IJsonModel<Models.ResponseObject>)request.Response).Write(writer, JsonOptions);

        writer.WritePropertyName("input_items");
        writer.WriteStartArray();
        foreach (var item in request.InputItems)
        {
            ((IJsonModel<OutputItem>)item).Write(writer, JsonOptions);
        }
        writer.WriteEndArray();

        writer.WritePropertyName("history_item_ids");
        writer.WriteStartArray();
        foreach (var id in request.HistoryItemIds)
        {
            writer.WriteStringValue(id);
        }
        writer.WriteEndArray();

        writer.WriteEndObject();
        writer.Flush();

        return ms.ToArray();
    }

    /// <summary>
    /// Serializes a <see cref="Models.ResponseObject"/> to a JSON byte array.
    /// </summary>
    public static ReadOnlyMemory<byte> SerializeResponse(Models.ResponseObject response)
    {
        using var ms = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(ms);
        ((IJsonModel<Models.ResponseObject>)response).Write(writer, JsonOptions);
        writer.Flush();
        return ms.ToArray();
    }

    /// <summary>
    /// Serializes a batch item ID request body: <c>{ "item_ids": [...] }</c>.
    /// </summary>
    public static ReadOnlyMemory<byte> SerializeBatchRequest(IList<string> itemIds)
    {
        using var ms = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(ms);
        writer.WriteStartObject();
        writer.WritePropertyName("item_ids");
        writer.WriteStartArray();
        foreach (var id in itemIds)
        {
            writer.WriteStringValue(id);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Flush();
        return ms.ToArray();
    }

    /// <summary>
    /// Deserializes a JSON string into a <see cref="Response"/>.
    /// </summary>
    [SuppressMessage("Usage", "AZC0150:Use ModelReaderWriterContext overload", Justification = "Generated contracts do not yet expose ModelReaderWriterContext.")]
    public static Models.ResponseObject DeserializeResponse(string json)
    {
        var data = BinaryData.FromString(json);
        return ModelReaderWriter.Read<Models.ResponseObject>(data, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Response from storage.");
    }

    /// <summary>
    /// Deserializes a JSON string into an <see cref="AgentsPagedResultOutputItem"/>.
    /// </summary>
    [SuppressMessage("Usage", "AZC0150:Use ModelReaderWriterContext overload", Justification = "Generated contracts do not yet expose ModelReaderWriterContext.")]
    public static AgentsPagedResultOutputItem DeserializePagedItems(string json)
    {
        var data = BinaryData.FromString(json);
        return ModelReaderWriter.Read<AgentsPagedResultOutputItem>(data, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize AgentsPagedResultOutputItem from storage.");
    }

    /// <summary>
    /// Deserializes a JSON array of nullable <see cref="OutputItem"/> objects.
    /// </summary>
    [SuppressMessage("Usage", "AZC0150:Use ModelReaderWriterContext overload", Justification = "Generated contracts do not yet expose ModelReaderWriterContext.")]
    public static IEnumerable<OutputItem?> DeserializeItemsArray(string json)
    {
        using var doc = JsonDocument.Parse(json);
        var result = new List<OutputItem?>();
        foreach (var element in doc.RootElement.EnumerateArray())
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                result.Add(null);
                continue;
            }
            var itemData = BinaryData.FromString(element.GetRawText());
            result.Add(ModelReaderWriter.Read<OutputItem>(itemData, JsonOptions));
        }
        return result;
    }

    /// <summary>
    /// Deserializes a JSON array of history item ID strings.
    /// </summary>
    public static IEnumerable<string> DeserializeHistoryIds(string json)
    {
        using var doc = JsonDocument.Parse(json);
        var result = new List<string>();
        foreach (var element in doc.RootElement.EnumerateArray())
        {
            result.Add(element.GetString()!);
        }
        return result;
    }
}
