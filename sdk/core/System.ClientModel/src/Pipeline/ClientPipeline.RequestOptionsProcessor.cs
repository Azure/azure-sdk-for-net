// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

public partial class ClientPipeline
{
    /// <summary>
    /// Pipeline processor to advance through policies for pipeline customized
    /// per-request by passing RequestOptions to a protocol method.
    /// </summary>
    internal class RequestOptionsProcessor : IReadOnlyList<PipelinePolicy>
    {
        private readonly int _perCallIndex;
        private readonly int _perTryIndex;
        private readonly int _beforeTransportIndex;
        private readonly int _length;

        // Original client-scope pipeline.
        private readonly ReadOnlyMemory<PipelinePolicy> _fixedPolicies;

        // Custom per-call policies used for the scope of the method invocation.
        private readonly ReadOnlyMemory<PipelinePolicy> _customPerCallPolicies;

        // Custom per-try policies used for the scope of the method invocation.
        private readonly ReadOnlyMemory<PipelinePolicy> _customPerTryPolicies;

        // Custom per-try policies used for the scope of the method invocation.
        private readonly ReadOnlyMemory<PipelinePolicy> _customBeforeTransportPolicies;

        private PolicyEnumerator? _enumerator;

        public RequestOptionsProcessor(
            ReadOnlyMemory<PipelinePolicy> fixedPolicies,
            ReadOnlyMemory<PipelinePolicy> perCallPolicies,
            ReadOnlyMemory<PipelinePolicy> perTryPolicies,
            ReadOnlyMemory<PipelinePolicy> beforeTransportPolicies,
            int perCallIndex,
            int perTryIndex,
            int beforeTransportIndex)
        {
            Debug.Assert(perCallIndex <= fixedPolicies.Length);
            Debug.Assert(perTryIndex <= fixedPolicies.Length);
            Debug.Assert(beforeTransportIndex <= fixedPolicies.Length);
            Debug.Assert(perCallIndex <= perTryIndex);
            Debug.Assert(perTryIndex <= beforeTransportIndex);

            _fixedPolicies = fixedPolicies;
            _customPerCallPolicies = perCallPolicies;
            _customPerTryPolicies = perTryPolicies;
            _customBeforeTransportPolicies = beforeTransportPolicies;

            _perCallIndex = perCallIndex;
            _perTryIndex = perTryIndex;
            _beforeTransportIndex = beforeTransportIndex;

            _length = _fixedPolicies.Length +
                _customPerCallPolicies.Length +
                _customPerTryPolicies.Length +
                _customBeforeTransportPolicies.Length;
        }

        public PipelinePolicy this[int index]
        {
            get
            {
                TryGetPolicy(index, out PipelinePolicy policy);
                return policy;
            }
        }

        public int Count => _length;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator ??= new(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// This custom pipeline is divided into seven segments by the per-call,
        /// per-try, and before-transport indexes:
        ///
        /// [FixedPerCall] [CustomPerCall][FixedPerTry] [CustomPerTry][FixedPerTransport] [CustomBeforeTransport][Transport]
        ///               ^_perCallIndex               ^_perTryIndex                     ^_beforeTransport
        ///
        /// This method returns the next policy in the customized pipeline
        /// sequence and maintains state by incrementing the _current counter
        /// after each "next policy" is returned.
        /// </summary>
        private bool TryGetPolicy(int index, out PipelinePolicy policy)
        {
            if (TryGetFixedPerCallPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetCustomPerCallPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetFixedPerTryPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetCustomPerTryPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetFixedPerTransportPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetCustomBeforeTransportPolicy(index, out policy))
            {
                return true;
            }

            if (TryGetFixedTransportPolicy(index, out policy))
            {
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerCallPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perCallIndex)
            {
                policy = _fixedPolicies.Span[index];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetCustomPerCallPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perCallIndex + _customPerCallPolicies.Length)
            {
                policy = _customPerCallPolicies.Span[index - _perCallIndex];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerTryPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perTryIndex + _customPerCallPolicies.Length)
            {
                policy = _fixedPolicies.Span[index - _customPerCallPolicies.Length];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetCustomPerTryPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perTryIndex +
                           _customPerCallPolicies.Length +
                           _customPerTryPolicies.Length)
            {
                policy = _customPerTryPolicies.Span[index - (_perTryIndex + _customPerCallPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerTransportPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perTryIndex + _customPerCallPolicies.Length + _customPerTryPolicies.Length)
            {
                policy = _fixedPolicies.Span[index - (_customPerCallPolicies.Length + _customPerTryPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetCustomBeforeTransportPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _perTryIndex +
                           _customPerCallPolicies.Length +
                           _customPerTryPolicies.Length +
                           _customBeforeTransportPolicies.Length)
            {
                policy = _customBeforeTransportPolicies.Span[index - (_beforeTransportIndex + _customPerCallPolicies.Length + _customPerTryPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedTransportPolicy(int index, out PipelinePolicy policy)
        {
            if (index < _length)
            {
                policy = _fixedPolicies.Span[index - (_customPerCallPolicies.Length + _customPerTryPolicies.Length + _customBeforeTransportPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }
    }
}
