// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    internal static class CancellationTokenSourceExtensions
    {
        public static void CancelAfterLockExpired(
            this CancellationTokenSource? cancellationTokenSource,
            ServiceBusReceivedMessage receivedMessage)
        {
            if (cancellationTokenSource is null || receivedMessage.LockedUntil == default)
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

        public static void CancelAfterLockExpired(
            this CancellationTokenSource? cancellationTokenSource,
            ServiceBusSessionReceiver? sessionReceiver)
        {
            if (cancellationTokenSource is null || sessionReceiver is null)
            {
                return;
            }

            var delay = sessionReceiver.SessionLockedUntil.Subtract(DateTimeOffset.UtcNow);
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
