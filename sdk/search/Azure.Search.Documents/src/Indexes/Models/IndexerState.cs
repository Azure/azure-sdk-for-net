// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal string AllDocsInitialChangeTrackingState => ChangeTrackingState.AllDocumentsInitialState;

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        internal string AllDocsFinalChangeTrackingState => ChangeTrackingState.AllDocumentsFinalState;

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        internal string ResetDocsInitialChangeTrackingState => ChangeTrackingState.ResetDocumentsInitialState ;

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        internal string ResetDocsFinalChangeTrackingState => ChangeTrackingState.ResetDocumentsFinalState ;

        /// <summary>
        /// Change tracking state for an indexer's execution.
        /// </summary>
        public IndexerChangeTrackingState ChangeTrackingState { get; }

        /// <summary> The list of datasource document ids that have been reset. The datasource document id is the unique identifier for the data in the datasource. The indexer will prioritize selectively re-ingesting these ids. </summary>
        [CodeGenMember("ResetDatasourceDocumentIds")]
        public IReadOnlyList<string> ResetDataSourceDocumentIds { get; }

        /// <summary> Initializes a new instance of IndexerState. </summary>
        /// <param name="mode"> The mode the indexer is running in. </param>
        /// <param name="allDocumentsInitialChangeTrackingState"> Change tracking state used when indexing starts on all documents in the datasource. </param>
        /// <param name="allDocumentsFinalChangeTrackingState"> Change tracking state value when indexing finishes on all documents in the datasource. </param>
        /// <param name="resetDocumentsInitialChangeTrackingState"> Change tracking state used when indexing starts on select, reset documents in the datasource. </param>
        /// <param name="resetDocumentsFinalChangeTrackingState"> Change tracking state value when indexing finishes on select, reset documents in the datasource. </param>
        /// <param name="resetDocumentKeys"> The list of document keys that have been reset. The document key is the document&apos;s unique identifier for the data in the search index. The indexer will prioritize selectively re-ingesting these keys. </param>
        /// <param name="resetDataSourceDocumentIds"> The list of datasource document ids that have been reset. The datasource document id is the unique identifier for the data in the datasource. The indexer will prioritize selectively re-ingesting these ids. </param>
        internal IndexerState(IndexingMode? mode, string allDocumentsInitialChangeTrackingState, string allDocumentsFinalChangeTrackingState, string resetDocumentsInitialChangeTrackingState, string resetDocumentsFinalChangeTrackingState, IReadOnlyList<string> resetDocumentKeys, IReadOnlyList<string> resetDataSourceDocumentIds)
        {
            Mode = mode;
            ResetDocumentKeys = resetDocumentKeys;
            ResetDataSourceDocumentIds = resetDataSourceDocumentIds;

            ChangeTrackingState = new IndexerChangeTrackingState(allDocumentsInitialChangeTrackingState, allDocumentsFinalChangeTrackingState, resetDocumentsInitialChangeTrackingState, resetDocumentsFinalChangeTrackingState);
        }
    }
}
