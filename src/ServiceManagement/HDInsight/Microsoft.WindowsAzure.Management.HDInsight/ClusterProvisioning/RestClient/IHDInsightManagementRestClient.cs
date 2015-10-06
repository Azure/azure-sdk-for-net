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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Used to send container (cluster) request to the server.
    /// </summary>
    internal interface IHDInsightManagementRestClient : ILogProvider
    {
        /// <summary>
        /// Lists the cloud services on the client.
        /// </summary>
        /// <returns>
        /// The response from the request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> ListCloudServices();
        
        /// <summary>
        /// Creates a new cluster on the subscription.
        /// </summary>
        /// <param name="dnsName">
        /// The DNS name of the cluster to create.
        /// </param>
        /// <param name="location">
        /// The location of the cluster to create.
        /// </param>
        /// <param name="clusterPayload">
        /// The creation payload with the details of the cluster to create.
        /// </param>
        /// <param name="schemaVersion">
        /// The schemaversion header we sent to the server, by default it is 2.
        /// </param>
        /// <returns>
        /// A task that represents the cluster creation.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> CreateContainer(string dnsName, string location, string clusterPayload, int schemaVersion = 2);

        /// <summary>
        /// Deletes a cluster from the subscription.
        /// </summary>
        /// <param name="dnsName">
        /// The name of the cluster to delete.
        /// </param>
        /// <param name="location">
        /// The location of the cluster to delete.
        /// </param>
        /// <returns>
        /// A task that represents the cluster deletion.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> DeleteContainer(string dnsName, string location);

        /// <summary>
        /// Submits a request to add a http user a HdInsight cluster.  Only one http user is allowed per cluster.
        /// </summary>
        /// <param name="dnsName">The HdInsight cluster to update.</param>
        /// <param name="location">The location of the cluster to delete.</param>
        /// <param name="requestType">
        /// The type of request being made.
        /// </param>
        /// <param name="payload">The payload.</param>
        /// <returns>Task that adds a user, error if there is already a http user.</returns>
        Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, UserChangeRequestUserType requestType, string payload);

        /// <summary>
        /// Gets the current status of an operation.
        /// </summary>
        /// <param name="dnsName">The HdInsight cluster to update.</param>
        /// <param name="location">The location of the cluster to delete.</param>
        /// <param name="operationId">Id of the operation.</param>
        /// <returns>The current status of the Operation.</returns>
        Task<IHttpResponseMessageAbstraction> GetOperationStatus(string dnsName, string location, Guid operationId);
    }
}