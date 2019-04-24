// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    static class Ticks
    {
        public static long Now
        {
            get
            {
                long time = DateTime.UtcNow.ToFileTimeUtc();
                return time;
            }
        }

        public static long FromMilliseconds(int milliseconds)
        {
            return checked(milliseconds * TimeSpan.TicksPerMillisecond);
        }

        public static int ToMilliseconds(long ticks)
        {
            return checked((int)(ticks / TimeSpan.TicksPerMillisecond));
        }

        public static long FromTimeSpan(TimeSpan duration)
        {
            return duration.Ticks;
        }

        public static TimeSpan ToTimeSpan(long ticks)
        {
            return new TimeSpan(ticks);
        }

        public static long Add(long firstTicks, long secondTicks)
        {
            if (firstTicks == long.MaxValue || firstTicks == long.MinValue)
            {
                return firstTicks;
            }

            if (secondTicks == long.MaxValue || secondTicks == long.MinValue)
            {
                return secondTicks;
            }

            if (firstTicks >= 0 && long.MaxValue - firstTicks <= secondTicks)
            {
                return long.MaxValue - 1;
            }

            if (firstTicks <= 0 && long.MinValue - firstTicks >= secondTicks)
            {
                return long.MinValue + 1;
            }

            return checked(firstTicks + secondTicks);
        }
    }
}
