// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    internal sealed class SessionReceivePump
    {
	    private readonly string _clientId;
	    private readonly ISessionClient _client;
	    private readonly Func<IMessageSession, Message, CancellationToken, Task> _userOnSessionCallback;
	    private readonly SessionHandlerOptions _sessionHandlerOptions;
	    private readonly string _endpoint;
	    private readonly string _entityPath;
	    private readonly CancellationToken _pumpCancellationToken;
	    private readonly SemaphoreSlim _maxConcurrentSessionsSemaphoreSlim;
	    private readonly SemaphoreSlim _maxPendingAcceptSessionsSemaphoreSlim;
        private readonly ServiceBusDiagnosticSource _diagnosticSource;

        public SessionReceivePump(string clientId,
            ISessionClient client,
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken token)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
            _clientId = clientId;
            ReceiveMode = receiveMode;
            _sessionHandlerOptions = sessionHandlerOptions;
            _userOnSessionCallback = callback;
            _endpoint = endpoint.Authority;
            _entityPath = client.EntityPath;
            _pumpCancellationToken = token;
            _maxConcurrentSessionsSemaphoreSlim = new SemaphoreSlim(_sessionHandlerOptions.MaxConcurrentSessions);
            _maxPendingAcceptSessionsSemaphoreSlim = new SemaphoreSlim(_sessionHandlerOptions.MaxConcurrentAcceptSessionCalls);
            _diagnosticSource = new ServiceBusDiagnosticSource(client.EntityPath, endpoint);
        }

        private ReceiveMode ReceiveMode { get; }

        public void StartPump()
        {
            // Schedule Tasks for doing PendingAcceptSession calls
            for (var i = 0; i < _sessionHandlerOptions.MaxConcurrentAcceptSessionCalls; i++)
            {
                TaskExtensionHelper.Schedule(SessionPumpTaskAsync);
            }
        }

        private static void CancelAutoRenewLock(object state)
        {
            var renewCancellationTokenSource = (CancellationTokenSource)state;

            try
            {
                renewCancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Ignore this race.
            }
        }

        private bool ShouldRenewSessionLock()
        {
            return
                ReceiveMode == ReceiveMode.PeekLock &&
                _sessionHandlerOptions.AutoRenewLock;
        }

        private Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, _endpoint, _entityPath, _clientId);
            return _sessionHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        private async Task CompleteMessageIfNeededAsync(IMessageSession session, Message message)
        {
            try
            {
                if (ReceiveMode == ReceiveMode.PeekLock &&
                    _sessionHandlerOptions.AutoComplete)
                {
                    await session.CompleteAsync(new[] { message.SystemProperties.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        private async Task AbandonMessageIfNeededAsync(IMessageSession session, Message message)
        {
            try
            {
                if (session.ReceiveMode == ReceiveMode.PeekLock)
                {
                    await session.AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        private async Task SessionPumpTaskAsync()
        {
            while (!_pumpCancellationToken.IsCancellationRequested)
            {
                var concurrentSessionSemaphoreAcquired = false;
                try
                {
                    await _maxConcurrentSessionsSemaphoreSlim.WaitAsync(_pumpCancellationToken).ConfigureAwait(false);
                    concurrentSessionSemaphoreAcquired = true;

                    await _maxPendingAcceptSessionsSemaphoreSlim.WaitAsync(_pumpCancellationToken).ConfigureAwait(false);
                    var session = await _client.AcceptMessageSessionAsync().ConfigureAwait(false);
                    if (session == null)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, _pumpCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    // `session` needs to be copied to another local variable before passing to Schedule
                    // because of the way variables are captured. (Refer 'Captured variables')
                    var messageSession = session;
                    TaskExtensionHelper.Schedule(() => MessagePumpTaskAsync(messageSession));
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionReceiveException(_clientId, exception);

                    if (concurrentSessionSemaphoreAcquired)
                    {
                        _maxConcurrentSessionsSemaphoreSlim.Release();
                    }

                    if (exception is ServiceBusTimeoutException)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, _pumpCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        if (!(exception is ObjectDisposedException && _pumpCancellationToken.IsCancellationRequested))
                        {
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.AcceptMessageSession).ConfigureAwait(false); 
                        }
                        if (!MessagingUtilities.ShouldRetry(exception))
                        {
                            await Task.Delay(Constants.NoMessageBackoffTimeSpan, _pumpCancellationToken).ConfigureAwait(false);
                        }
                    }
                }
                finally
                {
                    _maxPendingAcceptSessionsSemaphoreSlim.Release();
                }
            }
        }

        private async Task MessagePumpTaskAsync(IMessageSession session)
        {
            if (session == null)
            {
                return;
            }

            var renewLockCancellationTokenSource = new CancellationTokenSource();
            if (ShouldRenewSessionLock())
            {
                TaskExtensionHelper.Schedule(() => RenewSessionLockTaskAsync(session, renewLockCancellationTokenSource.Token));
            }

            var autoRenewLockCancellationTimer = new Timer(
                CancelAutoRenewLock,
                renewLockCancellationTokenSource,
                Timeout.Infinite,
                Timeout.Infinite);

            try
            {
                while (!_pumpCancellationToken.IsCancellationRequested && !session.IsClosedOrClosing)
                {
                    Message message;
                    try
                    {
                        message = await session.ReceiveAsync(_sessionHandlerOptions.MessageWaitTimeout).ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        MessagingEventSource.Log.MessageReceivePumpTaskException(_clientId, session.SessionId, exception);
                        if (exception is ServiceBusTimeoutException)
                        {
                            // Timeout Exceptions are pretty common. Not alerting the User on this.
                            continue;
                        }

                        if (!(exception is ObjectDisposedException && _pumpCancellationToken.IsCancellationRequested))
                        {
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false); 
                        }
                        break;
                    }

                    if (message == null)
                    {
                        MessagingEventSource.Log.SessionReceivePumpSessionEmpty(_clientId, session.SessionId);
                        break;
                    }

                    var isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
                    var activity = isDiagnosticSourceEnabled ? _diagnosticSource.ProcessSessionStart(session, message) : null;
                    Task processTask = null;

                    try
                    {
                        // Set the timer
                        autoRenewLockCancellationTimer.Change(_sessionHandlerOptions.MaxAutoRenewDuration,
                            TimeSpan.FromMilliseconds(-1));
                        var callbackExceptionOccurred = false;
                        try
                        {
                            processTask = _userOnSessionCallback(session, message, _pumpCancellationToken);
                            await processTask.ConfigureAwait(false);
                        }
                        catch (Exception exception)
                        {
                            if (isDiagnosticSourceEnabled)
                            {
                                _diagnosticSource.ReportException(exception);
                            }

                            MessagingEventSource.Log.MessageReceivePumpTaskException(_clientId, session.SessionId, exception);
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);
                            callbackExceptionOccurred = true;
                            if (!(exception is MessageLockLostException || exception is SessionLockLostException))
                            {
                                await AbandonMessageIfNeededAsync(session, message).ConfigureAwait(false);
                            }
                        }
                        finally
                        {
                            autoRenewLockCancellationTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        }

                        if (!callbackExceptionOccurred)
                        {
                            await CompleteMessageIfNeededAsync(session, message).ConfigureAwait(false);
                        }
                        else if (session.IsClosedOrClosing)
                        {
                            // If User closed the session as part of the callback, break out of the loop
                            break;
                        }
                    }
                    finally
                    {
                        _diagnosticSource.ProcessSessionStop(activity, session, message, processTask?.Status);
                    }
                }
            }
            finally
            {
                renewLockCancellationTokenSource.Cancel();
                renewLockCancellationTokenSource.Dispose();
                autoRenewLockCancellationTimer.Dispose();

                await CloseSessionIfNeededAsync(session).ConfigureAwait(false);
                _maxConcurrentSessionsSemaphoreSlim.Release();
            }
        }

        private async Task CloseSessionIfNeededAsync(IMessageSession session)
        {
            if (!session.IsClosedOrClosing)
            {
                try
                {
                    await session.CloseAsync().ConfigureAwait(false);
                    MessagingEventSource.Log.SessionReceivePumpSessionClosed(_clientId, session.SessionId);
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionCloseException(_clientId, session.SessionId, exception);
                    await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.CloseMessageSession).ConfigureAwait(false);
                }
            }
        }

        private async Task RenewSessionLockTaskAsync(IMessageSession session, CancellationToken renewLockCancellationToken)
        {
            while (!_pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(session.LockedUntilUtc);

                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStart(_clientId, session.SessionId, amount);
                    await Task.Delay(amount, renewLockCancellationToken).ConfigureAwait(false);

                    if (!_pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await session.RenewSessionLockAsync().ConfigureAwait(false);
                        MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStop(_clientId, session.SessionId);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockException(_clientId, session.SessionId, exception);

                    // TaskCanceled is expected here as renewTasks will be cancelled after the Complete call is made.
                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point 
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is TaskCanceledException) && !(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);
                    }
                    if (!MessagingUtilities.ShouldRetry(exception))
                    {
                        break;
                    }
                }
            }
        }
    }
}