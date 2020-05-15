// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents a thread-safe abstraction around a single session receiver that threads
    /// spawned by the ServiceBusProcessor use to receive and process messages. Depending on how the
    /// MaxConcurrentCalls and SessionIds options are configured, there may be multiple threads using the same
    /// SessionReceiverManager (i.e. if MaxConcurrentCalls is greater than the number of specified sessions).
    /// The manager will delegate to the user provided callbacks and handle automatic locking of sessions.
    /// The receiver instance will only be closed when no other threads are using it, or when the user has
    /// called StopProcessingAsync.
    /// </summary>
    internal class SessionReceiverManager : ReceiverManager
    {
        private int _threadCount = 0;
        private readonly string _sessionId;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionInitHandler;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionCloseHandler;
        private readonly Func<ProcessSessionMessageEventArgs, Task> _messageHandler;
        private readonly SemaphoreSlim _concurrentAcceptSessionsSemaphore;
        private ServiceBusSessionReceiver _receiver;
        protected override ServiceBusReceiver Receiver => _receiver;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public SessionReceiverManager(
            ServiceBusConnection connection,
            string fullyQualifiedNamespace,
            string entityPath,
            string identifier,
            string sessionId,
            ServiceBusProcessorOptions processorOptions,
            Func<ProcessSessionEventArgs, Task> sessionInitHandler,
            Func<ProcessSessionEventArgs, Task> sessionCloseHandler,
            Func<ProcessSessionMessageEventArgs, Task> messageHandler,
            Func<ProcessErrorEventArgs, Task> errorHandler,
            SemaphoreSlim concurrentAcceptSessionsSemaphore)
            : base(connection, fullyQualifiedNamespace, entityPath, identifier, processorOptions, default, errorHandler)
        {
            _sessionId = sessionId;
            _sessionInitHandler = sessionInitHandler;
            _sessionCloseHandler = sessionCloseHandler;
            _messageHandler = messageHandler;
            _concurrentAcceptSessionsSemaphore = concurrentAcceptSessionsSemaphore;
        }

        private async Task EnsureReceiverCreated(CancellationToken cancellationToken)
        {
            bool releaseSemaphore = false;
            try
            {
                await WaitSemaphore(cancellationToken).ConfigureAwait(false);
                releaseSemaphore = true;
                _threadCount++;
                if (_receiver != null)
                {
                    return;
                }
                await CreateAndInitializeSessionReceiver(cancellationToken).ConfigureAwait(false);
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
            CancellationToken cancellationToken)
        {
            _receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: _entityPath,
                connection: _connection,
                sessionId: _sessionId,
                options: _receiverOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            if (AutoRenewLock)
            {
                var sessionLockCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                Task _ = RenewSessionLock(sessionLockCancellationSource);
            }

            if (_sessionInitHandler != null)
            {
                var args = new ProcessSessionEventArgs(_receiver, cancellationToken);
                await _sessionInitHandler(args).ConfigureAwait(false);
            }
        }

        public override async Task CloseReceiverIfNeeded(
            CancellationToken cancellationToken,
            bool forceClose = false)
        {
            bool releaseSemaphore = false;
            try
            {
                await WaitSemaphore(cancellationToken).ConfigureAwait(false);
                releaseSemaphore = true;
                if (_receiver == null)
                {
                    return;
                }
                _threadCount--;
                if (_threadCount == 0 || forceClose)
                {
                    await CloseReceiver(cancellationToken).ConfigureAwait(false);
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
            if (_receiver == null || _receiver.IsDisposed)
            {
                return;
            }
            try
            {
                if (_sessionCloseHandler != null)
                {
                    var args = new ProcessSessionEventArgs(_receiver, cancellationToken);
                    await _sessionCloseHandler(args).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(
                        exception,
                        ServiceBusErrorSource.CloseMessageSession,
                        _fullyQualifiedNamespace,
                        _entityPath))
                    .ConfigureAwait(false);
            }
            finally
            {
                // Always at least attempt to dispose. If this fails, it won't be retried.
                await _receiver.DisposeAsync().ConfigureAwait(false);
                _receiver = null;
            }
        }

        public override async Task ReceiveAndProcessMessagesAsync(
            CancellationToken cancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            try
            {
                errorSource = ServiceBusErrorSource.AcceptMessageSession;
                bool releaseSemaphore = false;
                try
                {
                    try
                    {
                        await _concurrentAcceptSessionsSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                        // only attempt to release semaphore if WaitAsync is successful,
                        // otherwise SemaphoreFullException can occur.
                        releaseSemaphore = true;
                    }
                    catch (OperationCanceledException)
                    {
                        // propagate as TCE so it will be handled by the outer catch block
                        throw new TaskCanceledException();
                    }
                    try
                    {
                        await EnsureReceiverCreated(cancellationToken).ConfigureAwait(false);
                    }
                    catch (ServiceBusException ex)
                    when (ex.Reason == ServiceBusException.FailureReason.ServiceTimeout)
                    {
                        // these exceptions are expected when no messages are available
                        // so simply return and allow this to be tried again on next thread
                        return;
                    }
                }
                finally
                {
                    if (releaseSemaphore)
                    {
                        _concurrentAcceptSessionsSemaphore.Release();
                    }
                }

                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    ServiceBusReceivedMessage message = await _receiver.ReceiveAsync(
                        _maxReceiveWaitTime,
                        cancellationToken).ConfigureAwait(false);
                    if (message == null)
                    {
                        // Break out of the loop to allow a new session to
                        // be processed.
                        break;
                    }

                    await ProcessOneMessage(
                        message,
                        cancellationToken)
                        .ConfigureAwait(false);
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
            finally
            {
                await CloseReceiverIfNeeded(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task RenewSessionLock(CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(_processorOptions.MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockStart(_identifier, _receiver.SessionId);
                    TimeSpan delay = CalculateRenewDelay(_receiver.SessionLockedUntil);

                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                    if (_receiver.IsDisposed)
                    {
                        break;
                    }
                    await _receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(_identifier);
                }

                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(_identifier, ex);
                    await HandleRenewLockException(ex, cancellationToken).ConfigureAwait(false);

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
            CancellationToken processorCancellationToken)
        {
            var args = new ProcessSessionMessageEventArgs(
                message,
                _receiver,
                processorCancellationToken);
            await _messageHandler(args).ConfigureAwait(false);
        }
    }
}
