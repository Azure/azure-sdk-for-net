// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    internal static class CancellationTokenSourceExtensions
    {
        public static void CancelAfterLockExpired(this CancellationTokenSource cancellationTokenSource,
            ServiceBusReceivedMessage receivedMessage)
        {
            if (cancellationTokenSource == null || receivedMessage.LockedUntil == default)
            {
                return;
            }

            var delay = receivedMessage.LockedUntil.Subtract(DateTimeOffset.UtcNow);
            if (delay > TimeSpan.Zero)
            {
                cancellationTokenSource.CancelAfter(delay);
            }
            else
            {
                cancellationTokenSource.Cancel();
            }
        }

        public static void CancelAfterSessionLockExpired(this CancellationTokenSource cancellationTokenSource,
            ServiceBusSessionReceiver sessionReceiver, DateTimeOffset utcNow)
        {
            if (cancellationTokenSource == null || sessionReceiver.SessionLockedUntil == default)
            {
                return;
            }

            var delay = sessionReceiver.SessionLockedUntil.Subtract(utcNow);
            if (delay > TimeSpan.Zero)
            {
                cancellationTokenSource.CancelAfter(delay);
            }
            else
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
