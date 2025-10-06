// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity.Broker.Tests
{
    public class PopTestClient
    {
        internal readonly HttpPipeline _pipeline;

        protected PopTestClient() { }
        public PopTestClient(TokenCredential credential, ClientOptions options = null)
        {
            options ??= new PopClientOptions();
            var pipelineOptions = new HttpPipelineOptions(options);
            pipelineOptions.PerRetryPolicies.Add(new PopTokenAuthenticationPolicy(credential, "https://graph.microsoft.com/.default"));
            _pipeline = HttpPipelineBuilder.Build(
                pipelineOptions);
        }

        [ForwardsClientCalls(true)]
        public async virtual ValueTask<Response> GetAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            using Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(uri);
            var response = await _pipeline.SendRequestAsync(request, cancellationToken);
            return response;
        }

        [ForwardsClientCalls(true)]
        public virtual Response Get(Uri uri, CancellationToken cancellationToken = default)
        {
            using Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(uri);
            var response = _pipeline.SendRequest(request, cancellationToken);
            return response;
        }
    }
}
