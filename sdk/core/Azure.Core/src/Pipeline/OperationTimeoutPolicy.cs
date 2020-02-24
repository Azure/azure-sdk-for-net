// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class OperationTimeoutPolicy: HttpPipelinePolicy
    {
        private readonly TimeSpan _operationTimeout;

        public OperationTimeoutPolicy(TimeSpan operationTimeout)
        {
            _operationTimeout = operationTimeout;
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
            CancellationToken oldToken = message.CancellationToken;
            CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);
            cts.CancelAfter(_operationTimeout);
            try
            {
                message.CancellationToken = cts.Token;
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
            finally
            {
                message.CancellationToken = oldToken;
                cts.Dispose();
            }
        }
    }
}