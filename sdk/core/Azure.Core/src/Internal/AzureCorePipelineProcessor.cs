// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    internal struct AzureCorePipelineProcessor : IReadOnlyList<PipelinePolicy>
    {
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
        private readonly PolicyEnumerator _enumerator;

        public AzureCorePipelineProcessor(ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _policies = policies;
            _enumerator = new(this);

            // Automatically advance the enumerator given the expectation of
            // HttpPipelinePolicy.Process that the first policy will be the one
            // after the policy whose Process method is currently being called.
            _enumerator.MoveNext();
        }

        public ReadOnlyMemory<HttpPipelinePolicy> Policies
            => _policies;

        public PipelinePolicy this[int index] => _policies.Span[index];

        public int Count => _policies.Length;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator;

        IEnumerator IEnumerable.GetEnumerator()
            => _enumerator;

        private class PolicyEnumerator : IEnumerator<PipelinePolicy>
        {
            private readonly IReadOnlyList<PipelinePolicy> _policies;
            private int _current;

            public PolicyEnumerator(IReadOnlyList<PipelinePolicy> policies)
            {
                _policies = policies;
                _current = -1;
            }

            public PipelinePolicy Current
            {
                get
                {
                    if (_current >= 0 && _current < _policies.Count)
                    {
                        return _policies[_current];
                    }

                    return null!;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext() => _current++ < _policies.Count;

            public void Reset() => _current = -1;

            public void Dispose() { }
        }
    }
}
