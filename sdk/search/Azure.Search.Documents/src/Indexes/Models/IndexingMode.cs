// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public readonly partial struct IndexingMode
    {
        /// <summary> The indexer is indexing all documents in the datasource. </summary>
        [CodeGenMember("IndexingAllDocs")]
        public static IndexingMode AllDocuments { get; } = new IndexingMode(AllDocumentsValue);

        /// <summary> The indexer is indexing selective, reset documents in the datasource. The documents being indexed are defined on indexer status. </summary>
        [CodeGenMember("IndexingResetDocs")]
        public static IndexingMode ResetDocuments { get; } = new IndexingMode(ResetDocumentsValue);
    }
}
