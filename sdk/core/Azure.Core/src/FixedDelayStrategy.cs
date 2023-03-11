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
        public FixedDelayStrategy(TimeSpan? delay = default) : base(RetryMode.Fixed, delay, delay)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="attempt"></param>
        /// <param name="clientDelayHint"></param>
        /// <param name="serverDelayHint"></param>
        /// <returns></returns>
        public override TimeSpan GetNextDelay(Response? response, int attempt, TimeSpan? clientDelayHint, TimeSpan? serverDelayHint)
        {
            return
                Max(
                    serverDelayHint ?? TimeSpan.Zero,
                    Max(
                        clientDelayHint ?? TimeSpan.Zero,
                        Max(
                            response?.Headers.RetryAfter ?? TimeSpan.Zero,
                            _delay)));
        }
    }
}