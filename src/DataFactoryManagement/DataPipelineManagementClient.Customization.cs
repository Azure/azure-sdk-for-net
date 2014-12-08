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

using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure
{
    public static class DataPipelineManagementDiscoveryExtensions
    {
        public static DataPipelineManagementClient CreateDataPipelineManagementClient(
            this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new DataPipelineManagementClient(credentials);
        }

        public static DataPipelineManagementClient CreateDataPipelineManagementClient(
            this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new DataPipelineManagementClient(credentials, baseUri);
        }

        public static DataPipelineManagementClient CreateDataPipelineManagementClient(this CloudClients clients)
        {
            return
                ConfigurationHelper.CreateFromSettings<DataPipelineManagementClient>(
                    DataPipelineManagementClient.Create);
        }
    }
}

namespace Microsoft.Azure.Management.DataFactories
{
    public partial class DataPipelineManagementClient
    {
        public static DataPipelineManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials =
                ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null
                       ? new DataPipelineManagementClient(credentials, baseUri)
                       : new DataPipelineManagementClient(credentials);
        }

        public override DataPipelineManagementClient WithHandler(DelegatingHandler handler)
        {
            return (DataPipelineManagementClient)WithHandler(new DataPipelineManagementClient(), handler);
        }

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
            public string Json
            {
                get;
                set;
            }

            /// <summary>
            /// A custom action to execute when a request is executed.
            /// </summary>
            public Action<HttpRequestMessage> OnRequestAction
            {
                get;
                set;
            }

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
        public string GetResponseBody(Action<DataPipelineManagementClient> operation)
        {
            var handler = new ResponseInterceptor();
            DataPipelineManagementClient client = this.WithHandler(handler);

            operation(client);
            return handler.ResponseBody;
        }

