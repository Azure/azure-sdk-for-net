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
    public partial class DocumentHealthcareEntities
    {
        /// <summary> Initializes a new instance of DocumentHealthcareEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Healthcare entities. </param>
        /// <param name="relations"> Healthcare entity relations. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="entities"/>, <paramref name="relations"/>, or <paramref name="warnings"/> is null. </exception>
        internal DocumentHealthcareEntities(string id, IEnumerable<HealthcareEntity> entities, IEnumerable<HealthcareRelationInternal> relations, IEnumerable<TextAnalyticsWarningInternal> warnings)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            if (relations == null)
            {
                throw new ArgumentNullException(nameof(relations));
            }
            if (warnings == null)
            {
                throw new ArgumentNullException(nameof(warnings));
            }

            Id = id;
            Entities = entities.ToList();
            Relations = ResolveHealthcareRelations(entities, relations);
            Warnings = Transforms.ConvertToWarnings(warnings.ToList());
        }

        internal DocumentHealthcareEntities(DocumentHealthcareEntitiesInternal documentHealthcareEntities)
        {
            Entities = documentHealthcareEntities.Entities;
            Relations = ResolveHealthcareRelations(documentHealthcareEntities.Entities, documentHealthcareEntities.Relations);
            Id = documentHealthcareEntities.Id;
            Warnings = documentHealthcareEntities.Warnings != null ? Transforms.ConvertToWarnings(documentHealthcareEntities.Warnings) : null;
        }

        /// <summary> Initializes a new instance of DocumentHealthcareEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Healthcare entities. </param>
        /// <param name="relations"> Healthcare entity relations. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentHealthcareEntities(string id, IReadOnlyList<HealthcareEntity> entities, IReadOnlyList<HealthcareRelationInternal> relations, IReadOnlyList<TextAnalyticsWarningInternal> warnings, TextDocumentStatistics? statistics)
        {
            Id = id;
            Entities = entities;
            Relations = ResolveHealthcareRelations(entities, relations);
            Warnings = Transforms.ConvertToWarnings(warnings);
            Statistics = statistics;
        }

        internal static IReadOnlyList<HealthcareRelation> ResolveHealthcareRelations(IEnumerable<HealthcareEntity> entities, IEnumerable<HealthcareRelationInternal> relations)
        {
            List<HealthcareRelation> list = new List<HealthcareRelation>();
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
        public IReadOnlyList<HealthcareRelation> Relations { get; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public TextDocumentStatistics? Statistics { get; }

        private static Regex _healthcareEntityRegex = new Regex(@"\#/results/documents\/(?<documentIndex>\d*)\/entities\/(?<entityIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        internal static HealthcareEntity ResolveHealthcareEntity(IEnumerable<HealthcareEntity> entities, string reference)
        {
            var healthcareEntityMatch = _healthcareEntityRegex.Match(reference);
            if (healthcareEntityMatch.Success)
            {
                int entityIndex = int.Parse(healthcareEntityMatch.Groups["entityIndex"].Value, CultureInfo.InvariantCulture);
                //int entityIndex = int.Parse(healthcareEntityMatch.Groups[2].Value, CultureInfo.InvariantCulture);

                if (entityIndex < entities.Count())
                {
                    var entity = entities.ElementAt(entityIndex);
                    return new HealthcareEntity(entity.Text, entity.Category,
                        entity.Offset, entity.Length, entity.ConfidenceScore,
                        entity.IsNegated);
                }
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }

    }
}
