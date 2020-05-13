// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Core;
using System.IO;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus
{

    internal class SessionReceiverLifeCycleManager : ReceiverLifeCycleManager
    {
        private int _threadCount = 0;
        private readonly string _sessionId;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionInitHandler;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionCloseHandler;
        private Func<ProcessSessionMessageEventArgs, Task> _messageHandler;
        private readonly Func<ProcessErrorEventArgs, Task> _errorHandler;
        private readonly SemaphoreSlim _concurrentAcceptSessionsSemaphore;
        private ServiceBusSessionReceiver _receiver;
        protected override ServiceBusReceiver Receiver => _receiver;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public SessionReceiverLifeCycleManager(
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
            SemaphoreSlim concurrentCallsSemaphore,
            SemaphoreSlim concurrentAcceptSessionsSemaphore)
            : base(connection, fullyQualifiedNamespace, entityPath, identifier, processorOptions, default, errorHandler, concurrentCallsSemaphore)
        {
            _sessionId = sessionId;
            _sessionInitHandler = sessionInitHandler;
            _sessionCloseHandler = sessionCloseHandler;
            _messageHandler = messageHandler;
            _errorHandler = errorHandler;
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
                _receiver = await CreateAndInitializeSessionReceiver(cancellationToken).ConfigureAwait(false);
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

        private async Task<ServiceBusSessionReceiver> CreateAndInitializeSessionReceiver(
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

            return _receiver;
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
                await ProcessorUtils.RaiseExceptionReceived(
                    _errorHandler,
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
                await ProcessorUtils.RaiseExceptionReceived(
                    _errorHandler,
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
                _concurrentCallsSemaphore.Release();
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
                    TimeSpan delay = ProcessorUtils.CalculateRenewDelay(_receiver.SessionLockedUntil);

                    try
                    {
                        await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
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

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(ex is ObjectDisposedException) && !cancellationToken.IsCancellationRequested)
                    {
                        await ProcessorUtils.RaiseExceptionReceived(
                            _errorHandler,
                            new ProcessErrorEventArgs(
                                ex,
                                ServiceBusErrorSource.RenewLock,
                                _fullyQualifiedNamespace,
                                _entityPath)).ConfigureAwait(false);
                    }

                    // if the error was not transient, break out of the loop
                    if (!(ex as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        public override async Task OnMessageHandler(ServiceBusReceivedMessage message, CancellationToken processorCancellationToken)
        {
            var args = new ProcessSessionMessageEventArgs(
                message,
                _receiver,
                processorCancellationToken);
            await _messageHandler(args).ConfigureAwait(false);
        }
    }
}
