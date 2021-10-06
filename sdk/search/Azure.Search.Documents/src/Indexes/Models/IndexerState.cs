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
        [CodeGenMember("AllDocsInitialChangeTrackingState")]
        public string AllDocumentsInitialHighWaterMark { get; }

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        [CodeGenMember("AllDocsFinalChangeTrackingState")]
        public string AllDocumentsFinalHighWaterMark { get; }

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        [CodeGenMember("ResetDocsInitialChangeTrackingState")]
        public string ResetDocumentsInitialHighWaterMark { get; }

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        [CodeGenMember("ResetDocsFinalChangeTrackingState")]
        public string ResetDocumentsFinalHighWaterMark { get; }

        /// <summary> The list of datasource document ids that have been reset. The datasource document id is the unique identifier for the data in the datasource. The indexer will prioritize selectively re-ingesting these ids. </summary>
        [CodeGenMember("ResetDatasourceDocumentIds")]
        public IReadOnlyList<string> ResetDataSourceDocumentIds { get; }
    }
}
