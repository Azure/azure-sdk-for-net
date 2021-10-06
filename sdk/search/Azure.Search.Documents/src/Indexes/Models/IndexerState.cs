﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Represents all of the state that defines and dictates the indexer&apos;s current execution. </summary>
    [CodeGenModel("IndexerCurrentState")]
    public partial class IndexerState
    {
        /// <summary> Change tracking state used when indexing starts on all documents in the datasource. </summary>
        internal string AllDocsInitialChangeTrackingState => HighWaterMark.AllDocumentsInitialHighWaterMark;

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        internal string AllDocsFinalChangeTrackingState => HighWaterMark.AllDocumentsFinalHighWaterMark;

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        internal string ResetDocsInitialChangeTrackingState => HighWaterMark.ResetDocumentsInitialHighWaterMark;

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        internal string ResetDocsFinalChangeTrackingState => HighWaterMark.ResetDocumentsFinalHighWaterMark;

        /// <summary>
        /// Change tracking state for an indexer's execution.
        /// </summary>
        public IndexerStateHighWaterMark HighWaterMark { get; }

        /// <summary> The list of datasource document ids that have been reset. The datasource document id is the unique identifier for the data in the datasource. The indexer will prioritize selectively re-ingesting these ids. </summary>
        [CodeGenMember("ResetDatasourceDocumentIds")]
        public IReadOnlyList<string> ResetDataSourceDocumentIds { get; }

        /// <summary> Initializes a new instance of IndexerState. </summary>
        /// <param name="mode"> The mode the indexer is running in. </param>
        /// <param name="allDocumentsInitialHighWaterMark"> Change tracking state used when indexing starts on all documents in the datasource. </param>
        /// <param name="allDocumentsFinalHighWaterMark"> Change tracking state value when indexing finishes on all documents in the datasource. </param>
        /// <param name="resetDocumentsInitialHighWaterMark"> Change tracking state used when indexing starts on select, reset documents in the datasource. </param>
        /// <param name="resetDocumentsFinalHighWaterMark"> Change tracking state value when indexing finishes on select, reset documents in the datasource. </param>
        /// <param name="resetDocumentKeys"> The list of document keys that have been reset. The document key is the document&apos;s unique identifier for the data in the search index. The indexer will prioritize selectively re-ingesting these keys. </param>
        /// <param name="resetDataSourceDocumentIds"> The list of datasource document ids that have been reset. The datasource document id is the unique identifier for the data in the datasource. The indexer will prioritize selectively re-ingesting these ids. </param>
        internal IndexerState(IndexingMode? mode, string allDocumentsInitialHighWaterMark, string allDocumentsFinalHighWaterMark, string resetDocumentsInitialHighWaterMark, string resetDocumentsFinalHighWaterMark, IReadOnlyList<string> resetDocumentKeys, IReadOnlyList<string> resetDataSourceDocumentIds)
        {
            Mode = mode;
            ResetDocumentKeys = resetDocumentKeys;
            ResetDataSourceDocumentIds = resetDataSourceDocumentIds;

            HighWaterMark = new IndexerStateHighWaterMark(allDocumentsInitialHighWaterMark, allDocumentsFinalHighWaterMark, resetDocumentsInitialHighWaterMark, resetDocumentsFinalHighWaterMark);
        }
    }
}
