﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SyncAsyncPolicyTestBase : SyncAsyncTestBase
    {
        public SyncAsyncPolicyTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected Task<Response> SendRequestAsync(HttpPipeline pipeline, Request request, bool bufferResponse = true, CancellationToken cancellationToken = default)
        {
            return IsAsync ? pipeline.SendRequestAsync(request, bufferResponse, cancellationToken) : Task.FromResult(pipeline.SendRequest(request, bufferResponse, cancellationToken));
        }

        protected async Task<Response> SendRequestAsync(HttpPipelineTransport transport, Request request, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true)
        {
            await Task.Yield();

            var pipeline = new HttpPipeline(transport, new [] { policy }, responseClassifier);
            return await SendRequestAsync(pipeline, request, bufferResponse, CancellationToken.None);
        }

        protected async Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true)
        {
            using Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.UriBuilder.Uri = new Uri("http://example.com");
            return await SendRequestAsync(transport, request, policy, responseClassifier, bufferResponse);
        }
    }
}
