// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct RequestStatistics
    {
        /// <summary>
        /// Gets or sets number of documents submitted in the request.
        /// </summary>
        public int DocumentsCount { get; internal set; }

        /// <summary>
        /// Gets or sets number of valid documents. This excludes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int ValidDocumentCount { get; internal set; }

        /// <summary>
        /// Gets or sets number of invalid documents. This includes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int ErroneousDocumentCount { get; internal set; }

        /// <summary>
        /// Gets or sets number of transactions for the request.
        /// </summary>
        public long TransactionCount { get; internal set; }
    }
}
