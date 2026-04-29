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
    // The same pattern applies to throughputSettings sub-resources whose multiple parent
    // paths (sqlDatabases / sqlContainers / mongodbDatabases / cassandraKeyspaces /
    // cassandraTables / cassandraViews / gremlinDatabases / gremlinGraphs / tables) all
    // collapse onto a single phantom umbrella resource (SqlResource / MongoDBResource /
    // CassandraResource / GremlinResource / TableResource) by the MPG generator.
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetMongoDBResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetGremlinResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTableResource", typeof(ArmClient), typeof(ResourceIdentifier))]
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

        /// <summary>
        /// Gets an object representing a <see cref="SqlResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SqlResource"/> object. </returns>
        public static SqlResource GetSqlResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetSqlResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="MongoDBResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="MongoDBResource"/> object. </returns>
        public static MongoDBResource GetMongoDBResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetMongoDBResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CassandraResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CassandraResource"/> object. </returns>
        public static CassandraResource GetCassandraResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetCassandraResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="GremlinResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="GremlinResource"/> object. </returns>
        public static GremlinResource GetGremlinResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetGremlinResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TableResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TableResource"/> object. </returns>
        public static TableResource GetTableResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetTableResource(id);
        }
    }
}
