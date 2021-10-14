// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Represents the change tracking state during an indexer's execution. </summary>
    public class IndexerChangeTrackingState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexerChangeTrackingState"/> class.
        /// </summary>
        /// <param name="allDocumentsInitialChangeTrackingState">Change tracking state used when indexing starts on all documents in the datasource.</param>
        /// <param name="allDocumentsFinalChangeTrackingState">Change tracking state value when indexing finishes on all documents in the datasource.</param>
        /// <param name="resetDocumentsInitialChangeTrackingState">Change tracking state used when indexing starts on select, reset documents in the datasource.</param>
        /// <param name="resetDocumentsFinalChangeTrackingState">Change tracking state value when indexing finishes on select, reset documents in the datasource.</param>
        internal IndexerChangeTrackingState(string allDocumentsInitialChangeTrackingState, string allDocumentsFinalChangeTrackingState, string resetDocumentsInitialChangeTrackingState, string resetDocumentsFinalChangeTrackingState)
        {
            AllDocumentsInitialChangeTrackingState = allDocumentsInitialChangeTrackingState;
            AllDocumentsFinalChangeTrackingState = allDocumentsFinalChangeTrackingState;
            ResetDocumentsInitialChangeTrackingState = resetDocumentsInitialChangeTrackingState;
            ResetDocumentsFinalChangeTrackingState = resetDocumentsFinalChangeTrackingState;
        }

        /// <summary> Change tracking state used when indexing starts on all documents in the datasource. </summary>
        public string AllDocumentsInitialChangeTrackingState { get; }

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        public string AllDocumentsFinalChangeTrackingState { get; }

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        public string ResetDocumentsInitialChangeTrackingState  { get; }

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        public string ResetDocumentsFinalChangeTrackingState  { get; }
    }
}
