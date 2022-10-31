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

        public GlobalTimeoutRetryPolicy(RetryOptions options, TimeSpan timeout) : base(options)
        {
            _timeout = timeout;
        }

        protected internal override bool ShouldRetry(HttpMessage message)
        {
            return ShouldRetryInternalAsync(message, false).EnsureCompleted();
        }
        protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message)
        {
            return ShouldRetryInternalAsync(message, true);
        }

        private ValueTask<bool> ShouldRetryInternalAsync(HttpMessage message, bool async)
        {
            TimeSpan elapsedTime = message.ProcessingContext.StartTime - DateTimeOffset.UtcNow;
            if (elapsedTime > _timeout)
            {
                return new ValueTask<bool>(false);
            }

            return async ? base.ShouldRetryAsync(message) : new ValueTask<bool>(base.ShouldRetry(message));
        }
    }
    #endregion
}