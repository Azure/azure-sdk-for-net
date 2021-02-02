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
    internal partial class HealthcareEntityInternal
    {
        /// <summary>
        /// Gets the dictionary for related entity with mapped relation type for each.
        /// </summary>
        internal Dictionary<HealthcareEntity, HealthcareEntityRelationType> RelatedEntities { get; } = new Dictionary<HealthcareEntity, HealthcareEntityRelationType>();
    }
}
