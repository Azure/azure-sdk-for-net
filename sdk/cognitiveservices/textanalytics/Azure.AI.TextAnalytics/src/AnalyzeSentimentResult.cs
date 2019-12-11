// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class AnalyzeSentimentResult : TextAnalysisResult
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
            SentenceSentiments = EmptyArray<TextSentiment>.Instance;
        }

        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// </summary>
        public TextSentiment DocumentSentiment { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<TextSentiment> SentenceSentiments { get; }
    }
}