        /// <summary>
        /// Returns the url that the Hydra client would use to execute the given RP operation (doesn't actually 
        /// call the RP.)
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public string GetRequestUri(Action<DataPipelineManagementClient> operation)
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
        public async Task<string> GetResponseBodyAsync(Func<DataPipelineManagementClient, Task> operation)
        {
            var handler = new ResponseInterceptor();
            DataPipelineManagementClient fakeClient = this.WithHandler(handler);

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
        private static DataPipelineManagementClient GetFakeClient(DelegatingHandler handler)
        {
            string fakeSubscriptionId = Guid.NewGuid().ToString("D");
            string fakePassword = "fakepassword";
            var baseUri = new Uri("https://localhost");
            return new DataPipelineManagementClient(new TokenCloudCredentials(fakeSubscriptionId, fakePassword), baseUri).WithHandler(handler);
        }

        /// <summary>
        /// Serializes the given LinkedService into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeLinkedServiceToJson(LinkedService item)
        {
            var createParams = new LinkedServiceCreateOrUpdateParameters() { LinkedService = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.LinkedServices.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given Table into JSON, by mocking a create or update request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeTableToJson(Table item)
        {
            var createParams = new TableCreateOrUpdateParameters() { Table = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Tables.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given Pipeline into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializePipelineToJson(Pipeline item)
        {
            var createParams = new PipelineCreateOrUpdateParameters() { Pipeline = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Pipelines.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given GatewayDefinition into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeGatewayToJson(Gateway item)
        {
            var createParams = new GatewayCreateOrUpdateParameters() { Gateway = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            client.Gateways.BeginCreateOrUpdate(resourceGroupName, dataFactoryName, createParams);
            return handler.Json;
        }

        /// <summary>
        /// Serializes the given <see cref="DataFactory" /> into JSON, by mocking a create request to 
        /// exercise the client's serialization logic.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeDataFactoryToJson(DataFactory item)
        {
            var createParams = new DataFactoryCreateOrUpdateParameters() { DataFactory = item };

            var handler = new MockResourceProviderDelegatingHandler();
            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            client.DataFactories.BeginCreateOrUpdate(resourceGroupName, createParams);
            return handler.Json;
        }

        #endregion JSON serialization

        #region JSON deserialization

        /// <summary>
        /// Deserializes the given json into an Hydra OM Asset instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static LinkedService DeserializeLinkedServiceJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string linkedServiceName = Guid.NewGuid().ToString("D");
            LinkedServiceGetResponse getResponse = client.LinkedServices.Get(resourceGroupName, dataFactoryName, linkedServiceName);
            return getResponse.LinkedService;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM Table instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Table DeserializeTableJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string tableName = Guid.NewGuid().ToString("D");
            TableGetResponse getResponse = client.Tables.Get(resourceGroupName, dataFactoryName, tableName);
            return getResponse.Table;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM Pipeline instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Pipeline DeserializePipelineJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            string pipelineName = Guid.NewGuid().ToString("D");
            PipelineGetResponse getResponse = client.Pipelines.Get(resourceGroupName, dataFactoryName, pipelineName);
            return getResponse.Pipeline;
        }

        /// <summary>
        /// Deserializes the given json into an Hydra OM Gateway instance, by mocking a get request to 
        /// exercise the client's deserialization logic.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Gateway DeserializeGatewayJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = DataPipelineManagementClient.GetFakeClient(handler);
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
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataFactory DeserializeDataFactoryJson(string json)
        {
            var handler = new MockResourceProviderDelegatingHandler() { Json = json };

            var client = DataPipelineManagementClient.GetFakeClient(handler);
            string resourceGroupName = Guid.NewGuid().ToString("D");
            string dataFactoryName = Guid.NewGuid().ToString("D");
            DataFactoryGetResponse getResponse = client.DataFactories.Get(resourceGroupName, dataFactoryName);
            return getResponse.DataFactory;
        }

        #endregion JSON deserialization
    }

    // ToDo: In the Hydra generated codes, DateTime in Uri does not support ISO8601 format by default.
    //       We need to remove this extension class once Hydra team has fixed the issue.    
    public static class DateTimeExtensions
    {
        public static string ConvertToISO8601DateTimeString(this DateTime date)
        {
            return date.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}

namespace Microsoft.Azure.Management.DataFactories.Models
{
    // Use partial classes of various Hydra objects to link them to the JsonConverters that know how to des/ser them, so that
    // JSON.NET produces and parses correct json

    [JsonConverter(typeof(LinkedServiceConverter))]
    partial class LinkedService { }

    [JsonConverter(typeof(TableConverter))]
    partial class Table { }

    [JsonConverter(typeof(PipelineConverter))]
    partial class Pipeline { }

    [JsonConverter(typeof(GatewayConverter))]
    partial class Gateway { }

    [JsonConverter(typeof(DataFactoryConverter))]
    partial class DataFactory { }

    #region JSON converters

    /// <summary>
    /// Base class for JsonConverters that instruct JSON.NET to use the generated Hydra des/ser code, 
    /// so that JSON.NET produces and parses correct json.
    /// </summary>
    public abstract class CustomJsonConverter<T> : JsonConverter
    {
        #region JsonConverter overrides

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string json = JObject.Load(reader).ToString();
            return this.Deserialize(json);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string json = this.Serialize((T)value);
            writer.WriteRaw(json);
        }

        #endregion JsonConverter overrides
        public abstract string Serialize(T item);

        public abstract T Deserialize(string json);
    }

    public class LinkedServiceConverter : CustomJsonConverter<LinkedService>
    {
        public override LinkedService Deserialize(string json)
        {
            return DataPipelineManagementClient.DeserializeLinkedServiceJson(json);
        }

        public override string Serialize(LinkedService item)
        {
            return DataPipelineManagementClient.SerializeLinkedServiceToJson(item);
        }
    }

    public class TableConverter : CustomJsonConverter<Table>
    {
        public override Table Deserialize(string json)
        {
            return DataPipelineManagementClient.DeserializeTableJson(json);
        }

        public override string Serialize(Table item)
        {
            return DataPipelineManagementClient.SerializeTableToJson(item);
        }
    }

    public class PipelineConverter : CustomJsonConverter<Pipeline>
    {
        public override Pipeline Deserialize(string json)
        {
            return DataPipelineManagementClient.DeserializePipelineJson(json);
        }

        public override string Serialize(Pipeline item)
        {
            return DataPipelineManagementClient.SerializePipelineToJson(item);
        }
    }

    public class GatewayConverter : CustomJsonConverter<Gateway>
    {
        public override Gateway Deserialize(string json)
        {
            return DataPipelineManagementClient.DeserializeGatewayJson(json);
        }

        public override string Serialize(Gateway item)
        {
            return DataPipelineManagementClient.SerializeGatewayToJson(item);
        }
    }

    public class DataFactoryConverter : CustomJsonConverter<DataFactory>
    {
        public override DataFactory Deserialize(string json)
        {
            return DataPipelineManagementClient.DeserializeDataFactoryJson(json);
        }

        public override string Serialize(DataFactory item)
        {
            return DataPipelineManagementClient.SerializeDataFactoryToJson(item);
        }
    }

    #endregion JSON converters

}
