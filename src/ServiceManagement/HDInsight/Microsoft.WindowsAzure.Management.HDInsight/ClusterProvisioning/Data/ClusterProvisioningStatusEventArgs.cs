// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;

    /// <summary>
    /// EventArgs for the ClusterProvisioning event on the IHDInsightClient.
    /// </summary>
    public sealed class ClusterProvisioningStatusEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the ClusterProvisioningStatusEventArgs class.
        /// </summary>
        /// <param name="clusterDetails">Details of the cluster being provisioned.</param>
        /// <param name="clusterState">Current state of the cluster.</param>
        public ClusterProvisioningStatusEventArgs(ClusterDetails clusterDetails, ClusterState clusterState)
        {
            this.Cluster = clusterDetails;
            this.State = clusterState;
        }

        /// <summary>
        /// Gets the current state of the HDInsight cluster.
        /// </summary>
        public ClusterState State { get; private set; }

        /// <summary>
        /// Gets the HDInsightCluster being provisioned.
        /// </summary>
        public ClusterDetails Cluster { get; private set; }
    }
}
