// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;

    internal static class ConcurrentRandom
    {
        // We lock on this when generating a seed for a threadLocalRandom
        [Fx.Tag.SynchronizationObject]
        private static readonly Random s_seedGenerator = new Random();

        [ThreadStatic]
        private static Random s_threadLocalRandom;

        public static int Next(int minValue, int maxValue)
        {
            return GetThreadLocalRandom().Next(minValue, maxValue);
        }

        // A 64-bit signed integer, x, such that 0 ≤ x ≤Int64.MaxValue.
        // This is different from ulong because ulong is 64 bits.
        // This only makes use of 63 bits - because it always returns positives
        public static long NextPositiveLong()
        {
            var buffer = new byte[8];
            GetThreadLocalRandom().NextBytes(buffer);
            var ulongValue = (long)BitConverter.ToUInt64(buffer, 0);
            return Math.Abs(ulongValue);
        }

        private static Random GetThreadLocalRandom()
        {
            if (s_threadLocalRandom == null)
            {
                int seed;
                lock (s_seedGenerator)
                {
                    seed = s_seedGenerator.Next();
                }

                s_threadLocalRandom = new Random(seed);
            }

            return s_threadLocalRandom;
        }
    }
}
