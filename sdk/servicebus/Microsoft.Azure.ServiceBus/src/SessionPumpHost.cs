// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class SessionPumpHost
    {
        readonly object syncLock;
        SessionReceivePump sessionReceivePump;
        CancellationTokenSource sessionPumpCancellationTokenSource;
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
    }
}