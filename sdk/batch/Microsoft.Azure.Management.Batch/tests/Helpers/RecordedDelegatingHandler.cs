// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Batch.Tests.Helpers
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        public HttpResponseMessage[] Responses;
        public HttpRequestMessage[] Requests;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response) : base()
        {
            Responses = new HttpResponseMessage[] { response };
            Requests = new HttpRequestMessage[1];
        }
        
        public RecordedDelegatingHandler(HttpResponseMessage[] responses) : base()
        {
            Responses = responses;
            Requests = new HttpRequestMessage[responses.Length];
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public HttpStatusCode SubsequentStatusCodeToReturn { get; set; }

        public string Request { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public HttpMethod Method { get; private set; }

        public Uri Uri { get; private set; }

        public bool IsPassThrough { get; set; }

        private int counter = 0;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Save the request - keep this is as a convenience since a number of tests already use this.
            if (Responses.Length == 1)
            {
                if (request.Content == null)
                {
                    Request = string.Empty;
                }
                else
                {
                    Request = await request.Content.ReadAsStringAsync();
                }
                RequestHeaders = request.Headers;
                if (request.Content != null)
                {
                    ContentHeaders = request.Content.Headers;
                }
                Method = request.Method;
                Requests[counter] = request;
                Uri = request.RequestUri;
            }
            else  // long running ops will use index based checks
            {
                Requests[counter] = request;
            }

            // Prepare response
            if (IsPassThrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                return Responses[counter++];
            }
        }
    }
    
    public class ResourceGroupNameHelpers
    {
        public static string GetResourceGroupName(string id)
        {
            var idParts = id.Split('/');
            for (int i = 0; i < idParts.Length; i++)
            {
                if (idParts[i].Equals("resourceGroupName", StringComparison.OrdinalIgnoreCase))
                {
                    return i == idParts.Length - 1 ? null : idParts[i + 1];
                }
            }

            return null;
        }
    }
}
