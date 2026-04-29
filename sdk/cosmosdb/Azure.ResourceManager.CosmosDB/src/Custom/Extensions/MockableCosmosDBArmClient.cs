// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// The TypeSpec emitter currently emits multiple identical
// GetCassandraClusterResource(ResourceIdentifier) members because ClusterResource.tsp
// declares ArmResourceRead<ClusterResource, ...> operations whose Parameters add
// @segment("backups") and @segment("commands") path segments. Each phantom path is
// treated by the generator as a separate client of the same target resource, which
// produces duplicate getters that fail to compile. Suppress the duplicates and
// re-add a single canonical getter here. Tracked as a generator improvement.
//
// The same problem affects throughputSettings sub-resources, which are bound under
// many parent paths (sqlDatabases / sqlContainers / mongodbDatabases /
// cassandraKeyspaces / cassandraTables / cassandraViews / gremlinDatabases /
// gremlinGraphs / tables) but are collapsed by the generator onto a single phantom
// umbrella resource per data plane (SqlResource / MongoDBResource / CassandraResource
// / GremlinResource / TableResource). Apply the same suppress + restore pattern.

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetMongoDBResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetGremlinResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTableResource", typeof(ResourceIdentifier))]
    public partial class MockableCosmosDBArmClient
    {
        /// <summary> Gets an object representing a <see cref="CassandraClusterResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CassandraClusterResource"/> object. </returns>
        public virtual CassandraClusterResource GetCassandraClusterResource(ResourceIdentifier id)
        {
            CassandraClusterResource.ValidateResourceId(id);
            return new CassandraClusterResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="SqlResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SqlResource"/> object. </returns>
        public virtual SqlResource GetSqlResource(ResourceIdentifier id)
        {
            SqlResource.ValidateResourceId(id);
            return new SqlResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="MongoDBResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MongoDBResource"/> object. </returns>
        public virtual MongoDBResource GetMongoDBResource(ResourceIdentifier id)
        {
            MongoDBResource.ValidateResourceId(id);
            return new MongoDBResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="CassandraResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CassandraResource"/> object. </returns>
        public virtual CassandraResource GetCassandraResource(ResourceIdentifier id)
        {
            CassandraResource.ValidateResourceId(id);
            return new CassandraResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="GremlinResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="GremlinResource"/> object. </returns>
        public virtual GremlinResource GetGremlinResource(ResourceIdentifier id)
        {
            GremlinResource.ValidateResourceId(id);
            return new GremlinResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="TableResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TableResource"/> object. </returns>
        public virtual TableResource GetTableResource(ResourceIdentifier id)
        {
            TableResource.ValidateResourceId(id);
            return new TableResource(Client, id);
        }
    }
}
