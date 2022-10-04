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
        protected RetryPolicy(RetryOptions? options = default)
        {
            options ??= ClientOptions.Default.Retry;
            _mode = options.Mode;
            _delay = options.Delay;
            _maxDelay = options.MaxDelay;
            _maxRetries = options.MaxRetries;
        }

        /// <inheritdoc />
        public sealed override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <inheritdoc />
        public sealed override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            List<Exception>? exceptions = null;
            while (true)
            {
                var before = Stopwatch.GetTimestamp();
                if (async)
                {
                    await OnTryRequestAsync(message).ConfigureAwait(false);
                }
                else
                {
                    OnTryRequest(message);
                }
                try
                {
                    if (async)
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                    else
                    {
                        ProcessNext(message, pipeline);
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

                // If we got a response for this request, trigger OnResponse. We don't rely on no exception being thrown because it's possible
                // a policy later in the pipeline could throw after receiving a response, but we still want to allow OnResponse to be called
                // in this case.
                if (message.Request.ClientRequestId == message.Response.ClientRequestId)
                {
                    if (async)
                    {
                        await OnResponseAsync(message).ConfigureAwait(false);
                    }
                    else
                    {
                        OnResponse(message);
                    }
                }
                var after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                bool shouldRetry = async ? await ShouldRetryAsync(message).ConfigureAwait(false) : ShouldRetry(message);
                if (shouldRetry)
                {
                    TimeSpan delay = async ? await CalculateNextDelayAsync(message).ConfigureAwait(false) : CalculateNextDelay(message);
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

                    throw new AggregateException(
                        $"Retry failed after {message.RetryContext.AttemptNumber} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.",
                        exceptions);
                }
                else
                {
                    // We are not retrying and the last attempt didn't result in an exception.
                    return;
                }

                if (message.HasResponse)
                {
                    // Dispose the content stream to free up a connection if the request has any
                    message.Response.ContentStream?.Dispose();
                }

                message.RetryContext.AttemptNumber++;
                AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.RetryContext.AttemptNumber,
                    elapsed);
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
        protected virtual ValueTask<TimeSpan> CalculateNextDelayAsync(HttpMessage message) => new(CalculateNextDelayInternal(message));

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
        protected virtual ValueTask OnTryRequestAsync(HttpMessage message) => default;

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
        protected virtual ValueTask OnResponseAsync(HttpMessage message) => default;

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
