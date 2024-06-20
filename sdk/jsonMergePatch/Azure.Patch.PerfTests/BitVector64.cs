// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Patch.PerfTests
{
    internal struct BitVector64
    {
        private ulong _bits;

        public bool this[int i]
        {
            get
            {
                int mod = i & 0b111111;
                ulong mask = 1ul << mod;
                ulong bit = _bits & mask;
                return bit == mask;
            }
            set
            {
                int mod = i & 0b111111;
                ulong mask = 1ul << mod;
                _bits |= mask;
            }
        }

        public readonly bool IsNonzero() => _bits > 0;
    }
}
