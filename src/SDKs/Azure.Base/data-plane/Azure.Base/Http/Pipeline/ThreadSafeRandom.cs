// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Base.Http.Pipeline
{
    internal class ThreadSafeRandom: Random
    {
        private static int _seed = Environment.TickCount;

        private readonly ThreadLocal<Random> _currentThreadRandom = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)), false);

        public override int Next()
        {
            return _currentThreadRandom.Value.Next();
        }

        public override int Next(int minValue, int maxValue)
        {
            return _currentThreadRandom.Value.Next(minValue, maxValue);
        }

        public override int Next(int maxValue)
        {
            return _currentThreadRandom.Value.Next(maxValue);
        }

        public override double NextDouble()
        {
            return _currentThreadRandom.Value.NextDouble();
        }

        public override void NextBytes(byte[] buffer)
        {
            _currentThreadRandom.Value.NextBytes(buffer);
        }
    }
}