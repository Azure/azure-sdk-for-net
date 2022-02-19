// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    /// <summary>
    /// Strategy to control polling behavior of LRO operation.
    /// </summary>
    internal abstract class OperationPollingStrategy
    {
        protected static readonly OperationPollingStrategy DefaultPollingStrategy = new ConstantPollingStrategy();

        /// <summary>
        /// Factory method to choose a proper <see cref="OperationPollingStrategy"/> based on given <paramref name="response"/> and <paramref name="customPollingStrategy"/>.
        /// </summary>
        /// <param name="response"> Server response. Normally it's the initial response of an LRO operation. </param>
        /// <param name="customPollingStrategy"> Default <see cref="OperationPollingStrategy"/>. </param>
        /// <returns> A <see cref="RetryAfterPollingStrategy"/> if there is a valid retry-after heawder in given <paramref name="response"/>; <paramref name="customPollingStrategy"/> otherwise. </returns>
        public static OperationPollingStrategy ChoosePollingStrategy(Response response, OperationPollingStrategy? customPollingStrategy)
        {
            return RetryAfterPollingStrategy.IsRetryAfterPresent(response) ? new RetryAfterPollingStrategy(response) : customPollingStrategy ?? DefaultPollingStrategy;
        }

        /// <summary>
        /// Get the interval of next polling iteration.
        /// </summary>
        /// <remarks>Note that the value could change per call.</remarks>
        /// <param name="response">Server response.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval. It is up to strategy
        /// implementation to decide how to deal with this parameter.</param>
        /// <returns>Polling interval of next iteration.</returns>
        public abstract TimeSpan GetNextWait(Response response, TimeSpan? suggestedInterval);

        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
