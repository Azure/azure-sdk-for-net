﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment for a given span of text.
    /// For more information regarding text sentiment, see
    /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis"/>.
    /// </summary>
    public readonly struct SentenceSentiment
    {
        internal SentenceSentiment(SentimentLabel sentiment, double positiveScore, double neutralScore, double negativeScore, int offset, int length)
        {
            Sentiment = sentiment;
            ConfidenceScores = new SentimentConfidenceScorePerLabel(positiveScore, neutralScore, negativeScore);
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed input document
        /// or substring.
        /// </summary>
        public SentimentLabel Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for each sentiment label. Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScorePerLabel ConfidenceScores { get; }

        /// <summary>
        /// Gets the start position for the matching text in the input document.
        /// The offset unit is unicode character count.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the matching text in the input document.
        /// The length unit is unicode character count.
        /// </summary>
        public int Length { get; }
    }
}
