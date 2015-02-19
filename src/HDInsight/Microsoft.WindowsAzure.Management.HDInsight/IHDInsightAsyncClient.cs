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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;

    /// <summary>
    /// Client Library that allows interacting with the Azure HDInsight Deployment Service.
    /// </summary>
    public interface IHDInsightAsyncClient : IHDInsightClientBase
    {
        /// <summary>
        /// Event that is fired when the client provisions a cluster.
        /// </summary>
        event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        /// <summary>
        /// Raises the cluster provisioning event.
        /// </summary>
        /// <param name="sender">The IHDInsightManagementPocoClient instance.</param>
        /// <param name="e">EventArgs for the event.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We need this so that components other than the class can raise the cluster provisioning event.")]
        void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e);

        /// <summary>
        /// Queries the locations where HDInsight has been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        Task<Collection<string>> ListAvailableLocationsAsync();

        /// <summary>
        /// Queries the locations where HDInsight deployments for the specified OS type have been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure locations.</returns>
        Task<Collection<string>> ListAvailableLocationsAsync(OSType osType);

        /// <summary>
        /// Queries the HDInsight Clusters registered.
        /// </summary>
        /// <returns>Task that returns a list of HDInsight Clusters.</returns>
        Task<ICollection<ClusterDetails>> ListClustersAsync();

        /// <summary>
        /// Queries the properties of a given subscription for the  HDInsight resource type.
        /// </summary>
        /// <returns>List of sindows Azure locations.</returns>
        Task<IEnumerable<KeyValuePair<string, string>>> ListResourceProviderPropertiesAsync();

        /// <summary>
        /// Queries the versions of HDInsight that have been enabled for the subscription.
        /// </summary>
        /// <returns>List of Windows Azure HDInsight versions.</returns>
        Task<Collection<HDInsightVersion>> ListAvailableVersionsAsync();

        /// <summary>
        /// Queries for a specific HDInsight Cluster registered.
        /// </summary>
        /// <param name="name">Name of the HDInsight cluster.</param>
        /// <returns>Task that returns an HDInsight Cluster or NULL if not found.</returns>
        Task<ClusterDetails> GetClusterAsync(string name);

        /// <summary>
        /// Queries for a specific HDInsight Cluster registered.
        /// </summary>
        /// <param name="name">Name of the HDInsight cluster.</param>
        /// <param name="location">Location of the HDInsight cluster.</param>
        /// <returns>Task that returns an HDInsight Cluster or NULL if not found.</returns>
        Task<ClusterDetails> GetClusterAsync(string name, string location);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="clusterCreateParameters">Request object that encapsulates all the configurations.</param>
        /// <returns>Object that will manage the deployment and returns an object that represents the HDInsight Cluster created.</returns>
        [Obsolete("ClusterCreateParameters is deprecated. Please use ClusterCreateParametersV2 for creating clusters in HdInsight.")]
        Task<ClusterDetails> CreateClusterAsync(ClusterCreateParameters clusterCreateParameters);

        /// <summary>
        /// Submits a request to create an HDInsight cluster and waits for it to complete.
        /// </summary>
        /// <param name="clusterCreateParameters">Request object that encapsulates all the configurations.</param>
        /// <returns>Object that will manage the deployment and returns an object that represents the HDInsight Cluster created.</returns>
        Task<ClusterDetails> CreateClusterAsync(ClusterCreateParametersV2 clusterCreateParameters);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster.
        /// </summary>
        /// <param name="name">Name of the HDInsight cluster.</param>
        /// <returns>Task that submits a DeleteCluster request.</returns>
        Task DeleteClusterAsync(string name);

        /// <summary>
        /// Submits a request to delete an HDInsight cluster.
        /// </summary>
        /// <param name="name">Name of the HDInsight cluster.</param>
        /// <param name="location">Location of the HDInsight cluster.</param>
        /// <returns>Task that submits a DeleteCluster request.</returns>
        Task DeleteClusterAsync(string name, string location);

        /// <summary>
        /// Submits a request to change the data node size of a cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>
        /// Task that returns an HDInsight Cluster.
        /// </returns>
        Task<ClusterDetails> ChangeClusterSizeAsync(string dnsName, string location, int newSize);

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
        /// <returns>
        /// A task that can be used to wait for the request to complete.
        /// </returns>
        Task EnableHttpAsync(string dnsName, string location, string httpUserName, string httpPassword);

        /// <summary>
        /// Disables Http Connectivity on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <returns>
        /// A task that can be used to wait for the request to complete.
        /// </returns>
        Task DisableHttpAsync(string dnsName, string location);

        /// <summary>
        /// Enables Rdp access on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The Dns name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <param name="rdpUserName">Rdp username of the cluster</param>
        /// <param name="rdpPassword">Rdp password of the cluseter</param>
        /// <param name="expiry">The time when the Rdp access on the cluster will expire</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>>
        Task EnableRdpAsync(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry);

        /// <summary>
        /// Disables the Rdp access on the HDInsight cluster
        /// </summary>
        /// <param name="dnsName">The Dns name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>
        Task DisableRdpAsync(string dnsName, string location);
    }
}
