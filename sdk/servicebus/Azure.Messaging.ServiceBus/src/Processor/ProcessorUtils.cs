// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    internal static class ProcessorUtils
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="lockedUntil"></param>
        /// <returns></returns>
        internal static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntil)
        {
            var remainingTime = lockedUntil - DateTimeOffset.UtcNow;

            if (remainingTime < TimeSpan.FromMilliseconds(400))
            {
                return TimeSpan.Zero;
            }

            var buffer = TimeSpan.FromTicks(Math.Min(remainingTime.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            var renewAfter = remainingTime - buffer;

            return renewAfter;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="errorHandler"></param>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        internal static async Task RaiseExceptionReceived(
            Func<ProcessErrorEventArgs, Task> errorHandler,
            ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await errorHandler(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                MessagingEventSource.Log.ExceptionReceivedHandlerThrewException(exception);
            }
        }
    }
}
