// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Represents the change tracking state during an indexer's execution. </summary>
    public class IndexerStateHighWaterMark
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexerStateHighWaterMark"/> class.
        /// </summary>
        /// <param name="allDocumentsInitialHighWaterMark">Change tracking state used when indexing starts on all documents in the datasource.</param>
        /// <param name="allDocumentsFinalHighWaterMark">Change tracking state value when indexing finishes on all documents in the datasource.</param>
        /// <param name="resetDocumentsInitialHighWaterMark">Change tracking state used when indexing starts on select, reset documents in the datasource.</param>
        /// <param name="resetDocumentsFinalHighWaterMark">Change tracking state value when indexing finishes on select, reset documents in the datasource.</param>
        internal IndexerStateHighWaterMark(string allDocumentsInitialHighWaterMark, string allDocumentsFinalHighWaterMark, string resetDocumentsInitialHighWaterMark, string resetDocumentsFinalHighWaterMark)
        {
            AllDocumentsInitialHighWaterMark = allDocumentsInitialHighWaterMark;
            AllDocumentsFinalHighWaterMark = allDocumentsFinalHighWaterMark;
            ResetDocumentsInitialHighWaterMark= resetDocumentsInitialHighWaterMark;
            ResetDocumentsFinalHighWaterMark= resetDocumentsFinalHighWaterMark;
        }

        /// <summary> Change tracking state used when indexing starts on all documents in the datasource. </summary>
        public string AllDocumentsInitialHighWaterMark { get; }

        /// <summary> Change tracking state value when indexing finishes on all documents in the datasource. </summary>
        public string AllDocumentsFinalHighWaterMark { get; }

        /// <summary> Change tracking state used when indexing starts on select, reset documents in the datasource. </summary>
        public string ResetDocumentsInitialHighWaterMark { get; }

        /// <summary> Change tracking state value when indexing finishes on select, reset documents in the datasource. </summary>
        public string ResetDocumentsFinalHighWaterMark { get; }
    }
}
