// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    ///
    /// </summary>
    public abstract class RetryPolicy
    {
        private readonly RetryMode _mode;
        private readonly TimeSpan _delay;
        private readonly TimeSpan _maxDelay;
        private readonly int _maxRetries;

        private readonly Random _random = new ThreadSafeRandom();

        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        protected RetryPolicy(RetryOptions options)
        {
            _mode = options.Mode;
            _delay = options.Delay;
            _maxDelay = options.MaxDelay;
            _maxRetries = options.MaxRetries;
        }

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected internal virtual bool ShouldRetry(HttpMessage message) => ShouldRetryInternal(message);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected internal virtual ValueTask<bool> ShouldRetryAsync(HttpMessage message) => new(ShouldRetryInternal(message));

        private bool ShouldRetryInternal(HttpMessage message)
        {
            if (message.RetryContext!.AttemptNumber <= _maxRetries + 1)
            {
                if (message.RetryContext!.LastException != null)
                {
                    return message.ResponseClassifier.IsRetriable(message, message.RetryContext!.LastException);
                }

                if (message.Response.IsError)
                {
                    return message.ResponseClassifier.IsRetriableResponse(message);
                }
            }

            // either was a success response or out of retries
            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected internal virtual TimeSpan CalculateNextDelay(HttpMessage message) => CalculateNextDelayInternal(message);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected internal virtual ValueTask<TimeSpan> CalculateNextDelayAsync(HttpMessage message) => new(CalculateNextDelayInternal(message));

        private TimeSpan CalculateNextDelayInternal(HttpMessage message)
        {
            TimeSpan delay = TimeSpan.Zero;

            switch (_mode)
            {
                case RetryMode.Fixed:
                    delay = _delay;
                    break;
                case RetryMode.Exponential:
                    delay = CalculateExponentialDelay(message.RetryContext!.AttemptNumber);
                    break;
            }

            TimeSpan serverDelay = GetServerDelay(message);
            if (serverDelay > delay)
            {
                delay = serverDelay;
            }

            return delay;
        }

        internal virtual TimeSpan GetServerDelay(HttpMessage message)
        {
            if (!message.HasResponse)
            {
                return TimeSpan.Zero;
            }

            if (message.Response.TryGetHeader(RetryAfterMsHeaderName, out var retryAfterValue) ||
                message.Response.TryGetHeader(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromMilliseconds(delaySeconds);
                }
            }

            if (message.Response.TryGetHeader(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromSeconds(delaySeconds);
                }
                if (DateTimeOffset.TryParse(retryAfterValue, out DateTimeOffset delayTime))
                {
                    return delayTime - DateTimeOffset.Now;
                }
            }

            return TimeSpan.Zero;
        }

        private TimeSpan CalculateExponentialDelay(int attempted)
        {
            return TimeSpan.FromMilliseconds(
                Math.Min(
                    (1 << (attempted - 1)) * _random.Next((int)(_delay.TotalMilliseconds * 0.8), (int)(_delay.TotalMilliseconds * 1.2)),
                    _maxDelay.TotalMilliseconds));
        }
    }
}
