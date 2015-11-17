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
        public Task<DocumentSuggestResponse> SuggestAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            CancellationToken cancellationToken)
        {
            return DoSuggestAsync<DocumentSuggestResponse, SuggestResult, Document>(
                searchText,
                suggesterName,
                suggestParameters,
                cancellationToken,
                DeserializeForSuggest);
        }

        public Task<DocumentSuggestResponse<T>> SuggestAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            CancellationToken cancellationToken) where T : class
        {
            return DoSuggestAsync<DocumentSuggestResponse<T>, SuggestResult<T>, T>(
                searchText,
                suggesterName,
                suggestParameters,
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

        private async Task<TResponse> DoSuggestAsync<TResponse, TResult, TDoc>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters, 
            CancellationToken cancellationToken,
            Func<string, DocumentSuggestResponsePayload<TResult, TDoc>> deserialize)
            where TResponse : DocumentSuggestResponseBase<TResult, TDoc>, new()
            where TResult : SuggestResultBase<TDoc>
            where TDoc : class
        {
            // Validate
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

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("searchText", searchText);
                tracingParameters.Add("suggesterName", suggesterName);
                tracingParameters.Add("suggestParameters", suggestParameters);

                TracingAdapter.Enter(invocationId, this, "SuggestAsync", tracingParameters);
            }

            // Construct URL
            bool useGet = Client.UseHttpGetForQueries;
            const string ApiVersion = "api-version=2015-02-28";
            string url =
                useGet ?
                    String.Format(
                        "docs/search.suggest?search={0}&suggesterName={1}&{2}&{3}",
                        Uri.EscapeDataString(searchText),
                        suggesterName,
                        suggestParameters.ToString(),
                        ApiVersion) :
                    String.Format("docs/search.post.suggest?{0}", ApiVersion);
            
            string baseUrl = this.Client.BaseUri.AbsoluteUri;

            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

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
                    SuggestParametersPayload payload = suggestParameters.ToPayload(searchText, suggesterName);
                    string requestContent =
                        JsonUtility.SerializeObject(payload, JsonUtility.DefaultSerializerSettings);
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
                        DocumentSuggestResponsePayload<TResult, TDoc> deserializedResult = deserialize(responseContent);
                        result.Coverage = deserializedResult.Coverage;
                        result.Results = deserializedResult.Documents;
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
