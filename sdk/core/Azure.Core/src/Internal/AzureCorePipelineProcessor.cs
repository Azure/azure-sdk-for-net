// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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

        public override bool ProcessNext()
        {
            if (_policies.Length == 0)
            {
                return false;
            }

            _policies.Span[0].Process(_message, _policies.Slice(1));

            return _policies.Length > 0;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            if (_policies.Length == 0)
            {
                return false;
            }

            await _policies.Span[0].ProcessAsync(_message, _policies.Slice(1)).ConfigureAwait(false);

            return _policies.Length > 0;
        }
    }
}
