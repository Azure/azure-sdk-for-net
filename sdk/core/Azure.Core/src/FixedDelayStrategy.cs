// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    internal class FixedDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="minJitterFactor"></param>
        /// <param name="maxJitterFactor"></param>
        public FixedDelayStrategy(
            TimeSpan delay,
            double minJitterFactor,
            double maxJitterFactor) : base(TimeSpan.FromMilliseconds(delay.TotalMilliseconds * maxJitterFactor), minJitterFactor, maxJitterFactor)
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) => _delay;
    }
}