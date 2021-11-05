// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public class PipelineTestBase
    {
        private readonly bool _isAsync;

        public PipelineTestBase(bool isAsync)
        {
            _isAsync = isAsync;
        }

        protected async Task<Response> ExecuteRequest(Request request, HttpPipelineTransport transport, CancellationToken cancellationToken = default)
        {
            var message = new HttpMessage(request, new ResponseClassifier());
            message.CancellationToken = cancellationToken;
            if (_isAsync)
            {
                await transport.ProcessAsync(message);
            }
            else
            {
                transport.Process(message);
            }
            return message.Response;
        }

        protected async Task<Response> ExecuteRequest(Request request, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            var message = new HttpMessage(request, new ResponseClassifier());
            return await ExecuteRequest(message, pipeline, cancellationToken);
        }

        protected async Task<Response> ExecuteRequest(HttpMessage message, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            if (_isAsync)
            {
                await pipeline.SendAsync(message, cancellationToken);
            }
            else
            {
                pipeline.Send(message, cancellationToken);
            }
            return message.Response;
        }
    }
}
