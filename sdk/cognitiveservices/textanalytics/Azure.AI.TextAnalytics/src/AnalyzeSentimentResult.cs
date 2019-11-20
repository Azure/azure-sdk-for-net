// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class AnalyzeSentimentResult : TextAnalysisResult
    {
        internal AnalyzeSentimentResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal AnalyzeSentimentResult(string id, string errorMessage)
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
