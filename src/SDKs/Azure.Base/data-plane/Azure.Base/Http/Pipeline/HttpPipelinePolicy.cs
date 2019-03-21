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
        public abstract Task ProcessAsync(HttpPipelineContext pipelineContext, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        protected HttpPipelineEventSource Log = HttpPipelineEventSource.Singleton;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static async Task ProcessNextAsync(ReadOnlyMemory<HttpPipelinePolicy> pipeline, HttpPipelineContext pipelineContext)
        {
            if (pipeline.IsEmpty) throw new InvalidOperationException("last policy in the pipeline must be a transport"); 
            var next = pipeline.Span[0];
            await next.ProcessAsync(pipelineContext, pipeline.Slice(1)).ConfigureAwait(false);
        }
    }
}
