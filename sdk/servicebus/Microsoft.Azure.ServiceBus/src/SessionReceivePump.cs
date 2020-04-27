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
	    private readonly string clientId;
	    private readonly ISessionClient client;
	    private readonly Func<IMessageSession, Message, CancellationToken, Task> userOnSessionCallback;
	    private readonly SessionHandlerOptions sessionHandlerOptions;
	    private readonly string endpoint;
	    private readonly string entityPath;
	    private readonly CancellationToken pumpCancellationToken;
	    private readonly SemaphoreSlim maxConcurrentSessionsSemaphoreSlim;
	    private readonly SemaphoreSlim maxPendingAcceptSessionsSemaphoreSlim;
        private readonly ServiceBusDiagnosticSource diagnosticSource;

        public SessionReceivePump(string clientId,
            ISessionClient client,
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken token)
        {
            this.client = client ?? throw new ArgumentException(nameof(client));
            this.clientId = clientId;
            ReceiveMode = receiveMode;
            this.sessionHandlerOptions = sessionHandlerOptions;
            userOnSessionCallback = callback;
            this.endpoint = endpoint.Authority;
            entityPath = client.EntityPath;
            pumpCancellationToken = token;
            maxConcurrentSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentSessions);
            maxPendingAcceptSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls);
            diagnosticSource = new ServiceBusDiagnosticSource(client.EntityPath, endpoint);
        }

        private ReceiveMode ReceiveMode { get; }

        public void StartPump()
        {
            // Schedule Tasks for doing PendingAcceptSession calls
            for (var i = 0; i < sessionHandlerOptions.MaxConcurrentAcceptSessionCalls; i++)
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
                sessionHandlerOptions.AutoRenewLock;
        }

        private Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, endpoint, entityPath, clientId);
            return sessionHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        private async Task CompleteMessageIfNeededAsync(IMessageSession session, Message message)
        {
            try
            {
                if (ReceiveMode == ReceiveMode.PeekLock &&
                    sessionHandlerOptions.AutoComplete)
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
            while (!pumpCancellationToken.IsCancellationRequested)
            {
                var concurrentSessionSemaphoreAcquired = false;
                try
                {
                    await maxConcurrentSessionsSemaphoreSlim.WaitAsync(pumpCancellationToken).ConfigureAwait(false);
                    concurrentSessionSemaphoreAcquired = true;

                    await maxPendingAcceptSessionsSemaphoreSlim.WaitAsync(pumpCancellationToken).ConfigureAwait(false);
                    var session = await client.AcceptMessageSessionAsync().ConfigureAwait(false);
                    if (session == null)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, pumpCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    // `session` needs to be copied to another local variable before passing to Schedule
                    // because of the way variables are captured. (Refer 'Captured variables')
                    var messageSession = session;
                    TaskExtensionHelper.Schedule(() => MessagePumpTaskAsync(messageSession));
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionReceiveException(clientId, exception);

                    if (concurrentSessionSemaphoreAcquired)
                    {
                        maxConcurrentSessionsSemaphoreSlim.Release();
                    }

                    if (exception is ServiceBusTimeoutException)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, pumpCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        if (!(exception is ObjectDisposedException && pumpCancellationToken.IsCancellationRequested))
                        {
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.AcceptMessageSession).ConfigureAwait(false); 
                        }
                        if (!MessagingUtilities.ShouldRetry(exception))
                        {
                            await Task.Delay(Constants.NoMessageBackoffTimeSpan, pumpCancellationToken).ConfigureAwait(false);
                        }
                    }
                }
                finally
                {
                    maxPendingAcceptSessionsSemaphoreSlim.Release();
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
                while (!pumpCancellationToken.IsCancellationRequested && !session.IsClosedOrClosing)
                {
                    Message message;
                    try
                    {
                        message = await session.ReceiveAsync(sessionHandlerOptions.MessageWaitTimeout).ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        MessagingEventSource.Log.MessageReceivePumpTaskException(clientId, session.SessionId, exception);
                        if (exception is ServiceBusTimeoutException)
                        {
                            // Timeout Exceptions are pretty common. Not alerting the User on this.
                            continue;
                        }

                        if (!(exception is ObjectDisposedException && pumpCancellationToken.IsCancellationRequested))
                        {
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false); 
                        }
                        break;
                    }

                    if (message == null)
                    {
                        MessagingEventSource.Log.SessionReceivePumpSessionEmpty(clientId, session.SessionId);
                        break;
                    }

                    bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
                    Activity activity = isDiagnosticSourceEnabled ? diagnosticSource.ProcessSessionStart(session, message) : null;
                    Task processTask = null;

                    try
                    {
                        // Set the timer
                        autoRenewLockCancellationTimer.Change(sessionHandlerOptions.MaxAutoRenewDuration,
                            TimeSpan.FromMilliseconds(-1));
                        var callbackExceptionOccurred = false;
                        try
                        {
                            processTask = userOnSessionCallback(session, message, pumpCancellationToken);
                            await processTask.ConfigureAwait(false);
                        }
                        catch (Exception exception)
                        {
                            if (isDiagnosticSourceEnabled)
                            {
                                diagnosticSource.ReportException(exception);
                            }

                            MessagingEventSource.Log.MessageReceivePumpTaskException(clientId, session.SessionId, exception);
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
                        diagnosticSource.ProcessSessionStop(activity, session, message, processTask?.Status);
                    }
                }
            }
            finally
            {
                renewLockCancellationTokenSource.Cancel();
                renewLockCancellationTokenSource.Dispose();
                autoRenewLockCancellationTimer.Dispose();

                await CloseSessionIfNeededAsync(session).ConfigureAwait(false);
                maxConcurrentSessionsSemaphoreSlim.Release();
            }
        }

        private async Task CloseSessionIfNeededAsync(IMessageSession session)
        {
            if (!session.IsClosedOrClosing)
            {
                try
                {
                    await session.CloseAsync().ConfigureAwait(false);
                    MessagingEventSource.Log.SessionReceivePumpSessionClosed(clientId, session.SessionId);
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionCloseException(clientId, session.SessionId, exception);
                    await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.CloseMessageSession).ConfigureAwait(false);
                }
            }
        }

        private async Task RenewSessionLockTaskAsync(IMessageSession session, CancellationToken renewLockCancellationToken)
        {
            while (!pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(session.LockedUntilUtc);

                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStart(clientId, session.SessionId, amount);
                    await Task.Delay(amount, renewLockCancellationToken).ConfigureAwait(false);

                    if (!pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await session.RenewSessionLockAsync().ConfigureAwait(false);
                        MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStop(clientId, session.SessionId);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockException(clientId, session.SessionId, exception);

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