// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A category that was used to classify a given document.
    /// </summary>
    public readonly struct ClassificationCategory
    {
        internal ClassificationCategory(ClassificationResult classification)
        {
            Category = classification.Category;
            ConfidenceScore = classification.ConfidenceScore;
        }

        /// <summary>
        /// The category that was used to classify the given document.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The score between 0.0 and 1.0 indicating the confidence that the category accurately corresponds to the
        /// given document.
        /// </summary>
        public double ConfidenceScore { get; }
    }
}
