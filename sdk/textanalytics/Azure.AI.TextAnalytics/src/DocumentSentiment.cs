// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentSentiment
    {
        internal DocumentSentiment(TextSentimentClass sentiment, double positiveScore, double neutralScore, double negativeScore, List<TextSentiment> sentenceSentiments)
        {
            PredictedSentiment = sentiment;
            Scores = new TextSentimentScores(positiveScore, neutralScore, negativeScore);
            SentenceSentiments = new ReadOnlyCollection<TextSentiment>(sentenceSentiments);
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed input document
        /// or substring.
        /// </summary>
        public TextSentimentClass PredictedSentiment { get; }

        /// <summary>
        /// The confidence scores for the sentiment, for each sentiment class label, Positive, Neutrual, and Negative.
        /// </summary>
        public TextSentimentScores Scores { get; }

        /// <summary>
        /// Gets the predicted sentiment for each sentence in the corresponding
        /// document.
        /// </summary>
        public IReadOnlyCollection<TextSentiment> SentenceSentiments { get; }
    }
}
