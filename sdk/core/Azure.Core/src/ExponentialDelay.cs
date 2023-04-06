// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    internal class ExponentialDelay : Delay
    {
        private readonly TimeSpan _delay;

        public ExponentialDelay(
            TimeSpan delay,
            TimeSpan maxDelay) : base(maxDelay)
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) =>
            TimeSpan.FromMilliseconds((1 << retryNumber) * _delay.TotalMilliseconds);
    }
}