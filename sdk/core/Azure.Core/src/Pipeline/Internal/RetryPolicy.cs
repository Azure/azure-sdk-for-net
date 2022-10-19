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
    internal class RetryPolicy : HttpPipelinePolicy
    {
        private readonly RetryMode _mode;
        private readonly TimeSpan _delay;
        private readonly TimeSpan _maxDelay;
        private readonly int _maxRetries;
        private readonly List<RetryCondition> _retryConditions;

        private readonly Random _random = new ThreadSafeRandom();

        public RetryPolicy(RetryMode mode, TimeSpan delay, TimeSpan maxDelay, int maxRetries, IEnumerable<RetryCondition> retryConditions)
        {
            _mode = mode;
            _delay = delay;
            _maxDelay = maxDelay;
            _maxRetries = maxRetries;

            _retryConditions = new List<RetryCondition>();
            _retryConditions.AddRange(retryConditions);

            // Add the Max Attempts retry condition to the end of the list to ensure we have a default condition.
            _retryConditions.Add(new MaxAttemptsRetryCondition(maxRetries));
        }

        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            message.PipelineContext.RetryAttempt = 0;
            List<Exception>? exceptions = null;
            while (true)
            {
                Exception? lastException = null;
                var before = Stopwatch.GetTimestamp();
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
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);

                    lastException = ex;
                }

                var after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                TimeSpan delay;

                message.PipelineContext.RetryAttempt++;
                bool shouldRetry = EvaluateRetryConditions(message);

                if (lastException != null)
                {
                    if (shouldRetry && message.ResponseClassifier.IsRetriable(message, lastException))
                    {
                        GetDelay(message.PipelineContext.RetryAttempt, out delay);
                    }
                    else
                    {
                        // Rethrow a singular exception
                        if (exceptions!.Count == 1)
                        {
                            ExceptionDispatchInfo.Capture(lastException).Throw();
                        }

                        throw new AggregateException($"Retry failed after {message.PipelineContext.RetryAttempt} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.", exceptions);
                    }
                }
                else if (message.Response.IsError)
                {
                    if (shouldRetry && message.ResponseClassifier.IsRetriableResponse(message))
                    {
                        GetDelay(message, message.PipelineContext.RetryAttempt, out delay);
                    }
                    else
                    {
                        return;
                    }
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

                AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.PipelineContext.RetryAttempt, elapsed);
            }
        }

        private bool EvaluateRetryConditions(HttpMessage message)
        {
            foreach (RetryCondition condition in _retryConditions)
            {
                if (condition.TryGetShouldRetry(message, out bool shouldRetry))
                {
                    return shouldRetry;
                }
            }

            // We added a default retry condition that always returns true at the end of the list,
            // so we should never get here.
            return false;
        }

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }

        protected virtual TimeSpan GetServerDelay(HttpMessage message)
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

        private void GetDelay(HttpMessage message, int attempted, out TimeSpan delay)
        {
            delay = TimeSpan.Zero;

            switch (_mode)
            {
                case RetryMode.Fixed:
                    delay = _delay;
                    break;
                case RetryMode.Exponential:
                    delay = CalculateExponentialDelay(attempted);
                    break;
            }

            TimeSpan serverDelay = GetServerDelay(message);
            if (serverDelay > delay)
            {
                delay = serverDelay;
            }
        }

        private void GetDelay(int attempted, out TimeSpan delay)
        {
            delay = CalculateExponentialDelay(attempted);
        }

        private TimeSpan CalculateExponentialDelay(int attempted)
        {
            return TimeSpan.FromMilliseconds(
                Math.Min(
                    (1 << (attempted - 1)) * _random.Next((int)(_delay.TotalMilliseconds * 0.8), (int)(_delay.TotalMilliseconds * 1.2)),
                    _maxDelay.TotalMilliseconds));
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class MaxAttemptsRetryCondition : RetryCondition
#pragma warning restore SA1402 // File may only contain a single type
    {
        private int _maxAttempts;

        internal MaxAttemptsRetryCondition(int maxAttempts)
        {
            _maxAttempts = maxAttempts;
        }

        public override bool TryGetShouldRetry(HttpMessage message, out bool shouldRetry)
        {
            if (message.PipelineContext.RetryAttempt <= _maxAttempts)
            {
                shouldRetry = false;
                return true;
            }

            shouldRetry = true;
            return true;
        }
    }
}
