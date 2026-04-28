// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// The TypeSpec emitter currently emits three identical
// GetCassandraClusterResource(ResourceIdentifier) members because ClusterResource.tsp
// declares ArmResourceRead<ClusterResource, ...> operations whose Parameters add
// @segment("backups") and @segment("commands") path segments. Each phantom path is
// treated by the generator as a separate client of the same target resource, which
// produces duplicate getters that fail to compile. Suppress the duplicates and
// re-add a single canonical getter here. Tracked as a generator improvement.

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ResourceIdentifier))]
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
    }
}
