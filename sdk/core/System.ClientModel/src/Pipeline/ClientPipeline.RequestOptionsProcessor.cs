// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class ClientPipeline
{
    /// <summary>
    /// Pipeline processor to advance through policies for pipeline customized
    /// per-request by passing RequestOptions to a protocol method.
    /// </summary>
    internal class RequestOptionsProcessor : PipelineProcessor
    {
        private readonly PipelineMessage _message;

        private readonly int _perCallIndex;
        private readonly int _perTryIndex;
        private readonly int _length;

        // Original client-scope pipeline.
        private readonly ReadOnlyMemory<PipelinePolicy> _fixedPolicies;

        // Custom per-call policies used for the scope of the method invocation.
        private readonly ReadOnlyMemory<PipelinePolicy> _customPerCallPolicies;

        // Custom per-try policies used for the scope of the method invocation.
        private readonly ReadOnlyMemory<PipelinePolicy> _customPerTryPolicies;

        private int _current;

        public RequestOptionsProcessor(PipelineMessage message,
            ReadOnlyMemory<PipelinePolicy> fixedPolicies,
            ReadOnlyMemory<PipelinePolicy> perCallPolicies,
            ReadOnlyMemory<PipelinePolicy> perTryPolicies,
            int perCallIndex,
            int perTryIndex)
        {
            if (perCallIndex > fixedPolicies.Length) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than pipeline length.");
            if (perTryIndex > fixedPolicies.Length) throw new ArgumentOutOfRangeException(nameof(perTryIndex), "perTryIndex cannot be greater than pipeline length.");
            if (perCallIndex > perTryIndex) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than perTryIndex.");

            _message = message;

            _fixedPolicies = fixedPolicies;
            _customPerCallPolicies = perCallPolicies;
            _customPerTryPolicies = perTryPolicies;

            _perCallIndex = perCallIndex;
            _perTryIndex = perTryIndex;

            _length = _fixedPolicies.Length + _customPerCallPolicies.Length + _customPerTryPolicies.Length;
        }

        public override bool ProcessNext()
        {
            if (TryGetNextPolicy(out PipelinePolicy next))
            {
                next.Process(_message, this);
                return true;
            }

            return false;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            if (TryGetNextPolicy(out PipelinePolicy next))
            {
                await next.ProcessAsync(_message, this).ConfigureAwait(false);
                return true;
            }

            return false;
        }

        /// <summary>
        /// This custom pipeline is divided into five segments by the per-call
        /// and per-try indexes:
        ///
        /// [FixedPerCall] [CustomPerCall][FixedPerTry] [CustomPerTry][FixedPerTransport]
        ///               ^_perCallIndex               ^_perTryIndex
        ///
        /// This method returns the next policy in the customized pipeline
        /// sequence and maintains state by incrementing the _current counter
        /// after each "next policy" is returned.
        /// </summary>
        private bool TryGetNextPolicy(out PipelinePolicy policy)
        {
            if (TryGetFixedPerCallPolicy(out policy))
            {
                return true;
            }

            if (TryGetCustomPerCallPolicy(out policy))
            {
                return true;
            }

            if (TryGetFixedPerTryPolicy(out policy))
            {
                return true;
            }

            if (TryGetCustomPerTryPolicy(out policy))
            {
                return true;
            }

            if (TryGetFixedPerTransportPolicy(out policy))
            {
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerCallPolicy(out PipelinePolicy policy)
        {
            if (_current < _perCallIndex)
            {
                policy = _fixedPolicies.Span[_current++];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetCustomPerCallPolicy(out PipelinePolicy policy)
        {
            if (_current < _perCallIndex + _customPerCallPolicies.Length)
            {
                policy = _customPerCallPolicies.Span[_current++ - _perCallIndex];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerTryPolicy(out PipelinePolicy policy)
        {
            if (_current < _perTryIndex + _customPerCallPolicies.Length)
            {
                policy = _fixedPolicies.Span[_current++ - _customPerCallPolicies.Length];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetCustomPerTryPolicy(out PipelinePolicy policy)
        {
            if (_current < _perTryIndex + _customPerCallPolicies.Length + _customPerTryPolicies.Length)
            {
                policy = _customPerTryPolicies.Span[_current++ - (_perTryIndex + _customPerCallPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }

        private bool TryGetFixedPerTransportPolicy(out PipelinePolicy policy)
        {
            if (_current < _length)
            {
                policy = _fixedPolicies.Span[_current++ - (_customPerCallPolicies.Length + _customPerTryPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }
    }
}
