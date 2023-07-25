// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase that was recognized as an entity and categorized accordingly by the service's named entity
    /// recognition model and taxonomy. For the list of supported categories and subcategories, see
    /// <see href="https://learn.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories"/>.
    /// </summary>
    public readonly struct CategorizedEntity
    {
        internal CategorizedEntity(Entity entity)
            : this(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length)
        {
        }

        internal CategorizedEntity(string text, string category, string subcategory, double confidenceScore, int offset, int length)
        {
            // We shipped TA 5.0.0 Category == string.Empty if the service returned a null value for Category.
            // Because we don't want to introduce a breaking change, we are transforming that null to string.Empty
            Category = category ?? string.Empty;
            Text = text;
            SubCategory = subcategory;
            ConfidenceScore = confidenceScore;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// The text corresponding to the recognized entity, as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The category of the entity as recognized by the service's named entity recognition model. For the list of
        /// supported categories, see
        /// <see href="https://learn.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories"/>.
        /// </summary>
        public EntityCategory Category { get; }

        /// <summary>
        /// The subcategory of the entity (if applicable) as recognized by the service's named entity recognition
        /// model. For the list of supported categories and subcategories, see
        /// <see href="https://learn.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories"/>.
        /// </summary>
        public string SubCategory { get; }

        /// <summary>
        /// The score between 0.0 and 1.0 indicating the confidence that the recognized entity accurately corresponds
        /// to the text substring.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// The starting position of the matching text in the input document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// The length of the matching text in the input document.
        /// </summary>
        public int Length { get; }
    }
}
