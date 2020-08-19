// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment for a given span of text.
    /// For more information regarding text sentiment, see
    /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis"/>.
    /// </summary>
    public readonly struct SentenceSentiment
    {
        internal SentenceSentiment(TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore)
        {
            Sentiment = sentiment;
            Text = text;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, neutralScore, negativeScore);
        }

        internal SentenceSentiment(SentenceSentimentInternal sentenceSentiment)
        {
            // We shipped TA 5.0.0 Text == string.Empty if the service returned a null value for Text.
            // Because we don't want to introduce a breaking change, we are transforming that null to string.Empty
            Text = sentenceSentiment.Text ?? string.Empty;

            ConfidenceScores = sentenceSentiment.ConfidenceScores;
            Sentiment = (TextSentiment)Enum.Parse(typeof(TextSentiment), sentenceSentiment.Sentiment, ignoreCase: true);
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed sentence.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the sentence text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for each sentiment. Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }
    }
}
