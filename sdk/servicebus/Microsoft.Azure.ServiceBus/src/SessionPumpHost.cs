// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class SessionPumpHost
    {
	    private readonly object syncLock;
	    private SessionReceivePump sessionReceivePump;
	    private CancellationTokenSource sessionPumpCancellationTokenSource;
	    private readonly Uri endpoint;

        public SessionPumpHost(string clientId, ReceiveMode receiveMode, ISessionClient sessionClient, Uri endpoint)
        {
            syncLock = new object();
            ClientId = clientId;
            ReceiveMode = receiveMode;
            SessionClient = sessionClient;
            this.endpoint = endpoint;
        }

        private ReceiveMode ReceiveMode { get; }

        private ISessionClient SessionClient { get; }

        private string ClientId { get; }

        public void Close()
        {
            if (sessionReceivePump != null)
            {
                sessionPumpCancellationTokenSource?.Cancel();
                sessionPumpCancellationTokenSource?.Dispose();
                sessionReceivePump = null;
            }
        }

        public void OnSessionHandler(
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            SessionHandlerOptions sessionHandlerOptions)
        {
            MessagingEventSource.Log.RegisterOnSessionHandlerStart(ClientId, sessionHandlerOptions);

            lock (syncLock)
            {
                if (sessionReceivePump != null)
                {
                    throw new InvalidOperationException(Resources.SessionHandlerAlreadyRegistered);
                }

                sessionPumpCancellationTokenSource = new CancellationTokenSource();
                sessionReceivePump = new SessionReceivePump(
                    ClientId,
                    SessionClient,
                    ReceiveMode,
                    sessionHandlerOptions,
                    callback,
                    endpoint,
                    sessionPumpCancellationTokenSource.Token);
            }

            try
            {
                sessionReceivePump.StartPump();
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RegisterOnSessionHandlerException(ClientId, exception);
                if (sessionReceivePump != null)
                {
                    sessionPumpCancellationTokenSource.Cancel();
                    sessionPumpCancellationTokenSource.Dispose();
                    sessionReceivePump = null;
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnSessionHandlerStop(ClientId);
        }
    }
}