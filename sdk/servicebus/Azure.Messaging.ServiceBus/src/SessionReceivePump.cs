// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    internal sealed class SessionReceivePump
    {
        private readonly string clientId;

        private readonly SessionClient client;

        private readonly Func<MessageSession, ReceivedMessage, CancellationToken, Task> userOnSessionCallback;

        private readonly SessionHandlerOptions sessionHandlerOptions;

        private readonly string endpoint;

        private readonly string entityPath;

        private readonly CancellationToken pumpCancellationToken;

        private readonly SemaphoreSlim maxConcurrentSessionsSemaphoreSlim;

        private readonly SemaphoreSlim maxPendingAcceptSessionsSemaphoreSlim;
        private readonly ServiceBusDiagnosticSource diagnosticSource;

        public SessionReceivePump(string clientId,
            SessionClient client,
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            Func<MessageSession, ReceivedMessage, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken token)
        {
            this.client = client ?? throw new ArgumentException(nameof(client));
            this.clientId = clientId;
            this.ReceiveMode = receiveMode;
            this.sessionHandlerOptions = sessionHandlerOptions;
            this.userOnSessionCallback = callback;
            this.endpoint = endpoint.Authority;
            this.entityPath = client.EntityPath;
            this.pumpCancellationToken = token;
            this.maxConcurrentSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentSessions);
            this.maxPendingAcceptSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls);
            this.diagnosticSource = new ServiceBusDiagnosticSource(client.EntityPath, endpoint);
        }

        private ReceiveMode ReceiveMode { get; }

        public void StartPump()
        {
            // Schedule Tasks for doing PendingAcceptSession calls
            for (var i = 0; i < this.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls; i++)
            {
                TaskExtensionHelper.Schedule(this.SessionPumpTaskAsync);
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
                this.ReceiveMode == ReceiveMode.PeekLock &&
                this.sessionHandlerOptions.AutoRenewLock;
        }

        private Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, this.endpoint, this.entityPath, this.clientId);
            return this.sessionHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        private async Task CompleteMessageIfNeededAsync(MessageSession session, ReceivedMessage message)
        {
            try
            {
                if (this.ReceiveMode == ReceiveMode.PeekLock &&
                    this.sessionHandlerOptions.AutoComplete)
                {
                    await session.CompleteAsync(new[] { message.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        private async Task AbandonMessageIfNeededAsync(MessageSession session, ReceivedMessage message)
        {
            try
            {
                if (session.ReceiveMode == ReceiveMode.PeekLock)
                {
                    await session.AbandonAsync(message.LockToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        private async Task SessionPumpTaskAsync()
        {
            while (!this.pumpCancellationToken.IsCancellationRequested)
            {
                var concurrentSessionSemaphoreAcquired = false;
                try
                {
                    await this.maxConcurrentSessionsSemaphoreSlim.WaitAsync(this.pumpCancellationToken).ConfigureAwait(false);
                    concurrentSessionSemaphoreAcquired = true;

                    await this.maxPendingAcceptSessionsSemaphoreSlim.WaitAsync(this.pumpCancellationToken).ConfigureAwait(false);
                    var session = await this.client.AcceptMessageSessionAsync().ConfigureAwait(false);
                    if (session == null)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, this.pumpCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    // `session` needs to be copied to another local variable before passing to Schedule
                    // because of the way variables are captured. (Refer 'Captured variables')
                    var messageSession = session;
                    TaskExtensionHelper.Schedule(() => this.MessagePumpTaskAsync(messageSession));
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionReceiveException(this.clientId, exception);

                    if (concurrentSessionSemaphoreAcquired)
                    {
                        this.maxConcurrentSessionsSemaphoreSlim.Release();
                    }

                    if (exception is ServiceBusTimeoutException)
                    {
                        await Task.Delay(Constants.NoMessageBackoffTimeSpan, this.pumpCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        if (!(exception is ObjectDisposedException && this.pumpCancellationToken.IsCancellationRequested))
                        {
                            await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.AcceptMessageSession).ConfigureAwait(false);
                        }
                        if (!MessagingUtilities.ShouldRetry(exception))
                        {
                            await Task.Delay(Constants.NoMessageBackoffTimeSpan, this.pumpCancellationToken).ConfigureAwait(false);
                        }
                    }
                }
                finally
                {
                    this.maxPendingAcceptSessionsSemaphoreSlim.Release();
                }
            }
        }

        private async Task MessagePumpTaskAsync(MessageSession session)
        {
            if (session == null)
            {
                return;
            }

            var renewLockCancellationTokenSource = new CancellationTokenSource();
            if (this.ShouldRenewSessionLock())
            {
                TaskExtensionHelper.Schedule(() => this.RenewSessionLockTaskAsync(session, renewLockCancellationTokenSource.Token));
            }

            var autoRenewLockCancellationTimer = new Timer(
                CancelAutoRenewLock,
                renewLockCancellationTokenSource,
                Timeout.Infinite,
                Timeout.Infinite);

            try
            {
                while (!this.pumpCancellationToken.IsCancellationRequested && !session.ClientEntity.IsClosedOrClosing)
                {
                    ReceivedMessage message;
                    try
                    {
                        message = await session.ReceiveAsync(this.sessionHandlerOptions.MessageWaitTimeout).ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        MessagingEventSource.Log.MessageReceivePumpTaskException(this.clientId, session.SessionId, exception);
                        if (exception is ServiceBusTimeoutException)
                        {
                            // Timeout Exceptions are pretty common. Not alerting the User on this.
                            continue;
                        }

                        if (!(exception is ObjectDisposedException && this.pumpCancellationToken.IsCancellationRequested))
                        {
                            await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                        }
                        break;
                    }

                    if (message == null)
                    {
                        MessagingEventSource.Log.SessionReceivePumpSessionEmpty(this.clientId, session.SessionId);
                        break;
                    }

                    bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
                    Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.ProcessSessionStart(session, message) : null;
                    Task processTask = null;

                    try
                    {
                        // Set the timer
                        autoRenewLockCancellationTimer.Change(this.sessionHandlerOptions.MaxAutoRenewDuration,
                            TimeSpan.FromMilliseconds(-1));
                        var callbackExceptionOccurred = false;
                        try
                        {
                            processTask = this.userOnSessionCallback(session, message, this.pumpCancellationToken);
                            await processTask.ConfigureAwait(false);
                        }
                        catch (Exception exception)
                        {
                            if (isDiagnosticSourceEnabled)
                            {
                                this.diagnosticSource.ReportException(exception);
                            }

                            MessagingEventSource.Log.MessageReceivePumpTaskException(this.clientId, session.SessionId, exception);
                            await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);
                            callbackExceptionOccurred = true;
                            if (!(exception is MessageLockLostException || exception is SessionLockLostException))
                            {
                                await this.AbandonMessageIfNeededAsync(session, message).ConfigureAwait(false);
                            }
                        }
                        finally
                        {
                            autoRenewLockCancellationTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        }

                        if (!callbackExceptionOccurred)
                        {
                            await this.CompleteMessageIfNeededAsync(session, message).ConfigureAwait(false);
                        }
                        else if (session.ClientEntity.IsClosedOrClosing)
                        {
                            // If User closed the session as part of the callback, break out of the loop
                            break;
                        }
                    }
                    finally
                    {
                        this.diagnosticSource.ProcessSessionStop(activity, session, message, processTask?.Status);
                    }
                }
            }
            finally
            {
                renewLockCancellationTokenSource.Cancel();
                renewLockCancellationTokenSource.Dispose();
                autoRenewLockCancellationTimer.Dispose();

                await this.CloseSessionIfNeededAsync(session).ConfigureAwait(false);
                this.maxConcurrentSessionsSemaphoreSlim.Release();
            }
        }

        private async Task CloseSessionIfNeededAsync(MessageSession session)
        {
            if (!session.ClientEntity.IsClosedOrClosing)
            {
                try
                {
                    await session.DisposeAsync().ConfigureAwait(false);
                    MessagingEventSource.Log.SessionReceivePumpSessionClosed(this.clientId, session.SessionId);
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionCloseException(this.clientId, session.SessionId, exception);
                    await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.CloseMessageSession).ConfigureAwait(false);
                }
            }
        }

        private async Task RenewSessionLockTaskAsync(MessageSession session, CancellationToken renewLockCancellationToken)
        {
            while (!this.pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(session.LockedUntilUtc);

                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStart(this.clientId, session.SessionId, amount);
                    await Task.Delay(amount, renewLockCancellationToken).ConfigureAwait(false);

                    if (!this.pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await session.RenewSessionLockAsync().ConfigureAwait(false);
                        MessagingEventSource.Log.SessionReceivePumpSessionRenewLockStop(this.clientId, session.SessionId);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionRenewLockException(this.clientId, session.SessionId, exception);

                    // TaskCanceled is expected here as renewTasks will be cancelled after the Complete call is made.
                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is TaskCanceledException) && !(exception is ObjectDisposedException))
                    {
                        await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);
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