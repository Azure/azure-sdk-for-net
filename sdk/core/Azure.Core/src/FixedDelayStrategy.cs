// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    public class FixedDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        public FixedDelayStrategy(TimeSpan? delay = default)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="attempt"></param>
        /// <param name="delayHint"></param>
        /// <returns></returns>
        public override TimeSpan GetNextDelay(Response? response, int attempt, TimeSpan? delayHint)
        {
            return
                Max(
                    delayHint ?? TimeSpan.Zero,
                    Max(
                        GetServerDelay(response),
                        _delay));
        }
    }
}