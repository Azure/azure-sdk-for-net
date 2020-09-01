// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class CloudShellAuthRequestBuilder : IAuthRequestBuilder
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _clientId;

        public CloudShellAuthRequestBuilder(HttpPipeline pipeline, Uri endpoint, string clientId)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
            _clientId = clientId;
        }

        public Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(_endpoint);

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(_clientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(_clientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();
            request.Content = RequestContent.Create(content);
            return request;
        }
    }
}
