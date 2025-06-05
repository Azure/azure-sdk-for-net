// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Diagnostics;

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
        internal virtual ServiceBusReceiver Receiver { get; private set; }

        protected readonly ServiceBusProcessor Processor;
        protected readonly TimeSpan? _maxReceiveWaitTime;
        private readonly ServiceBusReceiverOptions _receiverOptions;
        protected readonly ServiceBusProcessorOptions ProcessorOptions;
        private readonly MessagingClientDiagnostics _clientDiagnostics;

        protected bool AutoRenewLock => ProcessorOptions.MaxAutoLockRenewalDuration > TimeSpan.Zero ||
                                        ProcessorOptions.MaxAutoLockRenewalDuration == Timeout.InfiniteTimeSpan;

        public ReceiverManager(
            ServiceBusProcessor processor,
            MessagingClientDiagnostics clientDiagnostics,
            bool isSession)
        {
            Processor = processor;
            ProcessorOptions = processor.Options;
            _receiverOptions = new ServiceBusReceiverOptions
            {
                ReceiveMode = ProcessorOptions.ReceiveMode,
                PrefetchCount = ProcessorOptions.PrefetchCount,
                // Pass None for subqueue since the subqueue has already
                // been taken into account when computing the EntityPath of the processor.
                SubQueue = SubQueue.None,
                Identifier = $"{processor.Identifier}-Receiver"
            };
            _maxReceiveWaitTime = ProcessorOptions.MaxReceiveWaitTime;
            if (!isSession)
            {
                Receiver = new ServiceBusReceiver(
                    connection: Processor.Connection,
                    entityPath: Processor.EntityPath,
                    isSessionEntity: false,
                    isProcessor: true,
                    options: _receiverOptions);
            }

            _clientDiagnostics = clientDiagnostics;
        }

        public virtual async Task CloseReceiverIfNeeded(CancellationToken cancellationToken)
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
                while (!cancellationToken.IsCancellationRequested && !Processor.Connection.IsClosed)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    IReadOnlyList<ServiceBusReceivedMessage> messages = await Receiver.ReceiveMessagesAsync(
                        maxMessages: 1,
                        maxWaitTime: _maxReceiveWaitTime,
                        isProcessor: true,
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                    ServiceBusReceivedMessage message = messages.Count == 0 ? null : messages[0];
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
                        Processor.Identifier,
                        cancellationToken))
                    .ConfigureAwait(false);
            }
        }

        public virtual Task CancelAsync() => Task.CompletedTask;

        public virtual void UpdatePrefetchCount(int prefetchCount)
        {
            var capturedReceiver = Receiver;

            // If the Receiver property is set to null after we have captured a non-null instance, the Prefetch setter will essentially
            // no-op as the underlying link has been closed.
            if (capturedReceiver != null && capturedReceiver.PrefetchCount != prefetchCount)
            {
                capturedReceiver.PrefetchCount = prefetchCount;
            }
        }

        protected async Task ProcessOneMessageWithinScopeAsync(ServiceBusReceivedMessage message, string activityName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(activityName, ActivityKind.Consumer, MessagingDiagnosticOperation.Process);
            scope.SetMessageAsParent(message);
            scope.Start();

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
            ServiceBusReceivedMessage triggerMessage,
            CancellationToken cancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            EventArgs args = ConstructEventArgs(triggerMessage, cancellationToken);

            try
            {
                errorSource = ServiceBusErrorSource.ProcessMessageCallback;
                try
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerStart(Processor.Identifier, triggerMessage.SequenceNumber, triggerMessage.LockTokenGuid);
                    await OnMessageHandler(args).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorMessageHandlerComplete(Processor.Identifier, triggerMessage.SequenceNumber, triggerMessage.LockTokenGuid);
                }
                catch (Exception ex)
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerException(Processor.Identifier, triggerMessage.SequenceNumber, ex.ToString(), triggerMessage.LockTokenGuid);
                    throw;
                }

                if (Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock && ProcessorOptions.AutoCompleteMessages)
                {
                    foreach (ServiceBusReceivedMessage message in GetProcessedMessages(args))
                    {
                        if (!message.IsSettled)
                        {
                            errorSource = ServiceBusErrorSource.Complete;
                            // Don't pass the processor cancellation token as we want in flight auto-completion to be able
                            // to finish.
                            await Receiver.CompleteMessageAsync(
                                    message,
                                    CancellationToken.None)
                                .ConfigureAwait(false);
                            message.IsSettled = true;
                        }
                    }
                }
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
                            Processor.Identifier,
                            cancellationToken))
                    .ConfigureAwait(false);

                // If we got a message or session lock lost error, do not attempt to abandon the message, or any of the additional received
                // messages in the handler, as we have no way of knowing which message caused the error.
                ServiceBusFailureReason? failureReason = (ex as ServiceBusException)?.Reason;
                if (_receiverOptions.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                    failureReason != ServiceBusFailureReason.SessionLockLost &&
                    failureReason != ServiceBusFailureReason.MessageLockLost)
                {
                    foreach (ServiceBusReceivedMessage message in GetProcessedMessages(args))
                    {
                        // If the user already settled the message, do not abandon.
                        if (message.IsSettled)
                        {
                            continue;
                        }
                        try
                        {
                            // Don't pass the processor cancellation token as we want in flight abandon to be able
                            // to finish even if user stopped processing.
                            await Receiver.AbandonMessageAsync(message, cancellationToken: CancellationToken.None).ConfigureAwait(false);
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
                                        Processor.Identifier,
                                        cancellationToken))
                                .ConfigureAwait(false);
                        }
                    }
                }
            }
            finally
            {
                if (args is ProcessMessageEventArgs processMessageEventArgs)
                {
                    await processMessageEventArgs.CancelMessageLockRenewalAsync().ConfigureAwait(false);
                }
            }
        }

        private static ICollection<ServiceBusReceivedMessage> GetProcessedMessages(EventArgs args) =>
            args is ProcessMessageEventArgs processMessageEventArgs ? processMessageEventArgs.Messages.Keys
                : ((ProcessSessionMessageEventArgs)args).Messages.Keys;

        internal bool ShouldAutoRenewMessageLock()
        {
            return !Receiver.IsSessionReceiver &&
                   Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                   AutoRenewLock;
        }

        protected virtual EventArgs ConstructEventArgs(ServiceBusReceivedMessage message, CancellationToken cancellationToken) =>
            new ProcessMessageEventArgs(
            message,
            this,
            Processor.Identifier,
            cancellationToken);

        protected virtual async Task OnMessageHandler(EventArgs args)
        {
            var processMessageArgs = (ProcessMessageEventArgs)args;
            using var registration = processMessageArgs.RegisterMessageLockLostHandler();
            await Processor.OnProcessMessageAsync((ProcessMessageEventArgs)args).ConfigureAwait(false);
        }

        internal async Task RenewMessageLockAsync(
            ProcessMessageEventArgs args,
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(ProcessorOptions.MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            bool isTriggerMessage = args.Message == message;

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockStart(Processor.Identifier, 1, message.LockTokenGuid);
                    TimeSpan delay = CalculateRenewDelay(message.LockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(
                            t => t,
                            CancellationToken.None,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Default)
                        .ConfigureAwait(false);
                    if (Receiver.IsClosed || delayTask.IsCanceled || message.IsSettled)
                    {
                        break;
                    }

                    await Receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);

                    // Currently only the trigger message supports cancellation token for LockedUntil.
                    if (isTriggerMessage)
                    {
                        args.MessageLockLostCancellationSource.CancelAfterLockExpired(message);
                    }

                    ServiceBusEventSource.Log.ProcessorRenewMessageLockComplete(Processor.Identifier, message.LockTokenGuid);
                }
                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockException(Processor.Identifier, ex.ToString(), message.LockTokenGuid);

                    // If the message has already been settled there is no need to raise the lock lost exception to user error handler.
                    if (!message.IsSettled)
                    {
                        // Currently only the trigger message supports cancellation token for LockedUntil.
                        if (isTriggerMessage)
                        {
                            args.LockLostException = ex;
                            args.MessageLockLostCancellationSource?.Cancel();
                        }

                        await HandleRenewLockException(ex, cancellationToken).ConfigureAwait(false);
                    }

                    // if the error was not transient, break out of the loop
                    if (!(ex as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
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
                        Processor.Identifier,
                        cancellationToken)).ConfigureAwait(false);
            }
        }

        protected virtual async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await Processor.OnProcessErrorAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                ServiceBusEventSource.Log.ProcessorErrorHandlerThrewException(exception.ToString(), Processor.Identifier);
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
