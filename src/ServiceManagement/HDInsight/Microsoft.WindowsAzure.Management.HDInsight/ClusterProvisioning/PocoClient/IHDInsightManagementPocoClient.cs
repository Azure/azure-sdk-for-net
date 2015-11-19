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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;

    /// <summary>
    /// Provides an object oriented abstraction over the HDInsight management REST client.
    /// </summary>
    internal interface IHDInsightManagementPocoClient : IDisposable, ILogProvider
    {
        /// <summary>
        /// Event that is fired when the client provisions a cluster.
        /// </summary>
        event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        /// <summary>
        /// Gets the abstraction context.
        /// </summary>
        IAbstractionContext Context { get; }

        /// <summary>
        /// Raises the cluster provisioning event.
        /// </summary>
        /// <param name="sender">The IHDInsightManagementPocoClient instance.</param>
        /// <param name="e">EventArgs for the event.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "We need this so that components other than the class can raise the cluster provisioning event.")]
        void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e);

        /// <summary>
        /// Lists the HDInsight containers for a subscription.
        /// </summary>
        /// <returns>
        /// A task that can be used to retrieve a collection of HDInsight containers (clusters).
        /// </returns>
        Task<ICollection<ClusterDetails>> ListContainers();

        /// <summary>
        /// Lists a single HDInsight container by name.
        /// </summary>
        /// <param name="dnsName">
        /// The name of the HDInsight container.
        /// </param>
        /// <returns>
        /// A task that can be used to retrieve the requested HDInsight container.
        /// </returns>
        Task<ClusterDetails> ListContainer(string dnsName);

        /// <summary>
        /// Lists a single HDInsight container by name in specified region.
        /// </summary>
        /// <param name="dnsName">
        /// The name of the HDInsight container.
        /// </param>
        /// <param name="location">
        /// The location of the HDInsight container.
        /// </param>
        /// <returns>
        /// A task that can be used to retrieve the requested HDInsight container.
        /// </returns>
        Task<ClusterDetails> ListContainer(string dnsName, string location);

        /// <summary>
        /// Creates a new HDInsight container (cluster).
        /// </summary>
        /// <param name="details">
        /// A creation object with the details of how the container should be 
        /// configured.
        /// </param>
        /// <returns>
        /// A task that can be used to wait for the creation request to complete.
        /// </returns>
        Task CreateContainer(ClusterCreateParametersV2 details);

        /// <summary>
        /// Deletes an HDInsight container (cluster).
        /// </summary>
        /// <param name="dnsName">
        /// The name of the cluster to delete.
        /// </param>
        /// <returns>
        /// A task that can be used to wait for the delete request to complete.
        /// </returns>
        Task DeleteContainer(string dnsName);

        /// <summary>
        /// Deletes an HDInsight container (cluster).
        /// </summary>
        /// <param name="dnsName">
        /// The name of the cluster to delete.
        /// </param>
        /// <param name="location">
        /// The location of the cluster to delete.
        /// </param>
        /// <returns>
        /// A task that can be used to wait for the delete request to complete.
        /// </returns>
        Task DeleteContainer(string dnsName, string location);

        /// <summary>
        /// Changes the size of the cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>A task that can be used to wait for the request to complete.</returns>
        Task<Guid> ChangeClusterSize(string dnsName, string location, int newSize);

        /// <summary>
        /// Used to enable or disable a given protocol.
        /// </summary>
        /// <param name="protocol">
        /// The protocol to enable or disable.
        /// </param>
        /// <param name="operation">
        /// The operation (either enable or disable).
        /// </param>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="userName">
        /// The user name to use when enabling Http Connectivity.
        /// </param>
        /// <param name="password">
        /// The password to use when enabling Http Connectivity.
        /// </param>
        /// <param name="expiration">
        /// The expiration of the Connectivity.  This is only used for 
        /// some types of protocol requests.
        /// </param>
        /// <returns>
        /// A task that can be used to wait for the request to complete.
        /// </returns>
        Task<Guid> EnableDisableProtocol(UserChangeRequestUserType protocol, UserChangeRequestOperationType operation, string dnsName, string location, string userName, string password, DateTimeOffset expiration);

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
        Task<Guid> EnableHttp(string dnsName, string location, string httpUserName, string httpPassword);

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
        Task<Guid> DisableHttp(string dnsName, string location);

        /// <summary>
        /// Enables Rdp user on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <param name="rdpUserName">The username of the rdp user on the cluster</param>
        /// <param name="rdpPassword">The password of the rdo user on the cluster</param>
        /// <param name="expiry">The time when the rdp access will expire on the cluster</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>
        Task<Guid> EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry);

        /// <summary>
        /// Disables the Rdp user on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>
        Task<Guid> DisableRdp(string dnsName, string location);

        /// <summary>
        /// Queries an operation status to check whether it is complete.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="operationId">The Id of the operation to wait for.</param>
        /// <returns>Returns true, if the the operation is complete.</returns>
        Task<bool> IsComplete(string dnsName, string location, Guid operationId);

        /// <summary>
        /// Queries an operation status.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="operationId">The Id of the operation to wait for.</param>
        /// <returns>A status object for the operation.</returns>
        Task<UserChangeRequestStatus> GetStatus(string dnsName, string location, Guid operationId);

        /// <summary>
        /// Queries status of an RDFE operation.
        /// </summary>
        /// <param name="operationId">The Id of the operation to wait for.</param>
        /// <returns>A status object for the operation.</returns>
        Task<Operation> GetRdfeOperationStatus(Guid operationId);
    }
}