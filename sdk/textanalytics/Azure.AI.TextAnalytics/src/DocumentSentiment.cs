// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Overall predicted sentiment and confidence scores for the document.
    /// It also includes per-sentence sentiment prediction.
    /// For more information regarding text sentiment, see
    /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis"/>.
    /// </summary>
    public class DocumentSentiment
    {
        internal DocumentSentiment(TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, List<SentenceSentiment> sentenceSentiments)
        {
            Sentiment = sentiment;
            ConfidenceScores = new SentimentConfidenceScore(positiveScore, neutralScore, negativeScore);
            Sentences = new ReadOnlyCollection<SentenceSentiment>(sentenceSentiments);
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed document.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for each sentiment. Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScore ConfidenceScores { get; }

        /// <summary>
        /// Gets the predicted sentiment for each sentence in the corresponding
        /// document.
        /// </summary>
        public IReadOnlyCollection<SentenceSentiment> Sentences { get; }
    }
}
