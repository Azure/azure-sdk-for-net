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
        public readonly int First => -1;

        private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
        private PolicyEnumerator? _enumerator;

        public AzureCorePipelineProcessor(ReadOnlyMemory<HttpPipelinePolicy> policies)
            => _policies = policies;

        public ReadOnlyMemory<HttpPipelinePolicy> Policies
            => _policies;

        public PipelinePolicy this[int index] => _policies.Span[index];

        public int Count => _policies.Length;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator ??= new(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

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

            public bool MoveNext() => ++_current < _policies.Count;

            public void Reset() => _current = -1;

            public void Dispose() { }
        }
    }
}
