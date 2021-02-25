// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using Microsoft.Azure.ServiceBus.Primitives;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class SessionPumpHost
    {
        readonly object syncLock;
        SessionReceivePump sessionReceivePump;
        CancellationTokenSource sessionPumpCancellationTokenSource;
        CancellationTokenSource runningTaskCancellationTokenSource;
        readonly Uri endpoint;

        public SessionPumpHost(string clientId, ReceiveMode receiveMode, ISessionClient sessionClient, Uri endpoint)
        {
            this.syncLock = new object();
            this.ClientId = clientId;
            this.ReceiveMode = receiveMode;
            this.SessionClient = sessionClient;
            this.endpoint = endpoint;
        }

        ReceiveMode ReceiveMode { get; }

        ISessionClient SessionClient { get; }

        string ClientId { get; }

        public void Close()
        {
            if (this.sessionReceivePump != null)
            {
                this.sessionPumpCancellationTokenSource?.Cancel();
                this.sessionPumpCancellationTokenSource?.Dispose();
                // For back-compatibility 
                this.runningTaskCancellationTokenSource?.Cancel();
                this.runningTaskCancellationTokenSource?.Dispose();
                this.sessionReceivePump = null;
            }
        }

        public void OnSessionHandler(
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            SessionHandlerOptions sessionHandlerOptions)
        {
            MessagingEventSource.Log.RegisterOnSessionHandlerStart(this.ClientId, sessionHandlerOptions);

            lock (this.syncLock)
            {
                if (this.sessionReceivePump != null)
                {
                    throw new InvalidOperationException(Resources.SessionHandlerAlreadyRegistered);
                }

                this.sessionPumpCancellationTokenSource = new CancellationTokenSource();
                this.runningTaskCancellationTokenSource = new CancellationTokenSource();

                this.sessionReceivePump = new SessionReceivePump(
                    this.ClientId,
                    this.SessionClient,
                    this.ReceiveMode,
                    sessionHandlerOptions,
                    callback,
                    this.endpoint,
                    this.sessionPumpCancellationTokenSource.Token,
                    this.runningTaskCancellationTokenSource.Token);
            }

            try
            {
                this.sessionReceivePump.StartPump();
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RegisterOnSessionHandlerException(this.ClientId, exception);
                if (this.sessionReceivePump != null)
                {
                    this.sessionPumpCancellationTokenSource.Cancel();
                    this.sessionPumpCancellationTokenSource.Dispose();
                    this.runningTaskCancellationTokenSource.Cancel();
                    this.runningTaskCancellationTokenSource.Dispose();
                    this.sessionReceivePump = null;
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnSessionHandlerStop(this.ClientId);
        }

        public async Task UnregisterSessionHandlerAsync(TimeSpan inflightSessionHandlerTasksWaitTimeout)
        {
            if (inflightSessionHandlerTasksWaitTimeout <= TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(nameof(inflightSessionHandlerTasksWaitTimeout), inflightSessionHandlerTasksWaitTimeout, Resources.TimeoutMustBePositiveNonZero.FormatForUser(nameof(inflightSessionHandlerTasksWaitTimeout), inflightSessionHandlerTasksWaitTimeout));
            }

            MessagingEventSource.Log.UnregisterSessionHandlerStart(this.ClientId);
            lock (this.syncLock)
            {
                if (this.sessionReceivePump == null || this.sessionPumpCancellationTokenSource.IsCancellationRequested)
                {
                    // Silently return if handler has already been unregistered. 
                    return;
                }

                this.sessionPumpCancellationTokenSource.Cancel();
                this.sessionPumpCancellationTokenSource.Dispose();
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            while (this.sessionReceivePump != null
                && stopWatch.Elapsed < inflightSessionHandlerTasksWaitTimeout
                && (this.sessionReceivePump.maxConcurrentSessionsSemaphoreSlim.CurrentCount < 
                    this.sessionReceivePump.sessionHandlerOptions.MaxConcurrentSessions
                || this.sessionReceivePump.maxPendingAcceptSessionsSemaphoreSlim.CurrentCount <           
                this.sessionReceivePump.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls))
            {
                // We can proceed when the inflight tasks are done. 
                if (this.sessionReceivePump.maxConcurrentSessionsSemaphoreSlim.CurrentCount ==
                    this.sessionReceivePump.sessionHandlerOptions.MaxConcurrentSessions
                && this.sessionReceivePump.maxPendingAcceptSessionsSemaphoreSlim.CurrentCount ==
                this.sessionReceivePump.sessionHandlerOptions.MaxConcurrentAcceptSessionCalls)
                {
                    break;
                }

                await Task.Delay(10).ConfigureAwait(false);
            }

            lock (this.sessionPumpCancellationTokenSource)
            {
                this.runningTaskCancellationTokenSource.Cancel();
                this.runningTaskCancellationTokenSource.Dispose();
                this.sessionReceivePump = null;
            }
            MessagingEventSource.Log.UnregisterSessionHandlerStop(this.ClientId);
        }
    }
}