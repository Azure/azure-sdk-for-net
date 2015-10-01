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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Search
{
    internal partial class DocumentOperations
    {
        public Task<DocumentSearchResponse> SearchAsync(
            string searchText,
            SearchParameters searchParameters,
            CancellationToken cancellationToken)
        {
            return DoSearchAsync<DocumentSearchResponse, SearchResult, Document>(
                searchText,
                searchParameters,
                cancellationToken,
                DeserializeForSearch);
        }

        public Task<DocumentSearchResponse<T>> SearchAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            CancellationToken cancellationToken) where T : class
        {
            return DoSearchAsync<DocumentSearchResponse<T>, SearchResult<T>, T>(
                searchText,
                searchParameters,
                cancellationToken,
                DeserializeForSearch<T>);
        }

        private static DocumentSearchResponsePayload<SearchResult<T>, T> DeserializeForSearch<T>(string payload) 
            where T : class
        {
            return JsonUtility.DeserializeObject<DocumentSearchResponsePayload<SearchResult<T>, T>>(
                payload, 
                JsonUtility.CreateTypedDeserializerSettings<T>());
        }

        private static DocumentSearchResponsePayload<SearchResult, Document> DeserializeForSearch(string payload)
        {
            return JsonUtility.DeserializeObject<DocumentSearchResponsePayload<SearchResult, Document>>(
                payload, 
                JsonUtility.DocumentDeserializerSettings);
        }

        private Task<TResponse> DoSearchAsync<TResponse, TResult, TDoc>(
            string searchText,
            SearchParameters searchParameters,
            CancellationToken cancellationToken,
            Func<string, DocumentSearchResponsePayload<TResult, TDoc>> deserialize)
            where TResponse : DocumentSearchResponseBase<TResult, TDoc>, new()
            where TResult : SearchResultBase<TDoc>
            where TDoc : class
        {
            // Validate
            searchText = searchText ?? "*";

            if (searchParameters == null)
            {
                throw new ArgumentNullException("searchParameters");
            }

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("searchText", searchText);
                tracingParameters.Add("searchParameters", searchParameters);

                TracingAdapter.Enter(invocationId, this, "SearchAsync", tracingParameters);
            }

            // Construct URL
            bool useGet = Client.UseHttpGetForQueries;
            const string ApiVersion = "api-version=2015-02-28";
            string searchOption = "search=" + Uri.EscapeDataString(searchText);
            string url =
                useGet ?
                    String.Format("docs?{0}&{1}&{2}", searchOption, searchParameters.ToString(), ApiVersion) :
                    String.Format("docs/search.post.search?{0}", ApiVersion);
            
            string baseUrl = this.Client.BaseUri.AbsoluteUri;

            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            return DoContinueSearchAsync<TResponse, TResult, TDoc>(
                url,
                searchParameters.ToPayload(searchText),
                useGet,
                shouldTrace, 
                invocationId, 
                cancellationToken, 
                deserialize);
        }

        private async Task<TResponse> DoContinueSearchAsync<TResponse, TResult, TDoc>(
            string url,
            SearchParametersPayload searchParameters,
            bool useGet,
            bool shouldTrace,
            string invocationId,
            CancellationToken cancellationToken,
            Func<string, DocumentSearchResponsePayload<TResult, TDoc>> deserialize)
            where TResponse : DocumentSearchResponseBase<TResult, TDoc>, new()
            where TResult : SearchResultBase<TDoc>
            where TDoc : class
        {
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = useGet ? HttpMethod.Get : HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);

                // Set Headers
                httpRequest.Headers.Add("Accept", "application/json;odata.metadata=none");

                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);

                // Serialize Request for POST only
                if (!useGet)
                {
                    string requestContent =
                        JsonUtility.SerializeObject(searchParameters, JsonUtility.DefaultSerializerSettings);
                    httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                    httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                }

                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }

                    // Create Result
                    TResponse result = null;

                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new TResponse();
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        DocumentSearchResponsePayload<TResult, TDoc> deserializedResult = deserialize(responseContent);
                        result.Count = deserializedResult.Count;
                        result.Coverage = deserializedResult.Coverage;
                        result.Facets = deserializedResult.Facets;
                        result.Results = deserializedResult.Documents;
                        result.ContinuationToken =
                            deserializedResult.NextLink != null ?
                                new SearchContinuationToken(
                                    deserializedResult.NextLink, 
                                    deserializedResult.NextPageParameters) : 
                                null;
                    }

                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("request-id").FirstOrDefault();
                    }

                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }

                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }

        private class DocumentSearchResponsePayload<TResult, TDoc>
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

            [JsonProperty("@odata.nextLink")]
            public string NextLink { get; set; }

            [JsonProperty("@search.nextPageParameters")]
            public SearchParametersPayload NextPageParameters { get; set; }
        }
    }
}
