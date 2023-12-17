// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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

        // Starting indexes of each of the ROM segments.
        private readonly FourBitIntVector64 _offsets = new();

        // Lookup table from policy to ROM segment policy is in.
        private readonly FourBitIntVector64 _segments = new();

        private PolicyEnumerator? _enumerator;

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
        public RequestOptionsProcessor(
            ReadOnlyMemory<PipelinePolicy> fixedPolicies,
            ReadOnlyMemory<PipelinePolicy> perCallPolicies,
            ReadOnlyMemory<PipelinePolicy> perTryPolicies,
            ReadOnlyMemory<PipelinePolicy> beforeTransportPolicies,
            int perCallIndex,
            int perTryIndex,
            int beforeTransportIndex)
        {
            if (perCallIndex > fixedPolicies.Length) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than pipeline length.");
            if (perTryIndex > fixedPolicies.Length) throw new ArgumentOutOfRangeException(nameof(perTryIndex), "perTryIndex cannot be greater than pipeline length.");
            if (beforeTransportIndex > fixedPolicies.Length) throw new ArgumentOutOfRangeException(nameof(beforeTransportIndex), "beforeTransportIndex cannot be greater than pipeline length.");
            if (perCallIndex > perTryIndex) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than perTryIndex.");
            if (perTryIndex > beforeTransportIndex) throw new ArgumentOutOfRangeException(nameof(perTryIndex), "perTryIndex cannot be greater than beforeTransportIndex.");

            ClientUtilities.AssertInRange(fixedPolicies.Length, 0, 15, nameof(fixedPolicies.Length));
            ClientUtilities.AssertInRange(perCallPolicies.Length, 0, 15, nameof(perCallPolicies.Length));
            ClientUtilities.AssertInRange(perTryPolicies.Length, 0, 15, nameof(perTryPolicies.Length));
            ClientUtilities.AssertInRange(beforeTransportPolicies.Length, 0, 15, nameof(beforeTransportPolicies.Length));

            _fixedPolicies = fixedPolicies;
            _customPerCallPolicies = perCallPolicies;
            _customPerTryPolicies = perTryPolicies;
            _customBeforeTransportPolicies = beforeTransportPolicies;

            _perCallIndex = perCallIndex;
            _perTryIndex = perTryIndex;
            _beforeTransportIndex = beforeTransportIndex;

            // Initialize the offsets of the segments in the logical array.
            _offsets[0] = 0;
            _offsets[1] = perCallIndex;
            _offsets[2] = _offsets[1] + perCallPolicies.Length;
            _offsets[3] = _offsets[2] + perTryIndex - perCallIndex;
            _offsets[4] = _offsets[3] + perTryPolicies.Length;
            _offsets[5] = _offsets[4] + beforeTransportIndex - perTryIndex;
            _offsets[6] = _offsets[5] + beforeTransportPolicies.Length;
            _offsets[7] = _offsets[6] + fixedPolicies.Length - beforeTransportIndex;

            _length = _offsets[7];

            // Initialize the lookup table from policy to segment.
            int romIndex = 0;
            for (int i = 0; i < _length; i++)
            {
                while (i >= _offsets[romIndex + 1])
                {
                    romIndex++;
                }

                _segments[i] = romIndex;
            }
        }

        public PipelinePolicy this[int index]
        {
            get
            {
                int rom = _segments[index];
                int offset = index - _offsets[rom];
                return GetRom(rom).Span[offset];
            }
        }

        public int Count => _length;

        private ReadOnlyMemory<PipelinePolicy> GetRom(int rom)
            => rom switch
            {
                0 => _fixedPolicies,
                1 => _customPerCallPolicies,
                2 => _fixedPolicies.Slice(_perCallIndex),
                3 => _customPerTryPolicies,
                4 => _fixedPolicies.Slice(_perTryIndex),
                5 => _customBeforeTransportPolicies,
                6 => _fixedPolicies.Slice(_beforeTransportIndex),
                _ => throw new InvalidOperationException(),
            };

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator ??= new(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        // Holds up to sixty-four four-bit "ints"
        public struct FourBitIntVector64
        {
            private ulong _storage0;
            private ulong _storage1;
            private ulong _storage2;
            private ulong _storage3;

            public int this[int i]
            {
                readonly get
                {
                    Debug.Assert(i < 64);

                    int storageIndex = i >> 4;
                    int valueIndex = i & 0b1111;
                    ulong bits = Get(storageIndex);
                    return (int)(bits >> valueIndex * 4) & 0b1111;
                }
                set
                {
                    Debug.Assert(i < 64);

                    int storageIndex = i >> 4;
                    int valueIndex = i & 0b1111;
                    ulong bits = ((ulong)value & 0b1111) << valueIndex * 4;
                    Set(storageIndex, bits);
                }
            }

            private readonly ulong Get(int storageIndex)
            {
                return storageIndex switch
                {
                    0 => _storage0,
                    1 => _storage1,
                    2 => _storage2,
                    3 => _storage3,
                    _ => throw new IndexOutOfRangeException("Requested index exceeds capacity of type."),
                };
            }
            private void Set(int storageIndex, ulong value)
            {
                switch (storageIndex)
                {
                    case 0:
                        _storage0 |= value;
                        break;
                    case 1:
                        _storage1 |= value;
                        break;
                    case 2:
                        _storage2 |= value;
                        break;
                    case 3:
                        _storage3 |= value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Requested index exceeds capacity of type.");
                }
            }
        }
    }
}
