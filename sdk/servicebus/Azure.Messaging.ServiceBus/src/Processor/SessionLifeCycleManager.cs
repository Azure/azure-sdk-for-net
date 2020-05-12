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

    internal class SessionLifeCycleManager
    {
        private int _threadCount = 0;
        private readonly string _sessionId;
        private readonly string _identifier;
        private readonly TimeSpan _maxAutoLockRenewal;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionInitHandler;
        private readonly Func<ProcessSessionEventArgs, Task> _sessionCloseHandler;
        private readonly Func<ProcessErrorEventArgs, Task> _errorHandler;
        private ServiceBusSessionReceiver _receiver;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly ServiceBusConnection _connection;
        private readonly string _fullyQualifiedNamespace;
        private readonly string _entityPath;

        public SessionLifeCycleManager(
            ServiceBusConnection connection,
            string fullyQualifiedNamespace,
            string entityPath,
            string identifier,
            TimeSpan maxAutoLockRenewal,
            Func<ProcessSessionEventArgs, Task> sessionInitHandler,
            Func<ProcessSessionEventArgs, Task> sessionCloseHandler,
            Func<ProcessErrorEventArgs, Task> errorHandler,
            string sessionId)
        {
            _connection = connection;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _entityPath = entityPath;
            _sessionId = sessionId;
            _identifier = identifier;
            _maxAutoLockRenewal = maxAutoLockRenewal;
            _sessionInitHandler = sessionInitHandler;
            _sessionCloseHandler = sessionCloseHandler;
            _errorHandler = errorHandler;
        }

        public async Task<ServiceBusReceiver> GetOrCreateSessionReceiver(
            ServiceBusReceiverOptions receiverOptions,
            CancellationToken cancellationToken)
        {
            if (_sessionId == null)
            {
                _receiver = await CreateAndInitializeSessionReceiver(
                    receiverOptions,
                    cancellationToken,
                    _sessionId)
                    .ConfigureAwait(false);
                return _receiver;
            }
            bool releaseSemaphore = false;
            try
            {
                await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                releaseSemaphore = true;
                _threadCount++;
                if (_receiver != null)
                {
                    return _receiver;
                }

                _receiver = await CreateAndInitializeSessionReceiver(
                    receiverOptions,
                    cancellationToken,
                    _sessionId).ConfigureAwait(false);

                return _receiver;
            }
            finally
            {
                if (releaseSemaphore)
                {
                    _semaphore.Release();
                }
            }
        }

        private async Task<ServiceBusSessionReceiver> CreateAndInitializeSessionReceiver(
            ServiceBusReceiverOptions receiverOptions,
            CancellationToken cancellationToken,
            string sessionId = default)
        {
            _receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: _entityPath,
                connection: _connection,
                sessionId: sessionId,
                options: receiverOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            if (_maxAutoLockRenewal > TimeSpan.Zero)
            {
                var sessionLockCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                Task _ = RenewSessionLock(
                    receiver: _receiver,
                    sessionLockCancellationSource);
            }

            if (_sessionInitHandler != null)
            {
                var args = new ProcessSessionEventArgs(_receiver, cancellationToken);
                await _sessionInitHandler(args).ConfigureAwait(false);
            }

            return _receiver;
        }

        public async Task CloseSessionIfNeeded(CancellationToken cancellationToken)
        {
            bool releaseSemaphore = false;
            if (_receiver == null)
            {
                return;
            }
            try
            {
                if (_sessionId != null)
                {
                    await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                    releaseSemaphore = true;
                    _threadCount--;
                    if (_threadCount == 0)
                    {
                        await CloseSession(cancellationToken).ConfigureAwait(false);
                    }
                }
                else
                {
                    await CloseSession(cancellationToken).ConfigureAwait(false);
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

        public async Task CloseSession(CancellationToken cancellationToken)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task RenewSessionLock(
            ServiceBusSessionReceiver receiver,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(_maxAutoLockRenewal);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockStart(_identifier, receiver.SessionId);
                    TimeSpan delay = ProcessorUtils.CalculateRenewDelay(receiver.SessionLockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled || receiver.IsDisposed)
                    {
                        break;
                    }
                    await receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(_identifier);
                }

                catch (Exception exception)
                {
                    // if the renewLock token was cancelled, throw a TaskCanceledException as we don't want
                    // to propagate to user error handler. This will be handled by the caller.
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(_identifier, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await ProcessorUtils.RaiseExceptionReceived(
                            _errorHandler,
                            new ProcessErrorEventArgs(
                                exception,
                                ServiceBusErrorSource.RenewLock,
                                _fullyQualifiedNamespace,
                                _entityPath)).ConfigureAwait(false);
                    }

                    // if the error was not transient, break out of the loop
                    if (!(exception as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }
    }
}
