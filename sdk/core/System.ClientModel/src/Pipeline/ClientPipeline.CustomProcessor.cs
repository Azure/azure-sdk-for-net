// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class ClientPipeline
{
    internal class CustomPipelineProcessor : PipelineProcessor
    {
        private readonly PipelineMessage _message;

        private readonly int _perCallIndex;
        private readonly int _perTryIndex;

        private readonly ReadOnlyMemory<PipelinePolicy> _original;
        private readonly ReadOnlyMemory<PipelinePolicy> _perCallPolicies;
        private readonly ReadOnlyMemory<PipelinePolicy> _perTryPolicies;

        private readonly int _length;
        private int _current;

        public CustomPipelineProcessor(PipelineMessage message,
            ReadOnlyMemory<PipelinePolicy> original,
            ReadOnlyMemory<PipelinePolicy> perCallPolicies,
            ReadOnlyMemory<PipelinePolicy> perTryPolicies,
            int perCallIndex,
            int perTryIndex)
        {
            if (perCallIndex > original.Length) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than pipeline length.");
            if (perTryIndex > original.Length) throw new ArgumentOutOfRangeException(nameof(perTryIndex), "perTryIndex cannot be greater than pipeline length.");
            if (perCallIndex > perTryIndex) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than perTryIndex.");

            _message = message;

            _original = original;
            _perCallPolicies = perCallPolicies;
            _perTryPolicies = perTryPolicies;

            _perCallIndex = perCallIndex;
            _perTryIndex = perTryIndex;

            _length = _original.Length + _perCallPolicies.Length + _perTryPolicies.Length;
        }

        public override int Length => _length - _current;

        public override bool ProcessNext()
        {
            if (GetNextPolicy(out PipelinePolicy next))
            {
                next.ProcessAsync(_message, this);
                return true;
            }

            return false;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            if (GetNextPolicy(out PipelinePolicy next))
            {
                await next.ProcessAsync(_message, this).ConfigureAwait(false);
                return true;
            }

            return false;
        }

        private bool GetNextPolicy(out PipelinePolicy policy)
        {
            if (_current < _perCallIndex)
            {
                policy = _original.Span[_current++];
                return true;
            }

            if (_current < _perCallIndex + _perCallPolicies.Length)
            {
                policy = _perCallPolicies.Span[_current++ - _perCallIndex];
                return true;
            }

            if (_current < _perTryIndex + _perCallPolicies.Length)
            {
                policy = _original.Span[_current++ - _perCallPolicies.Length];
                return true;
            }

            if (_current < _perTryIndex + _perCallPolicies.Length + _perTryPolicies.Length)
            {
                policy = _perTryPolicies.Span[_current++ - (_perTryIndex + _perCallPolicies.Length)];
                return true;
            }

            if (_current < _length)
            {
                policy = _original.Span[_current++ - (_perCallPolicies.Length + _perTryPolicies.Length)];
                return true;
            }

            policy = default!;
            return false;
        }
    }
}
