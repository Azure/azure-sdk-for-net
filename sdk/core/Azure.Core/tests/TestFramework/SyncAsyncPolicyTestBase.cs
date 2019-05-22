// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SyncAsyncPolicyTestBase
    {
        public bool IsAsync { get; }

        public SyncAsyncPolicyTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        protected MockTransport CreateMockTransport()
        {
            return new MockTransport()
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        protected MockTransport CreateMockTransport(params MockResponse[] responses)
        {
            return new MockTransport(responses)
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        protected Task<Response> SendRequestAsync(HttpPipeline pipeline, Request request, CancellationToken cancellationToken = default)
        {
            return IsAsync ? pipeline.SendRequestAsync(request, cancellationToken) : Task.FromResult(pipeline.SendRequest(request, cancellationToken));
        }

        protected async Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null)
        {
            await Task.Yield();

            using (Request request = transport.CreateRequest(null))
            {
                request.Method = HttpPipelineMethod.Get;
                request.UriBuilder.Uri = new Uri("http://example.com");
                var pipeline = TestPipelineFactory.Create(transport, responseClassifier, policy);
                return await SendRequestAsync(pipeline, request, CancellationToken.None);
            }
        }
    }
}
