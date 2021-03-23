// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of statistics describing an individual input document.
    /// This information is provided on the result collection returned by an
    /// operation when the caller passes in a <see cref="TextAnalyticsRequestOptions"/>
    /// with IncludeStatistics set to true.
    /// </summary>
    [CodeGenModel("DocumentStatistics")]
    public readonly partial struct TextDocumentStatistics
    {
        internal TextDocumentStatistics(int characterCount, int transactionCount)
        {
            CharacterCount = characterCount;
            TransactionCount = transactionCount;
        }

        /// <summary>
        /// Gets the number of characters (in Unicode graphemes) the corresponding document contains.
        /// </summary>
        [CodeGenMember("CharactersCount")]
        public int CharacterCount { get; }

        /// <summary>
        /// Gets the number of transactions used by the service to analyze the
        /// input document.
        /// </summary>
        [CodeGenMember("TransactionsCount")]
        public int TransactionCount { get; }
    }
}
