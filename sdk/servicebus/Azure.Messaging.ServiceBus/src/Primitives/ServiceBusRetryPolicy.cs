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
        /// <summary>
        /// Represents a state flag that is used to make sure the server busy value can be observed with
        /// reasonable fresh values without having to acquire a lock.
        /// </summary>
        private volatile int _serverBusyState;

        private const int ServerNotBusyState = 0; // default value of serverBusy
        private const int ServerBusyState = 1;

        /// <summary>A generic retriable busy exception to use for delay calculations.</summary>
        private static readonly ServiceBusException DefaultServiceBusyException = new ServiceBusException(Resources.DefaultServerBusyException, ServiceBusFailureReason.ServiceBusy);

        /// <summary>
        /// Determines whether or not the server returned a busy error.
        /// </summary>
        internal bool IsServerBusy => _serverBusyState == ServerBusyState;

        /// <summary>
        /// Gets the exception message when a server busy error is returned.
        /// </summary>
        internal string ServerBusyExceptionMessage { get; set; }

        /// <summary>
        /// Gets the server busy base sleep time
        /// </summary>
        /// <remarks>Defaults to TimeSpan.FromSeconds(10)</remarks>
        internal TimeSpan ServerBusyBaseSleepTime { get; set; } = TimeSpan.FromSeconds(10);

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

        internal async ValueTask RunOperation<T1>(
            Func<T1, TimeSpan, CancellationToken, ValueTask> operation,
            T1 t1,
            TransportConnectionScope scope,
            CancellationToken cancellationToken) =>
            await RunOperation(static async (value, timeout, token) =>
            {
                var (t1, operation) = value;
                await operation(t1, timeout, token).ConfigureAwait(false);
                return default(object);
            }, (t1, operation), scope, cancellationToken).ConfigureAwait(false);

        internal async ValueTask<TResult> RunOperation<T1, TResult>(
            Func<T1, TimeSpan, CancellationToken, ValueTask<TResult>> operation,
            T1 t1,
            TransportConnectionScope scope,
            CancellationToken cancellationToken,
            bool logTimeoutRetriesAsVerbose = false)
      {
            var failedAttemptCount = 0;
            var tryTimeout = CalculateTryTimeout(0);

            if (IsServerBusy && tryTimeout < ServerBusyBaseSleepTime)
            {
                while (IsServerBusy && !cancellationToken.IsCancellationRequested)
                {
                    // If we are in a server busy state, we will wait for the try timeout.

                    await Task.Delay(tryTimeout, cancellationToken).ConfigureAwait(false);

                    // If the server is still busy, consider this a retry attempt and wait for the
                    // calculated retry delay before trying again.

                    if (IsServerBusy)
                    {
                        ++failedAttemptCount;
                        var delay = CalculateRetryDelay(DefaultServiceBusyException, failedAttemptCount);

                        if (delay.HasValue)
                        {
                            Logger.RunOperationExceptionEncountered(DefaultServiceBusyException.ToString());

                            await Task.Delay(delay.Value, cancellationToken).ConfigureAwait(false);
                            tryTimeout = CalculateTryTimeout(failedAttemptCount);
                        }
                        else
                        {
                            // If there are no retries left, then fail because the server is busy.
                            throw new ServiceBusException(
                                ServerBusyExceptionMessage,
                                ServiceBusFailureReason.ServiceBusy);
                        }
                    }
                }
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                if (IsServerBusy)
                {
                    await Task.Delay(ServerBusyBaseSleepTime, cancellationToken).ConfigureAwait(false);
                }

                try
                {
                    return await operation(t1, tryTimeout, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Exception activeEx = AmqpExceptionHelper.TranslateException(ex);

                    if (activeEx is ServiceBusException { Reason: ServiceBusFailureReason.ServiceBusy })
                    {
                        SetServerBusy(activeEx.Message, cancellationToken);
                    }

                    // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                    // Otherwise, throw the translated exception.

                    ++failedAttemptCount;
                    TimeSpan? retryDelay = CalculateRetryDelay(activeEx, failedAttemptCount);
                    if (retryDelay.HasValue && !scope.IsDisposed && !cancellationToken.IsCancellationRequested)
                    {
                        if (logTimeoutRetriesAsVerbose && activeEx is ServiceBusException { Reason: ServiceBusFailureReason.ServiceTimeout })
                        {
                            Logger.RunOperationExceptionEncounteredVerbose(activeEx.ToString());
                        }
                        else
                        {
                            Logger.RunOperationExceptionEncountered(activeEx.ToString());
                        }

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

        private void SetServerBusy(string exceptionMessage, CancellationToken cancellationToken)
        {
            // multiple call to this method will not prolong the timer.
            if (_serverBusyState == ServerBusyState)
            {
                return;
            }

            ServerBusyExceptionMessage = string.IsNullOrWhiteSpace(exceptionMessage) ?
                Resources.DefaultServerBusyException : exceptionMessage;
            Interlocked.Exchange(ref _serverBusyState, ServerBusyState);
            _ = ScheduleResetServerBusy(cancellationToken);
        }

        private void ResetServerBusy()
        {
            if (_serverBusyState == ServerNotBusyState)
            {
                return;
            }

            ServerBusyExceptionMessage = Resources.DefaultServerBusyException;
            Interlocked.Exchange(ref _serverBusyState, ServerNotBusyState);
        }

        private async Task ScheduleResetServerBusy(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(ServerBusyBaseSleepTime, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // ignored
            }
            catch (Exception ex)
            {
                // This is non-impactful to the operation; log as verbose and ignore.
                Logger.RunOperationExceptionEncounteredVerbose(ex.ToString());
            }
            finally
            {
                // In the case of cancellation or another exception while
                // waiting, we still want to reset the server busy state.
                ResetServerBusy();
            }
        }
    }
}
