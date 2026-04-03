// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Models
{
    // Backward-compat only: baseline had ctor(string name) without type parameter.
    public partial class CosmosDBForPostgreSqlClusterNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBForPostgreSqlClusterNameAvailabilityContent"/>. </summary>
        /// <param name="name"> Cluster name to verify. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CosmosDBForPostgreSqlClusterNameAvailabilityContent(string name) : this(name, CosmosDBForPostgreSqlNameAvailabilityResourceType.ServerGroupsV2)
        {
        }
    }
}
