// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified as a Personally Identifiable Information
    /// that can be categorized as known type in a given taxonomy.
    /// The set of categories recognized by the Language service is described at
    /// <see href="https://aka.ms/azsdk/language/pii"/>.
    /// </summary>
    public readonly struct PiiEntity
    {
        internal PiiEntity(Entity entity)
            : this(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length)
        {
        }

        internal PiiEntity(string text, string category, string subcategory, double confidenceScore, int offset, int length)
        {
            Text = text;
            Category = category;
            SubCategory = subcategory;
            ConfidenceScore = confidenceScore;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the PII entity category inferred by the Text Analytics service's
        /// named entity recognition model, such as Financial Account
        /// Identification/Social Security Number/Phone Number, etc.
        /// The list of available categories is described at
        /// <see href="https://aka.ms/azsdk/language/pii"/>.
        /// </summary>
        public PiiEntityCategory Category { get; }

        /// <summary>
        /// Gets the subcategory of the entity inferred by the Language service's
        /// named entity recognition model.  This property may not have a value if
        /// a subcategory doesn't exist for this entity.  The list of available categories and
        /// subcategories is described at <see href="https://aka.ms/azsdk/language/pii"/>.
        /// </summary>
        public string SubCategory { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// text substring matches this inferred entity.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// Gets the starting position for the matching text in the input document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the matching text in the input document.
        /// </summary>
        public int Length { get; }
    }
}
