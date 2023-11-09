// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel.Core;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class AzureCorePipelineProcessor : PipelineProcessor
    {
        private readonly HttpMessage _message;
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;

        public AzureCorePipelineProcessor(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _policies = policies;
            _message = message;
        }

        public override int Length => _policies.Length;

        public override bool ProcessNext()
        {
            _policies.Span[0].Process(_message, _policies.Slice(1));
            return true;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            await _policies.Span[0].ProcessAsync(_message, _policies.Slice(1)).ConfigureAwait(false);
            return true;
        }
    }
}
