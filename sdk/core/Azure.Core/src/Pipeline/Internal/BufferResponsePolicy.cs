// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class BufferResponsePolicy : HttpPipelinePolicy
    {
        protected BufferResponsePolicy()
        {
        }

        public static HttpPipelinePolicy Shared { get; set; } = new BufferResponsePolicy();

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

            if (message.BufferResponse)
            {
                await BufferResponse(message, true).ConfigureAwait(false);
            }
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);

            if (message.BufferResponse)
            {
                BufferResponse(message, false).EnsureCompleted();
            }
        }

        private static async ValueTask BufferResponse(HttpMessage message, bool async)
        {
            if (message.Response.ContentStream != null && !message.Response.ContentStream.CanSeek)
            {
                Stream responseContentStream = message.Response.ContentStream;
                var bufferedStream = new MemoryStream();
                if (async)
                {
                    await responseContentStream.CopyToAsync(bufferedStream).ConfigureAwait(false);
                }
                else
                {
                    responseContentStream.CopyTo(bufferedStream);
                }
                responseContentStream.Dispose();
                bufferedStream.Position = 0;
                message.Response.ContentStream = bufferedStream;
            }
        }
    }
}
