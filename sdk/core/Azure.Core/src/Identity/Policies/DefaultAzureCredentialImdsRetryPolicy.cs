// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialImdsRetryPolicy : RetryPolicy
    {
        private static ManagedIdentityResponseClassifier classifier = new ManagedIdentityResponseClassifier();

        public DefaultAzureCredentialImdsRetryPolicy(RetryOptions retryOptions, DelayStrategy delayStrategy = null) : base(retryOptions.MaxRetries,
                    delayStrategy ?? new ImdsRetryDelayStrategy(retryOptions.Delay, retryOptions.MaxDelay))
        {
        }

        protected internal override bool ShouldRetry(HttpMessage message, Exception exception)
        {
            message.ResponseClassifier = classifier;
            return ImdsManagedIdentityProbeSource.IsProbRequest(message) ? false : base.ShouldRetry(message, exception);
        }

        protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
        {
            message.ResponseClassifier = classifier;
            return ImdsManagedIdentityProbeSource.IsProbRequest(message) ? default : base.ShouldRetryAsync(message, exception);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            base.Process(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var result = base.ProcessAsync(message, pipeline);
            return result;
        }
    }
}
