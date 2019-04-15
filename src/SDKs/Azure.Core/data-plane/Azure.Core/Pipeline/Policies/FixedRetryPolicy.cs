// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Core.Pipeline.Policies
{
    public class FixedRetryPolicy : RetryPolicy
    {
        /// <summary>
        /// Gets or sets the list of response status codes to retry.
        /// </summary>
        public int[] RetriableCodes { get; set; } = Array.Empty<int>();

        /// <summary>
        /// Gets or sets the delegate to specify is exception should be retried.
        /// </summary>
        public Func<Exception, bool> ShouldRetryException { get; set; } = _ => false;

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

            return Array.IndexOf(RetriableCodes, message.Response.Status) >= 0;
        }

        protected override bool IsRetriableException(Exception exception, int attempted, out TimeSpan delay)
        {
            delay = Delay;

            if (attempted > MaxRetries)
            {
                return false;
            }

            return ShouldRetryException != null && ShouldRetryException(exception);
        }
    }
}
