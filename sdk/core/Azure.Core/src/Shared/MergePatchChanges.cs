// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
    internal readonly struct MergePatchChanges
    {
        private readonly BitVector _changed;

        public MergePatchChanges(int propertyCount)
        {
            _changed = new BitVector(propertyCount);
        }

        public void SetChanged(int index) => _changed[index] = true;

        public bool HasChanged(int index) => _changed[index];

        private readonly struct BitVector
        {
            private readonly ulong[] _bits;

            public BitVector(int size)
            {
                _bits = new ulong[(size >> 6) + 1];
            }

            public bool this[int i]
            {
                get
                {
                    int index = i >> 6;
                    int mod = i & 0b111111;
                    ulong mask = 1ul << mod;
                    ulong bit = _bits[index] & mask;
                    return bit == mask;
                }
                set
                {
                    int index = i >> 6;
                    int mod = i & 0b111111;
                    ulong mask = 1ul << mod;
                    _bits[index] |= mask;
                }
            }
        }
    }
}
