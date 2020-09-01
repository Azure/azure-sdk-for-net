// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class ImdsAuthRequestBuilder : IAuthRequestBuilder
    {
        private const string ImdsApiVersion = "2018-02-01";

        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _clientId;

        public ImdsAuthRequestBuilder(HttpPipeline pipeline, Uri endpoint, string clientId)
        {
            _pipeline = pipeline;
            _clientId = clientId;
            _endpoint = endpoint;
        }

        public Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Headers.Add("Metadata", "true");
            request.Uri.Reset(_endpoint);
            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery("client_id", _clientId);
            }

            return request;
        }
    }
}
