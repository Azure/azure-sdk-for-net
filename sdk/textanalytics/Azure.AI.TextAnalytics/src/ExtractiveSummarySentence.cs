// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A sentence extracted from a given document as a result of performing extractive summarization on it. The
    /// sentence receives a rank score based on its relevance, as determined by the service.
    /// </summary>
    public readonly struct ExtractiveSummarySentence
    {
        internal ExtractiveSummarySentence(ExtractedSummarySentence sentence)
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
        /// The score between 0.0 and 1.0 indicating the relevance of the sentence to the input document, as determined
        /// by the service.
        /// </summary>
        public double RankScore { get; }

        /// <summary>
        /// The starting position of the sentence as it appears in the original document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// The length of the sentence as it appears in the original document.
        /// </summary>
        public int Length { get; }
    }
}
