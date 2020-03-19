// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Details regarding the specific substring in the document matching
    /// the linked entity, or well-known item, that the text analytics model
    /// identified.
    /// </summary>
    public readonly struct LinkedEntityMatch
    {
        internal LinkedEntityMatch(string text, double score, int offset, int length)
        {
            Text = text;
            ConfidenceScore = score;
            GraphemeOffset = offset;
            GraphemeLength = length;
        }

        /// <summary>
        /// Gets the entity text as it appears in the document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that this
        /// substring matches the corresponding linked entity.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// Gets the starting position (in Unicode graphemes) for the matching text in the document.
        /// </summary>
        public int GraphemeOffset { get; }

        /// <summary>
        /// Gets the length (in Unicode graphemes) of the matching text in the document.
        /// </summary>
        public int GraphemeLength { get; }
    }
}
