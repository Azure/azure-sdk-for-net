// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public readonly partial struct Variant
    {
        private static class TypeFlags
        {
            internal static readonly StraightCastFlag<bool> Boolean = StraightCastFlag<bool>.Instance;
            internal static readonly StraightCastFlag<char> Char = StraightCastFlag<char>.Instance;
            internal static readonly StraightCastFlag<byte> Byte = StraightCastFlag<byte>.Instance;
            internal static readonly StraightCastFlag<sbyte> SByte = StraightCastFlag<sbyte>.Instance;
            internal static readonly StraightCastFlag<short> Int16 = StraightCastFlag<short>.Instance;
            internal static readonly StraightCastFlag<ushort> UInt16 = StraightCastFlag<ushort>.Instance;
            internal static readonly StraightCastFlag<int> Int32 = StraightCastFlag<int>.Instance;
            internal static readonly StraightCastFlag<uint> UInt32 = StraightCastFlag<uint>.Instance;
            internal static readonly StraightCastFlag<long> Int64 = StraightCastFlag<long>.Instance;
            internal static readonly StraightCastFlag<ulong> UInt64 = StraightCastFlag<ulong>.Instance;
            internal static readonly StraightCastFlag<float> Single = StraightCastFlag<float>.Instance;
            internal static readonly StraightCastFlag<double> Double = StraightCastFlag<double>.Instance;
            internal static readonly StraightCastFlag<DateTime> DateTime = StraightCastFlag<DateTime>.Instance;
            internal static readonly DateTimeOffsetFlag DateTimeOffset = DateTimeOffsetFlag.Instance;
            internal static readonly PackedDateTimeOffsetFlag PackedDateTimeOffset = PackedDateTimeOffsetFlag.Instance;
        }
    }
}
