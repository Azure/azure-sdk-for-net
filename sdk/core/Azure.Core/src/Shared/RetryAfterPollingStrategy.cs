// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="OperationPollingStrategy"/> of which the interval is from
    /// retry-after header of service response.
    /// </summary>
    internal class RetryAfterPollingStrategy : OperationPollingStrategy
    {
        protected const string RetryAfterHeaderName = "Retry-After";
        protected const string RetryAfterMsHeaderName = "retry-after-ms";
        protected const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        public TimeSpan LastPollingInterval { get; private set; }

        protected RetryAfterPollingStrategy(TimeSpan defaultPollingInterval)
        {
            LastPollingInterval = defaultPollingInterval;
        }

        /// <summary>
        /// Get the polling interval for retry-after header of given service response. If no valid header is found,
        /// returns the last polling interval.
        /// </summary>
        /// <param name="response">Service response which might carry retry-after header.</param>
        /// <returns>Polling interval for next iteration.</returns>
        public override TimeSpan GetNextWait(Response response)
        {
            if (TryGetRetryAfter(response, out TimeSpan? retryAfter))
            {
                LastPollingInterval = retryAfter!.Value;
            }
            return LastPollingInterval;
        }

        /// <summary>
        /// Try to parse the retry-after header from service response, and create a
        /// <see cref="RetryAfterPollingStrategy"/> of which the default inteval is set to the retry-after
        /// header value.
        /// </summary>
        /// <param name="response">Service response which might contain valid retry-after header. Normally it's the original response of LRO operation.</param>
        /// <param name="pollingStrategy">A <see cref="RetryAfterPollingStrategy"/> of which the default inteval is set to the retry-after header.</param>
        /// <returns>true if a valid retry-after header is found in the given response; false otherwise.</returns>
        public static bool TryParseAndBuild(Response response, out RetryAfterPollingStrategy? pollingStrategy)
        {
            pollingStrategy = null;
            if (TryGetRetryAfter(response, out TimeSpan? retryAfter))
            {
                pollingStrategy = new RetryAfterPollingStrategy(retryAfter!.Value);
                return true;
            }
            return false;
        }

        protected static bool TryGetRetryAfter(Response response, out TimeSpan? retryAfter)
        {
            retryAfter = null;
            if (response == null)
            {
                return false;
            }

            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    retryAfter = TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                    return true;
                }
            }
            else if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    retryAfter = TimeSpan.FromSeconds(serverDelayInSeconds);
                    return true;
                }
            }

            return false;
        }
    }
}
