// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    internal static class CancellationTokenSourceExtensions
    {
        public static void CancelAfter(this CancellationTokenSource cancellationTokenSource,
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
    }
}
