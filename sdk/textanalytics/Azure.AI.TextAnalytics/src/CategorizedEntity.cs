// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified as an entity that can be categorized
    /// as known type in a given taxonomy.  The set of categories recognized by the
    /// Text Analytics service is described at
    /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
    /// </summary>
    public readonly struct CategorizedEntity
    {
        internal CategorizedEntity(string text, string category, string subCategory, double score)
        {
            Text = text;
            Category = category;
            SubCategory = subCategory;
            ConfidenceScore = score;
        }

        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the entity category inferred by the Text Analytics service's
        /// named entity recognition model.  The list of available categories is
        /// described at
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// </summary>
        public EntityCategory Category { get; }

        /// <summary>
        /// Gets the sub category of the entity inferred by the Text Analytics service's
        /// named entity recognition model.  This property may not have a value if
        /// a sub category doesn't exist for this entity.  The list of available categories and
        /// subcategories is described at
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// </summary>
        public string SubCategory { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// text substring matches this inferred entity.
        /// </summary>
        public double ConfidenceScore { get; }
    }
}
