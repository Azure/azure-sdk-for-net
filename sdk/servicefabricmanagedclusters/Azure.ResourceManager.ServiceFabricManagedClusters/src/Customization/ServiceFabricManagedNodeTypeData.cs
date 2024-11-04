// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    /// <summary>
    /// A class representing the ServiceFabricManagedNodeType data model.
    /// Describes a node type in the cluster, each node type represents sub set of nodes in the cluster.
    /// </summary>
    public partial class ServiceFabricManagedNodeTypeData
    {
        /// <summary> Specifies whether each node is allocated its own public IPv6 address. This is only supported on secondary node types with custom Load Balancers. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsNodePublicIPv6Enabled
        {
            get => EnableNodePublicIPv6 is null ? null: EnableNodePublicIPv6;
            set => EnableNodePublicIPv6 = value;
        }
    }
}
