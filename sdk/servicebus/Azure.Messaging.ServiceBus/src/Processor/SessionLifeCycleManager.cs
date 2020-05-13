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
            bool releaseSemaphore = false;
            try
            {
                await WaitSemaphore(cancellationToken).ConfigureAwait(false);
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

        public async Task CloseSessionIfNeeded(CancellationToken cancellationToken, bool forceClose = false)
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

        private async Task CloseSession(CancellationToken cancellationToken)
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

                    try
                    {
                        await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                    if (receiver.IsDisposed)
                    {
                        break;
                    }
                    await receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(_identifier);
                }

                catch (Exception ex) when (!(ex is TaskCanceledException))
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(_identifier, ex);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(ex is ObjectDisposedException))
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
    }
}
