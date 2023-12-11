// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class AzureCorePipelineProcessor : IEnumerable<PipelinePolicy>
    {
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;

        private readonly PolicyEnumerator _enumerator;

        public AzureCorePipelineProcessor(ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _policies = policies;
            _enumerator = new PolicyEnumerator(policies);
        }

        public ReadOnlyMemory<HttpPipelinePolicy> Policies => _policies;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator;

        IEnumerator IEnumerable.GetEnumerator()
            => _enumerator;

        private class PolicyEnumerator : IEnumerator<PipelinePolicy>
        {
            private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
            private int _current;

            public PolicyEnumerator(ReadOnlyMemory<HttpPipelinePolicy> policies)
            {
                _policies = policies;
                _current = -1;
            }
            public PolicyEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                _current++;
                return _current < _policies.Length;
            }

            public PipelinePolicy Current => _policies.Span[_current];

            object IEnumerator.Current => Current;

            public void Reset()
            {
                _current = 0;
            }

            public void Dispose() { }
        }

        //private class PipelinePolicyAdapter : PipelinePolicy
        //{
        //    private readonly IEnumerable<PipelinePolicy> _pipeline;
        //    private readonly HttpPipelinePolicy _policy;

        //    public PipelinePolicyAdapter(HttpPipelinePolicy policy, IEnumerable<PipelinePolicy> pipeline)
        //    {
        //        _policy = policy;
        //        _pipeline = pipeline;
        //    }

        //    public override void Process(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
        //    {
        //        _policy.Process(message, new AzureCorePipelineEnumerable)
        //    }

        //    public override ValueTask ProcessAsync(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public bool ProcessNext()
        //{
        //    if (_policies.Length == 0)
        //    {
        //        return false;
        //    }

        //    _policies.Span[0].Process(_message, _policies.Slice(1));

        //    return _policies.Length > 0;
        //}

        //public async ValueTask<bool> ProcessNextAsync()
        //{
        //    if (_policies.Length == 0)
        //    {
        //        return false;
        //    }

        //    await _policies.Span[0].ProcessAsync(_message, _policies.Slice(1)).ConfigureAwait(false);

        //    return _policies.Length > 0;
        //}
    }
}
