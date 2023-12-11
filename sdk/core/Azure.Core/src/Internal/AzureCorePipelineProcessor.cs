// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    internal class AzureCorePipelineProcessor : IEnumerable<PipelinePolicy>
    {
        private readonly PolicyEnumerator _enumerator;

        public AzureCorePipelineProcessor(ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _enumerator = new PolicyEnumerator(policies);
        }

        public ReadOnlyMemory<HttpPipelinePolicy> Policies
            => _enumerator.Policies;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator;

        IEnumerator IEnumerable.GetEnumerator()
            => _enumerator;

        //private class PolicyEnumerator : IEnumerator<PipelinePolicy>
        //{
        //    private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
        //    private int _current;

        //    public PolicyEnumerator(ReadOnlyMemory<HttpPipelinePolicy> policies)
        //    {
        //        _policies = policies;
        //        _current = -1;
        //    }

        //    public ReadOnlyMemory<HttpPipelinePolicy> Policies
        //        => _policies.Slice(_current);

        //    public PolicyEnumerator GetEnumerator() => this;

        //    public bool MoveNext()
        //    {
        //        _current++;
        //        return _current < _policies.Length;
        //    }

        //    public PipelinePolicy Current => _policies.Span[_current];

        //    object IEnumerator.Current => Current;

        //    public void Reset()
        //    {
        //        _current = 0;
        //    }

        //    public void Dispose() { }
        //}

        private class PolicyEnumerator : IEnumerator<PipelinePolicy>
        {
            //private readonly ReadOnlyMemory<HttpPipelinePolicy> _original;
            private ReadOnlyMemory<HttpPipelinePolicy> _policies;

            private bool _first = true;

            public PolicyEnumerator(ReadOnlyMemory<HttpPipelinePolicy> policies)
            {
                //_original = policies;
                _policies = policies;
            }

            public ReadOnlyMemory<HttpPipelinePolicy> Policies => _policies;

            public PolicyEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                if (_first)
                {
                    _first = false;
                }
                else
                {
                    _policies = _policies.Slice(1);
                }

                return _policies.Length > 0;
            }

            public PipelinePolicy Current => _policies.Span[0];

            object IEnumerator.Current => Current;

            public void Reset()
                => throw new NotSupportedException("Reset operation is not supported for PolicyEnumerator.");

            public void Dispose() { }
        }
    }
}
