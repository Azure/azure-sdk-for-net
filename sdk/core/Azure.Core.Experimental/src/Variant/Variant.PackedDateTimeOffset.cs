// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

namespace Azure
{
    public readonly partial struct Variant
    {
        private readonly struct PackedDateTimeOffset
        {
            // HHHHHMMT TTT...
            //
            // HHHHH   - hour bits 1-31
            // MM      - minutes flag
            // T       - ticks bit
            //            00 - :00
            //            01 - :15
            //            10 - :30
            //            11 - :45

            // Base local tick time 1800 [DateTime(1800, 1, 1).Ticks]
            private const ulong BaseTicks = 567709344000000000;
            private const ulong MaxTicks = BaseTicks + TickMask;

            // Hours go from -14 to 14. We add 14 to get our number to store.
            private const int HourOffset = 14;

            private const ulong TickMask = 0b00000001_11111111_11111111_11111111__11111111_11111111_11111111_11111111;
            private const ulong MinuteMask = 0b00000110_00000000_00000000_00000000__00000000_00000000_00000000_00000000;
            private const ulong HourMask = 0b11111000_00000000_00000000_00000000__00000000_00000000_00000000_00000000;

            private const int MinuteShift = 57;
            private const int HourShift = 59;

            private readonly ulong _data;

            private PackedDateTimeOffset(ulong data) => _data = data;

            public static bool TryCreate(DateTimeOffset dateTime, TimeSpan offset, out PackedDateTimeOffset packed)
            {
                bool result = false;
                packed = default;

                ulong ticks = (ulong)dateTime.Ticks;
                if (ticks > BaseTicks && ticks < MaxTicks)
                {
                    ulong data = default;
                    int minutes = offset.Minutes;
                    if (minutes % 15 == 0)
                    {
                        data = (ulong)(minutes / 15) << MinuteShift;
                        int hours = offset.Hours + HourOffset;

                        // Only valid offset hours are -14 to 14
                        Debug.Assert(hours >= 0 && hours <= 28);
                        data |= (ulong)hours << HourShift;
                        data |= ticks - BaseTicks;
                        packed = new(data);
                        result = true;
                    }
                }

                return result;
            }

            public DateTimeOffset Extract()
            {
                TimeSpan offset = new(
                    (int)(((_data & HourMask) >> HourShift) - HourOffset),
                    (int)((_data & MinuteMask) >> MinuteShift),
                    0);
                return new((long)((_data & TickMask) + BaseTicks), offset);
            }
        }
    }
}
