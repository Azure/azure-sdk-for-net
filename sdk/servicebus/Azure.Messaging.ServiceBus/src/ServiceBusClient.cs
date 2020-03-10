// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Indicate that this is one connection.
    ///
    /// </summary>
    public class ServiceBusClient : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusConnection"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the connection is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; }

        /// <summary>
        /// The transport type used for this connection.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        ///   A unique name used to identify this client.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   Closes the connection to the Service Bus namespace and associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async virtual Task CloseAsync(CancellationToken cancellationToken = default)
        {
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), Identifier);

            try
            {
                await Connection.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseException(typeof(ServiceBusConnection), Identifier, ex);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusConnection), Identifier);
            }
        }


        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusConnection" />,
        ///   including ensuring that the connection itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        /// Can be used for mocking.
        /// </summary>
        protected ServiceBusClient()
        {
        }

        /// <summary>
        ///
        /// </summary>
        internal ServiceBusConnection Connection { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        public ServiceBusClient(string connectionString) :
            this(connectionString, new ServiceBusClientOptions())
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="options"></param>
        public ServiceBusClient(string connectionString, ServiceBusClientOptions options)
        {
            Connection = new ServiceBusConnection(connectionString, options);
            Identifier = DiagnosticUtilities.GenerateIdentifier(Connection.FullyQualifiedNamespace);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential) :
            this(fullyQualifiedNamespace, credential, new ServiceBusClientOptions())
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential, ServiceBusClientOptions options)
        {
            Identifier = DiagnosticUtilities.GenerateIdentifier(fullyQualifiedNamespace);
            Connection = new ServiceBusConnection(
                fullyQualifiedNamespace,
                credential,
                options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public ServiceBusSender GetSender(string entityName) =>
            new ServiceBusSender(
                entityName: entityName,
                connection: Connection,
                options: new ServiceBusSenderOptions());

        private void ValidateEntityName(string entityName)
        {
            if (Connection.EntityName != null && entityName != Connection.EntityName)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusSender GetSender(string entityName, ServiceBusSenderOptions options) =>
            new ServiceBusSender(
                entityName: entityName,
                connection: Connection,
                options: options);

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName) =>
            ServiceBusReceiver.CreateReceiver(
                entityName: queueName,
                connection: Connection);

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName, ServiceBusReceiverOptions options) =>
            ServiceBusReceiver.CreateReceiver(
                entityName: queueName,
                connection: Connection,
                options: options);

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string topicName, string subscriptionName) =>
            ServiceBusReceiver.CreateReceiver(
                entityName: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection);

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options) =>
            ServiceBusReceiver.CreateReceiver(
                entityName: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                options: options);

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(string queueName) =>
            new ServiceBusProcessor(
                entityName: queueName,
                connection: Connection);

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(string topicName, string subscriptionName) =>
            new ServiceBusProcessor(
                entityName: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSessionReceiverAsync(
            string queueName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default) =>
            await ServiceBusReceiver.CreateSessionReceiverAsync(
                entityName: queueName,
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSessionReceiverAsync(
            string subscriptionName,
            string topicName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default) =>
            await ServiceBusReceiver.CreateSessionReceiverAsync(
                entityName: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
