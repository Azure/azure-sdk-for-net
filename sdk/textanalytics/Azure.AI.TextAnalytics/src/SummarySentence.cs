// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A sentence extracted from an input document by an extractive text summarization
    /// operation. The service attributes a rank score to it for measuring how relevant
    /// the sentence is to the input document.
    /// </summary>
    public readonly struct SummarySentence
    {
        internal SummarySentence(ExtractedSummarySentence sentence)
        {
            Text = sentence.Text;
            RankScore = sentence.RankScore;
            Offset = sentence.Offset;
            Length = sentence.Length;
        }

        /// <summary>
        /// The text of the sentence as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The rank score of the sentence, measuring how relevant the sentence is
        /// to the input document. The value is set between [0.0, 1.0], with higher
        /// values indicating a higher relevance.
        /// </summary>
        public double RankScore { get; }

        /// <summary>
        /// The starting position for the matching sentence in the input document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// The length of the matching sentence in the input document.
        /// </summary>
        public int Length { get; }
    }
}
