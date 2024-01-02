// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline;

public partial class RetryPolicy
{
    internal class AzureCoreRetryPolicy : RequestRetryPolicy
    {
        private readonly RetryPolicy _pipelinePolicy;

        private long _beforeProcess;
        private long _afterProcess;
        private double _elapsedTime;

        public AzureCoreRetryPolicy(int maxRetries, DelayStrategy delay, RetryPolicy policy)
            : base(maxRetries, CreateDelay(delay, policy))
        {
            _pipelinePolicy = policy;
        }

        protected override void OnSendingRequest(PipelineMessage message)
        {
            _beforeProcess = Stopwatch.GetTimestamp();

            _pipelinePolicy.OnSendingRequest(AssertHttpMessage(message));
        }

        protected override async ValueTask OnSendingRequestAsync(PipelineMessage message)
        {
            _beforeProcess = Stopwatch.GetTimestamp();

            await _pipelinePolicy.OnSendingRequestAsync(AssertHttpMessage(message)).ConfigureAwait(false);
        }

        protected override void OnRequestSent(PipelineMessage message)
        {
            _pipelinePolicy.OnRequestSent(AssertHttpMessage(message));

            _afterProcess = Stopwatch.GetTimestamp();
            _elapsedTime = (_afterProcess - _beforeProcess) / (double)Stopwatch.Frequency;
        }

        protected override async ValueTask OnRequestSentAsync(PipelineMessage message)
        {
            await _pipelinePolicy.OnRequestSentAsync(AssertHttpMessage(message)).ConfigureAwait(false);

            _afterProcess = Stopwatch.GetTimestamp();
            _elapsedTime = (_afterProcess - _beforeProcess) / (double)Stopwatch.Frequency;
        }

        protected override bool ShouldRetryCore(PipelineMessage message, Exception? exception)
            => _pipelinePolicy.ShouldRetry(AssertHttpMessage(message), exception);

        protected override async ValueTask<bool> ShouldRetryCoreAsync(PipelineMessage message, Exception? exception)
            => await _pipelinePolicy.ShouldRetryAsync(AssertHttpMessage(message), exception).ConfigureAwait(false);

        public void OnDelayComplete(PipelineMessage message)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);
            httpMessage.RetryNumber++;

            AzureCoreEventSource.Singleton.RequestRetrying(httpMessage.Request.ClientRequestId, httpMessage.RetryNumber, _elapsedTime);

            // Reset stopwatch values
            _afterProcess = default;
            _beforeProcess = default;
            _elapsedTime = default;
        }

        // TODO: I like this pattern.  Where else can I apply it?
        private static HttpMessage AssertHttpMessage(PipelineMessage message)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message?.GetType()}'.");
            }

            return httpMessage;
        }

        private static MessageDelay CreateDelay(DelayStrategy strategy, RetryPolicy policy)
            => new AzureCoreRetryDelay(strategy, policy);

        private class AzureCoreRetryDelay : MessageDelay
        {
            private readonly DelayStrategy _strategy;
            private readonly RetryPolicy _retryPolicy;

            public AzureCoreRetryDelay(DelayStrategy strategy, RetryPolicy policy)
            {
                _strategy = strategy;
                _retryPolicy = policy;
            }

            protected override TimeSpan GetDelayCore(PipelineMessage message, int delayCount)
            {
                HttpMessage httpMessage = AssertHttpMessage(message);

                Debug.Assert(delayCount == httpMessage.RetryNumber);

                Response? response = httpMessage.HasResponse ? httpMessage.Response : default;
                return _strategy.GetNextDelay(response, delayCount + 1);
            }

            protected override void OnDelayComplete(PipelineMessage message)
                => _retryPolicy.OnDelayComplete(message);

            protected override void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
                => _retryPolicy.Wait(duration, cancellationToken);

            protected override async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
                => await _retryPolicy.WaitAsync(duration, cancellationToken).ConfigureAwait(false);
        }
    }
}
