// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;
    using Rest;
    using Rest.Azure;
    using Serialization;

    internal class DocumentsOperations : IServiceOperations<SearchIndexClient>, IDocumentsOperations
    {
        internal static readonly string[] SelectAll = new[] { "*" };
        internal static readonly string Accept = "application/json;odata.metadata=none";
        internal static readonly string searchParameter = "search";

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

                SearchParameters searchParameters = SearchParameters.FromDictionary(parameters);

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
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);

            bool useGet = continuationToken.NextPageParameters == null;

            AzureOperationResponse<DocumentSearchResultProxy> response;

            if (useGet)
            {
                var parameters = ParseQueryParameters(continuationToken.NextLink);
                string searchText = parameters.ContainsKey("search") ? parameters["search"].First() : null;
                SearchParameters searchParameters = SearchParameters.FromDictionary(parameters);

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

        public async Task<AzureOperationResponse<Document>> GetWithHttpMessagesAsync(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentLookupResultProxy> response 
                = await this.Client.DocumentsProxy.LookupWithHttpMessagesAsync(
                    key,
                    selectedFields.ToList(),
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);

            return new AzureOperationResponse<Document>()
            {
                Body = response.Body.Document as Document,
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }

        public async Task<AzureOperationResponse<T>> GetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentLookupResultProxy> response
                = await this.Client.DocumentsProxy.LookupWithHttpMessagesAsync(
                    key,
                    selectedFields.ToList(),
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);

            return new AzureOperationResponse<T>()
            {
                Body = response.Body.Document as T,
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
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
                = await this.Client.DocumentsProxy.DocumentIndexWithHttpMessagesAsync(batch, searchRequestOptions, customHeaders, cancellationToken, requestSerializerSettings: serializationSettings).ConfigureAwait(false);

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
                = await this.Client.DocumentsProxy.DocumentIndexWithHttpMessagesAsync(batch, searchRequestOptions, customHeaders, cancellationToken, requestSerializerSettings: serializationSettings).ConfigureAwait(false);

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
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
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

        public async Task<AzureOperationResponse<DocumentSuggestResult>> SuggestWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateDocumentDeserializerSettings(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentSuggestResultProxy> response;

            if (Client.UseHttpGetForQueries)
            {
                response = await this.Client.DocumentsProxy.SuggestGetWithHttpMessagesAsync(
                    searchText,
                    suggesterName,
                    Accept,
                    suggestParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                SuggestParametersPayload request = suggestParameters.ToPayload(searchText, suggesterName);
                response = await this.Client.DocumentsProxy.SuggestPostWithHttpMessagesAsync(
                    request,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSuggestResult>()
            {
                Body = CreateDocumentSuggestResultFromProxy(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
        }


        public async Task<AzureOperationResponse<DocumentSuggestResult<T>>> SuggestWithHttpMessagesAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            JsonSerializerSettings deserializationSettings =
                JsonUtility.CreateTypedDeserializerSettings<T>(this.Client.DeserializationSettings);

            AzureOperationResponse<DocumentSuggestResultProxy> response;

            if (Client.UseHttpGetForQueries)
            {
                response = await this.Client.DocumentsProxy.SuggestGetWithHttpMessagesAsync(
                    searchText,
                    suggesterName,
                    Accept,
                    suggestParameters,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }
            else
            {
                SuggestParametersPayload request = suggestParameters.ToPayload(searchText, suggesterName);
                response = await this.Client.DocumentsProxy.SuggestPostWithHttpMessagesAsync(
                    request,
                    Accept,
                    searchRequestOptions,
                    customHeaders,
                    cancellationToken,
                    requestDeserializerSettings: deserializationSettings).ConfigureAwait(false);
            }

            return new AzureOperationResponse<DocumentSuggestResult<T>>()
            {
                Body = CreateTypedSuggestResultFromProxy<T>(response.Body),
                Request = response.Request,
                RequestId = response.RequestId,
                Response = response.Response
            };
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

        private static DocumentSuggestResult CreateDocumentSuggestResultFromProxy(DocumentSuggestResultProxy resultProxy)
        {
            return new DocumentSuggestResult()
            {
                Coverage = resultProxy.Coverage,
                Results = resultProxy.Results.Select(r => new SuggestResult() { Text = r.Text, Document = r.Document as Document }).ToArray(),
            };
        }

        private static DocumentSuggestResult<T> CreateTypedSuggestResultFromProxy<T>(DocumentSuggestResultProxy resultProxy)
            where T : class
        {
            return new DocumentSuggestResult<T>()
            {
                Coverage = resultProxy.Coverage,
                Results = resultProxy.Results.Select(r => new SuggestResult<T>() { Text = r.Text, Document = r.Document as T }).ToArray()
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

            var parameters = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

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
    }
}
