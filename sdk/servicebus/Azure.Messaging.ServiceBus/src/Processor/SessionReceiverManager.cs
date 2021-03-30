// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

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
        private readonly int _maxCallsPerSession;
        private readonly ServiceBusSessionReceiverOptions _sessionReceiverOptions;
        private readonly string _sessionId;
        private readonly bool _keepOpenOnReceiveTimeout;
        private ServiceBusSessionReceiver _receiver;
        private CancellationTokenSource _sessionLockRenewalCancellationSource;
        private Task _sessionLockRenewalTask;
        private CancellationTokenSource _sessionCancellationSource = new CancellationTokenSource();
        private bool _receiveTimeout;

        protected override ServiceBusReceiver Receiver => _receiver;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public SessionReceiverManager(
            ServiceBusProcessor processor,
            string sessionId,
            SemaphoreSlim concurrentAcceptSessionsSemaphore,
            EntityScopeFactory scopeFactory,
            IList<ServiceBusPlugin> plugins,
            int maxCallsPerSession,
            bool keepOpenOnReceiveTimeout)
            : base(processor, scopeFactory, plugins)
        {
            _concurrentAcceptSessionsSemaphore = concurrentAcceptSessionsSemaphore;
            _maxCallsPerSession = maxCallsPerSession;
            _sessionReceiverOptions = new ServiceBusSessionReceiverOptions
            {
                ReceiveMode = processor.Options.ReceiveMode,
                PrefetchCount = processor.Options.PrefetchCount,
            };
            _sessionId = sessionId;
            _keepOpenOnReceiveTimeout = keepOpenOnReceiveTimeout;
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
                if (_threadCount >= _maxCallsPerSession ||
                    (_receiveTimeout && !_keepOpenOnReceiveTimeout))
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

        private async Task CreateAndInitializeSessionReceiver(
            CancellationToken processorCancellationToken)
        {
            await CreateReceiver(processorCancellationToken).ConfigureAwait(false);
            _sessionCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(processorCancellationToken);

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
                    plugins: _plugins,
                    options: _sessionReceiverOptions,
                    sessionId: _sessionId,
                    cancellationToken: processorCancellationToken).ConfigureAwait(false);
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
            if (forceClose)
            {
                await CloseReceiver(processorCancellationToken).ConfigureAwait(false);
                return;
            }
            bool releaseSemaphore = false;
            try
            {
                // Intentionally not including processor cancellation token as
                // we need to ensure that we at least attempt to close the receiver if needed.
                await WaitSemaphore(CancellationToken.None).ConfigureAwait(false);
                releaseSemaphore = true;
                if (_receiver == null)
                {
                    return;
                }
                _threadCount--;
                if (_threadCount == 0 && !processorCancellationToken.IsCancellationRequested)
                {
                    if ((_receiveTimeout && !_keepOpenOnReceiveTimeout) ||
                        !AutoRenewLock ||
                        _sessionLockRenewalCancellationSource.IsCancellationRequested)
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
            if (_receiver == null || _receiver.IsClosed)
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

                // Always at least attempt to dispose. If this fails, it won't be retried.
                await _receiver.DisposeAsync().ConfigureAwait(false);
                _receiver = null;
                _receiveTimeout = false;
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
                // loop within the context of this thread
                while (!_sessionCancellationSource.Token.IsCancellationRequested)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    ServiceBusReceivedMessage message = await _receiver.ReceiveMessageAsync(
                        _maxReceiveWaitTime,
                        _sessionCancellationSource.Token).ConfigureAwait(false);
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
                        _sessionCancellationSource.Token).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            when (!(ex is TaskCanceledException) ||
            // If the user manually throws a TCE, then we should log it.
            (!_sessionCancellationSource.IsCancellationRequested &&
            // Even though the _sessionCancellationSource is linked to processorCancellationToken,
            // we need to check both here in case the processor token gets cancelled before the
            // session token is linked.
            !processorCancellationToken.IsCancellationRequested))
            {
                if (ex is ServiceBusException sbException && sbException.ProcessorErrorSource.HasValue)
                {
                    errorSource = sbException.ProcessorErrorSource.Value;

                    // Signal cancellation so user event handlers can stop whatever processing they are doing
                    // as soon as we know the session lock has been lost. Note, we don't have analogous handling
                    // for message locks in ReceiverManager, because there is only ever one thread processing a
                    // single message at one time, so cancelling the token there would serve no purpose.
                    if (sbException.Reason == ServiceBusFailureReason.SessionLockLost)
                    {
                        _sessionCancellationSource.Cancel();
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
                    await CloseReceiverIfNeeded(
                        processorCancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task RenewSessionLock()
        {
            _sessionLockRenewalCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(
                _sessionCancellationSource.Token);
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
                    if (Receiver.IsClosed || delayTask.IsCanceled)
                    {
                        break;
                    }
                    await _receiver.RenewSessionLockAsync(sessionLockRenewalCancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(Processor.Identifier);
                }

                catch (Exception ex) when (!(ex is TaskCanceledException))
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
                cancellationToken);
            await Processor.OnProcessSessionMessageAsync(args).ConfigureAwait(false);
        }
    }
}
