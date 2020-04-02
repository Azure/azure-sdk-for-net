// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of statistics describing an individual input document.
    /// This information is provided on the result collection returned by an
    /// operation when the caller passes in a <see cref="TextAnalyticsRequestOptions"/>
    /// with IncludeStatistics set to true.
    /// </summary>
    public readonly struct TextDocumentStatistics
    {
        internal TextDocumentStatistics(int grahemeCount, int transactionCount)
        {
            GraphemeCount = grahemeCount;
            TransactionCount = transactionCount;
        }

        /// <summary>
        /// Gets the number of characters (in Unicode graphemes) the corresponding document contains.
        /// </summary>
        public int GraphemeCount { get; }

        /// <summary>
        /// Gets the number of transactions used by the service to analyze the
        /// input document.
        /// </summary>
        public int TransactionCount { get; }
    }
}
