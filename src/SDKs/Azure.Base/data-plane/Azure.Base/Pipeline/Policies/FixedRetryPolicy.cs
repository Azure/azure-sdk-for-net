// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Base.Pipeline.Policies
{
    public class FixedRetryPolicy : RetryPolicy
    {
        /// <summary>
        /// Gets or sets the maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 10;

        /// <summary>
        /// Gets or sets the timespan to wait before retries.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1);

        protected override bool IsRetriableResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = Delay;

            if (attempted > MaxRetries)
            {
                return false;
            }

            return !message.ResponseClassifier.IsFatalErrorResponse(message.Response);
        }

        protected override bool IsRetriableException(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = Delay;

            if (attempted > MaxRetries)
            {
                return false;
            }

            return !message.ResponseClassifier.IsFatalException(exception);
        }
    }
}
