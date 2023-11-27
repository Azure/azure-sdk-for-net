// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline;

public partial class RetryPolicy
{
    internal class AzureCoreRetryPolicy : RequestRetryPolicy
    {
        private readonly RetryPolicy _pipelinePolicy;

        public AzureCoreRetryPolicy(int maxRetries, RetryPolicy policy): base(maxRetries)
        {
            _pipelinePolicy = policy;
        }

        protected override void OnSendingRequest(PipelineMessage message)
            => _pipelinePolicy.OnSendingRequest(AssertHttpMessage(message));

        protected override async ValueTask OnSendingRequestAsync(PipelineMessage message)
            => await _pipelinePolicy.OnSendingRequestAsync(AssertHttpMessage(message)).ConfigureAwait(false);

        protected override void OnRequestSent(PipelineMessage message)
            => _pipelinePolicy.OnRequestSent(AssertHttpMessage(message));

        protected override async ValueTask OnRequestSentAsync(PipelineMessage message)
            => await _pipelinePolicy.OnRequestSentAsync(AssertHttpMessage(message)).ConfigureAwait(false);

        protected override bool ShouldRetry(PipelineMessage message, Exception? exception)
            => _pipelinePolicy.ShouldRetry(AssertHttpMessage(message), exception);

        protected override async ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
            => await _pipelinePolicy.ShouldRetryAsync(AssertHttpMessage(message), exception).ConfigureAwait(false);

        protected override TimeSpan GetDelay(PipelineMessage message)
            => _pipelinePolicy.GetNextDelay(AssertHttpMessage(message));

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
