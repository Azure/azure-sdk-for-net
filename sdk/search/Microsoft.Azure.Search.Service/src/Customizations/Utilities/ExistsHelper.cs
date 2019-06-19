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
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Rest;

    internal static class ExistsHelper
    {
        public static async Task<AzureOperationResponse<bool>> ExistsFromGetResponse<T>(
            Func<Task<AzureOperationResponse<T>>> invokeGet)
        {
            var response = new AzureOperationResponse<bool>();

            try
            {
                // Get validates indexName.
                AzureOperationResponse<T> getResponse = await invokeGet().ConfigureAwait(false);
                response.Body = true;
                response.Request = getResponse.Request;
                response.RequestId = getResponse.RequestId;
                response.Response = getResponse.Response;
                return response;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    response.Body = false;
                    response.Request = CopyRequest(e.Request);
                    response.Response = CopyResponse(e.Response);

                    if (e.Response.Headers.ContainsKey("request-id"))
                    {
                        response.RequestId = e.Response.Headers["request-id"].FirstOrDefault();
                    }

                    return response;
                }

                throw;
            }
        }

        private static HttpRequestMessage CopyRequest(HttpRequestMessageWrapper requestWrapper)
        {
            var request = new HttpRequestMessage(requestWrapper.Method, requestWrapper.RequestUri);
            request.Content = CopyContent(requestWrapper);
            CopyHeaders(requestWrapper, request.Headers);
            CopyProperties(requestWrapper, request);
            return request;
        }

        private static HttpResponseMessage CopyResponse(HttpResponseMessageWrapper responseWrapper)
        {
            var response = new HttpResponseMessage(responseWrapper.StatusCode);
            response.Content = CopyContent(responseWrapper);
            CopyHeaders(responseWrapper, response.Headers);
            response.ReasonPhrase = responseWrapper.ReasonPhrase;
            return response;
        }

        private static StringContent CopyContent(HttpMessageWrapper source)
        {
            return new StringContent(source.Content ?? String.Empty);
        }

        private static void CopyHeaders(HttpMessageWrapper source, HttpHeaders headers)
        {
            var sourceHeaders = source.Headers ?? Enumerable.Empty<KeyValuePair<string, IEnumerable<string>>>();

            foreach (KeyValuePair<string, IEnumerable<string>> header in sourceHeaders)
            {
                string headerName = header.Key;
                foreach (string headerValue in header.Value)
                {
                    headers.TryAddWithoutValidation(headerName, headerValue);
                }
            }
        }

        private static void CopyProperties(HttpRequestMessageWrapper source, HttpRequestMessage target)
        {
            var sourceProperties = source.Properties ?? Enumerable.Empty<KeyValuePair<string, object>>();
            foreach (KeyValuePair<string, object> property in sourceProperties)
            {
                target.Properties.Add(property.Key, property.Value);
            }
        }
    }
}
