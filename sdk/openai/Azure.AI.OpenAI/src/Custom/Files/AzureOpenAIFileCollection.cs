// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Files;

[Experimental("AOAI001")]
internal partial class AzureOpenAIFileCollection : OpenAIFileCollection
{
    internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        = new ChangeTrackingDictionary<string, BinaryData>();

    internal InternalListFilesResponseObject Object { get; }

    internal AzureOpenAIFileCollection()
        : this(
              new ChangeTrackingList<AzureOpenAIFile>(),
              InternalListFilesResponseObject.List,
              new ChangeTrackingDictionary<string, BinaryData>())
    { }

    internal AzureOpenAIFileCollection(
        IEnumerable<AzureOpenAIFile> files,
        InternalListFilesResponseObject @object,
        IDictionary<string, BinaryData> serializedAdditionalRawData)
            : base(files.Cast<OpenAIFile>().ToList(), @object, serializedAdditionalRawData)
    { }
}