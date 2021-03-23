// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    sealed class SessionReceivePump
    {
        public readonly SemaphoreSlim maxConcurrentSessionsSemaphoreSlim;
        public readonly SemaphoreSlim maxPendingAcceptSessionsSemaphoreSlim;
        public readonly SessionHandlerOptions sessionHandlerOptions;
        readonly string clientId;
        readonly ISessionClient client;
        readonly Func<IMessageSession, Message, CancellationToken, Task> userOnSessionCallback;
        readonly string endpoint;
        readonly string entityPath;
        readonly CancellationToken pumpCancellationToken;
        readonly CancellationToken runningTaskCancellationToken;
        private readonly ServiceBusDiagnosticSource diagnosticSource;

        public SessionReceivePump(string clientId,
            ISessionClient client,
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken pumpToken,
            CancellationToken runningTaskToken)
        {
            this.client = client ?? throw new ArgumentException(nameof(client));
            this.clientId = clientId;
            this.ReceiveMode = receiveMode;
            this.sessionHandlerOptions = sessionHandlerOptions;
            this.userOnSessionCallback = callback;
            this.endpoint = endpoint.Authority;
            this.entityPath = client.EntityPath;
            this.pumpCancellationToken = pumpToken;
            this.runningTaskCancellationToken = runningTaskToken;
            this.maxConcurrentSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentSessions);
            this.maxPendingAcceptSessionsSemaphoreSlim = new SemaphoreSlim(this.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls);
            this.diagnosticSource = new ServiceBusDiagnosticSource(client.EntityPath, endpoint);
        }

        ReceiveMode ReceiveMode { get; }

        public void StartPump()
        {
            // Schedule Tasks for doing PendingAcceptSession calls
            for (var i = 0; i < this.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls; i++)
            {
                TaskExtensionHelper.Schedule(this.SessionPumpTaskAsync);
            }
        }

        static void CancelAutoRenewLock(object state)
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

        bool ShouldRenewSessionLock()
        {
            return
                this.ReceiveMode == ReceiveMode.PeekLock &&
                this.sessionHandlerOptions.AutoRenewLock;
        }

        Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, this.endpoint, this.entityPath, this.clientId);
            return this.sessionHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        async Task CompleteMessageIfNeededAsync(IMessageSession session, Message message)
        {
            try
            {
                if (this.ReceiveMode == ReceiveMode.PeekLock &&
                    this.sessionHandlerOptions.AutoComplete)
                {
                    await session.CompleteAsync(new[] { message.SystemProperties.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        async Task AbandonMessageIfNeededAsync(IMessageSession session, Message message)
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
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        async Task SessionPumpTaskAsync()
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

        async Task MessagePumpTaskAsync(IMessageSession session)
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
                while (!this.pumpCancellationToken.IsCancellationRequested && !session.IsClosedOrClosing)
                {
                    Message message;
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
                            processTask = this.userOnSessionCallback(session, message, this.runningTaskCancellationToken);
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
                        else if (session.IsClosedOrClosing)
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

        async Task CloseSessionIfNeededAsync(IMessageSession session)
        {
            if (!session.IsClosedOrClosing)
            {
                try
                {
                    await session.CloseAsync().ConfigureAwait(false);
                    MessagingEventSource.Log.SessionReceivePumpSessionClosed(this.clientId, session.SessionId);
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.SessionReceivePumpSessionCloseException(this.clientId, session.SessionId, exception);
                    await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.CloseMessageSession).ConfigureAwait(false);
                }
            }
        }

        async Task RenewSessionLockTaskAsync(IMessageSession session, CancellationToken renewLockCancellationToken)
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