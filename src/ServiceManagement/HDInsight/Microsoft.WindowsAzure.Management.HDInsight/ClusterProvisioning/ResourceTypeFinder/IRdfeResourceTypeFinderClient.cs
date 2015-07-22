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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ResourceTypeFinder
{
    using System.Threading.Tasks;

    internal enum RdfeResourceType
    {
        Unknown,
        Clusters,
        Containers,
        IaasClusters,
    }

    /// <summary>
    /// This is interface incharge of finding the associated Rdfe resource for cluster.
    /// </summary>
    internal interface IRdfeResourceTypeFinderClient
    {
        /// <summary>
        /// Gets the resource type for cluster.
        /// </summary>
        /// <param name="dnsName">Name of the DNS.</param>
        /// <returns>The RdfeResourceType associated with the cluster.</returns>
        Task<RdfeResourceType> GetResourceTypeForCluster(string dnsName);
    }
}
