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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search
{
    internal partial class DocumentOperations
    {
        internal static readonly string[] SelectAll = new[] { "*" };

        public Task<DocumentGetResponse> GetAsync(
            string key,
            IEnumerable<string> selectedFields, 
            CancellationToken cancellationToken)
        {
            return DoGetAsync<DocumentGetResponse, Document>(
                key,
                selectedFields,
                cancellationToken,
                s => JsonUtility.DeserializeObject<Document>(s, JsonUtility.DocumentDeserializerSettings));
        }

        public Task<DocumentGetResponse<T>> GetAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            CancellationToken cancellationToken) where T : class
        {
            JsonSerializerSettings jsonSettings = JsonUtility.CreateTypedDeserializerSettings<T>();
            return DoGetAsync<DocumentGetResponse<T>, T>(
                key,
                selectedFields,
                cancellationToken,
                s => JsonUtility.DeserializeObject<T>(s, jsonSettings));
        }

        private async Task<TResponse> DoGetAsync<TResponse, TDoc>(
            string key, 
            IEnumerable<string> selectedFields, 
            CancellationToken cancellationToken,
            Func<string, TDoc> deserialize)
            where TResponse : DocumentGetResponseBase<TDoc>, new()
            where TDoc : class
        {
            // Validate
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (selectedFields == null)
            {
                throw new ArgumentNullException("selectedFields");
            }

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("key", key);
                tracingParameters.Add("selectedFields", selectedFields);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }

            // Construct URL
            if (!selectedFields.Any())
            {
                selectedFields = SelectAll;
            }

            string selectClause = String.Join(",", selectedFields);
            string url = 
                String.Format("docs('{0}')?$select={1}&api-version=2015-02-28", key, Uri.EscapeDataString(selectClause));
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
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);

                // Set Headers
                httpRequest.Headers.Add("Accept", "application/json;odata.metadata=none");

                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);

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
                        result.Document = deserialize(responseContent);
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
    }
}
