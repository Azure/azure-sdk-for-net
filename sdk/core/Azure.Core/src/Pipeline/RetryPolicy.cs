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
    /// Represents a policy that can be overriden to customize whether or not a request will be retried and how long to wait before retrying.
    /// </summary>
    public class RetryPolicy : HttpPipelinePolicy
    {
        private readonly int _maxRetries;

        /// <summary>
        /// Gets the delay to use for computing the interval between retry attempts.
        /// </summary>
        private readonly DelayStrategy _delayStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class.
        /// </summary>
        /// <param name="maxRetries">The maximum number of retries to attempt.</param>
        /// <param name="delayStrategy">The delay to use for computing the interval between retry attempts.</param>
        public RetryPolicy(int maxRetries = RetryOptions.DefaultMaxRetries, DelayStrategy? delayStrategy = default)
        {
            _maxRetries = maxRetries;
            _delayStrategy = delayStrategy ?? DelayStrategy.CreateExponentialDelayStrategy();
        }

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            List<Exception>? exceptions = null;
            while (true)
            {
                Exception? lastException = null;
                var before = Stopwatch.GetTimestamp();
                if (async)
                {
                    await OnSendingRequestAsync(message).ConfigureAwait(false);
                }
                else
                {
                    OnSendingRequest(message);
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

                if (async)
                {
                    await OnRequestSentAsync(message).ConfigureAwait(false);
                }
                else
                {
                    OnRequestSent(message);
                }

                var after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                bool shouldRetry = false;

                // We only invoke ShouldRetry for errors. If a user needs full control they can either override HttpPipelinePolicy directly
                // or modify the ResponseClassifier.

                if (lastException != null || (message.HasResponse && message.Response.IsError))
                {
                    shouldRetry = async ? await ShouldRetryAsync(message, lastException).ConfigureAwait(false) : ShouldRetry(message, lastException);
                }

                if (shouldRetry)
                {
                    var retryAfter = message.HasResponse ? message.Response.Headers.RetryAfter : default;
                    TimeSpan delay = async ? await GetNextDelayAsync(message, retryAfter).ConfigureAwait(false) : GetNextDelay(message, retryAfter);
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

                    message.RetryNumber++;
                    AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.RetryNumber, elapsed);
                    continue;
                }

                if (lastException != null)
                {
                    // Rethrow a singular exception
                    if (exceptions!.Count == 1)
                    {
                        ExceptionDispatchInfo.Capture(lastException).Throw();
                    }

                    throw new AggregateException(
                        $"Retry failed after {message.RetryNumber + 1} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}" +
                        $" or by configuring a custom retry policy in {nameof(ClientOptions)}.{nameof(ClientOptions.RetryPolicy)}.",
                        exceptions);
                }

                // We are not retrying and the last attempt didn't result in an exception.
                break;
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
        /// This method can be overriden to control whether a request should be retried. It will be called for any response where
        /// <see cref="Response.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected internal virtual bool ShouldRetry(HttpMessage message, Exception? exception) => ShouldRetryInternal(message, exception);

        /// <summary>
        /// This method can be overriden to control whether a request should be retried.  It will be called for any response where
        /// <see cref="Response.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected internal virtual ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception? exception) => new(ShouldRetryInternal(message, exception));

        private bool ShouldRetryInternal(HttpMessage message, Exception? exception)
        {
            if (message.RetryNumber < _maxRetries)
            {
                if (exception != null)
                {
                    return message.ResponseClassifier.IsRetriable(message, exception);
                }

                // Response.IsError is true if we get here
                return message.ResponseClassifier.IsRetriableResponse(message);
            }

            // out of retries
            return false;
        }

        /// <summary>
        /// This method can be overriden to control how long to delay before retrying. This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="retryAfter">The Retry-After header value, if any, returned from the service.</param>
        /// <returns>The amount of time to delay before retrying.</returns>
        internal TimeSpan GetNextDelay(HttpMessage message, TimeSpan? retryAfter) => GetNextDelayInternal(message);

        /// <summary>
        /// This method can be overriden to control how long to delay before retrying. This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="retryAfter">The Retry-After header value, if any, returned from the service.</param>
        /// <returns>The amount of time to delay before retrying.</returns>
        internal ValueTask<TimeSpan> GetNextDelayAsync(HttpMessage message, TimeSpan? retryAfter) => new(GetNextDelayInternal(message));

        /// <summary>
        /// This method can be overridden to introduce logic before each request attempt is sent. This will run even for the first attempt.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual void OnSendingRequest(HttpMessage message)
        {
        }

        /// <summary>
        /// This method can be overriden to introduce logic that runs before the request is sent. This will run even for the first attempt.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual ValueTask OnSendingRequestAsync(HttpMessage message) => default;

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual void OnRequestSent(HttpMessage message)
        {
        }

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected internal virtual ValueTask OnRequestSentAsync(HttpMessage message) => default;

        private TimeSpan GetNextDelayInternal(HttpMessage message)
        {
            return _delayStrategy.GetNextDelay(
                message.HasResponse ? message.Response : default,
                message.RetryNumber + 1);
        }
    }
}
