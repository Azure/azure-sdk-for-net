// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Memory;

/// <summary> Options that describe a memory-store search request. </summary>
[CodeGenType("SearchMemoriesRequest")]
[Experimental("AAIP001")]
public partial class MemorySearchOptions : IJsonModel<MemorySearchOptions>
{
    /*
     * Public wrapper type temporarily needed to mitigate code generation limitation with suffix/prefix
     * collision of Azure.AI.Projects.OpenAI and OpenAI.Responses
     */

    /// <summary> The conversation items used as context for the search. </summary>
    public IList<ResponseItem> Items { get; private set; }
    /// <summary> The identifier of the previous search, used to continue or refine a prior search. </summary>
    public string PreviousSearchId { get; set; }
    /// <summary> Options controlling how the search results are shaped (limits, ranking, etc.). </summary>
    [CodeGenMember("Options")]
    public MemorySearchResultOptions ResultOptions { get; set; }

    /// <summary> Initializes a new instance of <see cref="MemorySearchOptions"/>. </summary>
    /// <param name="scope"> The scope that partitions the memory store. </param>
    public MemorySearchOptions(string scope)
    {
        Scope = scope;
        Items = new ChangeTrackingList<ResponseItem>();
    }

    /// <param name="element"> The JSON element to deserialize. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    internal static MemorySearchOptions DeserializeMemorySearchOptions(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string scope = default;
        IList<ResponseItem> items = default;
        string previousSearchId = default;
        MemorySearchResultOptions resultOptions = default;
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
            if (prop.NameEquals("previous_search_id"u8))
            {
                previousSearchId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("options"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                resultOptions = ModelReaderWriter.Read<MemorySearchResultOptions>(BinaryData.FromString(prop.Value.GetRawText()), options, AzureAIProjectsContext.Default);

                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new MemorySearchOptions(scope, items ?? new ChangeTrackingList<ResponseItem>(), previousSearchId, resultOptions, additionalBinaryDataProperties);
    }
}
