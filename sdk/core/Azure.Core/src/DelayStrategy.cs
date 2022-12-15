// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    /// <summary>
    /// Strategy to control delay behavior.
    /// </summary>
    public abstract class DelayStrategy
    {
        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="attempt"></param>
        /// <param name="delayHint"></param>
        /// <returns> Delay interval of next iteration. </returns>
        public abstract TimeSpan GetNextDelay(Response response, int attempt, TimeSpan? delayHint);

        /// <summary>
        /// Gets the server specified delay. If there is no response, <see cref="TimeSpan.Zero"/> is returned.
        /// This method can be used to help calculate the next delay when overriding <see cref="GetNextDelay"/>, i.e.
        /// implementors may want to add the server delay to their own custom delay.
        /// </summary>
        /// <param name="response">The response to inspect for the server specified delay.</param>
        /// <returns>The server specified delay.</returns>
        protected internal static TimeSpan GetServerDelay(Response? response)
        {
            if (response == null)
            {
                return TimeSpan.Zero;
            }
            if (response.TryGetHeader(RetryAfterMsHeaderName, out var retryAfterValue) ||
                response.TryGetHeader(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromMilliseconds(delaySeconds);
                }
            }

            if (response.TryGetHeader(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromSeconds(delaySeconds);
                }
                if (DateTimeOffset.TryParse(retryAfterValue, out DateTimeOffset delayTime))
                {
                    return delayTime - DateTimeOffset.Now;
                }
            }

            return TimeSpan.Zero;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
