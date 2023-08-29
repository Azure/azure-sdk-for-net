// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    internal readonly struct BitVectorHeapBacked
    {
        private readonly ulong[] _bits;

        public BitVectorHeapBacked(int size)
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

        public bool IsNonzero()
        {
            foreach (ulong value in _bits)
            {
                if (value > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
