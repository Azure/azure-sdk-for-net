// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Contains the related opinions, predicted sentiment,
    /// confidence scores and other information about an aspect of a product.
    /// An aspect of a product/service is a key component of that product/service.
    /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
    /// "Hotel Foo".</para>
    /// </summary>
    public readonly struct AspectSentiment
    {
        private const double _neutralValue = 0d;

        internal AspectSentiment(TextSentiment sentiment, string text, double positiveScore, double negativeScore, int offset)
        {
            Sentiment = sentiment;
            Text = text;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, _neutralValue, negativeScore);
            Offset = offset;
        }

        internal AspectSentiment(SentenceAspect sentenceAspect)
        {
            _ = sentenceAspect ?? throw new ArgumentNullException(nameof(sentenceAspect));

            Text = sentenceAspect.Text;
            ConfidenceScores = new SentimentConfidenceScores(sentenceAspect.ConfidenceScores.Positive, _neutralValue, sentenceAspect.ConfidenceScores.Negative);
            Sentiment = (TextSentiment)Enum.Parse(typeof(TextSentiment), sentenceAspect.Sentiment, ignoreCase: true);
            Offset = sentenceAspect.Offset;
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed aspect.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the aspect text.
        /// <para>An aspect of a product/service is a key component of that product/service.</para>
        /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
        /// "Hotel Foo".</para>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for the aspect for 'positive' and 'negative' labels. Its score
        /// for 'neutral' will always be 0.
        /// Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }

        /// <summary>
        /// Gets the starting position (in UTF-16 code units) for the aspect text.
        /// </summary>
        public int Offset { get; }
    }
}
