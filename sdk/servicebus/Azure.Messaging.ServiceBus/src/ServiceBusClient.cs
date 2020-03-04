// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
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
        ///   Closes the connection to the Service Bus namespace and associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async virtual Task CloseAsync(CancellationToken cancellationToken = default)
        {
            //cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), "", FullyQualifiedNamespace);

            try
            {
                await Connection.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusConnection), "", FullyQualifiedNamespace, ex.Message);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusConnection), "", FullyQualifiedNamespace);
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
        ///
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
        public ServiceBusClient(string connectionString) // this should contain namespace and credentials, if it contains entity information we would throw
        {
            Connection = new ServiceBusConnection(connectionString, new ServiceBusClientOptions());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="options"></param>
        public ServiceBusClient(string connectionString, ServiceBusClientOptions options)
        {
            Connection = new ServiceBusConnection(connectionString, options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential)
        {
            Connection = new ServiceBusConnection(fullyQualifiedNamespace, credential);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential, ServiceBusClientOptions options)
        {
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
        public ServiceBusSender GetSender(string entityName)
        {
            return new ServiceBusSender(
                Connection,
                new ServiceBusSenderOptions(),
                entityName: entityName);
        }

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
        public ServiceBusSender GetSender(string entityName, ServiceBusSenderOptions options)
        {
            return new ServiceBusSender(
                Connection,
                options,
                entityName: entityName);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName)
        {
            return ServiceBusReceiver.CreateReceiver(
                queueName,
                Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiver(string queueName, ServiceBusReceiverOptions options)
        {
            return ServiceBusReceiver.CreateReceiver(
                queueName,
                Connection,
                options);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetSubscriptionReceiver(string topicName, string subscriptionName)
        {
            return ServiceBusReceiver.CreateReceiver(
                EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetSubscriptionReceiver(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options)
        {
            return ServiceBusReceiver.CreateReceiver(
                EntityNameFormatter.FormatSubscriptionPath(
                    topicName,
                    subscriptionName),
                Connection,
                options);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessor(string queueName)
        {
            return new ServiceBusProcessor(Connection, queueName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetSubscriptionProcessor(string topicName, string subscriptionName)
        {
            return new ServiceBusProcessor(
                Connection,
                EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSessionReceiverAsync(
            string queueName,
            string sessionId = default,
            ServiceBusReceiverOptions options = default,
            CancellationToken cancellationToken = default) =>
            await ServiceBusReceiver.CreateSessionReceiverAsync(
                queueName,
                Connection,
                sessionId,
                options,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceiver> GetSubscriptionSessionReceiverAsync(
            string subscriptionName,
            string topicName,
            string sessionId = default,
            ServiceBusReceiverOptions options = default,
            CancellationToken cancellationToken = default) =>
            await ServiceBusReceiver.CreateSessionReceiverAsync(
                EntityNameFormatter.FormatSubscriptionPath(
                    topicName,
                    subscriptionName),
                Connection,
                sessionId,
                options,
                cancellationToken).ConfigureAwait(false);
    }
}
