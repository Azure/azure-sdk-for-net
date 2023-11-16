// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives.Pipeline;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal struct AzureCorePipelineEnumerator : IPipelineEnumerator
    {
        private readonly HttpMessage _message;
        private ReadOnlyMemory<HttpPipelinePolicy> _policies;

        public AzureCorePipelineEnumerator(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _policies = policies;
            _message = message;
        }

        public int Length => _policies.Length;

        public bool ProcessNext()
        {
            _policies.Span[0].Process(_message, _policies.Slice(1));
            return true;
        }

        public async ValueTask<bool> ProcessNextAsync()
        {
            await _policies.Span[0].ProcessAsync(_message, _policies.Slice(1)).ConfigureAwait(false);
            return true;
        }
    }
}
