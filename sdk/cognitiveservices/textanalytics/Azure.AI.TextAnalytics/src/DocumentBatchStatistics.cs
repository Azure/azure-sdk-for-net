// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct DocumentBatchStatistics
    {
        /// <summary>
        /// Gets number of documents submitted in the request.
        /// </summary>
        public int DocumentCount { get; internal set; }

        /// <summary>
        /// Gets number of valid documents. This excludes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int ValidDocumentCount { get; internal set; }

        /// <summary>
        /// Gets number of invalid documents. This includes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int InvalidDocumentCount { get; internal set; }

        /// <summary>
        /// Gets number of transactions for the request.
        /// </summary>
        public long TransactionCount { get; internal set; }
    }
}
