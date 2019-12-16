// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment for a given span of text.  This may correspond
    /// to a full text document input or a substring such as a sentence of that
    /// input.  For more information regarding text sentiment, see
    /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis.
    /// </summary>
    public readonly struct TextSentiment
    {
        internal TextSentiment(TextSentimentClass sentimentClass, double positiveScore, double neutralScore, double negativeScore, int offset, int length)
        {
            SentimentClass = sentimentClass;
            PositiveScore = positiveScore;
            NeutralScore = neutralScore;
            NegativeScore = negativeScore;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed input document
        /// or substring.
        /// </summary>
        public TextSentimentClass SentimentClass { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is positive.
        /// </summary>
        public double PositiveScore { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is neutral.
        /// </summary>
        public double NeutralScore { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is negative.
        /// </summary>
        public double NegativeScore { get; }

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
