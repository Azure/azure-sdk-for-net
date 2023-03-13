// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    internal class ExponentialDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;
        private readonly double _factor;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="maxDelay"></param>
        /// <param name="factor"></param>
        /// <param name="minJitterFactor"></param>
        /// <param name="maxJitterFactor"></param>
        public ExponentialDelayStrategy(
            TimeSpan? delay,
            TimeSpan? maxDelay,
            double factor,
            double minJitterFactor,
            double maxJitterFactor) : base(maxDelay, minJitterFactor, maxJitterFactor)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
            _factor = factor;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) => TimeSpan.FromMilliseconds(
            Math.Pow(_factor, retryNumber) * _delay.TotalMilliseconds);
    }
}