// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Details regarding the specific substring in the document matching
    /// the linked entity, or well-known item, that the Text Analytics model
    /// identified.
    /// </summary>
    [CodeGenModel("Match")]
    public readonly partial struct LinkedEntityMatch
    {
        internal LinkedEntityMatch(double confidenceScore, string text, int offset, int length)
        {
            // We shipped TA 5.0.0 Text == string.Empty if the service returned a null value for Text.
            // Because we don't want to introduce a breaking change, we are transforming that null to string.Empty
            Text = text ?? string.Empty;
            ConfidenceScore = confidenceScore;
            Offset = offset;
            Length = length;
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
        /// Gets the starting position for the matching text in the document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the matching text in the sentence.
        /// </summary>
        public int Length { get; }
    }
}
