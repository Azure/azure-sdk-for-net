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

        private TimeSpan lastRetryAfter { get; set; }

        /// <summary>
        /// Create a <see cref="RetryAfterPollingStrategy"/> with a default retry-after value which normally
        /// comes from the initial response of an LRO operation.
        /// </summary>
        /// <param name="originalResponse"> Original response for the LRO. </param>
        public RetryAfterPollingStrategy(Response originalResponse)
        {
            lastRetryAfter = GetRetryAfterInterval(originalResponse);
        }

        /// <summary>
        /// Get the polling interval from the max value of retry-after header of given service response and <paramref name="suggestedInterval"/>.
        /// If retry-after header is not found, adopt the value of last retry-after header.
        /// </summary>
        /// <param name="response">Service response which might carry retry-after header.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval.</param>
        /// <returns>Max value of retry-after header and <paramref name="suggestedInterval"/>.</returns>
        public override TimeSpan GetNextWait(Response response, TimeSpan? suggestedInterval)
        {
            lastRetryAfter = GetRetryAfterInterval(response);
            return lastRetryAfter;
        }

        private TimeSpan GetRetryAfterInterval(Response response)
        {
            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    return TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                }
            }
            else if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    return TimeSpan.FromSeconds(serverDelayInSeconds);
                }
            }

            return lastRetryAfter;
        }

        internal static bool IsRetryAfterPresent(Response response)
        {
            return response is not null &&
                (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue) ||
                response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue));
        }
    }
}
