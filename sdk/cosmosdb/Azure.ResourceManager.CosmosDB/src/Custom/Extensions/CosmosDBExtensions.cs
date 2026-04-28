// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // The MPG generator emits multiple identical extension methods for resource classes
    // whose @armResourceOperations interfaces collapse onto the same C# Resource type
    // (e.g., several `ThroughputSettingsGetResults`-based operation groups all map to
    // SqlResource/MongoDBResource/CassandraResource/GremlinResource, and CassandraCluster
    // is emitted multiple times due to multi-version registration). The CodeGenSuppress
    // entries below remove those duplicate emissions; the canonical implementation is
    // re-provided in this partial class.
    [CodeGenSuppress("GetSqlResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetMongoDBResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetGremlinResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class CosmosDBExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="SqlResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SqlResource"/> object. </returns>
        public static SqlResource GetSqlResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableCosmosDBArmClient(client).GetSqlResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="MongoDBResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MongoDBResource"/> object. </returns>
        public static MongoDBResource GetMongoDBResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableCosmosDBArmClient(client).GetMongoDBResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CassandraResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CassandraResource"/> object. </returns>
        public static CassandraResource GetCassandraResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableCosmosDBArmClient(client).GetCassandraResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="GremlinResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="GremlinResource"/> object. </returns>
        public static GremlinResource GetGremlinResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableCosmosDBArmClient(client).GetGremlinResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CassandraClusterResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CassandraClusterResource"/> object. </returns>
        public static CassandraClusterResource GetCassandraClusterResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableCosmosDBArmClient(client).GetCassandraClusterResource(id);
        }
    }
}
