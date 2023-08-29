// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    internal struct BitVector128
    {
        private ulong _bits0;
        private ulong _bits1;

        public bool this[int i]
        {
            readonly get
            {
                int index = i >> 6;
                int mod = i & 0b111111;
                ulong mask = 1ul << mod;
                ulong bit = (index == 0 ? _bits0 : _bits1) & mask;
                return bit == mask;
            }
            set
            {
                int index = i >> 6;
                int mod = i & 0b111111;
                ulong mask = 1ul << mod;
                if (index == 0)
                {
                    _bits0 |= mask;
                }
                else
                {
                    _bits1 |= mask;
                }
            }
        }

        public readonly bool IsNonzero() => (_bits0 > 0) || (_bits1 > 0);
    }
}
