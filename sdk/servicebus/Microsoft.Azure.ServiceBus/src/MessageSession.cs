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
        private readonly ServiceBusDiagnosticSource diagnosticSource;

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
            this.diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);
        }

        /// <summary>
        /// Gets the time that the session identified by <see cref="SessionId"/> is locked until for this client.
        /// </summary>
        public DateTime LockedUntilUtc
        {
            get => this.LockedUntilUtcInternal;
            internal set => this.LockedUntilUtcInternal = value;
        }

        /// <summary>
        /// Gets the SessionId.
        /// </summary>
        public string SessionId => this.SessionIdInternal;

        public Task<byte[]> GetStateAsync()
        {
            this.ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? this.OnGetStateInstrumentedAsync() : this.OnGetStateAsync();
        }

        public Task SetStateAsync(byte[] sessionState)
        {
            this.ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? this.OnSetStateInstrumentedAsync(sessionState) : this.OnSetStateAsync(sessionState);
        }

        public Task RenewSessionLockAsync()
        {
            this.ThrowIfClosed();
            return ServiceBusDiagnosticSource.IsEnabled() ? this.OnRenewSessionLockInstrumentedAsync() : this.OnRenewSessionLockAsync();
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
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.GetSessionStateOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

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
                throw AmqpExceptionHelper.GetClientException(exception, true);
            }
        }

        protected async Task OnSetStateAsync(byte[] sessionState)
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.SetSessionStateOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                if (sessionState != null)
                {
                    var value = new ArraySegment<byte>(sessionState);
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = value;
                }
                else
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = null;
                }

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception, true);
            }
        }

        protected async Task OnRenewSessionLockAsync()
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    this.LockedUntilUtcInternal = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception, true);
            }
        }

        /// <summary>
        /// Throw an OperationCanceledException if the object is Closing.
        /// </summary>
        protected override void ThrowIfClosed()
        {
            if (this.IsClosedOrClosing)
            {
                throw new ObjectDisposedException($"MessageSession with Id '{this.ClientId}' has already been closed. Please accept a new MessageSession.");
            }
        }

        private async Task<byte[]> OnGetStateInstrumentedAsync()
        {
            Activity activity = this.diagnosticSource.GetSessionStateStart(this.SessionId);
            Task<byte[]> getStateTask = null;
            byte[] state = null;

            try
            {
                getStateTask = this.OnGetStateAsync();
                state = await getStateTask.ConfigureAwait(false);
                return state;
            }
            catch (Exception ex)
            {
                this.diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                this.diagnosticSource.GetSessionStateStop(activity, this.SessionId, state, getStateTask?.Status);
            }
        }

        private async Task OnSetStateInstrumentedAsync(byte[] sessionState)
        {
            Activity activity = this.diagnosticSource.SetSessionStateStart(this.SessionId, sessionState);
            Task setStateTask = null;

            try
            {
                setStateTask = this.OnSetStateAsync(sessionState);
                await setStateTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                this.diagnosticSource.SetSessionStateStop(activity, sessionState, this.SessionId, setStateTask?.Status);
            }
        }

        private async Task OnRenewSessionLockInstrumentedAsync()
        {
            Activity activity = this.diagnosticSource.RenewSessionLockStart(this.SessionId);
            Task renewTask = null;

            try
            {
                renewTask = this.OnRenewSessionLockAsync();
                await renewTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.diagnosticSource.ReportException(ex);
                throw;
            }
            finally
            {
                this.diagnosticSource.RenewSessionLockStop(activity, this.SessionId, renewTask?.Status);
            }
        }

    }
}