// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Backward-compat only: baseline had public ctor(string password).
    // Password is optional in the current API version.
    public partial class CosmosDBForPostgreSqlRoleData
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBForPostgreSqlRoleData"/>. </summary>
        /// <param name="password"> The password of the cluster role. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CosmosDBForPostgreSqlRoleData(string password)
        {
            Password = password;
        }
    }
}
