// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SyncAsyncPolicyTestBase : SyncAsyncTestBase
    {
        public SyncAsyncPolicyTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected async Task<Response> SendRequestAsync(HttpPipeline pipeline, Action<Request> requestAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
        {
            HttpMessage message = pipeline.CreateMessage();
            message.BufferResponse = bufferResponse;
            requestAction(message.Request);

            if (IsAsync)
            {
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                pipeline.Send(message, cancellationToken);
            }

            return message.Response;
        }

        protected async Task<Response> SendRequestAsync(HttpPipelineTransport transport, Action<Request> requestAction, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
        {
            await Task.Yield();

            var pipeline = new HttpPipeline(transport, new[] { policy }, responseClassifier);
            return await SendRequestAsync(pipeline, requestAction, bufferResponse, cancellationToken);
        }

        protected async Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true, Uri uri = null, CancellationToken cancellationToken = default)
        {
            return await SendRequestAsync(transport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(uri ?? new Uri("http://example.com"));
            }, policy, responseClassifier, bufferResponse, cancellationToken);
        }
    }
}
