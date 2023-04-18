// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Samples
{
    #region Snippet:GlobalTimeoutRetryPolicy
    internal class GlobalTimeoutRetryPolicy : RetryPolicy
    {
        private readonly TimeSpan _timeout;

        public GlobalTimeoutRetryPolicy(int maxRetries, DelayStrategy delayStrategy, TimeSpan timeout) : base(maxRetries, delayStrategy)
        {
            _timeout = timeout;
        }

        protected internal override bool ShouldRetry(HttpMessage message, Exception exception)
        {
            return ShouldRetryInternalAsync(message, exception, false).EnsureCompleted();
        }
        protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
        {
            return ShouldRetryInternalAsync(message, exception, true);
        }

        private ValueTask<bool> ShouldRetryInternalAsync(HttpMessage message, Exception exception, bool async)
        {
            TimeSpan elapsedTime = message.ProcessingContext.StartTime - DateTimeOffset.UtcNow;
            if (elapsedTime > _timeout)
            {
                return new ValueTask<bool>(false);
            }

            return async ? base.ShouldRetryAsync(message, exception) : new ValueTask<bool>(base.ShouldRetry(message, exception));
        }
    }
    #endregion
}