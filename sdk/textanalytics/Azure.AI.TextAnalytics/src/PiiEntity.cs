// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified as a Personally Identifiable Information
    /// that can be categorized as known type in a given taxonomy.
    /// The set of categories recognized by the Text Analytics service is described at
    /// <a href="https://aka.ms/tanerpii"/>.
    /// </summary>
    public readonly struct PiiEntity
    {
        internal PiiEntity(Entity entity)
        {
            Category = entity.Category;
            Text = entity.Text;
            SubCategory = entity.Subcategory;
            ConfidenceScore = entity.ConfidenceScore;
            Offset = entity.Offset;
        }

        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the entity category inferred by the Text Analytics service's
        /// named entity recognition model, such as Financial Account
        /// Identification/Social Security Number/Phone Number, etc.
        /// The list of available categories is described at
        /// <a href="https://aka.ms/tanerpii"/>.
        /// </summary>
        public EntityCategory Category { get; }

        /// <summary>
        /// Gets the sub category of the entity inferred by the Text Analytics service's
        /// named entity recognition model.  This property may not have a value if
        /// a sub category doesn't exist for this entity.  The list of available categories and
        /// subcategories is described at <a href="https://aka.ms/tanerpii"/>.
        /// </summary>
        public string SubCategory { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// text substring matches this inferred entity.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// Gets the starting position (in UTF-16 code units) for the matching text in the input document.
        /// </summary>
        public int Offset { get; }
    }
}
