// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents a thread-safe abstraction around a single session receiver that tasks spawned
    /// by the <see cref="ServiceBusSessionProcessor"/> use to receive and process messages.
    /// If <see cref="ServiceBusSessionProcessor.MaxConcurrentCallsPerSession"/> > 1, there may be
    /// multiple tasks using the same <see cref="SessionReceiverManager"/>. The manager will delegate
    /// to the user provided callbacks and handle automatic locking of sessions.
    /// The receiver instance will only be closed when no other tasks are using it, or when the user
    /// has called <see cref="ServiceBusSessionProcessor.StopProcessingAsync"/>.
    /// </summary>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable.
    // Doesn't own _concurrentAcceptSessionsSemaphore
    internal class SessionReceiverManager : ReceiverManager
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private int _activeTaskCount;
        private readonly SemaphoreSlim _concurrentAcceptSessionsSemaphore;
        private readonly ServiceBusSessionReceiverOptions _sessionReceiverOptions;
        private readonly string _sessionId;
        private readonly bool _keepOpenOnReceiveTimeout;
        private ServiceBusSessionReceiver _receiver;
        private CancellationTokenSource _sessionLockRenewalCancellationSource;
        private Task _sessionLockRenewalTask;
        // This token source will be cancelled when the processor is shutting down or when we receive a lock lost exception during message settlement.
        private CancellationTokenSource _sessionCancellationSource;
        // This token source will be cancelled when we receive a lock lost exception or when the lock expiration time has passed.
        private CancellationTokenSource _sessionLockCancellationTokenSource;
        private volatile bool _receiveTimeout;

        internal override ServiceBusReceiver Receiver => _receiver;
        internal CancellationToken SessionLockCancellationToken => _sessionLockCancellationTokenSource.Token;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly ServiceBusSessionProcessor _sessionProcessor;
        internal Exception SessionLockLostException { get; private set; }

        public SessionReceiverManager(
            ServiceBusSessionProcessor sessionProcessor,
            string sessionId,
            SemaphoreSlim concurrentAcceptSessionsSemaphore,
            MessagingClientDiagnostics clientDiagnostics,
            bool keepOpenOnReceiveTimeout)
            : base(sessionProcessor.InnerProcessor, clientDiagnostics, true)
        {
            _concurrentAcceptSessionsSemaphore = concurrentAcceptSessionsSemaphore;
            _sessionReceiverOptions = new ServiceBusSessionReceiverOptions
            {
                ReceiveMode = sessionProcessor.InnerProcessor.Options.ReceiveMode,
                PrefetchCount = sessionProcessor.InnerProcessor.Options.PrefetchCount
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

                // If a receive call timed out for this session, avoid adding more tasks
                // if we don't intend to leave the receiver open on receive timeouts. This
                // will help ensure other sessions get a chance to be processed.
                if (_activeTaskCount >= _sessionProcessor.MaxConcurrentCallsPerSession ||
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
                _activeTaskCount++;
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
            SessionLockLostException = null;

            _sessionLockCancellationTokenSource?.Dispose();
            _sessionLockCancellationTokenSource = new CancellationTokenSource();
            _sessionLockCancellationTokenSource.CancelAfterLockExpired(_receiver);

            if (AutoRenewLock)
            {
                _sessionLockRenewalTask = RenewSessionLock();
            }

            if (Processor._sessionInitializingAsync != null)
            {
                var args = new ProcessSessionEventArgs(this, Processor.Identifier, processorCancellationToken);
                await Processor.OnSessionInitializingAsync(args).ConfigureAwait(false);
            }
        }

        private async Task CreateReceiver(CancellationToken processorCancellationToken)
        {
            bool releaseSemaphore = false;
            try
            {
                // Do a quick synchronous check before we resort to async/await with the state-machine overhead.
                if (!_concurrentAcceptSessionsSemaphore.Wait(0, CancellationToken.None))
                {
                    await _concurrentAcceptSessionsSemaphore.WaitAsync(processorCancellationToken).ConfigureAwait(false);
                }
                releaseSemaphore = true;

                _receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                    entityPath: Processor.EntityPath,
                    connection: Processor.Connection,
                    options: _sessionReceiverOptions,
                    sessionId: _sessionId,
                    cancellationToken: processorCancellationToken,
                    isProcessor: true).ConfigureAwait(false);
                _receiver.Identifier = $"{Processor.Identifier}-S{_receiver.SessionId}";
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

        public override async Task CloseReceiverIfNeeded(CancellationToken cancellationToken)
        {
            await CloseReceiverCore(forceClose: true, cancellationToken).ConfigureAwait(false);
        }

        private async Task CloseReceiverCore(bool forceClose, CancellationToken cancellationToken)
        {
            bool releaseSemaphore = false;
            try
            {
                // Intentionally not including cancellation token as
                // we need to ensure that we at least attempt to close the receiver if needed.
                await WaitSemaphore(CancellationToken.None).ConfigureAwait(false);
                releaseSemaphore = true;

                if (forceClose)
                {
                    await CloseReceiver(cancellationToken).ConfigureAwait(false);
                    return;
                }

                if (_receiver == null)
                {
                    return;
                }
                _activeTaskCount--;

                if (_activeTaskCount == 0)
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
                        await CloseReceiver(cancellationToken).ConfigureAwait(false);
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
                    var args = new ProcessSessionEventArgs(this, Processor.Identifier, cancellationToken);
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
                        Processor.Identifier,
                        cancellationToken))
                    .ConfigureAwait(false);
            }
            finally
            {
                // cancel the automatic session lock renewal
                try
                {
                    await CancelAsync().ConfigureAwait(false);
                    _sessionLockCancellationTokenSource?.Dispose();
                }
                catch (Exception ex) when (ex is TaskCanceledException)
                {
                    // Nothing to do here.  These exceptions are expected.
                }
                finally
                {
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
                    if (!canProcess || _sessionCancellationSource.IsCancellationRequested)
                    {
                        return;
                    }
                }
                catch (ServiceBusException ex)
                    when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                {
                    // these exceptions are expected when no messages are available
                    // so simply return and allow this to be tried again on next task
                    return;
                }

                using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(processorCancellationToken, _sessionCancellationSource.Token);
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
                        // this will be awaited when closing the receiver
                        _ = CancelAsync();
                    }
                }
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        ex,
                        errorSource,
                        Processor.FullyQualifiedNamespace,
                        Processor.EntityPath,
                        Processor.Identifier,
                        processorCancellationToken))
                    .ConfigureAwait(false);
            }
            finally
            {
                if (canProcess)
                {
                    await CloseReceiverCore(forceClose: false, processorCancellationToken).ConfigureAwait(false);
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
                            t => t,
                            CancellationToken.None,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Default)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }
                    await _receiver.RenewSessionLockAsync(sessionLockRenewalCancellationToken).ConfigureAwait(false);
                    _sessionLockCancellationTokenSource.CancelAfterLockExpired(_receiver);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(Processor.Identifier, _receiver.SessionId);
                }

                catch (Exception ex) when (ex is not TaskCanceledException)
                {
                    var serviceBusException = ex as ServiceBusException;
                    if (serviceBusException?.Reason == ServiceBusFailureReason.SessionLockLost)
                    {
                        SessionLockLostException = ex;
                        _sessionLockCancellationTokenSource.Cancel();
                    }

                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(Processor.Identifier, ex.ToString(), _receiver.SessionId);
                    await HandleRenewLockException(ex, sessionLockRenewalCancellationToken).ConfigureAwait(false);

                    // if the error was not transient, break out of the loop
                    if (!(ex as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        protected override EventArgs ConstructEventArgs(ServiceBusReceivedMessage message, CancellationToken cancellationToken) =>
            new ProcessSessionMessageEventArgs(
                message,
                this,
                Processor.Identifier,
                cancellationToken);

        protected override async Task OnMessageHandler(EventArgs args)
        {
            var sessionArgs = (ProcessSessionMessageEventArgs)args;
            using var registration = sessionArgs.RegisterSessionLockLostHandler();
            await _sessionProcessor.OnProcessSessionMessageAsync(sessionArgs).ConfigureAwait(false);
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
                ServiceBusEventSource.Log.ProcessorErrorHandlerThrewException(exception.ToString(), Processor.Identifier);
            }
        }

        public override async Task CancelAsync()
        {
            if (_sessionCancellationSource is { IsCancellationRequested: false })
            {
                _sessionCancellationSource.Cancel();
            }

            if (_sessionLockRenewalTask != null)
            {
                await _sessionLockRenewalTask.ConfigureAwait(false);
            }

            // We do not dispose _sessionLockCancellationSource here because it is exposed to users via the SessionLockLostAsync
            // event within the ProcessSessionMessageEventArgs. If we dispose it here, there is a race condition where the user
            // might get an ObjectDisposedException. Instead, we dispose it when shutting down, and when initializing a new instance
            // for a new session.

            _sessionCancellationSource?.Dispose();
            _sessionLockRenewalCancellationSource?.Dispose();
        }

        internal void RefreshSessionLockToken()
        {
            _sessionLockCancellationTokenSource.CancelAfterLockExpired(_receiver);
        }
    }
}
