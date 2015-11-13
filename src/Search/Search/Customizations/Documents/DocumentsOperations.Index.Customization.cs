// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    internal partial class DocumentsOperations
    {
        public Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync(
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            string payload = JsonUtility.SerializeObject(batch, JsonUtility.DocumentSerializerSettings);
            return DoIndexWithHttpMessagesAsync(payload, searchRequestOptions, customHeaders, cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync<T>(
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType<T>();
            string payload = JsonUtility.SerializeObject(batch, JsonUtility.CreateSerializerSettings<T>(useCamelCase));

            return DoIndexWithHttpMessagesAsync(payload, searchRequestOptions, customHeaders, cancellationToken);
        }

        private async Task<AzureOperationResponse<DocumentIndexResult>> DoIndexWithHttpMessagesAsync(
            string payload,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }

            string clientRequestId = null;
            if (searchRequestOptions != null)
            {
                clientRequestId = searchRequestOptions.ClientRequestId;
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("batch", payload);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Index", tracingParameters);
            }
            
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "docs/search.index").ToString();

            List<string> queryParameters = new List<string>();
            if (this.Client.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(url);
                
            // Set Headers
            if (this.Client.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.Client.AcceptLanguage);
            }
            if (clientRequestId != null)
            {
                if (httpRequest.Headers.Contains("client-request-id"))
                {
                    httpRequest.Headers.Remove("client-request-id");
                }
                httpRequest.Headers.TryAddWithoutValidation("client-request-id", clientRequestId);
            }
            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            httpRequest.Headers.TryAddWithoutValidation("Accept", "application/json;odata.metadata=none");

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = payload;
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

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
            if (statusCode != HttpStatusCode.OK && statusCode != (HttpStatusCode)207)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                CloudError errorBody = JsonUtility.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            var result = new AzureOperationResponse<DocumentIndexResult>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
            }

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == (HttpStatusCode)207)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonUtility.DeserializeObject<DocumentIndexResult>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }

            // Throw IndexBatchException if necessary.
            if (statusCode == (HttpStatusCode)207)
            {
                CloudException ex = new IndexBatchException(result.Body);
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            return result;
        }
    }
}
