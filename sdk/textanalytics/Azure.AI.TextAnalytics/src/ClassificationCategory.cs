// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A classification of an input document extracted by the Single Category Classification
    /// operation. The service attributes a confidence score to the predicted category
    /// for measuring how confident the model is in the returned prediction.
    /// </summary>
    public readonly struct ClassificationCategory
    {
        internal ClassificationCategory(SingleClassificationDocument classification)
        {
            Category = classification.Classification.Category;
            ConfidenceScore = classification.Classification.ConfidenceScore;
        }

        internal ClassificationCategory(ClassificationResult classification)
        {
            Category = classification.Category;
            ConfidenceScore = classification.ConfidenceScore;
        }

        /// <summary>
        /// Gets the predicted category for the respective document. The possible values
        /// of the category string depends on the custom categories set in the Text Analytics
        /// service for the targetted project.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets the confidence score of the predictive category. This is a value
        /// between 0 and 1 that represents the model's confidence in the predicted
        /// class, which can be used as an indicator of the probability of correctness.
        /// </summary>
        public double ConfidenceScore { get; }
    }
}
