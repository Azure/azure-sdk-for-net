// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    // See note on CosmosDBExtensions: duplicate Get*Resource methods originate from the MPG
    // generator collapsing multiple resource operation groups onto the same C# Resource class.
    [CodeGenSuppress("GetSqlResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetMongoDBResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetGremlinResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ResourceIdentifier))]
    public partial class MockableCosmosDBArmClient
    {
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

        /// <summary> Gets an object representing a <see cref="CassandraClusterResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CassandraClusterResource"/> object. </returns>
        public virtual CassandraClusterResource GetCassandraClusterResource(ResourceIdentifier id)
        {
            CassandraClusterResource.ValidateResourceId(id);
            return new CassandraClusterResource(Client, id);
        }
    }
}
