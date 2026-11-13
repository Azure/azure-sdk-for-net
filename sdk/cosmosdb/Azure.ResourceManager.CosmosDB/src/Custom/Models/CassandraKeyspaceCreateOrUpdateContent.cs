// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The C# `: TrackedResourceData` base is declared here (instead of via a
    // shadow model + @@alternateType in client.tsp). The generator picks the
    // base up from this partial and strips the inherited ARM base properties.
    // Back-compat ctor overload: 1.4.0 GA accepted a typed CassandraKeyspaceResourceInfo;
    // current spec flattens to a string `resourceKeyspaceName` ctor, so re-expose the
    // typed form and route it through the generated Properties holder.
    public partial class CassandraKeyspaceCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="CassandraKeyspaceCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="resource"> The standard JSON format of a Cassandra keyspace. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
        public CassandraKeyspaceCreateOrUpdateContent(AzureLocation location, CassandraKeyspaceResourceInfo resource) : base(location)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            Properties = new CassandraKeyspaceCreateUpdateProperties(resource.KeyspaceName);
        }
    }
}
