// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

internal struct BitVector640
{
    private ulong _bits0;
    private ulong _bits1;
    private ulong _bits2;
    private ulong _bits3;
    private ulong _bits4;
    private ulong _bits5;
    private ulong _bits6;
    private ulong _bits7;
    private ulong _bits8;
    private ulong _bits9;

    public bool this[int i]
    {
        readonly get
        {
            int index = i >> 6;
            int mod = i & 0b111111;
            ulong mask = 1ul << mod;
            ulong bit = Get(index) & mask;
            return bit == mask;
        }
        set
        {
            int index = i >> 6;
            int mod = i & 0b111111;
            ulong mask = 1ul << mod;
            Set(index, mask);
        }
    }

    public readonly bool IsNonzero() =>
        _bits0 > 0 ||
        _bits1 > 0 ||
        _bits2 > 0 ||
        _bits3 > 0 ||
        _bits4 > 0 ||
        _bits5 > 0 ||
        _bits6 > 0 ||
        _bits7 > 0 ||
        _bits8 > 0 ||
        _bits9 > 0;

    private readonly ulong Get(int index)
    {
        return index switch
        {
            0 => _bits0,
            1 => _bits1,
            2 => _bits2,
            3 => _bits3,
            4 => _bits4,
            5 => _bits5,
            6 => _bits6,
            7 => _bits7,
            8 => _bits8,
            9 => _bits9,
            _ => throw new InvalidOperationException(),
        };
    }

    private void Set(int index, ulong mask)
    {
        switch (index)
        {
            case 0:
                _bits0 |= mask;
                break;
            case 1:
                _bits1 |= mask;
                break;
            case 2:
                _bits2 |= mask;
                break;
            case 3:
                _bits3 |= mask;
                break;
            case 4:
                _bits4 |= mask;
                break;
            case 5:
                _bits5 |= mask;
                break;
            case 6:
                _bits6 |= mask;
                break;
            case 7:
                _bits7 |= mask;
                break;
            case 8:
                _bits8 |= mask;
                break;
            case 9:
                _bits9 |= mask;
                break;
            default:
                throw new InvalidOperationException();
        }
    }
}