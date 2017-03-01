// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    static class MessagingUtilities
    {
        public static TimeSpan CalculateRenewAfterDuration(DateTime lockedUntilUtc)
        {
            TimeSpan remaining = lockedUntilUtc - DateTime.UtcNow;
            if (remaining < TimeSpan.Zero)
            {
                // It is possible that time is not synchronized, clock moved backward or session has already expired.
                // Let's assume the session is still valid for half of minimum lock duration.
                remaining = TimeSpan.FromTicks(Constants.MinimumLockDuration.Ticks / 2);
            }

            TimeSpan buffer = TimeSpan.FromTicks(Math.Min(remaining.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            TimeSpan renewAfter = remaining - buffer;

            return renewAfter;
        }
    }
}