// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the relation role for the entity.
    /// </summary>
    public partial class HealthcareEntityRelationRole
    {
        internal HealthcareEntityRelationRole(HealthcareEntity entity, string entityName)
        {
            Name = entityName;
            Entity = entity;
        }

        internal HealthcareEntityRelationRole(HealthcareEntityInternal entity, string entityName)
        {
            Name = entityName;
            Entity = new HealthcareEntity(entity);
        }

        /// <summary>
        /// Healthcare entity.
        /// </summary>
        public HealthcareEntity Entity { get; }

        /// <summary>
        /// Determines the name for the role.
        /// </summary>
        public string Name { get; }
    }
}
