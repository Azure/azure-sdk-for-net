// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A model representing a reference for the healthcare entity into a specific entity catalog.
    /// </summary>
    [CodeGenModel("HealthcareEntityLink")]
    public partial class EntityDataSource
    {
        /// <summary> Initializes a new instance of EntityDataSource. </summary>
        /// <param name="name"> Entity Catalog. Examples include: UMLS, CHV, MSH, etc. </param>
        /// <param name="entityId"> Entity id in the given source catalog. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="entityId"/> is null. </exception>
        internal EntityDataSource(string name, string entityId)
        {
            // See https://github.com/Azure/azure-sdk-for-net/issues/28323 for why this constructor was redefined.
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (entityId == null)
            {
                throw new ArgumentNullException(nameof(entityId));
            }

            Name = name;
            EntityId = entityId;
        }

        /// <summary> Entity id in the given source catalog. </summary>
        [CodeGenMember("Id")]
        public string EntityId { get; }

        /// <summary> Entity Catalog. Examples include: UMLS, CHV, MSH, etc. </summary>
        [CodeGenMember("DataSource")]
        public string Name { get; }
    }
}
