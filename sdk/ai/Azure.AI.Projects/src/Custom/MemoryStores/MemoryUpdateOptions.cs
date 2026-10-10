// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Memory;

[CodeGenType("UpdateMemoriesRequest")]
public partial class MemoryUpdateOptions : IJsonModel<MemoryUpdateOptions>
{
    /// <summary> The conversation items to write into the memory store. </summary>
    public IList<ResponseItem> Items { get; private set; }
    /// <summary> The identifier of the previous update, used to chain or supersede a prior update. </summary>
    public string PreviousUpdateId { get; set; }
    /// <summary> Optional delay, in milliseconds, before the update is applied. </summary>
    public int? UpdateDelay { get; set; }

    /// <summary> Initializes a new instance of <see cref="MemoryUpdateOptions"/>. </summary>
    /// <param name="scope"> The scope that partitions the memory store. </param>
    public MemoryUpdateOptions(string scope)
    {
        Scope = scope;
        Items = new ChangeTrackingList<ResponseItem>();
    }

    /// <param name="element"> The JSON element to deserialize. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    internal static MemoryUpdateOptions DeserializeMemoryUpdateOptions(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string scope = default;
        IList<ResponseItem> items = default;
        string previousUpdateId = default;
        int? updateDelay = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("scope"u8))
            {
                scope = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("items"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<ResponseItem> array = new List<ResponseItem>();
                foreach (var item in prop.Value.EnumerateArray())
                {
                    ResponseItem responseItem = ModelReaderWriter.Read<ResponseItem>(BinaryData.FromString(item.GetRawText()), options, AzureAIProjectsContext.Default);
                    array.Add(responseItem);
                }
                items = array;
                continue;
            }
            if (prop.NameEquals("previous_update_id"u8))
            {
                previousUpdateId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("update_delay"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                updateDelay = prop.Value.GetInt32();
                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new MemoryUpdateOptions(scope, items ?? new ChangeTrackingList<ResponseItem>(), previousUpdateId, updateDelay, additionalBinaryDataProperties);
    }
}
