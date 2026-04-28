// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Companion partial that restores a single canonical extension method to map
    // ArmClient.GetCassandraClusterResource onto MockableCosmosDBArmClient, after the
    // CodeGenSuppress on this class removes the duplicate generators emitted from
    // @segment("backups") / @segment("commands") action paths in ClusterResource.tsp.
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class CosmosDBExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="CassandraClusterResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CassandraClusterResource"/> object. </returns>
        public static CassandraClusterResource GetCassandraClusterResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetCassandraClusterResource(id);
        }
    }
}
