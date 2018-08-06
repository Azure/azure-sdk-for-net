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
    using Common;
    using Models;
    using Newtonsoft.Json;
    using Rest;
    using Rest.Azure;
    using Rest.Serialization;
    using Serialization;

    internal class DocumentsOperations : IServiceOperations<SearchIndexClient>, IDocumentsOperations
    {
        internal static readonly string[] SelectAll = new[] { "*" };
        internal static readonly string Accept = "application/json; odata.metadata = none";

        /// <summary>
        /// Initializes a new instance of the DocumentsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DocumentsOperations(SearchIndexClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the SearchIndexClient
        /// </summary>
        public SearchIndexClient Client { get; private set; }

        public async Task<AzureOperationResponse<long>> CountWithHttpMessagesAsync(
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<long?> response =
                await this.Client.DocumentsProxy.CountWithHttpMessagesAsync(
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken).ConfigureAwait(false);

            return new AzureOperationResponse<long>()
            {
                Body = response.Body.GetValueOrDefault(),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }

        public async Task<AzureOperationResponse<AutocompleteResult>> AutocompleteWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            AutocompleteParameters autocompleteParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool useGet = Client.UseHttpGetForQueries;

            AzureOperationResponse<AutocompleteResult> response;

            if (useGet)
            {
                response = await this.Client.DocumentsProxy.AutocompleteGetWithHttpMessagesAsync(
                    searchText,
                    suggesterName,
                    searchRequestOptions,
                    autocompleteParameters,
                    customHeaders,
                    cancellationToken).ConfigureAwait(false);
            }
            else
            {
                string searchFieldsStr = null;
                if (autocompleteParameters?.SearchFields != null)
                {
                    searchFieldsStr = string.Join(",", autocompleteParameters?.SearchFields);
                }
                AutocompleteRequest request = new AutocompleteRequest()
                {
                    AutocompleteMode = autocompleteParameters?.AutocompleteMode,
                    UseFuzzyMatching = autocompleteParameters?.UseFuzzyMatching,
                    HighlightPostTag = autocompleteParameters?.HighlightPostTag,
                    HighlightPreTag = autocompleteParameters?.HighlightPreTag,
                    MinimumCoverage = autocompleteParameters?.MinimumCoverage,
                    SearchFields = searchFieldsStr,
                    SearchText = searchText,
                    SuggesterName = suggesterName,
                    Top = autocompleteParameters?.Top
                };

                response = await this.Client.DocumentsProxy.AutocompletePostWithHttpMessagesAsync(
                    request,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken).ConfigureAwait(false);
            }

            return new AzureOperationResponse<AutocompleteResult>()
            {
                Body = response.Body,
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }

        public async Task<AzureOperationResponse<DocumentSearchResult>> ContinueSearchWithHttpMessagesAsync(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings);

            bool useGet = continuationToken.NextPageParameters == null;

            AzureOperationResponse<DocumentSearchResultProxy> response;

            if (useGet)
            {
                var parameters = ParseQueryParameters(continuationToken.NextLink);
                string searchText = parameters.ContainsKey("search") ? parameters["search"].First() : null;

                SearchParameters searchParameters = ConvertToSearchParameters(parameters);

                response = await this.Client.DocumentsProxy.SearchGetWithHttpMessagesAsync(searchText, Accept, searchParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                response = await this.Client.DocumentsProxy.SearchPostWithHttpMessagesAsync(
                    continuationToken.NextPageParameters,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSearchResult>()
            {
                Body = CreateDocumentSearchResultFromProxy(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }

        public async Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class, new()
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);

            bool useGet = continuationToken.NextPageParameters == null;

            AzureOperationResponse<DocumentSearchResultProxy> response;

            if (useGet)
            {
                var parameters = ParseQueryParameters(continuationToken.NextLink);
                string searchText = parameters.ContainsKey("search") ? parameters["search"].First() : null;
                SearchParameters searchParameters = ConvertToSearchParameters(parameters);

                response = await this.Client.DocumentsProxy.SearchGetWithHttpMessagesAsync(
                    searchText,
                    Accept,
                    searchParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                response = await this.Client.DocumentsProxy.SearchPostWithHttpMessagesAsync(
                    continuationToken.NextPageParameters,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSearchResult<T>>()
            {
                Body = CreateTypedSearchResultFromProxy<T>(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
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
            CancellationToken cancellationToken = default(CancellationToken)) where T : class, new()
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

        public async Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync(
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            JsonSerializerSettings serializationSettings =
                JsonUtility.CreateDocumentSerializerSettings(this.Client.SerializationSettings);

            AzureOperationResponse<DocumentIndexResult> result
                = await this.Client.DocumentsProxy.DocumentIndexPostWithHttpMessagesAsync(batch, searchRequestOptions, customHeaders, cancellationToken, requestSerializerSettings: serializationSettings);

            CheckForPartialFailure(result);

            return result;
        }

        public async Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync<T>(
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType<T>();
            JsonSerializerSettings serializationSettings =
                JsonUtility.CreateTypedSerializerSettings<T>(this.Client.SerializationSettings, useCamelCase);

            AzureOperationResponse<DocumentIndexResult> result
                = await this.Client.DocumentsProxy.DocumentIndexPostWithHttpMessagesAsync(batch, searchRequestOptions, customHeaders, cancellationToken, requestSerializerSettings: serializationSettings).ConfigureAwait(false);

            CheckForPartialFailure(result);

            return result;
        }

        public async Task<AzureOperationResponse<DocumentSearchResult>> SearchWithHttpMessagesAsync(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentSearchResultProxy> response;

            if (Client.UseHttpGetForQueries)
            {
                response = await this.Client.DocumentsProxy.SearchGetWithHttpMessagesAsync(
                    searchText,
                    Accept,
                    searchParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                SearchParametersPayload request = searchParameters.ToPayload(searchText);
                response = await this.Client.DocumentsProxy.SearchPostWithHttpMessagesAsync(
                    request,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSearchResult>()
            {
                Body = CreateDocumentSearchResultFromProxy(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }

        public async Task<AzureOperationResponse<DocumentSearchResult<T>>> SearchWithHttpMessagesAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class, new()
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentSearchResultProxy> response;

            if (Client.UseHttpGetForQueries)
            {
                response = await this.Client.DocumentsProxy.SearchGetWithHttpMessagesAsync(
                    searchText,
                    Accept,
                    searchParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                SearchParametersPayload request = searchParameters.ToPayload(searchText);
                response = await this.Client.DocumentsProxy.SearchPostWithHttpMessagesAsync(
                    request,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSearchResult<T>>()
            {
                Body = CreateTypedSearchResultFromProxy<T>(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
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
            CancellationToken cancellationToken = default(CancellationToken)) where T : class, new()
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

        private DocumentSuggestResponsePayload<SuggestResult<T>, T> DeserializeForSuggest<T>(string payload)
            where T : class, new()
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

        private async Task<AzureOperationResponse<T>> DoGetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            JsonSerializerSettings jsonSerializerSettings) where T : class
        {
            if (Client.SearchServiceName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SearchServiceName");
            }
            if (Client.SearchDnsSuffix == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SearchDnsSuffix");
            }
            if (Client.IndexName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.IndexName");
            }
            if (Client.ApiVersion == null)
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

            Guid? clientRequestId = default(Guid?);
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

            string selectClause = selectedFields.ToCommaSeparatedString();

            var baseUrl = Client.BaseUri;
            var url = baseUrl + (baseUrl.EndsWith("/") ? "" : "/") + "docs('{key}')";
            url = url.Replace("{searchServiceName}", Client.SearchServiceName);
            url = url.Replace("{searchDnsSuffix}", Client.SearchDnsSuffix);
            url = url.Replace("{indexName}", Client.IndexName);
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
            HttpResponseMessage httpResponse = null;
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
                httpRequest.Headers.TryAddWithoutValidation("client-request-id", SafeJsonConvert.SerializeObject(clientRequestId, this.Client.SerializationSettings).Trim('"'));
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

            // Serialize Request
            string requestContent = null;
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
            httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = null;
            if (statusCode != HttpStatusCode.OK)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
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
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (httpResponse.Headers.Contains("request-id"))
                {
                    ex.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
                }
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                httpRequest.Dispose();
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
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
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    result.Body = SafeJsonConvert.DeserializeObject<T>(responseContent, jsonSerializerSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
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
            if (Client.SearchServiceName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SearchServiceName");
            }
            if (Client.SearchDnsSuffix == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SearchDnsSuffix");
            }
            if (Client.IndexName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.IndexName");
            }
            if (Client.ApiVersion == null)
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

            Guid? clientRequestId = default(Guid?);
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
            var baseUrl = Client.BaseUri;
            var url = baseUrl + (baseUrl.EndsWith("/") ? "" : "/") + (useGet ? "docs/search.suggest" : "docs/search.post.suggest");
            url = url.Replace("{searchServiceName}", Client.SearchServiceName);
            url = url.Replace("{searchDnsSuffix}", Client.SearchDnsSuffix);
            url = url.Replace("{indexName}", Client.IndexName);
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
            HttpResponseMessage httpResponse = null;
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
                httpRequest.Headers.TryAddWithoutValidation("client-request-id", SafeJsonConvert.SerializeObject(clientRequestId, this.Client.SerializationSettings).Trim('"'));
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
            string requestContent = null;
            if (!useGet)
            {
                SuggestParametersPayload payload = suggestParameters.ToPayload(searchText, suggesterName);
                if (payload != null)
                {
                    requestContent = SafeJsonConvert.SerializeObject(payload, this.Client.SerializationSettings);
                    httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                    httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                }
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = null;
            if (statusCode != HttpStatusCode.OK)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
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
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (httpResponse.Headers.Contains("request-id"))
                {
                    ex.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
                }
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                httpRequest.Dispose();
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
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
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = new TSuggestResult();
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    DocumentSuggestResponsePayload<TDocResult, TDoc> deserializedResult;
                    try
                    {
                        deserializedResult = deserialize(responseContent);
                    }
                    catch (JsonException ex)
                    {
                        httpRequest.Dispose();
                        if (httpResponse != null)
                        {
                            httpResponse.Dispose();
                        }
                        throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                    }

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

        private static DocumentSearchResult CreateDocumentSearchResultFromProxy(DocumentSearchResultProxy resultProxy)
        {
            return new DocumentSearchResult()
            {
                Facets = resultProxy.Facets,
                Count = resultProxy.Count,
                Coverage = resultProxy.Coverage,
                Results = resultProxy.Results.Select(r => new SearchResult() { Score = r.Score, Highlights = r.Highlights, Document = r.Document as Document }).ToArray(),
                ContinuationToken = (resultProxy.NextLink != null || resultProxy.NextSearchParametersPayload != null) ? new SearchContinuationToken(resultProxy.NextLink, resultProxy.NextSearchParametersPayload) : null
            };
        }

        private static DocumentSearchResult<T> CreateTypedSearchResultFromProxy<T>(DocumentSearchResultProxy resultProxy)
            where T : class
        {
            return new DocumentSearchResult<T>()
            {
                Facets = resultProxy.Facets,
                Count = resultProxy.Count,
                Coverage = resultProxy.Coverage,
                Results = resultProxy.Results.Select(r => new SearchResult<T>() { Score = r.Score, Highlights = r.Highlights, Document = r.Document as T }).ToArray(),
                ContinuationToken = (resultProxy.NextLink != null || resultProxy.NextSearchParametersPayload != null) ? new SearchContinuationToken(resultProxy.NextLink, resultProxy.NextSearchParametersPayload) : null
            };
        }

        private static void CheckForPartialFailure(AzureOperationResponse<DocumentIndexResult> documentIndexResult)
        {
            foreach (IndexingResult result in documentIndexResult.Body.Results)
            {
                if (!result.Succeeded)
                {
                    CloudException ex = new IndexBatchException(documentIndexResult.Body);
                    ex.Request = new HttpRequestMessageWrapper(documentIndexResult.Request, documentIndexResult.Request.Content.ToString());
                    ex.Response = new HttpResponseMessageWrapper(documentIndexResult.Response, documentIndexResult.Response.Content.ToString());
                    throw ex;
                }
            }
        }

        private static Dictionary<string, List<string>> ParseQueryParameters(string url)
        {
            string queryString = url.Substring(url.IndexOf('?'));
            queryString = WebUtility.UrlDecode(queryString);

            Dictionary<string, List<string>> parameters =
                new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            foreach (string parameter in queryString.Split('&'))
            {
                string[] elements = parameter.Split('=');
                string name = elements[0];
                string value = elements[1];
                if (!parameters.ContainsKey(name))
                {
                    parameters.Add(name, new List<string>());
                }
                parameters[name].Add(value);
            }
            return parameters;
        }

        private static SearchParameters ConvertToSearchParameters(Dictionary<string, List<string>> parameters)
        {
            List<string> values = new List<string>();

            int? Top = null;
            if (parameters.TryGetValue("$top", out values))
            {
                Top = Convert.ToInt32(values.First());
            }

            int? Skip = null;
            if (parameters.TryGetValue("$skip", out values))
            {
                Skip = Convert.ToInt32(values.First());
            }

            return new SearchParameters()
            {
                QueryType = parameters.TryGetValue("queryType", out values) ? values.First().ParseQueryType() : null,
                SearchMode = parameters.TryGetValue("searchMode", out values) ? values.First().ParseSearchMode() : null,
                HighlightPreTag = parameters.TryGetValue("highlightPreTag", out values) ? values.First() : null,
                HighlightPostTag = parameters.TryGetValue("highlightPostTag", out values) ? values.First() : null,
                SearchFields = parameters.TryGetValue("searchFields", out values) ? values : null,
                IncludeTotalResultCount = parameters.TryGetValue("$count", out values) ? Convert.ToBoolean(values.First()) : false,
                Top = Top,
                Skip = Skip,
                Select = parameters.TryGetValue("$select", out values) ? values : null,
                OrderBy = parameters.TryGetValue("$orderby", out values) ? values : null,
                Filter = parameters.TryGetValue("$filter", out values) ? values.First() : null,
                ScoringProfile = parameters.TryGetValue("scoringProfile", out values) ? values.First() : null,
                ScoringParameterStrings = parameters.TryGetValue("scoringParameter", out values) ? values : null
            };
        }
    }
}
