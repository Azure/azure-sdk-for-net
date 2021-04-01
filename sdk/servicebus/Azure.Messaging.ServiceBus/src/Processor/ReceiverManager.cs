// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents a single receiver instance that multiple tasks spawned by the
    /// <see cref="ServiceBusProcessor"/> may be using to receive and process messages.
    /// The manager will delegate to the user provided callbacks and handle automatic
    /// locking of messages.
    /// </summary>
    internal class ReceiverManager
    {
        protected virtual ServiceBusReceiver Receiver { get; set; }

        protected readonly ServiceBusProcessor Processor;
        protected readonly TimeSpan? _maxReceiveWaitTime;
        private readonly ServiceBusReceiverOptions _receiverOptions;
        protected readonly ServiceBusProcessorOptions ProcessorOptions;
        protected readonly EntityScopeFactory _scopeFactory;
        protected readonly IList<ServiceBusPlugin> _plugins;

        protected bool AutoRenewLock => ProcessorOptions.MaxAutoLockRenewalDuration > TimeSpan.Zero;

        public ReceiverManager(
            ServiceBusProcessor processor,
            EntityScopeFactory scopeFactory,
            IList<ServiceBusPlugin> plugins)
        {
            Processor = processor;
            ProcessorOptions = processor.Options;
            _receiverOptions = new ServiceBusReceiverOptions
            {
                ReceiveMode = ProcessorOptions.ReceiveMode,
                PrefetchCount = ProcessorOptions.PrefetchCount,
            };
            _maxReceiveWaitTime = ProcessorOptions.MaxReceiveWaitTime;
            _plugins = plugins;
            Receiver = new ServiceBusReceiver(
                connection: Processor.Connection,
                entityPath: Processor.EntityPath,
                isSessionEntity: false,
                plugins: _plugins,
                options: _receiverOptions);
            _scopeFactory = scopeFactory;
        }

        public virtual async Task CloseReceiverIfNeeded(
            CancellationToken cancellationToken,
            bool forceClose = false)
        {
            var capturedReceiver = Receiver;
            if (capturedReceiver != null)
            {
                try
                {
                    await capturedReceiver.DisposeAsync().ConfigureAwait(false);
                }
                finally
                {
                    Receiver = null;
                }
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
            catch (Exception ex)
            // If the user manually throws a TCE, then we should log it.
            when (!(ex is TaskCanceledException) ||
                  !cancellationToken.IsCancellationRequested)
            {
                if (ex is ServiceBusException sbException && sbException.ProcessorErrorSource.HasValue)
                {
                    errorSource = sbException.ProcessorErrorSource.Value;
                }
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        cancellationToken))
                    .ConfigureAwait(false);
            }
        }

        protected async Task ProcessOneMessageWithinScopeAsync(ServiceBusReceivedMessage message, string activityName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _scopeFactory.CreateScope(activityName, DiagnosticProperty.ConsumerKind);
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

        private async Task ProcessOneMessage(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Task renewLock = null;

            try
            {
                if (!Receiver.IsSessionReceiver &&
                    Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                    AutoRenewLock)
                {
                    renewLockCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    renewLock = RenewMessageLock(
                        message,
                        renewLockCancellationTokenSource);
                }

                errorSource = ServiceBusErrorSource.ProcessMessageCallback;

                try
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerStart(Processor.Identifier, message.SequenceNumber);
                    await OnMessageHandler(message, cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorMessageHandlerComplete(Processor.Identifier, message.SequenceNumber);
                }
                catch (Exception ex)
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerException(Processor.Identifier, message.SequenceNumber, ex.ToString());
                    throw;
                }

                if (Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                    ProcessorOptions.AutoCompleteMessages &&
                    !message.IsSettled)
                {
                    errorSource = ServiceBusErrorSource.Complete;
                    // don't pass the processor cancellation token
                    // as we want in flight auto-completion to be able
                    // to finish
                    await Receiver.CompleteMessageAsync(
                        message.LockToken,
                        CancellationToken.None)
                        .ConfigureAwait(false);
                }

                await CancelTask(renewLockCancellationTokenSource, renewLock).ConfigureAwait(false);
            }
            catch (Exception ex)
            // This prevents exceptions relating to processing a message from bubbling up all
            // the way to the main thread when calling StopProcessingAsync, which we don't want
            // as it isn't actionable.
            when (!(ex is TaskCanceledException) || !cancellationToken.IsCancellationRequested)
            {
                ThrowIfSessionLockLost(ex, errorSource);
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        cancellationToken))
                    .ConfigureAwait(false);

                // if the user settled the message, or if the message or session lock was lost,
                // do not attempt to abandon the message
                ServiceBusFailureReason? failureReason = (ex as ServiceBusException)?.Reason;
                if (!message.IsSettled &&
                    _receiverOptions.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                    failureReason != ServiceBusFailureReason.SessionLockLost &&
                    failureReason != ServiceBusFailureReason.MessageLockLost)
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
                                Processor.FullyQualifiedNamespace,
                                Processor.EntityPath,
                                cancellationToken))
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
            await Processor.OnProcessMessageAsync(args).ConfigureAwait(false);
        }

        private async Task RenewMessageLock(
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(ProcessorOptions.MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockStart(Processor.Identifier, 1, message.LockToken);
                    TimeSpan delay = CalculateRenewDelay(message.LockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(
                            (t, s) => t,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Default)
                        .ConfigureAwait(false);
                    if (Receiver.IsClosed || delayTask.IsCanceled)
                    {
                        break;
                    }

                    await Receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockComplete(Processor.Identifier);
                }
                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockException(Processor.Identifier, ex.ToString());
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
            if (sbException?.Reason == ServiceBusFailureReason.SessionLockLost)
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
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        cancellationToken)).ConfigureAwait(false);
            }
        }

        protected async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await Processor.OnProcessErrorAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                ServiceBusEventSource.Log.ProcessorErrorHandlerThrewException(exception.ToString());
            }
        }

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
