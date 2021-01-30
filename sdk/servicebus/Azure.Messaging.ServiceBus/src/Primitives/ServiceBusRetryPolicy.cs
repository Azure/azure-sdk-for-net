// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   An abstract representation of a policy to govern retrying of messaging operations.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that developers without advanced needs not implement custom retry
    ///   policies but instead configure the default policy by specifying the desired set of
    ///   retry options when creating one of the Service Bus clients.
    /// </remarks>
    ///
    /// <seealso cref="ServiceBusRetryOptions"/>
    ///
    public abstract class ServiceBusRetryPolicy
    {
        private static readonly TimeSpan ServerBusyBaseSleepTime = TimeSpan.FromSeconds(10);

        private readonly object serverBusyLock = new object();

        // This is a volatile copy of IsServerBusy. IsServerBusy is synchronized with a lock, whereas encounteredServerBusy is kept volatile for performance reasons.
        private volatile bool encounteredServerBusy;

        /// <summary>
        /// Determines whether or not the server returned a busy error.
        /// </summary>
        private bool IsServerBusy { get; set; }

        /// <summary>
        /// Gets the exception message when a server busy error is returned.
        /// </summary>
        private string ServerBusyExceptionMessage { get; set; }

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        ///   Calculates the amount of time to allow the current attempt for an operation to
        ///   complete before considering it to be timed out.
        /// </summary>
        ///
        /// <param name="attemptCount">The number of total attempts that have been made, including the initial attempt before any retries.</param>
        ///
        /// <returns>The amount of time to allow for an operation to complete.</returns>
        ///
        public abstract TimeSpan CalculateTryTimeout(int attemptCount);

        /// <summary>
        ///   Calculates the amount of time to wait before another attempt should be made.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was observed for the operation to be retried.</param>
        /// <param name="attemptCount">The number of total attempts that have been made, including the initial attempt before any retries.</param>
        ///
        /// <returns>The amount of time to delay before retrying the associated operation; if <c>null</c>, then the operation is no longer eligible to be retried.</returns>
        ///
        public abstract TimeSpan? CalculateRetryDelay(
            Exception lastException,
            int attemptCount);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task RunOperation(
            Func<TimeSpan, Task> operation,
            TransportConnectionScope scope,
            CancellationToken cancellationToken)
        {
            var failedAttemptCount = 0;

            TimeSpan tryTimeout = CalculateTryTimeout(0);
            if (IsServerBusy && tryTimeout < ServerBusyBaseSleepTime)
            {
                // We are in a server busy state before we start processing.
                // Since ServerBusyBaseSleepTime > remaining time for the operation, we don't wait for the entire Sleep time.
                await Task.Delay(tryTimeout, cancellationToken).ConfigureAwait(false);
                throw new ServiceBusException(
                    ServerBusyExceptionMessage,
                    ServiceBusFailureReason.ServiceBusy);
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                if (IsServerBusy)
                {
                    await Task.Delay(ServerBusyBaseSleepTime, cancellationToken).ConfigureAwait(false);
                }

                try
                {
                    await operation(tryTimeout).ConfigureAwait(false);
                    return;
                }

                catch (Exception ex)
                {
                    Exception activeEx = AmqpExceptionHelper.TranslateException(ex);

                    // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                    // Otherwise, throw the translated exception.

                    ++failedAttemptCount;
                    TimeSpan? retryDelay = CalculateRetryDelay(activeEx, failedAttemptCount);
                    if (retryDelay.HasValue && !scope.IsDisposed && !cancellationToken.IsCancellationRequested)
                    {
                        Logger.RunOperationExceptionEncountered(activeEx.ToString());
                        await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
                        tryTimeout = CalculateTryTimeout(failedAttemptCount);
                    }
                    else
                    {
                        ExceptionDispatchInfo.Capture(activeEx)
                            .Throw();
                    }
                }
            }
            // If no value has been returned nor exception thrown by this point,
            // then cancellation has been requested.
            throw new TaskCanceledException();
        }

        internal void SetServerBusy(string exceptionMessage)
        {
            // multiple call to this method will not prolong the timer.
            if (encounteredServerBusy)
            {
                return;
            }

            lock (serverBusyLock)
            {
                if (!encounteredServerBusy)
                {
                    encounteredServerBusy = true;
                    ServerBusyExceptionMessage = string.IsNullOrWhiteSpace(exceptionMessage) ?
                        Resources.DefaultServerBusyException : exceptionMessage;
                    IsServerBusy = true;
                    _ = ScheduleResetServerBusy();
                }
            }
        }

        internal void ResetServerBusy()
        {
            if (!encounteredServerBusy)
            {
                return;
            }

            lock (serverBusyLock)
            {
                if (encounteredServerBusy)
                {
                    encounteredServerBusy = false;
                    ServerBusyExceptionMessage = Resources.DefaultServerBusyException;
                    IsServerBusy = false;
                }
            }
        }

        private async Task ScheduleResetServerBusy()
        {
            await Task.Delay(ServerBusyBaseSleepTime).ConfigureAwait(false);
            ResetServerBusy();
        }
    }
}
