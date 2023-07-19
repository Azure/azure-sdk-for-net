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
        /// <param name="allDocumentsInitialState">Change tracking state used when indexing starts on all documents in the datasource.</param>
        /// <param name="allDocumentsFinalState">Change tracking state value when indexing finishes on all documents in the datasource.</param>
        /// <param name="resetDocumentsInitialState">Change tracking state used when indexing starts on select, reset documents in the datasource.</param>
        /// <param name="resetDocumentsFinalState">Change tracking state value when indexing finishes on select, reset documents in the datasource.</param>
        internal IndexerChangeTrackingState(string allDocumentsInitialState, string allDocumentsFinalState, string resetDocumentsInitialState, string resetDocumentsFinalState)
        {
            AllDocumentsInitialState = allDocumentsInitialState;
            AllDocumentsFinalState = allDocumentsFinalState;
            ResetDocumentsInitialState = resetDocumentsInitialState;
            ResetDocumentsFinalState = resetDocumentsFinalState;
        }

        /// <summary> Change tracking state used when indexing starts on all documents in the datasource. </summary>
        public string AllDocumentsInitialState { get; }

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        public string AllDocumentsFinalState { get; }

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        public string ResetDocumentsInitialState  { get; }

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        public string ResetDocumentsFinalState  { get; }
    }
}
