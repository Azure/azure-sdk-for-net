// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a policy that can be overriden to customize whether or not a request will be retried and how long to wait before retrying.
    /// </summary>
    public partial class RetryPolicy : HttpPipelinePolicy
    {
        private readonly int _maxRetries;
        private readonly DelayStrategy _delayStrategy;
        private readonly AzureCoreRetryPolicy _policy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class.
        /// </summary>
        /// <param name="maxRetries">The maximum number of retries to attempt.</param>
        /// <param name="delayStrategy">The delay to use for computing the interval between retry attempts.</param>
        public RetryPolicy(int maxRetries = RetryOptions.DefaultMaxRetries, DelayStrategy? delayStrategy = default)
        {
            _maxRetries = maxRetries;
            _delayStrategy = delayStrategy ?? DelayStrategy.CreateExponentialDelayStrategy();

            _policy = new AzureCoreRetryPolicy(maxRetries, _delayStrategy, this);
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
            AzureCorePipelineProcessor processor = new(message, pipeline);

            if (async)
            {
                await _policy.ProcessAsync(message, processor).ConfigureAwait(false);
            }
            else
            {
                _policy.Process(message, processor);
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
    }
}
