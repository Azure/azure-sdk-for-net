// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// DocumentHealthcareEntities.
    /// </summary>
    public partial class AnalyzeHealthcareEntitiesResult : TextAnalyticsResult
    {
        internal AnalyzeHealthcareEntitiesResult(string id, TextDocumentStatistics statistics, IReadOnlyCollection<HealthcareEntity> entities, IReadOnlyList<Models.TextAnalyticsWarningInternal> warnings)
            : base(id, statistics)
        {
            Entities = entities;
            Warnings = Transforms.ConvertToWarnings(warnings);
        }

        internal AnalyzeHealthcareEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary> Healthcare entities. </summary>
        public IReadOnlyCollection<HealthcareEntity> Entities { get; }

        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();
    }
}
