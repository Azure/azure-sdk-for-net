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
    using System.Linq;
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

        /// <summary>
        /// Ability for operatoins to participate in Error Status checking during polling
        /// This provides ability for certain operations to continue with legacy behavior
        /// </summary>
        internal Func<HttpResponseMessage, bool> IgnoreOperationErrorStatusCallBack;

        internal AzureAsyncOperation AsyncOperationResponseBody { get; set; }

        internal AzureOperationResponse<JObject, JObject> RawResponse { get; set; }
        
        internal HttpStatusCode CurrentStatusCode { get; set; }

        internal JObject RawBody { get; set; }
        string ResponseContent { get; set; }

        internal HttpStatusCode InitialResponseStatusCode { get; private set; }

        internal HttpOperationResponse<TResourceBody, TRequestHeaders> InitialResponse { get; private set; }

        internal string LastSerializationExceptionMessage { get; set; }

        internal LROPollState(HttpOperationResponse<TResourceBody, TRequestHeaders> response, IAzureClient client) 
            : base(response, client.LongRunningOperationRetryTimeout)
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
            if (AsyncOperationResponseBody?.Error != null)
            {
                this.Error = AsyncOperationResponseBody?.Error;
                
                // We do this to surface service error message as CloudException message.
                // this allows the message to be surfaced to Exception.Message, rather than user trying to discover the real message
                // from Exception.Body.Message (Body is CloudError)
                if (AsyncOperationResponseBody?.Error?.Message == null)
                {
                    this.Error.Message = string.Format(CultureInfo.InvariantCulture, Resources.LongRunningOperationFailed, AsyncOperationResponseBody.Status);
                }
                else
                {
                    this.Error.Message = string.Format(CultureInfo.InvariantCulture, Resources.LROOperationFailedAdditionalInfo, AsyncOperationResponseBody.Status, AsyncOperationResponseBody.Error?.Message);
                }

                this.CloudException = new CloudException(this.Error.Message)
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

        /// <summary>
        /// Gets a resource from the specified URL.
        /// </summary>
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

            // execute callback, if operations have set the callback to participate in status checking
            bool ignoreCheckingErrorStatus = IgnoreOperationErrorStatusCallBack != null ? IgnoreOperationErrorStatusCallBack(httpResponse) : false;

            if(ignoreCheckingErrorStatus == false)
            {
                await CheckErrorStatusAndThrowAsync(httpRequest, httpResponse);
            }

            JObject body = null;
            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                try
                {
                    body = ParseContent(responseContent);

                    // We only keep last serialization expcetion that occured in the last LRO poll cycle
                    // even if we got serialziation exception in the last iteration but the next response does not result
                    // in serialization error
                    if (!string.IsNullOrEmpty(this.LastSerializationExceptionMessage))
                    {
                        this.LastSerializationExceptionMessage = string.Empty;
                    }
                }
                catch(Exception ex)
                {
                    // failed to deserialize, return empty body
                    this.LastSerializationExceptionMessage = string.Format("Error - '{0}', Response - '{1}'", ex.Message, responseContent);
                }
            }

            // TODO: have a way to pick the last successfully response depending upon the result of the LRO operation for various conditions where
            // the response status code is success but the payload cannot be used or deserialzied
            return new AzureOperationResponse<JObject, JObject>
            {
                Request = httpRequest,
                Response = httpResponse,
                Body = body,
                Headers = httpResponse.Headers?.ToJson()                
            };
        }

        /// <summary>
        /// Currently the only way to parse non application/json content type is to try to parse and convert non application/json
        /// to application/json
        /// </summary>
        /// <param name="responseContent"></param>
        /// <returns></returns>
        private JObject ParseContent(string responseContent)
        {
            bool serializationFailed = false;
            JObject body = null;
            try
            {
                body = JObject.Parse(responseContent);
            }
            catch
            {
                serializationFailed = true;
            }

            if (serializationFailed)
            {
                JToken jt = JToken.Parse(responseContent);
                body = new JObject();
                body.Add("id", jt);
            }

            return body;
        }

        /// <summary>
        /// Check for status.
        /// Throw if error status.
        /// </summary>
        /// <param name="request">HttpRequsest</param>
        /// <param name="response">HttpResponse</param>
        /// <returns></returns>
        internal async Task CheckErrorStatusAndThrowAsync(HttpRequestMessage request, HttpResponseMessage response)
        {
            string responseContent = string.Empty;
            if (response.Content != null)
            {
                //responseContent = Task.Run(async () => await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Result;
                responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            HttpStatusCode statusCode = response.StatusCode;

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
                    Request = new HttpRequestMessageWrapper(request, null),
                    Response = new HttpResponseMessageWrapper(response, responseContent)
                };
            }

            return;
        }
    }
}
