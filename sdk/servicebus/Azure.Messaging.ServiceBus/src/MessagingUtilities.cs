// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    internal static class MessagingUtilities
    {
        public static TimeSpan CalculateRenewAfterDuration(DateTime lockedUntilUtc)
        {
            var remainingTime = lockedUntilUtc - DateTime.UtcNow;

            if (remainingTime < TimeSpan.FromMilliseconds(400))
            {
                return TimeSpan.Zero;
            }

            var buffer = TimeSpan.FromTicks(Math.Min(remainingTime.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            var renewAfter = remainingTime - buffer;

            return renewAfter;
        }

        public static bool ShouldRetry(Exception exception)
        {
            var serviceBusException = exception as ServiceBusException;
            return serviceBusException?.IsTransient == true;
        }
    }
}