// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// DocumentHealthcareEntities.
    /// </summary>
    public partial class AnalyzeHealthcareEntitiesResult : TextAnalyticsResult
    {
        internal AnalyzeHealthcareEntitiesResult(string id, TextDocumentStatistics statistics,
            IReadOnlyList<HealthcareEntityInternal> healthcareEntities,
            IReadOnlyList<HealthcareRelationInternal> healthcareRelations,
            IReadOnlyList<TextAnalyticsWarningInternal> warnings)
            : base(id, statistics)
        {
            Entities = Transforms.ConvertToHealthcareEntityCollection(healthcareEntities, healthcareRelations);
            Warnings = Transforms.ConvertToWarnings(warnings);
        }

        internal AnalyzeHealthcareEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary> Healthcare entities. </summary>
        public IReadOnlyCollection<HealthcareEntity> Entities { get; }

        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();
    }
}
