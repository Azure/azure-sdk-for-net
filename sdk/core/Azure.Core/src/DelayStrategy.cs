// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// An abstraction to control delay behavior.
    /// </summary>
    public abstract class DelayStrategy
    {
        internal const double DefaultJitterFactor = 0.2;

        private readonly Random _random = new ThreadSafeRandom();
        private readonly double _minJitterFactor;
        private readonly double _maxJitterFactor;
        private readonly TimeSpan _maxDelay;

        /// <summary>
        /// Constructs a new instance of <see cref="DelayStrategy"/>. This constructor can be used by derived classes to customize the jitter factor and max delay.
        /// </summary>
        /// <param name="maxDelay">The max delay value to apply on an individual delay.</param>
        /// <param name="jitterFactor">The jitter factor to apply to each delay. For example, if the delay is 1 second with a jitterFactor of 0.2, the actual
        /// delay used will be a random double between 0.8 and 1.2. If set to 0, no jitter will be applied.</param>
        protected DelayStrategy(TimeSpan? maxDelay = default, double jitterFactor = DefaultJitterFactor)
        {
            _minJitterFactor = 1.0 - jitterFactor;
            _maxJitterFactor = 1.0 + jitterFactor;

            // use same defaults as RetryOptions
            _maxDelay = maxDelay ?? RetryOptions.DefaultMaxDelay;
        }

        /// <summary>
        /// Constructs an exponential delay with jitter.
        /// </summary>
        /// <param name="initialDelay">The initial delay to use.</param>
        /// <param name="maxDelay">The maximum delay to use.</param>
        /// <returns>The <see cref="DelayStrategy"/> instance.</returns>
        public static DelayStrategy CreateExponentialDelayStrategy(
            TimeSpan? initialDelay = default,
            TimeSpan? maxDelay = default)
        {
            initialDelay ??= RetryOptions.DefaultInitialDelay;
            maxDelay ??= RetryOptions.DefaultMaxDelay;

            return new ExponentialDelayStrategy(initialDelay, maxDelay);
        }

        /// <summary>
        /// Constructs a fixed delay with jitter.
        /// </summary>
        /// <param name="delay">The delay to use.</param>
        /// <returns>The <see cref="DelayStrategy"/> instance.</returns>
        public static DelayStrategy CreateFixedDelayStrategy(TimeSpan? delay = default)
            => new FixedDelayStrategy(delay ?? RetryOptions.DefaultInitialDelay);

        /// <summary>
        /// Gets the next delay interval. Implement this method to provide custom delay logic.
        /// The Max Delay, jitter, and any Retry-After headers will be applied to the value returned from this method.
        /// </summary>
        /// <param name="response">The response, if any, returned from the service.</param>
        /// <param name="retryNumber">The retry number.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the next delay interval.</returns>
        protected abstract TimeSpan GetNextDelayCore(Response? response, int retryNumber);

        /// <summary>
        /// Gets the next delay interval taking into account the Max Delay, jitter, and any Retry-After headers.
        /// </summary>
        /// <param name="response">The response, if any, returned from the service.</param>
        /// <param name="retryNumber">The retry number.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the next delay interval.</returns>
        public TimeSpan GetNextDelay(Response? response, int retryNumber)
        {
            TimeSpan retryAfter = response?.Headers.RetryAfter ?? TimeSpan.Zero;

            TimeSpan defaultDelay = GetNextDelayCore(response, retryNumber);
            TimeSpan defaultWithJitter = ApplyJitter(defaultDelay);
            TimeSpan cappedDefault = Min(defaultWithJitter, _maxDelay);

            return Max(retryAfter, cappedDefault);
        }

        private TimeSpan ApplyJitter(TimeSpan delay)
        {
            // get a random double between 0 and 1
            double randomDouble = _random.NextDouble();

            // scale the double by the jitter range and then add it to the min
            randomDouble = randomDouble * (_maxJitterFactor - _minJitterFactor) + _minJitterFactor;

            // apply the jitter to the delay
            return TimeSpan.FromMilliseconds(delay.TotalMilliseconds * randomDouble);
        }

        /// <summary>
        /// Gets the maximum of two <see cref="TimeSpan"/> values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The maximum of the two <see cref="TimeSpan"/> values.</returns>
        protected static TimeSpan Max(TimeSpan val1, TimeSpan val2)
            => val1 > val2 ? val1 : val2;

        /// <summary>
        /// Gets the minimum of two <see cref="TimeSpan"/> values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The minimum of the two <see cref="TimeSpan"/> values.</returns>
        protected static TimeSpan Min(TimeSpan val1, TimeSpan val2)
            => val1 < val2 ? val1 : val2;
    }
}
