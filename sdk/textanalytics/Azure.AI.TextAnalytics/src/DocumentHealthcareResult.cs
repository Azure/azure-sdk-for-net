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
    /// DocumentHealthcareEntities.
    /// </summary>
    public partial class DocumentHealthcareResult
    {
        internal DocumentHealthcareResult(DocumentHealthcareEntitiesInternal documentHealthcareEntities)
        {
            Entities = documentHealthcareEntities.Entities;
            Relations = ResolveHealthcareRelations(documentHealthcareEntities.Entities, documentHealthcareEntities.Relations);
            Id = documentHealthcareEntities.Id;
            Warnings = Transforms.ConvertToWarnings(documentHealthcareEntities.Warnings);
            Statistics = documentHealthcareEntities.Statistics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentHealthcareResult"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="textAnalyticsError"></param>
        internal DocumentHealthcareResult(string id, TextAnalyticsError textAnalyticsError)
        {
            Id = id;
            TextAnalyticsError = textAnalyticsError;
        }

        internal static IReadOnlyList<HealthcareRelation> ResolveHealthcareRelations(IEnumerable<HealthcareEntity> entities, IEnumerable<HealthcareRelationInternal> relations)
        {
            List<HealthcareRelation> list = new List<HealthcareRelation>();

            if (relations == null)
            {
                return list;
            }

            foreach (HealthcareRelationInternal relation in relations)
            {
                list.Add(new HealthcareRelation(relation.RelationType,
                    relation.Bidirectional,
                    ResolveHealthcareEntity(entities, relation.Source),
                    ResolveHealthcareEntity(entities, relation.Target)));
            }

            return list;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> Healthcare entities. </summary>
        public IReadOnlyList<HealthcareEntity> Entities { get; }
        /// <summary> Healthcare entity relations. </summary>
        public IReadOnlyList<HealthcareRelation> Relations { get; } = new List<HealthcareRelation>();
        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();
        /// <summary> if IncludeStatistics=true was specified in the request this field will contain information about the document payload. </summary>
        public TextDocumentStatistics? Statistics { get; }

        /// <summary> TextAnalyticsError. </summary>
        public TextAnalyticsError TextAnalyticsError { get; }

        private static Regex _healthcareEntityRegex = new Regex(@"\#/results/documents\/(?<documentIndex>\d*)\/entities\/(?<entityIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        internal static HealthcareEntity ResolveHealthcareEntity(IEnumerable<HealthcareEntity> entities, string reference)
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
    }
}
