// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal SentenceSentiment(TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, int offset, int length)
        {
            Sentiment = sentiment;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, neutralScore, negativeScore);
            GraphemeOffset = offset;
            GraphemeLength = length;
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed sentence.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for each sentiment. Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }

        /// <summary>
        /// Gets the starting position (in Unicode graphemes) for the matching text in the sentence.
        /// </summary>
        public int GraphemeOffset { get; }

        /// <summary>
        /// Gets the length (in Unicode graphemes) of the matching text in the sentence.
        /// </summary>
        public int GraphemeLength { get; }
    }
}
