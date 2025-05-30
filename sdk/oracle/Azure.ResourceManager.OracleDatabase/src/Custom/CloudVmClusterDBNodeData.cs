// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the CloudVmClusterDBNode data model.
    /// The DbNode resource belonging to vmCluster
    /// </summary>
    public partial class CloudVmClusterDBNodeData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="CloudVmClusterDBNodeData"/>. </summary>
        public CloudVmClusterDBNodeData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public CloudVmClusterDBNodeProperties Properties { get; set; }
    }
}
