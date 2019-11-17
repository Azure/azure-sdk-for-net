// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class SentimentResult : DocumentResult<Sentiment>
    {
        internal SentimentResult(string id, DocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal SentimentResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// </summary>
        public Sentiment DocumentSentiment { get; set; }

        /// <summary>
        /// </summary>
        public DocumentResult<Sentiment> SentenceSentiments => this;
    }
}
