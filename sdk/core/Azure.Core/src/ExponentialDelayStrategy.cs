﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    public class ExponentialDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _delay;
        private readonly TimeSpan _maxDelay;
        private readonly Random _random = new ThreadSafeRandom();

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="maxDelay"></param>
        public ExponentialDelayStrategy(TimeSpan? delay = default, TimeSpan? maxDelay = default)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
            _maxDelay = maxDelay ?? TimeSpan.FromMinutes(1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="attempt"></param>
        /// <param name="delayHint"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override TimeSpan GetNextDelay(Response? response, int attempt, TimeSpan? delayHint)
        {
            return
                Max(
                    delayHint ?? TimeSpan.Zero,
                    Max(
                        GetServerDelay(response),
                        TimeSpan.FromMilliseconds(
                            Math.Min(
                            (1 << (attempt - 1)) * _random.Next((int)(_delay.TotalMilliseconds * 0.8), (int)(_delay.TotalMilliseconds * 1.2)),
                            _maxDelay.TotalMilliseconds))));
        }
    }
}