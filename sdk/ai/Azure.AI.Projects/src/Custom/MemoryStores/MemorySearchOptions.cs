// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects;

public partial class MemorySearchOptions : IJsonModel<MemorySearchOptions>
{
    /*
     * Public wrapper type temporarily needed to mitigate code generation limitation with suffix/prefix
     * collision of Azure.AI.Projects.OpenAI and OpenAI.Responses
     */

    public IList<ResponseItem> Items { get; private set; }
    public string Scope { get; }
    public string PreviousSearchId { get; set; }
    public MemorySearchResultOptions ResultOptions { get; set; }

    public MemorySearchOptions(string scope)
    {
        Scope = scope;
        Items = new ChangeTrackingList<ResponseItem>();
    }

    private InternalMemorySearchOptions GetInternalCopy()
    {
        return new InternalMemorySearchOptions(Scope, ResponseItemHelpers.ConvertItemsTo<InternalItemParam, ResponseItem>(Items), PreviousSearchId, ResultOptions, additionalBinaryDataProperties: null);
    }

    private static MemorySearchOptions CreateFromInternalOptions(InternalMemorySearchOptions internalOptions)
    {
        return new(internalOptions.Scope)
        {
            PreviousSearchId = internalOptions.PreviousSearchId,
            Items = ResponseItemHelpers.ConvertItemsTo<ResponseItem, InternalItemParam>(internalOptions.Items),
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
