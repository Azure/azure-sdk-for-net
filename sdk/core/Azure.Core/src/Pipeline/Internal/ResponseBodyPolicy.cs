// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class ResponseBodyPolicy : HttpPipelinePolicy
    {
        private readonly TimeSpan _readTimeout;

        public ResponseBodyPolicy(TimeSpan readTimeout)
        {
            _readTimeout = readTimeout;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, pipeline, true).ConfigureAwait(false);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            Stream? responseContentStream = message.Response.ContentStream;
            if (responseContentStream == null || responseContentStream.CanSeek)
            {
                return;
            }

            if (message.BufferResponse)
            {
                var bufferedStream = new MemoryStream();
                if (async)
                {
                    await responseContentStream.CopyToAsync(bufferedStream, message.CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    responseContentStream.CopyTo(bufferedStream, message.CancellationToken);
                }

                responseContentStream.Dispose();
                bufferedStream.Position = 0;
                message.Response.ContentStream = bufferedStream;
            }
            else if (_readTimeout != Timeout.InfiniteTimeSpan)
            {
                message.Response.ContentStream = new ReadTimeoutStream(responseContentStream, _readTimeout);
            }
        }
    }
}