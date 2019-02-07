// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Http.Pipeline
{
    public abstract class PipelineTransport : PipelinePolicy
    {
        public abstract Task ProcessAsync(HttpMessage message);

        public abstract HttpMessage CreateMessage(PipelineOptions options, CancellationToken cancellation);

        public sealed override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<PipelinePolicy> next)
        {
            if (next.Length == 0) await ProcessAsync(message).ConfigureAwait(false);
            else throw new ArgumentOutOfRangeException(nameof(next));
        }
    }
}
