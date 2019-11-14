// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct DocumentStatistics
    {
        /// <summary>
        /// Gets number of text elements recognized in the document.
        /// </summary>
        public int CharacterCount { get; internal set; }

        /// <summary>
        /// Gets number of transactions for the document.
        /// </summary>
        public int TransactionCount { get; internal set; }
    }
}
