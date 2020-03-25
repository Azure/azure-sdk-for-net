// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
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
        internal string Identifier { get; }

        /// <summary>
        ///   The set of client options used for creation of client.
        /// </summary>
        ///
        private ServiceBusClientOptions Options { get; set; }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusConnection" />,
        ///   including ensuring that the connection itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync()
        {
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), Identifier);

            try
            {
                await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
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
            Options = Connection.Options;
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
            Options = Connection.Options;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueOrTopicName"></param>
        /// <returns></returns>
        public ServiceBusSender GetSender(string queueOrTopicName)
        {
            ValidateEntityName(queueOrTopicName);

            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                connection: Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
                options: new ServiceBusReceiverOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(
            string queueName,
            ServiceBusReceiverOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                isSessionEntity: false,
                options: new ServiceBusReceiverOptions());
        }

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
            ServiceBusReceiverOptions options)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSessionReceiverAsync(
            string queueName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);

            return await ServiceBusReceiver.CreateSessionReceiverAsync(
                entityPath: queueName,
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSessionReceiverAsync(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(topicName);

            return await ServiceBusReceiver.CreateSessionReceiverAsync(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(
            string queueName,
            ServiceBusProcessorOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(
            string topicName,
            string subscriptionName,
            ServiceBusProcessorOptions options)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusProcessor GetSessionProcessor(
            string queueName,
            ServiceBusProcessorOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: true,
                sessionId: sessionId,
                options: options ?? new ServiceBusProcessorOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusProcessor GetSessionProcessor(
            string topicName,
            string subscriptionName,
            ServiceBusProcessorOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: true,
                sessionId: sessionId,
                options: options ?? new ServiceBusProcessorOptions());
        }

        private void ValidateEntityName(string entityName)
        {
            // The entity name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
            // value, then do not consider this a failure.

            if (!string.IsNullOrEmpty(Connection.EntityPath) && !string.Equals(entityName, Connection.EntityPath, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(Resources1.OnlyOneEntityNameMayBeSpecified);
            }
        }

        /// <summary>
        /// Subscription manager is used for all basic interactions with a Service Bus Subscription.
        /// </summary>
        internal ServiceBusRuleManager GetRuleManager(string topicName, string subscriptionName) =>
            new ServiceBusRuleManager(topicName, subscriptionName);
    }
}
