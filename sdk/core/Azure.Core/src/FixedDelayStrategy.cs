// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    internal class FixedDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;

        public FixedDelayStrategy(TimeSpan delay) : base(TimeSpan.FromMilliseconds(delay.TotalMilliseconds))
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) => _delay;
    }
}