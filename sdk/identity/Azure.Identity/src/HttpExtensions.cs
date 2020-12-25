// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Azure.Core;

namespace Azure.Identity
{
    internal static class HttpExtensions
    {
        public static async Task<Request> ToPipelineRequestAsync(this HttpRequestMessage request, HttpPipeline pipeline)
        {
            Request pipelineRequest = pipeline.CreateRequest();

            pipelineRequest.Method = RequestMethod.Parse(request.Method.Method);

            pipelineRequest.Uri.Reset(request.RequestUri);

            pipelineRequest.Content = await request.Content.ToPipelineRequestContentAsync().ConfigureAwait(false);

            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IEnumerable<string>> header in request.Headers)
            {
                foreach (var value in header.Value)
                {
                    pipelineRequest.Headers.Add(header.Key, value);
                }
            }

            return pipelineRequest;
        }

        private static void AddHeader(HttpResponseMessage request, HttpHeader header)
        {
            if (request.Headers.TryAddWithoutValidation(header.Name, header.Value))
            {
                return;
            }

            if (!request.Content.Headers.TryAddWithoutValidation(header.Name, header.Value))
            {
                throw new InvalidOperationException("Unable to add header to request or content");
            }
        }

        public static HttpResponseMessage ToHttpResponseMessage(this Response response)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)response.Status,

                Content = new StreamContent(response.ContentStream)
            };

            foreach (HttpHeader header in response.Headers)
            {
                if (!responseMessage.Headers.TryAddWithoutValidation(header.Name, header.Value))
                {
                    if (!responseMessage.Content.Headers.TryAddWithoutValidation(header.Name, header.Value))
                    {
                        throw new InvalidOperationException("Unable to add header to request or content");
                    }
                }
            }

            return responseMessage;
        }

        public static async Task<RequestContent> ToPipelineRequestContentAsync(this HttpContent content)
        {
            if (content != null)
            {
                return RequestContent.Create(await content.ReadAsStreamAsync().ConfigureAwait(false));
            }

            return null;
        }

    }
}
