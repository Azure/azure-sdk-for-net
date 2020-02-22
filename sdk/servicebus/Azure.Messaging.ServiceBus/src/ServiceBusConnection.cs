// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A connection to the Azure Service Bus service, enabling client communications with a specific
    ///   Service Bus entity instance within an Service Bus namespace.  A single connection may be shared among multiple
    ///   Service Bus entity producers and/or consumers, or may be used as a dedicated connection for a single
    ///   producer or consumer client.
    /// </summary>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/Azure/event-hubs/event-hubs-about" />
    ///
    public class ServiceBusConnection : IAsyncDisposable
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
        public bool IsClosed => InnerClient.IsClosed;

        /// <summary>
        ///   The endpoint for the Service Bus service to which the connection is associated.
        ///   This is essentially the <see cref="FullyQualifiedNamespace"/> but with
        ///   the scheme included.
        /// </summary>
        ///
        internal Uri ServiceEndpoint => InnerClient.ServiceEndpoint;

        /// <summary>
        /// The transport type used for this connection.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        ///   An abstracted Service Bus entity Client specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportClient InnerClient { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusConnection(string connectionString) :
            this(connectionString, null, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusConnection(
            string connectionString,
            ServiceBusConnectionOptions connectionOptions)
            : this(connectionString, null, connectionOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="entityName">The name of the specific entity to associate the connection with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusConnection(
            string connectionString,
            string entityName)
            : this(connectionString, entityName, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the connection with (if not contained in connectionString).</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusConnection(
            string connectionString,
            string entityName,
            ServiceBusConnectionOptions connectionOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            connectionOptions = connectionOptions?.Clone() ?? new ServiceBusConnectionOptions();

            ValidateConnectionOptions(connectionOptions);
            var builder = new ServiceBusConnectionStringBuilder(connectionString);

            var fullyQualifiedNamespace = builder.FullyQualifiedNamespace;

            if (string.IsNullOrEmpty(entityName))
            {
                entityName = builder.EntityName;
            }

            var sharedAccessSignature = new SharedAccessSignature
            (
                 BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, entityName),
                 builder.SasKeyName,
                 builder.SasKey
            );

            var sharedCredentials = new SharedAccessSignatureCredential(sharedAccessSignature);
            var tokenCredentials = new ServiceBusTokenCredential(sharedCredentials, BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, entityName));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EntityName = entityName;
            InnerClient = CreateTransportClient(fullyQualifiedNamespace, entityName, tokenCredentials, connectionOptions);
            TransportType = connectionOptions.TransportType;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the connection with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        public ServiceBusConnection(
            string fullyQualifiedNamespace,
            string entityName,
            TokenCredential credential,
            ServiceBusConnectionOptions connectionOptions = default)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(credential, nameof(credential));

            connectionOptions = connectionOptions?.Clone() ?? new ServiceBusConnectionOptions();
            ValidateConnectionOptions(connectionOptions);

            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case ServiceBusSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.AsSharedAccessSignatureCredential(BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, entityName));
                    break;
            }

            var tokenCredential = new ServiceBusTokenCredential(credential, BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, entityName));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EntityName = entityName;
            TransportType = connectionOptions.TransportType;

            InnerClient = CreateTransportClient(fullyQualifiedNamespace, entityName, tokenCredential, connectionOptions);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        protected ServiceBusConnection()
        {
        }

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
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), EntityName, FullyQualifiedNamespace);

            try
            {
                await InnerClient.CloseAsync(cancellationToken).ConfigureAwait(false);
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
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockTokens"></param>
        /// <param name="timeout"></param>
        /// <param name="dispositionStatus"></param>
        /// <param name="sessionId"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="isSessionReceiver"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        /// <returns></returns>
        internal virtual async Task DisposeMessageRequestResponseAsync(
            Guid[] lockTokens,
            TimeSpan timeout,
            DispositionStatus dispositionStatus,
            bool isSessionReceiver,
            string sessionId = null,
            string receiveLinkName = null,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null) =>
            await InnerClient.DisposeMessageRequestResponseAsync(
                lockTokens,
                timeout,
                dispositionStatus,
                isSessionReceiver,
                sessionId,
                receiveLinkName,
                propertiesToModify,
                deadLetterReason,
                deadLetterDescription).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="timeout"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="sessionId"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual async Task<IEnumerable<ServiceBusMessage>> PeekAsync(
            TimeSpan timeout,
            long? fromSequenceNumber,
            int messageCount = 1,
            string sessionId = null,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default) =>
            await InnerClient.PeekAsync(
                timeout,
                fromSequenceNumber,
                messageCount,
                sessionId,
                receiveLinkName,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="sendLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            ServiceBusRetryPolicy retryPolicy,
            string sendLinkName = null,
            CancellationToken cancellationToken = default) =>
            await InnerClient.ScheduleMessageAsync(message, retryPolicy, sendLinkName, cancellationToken)
            .ConfigureAwait(false);


        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ServiceBusMessage.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        /// <param name="retryPolicy"></param>
        /// <param name="sendLinkName"></param>
        /// <param name="cancellationToken"></param>
        internal async Task CancelScheduledMessageAsync(
            long sequenceNumber,
            ServiceBusRetryPolicy retryPolicy,
            string sendLinkName = null,
            CancellationToken cancellationToken = default) =>
            await InnerClient.CancelScheduledMessageAsync(sequenceNumber, retryPolicy, sendLinkName, cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="ServiceBusMessage" /> to the Service Bus entity.
        /// </summary>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        ///
        internal virtual TransportSender CreateTransportProducer(ServiceBusRetryPolicy retryPolicy)
        {
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
            return InnerClient.CreateSender(retryPolicy);
        }

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        /// </summary>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        ///
        internal virtual TransportConsumer CreateTransportConsumer(
            ServiceBusRetryPolicy retryPolicy,
            ReceiveMode receiveMode = default,
            uint? prefetchCount = default,
            string sessionId = default,
            bool isSessionReceiver = default)
        {
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
            return InnerClient.CreateConsumer(retryPolicy, receiveMode, prefetchCount, sessionId, isSessionReceiver);
        }

        /// <summary>
        ///   Builds a Service Bus client specific to the protocol and transport specified by the
        ///   requested connection type of the <paramref name="options" />.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of a specific Service Bus entity.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.</param>
        /// <param name="options">The set of options to use for the client.</param>
        ///
        /// <returns>A client generalization specific to the specified protocol/transport to which operations may be delegated.</returns>
        ///
        /// <remarks>
        ///   As an internal method, only basic sanity checks are performed against arguments.  It is
        ///   assumed that callers are trusted and have performed deep validation.
        ///
        ///   Parameters passed are also assumed to be owned by thee transport client and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the caller.
        /// </remarks>
        ///
        internal virtual TransportClient CreateTransportClient(
            string fullyQualifiedNamespace,
            string entityName,
            ServiceBusTokenCredential credential,
            ServiceBusConnectionOptions options)
        {
            switch (options.TransportType)
            {
                case ServiceBusTransportType.AmqpTcp:
                case ServiceBusTransportType.AmqpWebSockets:
                    return new AmqpClient(fullyQualifiedNamespace, entityName, credential, options);

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources1.InvalidTransportType, options.TransportType.ToString()), nameof(options.TransportType));
            }
        }

        /// <summary>
        ///   Builds the audience for use in the signature.
        /// </summary>
        ///
        /// <param name="transportType">The type of protocol and transport that will be used for communicating with the Service Bus service.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific entity to connect the client to.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        ///
        private static string BuildAudienceResource(ServiceBusTransportType transportType,
                                                    string fullyQualifiedNamespace,
                                                    string entityName)
        {
            var builder = new UriBuilder(fullyQualifiedNamespace)
            {
                Scheme = transportType.GetUriScheme(),
                Path = entityName,
                Port = -1,
                Fragment = string.Empty,
                Password = string.Empty,
                UserName = string.Empty,
            };

            if (builder.Path.EndsWith("/"))
            {
                builder.Path = builder.Path.TrimEnd('/');
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }

        ///// <summary>
        /////   Performs the actions needed to validate the set of properties for connecting to the
        /////   Service Bus service, as passed to this client during creation.
        ///// </summary>
        /////
        ///// <param name="properties">The set of properties parsed from the connection string associated this client.</param>
        ///// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        /////
        ///// <remarks>
        /////   In the case that the properties violate an invariant or otherwise represent a combination that
        /////   is not permissible, an appropriate exception will be thrown.
        ///// </remarks>
        /////
        //private static void ValidateConnectionProperties(ConnectionStringProperties properties,
        //                                                 string connectionStringArgumentName)
        //{
        //    // The Service Bus entity name may only be specified in one of the possible forms, either as part of the
        //    // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
        //    // value, then do not consider this a failure.

        //    if ((!string.IsNullOrEmpty(properties.EntityName))
        //        && (!string.Equals(properties.EventHubName, StringComparison.InvariantCultureIgnoreCase)))
        //    {
        //        throw new ArgumentException(Resources1.OnlyOneEventHubNameMayBeSpecified, connectionStringArgumentName);
        //    }

        //    // Ensure that each of the needed components are present for connecting.

        //    if (
        //          (string.IsNullOrEmpty(properties.Endpoint?.Host))
        //        || (string.IsNullOrEmpty(properties.SharedAccessKeyName))
        //        || (string.IsNullOrEmpty(properties.SharedAccessKey)))
        //    {
        //        throw new ArgumentException(Resources1.MissingConnectionInformation, connectionStringArgumentName);
        //    }
        //}

        /// <summary>
        ///   Performs the actions needed to validate the <see cref="ServiceBusConnectionOptions" /> associated
        ///   with this client.
        /// </summary>
        ///
        /// <param name="connectionOptions">The set of options to validate.</param>
        ///
        /// <remarks>
        ///   In the case that the options violate an invariant or otherwise represent a combination that
        ///   is not permissible, an appropriate exception will be thrown.
        /// </remarks>
        ///
        private static void ValidateConnectionOptions(ServiceBusConnectionOptions connectionOptions)
        {
            // If there were no options passed, they cannot be in an invalid state.

            if (connectionOptions == null)
            {
                return;
            }

            // A proxy is only valid when web sockets is used as the transport.

            if ((!connectionOptions.TransportType.IsWebSocketTransport()) && (connectionOptions.Proxy != null))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources1.ProxyMustUseWebSockets), nameof(connectionOptions));
            }
        }
    }
}
