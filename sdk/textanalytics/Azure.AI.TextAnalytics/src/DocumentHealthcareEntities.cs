// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Core;
using Microsoft.Extensions.Azure;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("DocumentHealthcareEntities")]
    internal partial class DocumentHealthcareEntities
    {
        /// <summary> Initializes a new instance of DocumentHealthcareEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Healthcare entities. </param>
        /// <param name="relations"> Healthcare entity relations. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="entities"/>, <paramref name="relations"/>, or <paramref name="warnings"/> is null. </exception>
        internal DocumentHealthcareEntities(string id, IEnumerable<HealthcareEntity> entities, IEnumerable<HealthcareRelation> relations, IEnumerable<TextAnalyticsWarningInternal> warnings)
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
            Warnings = warnings.ToList();
        }

        /// <summary> Initializes a new instance of DocumentHealthcareEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Healthcare entities. </param>
        /// <param name="relations"> Healthcare entity relations. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentHealthcareEntities(string id, IReadOnlyList<HealthcareEntity> entities, IReadOnlyList<HealthcareRelation> relations, IReadOnlyList<TextAnalyticsWarningInternal> warnings, TextDocumentStatistics? statistics)
        {
            Id = id;
            Entities = entities;
            Relations = ResolveHealthcareRelations(entities, relations);
            Warnings = warnings;
            Statistics = statistics;
        }

        internal static IReadOnlyList<HealthcareRelation> ResolveHealthcareRelations(IEnumerable<HealthcareEntity> entities, IEnumerable<HealthcareRelation> relations)
        {
            List<HealthcareRelation> list = new List<HealthcareRelation>();
            foreach (HealthcareRelation relation in relations)
            {
                list.Add(new HealthcareRelation(entities, relation.RelationType,
                    relation.Bidirectional,
                    relation.Source,
                    relation.Target));
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
        public IReadOnlyList<TextAnalyticsWarningInternal> Warnings { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public TextDocumentStatistics? Statistics { get; }
    }
}
