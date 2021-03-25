// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Contains the predicted sentiment, confidence scores, and other information related to Opinion Mining analysis.
    /// <para>For example, in the sentence "The food is good", the assessment of the
    /// target 'food' is 'good'.</para>
    /// </summary>
    public readonly struct AssessmentSentiment
    {
        private const double _neutralValue = 0d;

        internal AssessmentSentiment(TextSentiment sentiment, double positiveScore, double negativeScore, string text, bool isNegated, int offset, int length)
        {
            Sentiment = sentiment;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, _neutralValue, negativeScore);
            Text = text;
            IsNegated = isNegated;
            Offset = offset;
            Length = length;
        }

        internal AssessmentSentiment(SentenceAssessment assessment)
        {
            _ = assessment ?? throw new ArgumentNullException(nameof(assessment));

            Text = assessment.Text;
            ConfidenceScores = new SentimentConfidenceScores(assessment.ConfidenceScores.Positive, _neutralValue, assessment.ConfidenceScores.Negative);
            Sentiment = (TextSentiment)Enum.Parse(typeof(TextSentiment), assessment.Sentiment, ignoreCase: true);
            IsNegated = assessment.IsNegated;
            Offset = assessment.Offset;
            Length = assessment.Length;
        }

        /// <summary>
        /// Gets the predicted Sentiment for the assessment taking into account the
        /// value of <see cref="IsNegated"/>. Possible values
        /// include 'positive', 'mixed', and 'negative'.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for the assessment for 'positive' and 'negative' labels. Its score
        /// for 'neutral' will always be 0.
        /// Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }

        /// <summary>
        /// Gets the assessment text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Whether the assessment is negated.
        /// <para>For example, in "The food is not good",
        /// the assessment "good" is negated.</para>
        /// </summary>
        public bool IsNegated { get; }

        /// <summary>
        /// Gets the starting position for the assessment text.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the assessment text.
        /// </summary>
        public int Length { get; }
    }
}
