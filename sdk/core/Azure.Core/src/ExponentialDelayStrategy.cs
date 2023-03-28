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
    internal class ExponentialDelayStrategy : Delay
    {
        private readonly TimeSpan _delay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="maxDelay"></param>
        public ExponentialDelayStrategy(
            TimeSpan delay,
            TimeSpan maxDelay) : base(maxDelay)
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            TimeSpan.FromMilliseconds((1 << retryNumber) * _delay.TotalMilliseconds);

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            new(TimeSpan.FromMilliseconds((1 << retryNumber) * _delay.TotalMilliseconds));
    }
}