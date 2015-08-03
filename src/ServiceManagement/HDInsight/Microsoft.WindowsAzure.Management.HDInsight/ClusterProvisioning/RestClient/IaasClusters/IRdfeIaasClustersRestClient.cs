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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.IaasClusters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters;

    /// <summary>
    /// The interface that defines operations on IaaS Cluster resource
    /// </summary>
    [HttpRestDefinition]
    [XmlRequestFormatter, XmlResponseFormatter]
    internal interface IRdfeIaasClustersRestClient
    {
        [HttpRestInvoke("PUT", "{subscriptionId}/services?service={cloudServiceNameWithDeploymentNamespace}&action=register")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.Conflict })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task RegisterSubscriptionIfNotExists(string subscriptionId, string cloudServiceNameWithDeploymentNamespace, CancellationToken cancellationToken);

        [HttpRestInvoke("PUT", "{subscriptionId}/cloudservices/{cloudServiceName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.Created, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task PutCloudServiceAsync(string subscriptionId, string cloudServiceName, CloudService newCloudService, CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/cloudservices?detailLevel=Full")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task<CloudServiceList> ListCloudServicesAsync(string subscriptionId, CancellationToken cancellationToken);

        [HttpRestInvoke("PUT", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/iaasclusters/{dnsName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.OK })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task<HttpResponseMessage> CreateCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, RDFEResource cluster, CancellationToken cancellationToken);

        [HttpRestInvoke("DELETE", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/iaasclusters/{dnsName}")]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task DeleteCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, CancellationToken cancellationToken);

        [HttpRestInvoke("GET", "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/iaasclusters/{dnsName}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task<PassthroughResponse> GetCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName, CancellationToken token);

        [HttpRestInvoke("GET", "{subscriptionId}/operations/{operationId}")]
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK, HttpStatusCode.Accepted })]
        [CustomHeader("x-ms-version", "2014-09-01")]
        Task<Operation> GetRdfeOperationStatus(string subscriptionId, string operationId, CancellationToken cancellationToken);
    }
}
