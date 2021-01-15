// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

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
        /// The Session Id associated with the receiver.
        /// </summary>
        public string SessionId => InnerReceiver.SessionId;

        /// <summary>
        /// Gets the <see cref="DateTimeOffset"/> that the receiver's session is locked until.
        /// </summary>
        public DateTimeOffset SessionLockedUntil => InnerReceiver.SessionLockedUntil;

        /// <summary>
        /// Creates a session receiver which can be used to interact with all messages with the same sessionId.
        /// </summary>
        ///
        /// <param name="entityPath">The name of the specific queue to associate the receiver with.</param>
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="plugins">The set of plugins to apply to incoming messages.</param>
        /// <param name="options">A set of options to apply when configuring the receiver.</param>
        /// <param name="sessionId">The Session Id to receive from or null to receive from the next available session.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        ///<returns>Returns a new instance of the <see cref="ServiceBusSessionReceiver"/> class.</returns>
        internal static async Task<ServiceBusSessionReceiver> CreateSessionReceiverAsync(
            string entityPath,
            ServiceBusConnection connection,
            IList<ServiceBusPlugin> plugins,
            ServiceBusSessionReceiverOptions options,
            string sessionId,
            CancellationToken cancellationToken)
        {
            var receiver = new ServiceBusSessionReceiver(
                connection: connection,
                entityPath: entityPath,
                plugins: plugins,
                options: options,
                sessionId: sessionId);
            try
            {
                await receiver.OpenLinkAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                receiver.Logger.ClientCreateException(typeof(ServiceBusSessionReceiver), receiver.FullyQualifiedNamespace, entityPath, ex);
                throw;
            }
            receiver.Logger.ClientCreateComplete(typeof(ServiceBusSessionReceiver), receiver.Identifier);
            return receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityPath"></param>
        /// <param name="plugins">The set of plugins to apply to incoming messages.</param>
        /// <param name="options">A set of options to apply when configuring the consumer.</param>
        /// <param name="sessionId">An optional session Id to receive from.</param>
        internal ServiceBusSessionReceiver(
            ServiceBusConnection connection,
            string entityPath,
            IList<ServiceBusPlugin> plugins,
            ServiceBusSessionReceiverOptions options,
            string sessionId = default) :
            base(connection, entityPath, true, plugins, options?.ToReceiverOptions(), sessionId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class for mocking.
        /// </summary>
        ///
        protected ServiceBusSessionReceiver() : base() { }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as <see cref="BinaryData"/>.</returns>
        public virtual async Task<BinaryData> GetSessionStateAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSessionReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.GetSessionStateStart(Identifier, SessionId);
            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.GetSessionStateActivityName,
                DiagnosticProperty.ClientKind);
            scope.Start();

            BinaryData sessionState;

            try
            {
                sessionState = await InnerReceiver.GetStateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.GetSessionStateException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.GetSessionStateComplete(Identifier);
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
        public virtual async Task SetSessionStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSessionReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SetSessionStateStart(Identifier, SessionId);
            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.SetSessionStateActivityName,
                DiagnosticProperty.ClientKind);
            scope.Start();

            try
            {
                await InnerReceiver.SetStateAsync(sessionState, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.SetSessionStateException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.SetSessionStateComplete(Identifier);
        }

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// <para>
        /// When you get session receiver, the session is locked for this receiver by the service for a duration as specified during the Queue/Subscription creation.
        /// If processing of the session requires longer than this duration, the session-lock needs to be renewed.
        /// For each renewal, it resets the time the session is locked by the LockDuration set on the Entity.
        /// </para>
        /// <para>
        /// Renewal of session renews all the messages in the session as well. Each individual message need not be renewed.
        /// </para>
        /// </remarks>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSessionReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.RenewSessionLockStart(Identifier, SessionId);
            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.RenewSessionLockActivityName,
                DiagnosticProperty.ClientKind);
            scope.Start();

            try
            {
                await InnerReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.RenewSessionLockException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.RenewSessionLockComplete(Identifier);
        }
    }
}
