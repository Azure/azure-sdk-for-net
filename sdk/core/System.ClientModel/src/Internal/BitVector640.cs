// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

/// <summary>
/// This type effectively stores 640 bool values, but compresses their storage
/// into ten ulongs, where each bit of the ulong represents a single bool value.
///
/// It exposes a public indexer so that the bool values can be accessed as a
/// standard .NET collection API.
///
/// It is used in System.ClientModel and Azure.Core to implement response
/// classifiers, where each true bit represents a status code that the
/// classifier considers a success code.
/// </summary>
internal struct BitVector640
{
    // Keeping ulongs as fields puts them on the stack.
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
            // "Index" of the ulong the bit is stored in.
            int index = i >> 6;

            // i % 6, i.e. the offset of the bit in the ulong.
            int mod = i & 0b111111;

            // A mask that lets us access the single bit
            ulong mask = 1ul << mod;

            // The storage ulong and the mask
            ulong bit = Get(index) & mask;

            // If the bit equals the mask, the bit was set to true.
            return bit == mask;
        }
        set
        {
            // "Index" of the ulong the bit is stored in.
            int index = i >> 6;

            // i % 6, i.e. the offset of the bit in the ulong.
            int mod = i & 0b111111;

            // A mask that lets us access the single bit
            ulong mask = 1ul << mod;

            // Set the bit in question to the passed-in value
            Set(index, mask, value);
        }
    }

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

    private void Set(int index, ulong mask, bool value)
    {
        if (value)
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
        else
        {
            switch (index)
            {
                case 0:
                    _bits0 &= ~mask;
                    break;
                case 1:
                    _bits1 &= ~mask;
                    break;
                case 2:
                    _bits2 &= ~mask;
                    break;
                case 3:
                    _bits3 &= ~mask;
                    break;
                case 4:
                    _bits4 &= ~mask;
                    break;
                case 5:
                    _bits5 &= ~mask;
                    break;
                case 6:
                    _bits6 &= ~mask;
                    break;
                case 7:
                    _bits7 &= ~mask;
                    break;
                case 8:
                    _bits8 &= ~mask;
                    break;
                case 9:
                    _bits9 &= ~mask;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}