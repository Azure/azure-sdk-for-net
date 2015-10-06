//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactories.Models;
using CoreRegistrationModel = Microsoft.Azure.Management.DataFactories.Core.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories.Core
{
    public partial class DataFactoryManagementClient
    {
        #region DelegatingHandlers

        /// <summary>
        /// Intercepts the http response, and captures the raw json in the response
        /// body.
        /// </summary>
        private class ResponseInterceptor : DelegatingHandler
        {
            public string ResponseBody
            {
                get;
                private set;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return base.SendAsync(request, cancellationToken)
                    .ContinueWith(task =>
                    {
                        //string responseHeaders = task.Result.ToString();
                        this.ResponseBody = task.Result.Content.ReadAsStringAsync().Result;
                        return task.Result;
                    });
            }
        }

        /// <summary>
        /// Spoofs a call or response to/from the RP, allowing the JSON in the request/response body
        /// to be captured/set. 
        /// </summary>
        private class MockResourceProviderDelegatingHandler : DelegatingHandler
        {
            private bool IsPassThrough { get; set; }

            /// <summary>
            /// Request/response body
            /// </summary>
            public string Json { get; set; }

            /// <summary>
            /// A custom action to execute when a request is executed.
            /// </summary>
            public Action<HttpRequestMessage> OnRequestAction { get; set; }

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (this.OnRequestAction != null)
                {
                    this.OnRequestAction(request);
                }

                if (this.IsPassThrough)
                {
                    return await base.SendAsync(request, cancellationToken);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (request.Content != null)
                {
                    this.Json = request.Content.ReadAsStringAsync().Result;
                }

                if (!string.IsNullOrEmpty(this.Json))
                {
                    response.Content = new StringContent(this.Json);
                }


                string fakeRequestId = Guid.NewGuid().ToString();
                response.Headers.Add("x-ms-request-id", fakeRequestId);
                return response;
            }
        }

        #endregion DelegatingHandlers

        #region Operation response interceptors

        /// <summary>
        /// Executes the given call to the RP and returns the response content (i.e. raw json).
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public string GetResponseBody(Action<DataFactoryManagementClient> operation)
        {
            var handler = new ResponseInterceptor();
            DataFactoryManagementClient client = this.WithHandler(handler);

            operation(client);
            return handler.ResponseBody;
        }

        /// <summary>
        /// Returns the url that the Hydra client would use to execute the given RP operation (doesn't actually 
        /// call the RP.)
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public string GetRequestUri(Action<DataFactoryManagementClient> operation)
        {
            string uri = null;
            var handler = new MockResourceProviderDelegatingHandler();
            handler.OnRequestAction = (request) =>
            {
                uri = request.RequestUri.OriginalString;
                throw new NotSupportedException(); // abort after capturing the URI
            };

            var fakeClient = this.WithHandler(handler);

            try
            {
                operation(fakeClient);
            }
            catch (NotSupportedException)
            {
                // Swallow the exception
            }

            return uri;
        }

        /// <summary>
        /// Executes the given call to the RP and returns the response content (i.e. raw json).
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public async Task<string> GetResponseBodyAsync(Func<DataFactoryManagementClient, Task> operation)
        {
            var handler = new ResponseInterceptor();
            DataFactoryManagementClient fakeClient = this.WithHandler(handler);

            await operation(fakeClient);
            return handler.ResponseBody;
        }

        #endregion Operation response interceptors

        #region JSON serialization

        /// <summary>
        /// Gets a client instance suitable for faking calls to the RP.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        private static DataFactoryManagementClient GetFakeClient(DelegatingHandler handler)
        {
            string fakeSubscriptionId = Guid.NewGuid().ToString("D");
            string fakePassword = "fakepassword";
            var baseUri = new Uri("https://localhost");

            return new DataFactoryManagementClient(
                    new TokenCloudCredentials(fakeSubscriptionId, fakePassword),
                    baseUri).WithHandler(handler);
        }

        /// <summary>
        /// Serializes the given InternalLinkedService into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeInternalLinkedServiceToJson(Models.LinkedService item)
        {
            var createParams = new Models.LinkedServiceCreateOrUpdateParameters() { LinkedService = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.LinkedServices.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given Core.Models.Dataset into JSON, by mocking a create or update request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeInternalDatasetToJson(Models.Dataset item)
        {
            var createParams = new Models.DatasetCreateOrUpdateParameters() { Dataset = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Datasets.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given Pipeline into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeInternalPipelineToJson(Models.Pipeline item)
        {
            var createParams = new Models.PipelineCreateOrUpdateParameters() { Pipeline = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Pipelines.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given GatewayDefinition into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeGatewayToJson(Gateway item)
        {
            var createParams = new GatewayCreateOrUpdateParameters() { Gateway = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Gateways.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given <see cref="DataFactory" /> into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeDataFactoryToJson(DataFactory item)
        {
            var createParams = new DataFactoryCreateOrUpdateParameters() { DataFactory = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            client.DataFactories.BeginCreateOrUpdate(resourceGroupName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given <see cref="Registration.Models.ActivityType" /> into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeInternalActivityTypeToJson(Registration.Models.ActivityType item)
        {
            var createParams = new Registration.Models.ActivityTypeCreateOrUpdateParameters() { ActivityType = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.ActivityTypes.CreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given <see cref="Registration.Models.ComputeType" /> into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item">The object to serialize.</param>
        /// <returns></returns>
        internal static string SerializeInternalComputeTypeToJson(Registration.Models.ComputeType item)
        {
            var createParams = new Registration.Models.ComputeTypeCreateOrUpdateParameters() { ComputeType = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.ComputeTypes.CreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        #endregion JSON serialization

        #region JSON deserialization

        /// <summary>
        /// Deserializes the given json into an Hydra OM InternalLinkedService instance, 
        /// by mocking a get request to exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static Models.LinkedService DeserializeInternalLinkedServiceJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string linkedServiceName = Guid.NewGuid().ToString("D");
            Models.LinkedServiceGetResponse getResponse = client.LinkedServices.Get(
                resourceGroupName,
                dataFactoryName,
                linkedServiceName);

            return getResponse.LinkedService;
        }

        /// <summary>
        /// Deserializes the given json into a <see cref="Core.Models.Dataset"/> instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static Models.Dataset DeserializeInternalDatasetJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string datasetName = Guid.NewGuid().ToString("D");
            Models.DatasetGetResponse getResponse = client.Datasets.Get(resourceGroupName, dataFactoryName, datasetName);
            return getResponse.Dataset;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM Pipeline instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static Models.Pipeline DeserializeInternalPipelineJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string pipelineName = Guid.NewGuid().ToString("D");
            Models.PipelineGetResponse getResponse = client.Pipelines.Get(resourceGroupName, dataFactoryName, pipelineName);
            return getResponse.Pipeline;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM Gateway instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static Gateway DeserializeGatewayJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string gatewayName = Guid.NewGuid().ToString("D");
            GatewayGetResponse getResponse = client.Gateways.Get(resourceGroupName, dataFactoryName, gatewayName);
            return getResponse.Gateway;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM <see cref="DataFactory" /> instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static DataFactory DeserializeDataFactoryJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            DataFactoryGetResponse getResponse = client.DataFactories.Get(resourceGroupName, dataFactoryName);
            return getResponse.DataFactory;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM InternalActivityType instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static CoreRegistrationModel.ActivityType DeserializeInternalActivityTypeJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            CoreRegistrationModel.ActivityTypeGetParameters getParameters = new CoreRegistrationModel.ActivityTypeGetParameters(
                CoreRegistrationModel.RegistrationScope.DataFactory,
                Guid.NewGuid().ToString("D"));
            
            CoreRegistrationModel.ActivityTypeGetResponse getResponse = client.ActivityTypes.Get(
                resourceGroupName,
                dataFactoryName,
                getParameters);

            return getResponse.ActivityType;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM InternalComputeType instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns></returns>
        internal static CoreRegistrationModel.ComputeType DeserializeInternalComputeTypeJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            CoreRegistrationModel.ComputeTypeGetParameters getParameters = new CoreRegistrationModel.ComputeTypeGetParameters(
                CoreRegistrationModel.RegistrationScope.DataFactory,
                Guid.NewGuid().ToString("D"));

            CoreRegistrationModel.ComputeTypeGetResponse getResponse = client.ComputeTypes.Get(
                resourceGroupName,
                dataFactoryName,
                getParameters);

            return getResponse.ComputeType;
        }

        #endregion JSON deserialization
    }
}
