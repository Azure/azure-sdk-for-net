// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="DelayStrategy"/> of which the interval is from
    /// retry-after header of service response.
    /// </summary>
    internal class RetryAfterDelayStrategy : DelayStrategy
    {
        protected const string RetryAfterHeaderName = "Retry-After";
        protected const string RetryAfterMsHeaderName = "retry-after-ms";
        protected const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        private DelayStrategy _fallbackStrategy;

        /// <summary>
        /// Create a <see cref="RetryAfterDelayStrategy"/> with a default retry-after value which normally
        /// comes from the initial response of an LRO operation.
        /// </summary>
        /// <param name="fallbackStrategy"> Fallback strategy if retry after is not present. </param>
        public RetryAfterDelayStrategy(DelayStrategy? fallbackStrategy = null)
        {
            _fallbackStrategy = fallbackStrategy ?? new ConstantDelayStrategy();
        }

        /// <summary>
        /// Get the polling interval from the max value of retry-after header of given service response and <paramref name="delayHint"/>.
        /// If retry-after header is not found, adopt the value of last retry-after header.
        /// </summary>
        /// <param name="response">Service response which might carry retry-after header.</param>
        /// <param name="attempt"></param>
        /// <param name="delayHint">Suggested pollingInterval.</param>
        /// <returns>Max value of retry-after header and <paramref name="delayHint"/>.</returns>
        public override TimeSpan GetNextDelay(Response response, int attempt, TimeSpan? delayHint)
        {
            TimeSpan delay = TimeSpan.Zero;
            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    delay = TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                }
            }
            else if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    delay = TimeSpan.FromSeconds(serverDelayInSeconds);
                }
            }

            return Max(delay, _fallbackStrategy.GetNextDelay(response, attempt, delayHint));
        }
    }
}
