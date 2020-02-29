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
        ///   The name of the Service Bus entity that the connection is associated with, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName { get; }

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
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), EntityName, FullyQualifiedNamespace);

            try
            {
                await Connection.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusConnection), EntityName, FullyQualifiedNamespace, ex.Message);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusConnection), EntityName, FullyQualifiedNamespace);
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
        /// <param name="nameSpaceConnectionString"></param>
        public ServiceBusClient(string nameSpaceConnectionString)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nameSpaceConnectionString"></param>
        /// <param name="connectionOptions"></param>
        public ServiceBusClient(string nameSpaceConnectionString, ServiceBusClientOptions connectionOptions)
        {
            Connection = new ServiceBusConnection(nameSpaceConnectionString, connectionOptions);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="credential"></param>
        /// <param name="connectionOptions"></param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential, ServiceBusClientOptions connectionOptions)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public ServiceBusSender GetSenderClient(string entityName)
        {
            return new ServiceBusSender(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusSender GetSenderClient(string entityName, ServiceBusReceiverOptions options)
        {
            return new ServiceBusSender(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiverClient(string queueName)
        {
            return new ServiceBusReceiver(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiverClient(string queueName, ServiceBusReceiverOptions options)
        {
            return new ServiceBusReceiver(Connection);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiverClient(string topicName, string subscriptionName)
        {
            return new ServiceBusReceiver(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusReceiver GetReceiverClient(string topicName, string subscriptionName, ServiceBusReceiverOptions options)
        {
            return new ServiceBusReceiver(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessorClient(string queueName)
        {
            return new ServiceBusProcessor(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessorClient(string queueName, ServiceBusProcessorOptions options)
        {
            return new ServiceBusProcessor(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessorClient(string topicName, string subscriptionName)
        {
            return new ServiceBusProcessor(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ServiceBusProcessor GetProcessorClient(string topicName, string subscriptionName, ServiceBusProcessorOptions options)
        {
            return new ServiceBusProcessor(Connection);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusReceiver GetSessionReceiverClient(string queueName)
        {
            return new ServiceBusReceiver(Connection, new ServiceBusReceiverOptions { IsSessionEntity = true });
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusReceiver GetSessionReceiverClient(string queueName, ServiceBusReceiverOptions options = default)
        {
            return new ServiceBusReceiver(Connection, new ServiceBusReceiverOptions { IsSessionEntity = true });
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusReceiver GetSessionReceiverClient(string topicName, string subscriptionName)
        {
            return new ServiceBusReceiver(Connection, new ServiceBusReceiverOptions { IsSessionEntity = true });
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceBusReceiver GetSessionReceiverClient(string topicName, string subscriptionName, string sessionId = default, ServiceBusReceiverOptions options = default)
        {
            return new ServiceBusReceiver(Connection, new ServiceBusReceiverOptions { IsSessionEntity = true });
        }
    }
}
