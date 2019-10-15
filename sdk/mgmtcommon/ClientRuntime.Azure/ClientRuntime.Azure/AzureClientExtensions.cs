// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.LRO;
    using System.IO;

    public static partial class AzureClientExtensions
    {
        #region Get LRO Result

        /// <summary>
        /// Gets operation result for long running operations.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response with created resource</returns>
        public static async Task<AzureOperationResponse<TBody>> GetLongRunningOperationResultAsync<TBody>(
            this IAzureClient client,
            AzureOperationResponse<TBody> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            var headerlessResponse = new AzureOperationResponse<TBody, object>
            {
                Body = response.Body,
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
            var longRunningResponse = await GetLongRunningOperationResultAsync(client, headerlessResponse, customHeaders, cancellationToken).ConfigureAwait(false);
            return new AzureOperationResponse<TBody>
            {
                Body = longRunningResponse.Body,
                Request = longRunningResponse.Request,
                RequestId = longRunningResponse.RequestId,
                Response = longRunningResponse.Response
            };
        }

        /// <summary>
        /// Gets operation result for long running operations.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <typeparam name="THeader">Type of the resource header</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response with created resource</returns>
        public static async Task<AzureOperationResponse<TBody, THeader>> GetLongRunningOperationResultAsync<TBody, THeader>(
            this IAzureClient client,
            AzureOperationResponse<TBody, THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            IAzureLRO<TBody, THeader> lro = ScheduleLRO<TBody, THeader>(client, response, customHeaders, cancellationToken);
            await lro.BeginLROAsync().ConfigureAwait(false);
            return await lro.GetLROResults().ConfigureAwait(false);

            //return await LegacyLro<TBody, THeader>(client, response, customHeaders, cancellationToken);
        }

        internal static IAzureLRO<TResourceBody, TRequestHeaders> ScheduleLRO<TResourceBody, TRequestHeaders>(
           IAzureClient client,
           AzureOperationResponse<TResourceBody, TRequestHeaders> response,
          Dictionary<string, List<string>> customHeaders,
          CancellationToken cancellationToken)
            where TResourceBody : class
            where TRequestHeaders : class
        {
            var initialRequestMethod = response.Request.Method;
            HttpMethod patchMethod = new HttpMethod("Patch");

            IAzureLRO<TResourceBody, TRequestHeaders> aLro = null;

            //TODO: create factory
            if (initialRequestMethod.Equals(HttpMethod.Put))
            {
                aLro = new PutLRO<TResourceBody, TRequestHeaders>(client, response, customHeaders, cancellationToken);
            }
            else if (initialRequestMethod.Equals(patchMethod))
            {
                aLro = new PATCHLro<TResourceBody, TRequestHeaders>(client, response, customHeaders, cancellationToken);
            }
            else if (initialRequestMethod.Equals(HttpMethod.Post))
            {
                aLro = new POSTLro<TResourceBody, TRequestHeaders>(client, response, customHeaders, cancellationToken);
            }
            else if (initialRequestMethod.Equals(HttpMethod.Delete))
            {
                aLro = new DeleteLro<TResourceBody, TRequestHeaders>(client, response, customHeaders, cancellationToken);
            }
            return aLro;
        }

        /// <summary>
        /// Gets operation result for long running operations.
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationResponse> GetLongRunningOperationResultAsync(
            this IAzureClient client,
            AzureOperationResponse response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            var newResponse = new AzureOperationResponse<object>
            {
                Request = response.Request,
                Response = response.Response,
                RequestId = response.RequestId
            };

            var azureOperationResponse = await client.GetLongRunningOperationResultAsync(
                newResponse, customHeaders, cancellationToken).ConfigureAwait(false);

            return new AzureOperationResponse
            {
                Request = azureOperationResponse.Request,
                Response = azureOperationResponse.Response,
                RequestId = azureOperationResponse.RequestId
            };
        }

        /// <summary>
        /// Gets operation result for long running operations.
        /// </summary>
        /// <typeparam name="THeader">Type of the resource headers</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationHeaderResponse<THeader>> GetLongRunningOperationResultAsync<THeader>(
            this IAzureClient client,
            AzureOperationHeaderResponse<THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where THeader : class
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            var headerlessResponse = new AzureOperationResponse<object, THeader>
            {
                Headers = response.Headers,
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
            var longRunningResponse = await GetLongRunningOperationResultAsync(client, headerlessResponse, customHeaders, cancellationToken).ConfigureAwait(false);
            return new AzureOperationHeaderResponse<THeader>
            {
                Headers = longRunningResponse.Headers,
                Request = longRunningResponse.Request,
                RequestId = longRunningResponse.RequestId,
                Response = longRunningResponse.Response
            };
        }

        #endregion

        #region Put/Patch

        /// <summary>
        /// Gets operation result for PUT and PATCH operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response with created resource</returns>
        public static async Task<AzureOperationResponse<TBody>> GetPutOrPatchOperationResultAsync<TBody>(
            this IAzureClient client,
            AzureOperationResponse<TBody> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class
        {
            return await client.GetLongRunningOperationResultAsync(
                response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets operation result for PUT and PATCH operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <typeparam name="THeader">Type of the resource header</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response with created resource</returns>
        public static async Task<AzureOperationResponse<TBody, THeader>> GetPutOrPatchOperationResultAsync<TBody, THeader>(
            this IAzureClient client,
            AzureOperationResponse<TBody, THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            return await GetLongRunningOperationResultAsync(client, response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets operation result for PUT and PATCH operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationResponse> GetPutOrPatchOperationResultAsync(
            this IAzureClient client,
            AzureOperationResponse response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            return await client.GetLongRunningOperationResultAsync(
                response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Post/Delete

        /// <summary>
        /// Gets operation result for DELETE and POST operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationResponse<TBody>> GetPostOrDeleteOperationResultAsync<TBody>(
            this IAzureClient client,
            AzureOperationResponse<TBody> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class
        {
            return await GetLongRunningOperationResultAsync(client, response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets operation result for DELETE and POST operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <typeparam name="THeader">Type of the resource headers</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationHeaderResponse<THeader>> GetPostOrDeleteOperationResultAsync<THeader>(
            this IAzureClient client,
            AzureOperationHeaderResponse<THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where THeader : class
        {
            return await GetLongRunningOperationResultAsync(client, response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets operation result for DELETE and POST operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body</typeparam>
        /// <typeparam name="THeader">Type of the resource header</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationResponse<TBody, THeader>> GetPostOrDeleteOperationResultAsync<TBody, THeader>(
            this IAzureClient client,
            AzureOperationResponse<TBody, THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            return await GetLongRunningOperationResultAsync(client, response, customHeaders, cancellationToken);
        }

        /// <summary>
        /// Gets operation result for DELETE and POST operations. (Deprecated, please use GetLongRunningOperationResultAsync)
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="response">Response from the begin operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Operation response</returns>
        public static async Task<AzureOperationResponse> GetPostOrDeleteOperationResultAsync(
            this IAzureClient client,
            AzureOperationResponse response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            return await client.GetLongRunningOperationResultAsync(response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets a resource from the specified URL.
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="operationUrl">URL of the resource.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        private static async Task<AzureOperationResponse<TBody, THeader>> GetAsync<TBody, THeader>(
            this IAzureClient client,
            string operationUrl,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            var result = await GetRawAsync(client, operationUrl, customHeaders, cancellationToken).ConfigureAwait(false);

            TBody body = null;
            if (result.Body != null)
            {
                body = result.Body.ToObject<TBody>(JsonSerializer.Create(client.DeserializationSettings));
            }

            return new AzureOperationResponse<TBody, THeader>
            {
                Request = result.Request,
                Response = result.Response,
                Body = body,
                Headers = result.Headers.ToObject<THeader>(JsonSerializer.Create(client.DeserializationSettings))
            };
        }

        /// <summary>
        /// Gets a resource from the specified URL.
        /// </summary>
        /// <param name="client">IAzureClient</param>
        /// <param name="operationUrl">URL of the resource.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        private static async Task<AzureOperationResponse<JObject, JObject>> GetRawAsync(
            this IAzureClient client,
            string operationUrl,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            // Validate
            if (operationUrl == null)
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
                tracingParameters.Add("operationUrl", operationUrl);
                ServiceClientTracing.Enter(invocationId, client, "GetAsync", tracingParameters);
            }

            // Construct URL
            string url = operationUrl.Replace(" ", "%20");

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
            if (client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            HttpStatusCode statusCode = httpResponse.StatusCode;

            if (statusCode != HttpStatusCode.OK &&
                statusCode != HttpStatusCode.Accepted &&
                statusCode != HttpStatusCode.Created &&
                statusCode != HttpStatusCode.NoContent)
            {
                CloudError errorBody = null;
                try
                {
                    errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, client.DeserializationSettings);
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
                catch
                {
                    // failed to deserialize, return empty body
                }
            }

            return new AzureOperationResponse<JObject, JObject>
            {
                Request = httpRequest,
                Response = httpResponse,
                Body = body,
                Headers = httpResponse.Headers.ToJson()
            };
        }

        #endregion

        #region Helper functions
        private static bool CheckResponseStatusCodeFailed<TBody, THeader>(
            AzureOperationResponse<TBody, THeader> initialResponse)
        {
            var statusCode = initialResponse.Response.StatusCode;
            var method = initialResponse.Request.Method;
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Accepted ||
                (statusCode == HttpStatusCode.Created && ((method == HttpMethod.Put) || (method == new HttpMethod("PATCH")))) ||
                (statusCode == HttpStatusCode.NoContent && (method == HttpMethod.Delete || method == HttpMethod.Post)))
            {
                return false;
            }
            return true;
        }

        #endregion


        private static async Task<AzureOperationResponse<TBody, THeader>> LegacyLro<TBody, THeader>(IAzureClient client, 
            AzureOperationResponse<TBody, THeader> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        where TBody : class where THeader : class
        {

            if (response == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response");
            }

            if (response.Response == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Response");
            }

            if (response.Request == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Request");
            }

            if (response.Request.Method == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Request.Method");
            }

            var initialRequestMethod = response.Request.Method;
            if (CheckResponseStatusCodeFailed(response))
            {
                throw new CloudException(string.Format(
                    Resources.UnexpectedPollingStatus,
                    response.Response.StatusCode,
                    initialRequestMethod));
            }

            var pollingState = new PollingState<TBody, THeader>(response, client.LongRunningOperationRetryTimeout);
            Uri getOperationUrl = response.Request.RequestUri;

            // Check provisioning state
            while (!AzureAsyncOperation.TerminalStatuses.Any(s => s.Equals(pollingState.Status,
                StringComparison.OrdinalIgnoreCase)))
            {
                await Task.Delay(pollingState.DelayBetweenPolling, cancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(pollingState.AzureAsyncOperationHeaderLink))
                {
                    await UpdateStateFromAzureAsyncOperationHeader(client, pollingState, customHeaders, cancellationToken, initialRequestMethod).ConfigureAwait(false);
                }
                else if (!string.IsNullOrEmpty(pollingState.LocationHeaderLink))
                {
                    await UpdateStateFromLocationHeader(client, pollingState, customHeaders, cancellationToken, initialRequestMethod).ConfigureAwait(false);
                }
                else if (initialRequestMethod == HttpMethod.Put)
                {
                    await UpdateStateFromGetResourceOperation(client, pollingState, getOperationUrl,
                        customHeaders, cancellationToken, initialRequestMethod).ConfigureAwait(false);
                }
                else
                {
                    throw new CloudException("Location header is missing from long running operation.");
                }
            }

            if (AzureAsyncOperation.SuccessStatus.Equals(pollingState.Status, StringComparison.OrdinalIgnoreCase))
            {
                if ((!string.IsNullOrEmpty(pollingState.AzureAsyncOperationHeaderLink) || pollingState.Resource == null) &&
                    (initialRequestMethod == HttpMethod.Put || initialRequestMethod == new HttpMethod("PATCH")))
                {
                    await UpdateStateFromGetResourceOperation(client, pollingState, getOperationUrl, customHeaders,
                        cancellationToken, initialRequestMethod);
                }
            }

            // Check if operation failed
            if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(pollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                throw pollingState.CloudException;
            }

            return pollingState.AzureOperationResponse;
        }

        /// <summary>
        /// Updates PollingState from Location header.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="initialRequestMethod">Http method of the initial long running operation request</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromLocationHeader<TBody, THeader>(
           IAzureClient client,
           PollingState<TBody, THeader> pollingState,
           Dictionary<string, List<string>> customHeaders,
           CancellationToken cancellationToken,
           HttpMethod initialRequestMethod) where TBody : class where THeader : class
        {
            AzureAsyncOperation asyncOperation = null;

            AzureOperationResponse<JObject, JObject> responseWithResource = await client.GetRawAsync(
                pollingState.LocationHeaderLink,
                customHeaders,
                cancellationToken).ConfigureAwait(false);

            string responseContent = await responseWithResource.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            pollingState.Status = responseWithResource.Response.StatusCode.ToString();
            pollingState.Response = responseWithResource.Response;
            pollingState.Request = responseWithResource.Request;
            pollingState.Resource = responseWithResource.Body == null ? null : responseWithResource.Body.ToObject<TBody>(JsonSerializer
                    .Create(client.DeserializationSettings));
            pollingState.ResourceHeaders = responseWithResource.Headers.ToObject<THeader>(JsonSerializer
                .Create(client.DeserializationSettings));

            // We try to check if the response had status/error returned
            // the reason we deserialize it as AsyncOperation is simply because we are trying to reuse the AsyncOperation model for deserialization (which has Error, Code and Message model types)
            // which is how the response is returned
            // Ideally the response body should be provided as a type TBody, but TBody is a type defined in the swagger and so we cannot provide that type in the constraint hence we end up using a generic
            // JBody type
            try
            {
                asyncOperation = responseWithResource.Body.ToObject<AzureAsyncOperation>(JsonSerializer.Create(client.DeserializationSettings));
            }
            catch { }

            pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperation, responseWithResource, pollingState, responseContent, initialRequestMethod);
        }


        /// <summary>
        /// Updates PollingState from GET operations.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="getOperationUri">Uri for the get operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromGetResourceOperation<TBody, THeader>(
            IAzureClient client,
            PollingState<TBody, THeader> pollingState,
            Uri getOperationUri,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            HttpMethod initialRequestMethod) where TBody : class where THeader : class
        {
            AzureAsyncOperation asyncOperation = null;

            AzureOperationResponse<JObject, JObject> responseWithResource = await GetRawAsync(client,
                getOperationUri.AbsoluteUri, customHeaders, cancellationToken).ConfigureAwait(false);

            if (responseWithResource.Body == null)
            {
                throw new CloudException(Resources.NoBody);
            }

            string responseContent = await responseWithResource.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            pollingState.Response = responseWithResource.Response;
            pollingState.Request = responseWithResource.Request;
            pollingState.Resource = responseWithResource.Body.ToObject<TBody>(JsonSerializer
                .Create(client.DeserializationSettings));
            pollingState.ResourceHeaders = responseWithResource.Headers.ToObject<THeader>(JsonSerializer
                .Create(client.DeserializationSettings));

            // In 202 pattern on PUT ProvisioningState may not be present in 
            // the response. In that case the assumption is the status is Succeeded.

            // We try to check if the response had status/error returned
            // the reason we deserialize it as AsyncOperation is simply because we are trying to reuse the AsyncOperation model for deserialization (which has Error, Code and Message model types)
            // which is how the response is returned
            // Ideally the response body should be provided as a type TBody, but TBody is a type defined in the swagger and so we cannot provide that type in the constraint hence we end up using a generic
            // JBody type
            try
            {
                asyncOperation = responseWithResource.Body.ToObject<AzureAsyncOperation>(JsonSerializer.Create(client.DeserializationSettings));
            }
            catch { }

            pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperation, responseWithResource, pollingState, responseContent, initialRequestMethod);
        }


        /// <summary>
        /// Updates PollingState from Azure-AsyncOperation header.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromAzureAsyncOperationHeader<TBody, THeader>(
            IAzureClient client,
            PollingState<TBody, THeader> pollingState,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            HttpMethod initialRequestMethod) where TBody : class where THeader : class
        {
            string errMessage = string.Empty;

            AzureOperationResponse<AzureAsyncOperation, object> asyncOperationResponse =
                await client.GetAsync<AzureAsyncOperation, object>(
                    pollingState.AzureAsyncOperationHeaderLink,
                    customHeaders,
                    cancellationToken).ConfigureAwait(false);

            if (asyncOperationResponse.Body == null || asyncOperationResponse.Body.Status == null)
            {
                throw new CloudException(Resources.NoBody);
            }

            string responseContent = await asyncOperationResponse.Response.Content.ReadAsStringAsync().ConfigureAwait(false);

            pollingState.Response = asyncOperationResponse.Response;
            pollingState.Request = asyncOperationResponse.Request;
            pollingState.Resource = null;
            pollingState.Status = asyncOperationResponse.Body.Status;

            // In LRO with async operation header, we only update polling state if the status is one of the failed one
            if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(pollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                //As this is for AsyncOperation header, we pass AzureOperationResponse as null
                pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperationResponse.Body,
                                                                    null, pollingState, responseContent, initialRequestMethod);
            }

            //Try to de-serialize to the response model. (Not required for "PutOrPatch" 
            //which has the fallback of invoking generic "resource get".)
            var responseHeaders = pollingState.Response.Headers.ToJson();
            try
            {
                pollingState.Resource = JObject.Parse(responseContent)
                    .ToObject<TBody>(JsonSerializer.Create(client.DeserializationSettings));
                pollingState.ResourceHeaders =
                    responseHeaders.ToObject<THeader>(JsonSerializer.Create(client.DeserializationSettings));
            }
            catch { };
        }

        /// <summary>
        /// The primary purpose for this function is to get status and if there is any error
        /// Update error information to pollingState.Error and pollingState.Exception
        /// 
        /// We have on a very high level two cases
        /// 1) Regardless what kind of LRO operation it is (AzureAsync, locaiton header) either we get error or we dont
        /// 2) If we get error object, this function expects that information in the form of AzureAsyncOperation model type
        /// 3) We get status and error information from AzureAsyncOperation modele and update PollingState accordingly.
        /// 3) If AzureAsyncOperation is null, we assume there was no error retruned in the response
        /// 4) And we get the status from provisioningState and update pollingState accordinly
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <typeparam name="THeader"></typeparam>
        /// <param name="asyncOperation"></param>
        /// <param name="azureResponse"></param>
        /// <param name="pollState"></param>
        /// <param name="responseContent"></param>
        /// <param name="initialRequestMethod"></param>
        /// <returns></returns>
        private static PollingState<TBody, THeader> GetUpdatedPollingStatus<TBody, THeader>(
                        AzureAsyncOperation asyncOperation,
                        AzureOperationResponse<JObject, JObject> azureResponse,
                        PollingState<TBody, THeader> pollState,
                        string responseContent,
                        HttpMethod initialRequestMethod)
            where TBody : class
            where THeader : class
        {
            PollingState<TBody, THeader> pollingState = pollState;
            HttpStatusCode statusCode;

            // We are only interested if we see the status as one of the failed states and we have a valid error body
            if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(pollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                if (asyncOperation?.Error == null)
                {
                    // we need this check until service teams starts implementing v2.2 Azure REST API guidlines, when error will be mandatory on Failed/Canceled status
                    // in Az async operation, it's not madatory currently to send error body on failed/cancelled status
                    if (string.IsNullOrEmpty(pollingState.AzureAsyncOperationHeaderLink))
                    {
                        asyncOperation = null;
                    }
                    //else
                    //{
                    //    // there is no error body, so asynOperation is of no use for us at this stage, we will continue analyzing the response and try to find provisioning state etc
                    //    asyncOperation = null;
                    //}
                }
            }
            else
            {
                // also if the status is a non-standard terminal states (RP provided state e.g. TestFailed, TestSucceeded etc)
                // we again assume this is a response that RP provided for their LRO will continue analyzing the response accordingly
                asyncOperation = null;
            }


            if (asyncOperation != null)
            {
                string errorMessage = string.Empty;
                string errorCode = string.Empty;

                pollingState.Status = asyncOperation.Status;

                if (asyncOperation?.Error == null)
                {
                    errorMessage = string.Format(
                                        CultureInfo.InvariantCulture,
                                        Resources.LongRunningOperationFailed,
                                            asyncOperation.Status);
                }
                else
                {
                    errorMessage = string.Format(
                                        CultureInfo.InvariantCulture,
                                        Resources.LROOperationFailedAdditionalInfo,
                                            asyncOperation.Status, asyncOperation.Error?.Message);
                    errorCode = asyncOperation.Error.Code;
                }

                pollingState.Error = new CloudError()
                {
                    Code = errorCode,
                    Message = errorMessage
                };

                pollingState.CloudException = new CloudException(errorMessage)
                {
                    Body = asyncOperation?.Error,
                    Request = new HttpRequestMessageWrapper(pollingState.Request, null),
                    Response = new HttpResponseMessageWrapper(pollingState.Response, responseContent)
                };
            }
            else if (azureResponse != null)
            {
                statusCode = azureResponse.Response.StatusCode;
                var resource = azureResponse.Body;

                if (statusCode == HttpStatusCode.Accepted)
                {
                    pollingState.Status = AzureAsyncOperation.InProgressStatus;
                }
                else if (statusCode == HttpStatusCode.OK ||
                         (statusCode == HttpStatusCode.Created && initialRequestMethod == HttpMethod.Put) ||
                         (statusCode == HttpStatusCode.NoContent && (initialRequestMethod == HttpMethod.Delete || initialRequestMethod == HttpMethod.Post)))
                {
                    // We check if we got provisionState and we get the status from provisioning state

                    // In 202 pattern on PUT ProvisioningState may not be present in 
                    // the response. In that case the assumption is the status is Succeeded.
                    if (resource != null &&
                        resource["properties"] != null &&
                        resource["properties"]["provisioningState"] != null)
                    {
                        pollingState.Status = (string)resource["properties"]["provisioningState"];
                    }
                    else
                    {
                        pollingState.Status = AzureAsyncOperation.SuccessStatus;
                    }
                }
                else
                {
                    throw new CloudException("The response from long running operation does not have a valid status code.");
                }
            }
            else
            {
                throw new CloudException("The response from long running operation does not have a valid status code.");
            }

            return pollingState;
        }

    }
}