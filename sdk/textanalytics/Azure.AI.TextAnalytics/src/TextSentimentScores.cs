// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The sentiment confidence scores, by sentiment class label.
    /// </summary>
    public class TextSentimentScores
    {
        internal TextSentimentScores(double positive, double neutral, double negative)
        {
            PositiveScore = positive;
            NeutralScore = neutral;
            NegativeScore = negative;
        }

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
    }
}
