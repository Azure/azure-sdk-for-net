// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Azure.AI.Projects.OpenAI;

internal partial class InternalOpenAIPaginatedListResultOfT<TData> : ReadOnlyCollection<TData>
{
    public string FirstId { get; }
    public string LastId { get; }
    public bool HasMore { get; }

    internal InternalOpenAIPaginatedListResultOfT() : base(new ChangeTrackingList<TData>())
    { }

    internal InternalOpenAIPaginatedListResultOfT(string firstId, string lastId, bool hasMore, IList<TData> data)
        : base(data)
    {
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    internal static InternalOpenAIPaginatedListResultOfT<TData> DeserializeInternalOpenAIPaginatedListResultOfT(
        ClientResult protocolResult,
        Func<JsonElement, ModelReaderWriterOptions, TData> dataItemDeserializer,
        ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(protocolResult.GetRawResponse().ContentStream);
        return DeserializeInternalOpenAIPaginatedListResultOfT(document.RootElement, dataItemDeserializer, options);
    }

    internal static InternalOpenAIPaginatedListResultOfT<TData> DeserializeInternalOpenAIPaginatedListResultOfT(
        JsonElement element,
        Func<JsonElement, ModelReaderWriterOptions, TData> dataItemDeserializer,
        ModelReaderWriterOptions options)
    {
        if (element.ValueKind != JsonValueKind.Object)
        {
            return null;
        }

        string firstId = null;
        string lastId = null;
        bool hasMore = false;
        List<TData> data = [];

        foreach (JsonProperty topProperty in element.EnumerateObject())
        {
            if (topProperty.NameEquals("first_id"u8))
            {
                firstId = topProperty.Value.GetString();
            }
            else if (topProperty.NameEquals("last_id"u8))
            {
                lastId = topProperty.Value.GetString();
            }
            else if (topProperty.NameEquals("has_more"u8))
            {
                hasMore = topProperty.Value.GetBoolean();
            }
            else if (topProperty.NameEquals("data"u8))
            {
                if (topProperty.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                    {
                        TData dataItem = dataItemDeserializer.Invoke(dataElement, options);
                        data.Add(dataItem);
                    }
                }
            }
        }

        return new(firstId, lastId, hasMore, data);
    }
}
