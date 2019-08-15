// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class SessionPumpHost: IAsyncDisposable
    {
        private readonly object syncLock;

        private SessionReceivePump sessionReceivePump;

        private CancellationTokenSource sessionPumpCancellationTokenSource;

        private readonly Uri endpoint;

        public SessionPumpHost(string clientId, ReceiveMode receiveMode, SessionClient sessionClient, Uri endpoint)
        {
            this.syncLock = new object();
            this.ClientId = clientId;
            this.ReceiveMode = receiveMode;
            this.SessionClient = sessionClient;
            this.endpoint = endpoint;
        }

        private ReceiveMode ReceiveMode { get; }

        private SessionClient SessionClient { get; }

        private string ClientId { get; }

        public void Close()
        {
            if (this.sessionReceivePump != null)
            {
                this.sessionPumpCancellationTokenSource?.Cancel();
                this.sessionPumpCancellationTokenSource?.Dispose();
                this.sessionReceivePump = null;
            }
        }

        public void RegisterSessionHandler(
            Func<MessageSession, ReceivedMessage, CancellationToken, Task> callback,
            Func<ExceptionReceivedEventArgs, Task> exceptionAction)
        {
            RegisterSessionHandler(callback, new SessionHandlerOptions(exceptionAction));
        }

        public void RegisterSessionHandler(
            Func<MessageSession, ReceivedMessage, CancellationToken, Task> callback,
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
                this.sessionReceivePump = new SessionReceivePump(
                    this.ClientId,
                    this.SessionClient,
                    this.ReceiveMode,
                    sessionHandlerOptions,
                    callback,
                    this.endpoint,
                    this.sessionPumpCancellationTokenSource.Token);
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
                    this.sessionReceivePump = null;
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnSessionHandlerStop(this.ClientId);
        }

        public async ValueTask DisposeAsync()
        {
            await SessionClient.DisposeAsync();
        }
    }
}