// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ServiceModel.Rest.Core;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class Adapters
    {
        internal class ToPipelineEnumerator : PipelineEnumerator
        {
            private HttpMessage _message;
            private ReadOnlyMemory<HttpPipelinePolicy> _policies;
            public ToPipelineEnumerator(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> policies)
            {
                _message = message;
                _policies = policies;
            }

            public override bool ProcessNext()
            {
                var first = _policies.Span[0];
                _policies = _policies.Slice(1);
                first.Process(_message, _policies);
                return _policies.Length > 0;
            }

            public async override ValueTask<bool> ProcessNextAsync()
            {
                var first = _policies.Span[0];
                _policies = _policies.Slice(1);
                await first.ProcessAsync(_message, _policies).ConfigureAwait(false);
                return _policies.Length > 0;
            }
        }

        internal class ToHttpPipelinePolicy : HttpPipelinePolicy
        {
            private IPipelinePolicy<PipelineMessage> _policy;

            public ToHttpPipelinePolicy(IPipelinePolicy<PipelineMessage> policy)
                => _policy = policy;

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var adapter = new ToPipelineEnumerator(message, pipeline);
                _policy.Process(message, adapter);
            }

            public async override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var adapter = new ToPipelineEnumerator(message, pipeline);
                await _policy.ProcessAsync(message, adapter).ConfigureAwait(false);
            }
        }
    }
}
