// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the analyze sentiment operation on a single document,
    /// containing the predicted sentiment for each sentence as well as for
    /// the full document.
    /// </summary>
    public class AnalyzeSentimentResult : TextAnalyticsResult
    {
        internal AnalyzeSentimentResult(string id, TextDocumentStatistics statistics, TextSentiment documentSentiment, IList<TextSentiment> sentenceSentiments)
            : base(id, statistics)
        {
            DocumentSentiment = documentSentiment;
            SentenceSentiments = new ReadOnlyCollection<TextSentiment>(sentenceSentiments);
        }

        internal AnalyzeSentimentResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            SentenceSentiments = Array.Empty<TextSentiment>();
        }

        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// Gets the predicted sentiment for the full document.
        /// </summary>
        public TextSentiment DocumentSentiment { get; }

        /// <summary>
        /// Gets the predicted sentiment for each sentence in the corresponding
        /// document.
        /// </summary>
        public IReadOnlyCollection<TextSentiment> SentenceSentiments { get; }
    }
}
