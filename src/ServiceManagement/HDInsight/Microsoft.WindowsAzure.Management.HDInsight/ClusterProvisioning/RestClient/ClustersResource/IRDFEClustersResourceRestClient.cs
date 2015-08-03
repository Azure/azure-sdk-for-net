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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters;

    /// <summary>
    /// The interface that defines the rest class for RDFE client.
    /// </summary>
    [HttpRestDefinition]
    [XmlRequestFormatter, XmlResponseFormatter]
    internal interface IRdfeClustersResourceRestClient
    {
        [HttpRestInvoke("PUT", "{subscriptionId}/services?service={cloudServiceNameWithDeploymentNamespace}&action=register")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.Conflict })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task RegisterSubscriptionIfNotExists(string subscriptionId, string cloudServiceNameWithDeploymentNamespace, CancellationToken cancellationToken);

        [HttpRestInvoke("PUT", "{subscriptionId}/cloudservices/{cloudServiceName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.Created, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task PutCloudServiceAsync(string subscriptionId, string cloudServiceName, CloudService newCloudService, CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/cloudservices?detailLevel=Full")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<CloudServiceList> ListCloudServicesAsync(string subscriptionId, CancellationToken cancellationToken);

        [HttpRestInvoke("PUT", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/clusters/{dnsName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.OK })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<HttpResponseMessage> CreateCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, RDFEResource cluster, CancellationToken cancellationToken);

        [HttpRestInvoke("DELETE", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/clusters/{dnsName}")]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task DeleteCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, CancellationToken cancellationToken);

        [HttpRestInvoke("POST", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}/roles?action={roleAction}")]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<PassthroughResponse> ChangeClusterSize(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, string roleAction, ClusterRoleCollection clusterRoleCollection, CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}")]
        [CustomHeader("x-ms-version", "2012-08-01")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        Task<PassthroughResponse> GetCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, CancellationToken token);

        [HttpRestInvoke("POST", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}/components/{componentName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<PassthroughResponse> UpdateComponent(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, string componentName, ClusterComponent request, CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}/operations/{operationId}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<PassthroughResponse> CheckOperation(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, string operationId, CancellationToken cancellationToken);

        [HttpRestInvoke("POST",
            "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{clusterDnsName}/roles?action={actionType}"
            )]
        [ExpectedStatusCodeValidator(new[] {HttpStatusCode.OK, HttpStatusCode.Accepted,})]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<PassthroughResponse> EnableDisableRdp(string subscriptionId, string cloudServiceName,
            string resourceNamespace, string clusterDnsName, string actionType, ClusterRoleCollection roleCollection,
            CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/operations/{operationId}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2012-08-01")]
        Task<Data.Rdfe.Operation> GetRdfeOperationStatus(string subscriptionId, string operationId, CancellationToken cancellationToken);
    }
}
