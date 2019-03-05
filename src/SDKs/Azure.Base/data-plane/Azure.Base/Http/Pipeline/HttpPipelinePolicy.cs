// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Diagnostics;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelinePolicy
    {
        public abstract Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected internal static async Task ProcessNextAsync(ReadOnlyMemory<HttpPipelinePolicy> pipeline, HttpMessage message)
        {
            var next = pipeline.Span[0];
            await next.ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
        }

        protected HttpPipelineEventSource Log = HttpPipelineEventSource.Singleton;
    }
}
