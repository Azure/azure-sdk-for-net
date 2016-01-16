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

namespace Microsoft.Azure.Search
{
    internal partial class DocumentOperations
    {
        public async Task<DocumentIndexResponse> IndexAsync(IndexBatch batch, CancellationToken cancellationToken)
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            string payload = JsonUtility.SerializeObject(batch, JsonUtility.DocumentSerializerSettings);
            return await DoIndexAsync(payload, cancellationToken).ConfigureAwait(false);
        }

        public async Task<DocumentIndexResponse> IndexAsync<T>(
            IndexBatch<T> batch, 
            CancellationToken cancellationToken) where T : class
        {
            if (batch == null)
            {
                throw new ArgumentNullException("batch");
            }

            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType<T>();
            string payload = JsonUtility.SerializeObject(batch, JsonUtility.CreateSerializerSettings<T>(useCamelCase));

            return await DoIndexAsync(payload, cancellationToken).ConfigureAwait(false);
        }

        private async Task<DocumentIndexResponse> DoIndexAsync(string payload, CancellationToken cancellationToken)
        {
            // Validate
            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("payload", payload);
                TracingAdapter.Enter(invocationId, this, "IndexAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "docs/search.index?api-version=2015-02-28";
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
                httpRequest.Method = HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/json;odata.metadata=none");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);

                // Serialize Request
                string requestContent = payload;
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

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
                    if (statusCode != HttpStatusCode.OK && statusCode != (HttpStatusCode)207)
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
                    DocumentIndexResponse result = null;
                    
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DocumentIndexResponse();
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        var deserializedResult = 
                            JsonUtility.DeserializeObject<DocumentIndexResponsePayload>(
                                responseContent, 
                                new JsonSerializerSettings());
                        
                        result.Results = new LazyList<IndexResult>(deserializedResult.Value);
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

                    if (result.StatusCode == (HttpStatusCode)207)
                    {
                        CloudException ex = new IndexBatchException(httpRequest, httpResponse, result);
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
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

        private class DocumentIndexResponsePayload
        {
            public List<IndexResult> Value { get; set; }
        }
    }
}
