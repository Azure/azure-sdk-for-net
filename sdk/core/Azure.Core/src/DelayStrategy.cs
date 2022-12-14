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
        /// <param name="suggestedInterval"> Suggested pollingInterval. It is up to strategy
        /// implementation to decide how to deal with this parameter. </param>
        /// <returns> Delay interval of next iteration. </returns>
        public abstract TimeSpan GetNextDelay(Response response, int attempt, TimeSpan? suggestedInterval);

        /// <summary>
        /// Gets the server specified delay. If the message has no response, <see cref="TimeSpan.Zero"/> is returned.
        /// This method can be used to help calculate the next delay when overriding <see cref="GetNextDelay"/>, i.e.
        /// implementors may want to add the server delay to their own custom delay.
        /// </summary>
        /// <param name="message">The message to inspect for the server specified delay.</param>
        /// <returns>The server specified delay.</returns>
        protected internal static TimeSpan GetServerDelay(HttpMessage message)
        {
            if (!message.HasResponse)
            {
                return TimeSpan.Zero;
            }

            if (message.Response.TryGetHeader(RetryAfterMsHeaderName, out var retryAfterValue) ||
                message.Response.TryGetHeader(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromMilliseconds(delaySeconds);
                }
            }

            if (message.Response.TryGetHeader(RetryAfterHeaderName, out retryAfterValue))
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
