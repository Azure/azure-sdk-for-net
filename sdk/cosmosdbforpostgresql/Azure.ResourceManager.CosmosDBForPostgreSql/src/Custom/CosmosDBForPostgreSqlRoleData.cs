// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Add this custom code to avoid breaking changes for CosmosDBForPostgreSqlRoleData constructor
    // Old api version's model required 'string password' parameter
    public partial class CosmosDBForPostgreSqlRoleData
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBForPostgreSqlRoleData"/>. </summary>
        /// <param name="password"> The password of the cluster role. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="password"/> is null. </exception>
        public CosmosDBForPostgreSqlRoleData(string password)
        {
            Argument.AssertNotNull(password, nameof(password));

            Password = password;
        }
    }
}
