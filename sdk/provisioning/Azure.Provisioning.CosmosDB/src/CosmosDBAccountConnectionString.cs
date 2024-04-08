// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CosmosDB
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public class CosmosDBAccountConnectionString : ConnectionString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosDBAccountConnectionString"/>.
        /// </summary>
        /// <param name="account">The redis cache.</param>
        /// <param name="key">The key to use.</param>
        internal CosmosDBAccountConnectionString(CosmosDBAccount account, CosmosDBKey key)
        : base($"AccountEndpoint=${{{account.Name}.properties.documentEndpoint}};AccountKey=${{{account.Name}.listkeys({account.Name}.apiVersion).{key}}}")
        {
        }
    }
}
