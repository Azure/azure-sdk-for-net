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
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class HDInsightManagementRestClient : IHDInsightManagementRestClient
    {
        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly HDInsight.IAbstractionContext context;
        private const string HelpLinkForException = @"http://go.microsoft.com/fwlink/?LinkID=324137";
        private readonly bool ignoreSslErrors;
        
        public IHDInsightSubscriptionCredentials Credentials
        {
            get { return this.credentials; }
        }

        internal HDInsightManagementRestClient(IHDInsightSubscriptionCredentials credentials, HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            this.context = context;
            this.credentials = credentials;
            this.ignoreSslErrors = ignoreSslErrors;
            if (context.Logger.IsNotNull())
            {
                this.Logger = context.Logger;
            }
            else
            {
                this.Logger = new Logger();
            }
        }
        
        private async Task<IHttpResponseMessageAbstraction> ProcessListCloudServices(IHttpClientAbstraction client)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, this.ignoreSslErrors);
            var uriBuilder = overrideHandlers.UriBuilder;

            client.RequestUri = uriBuilder.GetListCloudServicesUri();
            client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
            client.RequestHeaders.Add(HDInsightRestConstants.Accept);
            client.RequestHeaders.Add(HDInsightRestConstants.UserAgent);
            client.Method = HttpMethod.Get;
            return await this.ProcessSendAsync(client);
        }

        private async Task<IHttpResponseMessageAbstraction> ProcessSendAsync(IHttpClientAbstraction client)
        {
            // Sends, validates and parses the response
            var httpResponse = await client.SendAsync();

            if (httpResponse.StatusCode != HttpStatusCode.Accepted && httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpLayerException(httpResponse.StatusCode, httpResponse.Content);
            }
            return httpResponse;
        }

        // Method = "GET", UriTemplate = "{subscriptionId}/cloudservices"
        public async Task<IHttpResponseMessageAbstraction> ListCloudServices()
        {
            OperationExecutionResult<IHttpResponseMessageAbstraction> result = await OperationExecutor.ExecuteOperationWithRetry(
                () => this.ProcessListCloudServices(this.CreateClient()),
                this.context.RetryPolicy,
                this.context,
                this.context.Logger);

            if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted && result.ExecutionOutput.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content, result.Attempts, result.TotalTime);
            }

            return result.ExecutionOutput;
        }
        
        private IHttpClientAbstraction CreateClient()
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(this.credentials, this.context, this.ignoreSslErrors);
            client.Timeout = this.context.HttpOperationTimeout;
            return client;
        }

        private async Task<IHttpResponseMessageAbstraction> ProcessGetClusterResourceDetail(IHttpClientAbstraction client, string resourceId, string resourceType, string location)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, this.ignoreSslErrors);
            var uriBuilder = overrideHandlers.UriBuilder;

            client.RequestUri = uriBuilder.GetGetClusterResourceDetailUri(resourceId, resourceType, location);
            client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
            client.RequestHeaders.Add(HDInsightRestConstants.Accept);
            client.RequestHeaders.Add(HDInsightRestConstants.UserAgent);
            client.RequestHeaders.Add(HDInsightRestConstants.SchemaVersion3);
            client.Method = HttpMethod.Get;

            // Sends, validates and parses the response
            return await this.ProcessSendAsync(client);
        }

        // Method = "GET", UriTemplate = "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceProviderNamespace}/~/{resourceType}/{resourceName}"
        public async Task<IHttpResponseMessageAbstraction> GetClusterResourceDetail(string resourceId, string resourceType, string location)
        {
            var result = await OperationExecutor.ExecuteOperationWithRetry(
                () => this.ProcessGetClusterResourceDetail(this.CreateClient(), resourceId, resourceType, location),
                this.context.RetryPolicy, 
                this.context,
                this.context.Logger);

            if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted && result.ExecutionOutput.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content, result.Attempts, result.TotalTime);
            }

            return result.ExecutionOutput;
        }

        // Method = "PUT", UriTemplate = "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceProviderNamespace}/{resourceType}/{resourceName}"
        public async Task<IHttpResponseMessageAbstraction> CreateResource(IHttpClientAbstraction client, string resourceId, string resourceType, string location, string clusterPayload, int schemaVersion = 3)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, this.ignoreSslErrors);
            var uriBuilder = overrideHandlers.UriBuilder;
            client.RequestUri = uriBuilder.GetCreateResourceUri(resourceId, resourceType, location);
            client.Method = HttpMethod.Put;
            client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
            switch (schemaVersion)
            {
                case 2:
                    client.RequestHeaders.Add(HDInsightRestConstants.SchemaVersion2);
                    break;
                case 3:
                    client.RequestHeaders.Add(HDInsightRestConstants.SchemaVersion3);
                    break;
            }
            client.RequestHeaders.Add(HDInsightRestConstants.Accept);
            client.Content = new StringContent(clusterPayload);

            return await this.ProcessSendAsync(client);
        }

        // Method = "PUT", UriTemplate = "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceProviderNamespace}/{resourceType}/{resourceName}"
        public async Task<IHttpResponseMessageAbstraction> CreateContainer(string dnsName, string location, string clusterPayload, int schemaVersion=2)
        {
            var result = await OperationExecutor.ExecuteOperationWithRetry(
                    () => this.CreateResource(this.CreateClient(), dnsName, "containers", location, clusterPayload, schemaVersion),
                    this.context.RetryPolicy,
                    this.context,
                    this.context.Logger);

            if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted)
            {
                throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content) { HelpLink = HelpLinkForException };
            }

            return result.ExecutionOutput;
        }

        private async Task<IHttpResponseMessageAbstraction> ProcessDeleteContainer(IHttpClientAbstraction client, string dnsName, string location)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, this.ignoreSslErrors);
            var uriBuilder = overrideHandlers.UriBuilder;

            client.RequestUri = uriBuilder.GetDeleteContainerUri(dnsName, location);

            client.Method = HttpMethod.Delete;
            client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
            client.RequestHeaders.Add(HDInsightRestConstants.Accept);

            return await this.ProcessSendAsync(client);
        }

        // Method = "DELETE", UriTemplate = "{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceProviderNamespace}/{resourceType}/{resourceName}"
        public async Task<IHttpResponseMessageAbstraction> DeleteContainer(string dnsName, string location)
        {
            var result = await OperationExecutor.ExecuteOperationWithRetry(
                    () => this.ProcessDeleteContainer(this.CreateClient(), dnsName, location),
                    this.context.RetryPolicy,
                    this.context,
                    this.context.Logger);

            if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted)
            {
                throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content) { HelpLink = HelpLinkForException };
            }

            return result.ExecutionOutput;
        }

        // Method = "POST", UriTemplate = "{subscriptionId}/cloudservices/{cloudServiceName}/resources/hdinsight/~/containers/{containerName}/services/http"
        public async Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, UserChangeRequestUserType requestType, string payload)
        {
            var manager = ServiceLocator.Instance.Locate<IUserChangeRequestManager>();
            var handler = manager.LocateUserChangeRequestHandler(this.credentials.GetType(), requestType);
            // Creates an HTTP client
            if (handler.IsNull())
            {
                throw new NotSupportedException("Request to submit a UserChangeRequest that is not supported by this client");
            }
            using (IHttpClientAbstraction client = ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(this.credentials, this.context, this.ignoreSslErrors))
            {
                var hadoopContext = new HDInsightSubscriptionAbstractionContext(this.credentials, this.context);
                client.RequestUri = handler.Item1(hadoopContext, dnsName, location);
                client.Method = HttpMethod.Post;
                client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
                client.RequestHeaders.Add(HDInsightRestConstants.SchemaVersion2);
                client.RequestHeaders.Add(HDInsightRestConstants.Accept);
                client.Content = new StringContent(payload);

                IHttpResponseMessageAbstraction httpResponse = await client.SendAsync();
                if (httpResponse.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new HttpLayerException(httpResponse.StatusCode, httpResponse.Content)
                    {
                        HelpLink = HelpLinkForException
                    };
                }
                return httpResponse;
            }
        }

        public async Task<IHttpResponseMessageAbstraction> ProcessGetOperationStatus(IHttpClientAbstraction client, string dnsName, string location, Guid operationId)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, this.ignoreSslErrors);
            var uriBuilder = overrideHandlers.UriBuilder;
            client.RequestUri = uriBuilder.GetOperationStatusUri(dnsName, location, this.credentials.DeploymentNamespace, operationId);
            client.Method = HttpMethod.Get;
            client.RequestHeaders.Add(HDInsightRestConstants.XMsVersion);
            client.RequestHeaders.Add(HDInsightRestConstants.SchemaVersion2);

            return await this.ProcessSendAsync(client);
        }

        // Method = "GET", UriTemplate = "/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{deploymentNamespace}/~/containers/{containerName}/users/operations/{operationId}",
        public async Task<IHttpResponseMessageAbstraction> GetOperationStatus(string dnsName, string location, Guid operationId)
        {
            var start = DateTime.UtcNow;
            var result = await OperationExecutor.ExecuteOperationWithRetry(
                () => this.ProcessGetOperationStatus(this.CreateClient(), dnsName, location, operationId),
                this.context.RetryPolicy,
                this.context,
                this.context.Logger);

            if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted && result.ExecutionOutput.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content, result.Attempts, result.TotalTime);
            }

            return result.ExecutionOutput;
        }

        public ILogger Logger { get; private set; }
    }
}