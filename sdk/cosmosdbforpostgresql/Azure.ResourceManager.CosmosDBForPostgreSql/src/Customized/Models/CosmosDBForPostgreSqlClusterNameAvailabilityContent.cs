// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.CosmosDBForPostgreSql.Models;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Models
{
    // Backward-compat: baseline had ctor(string name) without type parameter.
    // New generator requires both name and type since type is required in TypeSpec.
    public partial class CosmosDBForPostgreSqlClusterNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBForPostgreSqlClusterNameAvailabilityContent"/>. </summary>
        /// <param name="name"> Cluster name to verify. </param>
        public CosmosDBForPostgreSqlClusterNameAvailabilityContent(string name) : this(name, default)
        {
        }
    }
}
