// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextSentimentResult : TextAnalysisResult
    {
        internal TextSentimentResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal TextSentimentResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// </summary>
        public TextSentiment DocumentSentiment { get; }

        /// <summary>
        /// </summary>
        public Collection<TextSentiment> SentenceSentiments { get; }
    }
}
