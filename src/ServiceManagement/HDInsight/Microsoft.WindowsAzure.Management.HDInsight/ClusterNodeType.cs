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
    /// <summary>
    /// A list of roles in a HDInsight Hadoop cluster to run config action on.
    /// </summary>
    public enum ClusterNodeType
    {
        /// <summary> 
        /// The headnodes of the cluster.
        /// </summary> 
        HeadNode,

        /// <summary> 
        /// The datanodes of the cluster.
        /// </summary> 
        DataNode,

        /// <summary> 
        /// The zookerper nodes of the cluster.
        /// </summary> 
        ZookeperNode
    }
}