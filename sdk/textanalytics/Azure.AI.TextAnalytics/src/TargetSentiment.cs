// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Contains the related assessments, predicted sentiment,
    /// confidence scores and other information about a target of a product.
    /// A Target of a product/service is a key component of that product/service.
    /// <para>For example in "The food at Hotel Foo is good", "food" is a target of
    /// "Hotel Foo".</para>
    /// </summary>
    public readonly struct TargetSentiment
    {
        private const double _neutralValue = 0d;

        internal TargetSentiment(TextSentiment sentiment, string text, double positiveScore, double negativeScore, int offset, int length)
        {
            Sentiment = sentiment;
            Text = text;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, _neutralValue, negativeScore);
            Offset = offset;
            Length = length;
        }

        internal TargetSentiment(SentenceTarget sentenceTarget)
        {
            _ = sentenceTarget ?? throw new ArgumentNullException(nameof(sentenceTarget));

            Text = sentenceTarget.Text;
            ConfidenceScores = new SentimentConfidenceScores(sentenceTarget.ConfidenceScores.Positive, _neutralValue, sentenceTarget.ConfidenceScores.Negative);
            Sentiment = (TextSentiment)Enum.Parse(typeof(TextSentiment), sentenceTarget.Sentiment.ToString(), ignoreCase: true);
            Offset = sentenceTarget.Offset;
            Length = sentenceTarget.Length;
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed target.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the target text.
        /// <para>A target of a product/service is a key component of that product/service.</para>
        /// <para>For example in "The food at Hotel Foo is good", "food" is a target of
        /// "Hotel Foo".</para>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for the target for 'positive' and 'negative' labels. Its score
        /// for 'neutral' will always be 0.
        /// Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }

        /// <summary>
        /// Gets the starting position for the target text.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the target text.
        /// </summary>
        public int Length { get; }
    }
}
