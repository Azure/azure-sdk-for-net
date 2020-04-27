// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Amqp;
    using Azure.Amqp;
    using Core;
    using Primitives;

    internal class MessageSession : MessageReceiver, IMessageSession
    {
        private readonly ServiceBusDiagnosticSource _diagnosticSource;

        public MessageSession(
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy,
            int prefetchCount = Constants.DefaultClientPrefetchCount,
            string sessionId = null,
            bool isSessionReceiver = false)
            : base(entityPath, entityType, receiveMode, serviceBusConnection, cbsTokenProvider, retryPolicy, prefetchCount, sessionId, isSessionReceiver)
        {
            _diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);
        }

        /// <summary>
        /// Gets the time that the session identified by <see cref="SessionId"/> is locked until for this client.
        /// </summary>
        public DateTime LockedUntilUtc
        {
            get => LockedUntilUtcInternal;
            internal set => LockedUntilUtcInternal = value;
        }

        /// <summary>
        /// Gets the SessionId.
        /// </summary>
        public string SessionId => SessionIdInternal;

        public Task<byte[]> GetStateAsync()
        {
            ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? OnGetStateInstrumentedAsync() : OnGetStateAsync();
        }

        public Task SetStateAsync(byte[] sessionState)
        {
            ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? OnSetStateInstrumentedAsync(sessionState) : OnSetStateAsync(sessionState);
        }

        public Task RenewSessionLockAsync()
        {
            ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? OnRenewSessionLockInstrumentedAsync() : OnRenewSessionLockAsync();
        }

        protected override void OnMessageHandler(MessageHandlerOptions registerHandlerOptions, Func<Message, CancellationToken, Task> callback)
        {
            throw new InvalidOperationException($"{nameof(RegisterMessageHandler)} is not supported for Sessions.");
        }

        protected override Task<DateTime> OnRenewLockAsync(string lockToken)
        {
            throw new InvalidOperationException($"{nameof(RenewLockAsync)} is not supported for Session. Use {nameof(RenewSessionLockAsync)} to renew sessions instead");
        }

        protected async Task<byte[]> OnGetStateAsync()
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.GetSessionStateOperation, OperationTimeout, null);

                if (ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionIdInternal;

                var amqpResponseMessage = await ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                byte[] sessionState = null;
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    if (amqpResponseMessage.Map[ManagementConstants.Properties.SessionState] != null)
                    {
                        sessionState = amqpResponseMessage.GetValue<ArraySegment<byte>>(ManagementConstants.Properties.SessionState).Array;
                    }
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }

                return sessionState;
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        protected async Task OnSetStateAsync(byte[] sessionState)
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.SetSessionStateOperation, OperationTimeout, null);

                if (ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionIdInternal;

                if (sessionState != null)
                {
                    var value = new ArraySegment<byte>(sessionState);
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = value;
                }
                else
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = null;
                }

                var amqpResponseMessage = await ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        protected async Task OnRenewSessionLockAsync()
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, OperationTimeout, null);

                if (ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionIdInternal;

                var amqpResponseMessage = await ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    LockedUntilUtcInternal = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        /// <summary>
        /// Throw an OperationCanceledException if the object is Closing.
        /// </summary>
        protected override void ThrowIfClosed()
        {
            if (IsClosedOrClosing)
            {
                throw new ObjectDisposedException($"MessageSession with Id '{ClientId}' has already been closed. Please accept a new MessageSession.");
            }
        }

        private async Task<byte[]> OnGetStateInstrumentedAsync()
        {
            var activity = _diagnosticSource.GetSessionStateStart(SessionId);
            Task<byte[]> getStateTask = null;
            byte[] state = null;

            try
            {
                getStateTask = OnGetStateAsync();
                state = await getStateTask.ConfigureAwait(false);
                return state;
            }
            catch (Exception ex)
            {
                _diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                _diagnosticSource.GetSessionStateStop(activity, SessionId, state, getStateTask?.Status);
            }
        }

        private async Task OnSetStateInstrumentedAsync(byte[] sessionState)
        {
            var activity = _diagnosticSource.SetSessionStateStart(SessionId, sessionState);
            Task setStateTask = null;

            try
            {
                setStateTask = OnSetStateAsync(sessionState);
                await setStateTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                _diagnosticSource.SetSessionStateStop(activity, sessionState, SessionId, setStateTask?.Status);
            }
        }

        private async Task OnRenewSessionLockInstrumentedAsync()
        {
            var activity = _diagnosticSource.RenewSessionLockStart(SessionId);
            Task renewTask = null;

            try
            {
                renewTask = OnRenewSessionLockAsync();
                await renewTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                _diagnosticSource.RenewSessionLockStop(activity, SessionId, renewTask?.Status);
            }
        }

    }
}