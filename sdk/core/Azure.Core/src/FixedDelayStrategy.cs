// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
        public FixedDelayStrategy(
            TimeSpan delay) : base(TimeSpan.FromMilliseconds(delay.TotalMilliseconds * 1.2), 0.8, 1.2)
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) => _delay;
    }
}