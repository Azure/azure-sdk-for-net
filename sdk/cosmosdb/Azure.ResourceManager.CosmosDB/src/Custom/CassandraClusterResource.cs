// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary>
    /// A Class representing a CassandraCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="CassandraClusterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetCassandraClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetCassandraCluster method.
    /// </summary>
    public partial class CassandraClusterResource : ArmResource
    {
    }
}
