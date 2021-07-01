// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the relation between the entities.
    /// </summary>
    public partial class HealthcareEntityRelation
    {
        internal HealthcareEntityRelation(HealthcareEntityRelationType relationType, IReadOnlyCollection<HealthcareEntityRelationRole> roles)
        {
            RelationType = relationType;
            Roles = roles;
        }

        /// <summary>
        /// Determines the relation type between the healthcare entities. <see cref="HealthcareEntityRelationType"/>
        /// </summary>
        public HealthcareEntityRelationType RelationType { get; }

        /// <summary>
        /// Determines the role between the healthcare entities. <see cref="HealthcareEntityRelationRole"/>
        /// </summary>
        public IReadOnlyCollection<HealthcareEntityRelationRole> Roles { get; }
    }
}
