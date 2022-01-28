// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents a thread-safe abstraction around a single session receiver that threads spawned
    /// by the <see cref="ServiceBusSessionProcessor"/> use to receive and process messages.
    /// If <see cref="ServiceBusSessionProcessor.MaxConcurrentCallsPerSession"/> > 1, there may be
    /// multiple threads using the same <see cref="SessionReceiverManager"/>. The manager will delegate
    /// to the user provided callbacks and handle automatic locking of sessions.
    /// The receiver instance will only be closed when no other threads are using it, or when the user
    /// has called <see cref="ServiceBusSessionProcessor.StopProcessingAsync"/>.
    /// </summary>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable.
    // Doesn't own _concurrentAcceptSessionsSemaphore
    internal class SessionReceiverManager : ReceiverManager
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private int _threadCount;
        private readonly SemaphoreSlim _concurrentAcceptSessionsSemaphore;
        private readonly ServiceBusSessionReceiverOptions _sessionReceiverOptions;
        private readonly string _sessionId;
        private readonly bool _keepOpenOnReceiveTimeout;
        private ServiceBusSessionReceiver _receiver;
        private CancellationTokenSource _sessionLockRenewalCancellationSource;
        private Task _sessionLockRenewalTask;
        private CancellationTokenSource _sessionCancellationSource;
        private volatile bool _receiveTimeout;

        protected override ServiceBusReceiver Receiver => _receiver;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly ServiceBusSessionProcessor _sessionProcessor;

        public SessionReceiverManager(
            ServiceBusSessionProcessor sessionProcessor,
            string sessionId,
            SemaphoreSlim concurrentAcceptSessionsSemaphore,
            EntityScopeFactory scopeFactory,
            bool keepOpenOnReceiveTimeout)
            : base(sessionProcessor.InnerProcessor, scopeFactory)
        {
            _concurrentAcceptSessionsSemaphore = concurrentAcceptSessionsSemaphore;
            _sessionReceiverOptions = new ServiceBusSessionReceiverOptions
            {
                ReceiveMode = sessionProcessor.InnerProcessor.Options.ReceiveMode,
                PrefetchCount = sessionProcessor.InnerProcessor.Options.PrefetchCount,
            };
            _sessionId = sessionId;
            _keepOpenOnReceiveTimeout = keepOpenOnReceiveTimeout;
            _sessionProcessor = sessionProcessor;
        }

        private async Task<bool> EnsureCanProcess(CancellationToken cancellationToken)
        {
            bool releaseSemaphore = false;
            try
            {
                await WaitSemaphore(cancellationToken).ConfigureAwait(false);
                releaseSemaphore = true;

                // If a receive call timed out for this session, avoid adding more threads
                // if we don't intend to leave the receiver open on receive timeouts. This
                // will help ensure other sessions get a chance to be processed.
                if (_threadCount >= _sessionProcessor.MaxConcurrentCallsPerSession ||
                    (_receiveTimeout && !_keepOpenOnReceiveTimeout) ||
                    // If cancellation was requested but the receiver has not been closed yet,
                    // do not initiate new processing.
                    (_receiver != null && _sessionCancellationSource.IsCancellationRequested))
                {
                    return false;
                }

                if (_receiver == null)
                {
                    await CreateAndInitializeSessionReceiver(cancellationToken).ConfigureAwait(false);
                }
                _threadCount++;
                return true;
            }
            finally
            {
                if (releaseSemaphore)
                {
                    _semaphore.Release();
                }
            }
        }

        private async Task WaitSemaphore(CancellationToken cancellationToken)
        {
            try
            {
                await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // propagate as TCE so can be handled by
                // caller
                throw new TaskCanceledException();
            }
        }

        private async Task CreateAndInitializeSessionReceiver(CancellationToken processorCancellationToken)
        {
            await CreateReceiver(processorCancellationToken).ConfigureAwait(false);
            _sessionCancellationSource = new CancellationTokenSource();

            if (AutoRenewLock)
            {
                _sessionLockRenewalTask = RenewSessionLock();
            }

            if (Processor._sessionInitializingAsync != null)
            {
                var args = new ProcessSessionEventArgs(_receiver, processorCancellationToken);
                await Processor.OnSessionInitializingAsync(args).ConfigureAwait(false);
            }
        }

        private async Task CreateReceiver(CancellationToken processorCancellationToken)
        {
            bool releaseSemaphore = false;
            try
            {
                await _concurrentAcceptSessionsSemaphore.WaitAsync(processorCancellationToken).ConfigureAwait(false);
                // only attempt to release semaphore if WaitAsync is successful,
                // otherwise SemaphoreFullException can occur.
                releaseSemaphore = true;
                _receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                    entityPath: Processor.EntityPath,
                    connection: Processor.Connection,
                    options: _sessionReceiverOptions,
                    sessionId: _sessionId,
                    cancellationToken: processorCancellationToken,
                    isProcessor: true).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // propagate as TCE so it will be handled by the outer catch block
                throw new TaskCanceledException();
            }
            finally
            {
                if (releaseSemaphore)
                {
                    _concurrentAcceptSessionsSemaphore.Release();
                }
            }
        }

        public override async Task CloseReceiverIfNeeded(
            CancellationToken processorCancellationToken,
            bool forceClose = false)
        {
            bool releaseSemaphore = false;
            try
            {
                // Intentionally not including processor cancellation token as
                // we need to ensure that we at least attempt to close the receiver if needed.
                await WaitSemaphore(CancellationToken.None).ConfigureAwait(false);
                releaseSemaphore = true;

                if (forceClose)
                {
                    await CloseReceiver(processorCancellationToken).ConfigureAwait(false);
                    return;
                }

                if (_receiver == null)
                {
                    return;
                }
                _threadCount--;

                if (_threadCount == 0)
                {
                    // Even if there are no current receive tasks, we should leave the
                    // receiver open if _keepOpenOnReceiveTimeout is true - which happens
                    // when a list of session Ids is specified and this list is less than the
                    // MaxConcurrentSessions.
                    if ((_receiveTimeout && !_keepOpenOnReceiveTimeout) ||
                        // if the session is cancelled we should still close the receiver
                        // as this means the session lock was lost or the user requested to close the session.
                        _sessionCancellationSource.IsCancellationRequested)
                    {
                        await CloseReceiver(processorCancellationToken).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                if (releaseSemaphore)
                {
                    _semaphore.Release();
                }
            }
        }

        private async Task CloseReceiver(CancellationToken cancellationToken)
        {
            if (_receiver == null)
            {
                return;
            }

            try
            {
                if (Processor._sessionClosingAsync != null)
                {
                    var args = new ProcessSessionEventArgs(_receiver, cancellationToken);
                    await Processor.OnSessionClosingAsync(args).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        exception,
                        ServiceBusErrorSource.CloseSession,
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        cancellationToken))
                    .ConfigureAwait(false);
            }
            finally
            {
                // cancel the automatic session lock renewal
                await CancelTask(_sessionLockRenewalCancellationSource, _sessionLockRenewalTask).ConfigureAwait(false);

                try
                {
                    // Always at least attempt to dispose. If this fails, it won't be retried.
                    await _receiver.DisposeAsync().ConfigureAwait(false);
                }
                finally
                {
                    // If we call DisposeAsync, we need to reset to null even if DisposeAsync throws, otherwise we can
                    // end up in a bad state.
                    _receiver = null;
                    _receiveTimeout = false;
                }
            }
        }

        public override async Task ReceiveAndProcessMessagesAsync(CancellationToken processorCancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.AcceptSession;
            bool canProcess = false;
            try
            {
                try
                {
                    canProcess = await EnsureCanProcess(processorCancellationToken).ConfigureAwait(false);
                    if (!canProcess)
                    {
                        return;
                    }
                }
                catch (ServiceBusException ex)
                when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                {
                    // these exceptions are expected when no messages are available
                    // so simply return and allow this to be tried again on next thread
                    return;
                }

                using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(processorCancellationToken, _sessionCancellationSource.Token);
                // loop within the context of this thread
                while (!linkedTokenSource.Token.IsCancellationRequested)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    IReadOnlyList<ServiceBusReceivedMessage> messages = await Receiver.ReceiveMessagesAsync(
                        maxMessages: 1,
                        maxWaitTime: _maxReceiveWaitTime,
                        isProcessor: true,
                        cancellationToken: linkedTokenSource.Token).ConfigureAwait(false);
                    ServiceBusReceivedMessage message = messages.Count == 0 ? null : messages[0];
                    if (message == null)
                    {
                        // Break out of the loop to allow a new session to
                        // be processed.
                        _receiveTimeout = true;
                        break;
                    }
                    await ProcessOneMessageWithinScopeAsync(
                        message,
                        DiagnosticProperty.ProcessSessionMessageActivityName,
                        linkedTokenSource.Token).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            when (ex is not TaskCanceledException)
            {
                if (ex is ServiceBusException sbException)
                {
                    if (sbException.ProcessorErrorSource.HasValue)
                    {
                        errorSource = sbException.ProcessorErrorSource.Value;
                    }

                    // Signal cancellation so user event handlers can stop whatever processing they are doing
                    // as soon as we know the session lock has been lost. Note, we don't have analogous handling
                    // for message locks in ReceiverManager, because there is only ever one thread processing a
                    // single message at one time, so cancelling the token there would serve no purpose.
                    if (sbException.Reason == ServiceBusFailureReason.SessionLockLost)
                    {
                        CancelSession();
                    }
                }
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        processorCancellationToken))
                    .ConfigureAwait(false);
            }
            finally
            {
                if (canProcess)
                {
                    await CloseReceiverIfNeeded(processorCancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task RenewSessionLock()
        {
            _sessionLockRenewalCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(_sessionCancellationSource.Token);
            _sessionLockRenewalCancellationSource.CancelAfter(ProcessorOptions.MaxAutoLockRenewalDuration);
            CancellationToken sessionLockRenewalCancellationToken = _sessionLockRenewalCancellationSource.Token;

            while (!sessionLockRenewalCancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockStart(Processor.Identifier, _receiver.SessionId);
                    TimeSpan delay = CalculateRenewDelay(_receiver.SessionLockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, sessionLockRenewalCancellationToken)
                        .ContinueWith(
                            (t, s) => t,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Default)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }
                    await _receiver.RenewSessionLockAsync(sessionLockRenewalCancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(Processor.Identifier);
                }

                catch (Exception ex) when (ex is not TaskCanceledException)
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(Processor.Identifier, ex.ToString());
                    await HandleRenewLockException(ex, sessionLockRenewalCancellationToken).ConfigureAwait(false);

                    // if the error was not transient, break out of the loop
                    if (!(ex as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        protected override async Task OnMessageHandler(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken)
        {
            var args = new ProcessSessionMessageEventArgs(
                message,
                _receiver,
                this,
                cancellationToken);
            await _sessionProcessor.OnProcessSessionMessageAsync(args).ConfigureAwait(false);
        }

        protected override async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await _sessionProcessor.OnProcessErrorAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                ServiceBusEventSource.Log.ProcessorErrorHandlerThrewException(exception.ToString());
            }
        }

        internal void CancelSession()
        {
            _sessionCancellationSource?.Cancel();
            _sessionCancellationSource?.Dispose();
        }
    }
}
