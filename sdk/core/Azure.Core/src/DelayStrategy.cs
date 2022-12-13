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
        ///
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;
    }
}
