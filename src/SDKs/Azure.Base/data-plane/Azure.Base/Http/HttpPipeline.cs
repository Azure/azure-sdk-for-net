// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Http
{
    public struct HttpPipeline
    {
        private readonly HttpPipelinePolicy _entryPolicy;
        private readonly HttpPipelineTransport _transportPolicy;

        public HttpPipeline(HttpPipelineTransport transportPolicy) : this()
        {
            _transportPolicy = transportPolicy;
            _entryPolicy = transportPolicy;
        }

        public HttpPipeline(HttpPipelineTransport transportPolicy, HttpPipelinePolicy entryPolicy)
        {
            _transportPolicy = transportPolicy;
            _entryPolicy = entryPolicy;
        }

        public HttpMessage CreateMessage(CancellationToken cancellation)
            => _transportPolicy.CreateMessage(cancellation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task SendMessageAsync(HttpMessage message)
        {
            if (_entryPolicy != null)
            {
                await _entryPolicy.ProcessAsync(message).ConfigureAwait(false);
            }
        }
    }
}

