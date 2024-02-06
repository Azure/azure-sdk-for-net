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
    internal class AzureCoreRetryPolicy : ClientRetryPolicy
    {
        private readonly RetryPolicy _pipelinePolicy;
        private readonly DelayStrategy _delayStrategy;

        private long _beforeProcess;
        private long _afterProcess;
        private double _elapsedTime;

        public AzureCoreRetryPolicy(int maxRetries, DelayStrategy delay, RetryPolicy policy)
            : base(maxRetries)
        {
            _delayStrategy = delay;
            _pipelinePolicy = policy;
        }

        protected override void OnSendingRequest(PipelineMessage message)
        {
            _beforeProcess = Stopwatch.GetTimestamp();

            _pipelinePolicy.OnSendingRequest(HttpMessage.AssertHttpMessage(message));
        }

        protected override async ValueTask OnSendingRequestAsync(PipelineMessage message)
        {
            _beforeProcess = Stopwatch.GetTimestamp();

            await _pipelinePolicy.OnSendingRequestAsync(HttpMessage.AssertHttpMessage(message)).ConfigureAwait(false);
        }

        protected override void OnRequestSent(PipelineMessage message)
        {
            _pipelinePolicy.OnRequestSent(HttpMessage.AssertHttpMessage(message));

            _afterProcess = Stopwatch.GetTimestamp();
            _elapsedTime = (_afterProcess - _beforeProcess) / (double)Stopwatch.Frequency;
        }

        protected override async ValueTask OnRequestSentAsync(PipelineMessage message)
        {
            await _pipelinePolicy.OnRequestSentAsync(HttpMessage.AssertHttpMessage(message)).ConfigureAwait(false);

            _afterProcess = Stopwatch.GetTimestamp();
            _elapsedTime = (_afterProcess - _beforeProcess) / (double)Stopwatch.Frequency;
        }

        protected override bool ShouldRetry(PipelineMessage message, Exception? exception)
            => _pipelinePolicy.ShouldRetry(HttpMessage.AssertHttpMessage(message), exception);

        protected override async ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
            => await _pipelinePolicy.ShouldRetryAsync(HttpMessage.AssertHttpMessage(message), exception).ConfigureAwait(false);

        protected override void OnTryComplete(PipelineMessage message)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);
            httpMessage.RetryNumber++;

            AzureCoreEventSource.Singleton.RequestRetrying(httpMessage.Request.ClientRequestId, httpMessage.RetryNumber, _elapsedTime);

            // Reset stopwatch values
            _afterProcess = default;
            _beforeProcess = default;
            _elapsedTime = default;
        }

        protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);

            Debug.Assert(tryCount == httpMessage.RetryNumber);

            Response? response = httpMessage.HasResponse ? httpMessage.Response : default;
            return _delayStrategy.GetNextDelay(response, tryCount + 1);
        }

        protected override async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
            => await _pipelinePolicy.WaitAsync(time, cancellationToken).ConfigureAwait(false);

        protected override void Wait(TimeSpan time, CancellationToken cancellationToken)
            => _pipelinePolicy.Wait(time, cancellationToken);
    }
}
