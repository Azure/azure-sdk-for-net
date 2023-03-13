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
        private readonly TimeSpan _maxDelay;
        private readonly Random _random = new ThreadSafeRandom();
        private readonly double _minJitterFactor;
        private readonly double _maxJitterFactor;
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
            TimeSpan? delay = default,
            TimeSpan? maxDelay = default,
            double factor = 2.0,
            double minJitterFactor = 0.8,
            double maxJitterFactor = 1.2)
        {
            // use same defaults as RetryOptions
            _delay = delay ?? TimeSpan.FromSeconds(0.8);
            _maxDelay = maxDelay ?? TimeSpan.FromMinutes(1);
            _factor = factor;
            _minJitterFactor = minJitterFactor;
            _maxJitterFactor = maxJitterFactor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="retryNumber"></param>
        /// <param name="clientDelayHint"></param>
        /// <param name="serverDelayHint"></param>
        /// <returns></returns>
        public override TimeSpan GetNextDelay(Response? response, int retryNumber, TimeSpan? clientDelayHint, TimeSpan? serverDelayHint)
        {
            return
                Max(
                    serverDelayHint ?? TimeSpan.Zero,
                    Max(
                        clientDelayHint ?? TimeSpan.Zero,
                        Max(
                            response?.Headers.RetryAfter ?? TimeSpan.Zero,
                            TimeSpan.FromMilliseconds(
                                Math.Min(
                                Math.Pow(_factor, retryNumber) * _random.Next((int)(_delay.TotalMilliseconds * _minJitterFactor), (int)(_delay.TotalMilliseconds * _maxJitterFactor)),
                                _maxDelay.TotalMilliseconds)))));
        }
    }
}