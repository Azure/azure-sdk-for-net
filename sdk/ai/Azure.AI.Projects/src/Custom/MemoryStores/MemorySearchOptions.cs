// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Memory;

/// <summary> Options that describe a memory-store search request. </summary>
public partial class MemorySearchOptions : IJsonModel<MemorySearchOptions>
{
    /*
     * Public wrapper type temporarily needed to mitigate code generation limitation with suffix/prefix
     * collision of Azure.AI.Projects.OpenAI and OpenAI.Responses
     */

    /// <summary> The conversation items used as context for the search. </summary>
    public IList<ResponseItem> Items { get; private set; }
    /// <summary> The scope (for example, user or session identifier) that partitions the memory store. </summary>
    public string Scope { get; }
    /// <summary> The identifier of the previous search, used to continue or refine a prior search. </summary>
    public string PreviousSearchId { get; set; }
    /// <summary> Options controlling how the search results are shaped (limits, ranking, etc.). </summary>
    public MemorySearchResultOptions ResultOptions { get; set; }

    /// <summary> Initializes a new instance of <see cref="MemorySearchOptions"/>. </summary>
    /// <param name="scope"> The scope that partitions the memory store. </param>
    public MemorySearchOptions(string scope)
    {
        Scope = scope;
        Items = new ChangeTrackingList<ResponseItem>();
    }

    private InternalMemorySearchOptions GetInternalCopy()
    {
        return new InternalMemorySearchOptions(Scope, ResponseItemHelpers.ConvertItemsTo<InputItem, ResponseItem>(Items), PreviousSearchId, ResultOptions, additionalBinaryDataProperties: null);
    }

    private static MemorySearchOptions CreateFromInternalOptions(InternalMemorySearchOptions internalOptions)
    {
        return new(internalOptions.Scope)
        {
            PreviousSearchId = internalOptions.PreviousSearchId,
            Items = ResponseItemHelpers.ConvertItemsTo<ResponseItem, InputItem>(internalOptions.Items),
            ResultOptions = internalOptions.Options,
        };
    }

    MemorySearchOptions IJsonModel<MemorySearchOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        InternalMemorySearchOptions internalOptions = ((IJsonModel<InternalMemorySearchOptions>)new InternalMemorySearchOptions()).Create(ref reader, options);
        return CreateFromInternalOptions(internalOptions);
    }

    MemorySearchOptions IPersistableModel<MemorySearchOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        InternalMemorySearchOptions internalOptions = ((IPersistableModel<InternalMemorySearchOptions>)new InternalMemorySearchOptions()).Create(data, options);
        return CreateFromInternalOptions(internalOptions);
    }

    string IPersistableModel<MemorySearchOptions>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => options.Format ?? ModelSerializationExtensions.WireOptions.Format;

    void IJsonModel<MemorySearchOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ((IJsonModel<InternalMemorySearchOptions>)GetInternalCopy()).Write(writer, options);
    }

    BinaryData IPersistableModel<MemorySearchOptions>.Write(ModelReaderWriterOptions options)
    {
        return ((IPersistableModel<InternalMemorySearchOptions>)GetInternalCopy()).Write(options);
    }
}
