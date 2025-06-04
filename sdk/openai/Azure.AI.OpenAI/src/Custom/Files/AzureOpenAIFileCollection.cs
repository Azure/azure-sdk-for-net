// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Files;

[Experimental("AOAI001")]
internal partial class AzureOpenAIFileCollection : OpenAIFileCollection
{
    internal new IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        = new ChangeTrackingDictionary<string, BinaryData>();

    internal string Object { get; } = "list";

    internal AzureOpenAIFileCollection()
        : this(
              new ChangeTrackingList<AzureOpenAIFile>(),
              "list",
              firstId: null,
              lastId: null,
              hasMore: false,
              new ChangeTrackingDictionary<string, BinaryData>())
    { }

    internal AzureOpenAIFileCollection(
        IEnumerable<AzureOpenAIFile> files,
        string @object,
        string firstId,
        string lastId,
        bool hasMore,
        IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(files.Cast<OpenAIFile>().ToList(), @object, firstId, lastId, hasMore, additionalBinaryDataProperties)
    { }
}