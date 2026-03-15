// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Backward-compat: baseline had public ctor(string password).
    // New generator only emits internal ctor, making the class effectively sealed.
    public partial class CosmosDBForPostgreSqlRoleData
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBForPostgreSqlRoleData"/>. </summary>
        /// <param name="password"> The password of the cluster role. </param>
        public CosmosDBForPostgreSqlRoleData(string password)
        {
            Password = password;
        }
    }
}
