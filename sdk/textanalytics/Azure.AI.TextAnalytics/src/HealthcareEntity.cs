// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// HealthcareEntity.
    /// </summary>
    [CodeGenModel("HealthcareEntity")]
    public partial class HealthcareEntity
    {
        /// <summary>
        /// IsNegated
        /// </summary>
        public bool IsNegated { get; }

        /// <summary>
        /// DataSources
        /// </summary>
        public IReadOnlyCollection<EntityDataSource> DataSources { get; }

        /// <summary>
        /// RelatedEntities
        /// </summary>
        public IReadOnlyDictionary<HealthcareEntity, HealthcareEntityRelationType> RelatedEntities { get; }
    }
}
