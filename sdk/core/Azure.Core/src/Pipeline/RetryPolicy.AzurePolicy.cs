// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
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

        protected override void OnTryComplete(PipelineMessage message)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);
            httpMessage.RetryNumber++;

            AzureCoreEventSource.Singleton.RequestRetrying(httpMessage.Request.ClientRequestId, httpMessage.RetryNumber, _elapsedTime);

            // Reset stopwatch values
            _afterProcess = default;
            _beforeProcess = default;
            _elapsedTime = default;
        }

        protected override TimeSpan GetNextDelayCore(PipelineMessage message, int tryCount)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);

            Debug.Assert(tryCount == httpMessage.RetryNumber);

            Response? response = httpMessage.HasResponse ? httpMessage.Response : default;
            return _delayStrategy.GetNextDelay(response, tryCount + 1);
        }

        private static HttpMessage AssertHttpMessage(PipelineMessage message)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message?.GetType()}'.");
            }

            return httpMessage;
        }
    }
}
