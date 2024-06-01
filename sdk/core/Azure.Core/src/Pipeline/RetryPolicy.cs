// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
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

        private readonly RetryPolicyAdapter _clientModelPolicy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class.
        /// </summary>
        /// <param name="maxRetries">The maximum number of retries to attempt.</param>
        /// <param name="delayStrategy">The delay to use for computing the interval between retry attempts.</param>
        public RetryPolicy(int maxRetries = RetryOptions.DefaultMaxRetries, DelayStrategy? delayStrategy = default)
        {
            _maxRetries = maxRetries;
            _delayStrategy = delayStrategy ?? DelayStrategy.CreateExponentialDelayStrategy();

            _clientModelPolicy = new RetryPolicyAdapter(maxRetries, _delayStrategy, this);
        }

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

        /// <summary>
        /// This method can be overriden to take full control over the retry policy. If this is overriden and the base method isn't called,
        /// it is the implementer's responsibility to populate the <see cref="HttpMessage.ProcessingContext"/> property.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, async: false).EnsureCompleted();

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            HttpPipelineAdapter httpPipeline = new(pipeline);

            try
            {
                if (async)
                {
                    await _clientModelPolicy.ProcessAsync(message, httpPipeline, -1).ConfigureAwait(false);
                }
                else
                {
                    _clientModelPolicy.Process(message, httpPipeline, -1);
                }
            }
            catch (ClientResultException e)
            {
                if (!message.HasResponse)
                {
                    throw new RequestFailedException(e.Message, e.InnerException);
                }

                if (async)
                {
                    throw await RequestFailedException.CreateAsync(message.Response, innerException: e.InnerException).ConfigureAwait(false);
                }
                else
                {
                    throw new RequestFailedException(message.Response, e.InnerException);
                }
            }
        }

        /// <summary>
        /// This method can be overriden to control whether a request should be retried. It will be called for any response where
        /// <see cref="PipelineResponse.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected virtual bool ShouldRetry(HttpMessage message, Exception? exception)
        {
            if (message.RetryNumber >= _maxRetries)
            {
                // We've exceeded the maximum number of retries, so don't retry.
                return false;
            }

            return exception is null ?
                message.ResponseClassifier.IsRetriableResponse(message) :
                message.ResponseClassifier.IsRetriable(message, exception);
        }

        /// <summary>
        /// This method can be overriden to control whether a request should be retried.  It will be called for any response where
        /// <see cref="PipelineResponse.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
        /// <returns>Whether or not to retry.</returns>
        protected virtual ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception? exception)
            => new(ShouldRetry(message, exception));

        /// <summary>
        /// This method can be overridden to introduce logic before each request attempt is sent. This will run even for the first attempt.
        /// This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected virtual void OnSendingRequest(HttpMessage message) { }

        /// <summary>
        /// This method can be overriden to introduce logic that runs before the request is sent. This will run even for the first attempt.
        /// This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected virtual ValueTask OnSendingRequestAsync(HttpMessage message) => default;

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for sync methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected virtual void OnRequestSent(HttpMessage message) { }

        /// <summary>
        /// This method can be overridden to introduce logic that runs after the request is sent through the pipeline and control is returned to the retry
        /// policy. This method will only be called for async methods.
        /// </summary>
        /// <param name="message">The message containing the request and response.</param>
        protected virtual ValueTask OnRequestSentAsync(HttpMessage message) => default;

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }

        /// <summary>
        /// This type implements a System.ClientModel
        /// <see cref="ClientRetryPolicy"/> and adds the Azure.Core-specific
        /// feature of creating an EventSource event with the elapsed time to
        /// process the message on each try.
        ///
        /// It also adapts the Azure.Core <see cref="RetryPolicy"/> that holds
        /// it as a member. This is needed so that, if a user has implemented a
        /// type derived from Azure.Core <see cref="RetryPolicy"/> and
        /// overridden one or more of its virtual methods, when a virtual method
        /// is called on the <see cref="ClientRetryPolicy"/> base type from a
        /// System.ClientModel context, it will call through to the overridden
        /// method on the derived type.
        /// </summary>
        private sealed class RetryPolicyAdapter : ClientRetryPolicy
        {
            private readonly RetryPolicy _azureCorePolicy;
            private readonly DelayStrategy _delayStrategy;

            public RetryPolicyAdapter(int maxRetries, DelayStrategy delay, RetryPolicy policy)
                : base(maxRetries)
            {
                _delayStrategy = delay;
                _azureCorePolicy = policy;
            }

            protected override void OnSendingRequest(PipelineMessage message)
            {
                message.SetProperty(typeof(BeforeTimestamp), Stopwatch.GetTimestamp());

                _azureCorePolicy.OnSendingRequest(HttpMessage.GetHttpMessage(message));
            }

            protected override async ValueTask OnSendingRequestAsync(PipelineMessage message)
            {
                message.SetProperty(typeof(BeforeTimestamp), Stopwatch.GetTimestamp());

                await _azureCorePolicy.OnSendingRequestAsync(HttpMessage.GetHttpMessage(message)).ConfigureAwait(false);
            }

            protected override void OnRequestSent(PipelineMessage message)
            {
                _azureCorePolicy.OnRequestSent(HttpMessage.GetHttpMessage(message));

                if (!message.TryGetProperty(typeof(BeforeTimestamp), out object? beforeTimestamp) ||
                    beforeTimestamp is not long before)
                {
                    Debug.Fail("'BeforeTimestamp' was not set on message by RetryPolicy.");
                    return;
                }

                long after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                message.SetProperty(typeof(ElapsedTime), elapsed);
            }

            protected override async ValueTask OnRequestSentAsync(PipelineMessage message)
            {
                await _azureCorePolicy.OnRequestSentAsync(HttpMessage.GetHttpMessage(message)).ConfigureAwait(false);

                if (!message.TryGetProperty(typeof(BeforeTimestamp), out object? beforeTimestamp) ||
                    beforeTimestamp is not long before)
                {
                    Debug.Fail("'BeforeTimestamp' was not set on message by RetryPolicy.");
                    return;
                }

                long after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                message.SetProperty(typeof(ElapsedTime), elapsed);
            }

            protected override bool ShouldRetry(PipelineMessage message, Exception? exception)
                => _azureCorePolicy.ShouldRetry(HttpMessage.GetHttpMessage(message), exception);

            protected override async ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
                => await _azureCorePolicy.ShouldRetryAsync(HttpMessage.GetHttpMessage(message), exception).ConfigureAwait(false);

            protected override void OnTryComplete(PipelineMessage message)
            {
                HttpMessage httpMessage = HttpMessage.GetHttpMessage(message);
                httpMessage.RetryNumber++;

                if (!message.TryGetProperty(typeof(ElapsedTime), out object? elapsedTime) ||
                    elapsedTime is not double elapsed)
                {
                    Debug.Fail("'ElapsedTime' was not set on message by RetryPolicy.");
                    return;
                }

                // This logic can move into System.ClientModel's ClientRetryPolicy
                // once we enable EventSource logging there.
                AzureCoreEventSource.Singleton.RequestRetrying(httpMessage.Request.ClientRequestId, httpMessage.RetryNumber, elapsed);

                // Reset stopwatch values
                message.SetProperty(typeof(BeforeTimestamp), null);
                message.SetProperty(typeof(ElapsedTime), null);
            }

            protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
            {
                HttpMessage httpMessage = HttpMessage.GetHttpMessage(message);

                Debug.Assert(tryCount == httpMessage.RetryNumber);

                Response? response = httpMessage.HasResponse ? httpMessage.Response : default;
                return _delayStrategy.GetNextDelay(response, tryCount + 1);
            }

            protected override async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
                => await _azureCorePolicy.WaitAsync(time, cancellationToken).ConfigureAwait(false);

            protected override void Wait(TimeSpan time, CancellationToken cancellationToken)
                => _azureCorePolicy.Wait(time, cancellationToken);

            private class BeforeTimestamp { }

            private class ElapsedTime { }
        }
    }
}
