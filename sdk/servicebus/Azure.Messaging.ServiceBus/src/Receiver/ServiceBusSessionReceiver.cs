// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusSessionReceiver" /> is responsible for receiving <see cref="ServiceBusReceivedMessage" />
    ///  and settling messages from session-enabled Queues and Subscriptions. It is constructed by calling
    ///  <see cref="ServiceBusClient.AcceptNextSessionAsync(string, string, ServiceBusSessionReceiverOptions, CancellationToken)"/>.
    /// </summary>
    public class ServiceBusSessionReceiver : ServiceBusReceiver
    {
        /// <summary>
        /// The active connection to the Azure Service Bus service, enabling client communications for metadata
        /// about the associated Service Bus entity and access to transport-aware receivers.
        /// </summary>
        ///
        private readonly ServiceBusConnection _connection;

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public virtual string SessionId => InnerReceiver.SessionId;

        /// <summary>
        /// Indicates whether or not this <see cref="ServiceBusSessionReceiver"/> has been closed by the user, or whether the underlying
        /// session link was closed due to either losing the session lock or having the link disconnected. If this is <c>true</c>, the
        /// receiver cannot be used for any more operations. If this is <c>false</c>, it is still possible that the session lock has been lost
        /// so it is important to still handle <see cref="ServiceBusException" /> with <see cref="ServiceBusException.Reason" /> equal to
        /// <see cref="ServiceBusFailureReason.SessionLockLost"/>.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the session receiver was closed by the user or if the underlying link was closed; otherwise, <c>false</c>.
        /// </value>
        public override bool IsClosed => IsDisposed || InnerReceiver.IsSessionLinkClosed;

        /// <summary>
        /// Gets the <see cref="DateTimeOffset"/> that the receiver's session is locked until.
        /// </summary>
        public virtual DateTimeOffset SessionLockedUntil => InnerReceiver.SessionLockedUntil;

        ///  <summary>
        ///  Creates a session receiver which can be used to interact with all messages with the same sessionId.
        ///  </summary>
        ///  <param name="entityPath">The name of the specific queue to associate the receiver with.</param>
        ///  <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        ///  <param name="options">A set of options to apply when configuring the receiver.</param>
        ///  <param name="sessionId">The Session Id to receive from or null to receive from the next available session.</param>
        ///  <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///  <param name="isProcessor">True if called from the session processor.</param>
        ///  <returns>Returns a new instance of the <see cref="ServiceBusSessionReceiver"/> class.</returns>
        internal static async Task<ServiceBusSessionReceiver> CreateSessionReceiverAsync(
            string entityPath,
            ServiceBusConnection connection,
            ServiceBusSessionReceiverOptions options,
            string sessionId,
            CancellationToken cancellationToken,
            bool isProcessor = false)
        {
            var receiver = new ServiceBusSessionReceiver(
                connection: connection,
                entityPath: entityPath,
                options: options,
                cancellationToken: cancellationToken,
                sessionId: sessionId,
                isProcessor: isProcessor);
            try
            {
                await receiver.OpenLinkAsync(cancellationToken).ConfigureAwait(false);
                receiver.Logger.ClientCreateComplete(typeof(ServiceBusSessionReceiver), receiver.Identifier);
                return receiver;
            }
            catch (ServiceBusException e)
                when (e.Reason == ServiceBusFailureReason.ServiceTimeout)
            {
                await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);

                if (isProcessor)
                {
                    receiver.Logger.ProcessorAcceptSessionTimeout(receiver.FullyQualifiedNamespace, entityPath, e.ToString());
                }
                else
                {
                    receiver.Logger.ReceiverAcceptSessionTimeout(receiver.FullyQualifiedNamespace, entityPath, e.ToString());
                }

                throw;
            }
            catch (TaskCanceledException exception)
            {
                await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);

                if (isProcessor)
                {
                    receiver.Logger.ProcessorStoppingAcceptSessionCanceled(receiver.FullyQualifiedNamespace, entityPath, exception.ToString());
                }
                else
                {
                    receiver.Logger.ReceiverAcceptSessionCanceled(receiver.FullyQualifiedNamespace, entityPath, exception.ToString());
                }

                throw;
            }
            catch (Exception ex)
            {
                await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                receiver.Logger.ClientCreateException(typeof(ServiceBusSessionReceiver), receiver.FullyQualifiedNamespace, entityPath, ex);
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityPath"></param>
        /// <param name="options">A set of options to apply when configuring the consumer.</param>
        /// <param name="cancellationToken">The cancellation token to use when opening the receiver link.</param>
        /// <param name="sessionId">An optional session Id to receive from.</param>
        /// <param name="isProcessor"></param>
        internal ServiceBusSessionReceiver(
            ServiceBusConnection connection,
            string entityPath,
            ServiceBusSessionReceiverOptions options,
            CancellationToken cancellationToken,
            string sessionId = default,
            bool isProcessor = false) :
            base(connection, entityPath, true, options?.ToReceiverOptions(), sessionId, isProcessor, cancellationToken)
        {
            _connection = connection;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionReceiver"/> class for mocking.
        /// </summary>
        ///
        protected ServiceBusSessionReceiver() { }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as <see cref="BinaryData"/>.</returns>
        /// <exception cref="ServiceBusException">
        ///   The lock for the session has expired.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        /// </exception>
        public virtual async Task<BinaryData> GetSessionStateAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusSessionReceiver));
            _connection.ThrowIfClosed();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.GetSessionStateStart(Identifier, SessionId);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.GetSessionStateActivityName,
                ActivityKind.Client);
            scope.Start();

            BinaryData sessionState;

            try
            {
                sessionState = await InnerReceiver.GetStateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.GetSessionStateException(Identifier, exception.ToString(), SessionId);
                scope.Failed(exception);
                throw;
            }

            Logger.GetSessionStateComplete(Identifier, SessionId);
            return sessionState;
        }

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetSessionStateAsync"/>
        /// </summary>
        ///
        /// <param name="sessionState">A <see cref="BinaryData"/> of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        /// <exception cref="ServiceBusException">
        ///   The lock for the session has expired.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        /// </exception>
        public virtual async Task SetSessionStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusSessionReceiver));
            _connection.ThrowIfClosed();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SetSessionStateStart(Identifier, SessionId);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.SetSessionStateActivityName,
                ActivityKind.Client);
            scope.Start();

            try
            {
                await InnerReceiver.SetStateAsync(sessionState, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.SetSessionStateException(Identifier, exception.ToString(), SessionId);
                scope.Failed(exception);
                throw;
            }

            Logger.SetSessionStateComplete(Identifier, SessionId);
        }

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// <para>
        /// When you accept a session, the session is locked for this receiver by the service for a duration as specified during the Queue/Subscription creation.
        /// If processing of the session requires longer than this duration, the session-lock needs to be renewed.
        /// For each renewal, it resets the time the session is locked by the LockDuration set on the Entity.
        /// </para>
        /// <para>
        /// Renewal of session renews all the messages in the session as well. Each individual message need not be renewed.
        /// </para>
        /// </remarks>
        /// <exception cref="ServiceBusException">
        ///   The lock for the session has expired.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        /// </exception>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusSessionReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.RenewSessionLockStart(Identifier, SessionId);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.RenewSessionLockActivityName,
                ActivityKind.Client);
            scope.Start();

            try
            {
                await InnerReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.RenewSessionLockException(Identifier, exception.ToString(), SessionId);
                scope.Failed(exception);
                throw;
            }

            Logger.RenewSessionLockComplete(Identifier, SessionId);
        }
    }
}
