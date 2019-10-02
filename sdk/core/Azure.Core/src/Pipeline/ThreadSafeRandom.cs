// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    internal class ThreadSafeRandom : Random
    {
        private readonly Random _random = new Random();

        public override int Next()
        {
            lock (_random)
            {
                return _random.Next();
            }
        }

        public override int Next(int minValue, int maxValue)
        {
            lock (_random)
            {
                return _random.Next(minValue, maxValue);
            }
        }

        public override int Next(int maxValue)
        {
            lock (_random)
            {
                return _random.Next(maxValue);
            }
        }

        public override double NextDouble()
        {
            lock (_random)
            {
                return _random.NextDouble();
            }
        }

        public override void NextBytes(byte[] buffer)
        {
            lock (_random)
            {
                _random.NextBytes(buffer);
            }
        }
    }
}
