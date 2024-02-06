// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Adapter from an Azure.Core pipeline to a System.ClientModel pipeline.
    /// Azure.Core policies take <see cref="ReadOnlyMemory{HttpPipelinePolicy}"/>
    /// as the pipeline parameter of their <see cref="HttpPipelinePolicy.Process(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/>
    /// methods.  System.ClientModel policies take  <see cref="IReadOnlyList{PipelinePolicy}"/>.
    ///
    /// This type allows Azure.Core policies such as <see cref="RetryPolicy"/> to
    /// hold System.ClientModel policies internally and call their process methods
    /// in a way that will continue passing control down the chain of policies.
    /// </summary>
    internal struct ClientModelPolicyCollectionAdapter : IReadOnlyList<PipelinePolicy>
    {
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
        private PolicyEnumerator? _enumerator;

        public ClientModelPolicyCollectionAdapter(ReadOnlyMemory<HttpPipelinePolicy> policies)
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
