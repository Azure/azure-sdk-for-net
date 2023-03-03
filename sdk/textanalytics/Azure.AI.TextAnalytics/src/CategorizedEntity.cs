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
        internal CategorizedEntity(EntityWithResolution entity)
            : this(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length, entity.Resolutions)
        {
        }

        internal CategorizedEntity(string text, string category, string subcategory, double confidenceScore, int offset, int length, IList<BaseResolution> resolutions)
        {
            // We shipped TA 5.0.0 Category == string.Empty if the service returned a null value for Category.
            // Because we don't want to introduce a breaking change, we are transforming that null to string.Empty
            Category = category ?? string.Empty;
            Text = text;
            SubCategory = subcategory;
            ConfidenceScore = confidenceScore;
            Offset = offset;
            Length = length;
            Resolutions = (resolutions is not null)
                ? new ReadOnlyCollection<BaseResolution>(resolutions)
                : new List<BaseResolution>();
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

        /// <summary>
        /// The collection of entity resolutions. Please note <see cref="BaseResolution"/> is the base class. According
        /// to the scenario, a derived class of the base class might need to be assigned here, or this property needs
        /// to be casted to one of the possible derived classes. The available derived classes include
        /// <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="CurrencyResolution"/>,
        /// <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>,
        /// <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>,
        /// <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>,
        /// <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>. To learn more, see
        /// <see href=" https://aka.ms/azsdk/language/ner-resolutions"/>
        /// </summary>
        public IReadOnlyCollection<BaseResolution> Resolutions { get; }
    }
}
