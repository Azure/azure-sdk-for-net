// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extensions for the <see cref="TimeSpan" /> class.
    /// </summary>
    ///
    internal static class TimeSpanExtensions
    {
        /// <summary>
        ///   Calculates the duration remaining in a given period, with consideration to
        ///   the amount of time that has already elapsed.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="elapsed">The amount of time that has already elapsed.</param>
        ///
        /// <returns>The amount of time remaining in the time period.</returns>
        ///
        public static TimeSpan CalculateRemaining(this TimeSpan instance,
                                                  TimeSpan elapsed)
        {
            if ((instance == Timeout.InfiniteTimeSpan) || (instance == TimeSpan.Zero) || (elapsed == TimeSpan.Zero))
            {
                return instance;
            }

            if (elapsed >= instance)
            {
                return TimeSpan.Zero;
            }

            return TimeSpan.FromMilliseconds(instance.TotalMilliseconds - elapsed.TotalMilliseconds);
        }
    }
}
