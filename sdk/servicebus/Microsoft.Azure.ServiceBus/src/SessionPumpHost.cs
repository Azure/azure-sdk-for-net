// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class SessionPumpHost
    {
	    private readonly object _syncLock;
	    private SessionReceivePump _sessionReceivePump;
	    private CancellationTokenSource _sessionPumpCancellationTokenSource;
	    private readonly Uri _endpoint;

        public SessionPumpHost(string clientId, ReceiveMode receiveMode, ISessionClient sessionClient, Uri endpoint)
        {
            _syncLock = new object();
            ClientId = clientId;
            ReceiveMode = receiveMode;
            SessionClient = sessionClient;
            this._endpoint = endpoint;
        }

        private ReceiveMode ReceiveMode { get; }

        private ISessionClient SessionClient { get; }

        private string ClientId { get; }

        public void Close()
        {
            if (_sessionReceivePump != null)
            {
                _sessionPumpCancellationTokenSource?.Cancel();
                _sessionPumpCancellationTokenSource?.Dispose();
                _sessionReceivePump = null;
            }
        }

        public void OnSessionHandler(
            Func<IMessageSession, Message, CancellationToken, Task> callback,
            SessionHandlerOptions sessionHandlerOptions)
        {
            MessagingEventSource.Log.RegisterOnSessionHandlerStart(ClientId, sessionHandlerOptions);

            lock (_syncLock)
            {
                if (_sessionReceivePump != null)
                {
                    throw new InvalidOperationException(Resources.SessionHandlerAlreadyRegistered);
                }

                _sessionPumpCancellationTokenSource = new CancellationTokenSource();
                _sessionReceivePump = new SessionReceivePump(
                    ClientId,
                    SessionClient,
                    ReceiveMode,
                    sessionHandlerOptions,
                    callback,
                    _endpoint,
                    _sessionPumpCancellationTokenSource.Token);
            }

            try
            {
                _sessionReceivePump.StartPump();
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RegisterOnSessionHandlerException(ClientId, exception);
                if (_sessionReceivePump != null)
                {
                    _sessionPumpCancellationTokenSource.Cancel();
                    _sessionPumpCancellationTokenSource.Dispose();
                    _sessionReceivePump = null;
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnSessionHandlerStop(ClientId);
        }
    }
}