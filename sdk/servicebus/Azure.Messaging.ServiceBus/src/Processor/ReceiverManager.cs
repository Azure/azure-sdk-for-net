// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents a single receiver instance that multiple threads spawned by the ServiceBusProcessor
    /// may be using to receive and process messages. The manager will delegate to the user provided
    /// callbacks and handle automatic locking of messages.
    /// </summary>
    internal class ReceiverManager
    {
        protected virtual ServiceBusReceiver Receiver { get; set; }
        protected readonly ServiceBusConnection _connection;
        protected readonly string _fullyQualifiedNamespace;
        protected readonly string _entityPath;
        protected readonly string _identifier;
        protected readonly TimeSpan? _maxReceiveWaitTime;
        private readonly ServiceBusReceiverOptions _receiverOptions;
        protected readonly ServiceBusProcessorOptions _processorOptions;
        private readonly Func<ProcessErrorEventArgs, Task> _errorHandler;
        private readonly Func<ProcessMessageEventArgs, Task> _messageHandler;
        protected readonly EntityScopeFactory _scopeFactory;

        protected bool AutoRenewLock => _processorOptions.MaxAutoLockRenewalDuration > TimeSpan.Zero;

        public ReceiverManager(
            ServiceBusConnection connection,
            string fullyQualifiedNamespace,
            string entityPath,
            string identifier,
            ServiceBusProcessorOptions processorOptions,
            Func<ProcessMessageEventArgs, Task> messageHandler,
            Func<ProcessErrorEventArgs, Task> errorHandler,
            EntityScopeFactory scopeFactory)
        {
            _connection = connection;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _entityPath = entityPath;
            _processorOptions = processorOptions;
            _receiverOptions = new ServiceBusReceiverOptions
            {
                ReceiveMode = _processorOptions.ReceiveMode,
                PrefetchCount = _processorOptions.PrefetchCount
            };
            _maxReceiveWaitTime = _processorOptions.MaxReceiveWaitTime;
            _identifier = identifier;
            Receiver = new ServiceBusReceiver(
                connection: _connection,
                entityPath: _entityPath,
                isSessionEntity: false,
                options: _receiverOptions);
            _errorHandler = errorHandler;
            _messageHandler = messageHandler;
            _scopeFactory = scopeFactory;
        }

        public virtual async Task CloseReceiverIfNeeded(
            CancellationToken cancellationToken,
            bool forceClose = false)
        {
            try
            {
                await Receiver.DisposeAsync().ConfigureAwait(false);
            }
            finally
            {
                Receiver = null;
            }
        }

        public virtual async Task ReceiveAndProcessMessagesAsync(CancellationToken cancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            try
            {
                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    ServiceBusReceivedMessage message = await Receiver.ReceiveMessageAsync(
                        _maxReceiveWaitTime,
                        cancellationToken).ConfigureAwait(false);
                    if (message == null)
                    {
                        continue;
                    }
                    await ProcessOneMessageWithinScopeAsync(
                        message,
                        DiagnosticProperty.ProcessMessageActivityName,
                        cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (!(ex is TaskCanceledException))
            {
                if (ex is ServiceBusException sbException && sbException.ProcessorErrorSource.HasValue)
                {
                    errorSource = sbException.ProcessorErrorSource.Value;
                }
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        _fullyQualifiedNamespace,
                        _entityPath))
                    .ConfigureAwait(false);
            }
        }

        protected async Task ProcessOneMessageWithinScopeAsync(ServiceBusReceivedMessage message, string activityName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _scopeFactory.CreateScope(activityName);
            scope.Start();
            scope.SetMessageData(new ServiceBusReceivedMessage[] { message });
            try
            {
                await ProcessOneMessage(
                    message,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="processorCancellationToken"></param>
        /// <returns></returns>
        private async Task ProcessOneMessage(
            ServiceBusReceivedMessage message,
            CancellationToken processorCancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Task renewLock = null;

            try
            {
                if (!Receiver.IsSessionReceiver &&
                    Receiver.ReceiveMode == ReceiveMode.PeekLock &&
                    AutoRenewLock)
                {
                    renewLockCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(processorCancellationToken);
                    renewLock = RenewMessageLock(
                        message,
                        renewLockCancellationTokenSource);
                }

                errorSource = ServiceBusErrorSource.UserCallback;

                await OnMessageHandler(message, processorCancellationToken).ConfigureAwait(false);

                if (Receiver.ReceiveMode == ReceiveMode.PeekLock &&
                    _processorOptions.AutoComplete &&
                    !message.IsSettled)
                {
                    errorSource = ServiceBusErrorSource.Complete;
                    // don't pass the processor cancellation token
                    // as we want in flight autocompletion to be able
                    // to finish
                    await Receiver.CompleteMessageAsync(
                        message.LockToken,
                        CancellationToken.None)
                        .ConfigureAwait(false);
                }

                await CancelTask(renewLockCancellationTokenSource, renewLock).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is TaskCanceledException))
            {
                ThrowIfSessionLockLost(ex, errorSource);
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        _fullyQualifiedNamespace,
                        _entityPath))
                    .ConfigureAwait(false);

                // if the user settled the message, or if the message or session lock was lost,
                // do not attempt to abandon the message
                ServiceBusException.FailureReason? failureReason = (ex as ServiceBusException)?.Reason;
                if (!message.IsSettled &&
                    _receiverOptions.ReceiveMode == ReceiveMode.PeekLock &&
                    failureReason != ServiceBusException.FailureReason.SessionLockLost &&
                    failureReason != ServiceBusException.FailureReason.MessageLockLost)
                {
                    try
                    {
                        // don't pass the processor cancellation token
                        // as we want in flight abandon to be able
                        // to finish even if user stopped processing
                        await Receiver.AbandonMessageAsync(
                            message.LockToken,
                            cancellationToken: CancellationToken.None)
                            .ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        ThrowIfSessionLockLost(exception, ServiceBusErrorSource.Abandon);
                        await RaiseExceptionReceived(
                            new ProcessErrorEventArgs(
                                exception,
                                ServiceBusErrorSource.Abandon,
                                _fullyQualifiedNamespace,
                                _entityPath))
                        .ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                renewLockCancellationTokenSource?.Cancel();
                renewLockCancellationTokenSource?.Dispose();
            }
        }

        protected virtual async Task OnMessageHandler(ServiceBusReceivedMessage message, CancellationToken processorCancellationToken)
        {
            var args = new ProcessMessageEventArgs(
                message,
                Receiver,
                processorCancellationToken);
            await _messageHandler(args).ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task RenewMessageLock(
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(_processorOptions.MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockStart(_identifier, 1, message.LockToken);
                    TimeSpan delay = CalculateRenewDelay(message.LockedUntil);

                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                    if (Receiver.IsDisposed)
                    {
                        break;
                    }

                    await Receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockComplete(_identifier);
                }
                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockException(_identifier, ex.ToString());
                    await HandleRenewLockException(ex, cancellationToken).ConfigureAwait(false);

                    // if the error was not transient, break out of the loop
                    if (!(ex as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Cancels the specified cancellation source and awaits the specified task.
        /// </summary>
        /// <param name="cancellationSource">CancellationTokenSource to cancel</param>
        /// <param name="task">Associated task to await</param>
        protected static async Task CancelTask(
            CancellationTokenSource cancellationSource,
            Task task)
        {
            try
            {
                if (cancellationSource != null)
                {
                    cancellationSource.Cancel();
                    await task.ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
                // Nothing to do here.  These exceptions are expected.
            }
        }

        private static void ThrowIfSessionLockLost(
            Exception exception,
            ServiceBusErrorSource errorSource)
        {
            // we need to propagate this in order to dispose the session receiver
            // in the same place where we are creating them.
            var sbException = exception as ServiceBusException;
            if (sbException?.Reason == ServiceBusException.FailureReason.SessionLockLost)
            {
                sbException.ProcessorErrorSource = errorSource;
                throw sbException;
            }
        }

        protected async Task HandleRenewLockException(Exception ex, CancellationToken cancellationToken)
        {
            // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
            // this renew exception is not relevant anymore. Lets not bother user with this exception.
            if (!(ex is ObjectDisposedException) && !cancellationToken.IsCancellationRequested)
            {
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        ServiceBusErrorSource.RenewLock,
                        _fullyQualifiedNamespace,
                        _entityPath)).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        protected async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await _errorHandler(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                ServiceBusEventSource.Log.ProcessorErrorHandlerThrewException(exception.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockedUntil"></param>
        /// <returns></returns>
        protected static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntil)
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
    }
}
