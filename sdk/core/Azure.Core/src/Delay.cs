// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Strategy to control delay behavior.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Delay
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private readonly Random _random = new ThreadSafeRandom();
        private readonly double _minJitterFactor;
        private readonly double _maxJitterFactor;
        private readonly TimeSpan _maxDelay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxDelay"></param>
        /// <param name="jitterFactor"></param>
        protected Delay(TimeSpan? maxDelay = default, double jitterFactor = 0.2)
        {
            // use same defaults as RetryOptions
            _minJitterFactor = 1 - jitterFactor;
            _maxJitterFactor = 1 + jitterFactor;
            _maxDelay = maxDelay ?? TimeSpan.FromMinutes(1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialDelay"></param>
        /// <param name="maxDelay"></param>
        /// <returns></returns>
        public static Delay CreateExponentialDelay(
            TimeSpan? initialDelay = default,
            TimeSpan? maxDelay = default)
        {
            return new ExponentialDelay(initialDelay ?? TimeSpan.FromSeconds(0.8), maxDelay ?? TimeSpan.FromMinutes(1));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static Delay CreateFixedDelay(
            TimeSpan? delay = default)
        {
            return new FixedDelay(delay ?? TimeSpan.FromSeconds(0.8));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="retryNumber"></param>
        /// <returns></returns>
        protected abstract TimeSpan GetNextDelayCore(Response? response, int retryNumber);

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="retryNumber"></param>
        /// <returns> Delay interval of next iteration. </returns>
        public TimeSpan GetNextDelay(Response? response, int retryNumber) =>
            Max(
                response?.Headers.RetryAfter ?? TimeSpan.Zero,
                Min(
                    ApplyJitter(GetNextDelayCore(response, retryNumber)),
                    _maxDelay));

        private TimeSpan ApplyJitter(TimeSpan delay)
        {
            return TimeSpan.FromMilliseconds(_random.Next((int)(delay.TotalMilliseconds * _minJitterFactor), (int)(delay.TotalMilliseconds * _maxJitterFactor)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        protected static TimeSpan Max(TimeSpan val1, TimeSpan val2) => val1 > val2 ? val1 : val2;

        /// <summary>
        ///
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        protected static TimeSpan Min(TimeSpan val1, TimeSpan val2) => val1 < val2 ? val1 : val2;
    }
}
