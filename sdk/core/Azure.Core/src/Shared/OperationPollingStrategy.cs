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
        /// Get the interval of next polling iteration.
        /// </summary>
        /// <remarks>Note that the value could change per call.</remarks>
        /// <param name="response">Server response.</param>
        /// <returns>Polling interval of next iteration.</returns>
        public abstract TimeSpan GetNextWait(Response response);

        protected static TimeSpan GetMaxIntervalFromResponseAndIntrinsic(Response response, TimeSpan intrinsic)
        {
            if (TryGetRetryAfter(response, out TimeSpan? retryAfter))
            {
                return GetMaxInterval(retryAfter!.Value, intrinsic);
            }
            return intrinsic;
        }

        protected static TimeSpan GetMaxInterval(TimeSpan a, TimeSpan b)
        {
            return a > b ? a : b;
        }

        protected static bool TryGetRetryAfter(Response response, out TimeSpan? retryAfter)
        {
            retryAfter = null;
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
