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
        /// Subscription manager is used for all basic interactions with a Service Bus Subscription.
        /// </summary>
        public ServiceBusSubscriptionRuleManager SubscriptionRuleManager { get; private set; }

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

        internal bool isConnectionPropertiesValidationNeeded { get; set; }

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
            isConnectionPropertiesValidationNeeded = true;
            Options = Connection.Options;
            Identifier = DiagnosticUtilities.GenerateIdentifier(Connection.FullyQualifiedNamespace);
            SubscriptionRuleManager = new ServiceBusSubscriptionRuleManager();
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
            isConnectionPropertiesValidationNeeded = false;
            Options = Connection.Options;
            SubscriptionRuleManager = new ServiceBusSubscriptionRuleManager();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public ServiceBusSender GetSender(string entityName)
        {
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                entityName,
                Connection.ConnectionStringArgumentName);
            }

            return new ServiceBusSender(
                 entityPath: entityName,
                 connection: Connection,
                 options: new ServiceBusSenderOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusSender GetSender(
            string entityName,
            ServiceBusSenderOptions options)
        {
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                entityName,
                Connection.ConnectionStringArgumentName);
            }

            return new ServiceBusSender(
                entityPath: entityName,
                connection: Connection,
                options: options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName)
        {
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                queueName,
                Connection.ConnectionStringArgumentName);
            }

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
            if (isConnectionPropertiesValidationNeeded)
            {
                ValidateConnectionProperties(
                Connection.ConnectionStringProperties,
                topicName,
                Connection.ConnectionStringArgumentName);
            }

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: true,
                sessionId: sessionId,
                options: options ?? new ServiceBusProcessorOptions());
        }

        /// <summary>
        ///   Performs the actions needed to validate the set of properties for connecting to the
        ///   Service Bus service, as passed to this client during creation.
        /// </summary>
        ///
        /// <param name="properties">The set of properties parsed from the connection string associated this client.</param>
        /// <param name="entityName">The name of the entity passed independent of the connection string, allowing easier use of a namespace-level connection string.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <remarks>
        ///   In the case that the properties violate an invariant or otherwise represent a combination that
        ///   is not permissible, an appropriate exception will be thrown.
        /// </remarks>
        ///
        private static void ValidateConnectionProperties(
            ConnectionStringProperties properties,
            string entityName,
            string connectionStringArgumentName)
        {
            // The entity name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
            // value, then do not consider this a failure.

            if ((!string.IsNullOrEmpty(entityName))
                && (!string.IsNullOrEmpty(properties.EntityPath))
                && (!string.Equals(entityName, properties.EntityPath, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException(Resources1.OnlyOneEntityNameMayBeSpecified, connectionStringArgumentName);
            }

            // Ensure that each of the needed components are present for connecting.

            if ((string.IsNullOrEmpty(entityName)) && (string.IsNullOrEmpty(properties.EntityPath))
                || (string.IsNullOrEmpty(properties.Endpoint?.Host))
                || (string.IsNullOrEmpty(properties.SharedAccessKeyName))
                || (string.IsNullOrEmpty(properties.SharedAccessKey)))
            {
                throw new ArgumentException(Resources1.MissingConnectionInformation, connectionStringArgumentName);
            }
        }
    }
}
