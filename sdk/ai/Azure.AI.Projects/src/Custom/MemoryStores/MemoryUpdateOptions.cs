// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Memory;

/// <summary> Options that describe a memory-store update request. </summary>
public partial class MemoryUpdateOptions : IJsonModel<MemoryUpdateOptions>
{
    /// <summary> The conversation items to write into the memory store. </summary>
    public IList<ResponseItem> Items { get; private set; }
    /// <summary> The scope (for example, user or session identifier) that partitions the memory store. </summary>
    public string Scope { get; }
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

    private InternalMemoryUpdateOptions GetInternalCopy()
    {
        return new InternalMemoryUpdateOptions(Scope, ResponseItemHelpers.ConvertItemsTo<InputItem, ResponseItem>(Items), PreviousUpdateId, UpdateDelay, additionalBinaryDataProperties: null);
    }

    private static MemoryUpdateOptions CreateFromInternalOptions(InternalMemoryUpdateOptions internalOptions)
    {
        return new(internalOptions.Scope)
        {
            PreviousUpdateId = internalOptions.PreviousUpdateId,
            UpdateDelay = internalOptions.UpdateDelay,
            Items = ResponseItemHelpers.ConvertItemsTo<ResponseItem, InputItem>(internalOptions.Items),
        };
    }

    MemoryUpdateOptions IJsonModel<MemoryUpdateOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        InternalMemoryUpdateOptions internalOptions = ((IJsonModel<InternalMemoryUpdateOptions>)new InternalMemoryUpdateOptions()).Create(ref reader, options);
        return CreateFromInternalOptions(internalOptions);
    }

    MemoryUpdateOptions IPersistableModel<MemoryUpdateOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        InternalMemoryUpdateOptions internalOptions = ((IPersistableModel<InternalMemoryUpdateOptions>)new InternalMemoryUpdateOptions()).Create(data, options);
        return CreateFromInternalOptions(internalOptions);
    }

    string IPersistableModel<MemoryUpdateOptions>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => options.Format ?? ModelSerializationExtensions.WireOptions.Format;

    void IJsonModel<MemoryUpdateOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ((IJsonModel<InternalMemoryUpdateOptions>)GetInternalCopy()).Write(writer, options);
    }

    BinaryData IPersistableModel<MemoryUpdateOptions>.Write(ModelReaderWriterOptions options)
    {
        return ((IPersistableModel<InternalMemoryUpdateOptions>)GetInternalCopy()).Write(options);
    }
}
