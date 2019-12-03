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
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Common;
    using Models;
    using Newtonsoft.Json;
    using Rest;
    using Rest.Azure;
    using Serialization;

    internal class DocumentsOperations : IServiceOperations<SearchIndexClient>, IDocumentsOperations
    {
        internal static readonly string[] SelectAll = new[] { "*" };

        /// <summary>
        /// Initializes a new instance of the DocumentsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DocumentsOperations(SearchIndexClient client)
        {
            Client = client ?? throw new ArgumentNullException("client");
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
                await Client.DocumentsProxy.CountWithHttpMessagesAsync(
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

        public Task<AzureOperationResponse<AutocompleteResult>> AutocompleteWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            AutocompleteParameters autocompleteParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (Client.UseHttpGetForQueries)
            {
                return Client.DocumentsProxy.AutocompleteGetWithHttpMessagesAsync(
                    searchText,
                    suggesterName,
                    searchRequestOptions,
                    autocompleteParameters,
                    customHeaders,
                    cancellationToken);
            }
            else
            {
                return Client.DocumentsProxy.AutocompletePostWithHttpMessagesAsync(
                    (autocompleteParameters ?? new AutocompleteParameters()).ToRequest(searchText, suggesterName),
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken);
            }    
        }

        public Task<AzureOperationResponse<DocumentSearchResult<Document>>> ContinueSearchWithHttpMessagesAsync(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateDocumentDeserializerSettings(Client.DeserializationSettings);

            return DoContinueSearchAsync<Document>(
                continuationToken,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                deserializerSettings);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateTypedDeserializerSettings<T>(Client.DeserializationSettings);

            return DoContinueSearchAsync<T>(
                continuationToken,
                searchRequestOptions,
                customHeaders,
                cancellationToken,
                deserializerSettings);
        }

        public Task<AzureOperationResponse<Document>> GetWithHttpMessagesAsync(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings jsonSerializerSettings =
                JsonUtility.CreateDocumentDeserializerSettings(Client.DeserializationSettings);

            return Client.DocumentsProxy.GetWithHttpMessagesAsync<Document>(
                key,
                selectedFields.ToList(),
                searchRequestOptions,
                EnsureCustomHeaders(customHeaders),
                cancellationToken,
                responseDeserializerSettings: jsonSerializerSettings);
        }

        public Task<AzureOperationResponse<T>> GetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings jsonSerializerSettings = 
                JsonUtility.CreateTypedDeserializerSettings<T>(Client.DeserializationSettings);

            return Client.DocumentsProxy.GetWithHttpMessagesAsync<T>(
                key,
                selectedFields.ToList(),
                searchRequestOptions,
                EnsureCustomHeaders(customHeaders),
                cancellationToken,
                responseDeserializerSettings: jsonSerializerSettings);
        }

        public Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync(
            IndexBatch<Document> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings jsonSettings = JsonUtility.CreateDocumentSerializerSettings(Client.SerializationSettings);

            return DoIndexAsync(batch, searchRequestOptions, customHeaders, jsonSettings, cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync<T>(
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType<T>();
            JsonSerializerSettings jsonSettings = JsonUtility.CreateTypedSerializerSettings<T>(Client.SerializationSettings, useCamelCase);

            return DoIndexAsync(batch, searchRequestOptions, customHeaders, jsonSettings, cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<Document>>> SearchWithHttpMessagesAsync(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateDocumentDeserializerSettings(Client.DeserializationSettings);

            return DoSearchAsync<Document>(
                searchText,
                searchParameters,
                searchRequestOptions,
                customHeaders,
                deserializerSettings,
                cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<T>>> SearchWithHttpMessagesAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateTypedDeserializerSettings<T>(Client.DeserializationSettings);

            return DoSearchAsync<T>(
                searchText,
                searchParameters,
                searchRequestOptions,
                customHeaders,
                deserializerSettings,
                cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentSuggestResult<Document>>> SuggestWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateDocumentDeserializerSettings(Client.DeserializationSettings);

            return DoSuggestAsync<Document>(
                searchText,
                suggesterName,
                suggestParameters,
                searchRequestOptions,
                customHeaders,
                deserializerSettings,
                cancellationToken);
        }

        public Task<AzureOperationResponse<DocumentSuggestResult<T>>> SuggestWithHttpMessagesAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var deserializerSettings = JsonUtility.CreateTypedDeserializerSettings<T>(Client.DeserializationSettings);

            return DoSuggestAsync<T>(
                searchText, 
                suggesterName, 
                suggestParameters, 
                searchRequestOptions, 
                customHeaders, 
                deserializerSettings, 
                cancellationToken);
        }

        private static Dictionary<string, List<string>> EnsureCustomHeaders(Dictionary<string, List<string>> customHeaders)
        {
            const string Accept = nameof(Accept);
            const string AcceptValue = "application/json;odata.metadata=none";

            customHeaders = customHeaders ?? new Dictionary<string, List<string>>();

            if (!customHeaders.ContainsKey(Accept))
            {
                customHeaders[Accept] = new List<string>() { AcceptValue };
            }

            return customHeaders;
        }

        private async Task<AzureOperationResponse<DocumentIndexResult>> DoIndexAsync<T>(
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            JsonSerializerSettings jsonSettings,
            CancellationToken cancellationToken)
        {
            var result =
                await Client.DocumentsProxy.IndexWithHttpMessagesAsync(
                    batch,
                    searchRequestOptions,
                    EnsureCustomHeaders(customHeaders),
                    cancellationToken,
                    requestSerializerSettings: jsonSettings).ConfigureAwait(false);

            if (result.Response.StatusCode == (HttpStatusCode)207)
            {
                HttpRequestMessage httpRequest = result.Request;
                HttpResponseMessage httpResponse = result.Response;

                // NOTE: It is not possible to read the http request's string content property here, 
                // via .NET framework's HttpClient, as the Content gets disposed as soon as the request is sent.
                // Thus the batch is re-serialized, which is what happens in the IndexWithHttpMessagesAsync() method
                // In .NET Core, the Content doesn't get disposed, so it's safe to read the string content here.
#if FullNetFx
                string requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(batch, jsonSettings);
#else
                string requestContent = await httpRequest.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var exception =
                    new IndexBatchException(result.Body)
                    {
                        Request = new HttpRequestMessageWrapper(httpRequest, requestContent),
                        Response = new HttpResponseMessageWrapper(httpResponse, responseContent)
                    };

                if (httpResponse.Headers.Contains("request-id"))
                {
                    exception.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
                }

                result.Dispose();
                throw exception;
            }

            return result;
        }

        private Task<AzureOperationResponse<DocumentSearchResult<T>>> DoContinueSearchAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken,
            JsonSerializerSettings deserializerSettings)
        {
            // Validate
            if (Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }

            Throw.IfArgumentNull(continuationToken, nameof(continuationToken));

            Guid? clientRequestId = searchRequestOptions?.ClientRequestId;

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>
                {
                    ["continuationToken"] = continuationToken,
                    ["clientRequestId"] = clientRequestId,
                    ["cancellationToken"] = cancellationToken
                };

                ServiceClientTracing.Enter(invocationId, this, "ContinueSearch", tracingParameters);
            }

            bool useGet = continuationToken.NextPageParameters == null;
            if (useGet)
            {
                return Client.DocumentsProxy.ContinueSearchGetWithHttpMessagesAsync<T>(
                    continuationToken.NextLink, 
                    clientRequestId, 
                    EnsureCustomHeaders(customHeaders), 
                    shouldTrace, 
                    invocationId, 
                    cancellationToken, 
                    responseDeserializerSettings: deserializerSettings);
            }
            else
            {
                return Client.DocumentsProxy.ContinueSearchPostWithHttpMessagesAsync<T>(
                    continuationToken.NextLink,
                    continuationToken.NextPageParameters,
                    clientRequestId,
                    EnsureCustomHeaders(customHeaders),
                    shouldTrace,
                    invocationId,
                    cancellationToken,
                    responseDeserializerSettings: deserializerSettings);
            }
        }

        private Task<AzureOperationResponse<DocumentSearchResult<T>>> DoSearchAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            JsonSerializerSettings deserializerSettings,
            CancellationToken cancellationToken)
        {
            searchText = searchText ?? "*";

            if (Client.UseHttpGetForQueries)
            {
                return Client.DocumentsProxy.SearchGetWithHttpMessagesAsync<T>(
                    searchText,
                    searchParameters,
                    searchRequestOptions,
                    EnsureCustomHeaders(customHeaders),
                    cancellationToken,
                    responseDeserializerSettings: deserializerSettings);
            }
            else
            {
                return Client.DocumentsProxy.SearchPostWithHttpMessagesAsync<T>(
                    (searchParameters ?? new SearchParameters()).ToRequest(searchText),
                    searchRequestOptions,
                    EnsureCustomHeaders(customHeaders),
                    cancellationToken,
                    responseDeserializerSettings: deserializerSettings);
            }
        }

        private Task<AzureOperationResponse<DocumentSuggestResult<T>>> DoSuggestAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions,
            Dictionary<string, List<string>> customHeaders,
            JsonSerializerSettings deserializerSettings,
            CancellationToken cancellationToken)
        {
            suggestParameters = suggestParameters ?? new SuggestParameters();

            if (Client.UseHttpGetForQueries)
            {
                return Client.DocumentsProxy.SuggestGetWithHttpMessagesAsync<T>(
                    searchText,
                    suggesterName,
                    suggestParameters.EnsureSelect(),
                    searchRequestOptions,
                    EnsureCustomHeaders(customHeaders),
                    cancellationToken,
                    responseDeserializerSettings: deserializerSettings);
            }
            else
            {
                return Client.DocumentsProxy.SuggestPostWithHttpMessagesAsync<T>(
                    suggestParameters.ToRequest(searchText, suggesterName),
                    searchRequestOptions,
                    EnsureCustomHeaders(customHeaders),
                    cancellationToken,
                    responseDeserializerSettings: deserializerSettings);
            }
        }
    }
}
