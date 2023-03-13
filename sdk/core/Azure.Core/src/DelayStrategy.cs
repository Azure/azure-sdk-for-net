// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// Strategy to control delay behavior.
    /// </summary>
    public abstract class DelayStrategy
    {
        private readonly DelayStrategy? _innerStrategy;

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="initialDelay"></param>
        /// <param name="maxDelay"></param>
        protected DelayStrategy(RetryMode? mode = default, TimeSpan? initialDelay = default, TimeSpan? maxDelay = default)
        {
            _innerStrategy = mode switch
            {
                RetryMode.Exponential => new ExponentialDelayStrategy(initialDelay, maxDelay),
                RetryMode.Fixed => new FixedDelayStrategy(initialDelay),
                _ => null
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialDelay"></param>
        /// <param name="maxDelay"></param>
        /// <param name="factor"></param>
        /// <param name="minJitterFactor"></param>
        /// <param name="maxJitterFactor"></param>
        /// <returns></returns>
        public static DelayStrategy CreateExponentialDelayStrategy(
            TimeSpan? initialDelay = default,
            TimeSpan? maxDelay = default,
            double factor = 2.0,
            double minJitterFactor = 0.8,
            double maxJitterFactor = 1.2)
        {
            return new ExponentialDelayStrategy(initialDelay, maxDelay, factor, minJitterFactor, maxJitterFactor);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static DelayStrategy CreateFixedDelayStrategy(TimeSpan? delay = default)
        {
            return new FixedDelayStrategy(delay);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static DelayStrategy CreateSequentialDelayStrategy(IEnumerable<TimeSpan>? sequence = default)
        {
            return new SequentialDelayStrategy(sequence);
        }

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="retryNumber"></param>
        /// <param name="clientDelayHint"></param>
        /// <param name="serverDelayHint"></param>
        /// <returns> Delay interval of next iteration. </returns>
        public abstract TimeSpan GetNextDelay(Response? response, int retryNumber, TimeSpan? clientDelayHint, TimeSpan? serverDelayHint);

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="retryNumber"></param>
        /// <returns></returns>
        public TimeSpan? GetClientDelayHint(Response? response, int retryNumber)
        {
            return _innerStrategy?.GetNextDelay(response, retryNumber, null, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
