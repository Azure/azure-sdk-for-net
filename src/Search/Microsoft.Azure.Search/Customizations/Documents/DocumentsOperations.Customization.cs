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
    using Rest.Serialization;
    internal partial class DocumentsOperations
    {
        internal static readonly string[] SelectAll = new[] { "*" };

        public Task<AzureOperationResponse<DocumentSearchResult>> ContinueSearchWithHttpMessagesAsync(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string invocationId;
            string clientRequestId;
            bool shouldTrace =
                ValidateAndTraceContinueSearch(
                    continuationToken,
                    searchRequestOptions,
                    cancellationToken,
                    out invocationId,
                    out clientRequestId);

            return DoContinueSearchWithHttpMessagesAsync<DocumentSearchResult, SearchResult, Document>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                clientRequestId,
                customHeaders,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            string invocationId;
            string clientRequestId;
            bool shouldTrace =
                ValidateAndTraceContinueSearch(
                    continuationToken,
                    searchRequestOptions,
                    cancellationToken,
                    out invocationId,
                    out clientRequestId);

            return DoContinueSearchWithHttpMessagesAsync<DocumentSearchResult<T>, SearchResult<T>, T>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                clientRequestId,
                customHeaders,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch<T>);
        }

        public Task<AzureOperationResponse<Document>> GetWithHttpMessagesAsync(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return DoGetWithHttpMessagesAsync<Document>(
                key,
                selectedFields,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings));
        }

        public Task<AzureOperationResponse<T>> GetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            JsonSerializerSettings jsonSerializerSettings = 
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);
            return DoGetWithHttpMessagesAsync<T>(
                key,
                selectedFields,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                jsonSerializerSettings);
        }

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

            JsonSerializerSettings jsonSettings = 
                JsonUtility.CreateDocumentSerializerSettings(this.Client.SerializationSettings);
            string payload = SafeJsonConvert.SerializeObject(batch, jsonSettings);
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
            JsonSerializerSettings jsonSettings =
                JsonUtility.CreateTypedSerializerSettings<T>(this.Client.SerializationSettings, useCamelCase);
            string payload = SafeJsonConvert.SerializeObject(batch, jsonSettings);

            return DoIndexWithHttpMessagesAsync(payload, searchRequestOptions, customHeaders, cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentSearchResult>> SearchWithHttpMessagesAsync(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return DoSearchWithHttpMessagesAsync<DocumentSearchResult, SearchResult, Document>(
                searchText,
                searchParameters,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                DeserializeForSearch);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<T>>> SearchWithHttpMessagesAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            return DoSearchWithHttpMessagesAsync<DocumentSearchResult<T>, SearchResult<T>, T>(
                searchText,
                searchParameters,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                DeserializeForSearch<T>);
        }

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

        private DocumentSearchResponsePayload<SearchResult<T>, T> DeserializeForSearch<T>(string payload)
            where T : class
        {
            return SafeJsonConvert.DeserializeObject<DocumentSearchResponsePayload<SearchResult<T>, T>>(
                payload,
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings));
        }

        private DocumentSearchResponsePayload<SearchResult, Document> DeserializeForSearch(string payload)
        {
            return SafeJsonConvert.DeserializeObject<DocumentSearchResponsePayload<SearchResult, Document>>(
                payload,
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings));
        }

        private DocumentSuggestResponsePayload<SuggestResult<T>, T> DeserializeForSuggest<T>(string payload)
            where T : class
        {
            return SafeJsonConvert.DeserializeObject<DocumentSuggestResponsePayload<SuggestResult<T>, T>>(
                payload,
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings));
        }

        private DocumentSuggestResponsePayload<SuggestResult, Document> DeserializeForSuggest(string payload)
        {
            return SafeJsonConvert.DeserializeObject<DocumentSuggestResponsePayload<SuggestResult, Document>>(
                payload,
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings));
        }

        private async Task<AzureOperationResponse<TSearchResult>> DoContinueSearchWithHttpMessagesAsync<TSearchResult, TDocResult, TDoc>(
            string url,
            SearchParametersPayload searchParameters,
            string clientRequestId,
            Dictionary<string, List<string>> customHeaders,
            bool useGet,
            bool shouldTrace,
            string invocationId,
            CancellationToken cancellationToken,
            Func<string, DocumentSearchResponsePayload<TDocResult, TDoc>> deserialize)
            where TSearchResult : DocumentSearchResultBase<TDocResult, TDoc>, new()
            where TDocResult : SearchResultBase<TDoc>
            where TDoc : class
        {
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
                string requestContent = SafeJsonConvert.SerializeObject(searchParameters, this.Client.SerializationSettings);
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
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
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
            var result = new AzureOperationResponse<TSearchResult>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
            }

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = new TSearchResult();
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        DocumentSearchResponsePayload<TDocResult, TDoc> deserializedResult = deserialize(responseContent);
                        result.Body.Count = deserializedResult.Count;
                        result.Body.Coverage = deserializedResult.Coverage;
                        result.Body.Facets = deserializedResult.Facets;
                        result.Body.Results = deserializedResult.Documents;
                        result.Body.ContinuationToken =
                            deserializedResult.NextLink != null ?
                                new SearchContinuationToken(
                                    deserializedResult.NextLink,
                                    deserializedResult.NextPageParameters) :
                                null;
                    }
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }

            return result;
        }

        private async Task<AzureOperationResponse<T>> DoGetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            JsonSerializerSettings jsonSerializerSettings) where T : class
        {
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (selectedFields == null)
            {
                throw new ArgumentNullException("selectedFields");
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
                tracingParameters.Add("key", key);
                tracingParameters.Add("selectedFields", selectedFields);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Get", tracingParameters);
            }

            // Construct URL
            if (!selectedFields.Any())
            {
                selectedFields = SelectAll;
            }

            string selectClause = String.Join(",", selectedFields);

            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "docs('{key}')").ToString();
            url = url.Replace("{key}", Uri.EscapeDataString(key));
            List<string> queryParameters = new List<string>();
            if (this.Client.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(selectClause)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
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
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
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
            var result = new AzureOperationResponse<T>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
            }

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<T>(responseContent, jsonSerializerSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
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
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
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
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<DocumentIndexResult>(responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
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

        private Task<AzureOperationResponse<TSearchResult>> DoSearchWithHttpMessagesAsync<TSearchResult, TDocResult, TDoc>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            Func<string, DocumentSearchResponsePayload<TDocResult, TDoc>> deserialize)
            where TSearchResult : DocumentSearchResultBase<TDocResult, TDoc>, new()
            where TDocResult : SearchResultBase<TDoc>
            where TDoc : class
        {
            // Validate
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }

            searchText = searchText ?? "*";

            if (searchParameters == null)
            {
                throw new ArgumentNullException("searchParameters");
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
                tracingParameters.Add("searchParameters", searchParameters);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Search", tracingParameters);
            }

            // Construct URL
            bool useGet = Client.UseHttpGetForQueries;
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url =
                new Uri(
                    new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")),
                    (useGet ? "docs" : "docs/search.post.search")).ToString();

            List<string> queryParameters = new List<string>();
            if (this.Client.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            if (useGet)
            {
                queryParameters.Add(string.Format("search={0}", Uri.EscapeDataString(searchText)));
                queryParameters.Add(searchParameters.ToString());
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }

            return DoContinueSearchWithHttpMessagesAsync<TSearchResult, TDocResult, TDoc>(
                url,
                searchParameters.ToPayload(searchText),
                clientRequestId,
                customHeaders,
                useGet,
                shouldTrace,
                invocationId,
                cancellationToken,
                deserialize);
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
                string requestContent = SafeJsonConvert.SerializeObject(payload, this.Client.SerializationSettings);
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
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
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
                try
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
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }

            return result;
        }

        private bool ValidateAndTraceContinueSearch(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions,
            CancellationToken cancellationToken,
            out string invocationId,
            out string clientRequestId)
        {
            // Validate
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            if (continuationToken == null)
            {
                throw new ArgumentNullException("continuationToken");
            }

            clientRequestId = null;
            if (searchRequestOptions != null)
            {
                clientRequestId = searchRequestOptions.ClientRequestId;
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("continuationToken", continuationToken);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);

                ServiceClientTracing.Enter(invocationId, this, "ContinueSearch", tracingParameters);
            }

            return shouldTrace;
        }

        private class DocumentSearchResponsePayload<TResult, TDoc> : SearchContinuationTokenPayload
            where TResult : SearchResultBase<TDoc>
            where TDoc : class
        {
            [JsonProperty("@odata.count")]
            public long? Count { get; set; }

            [JsonProperty("@search.coverage")]
            public double? Coverage { get; set; }

            [JsonProperty("@search.facets")]
            public FacetResults Facets { get; set; }

            [JsonProperty("value")]
            public List<TResult> Documents { get; set; }
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
