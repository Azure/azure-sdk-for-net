// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// .
    /// </summary>
    public class HealthcareEntity
    {
        internal HealthcareEntity(HealthcareEntityInternal entity, IEnumerable<HealthcareEntityInternal> healthcareEntities = default, IEnumerable<HealthcareRelationInternal> healthcareRelations = default)
        {
            Category = entity.Category;
            Text = entity.Text;
            SubCategory = entity.Subcategory;
            ConfidenceScore = entity.ConfidenceScore;
            Offset = entity.Offset;
            DataSources = entity.Links;
            if (healthcareEntities != null && healthcareRelations != null)
            {
                RelatedEntities = ResolveRelatedEntities(entity, healthcareEntities, healthcareRelations);
            }
        }

        private static IReadOnlyDictionary<HealthcareEntity, HealthcareEntityRelationType> ResolveRelatedEntities(HealthcareEntityInternal entity,
            IEnumerable<HealthcareEntityInternal> healthcareEntities,
            IEnumerable<HealthcareRelationInternal> healthcareRelations)
        {
            Dictionary<HealthcareEntity, HealthcareEntityRelationType> dictionary = new Dictionary<HealthcareEntity, HealthcareEntityRelationType>();

            if (healthcareRelations == null)
            {
                return dictionary;
            }

            foreach (HealthcareRelationInternal relation in healthcareRelations)
            {
                int entityIndex = healthcareEntities.ToList().FindIndex(e => e.Text.Equals(entity.Text));

                if (IsEntitySource(relation, entityIndex))
                {
                    string targetRef = relation.Target;

                    HealthcareEntityInternal relatedEntity = ResolveHealthcareEntity(healthcareEntities, targetRef);

                    dictionary.Add(new HealthcareEntity(relatedEntity, healthcareEntities, healthcareRelations), relation.RelationType);
                }
            }

            return dictionary;
        }

        internal static HealthcareEntityInternal ResolveHealthcareEntity(IEnumerable<HealthcareEntityInternal> entities, string reference)
        {
            var healthcareEntityMatch = _healthcareEntityRegex.Match(reference);
            if (healthcareEntityMatch.Success)
            {
                int entityIndex = int.Parse(healthcareEntityMatch.Groups["entityIndex"].Value, CultureInfo.InvariantCulture);

                if (entityIndex < entities.Count())
                {
                    return entities.ElementAt(entityIndex);
                }
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }

        private static Regex _healthcareEntityRegex = new Regex(@"\#/results/documents\/(?<documentIndex>\d*)\/entities\/(?<entityIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        private static bool IsEntitySource(HealthcareRelationInternal healthcareRelation, int entityIndex)
        {
            string sourceRef = healthcareRelation.Source;

            var healthcareEntityMatch = _healthcareEntityRegex.Match(sourceRef);

            if (healthcareEntityMatch.Success)
            {
                int index = int.Parse(healthcareEntityMatch.Groups["entityIndex"].Value, CultureInfo.InvariantCulture);

                if (index == entityIndex)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the entity category inferred by the Text Analytics service's
        /// named entity recognition model.  The list of available categories is
        /// described at
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets the sub category of the entity inferred by the Text Analytics service's
        /// named entity recognition model.  This property may not have a value if
        /// a sub category doesn't exist for this entity.  The list of available categories and
        /// subcategories is described at
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
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

        /// <summary>
        /// .
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// .
        /// </summary>
        public IReadOnlyCollection<EntityDataSource> DataSources { get; }

        /// <summary>
        /// .
        /// </summary>
        public IReadOnlyDictionary<HealthcareEntity, HealthcareEntityRelationType> RelatedEntities { get; }
    }
}
