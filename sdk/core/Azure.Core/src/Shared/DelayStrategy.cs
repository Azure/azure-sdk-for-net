// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    /// <summary>
    /// Strategy to control polling behavior of LRO operation.
    /// </summary>
    internal abstract class DelayStrategy
    {
        private static readonly DelayStrategy DefaultDelayStrategy = new ConstantDelayStrategy();

        /// <summary>
        /// Factory method to choose a proper <see cref="DelayStrategy"/>  Currently it will always give you a <see cref="RetryAfterDelayStrategy"/>.
        /// If retry after is not present it will fallback to the strategy passed in or the default <see cref="ConstantDelayStrategy"/>.
        /// </summary>
        /// <param name="fallbackStrategy"> Default <see cref="DelayStrategy"/>. </param>
        public static DelayStrategy ChooseDelayStrategy(DelayStrategy? fallbackStrategy)
        {
            return new RetryAfterDelayStrategy(fallbackStrategy ?? DefaultDelayStrategy);
        }

        /// <summary>
        /// Get the interval of next delay iteration.
        /// </summary>
        /// <remarks> Note that the value could change per call. </remarks>
        /// <param name="response"> Server response. </param>
        /// <param name="suggestedInterval"> Suggested pollingInterval. It is up to strategy
        /// implementation to decide how to deal with this parameter. </param>
        /// <returns> Delay interval of next iteration. </returns>
        public abstract TimeSpan GetNextDelay(Response response, TimeSpan? suggestedInterval);

        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
