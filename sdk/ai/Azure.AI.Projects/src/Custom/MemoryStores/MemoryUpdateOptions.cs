// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects;

public partial class MemoryUpdateOptions : IJsonModel<MemoryUpdateOptions>
{
    public IList<ResponseItem> Items { get; private set; }
    public string Scope { get; }
    public string ConversationId { get; set; }
    public string PreviousUpdateId { get; set; }
    public int? UpdateDelay { get; set; }

    public MemoryUpdateOptions(string scope)
    {
        Scope = scope;
        Items = new ChangeTrackingList<ResponseItem>();
    }

    private InternalMemoryUpdateOptions GetInternalCopy()
    {
        return new InternalMemoryUpdateOptions(Scope, ConversationId, ResponseItemHelpers.ConvertItemsTo<InternalItemParam,ResponseItem>(Items), PreviousUpdateId, UpdateDelay, additionalBinaryDataProperties: null);
    }

    private static MemoryUpdateOptions CreateFromInternalOptions(InternalMemoryUpdateOptions internalOptions)
    {
        return new(internalOptions.Scope)
        {
            ConversationId = internalOptions.ConversationId,
            PreviousUpdateId = internalOptions.PreviousUpdateId,
            UpdateDelay = internalOptions.UpdateDelay,
            Items = ResponseItemHelpers.ConvertItemsTo<ResponseItem,InternalItemParam>(internalOptions.Items),
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
