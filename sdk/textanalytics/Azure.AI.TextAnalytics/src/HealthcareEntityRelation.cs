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
        internal HealthcareEntityRelation(
            HealthcareEntityRelationType relationType,
            IReadOnlyCollection<HealthcareEntityRelationRole> roles,
            double? confidenceScore)
        {
            RelationType = relationType;
            Roles = roles;
            ConfidenceScore = confidenceScore;
        }

        /// <summary>
        /// The type of relation between the entities.
        /// </summary>
        public HealthcareEntityRelationType RelationType { get; }

        /// <summary>
        /// The role of a given entity in the relation.
        /// </summary>
        public IReadOnlyCollection<HealthcareEntityRelationRole> Roles { get; }

        /// <summary>
        /// The confidence score of the identified relation as a decimal number between 0.0 and 1.0, where a value of 1.0 indicates a 100% certainty that the
        /// identified relation is accurate.
        /// </summary>
        public double? ConfidenceScore { get; }
    }
}
