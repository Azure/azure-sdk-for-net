// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Details regarding the specific substring in the document matching
    /// the linked entity, or well-known item, that the Text Analytics model
    /// identified.
    /// </summary>
    public readonly struct LinkedEntityMatch
    {
        internal LinkedEntityMatch(string text, double score)
        {
            Text = text;
            ConfidenceScore = score;
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
    }
}
