// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.TestClients.RedisClient
{
    using CR.Azure.NetCore.Tests.Redis;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CR.Azure.NetCore.Tests.TestClients.Interface;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using CR.Azure.NetCore.Tests.TestClients.Models;
    using System.Threading;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using System.Net;
    using System.Diagnostics;

    internal partial class RedisOperations : IServiceOperations<RedisManagementClient>, IRedisOperations
    {
        /// <summary>
        /// Initializes a new instance of the RedisOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RedisOperations(RedisManagementClient client)
        {
            this._client = client;
        }

        private RedisManagementClient _client;

        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Redis.RedisManagementClient.
        /// </summary>
        public RedisManagementClient Client
        {
            get { return this._client; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="httpMethod"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName,
                                                                                                    string name, RedisCreateOrUpdateParameters parameters,
                                                                                                    string subscriptionId, HttpMethod httpMethod,
                                                                                                    CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = httpMethod;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisResource> result = new AzureOperationResponse<RedisResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                RedisResource resultModel = JsonConvert.DeserializeObject<RedisResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<RedisResource>> PatchWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisResource> response = await BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                new HttpMethod("PATCH"),
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }
        public async Task<AzureOperationResponse<RedisResource>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name,
                                                                                                     RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                     CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisResource> response = await BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }


        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='httpMethod'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName,
                                                                                                string name, RedisCreateOrUpdateParameters parameters,
                                                                                                string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return await BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, HttpMethod.Put, cancellationToken);
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<Sku>> BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Put;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                Sku resultModel = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<Sku>> CreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<Sku> response = await BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisSubResource>> BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Put;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisSubResource> result = new AzureOperationResponse<RedisSubResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                RedisSubResource resultModel = JsonConvert.DeserializeObject<RedisSubResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<RedisSubResource>> CreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisSubResource> response = await BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginDeleteAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Delete;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Accepted && statusCode != HttpStatusCode.Created
                && statusCode != HttpStatusCode.NotFound && statusCode != HttpStatusCode.NoContent)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(
            string resourceGroupName,
            string name,
            string subscriptionId,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse response = await BeginDeleteWithHttpMessagesAsync(
                resourceGroupName,
                name,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                response.Response.StatusCode == HttpStatusCode.Accepted ||
                response.Response.StatusCode == HttpStatusCode.Created ||
                response.Response.StatusCode == HttpStatusCode.NoContent);

            return await this.Client.GetPostOrDeleteOperationResultAsync(response, null, cancellationToken);
        }

        public async Task<AzureOperationResponse<Sku>> BeginPostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginDeleteAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Accepted && statusCode != HttpStatusCode.NotFound)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            result.Body = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<Sku>> PostWithHttpMessagesAsync(
            string resourceGroupName,
            string name,
            string subscriptionId,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<Sku> response = await BeginPostWithHttpMessagesAsync(
                resourceGroupName,
                name,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                response.Response.StatusCode == HttpStatusCode.Accepted ||
                response.Response.StatusCode == HttpStatusCode.Created);

            return await this.Client.GetPostOrDeleteOperationResultAsync<Sku>(response, null, cancellationToken);
        }


        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisResource>> GetWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisResource> result = new AzureOperationResponse<RedisResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                RedisResource resultModel = JsonConvert.DeserializeObject<RedisResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<Sku>> GetSkuWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                Sku resultModel = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisSubResource>> GetSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisSubResource> result = new AzureOperationResponse<RedisSubResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                RedisSubResource resultModel = JsonConvert.DeserializeObject<RedisSubResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
    }

    public static partial class RedisOperationsExtensions
    {
        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource BeginCreateOrUpdate(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisSubResource BeginCreateOrUpdateSubResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateSubResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static Sku BeginCreateOrUpdateNonResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateNonResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Sku> BeginCreateOrUpdateNonResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisSubResource> BeginCreateOrUpdateSubResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisSubResource> result = await operations.BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> BeginCreateOrUpdateAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource CreateOrUpdate(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="resoruceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public static RedisResource Patch(this IRedisOperations operations, string resoruceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).PatchAsync(resoruceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static Sku CreateOrUpdateNonResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateNonResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisSubResource CreateOrUpdateSubResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateSubResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> CreateOrUpdateAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<RedisResource> PatchAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.PatchWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Sku> CreateOrUpdateNonResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.CreateOrUpdateNonResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisSubResource> CreateOrUpdateSubResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisSubResource> result = await operations.CreateOrUpdateSubResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static void BeginDelete(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginDeleteAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        public static void Delete(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).DeleteAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task BeginDeleteAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return;
        }
        public static async Task DeleteAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await operations.DeleteWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return;
        }

        public static Sku BeginPost(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginPostAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        public static Sku Post(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).PostAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        public static async Task<Sku> BeginPostAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.BeginPostWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        public static async Task<Sku> PostAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.PostWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }


        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource Get(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).GetAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> GetAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
