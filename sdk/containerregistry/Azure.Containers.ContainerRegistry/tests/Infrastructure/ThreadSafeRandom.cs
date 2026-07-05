// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Containers.ContainerRegistry.Tests
{
    // Adapted from https://devblogs.microsoft.com/pfxteam/getting-random-numbers-in-a-thread-safe-way/
    public static class ThreadsafeRandom
    {
        private static readonly Random _globalRandom = new Random();

        private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() =>
        {
            lock (_globalRandom)
            {
                return new Random(_globalRandom.Next());
            }
        });

        private static Random ThreadRandom => _threadRandom.Value;

        public static int Next() => ThreadRandom.Next();

        public static int Next(int minValue, int maxValue) => ThreadRandom.Next(minValue, maxValue);

        public static int Next(int maxValue) => ThreadRandom.Next(maxValue);

        public static void NextBytes(byte[] buffer) => ThreadRandom.NextBytes(buffer);

        public static double NextDouble() => ThreadRandom.NextDouble();
    }
}
