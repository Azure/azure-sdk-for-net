// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A model which contains information about the detected healthcare entity.
    /// </summary>
    public class HealthcareEntity
    {
        internal HealthcareEntity(string text, HealthcareEntityCategory category, string subcategory, double confidenceScore, int offset, int length, IReadOnlyCollection<EntityDataSource> dataSources, HealthcareEntityAssertion assertion, string normalizedName)
        {
            Text = text;
            Category = category;
            SubCategory = subcategory;
            ConfidenceScore = confidenceScore;
            Offset = offset;
            Length = length;
            DataSources = dataSources;
            Assertion = assertion;
            NormalizedText = normalizedName;
        }

        internal HealthcareEntity(HealthcareEntityInternal entity)
        {
            Category = entity.Category;
            Text = entity.Text;
            SubCategory = entity.Subcategory;
            ConfidenceScore = entity.ConfidenceScore;
            Offset = entity.Offset;
            Length = entity.Length;
            DataSources = new List<EntityDataSource>(entity.Links);
            Assertion = entity.Assertion;
            NormalizedText = entity.Name;
        }
        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the entity category inferred by the Text Analytics for
        /// healthcare model.
        /// </summary>
        public HealthcareEntityCategory Category { get; }

        /// <summary>
        /// Gets the subcategory of the entity inferred by the Text Analytics for
        /// healthcare model. This property may not have a value if
        /// a subcategory doesn't exist for this entity.
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
        /// Gets the length for the matching entity in the input document.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Get the list of data sources for the entity.
        /// </summary>
        public IReadOnlyCollection<EntityDataSource> DataSources { get; }

        /// <summary>
        /// Gets the healthcare assertions for the entity.
        /// </summary>
        public HealthcareEntityAssertion Assertion { get; }

        /// <summary>
        /// Gets the normalized text for the entity.
        /// </summary>
        public string NormalizedText { get; }
    }
}
