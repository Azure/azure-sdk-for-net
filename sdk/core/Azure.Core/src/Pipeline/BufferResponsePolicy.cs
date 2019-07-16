// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class BufferResponsePolicy: HttpPipelinePolicy
    {
        protected BufferResponsePolicy()
        {
        }

        public static HttpPipelinePolicy Shared { get; set; } = new BufferResponsePolicy();

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            await BufferResponse(message, true).ConfigureAwait(false);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
            BufferResponse(message, false).EnsureCompleted();
        }

        private static async Task BufferResponse(HttpPipelineMessage message, bool async)
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
