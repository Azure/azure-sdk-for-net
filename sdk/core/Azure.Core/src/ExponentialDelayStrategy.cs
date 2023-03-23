// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    internal class ExponentialDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="maxDelay"></param>
        public ExponentialDelayStrategy(
            TimeSpan? delay,
            TimeSpan? maxDelay) : base(maxDelay, 0.8, 1.2)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            TimeSpan.FromMilliseconds((1 << retryNumber) * _delay.TotalMilliseconds);

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            new(TimeSpan.FromMilliseconds((1 << retryNumber) * _delay.TotalMilliseconds));
    }
}