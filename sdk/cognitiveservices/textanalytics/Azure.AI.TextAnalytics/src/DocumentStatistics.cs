// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct DocumentStatistics
    {
        /// <summary>
        /// Gets or sets number of text elements recognized in the document.
        /// </summary>
        public int CharacterCount { get; internal set; }

        /// <summary>
        /// Gets or sets number of transactions for the document.
        /// </summary>
        public int TransactionCount { get; internal set; }
    }
}
