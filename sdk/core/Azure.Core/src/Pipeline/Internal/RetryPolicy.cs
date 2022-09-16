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
    public abstract class RetryPolicy : HttpPipelinePolicy
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
        public RetryPolicy(RetryOptions options)
        {
            _mode = options.Mode;
            _delay = options.Delay;
            _maxDelay = options.MaxDelay;
            _maxRetries = options.MaxRetries;
        }

        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc/>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            message.RetryContext = new RetryContext(DateTimeOffset.UtcNow);
            List<Exception>? exceptions = null;
            while (true)
            {
                message.RetryContext.AttemptNumber++;
                var before = Stopwatch.GetTimestamp();
                try
                {
                    if (async)
                    {
                        await OnTryRequestAsync(message).ConfigureAwait(false);
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                        await OnResponseAsync(message).ConfigureAwait(false);
                    }
                    else
                    {
                        OnTryRequest(message);
                        ProcessNext(message, pipeline);
                        OnResponse(message);
                    }
                    // This request didn't result in an exception, so reset the LastException property
                    // in case it was set on a previous attempt.
                    message.RetryContext.LastException = null;
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);

                    message.RetryContext.LastException = ex;
                }

                var after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                TimeSpan delay;

                bool shouldRetry = async ? await ShouldRetryAsync(message).ConfigureAwait(false) : ShouldRetry(message);
                if (shouldRetry)
                {
                    delay = async ? await CalculateNextDelayAsync(message).ConfigureAwait(false) : CalculateNextDelay(message);
                    if (delay > TimeSpan.Zero)
                    {
                        if (async)
                        {
                            await WaitAsync(delay, message.CancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            Wait(delay, message.CancellationToken);
                        }
                    }
                }
                else if (message.RetryContext.LastException != null)
                {
                    // Rethrow a singular exception
                    if (exceptions!.Count == 1)
                    {
                        ExceptionDispatchInfo.Capture(message.RetryContext.LastException).Throw();
                    }

                    throw new AggregateException($"Retry failed after {message.RetryContext.AttemptNumber} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.", exceptions);
                }
                else
                {
                    return;
                }

                if (delay > TimeSpan.Zero)
                {
                    if (async)
                    {
                        await WaitAsync(delay, message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        Wait(delay, message.CancellationToken);
                    }
                }

                if (message.HasResponse)
                {
                    // Dispose the content stream to free up a connection if the request has any
                    message.Response.ContentStream?.Dispose();
                }

                AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.RetryContext.AttemptNumber, elapsed);
            }
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
        protected virtual bool ShouldRetry(HttpMessage message) => ShouldRetryInternal(message);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ValueTask<bool> ShouldRetryAsync(HttpMessage message) => new(ShouldRetryInternal(message));

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

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual TimeSpan CalculateNextDelay(HttpMessage message) => CalculateNextDelayInternal(message);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ValueTask<TimeSpan> CalculateNextDelayAsync(HttpMessage message) => new(CalculateNextDelayInternal(message));

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

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        protected virtual void OnTryRequest(HttpMessage message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ValueTask OnTryRequestAsync(HttpMessage message) => new();

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        protected virtual void OnResponse(HttpMessage message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ValueTask OnResponseAsync(HttpMessage message) => new();

        internal virtual TimeSpan GetServerDelay(HttpMessage message)
        {
            if (message.Response == null)
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
