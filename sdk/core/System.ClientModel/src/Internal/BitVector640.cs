// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

namespace System.ClientModel.Internal;

/// <summary>
/// This type effectively stores 640 bool values, but compresses their storage
/// into ten unsigned long fields, where each bit of the ulong represents a single bool value.
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
    // Ten unsigned long field to keep 640 bits.
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

    // To get or set the correct bit, we need to find a field and an offset inside field
    // For that, we have GetField and GetOffset methods.
    // ===================================================
    // Example: find the field and the offset for index 621
    // In binary form, 621 is 0b1001101101.
    // First 4 bits represent the field number, while the last 6 bits represent the offset in the field
    // (ulong is 64-bit type, hence offset is in the [0, 63] range)
    //
    //    9 - field number
    // ╔══╩══╗
    // 1 0 0 1 1 0 1 1 0 1
    //         ╚════╦════╝
    //              45 - offset in the field
    // ╔════════════╩════════════════════════════════════════════════════════╗
    // 00000000 00000000 00100000 00000000 00000000 00000000 00000000 00000000
    //                     ↑
    //      bit #45 in 64-bit mask (indexing starts with 0)
    //
    // To get the field number, we right shift the index by 6
    //    (6 bits required to represent value in [0, 63] range)
    // To get the offset, we apply the 0b111111 mask to the index to get value from the last 6 bits,
    //    then shift left a single bit by that value to get mask for the field,
    //    then apply mask to the field

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ref ulong GetField(ref BitVector640 vector, int index)
    {
        switch (index >> 6)
        {
            case 0: return ref vector._bits0;
            case 1: return ref vector._bits1;
            case 2: return ref vector._bits2;
            case 3: return ref vector._bits3;
            case 4: return ref vector._bits4;
            case 5: return ref vector._bits5;
            case 6: return ref vector._bits6;
            case 7: return ref vector._bits7;
            case 8: return ref vector._bits8;
            case 9: return ref vector._bits9;
            default: throw new InvalidOperationException();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong GetOffset(int index)
        => 1ul << (index & 0b111_111);

    public bool this[int i]
    {
        get
        {
            var field = GetField(ref this, i);
            var offset = GetOffset(i);
            return (field & offset) != 0;
        }
        set
        {
            ref ulong field = ref GetField(ref this, i);
            var offset = GetOffset(i);
            field = value
                ? field | offset
                : field & ~offset;
        }
    }
}
