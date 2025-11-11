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
    // public int? MaxMemories { get; set; }

    // public MemorySearchOptions(string scope)
    // {
    //     Scope = scope;
    //     Items = new ChangeTrackingList<ResponseItem>();
    // }

    // private InternalMemorySearchOptions GetInternalCopy()
    // {
    //     return new InternalMemorySearchOptions(maxMemories, additionalBinaryDataProperties: null);
    // }

    // private static MemorySearchOptions CreateFromInternalOptions(InternalMemorySearchOptions internalOptions)
    // {
    //     return new(internalOptions.Scope)
    //     {
    //         ConversationId = internalOptions.ConversationId,
    //         PreviousUpdateId = internalOptions.PreviousUpdateId,
    //         UpdateDelay = internalOptions.UpdateDelay,
    //         Items = ResponseItemHelpers.ConvertItemsTo<ResponseItem,InternalItemParam>(internalOptions.Items),
    //     };
    // }

    // MemorySearchOptions IJsonModel<MemorySearchOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    // {
    //     InternalMemorySearchOptions internalOptions = ((IJsonModel<InternalMemorySearchOptions>)new InternalMemorySearchOptions()).Create(ref reader, options);
    //     return CreateFromInternalOptions(internalOptions);
    // }

    // MemorySearchOptions IPersistableModel<MemorySearchOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
    // {
    //     InternalMemorySearchOptions internalOptions = ((IPersistableModel<InternalMemorySearchOptions>)new InternalMemorySearchOptions()).Create(data, options);
    //     return CreateFromInternalOptions(internalOptions);
    // }

    // string IPersistableModel<MemorySearchOptions>.GetFormatFromOptions(ModelReaderWriterOptions options)
    //     => options.Format ?? ModelSerializationExtensions.WireOptions.Format;

    // void IJsonModel<MemorySearchOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    // {
    //     ((IJsonModel<InternalMemorySearchOptions>)GetInternalCopy()).Write(writer, options);
    // }

    // BinaryData IPersistableModel<MemorySearchOptions>.Write(ModelReaderWriterOptions options)
    // {
    //     return ((IPersistableModel<InternalMemorySearchOptions>)GetInternalCopy()).Write(options);
    // }
}
