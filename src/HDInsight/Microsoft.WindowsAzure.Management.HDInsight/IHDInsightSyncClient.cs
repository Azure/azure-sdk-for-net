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
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    /// <summary>
    /// Client Library that allows interacting with the Azure HDInsight Deployment Service.
    /// </summary>
    public interface IHDInsightSyncClient : IHDInsightClientBase
    {
        /// <summary>
        /// Queries the locations where HDInsight has been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        Collection<string> ListAvailableLocations();

        /// <summary>
        /// Queries the locations where HDInsight deployments for the specified OS type have been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        Collection<string> ListAvailableLocations(OSType osType);

        /// <summary>
        /// Queries the locations where HDInsight has been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        IEnumerable<KeyValuePair<string, string>> ListResourceProviderProperties();

        /// <summary>
        /// Queries the versions of HDInsight that have been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        Collection<HDInsightVersion> ListAvailableVersions();

        /// <summary>
        /// Queries the HDInsight Clusters registered.
        /// </summary>
        /// <returns>List of registered HDInsight Clusters.</returns>
        ICollection<ClusterDetails> ListClusters();

        /// <summary>
        /// Queries for a specific HDInsight Cluster registered.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        /// <returns>HDInsight Cluster or NULL if not found.</returns>
        ClusterDetails GetCluster(string dnsName);

        /// <summary>
        /// Queries for a specific HDInsight Cluster registered.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        /// <param name="location">Location of the HDInsight cluster.</param>
        /// <returns>HDInsight Cluster or NULL if not found.</returns>
        ClusterDetails GetCluster(string dnsName, string location);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="cluster">Request object that encapsulates all the configurations.</param>
        /// <returns>Object that represents the HDInsight Cluster created.</returns>
        [Obsolete("ClusterCreateParameters is deprecated. Please use ClusterCreateParametersV2 for creating clusters in HdInsight.")]
        ClusterDetails CreateCluster(ClusterCreateParameters cluster);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="cluster">Request object that encapsulates all the configurations.</param>
        /// <param name="timeout">Timeout interval for the operation.</param>
        /// <returns>Object that represents the HDInsight Cluster created.</returns>
        [Obsolete("ClusterCreateParameters is deprecated. Please use ClusterCreateParametersV2 for creating clusters in HdInsight.")]
        ClusterDetails CreateCluster(ClusterCreateParameters cluster, TimeSpan timeout);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="cluster">Request object that encapsulates all the configurations.</param>
        /// <returns>Object that represents the HDInsight Cluster created.</returns>
        ClusterDetails CreateCluster(ClusterCreateParametersV2 cluster);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="cluster">Request object that encapsulates all the configurations.</param>
        /// <param name="timeout">Timeout interval for the operation.</param>
        /// <returns>Object that represents the HDInsight Cluster created.</returns>
        ClusterDetails CreateCluster(ClusterCreateParametersV2 cluster, TimeSpan timeout);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        void DeleteCluster(string dnsName);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        /// <param name="timeout">Timeout interval for the operation.</param>
        void DeleteCluster(string dnsName, TimeSpan timeout);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        /// <param name="location">Location of the HDInsight cluster.</param>
        void DeleteCluster(string dnsName, string location);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="dnsName">Name of the HDInsight cluster.</param>
        /// <param name="location">Location of the HDInsight cluster.</param>
        /// <param name="timeout">Timeout interval for the operation.</param>
        void DeleteCluster(string dnsName, string location, TimeSpan timeout);

        /// <summary>
        /// Submits a request to change the data node size of a cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>Object that represents the HDInsight Cluster created.</returns>
        ClusterDetails ChangeClusterSize(string dnsName, string location, int newSize);

        /// <summary>
        /// Enables Http Connectivity on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="httpUserName">
        /// The user name to use when enabling Http Connectivity.
        /// </param>
        /// <param name="httpPassword">
        /// The password to use when enabling Http Connectivity.
        /// </param>
        void EnableHttp(string dnsName, string location, string httpUserName, string httpPassword);

        /// <summary>
        /// Disables Http Connectivity on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        void DisableHttp(string dnsName, string location);

        /// <summary>
        /// Enables Rdp access on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The Dns name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <param name="rdpUserName">Rdp username of the cluster</param>
        /// <param name="rdpPassword">Rdp password of the cluseter</param>
        /// <param name="expiry">The UTC time when the Rdp access on the cluster will expire</param>
        void EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry);

        /// <summary>
        /// Disables the Rdp access on the HDInsight cluster
        /// </summary>
        /// <param name="dnsName">The Dns name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        void DisableRdp(string dnsName, string location);
    }
}
