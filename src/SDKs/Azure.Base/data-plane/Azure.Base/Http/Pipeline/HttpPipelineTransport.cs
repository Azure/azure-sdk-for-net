// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelineTransport : HttpPipelinePolicy
    {
        public abstract Task ProcessAsync(HttpPipelineMessage pipelineMessage);

        public abstract HttpPipelineRequest CreateRequest(IServiceProvider services);

        public sealed override async Task ProcessAsync(HttpPipelineMessage pipelineMessage, ReadOnlyMemory<HttpPipelinePolicy> next)
        {
            if (next.Length == 0) await ProcessAsync(pipelineMessage).ConfigureAwait(false);
            else throw new ArgumentOutOfRangeException(nameof(next));
        }
    }
}
