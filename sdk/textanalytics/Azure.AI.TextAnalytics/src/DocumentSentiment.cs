// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Overall predicted sentiment and confidence scores for the document.
    /// It also includes per-sentence sentiment prediction.
    /// </summary>
    public class DocumentSentiment
    {
        internal DocumentSentiment(SentimentLabel sentiment, double positiveScore, double neutralScore, double negativeScore, List<SentenceSentiment> sentenceSentiments)
        {
            Sentiment = sentiment;
            SentimentScores = new SentimentScorePerLabel(positiveScore, neutralScore, negativeScore);
            Sentences = new ReadOnlyCollection<SentenceSentiment>(sentenceSentiments);
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed input document
        /// or substring.
        /// </summary>
        public SentimentLabel Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score between 0 and 1,
        /// for each sentiment label.
        /// </summary>
        public SentimentScorePerLabel SentimentScores { get; }

        /// <summary>
        /// Gets the predicted sentiment for each sentence in the corresponding
        /// document.
        /// </summary>
        public IReadOnlyCollection<SentenceSentiment> Sentences { get; }
    }
}
