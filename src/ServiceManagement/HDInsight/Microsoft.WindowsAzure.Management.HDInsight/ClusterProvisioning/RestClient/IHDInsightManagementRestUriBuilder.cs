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

    /// <summary>
    /// Used to build Uris to access Service endpoints.
    /// </summary>
    internal interface IHDInsightManagementRestUriBuilder
    {
        /// <summary>
        /// Gets the Uri for a ListCloudServices request.
        /// </summary>
        /// <returns>The Uri for a ListCloudServices request.</returns>
        Uri GetListCloudServicesUri();

        /// <summary>
        /// Gets the Uri for a Create Resource request.
        /// </summary>
        /// <param name="resourceId">Resource Id.</param>
        /// <param name="resourceType">Resource Type.</param>
        /// <param name="location">Region the cluster is to be deployed in.</param>
        /// <returns>The Uri for a Create Resource request.</returns>
        Uri GetCreateResourceUri(string resourceId, string resourceType, string location);

        /// <summary>
        /// Gets the Uri for a Get Resource details request.
        /// </summary>
        /// <param name="resourceId">Resource Id.</param>
        /// <param name="resourceType">Resource Type.</param>
        /// <param name="location">Region the cluster is to be deployed in.</param>
        /// <returns>The Uri for a Get Resource details request.</returns>
        Uri GetGetClusterResourceDetailUri(string resourceId, string resourceType, string location);

        /// <summary>
        /// Gets the Uri for a Delete Container request.
        /// </summary>
        /// <param name="dnsName">DnsName of the cluster.</param>
        /// <param name="location">Region the cluster is deployed in.</param>
        /// <returns>The Uri for a Delete Container request.</returns>
        Uri GetDeleteContainerUri(string dnsName, string location);

        /// <summary>
        /// Gets the Uri for a request to enable or disable Http Services.
        /// </summary>
        /// <param name="dnsName">DnsName of the cluster.</param>
        /// <param name="location">Region the cluster is deployed in.</param>
        /// <returns>The Uri for a request to enable or disable Http Services.</returns>
        Uri GetEnableDisableHttpUri(string dnsName, string location);

        /// <summary>
        /// Gets the Uri for a request to enable or disable Rdp Services.
        /// </summary>
        /// <param name="dnsName">The Dns name of the cluster</param>
        /// <param name="location">The region of the cluster</param>
        /// <returns>The Uri for a request to enable or disable Rdp Services</returns>
        Uri GetEnableDisableRdpUri(string dnsName, string location);

        /// <summary>
        /// Gets the Uri for a request to get Operation status.
        /// </summary>
        /// <param name="dnsName">DnsName of the cluster.</param>
        /// <param name="resourceType">Resource Type.</param>
        /// <param name="location">Region the cluster is to be deployed in.</param>
        /// <param name="operationId">Operation Id.</param>
        /// <returns>The Uri for a request to get Operation status.</returns>
        Uri GetOperationStatusUri(string dnsName, string resourceType, string location, Guid operationId);
    }
}