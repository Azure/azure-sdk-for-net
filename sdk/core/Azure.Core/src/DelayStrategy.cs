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
    public abstract class DelayStrategy
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
        protected DelayStrategy(TimeSpan? maxDelay = default, double jitterFactor = 0.2)
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
        public static DelayStrategy CreateExponentialDelayStrategy(
            TimeSpan? initialDelay = default,
            TimeSpan? maxDelay = default)
        {
            return new ExponentialDelayStrategy(initialDelay ?? TimeSpan.FromSeconds(0.8), maxDelay ?? TimeSpan.FromMinutes(1));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static DelayStrategy CreateFixedDelayStrategy(
            TimeSpan? delay = default)
        {
            return new FixedDelayStrategy(delay ?? TimeSpan.FromSeconds(0.8));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="retryNumber"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context);

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <param name="retryNumber"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber, IDictionary<string, object?> context);

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="retryNumber"></param>
        /// <param name="serverDelayHint"></param>
        /// <param name="context"></param>
        /// <returns> Delay interval of next iteration. </returns>
        public TimeSpan GetNextDelay(Response? response, int retryNumber, TimeSpan? serverDelayHint, IDictionary<string, object?> context)
            => GetNextDelayInternalAsync(false, response, retryNumber, serverDelayHint, context).EnsureCompleted();

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="retryNumber"></param>
        /// <param name="serverDelayHint"></param>
        /// <param name="context"></param>
        /// <returns> Delay interval of next iteration. </returns>
        public async ValueTask<TimeSpan> GetNextDelayAsync(Response? response, int retryNumber, TimeSpan? serverDelayHint, IDictionary<string, object?> context)
            => await GetNextDelayInternalAsync(true, response, retryNumber, serverDelayHint, context).ConfigureAwait(false);

        private async ValueTask<TimeSpan> GetNextDelayInternalAsync(bool async, Response? response, int retryNumber, TimeSpan? serverDelayHint, IDictionary<string, object?> context) =>
            Max(
                serverDelayHint ?? TimeSpan.Zero,
                Min(
                    ApplyJitter(async ? await GetNextDelayCoreAsync(response, retryNumber, context).ConfigureAwait(false) : GetNextDelayCore(response, retryNumber, context)),
                    _maxDelay));

        private TimeSpan ApplyJitter(TimeSpan delay)
        {
            return TimeSpan.FromMilliseconds(_random.Next((int)(delay.TotalMilliseconds * _minJitterFactor), (int)(delay.TotalMilliseconds * _maxJitterFactor)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;

        /// <summary>
        ///
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected static TimeSpan Min(TimeSpan t1, TimeSpan t2) => t1 < t2 ? t1 : t2;
    }
}
