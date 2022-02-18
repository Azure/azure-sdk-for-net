// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    /// <summary>
    /// Polling strategy of <see cref="OperationInternalBase"/>.
    /// </summary>
    internal abstract class OperationPollingStrategy
    {
        protected const string RetryAfterHeaderName = "Retry-After";
        protected const string RetryAfterMsHeaderName = "retry-after-ms";
        protected const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        /// <summary>
        /// Factory method to choose a proper <see cref="OperationPollingStrategy"/> based on given <paramref name="response"/> and <paramref name="defaultPollingStrategy"/>.
        /// </summary>
        /// <param name="response">Server response. Normally it's the initial response of an LRO operation.</param>
        /// <param name="defaultPollingStrategy">Default <see cref="OperationPollingStrategy"/>.</param>
        /// <returns>A <see cref="RetryAfterPollingStrategy"/> if there is a valid retry-after heawder in given <paramref name="response"/>; <paramref name="defaultPollingStrategy"/> otherwise.</returns>
        public static OperationPollingStrategy ChoosePollingStrategy(Response response, OperationPollingStrategy defaultPollingStrategy)
        {
            if (TryParseAndBuild(response, out RetryAfterPollingStrategy? pollingStrategy))
            {
                return pollingStrategy!;
            }
            return defaultPollingStrategy;
        }

        /// <summary>
        /// Try to parse the retry-after header from service response, and create a
        /// <see cref="RetryAfterPollingStrategy"/> of which the default inteval is set to the retry-after
        /// header value.
        /// </summary>
        /// <param name="response">Service response which might contain valid retry-after header. Normally it's the original response of LRO operation.</param>
        /// <param name="pollingStrategy">A <see cref="RetryAfterPollingStrategy"/> of which the default inteval is set to the retry-after header.</param>
        /// <returns>true if a valid retry-after header is found in the given response; false otherwise.</returns>
        private static bool TryParseAndBuild(Response response, out RetryAfterPollingStrategy? pollingStrategy)
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

        /// <summary>
        /// Get the interval of next polling iteration.
        /// </summary>
        /// <remarks>Note that the value could change per call.</remarks>
        /// <param name="response">Server response.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval. It is up to strategy
        /// implementation to decide how to deal with this parameter.</param>
        /// <returns>Polling interval of next iteration.</returns>
        public abstract TimeSpan GetNextWait(Response response, TimeSpan suggestedInterval);

        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
