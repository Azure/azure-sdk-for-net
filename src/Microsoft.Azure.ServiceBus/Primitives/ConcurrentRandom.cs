// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;

    internal static class ConcurrentRandom
    {
        // We lock on this when generating a seed for a threadLocalRandom
        [Fx.Tag.SynchronizationObject]
        static readonly Random SeedGenerator = new Random();

        [ThreadStatic]
        static Random threadLocalRandom;

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

        static Random GetThreadLocalRandom()
        {
            if (threadLocalRandom == null)
            {
                int seed;
                lock (SeedGenerator)
                {
                    seed = SeedGenerator.Next();
                }

                threadLocalRandom = new Random(seed);
            }

            return threadLocalRandom;
        }
    }
}