// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct DocumentStatistics
    {
        internal DocumentStatistics(int characterCount, int transactionCount)
        {
            CharacterCount = characterCount;
            TransactionCount = transactionCount;
        }

        /// <summary>
        /// Gets number of text elements recognized in the document.
        /// </summary>
        public int CharacterCount { get; }

        /// <summary>
        /// Gets number of transactions for the document.
        /// </summary>
        public int TransactionCount { get; }
    }
}
