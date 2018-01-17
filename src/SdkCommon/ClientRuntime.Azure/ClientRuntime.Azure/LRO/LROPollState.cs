// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    internal class LROPollState<TResourceBody, TRequestHeaders> : PollingState<TResourceBody, TRequestHeaders>
        where TResourceBody : class
        where TRequestHeaders : class
    {
        internal string PollingUrlToUse { get; set; }

        internal string FinalGETUrlToUser { get; set; }

        IAzureClient SdkClient { get; set; }

        internal AzureAsyncOperation AsyncOperationResponseBody { get; set; }

        internal AzureOperationResponse<JObject, JObject> RawResponse { get; set; }
        
        internal HttpStatusCode CurrentStatusCode { get; set; }

        internal JObject RawBody { get; set; }
        string ResponseContent { get; set; }

        internal HttpStatusCode InitialResponseStatusCode { get; }

        internal HttpOperationResponse<TResourceBody, TRequestHeaders> InitialResponse { get; private set; }

        internal string LastSerializationExceptionMessage { get; set; }

        internal LROPollState(HttpOperationResponse<TResourceBody, TRequestHeaders> response, IAzureClient client) : base(response, client.LongRunningOperationRetryTimeout)
        {
            SdkClient = client;
            InitialResponse = response;
            InitialResponseStatusCode = Response.StatusCode;
            CurrentStatusCode = InitialResponseStatusCode;
        }
        
        internal async Task Poll(Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            await UpdateResourceFromPollingUri(customHeaders, cancellationToken);

            #region Error response returned while polling on AsyncOperationHeader
            string errorMessage = string.Empty;
            string errorCode = string.Empty;

            if (AsyncOperationResponseBody?.Error != null)
            {
                if (AsyncOperationResponseBody?.Error?.Message == null)
                {
                    errorMessage = string.Format(CultureInfo.InvariantCulture, Resources.LongRunningOperationFailed, AsyncOperationResponseBody.Status);
                }
                else
                {
                    errorMessage = string.Format(CultureInfo.InvariantCulture, Resources.LROOperationFailedAdditionalInfo, AsyncOperationResponseBody.Status, AsyncOperationResponseBody.Error?.Message);
                    errorCode = AsyncOperationResponseBody.Error.Code;
                }

                this.Error = new CloudError()
                {
                    Code = errorCode,
                    Message = errorMessage
                };

                this.CloudException = new CloudException(errorMessage)
                {
                    Body = AsyncOperationResponseBody?.Error,
                    Request = new HttpRequestMessageWrapper(this.Request, null),
                    Response = new HttpResponseMessageWrapper(this.Response, this.ResponseContent)
                };
            }
            #endregion
        }

        internal async Task UpdateResourceFromPollingUri(Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            TResourceBody resourceBody = null;
            RawResponse = await GetRawAsync(customHeaders, cancellationToken).ConfigureAwait(false);

            // For Locaiton header case or where there are no LRO headers, this will be resource body (e.g. PUT with no location/async headers)
            resourceBody = DeserializeToObject<TResourceBody>(() => RawResponse.Body);            
            RawBody = RawResponse.Body;
            if(RawResponse.Response.Content != null)
            {
                this.ResponseContent = await RawResponse.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            // We now try to check if the response was due to polling on AzureAsyncOperatoin header
            // as we eliminated two code paths for different headers that were being used earlier.
            // This will be null if the response was no due to AsyncOperation header
            AsyncOperationResponseBody = DeserializeToObject<AzureAsyncOperation>(() => RawResponse.Body);            

            this.Status = RawResponse.Response.StatusCode.ToString();
            this.Response = RawResponse.Response;
            this.Request = RawResponse.Request;

            // Resource will be null when AsynOperation header is used. Also in Delete/POST if initial response has body, it will be ignore
            // status code will be instrumental to proceed further
            this.Resource = resourceBody;
            this.ResourceHeaders = DeserializeToObject<TRequestHeaders>(() => RawResponse.Headers);
        }

        private TDeserializedBodyType DeserializeToObject<TDeserializedBodyType>(Func<JObject> deserializDelegate) where TDeserializedBodyType: class
        {
            TDeserializedBodyType deserializedData = null;
            try
            {
                deserializedData = deserializDelegate().ToObject<TDeserializedBodyType>(JsonSerializer.Create(SdkClient.DeserializationSettings));
            }
            catch { }

            return deserializedData;
        }

        internal string GetProvisioningState()
        {
            string provisionState = string.Empty;
            if (this.RawBody != null &&
                   this.RawBody["properties"] != null &&
                   this.RawBody["properties"]["provisioningState"] != null)
            {
                provisionState = (string)this.RawBody["properties"]["provisioningState"];
            }

            return provisionState;
        }

        /// <summary>
        /// Gets a resource from the specified URL.
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="operationUrl">URL of the resource.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        internal async Task<AzureOperationResponse<JObject, JObject>> GetRawAsync(
            /*string operationUrl,*/
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            // Validate
            if (PollingUrlToUse == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "operationUrl");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("operationUrl", PollingUrlToUse);
                ServiceClientTracing.Enter(invocationId, SdkClient, "GetAsync", tracingParameters);
            }

            // Construct URL
            string url = PollingUrlToUse.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (SdkClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await SdkClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await SdkClient.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = string.Empty;
            if (httpResponse.Content != null)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            
            HttpStatusCode statusCode = httpResponse.StatusCode;

            if (statusCode != HttpStatusCode.OK &&
                statusCode != HttpStatusCode.Accepted &&
                statusCode != HttpStatusCode.Created &&
                statusCode != HttpStatusCode.NoContent)
            {
                CloudError errorBody = null;
                try
                {
                    errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, SdkClient.DeserializationSettings);
                }
                catch (JsonException)
                {
                    // failed to deserialize, return empty body
                }

                throw new CloudException(string.Format(CultureInfo.InvariantCulture,
                    Resources.LongRunningOperationFailed, statusCode))
                {
                    Body = errorBody,
                    Request = new HttpRequestMessageWrapper(httpRequest, null),
                    Response = new HttpResponseMessageWrapper(httpResponse, responseContent)
                };
            }

            JObject body = null;
            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                try
                {
                    body = JObject.Parse(responseContent);
                }
                catch(Exception ex)
                {
                    // failed to deserialize, return empty body
                    this.LastSerializationExceptionMessage = string.Format("Error - '{0}', Response - '{1}'", ex.Message, responseContent);
                }
            }

            return new AzureOperationResponse<JObject, JObject>
            {
                Request = httpRequest,
                Response = httpResponse,
                Body = body,
                Headers = httpResponse.Headers?.ToJson()                
            };
        }
    }
}
