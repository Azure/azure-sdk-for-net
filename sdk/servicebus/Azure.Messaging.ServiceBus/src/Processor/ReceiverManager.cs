﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
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
        internal virtual ServiceBusReceiver Receiver { get; set; }

        protected readonly ServiceBusProcessor Processor;
        protected readonly TimeSpan? _maxReceiveWaitTime;
        private readonly ServiceBusReceiverOptions _receiverOptions;
        protected readonly ServiceBusProcessorOptions ProcessorOptions;
        protected readonly EntityScopeFactory _scopeFactory;

        protected bool AutoRenewLock => ProcessorOptions.MaxAutoLockRenewalDuration > TimeSpan.Zero;

        public ReceiverManager(
            ServiceBusProcessor processor,
            EntityScopeFactory scopeFactory)
        {
            Processor = processor;
            ProcessorOptions = processor.Options;
            _receiverOptions = new ServiceBusReceiverOptions
            {
                ReceiveMode = ProcessorOptions.ReceiveMode,
                PrefetchCount = ProcessorOptions.PrefetchCount,
                // Pass None for subqueue since the subqueue has already
                // been taken into account when computing the EntityPath of the processor.
                SubQueue = SubQueue.None
            };
            _maxReceiveWaitTime = ProcessorOptions.MaxReceiveWaitTime;
            Receiver = new ServiceBusReceiver(
                connection: Processor.Connection,
                entityPath: Processor.EntityPath,
                isSessionEntity: false,
                isProcessor: true,
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
                        cancellationToken))
                    .ConfigureAwait(false);
            }
        }

        protected async Task ProcessOneMessageWithinScopeAsync(ServiceBusReceivedMessage message, string activityName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _scopeFactory.CreateScope(activityName, DiagnosticScope.ActivityKind.Consumer);
            scope.SetMessageData(message);
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
            EventArgs args = null;

            try
            {
                errorSource = ServiceBusErrorSource.ProcessMessageCallback;
                try
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerStart(Processor.Identifier, triggerMessage.SequenceNumber,
                        triggerMessage.LockTokenGuid);
                    args = await OnMessageHandler(triggerMessage, cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorMessageHandlerComplete(Processor.Identifier, triggerMessage.SequenceNumber,
                        triggerMessage.LockTokenGuid);
                }
                catch (Exception ex)
                {
                    ServiceBusEventSource.Log.ProcessorMessageHandlerException(Processor.Identifier, triggerMessage.SequenceNumber,
                        ex.ToString(), triggerMessage.LockTokenGuid);
                    throw;
                }

                if (Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock && ProcessorOptions.AutoCompleteMessages)
                {
                    var messages = (args is ProcessMessageEventArgs processMessageEventArgs)
                        ? processMessageEventArgs.Messages.Keys
                        : ((ProcessSessionMessageEventArgs)args).Messages.Keys;
                    foreach (ServiceBusReceivedMessage message in messages)
                    {
                        if (!message.IsSettled)
                        {
                            errorSource = ServiceBusErrorSource.Complete;
                            // don't pass the processor cancellation token
                            // as we want in flight auto-completion to be able
                            // to finish
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
                            cancellationToken))
                    .ConfigureAwait(false);

                // if the user settled the message, or if the message or session lock was lost,
                // do not attempt to abandon the message
                ServiceBusFailureReason? failureReason = (ex as ServiceBusException)?.Reason;
                if (!triggerMessage.IsSettled &&
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
                                triggerMessage.LockTokenGuid,
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
                if (args is ProcessMessageEventArgs processMessageEventArgs)
                {
                    await processMessageEventArgs.CancelMessageLockRenewalAsync().ConfigureAwait(false);
                }
            }
        }

        internal bool ShouldAutoRenewMessageLock()
        {
            return !Receiver.IsSessionReceiver &&
                   Receiver.ReceiveMode == ServiceBusReceiveMode.PeekLock &&
                   AutoRenewLock;
        }

        protected virtual async Task<EventArgs> OnMessageHandler(
            ServiceBusReceivedMessage message,
            CancellationToken processorCancellationToken)
        {
            var args = new ProcessMessageEventArgs(
                message,
                this,
                processorCancellationToken);
            await Processor.OnProcessMessageAsync(args).ConfigureAwait(false);
            return args;
        }

        internal async Task RenewMessageLockAsync(
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(ProcessorOptions.MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
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
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockComplete(Processor.Identifier);
                }
                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockException(Processor.Identifier, ex.ToString());

                    // If the message has already been settled there is no need to raise the lock lost exception to user error handler.
                    if (!message.IsSettled)
                    {
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
