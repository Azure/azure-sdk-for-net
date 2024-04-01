// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialImdsRetryPolicy : RetryPolicy
    {
        private bool _firstRequestComplete;
        private readonly Uri _imdsUri;

        public DefaultAzureCredentialImdsRetryPolicy(RetryOptions retryOptions, DelayStrategy delayStrategy = null) : base(retryOptions.MaxRetries,
                    delayStrategy ?? DelayStrategy.CreateExponentialDelayStrategy(retryOptions.Delay, retryOptions.MaxDelay))
        {
            _imdsUri = ImdsManagedIdentitySource.GetImdsUri();
        }

        protected override bool ShouldRetry(HttpMessage message, Exception exception)
        {
            // For IMDS requests, do not retry until we have observed the first response cycle
            var doRetry = _firstRequestComplete || !(message.Request.Uri.Host ==_imdsUri.Host && message.Request.Uri.Path == _imdsUri.AbsolutePath) ? base.ShouldRetry(message, exception) : false;
            Console.WriteLine($"{doRetry}");
            return doRetry;
        }

        protected override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
        {
            // For IMDS requests, do not retry until we have observed the first response cycle
            return _firstRequestComplete || !(message.Request.Uri.Host ==_imdsUri.Host && message.Request.Uri.Path == _imdsUri.AbsolutePath) ? base.ShouldRetryAsync(message, exception) : default;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            base.Process(message, pipeline);
            _firstRequestComplete = true;
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var result = base.ProcessAsync(message, pipeline);
            _firstRequestComplete = true;
            return result;
        }
    }
}
