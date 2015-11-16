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
    using Newtonsoft.Json.Serialization;

    internal partial class DocumentsOperations
    {
        public Task<AzureOperationResponse<DocumentSuggestResult>> SuggestWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return DoSuggestWithHttpMessagesAsync<DocumentSuggestResult, SuggestResult, Document>(
                searchText,
                suggesterName,
                suggestParameters,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                DeserializeForSuggest);
        }

        public Task<AzureOperationResponse<DocumentSuggestResult<T>>> SuggestWithHttpMessagesAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            return DoSuggestWithHttpMessagesAsync<DocumentSuggestResult<T>, SuggestResult<T>, T>(
                searchText,
                suggesterName,
                suggestParameters,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                DeserializeForSuggest<T>);
        }

        private static DocumentSuggestResponsePayload<SuggestResult<T>, T> DeserializeForSuggest<T>(string payload) 
            where T : class
        {
            return JsonUtility.DeserializeObject<DocumentSuggestResponsePayload<SuggestResult<T>, T>>(
                payload,
                JsonUtility.CreateTypedDeserializerSettings<T>());
        }

        private static DocumentSuggestResponsePayload<SuggestResult, Document> DeserializeForSuggest(string payload)
        {
            return JsonUtility.DeserializeObject<DocumentSuggestResponsePayload<SuggestResult, Document>>(
                payload, 
                JsonUtility.DocumentDeserializerSettings);
        }

        private async Task<AzureOperationResponse<TSuggestResult>> DoSuggestWithHttpMessagesAsync<TSuggestResult, TDocResult, TDoc>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            Func<string, DocumentSuggestResponsePayload<TDocResult, TDoc>> deserialize)
            where TSuggestResult : DocumentSuggestResultBase<TDocResult, TDoc>, new()
            where TDocResult : SuggestResultBase<TDoc>
            where TDoc : class
        {
            // Validate
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }

            if (searchText == null)
            {
                throw new ArgumentNullException("searchText");
            }

            if (suggesterName == null)
            {
                throw new ArgumentNullException("suggesterName");
            }

            if (suggestParameters == null)
            {
                throw new ArgumentNullException("suggestParameters");
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
                tracingParameters.Add("searchText", searchText);
                tracingParameters.Add("suggesterName", suggesterName);
                tracingParameters.Add("suggestParameters", suggestParameters);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Suggest", tracingParameters);
            }

            // Construct URL
            bool useGet = Client.UseHttpGetForQueries;
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = 
                new Uri(
                    new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")),
                    (useGet ? "docs/search.suggest" : "docs/search.post.suggest")).ToString();

            List<string> queryParameters = new List<string>();
            if (this.Client.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            if (useGet)
            {
                queryParameters.Add(string.Format("search={0}", Uri.EscapeDataString(searchText)));
                queryParameters.Add(string.Format("suggesterName={0}", Uri.EscapeDataString(suggesterName)));
                queryParameters.Add(suggestParameters.ToString());
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = useGet ? new HttpMethod("GET") : new HttpMethod("POST");
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

            // Serialize Request for POST only
            if (!useGet)
            {
                SuggestParametersPayload payload = suggestParameters.ToPayload(searchText, suggesterName);
                string requestContent =
                    JsonUtility.SerializeObject(payload, JsonUtility.DefaultSerializerSettings);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
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
            if (statusCode != HttpStatusCode.OK)
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
            var result = new AzureOperationResponse<TSuggestResult>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
            }

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = new TSuggestResult();
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    DocumentSuggestResponsePayload<TDocResult, TDoc> deserializedResult = deserialize(responseContent);
                    result.Body.Coverage = deserializedResult.Coverage;
                    result.Body.Results = deserializedResult.Documents;
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }

            return result;
        }

        private class DocumentSuggestResponsePayload<TResult, TDoc>
            where TResult : SuggestResultBase<TDoc>
            where TDoc : class 
        {
            [JsonProperty("@search.coverage")]
            public double? Coverage { get; set; }

            [JsonProperty("value")]
            public List<TResult> Documents { get; set; }
        }
    }
}
