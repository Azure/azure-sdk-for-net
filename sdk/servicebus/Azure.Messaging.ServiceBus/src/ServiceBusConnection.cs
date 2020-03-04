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
    internal class ServiceBusConnection : IAsyncDisposable
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
        public bool IsClosed => _innerClient.IsClosed;

        public string EntityName { get; }

        /// <summary>
        ///   The endpoint for the Service Bus service to which the connection is associated.
        ///   This is essentially the <see cref="FullyQualifiedNamespace"/> but with
        ///   the scheme included.
        /// </summary>
        ///
        internal Uri ServiceEndpoint => _innerClient.ServiceEndpoint;

        /// <summary>
        /// The transport type used for this connection.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        private readonly TransportClient _innerClient;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the  name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        internal ServiceBusConnection(
            string connectionString,
            ServiceBusClientOptions connectionOptions = default)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            connectionOptions = connectionOptions?.Clone() ?? new ServiceBusClientOptions();

            ValidateConnectionOptions(connectionOptions);
            var builder = new ServiceBusConnectionStringBuilder(connectionString);

            FullyQualifiedNamespace = builder.FullyQualifiedNamespace;
            TransportType = connectionOptions.TransportType;
            EntityName = builder.EntityName;
            var sharedAccessSignature = new SharedAccessSignature
            (
                 BuildAudienceResource(connectionOptions.TransportType, FullyQualifiedNamespace, EntityName),
                 builder.SasKeyName,
                 builder.SasKey
            );

            var sharedCredentials = new SharedAccessSignatureCredential(sharedAccessSignature);
            var tokenCredentials = new ServiceBusTokenCredential(sharedCredentials, BuildAudienceResource(connectionOptions.TransportType, FullyQualifiedNamespace, EntityName));
            _innerClient = CreateTransportClient(tokenCredentials, connectionOptions);
        }


        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        internal ServiceBusConnection(
                    string fullyQualifiedNamespace,
                    TokenCredential credential,
                    ServiceBusClientOptions connectionOptions = default)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            connectionOptions = connectionOptions?.Clone() ?? new ServiceBusClientOptions();
            ValidateConnectionOptions(connectionOptions);
            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case ServiceBusSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.AsSharedAccessSignatureCredential(BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, EntityName));
                    break;
            }

            var tokenCredential = new ServiceBusTokenCredential(credential, BuildAudienceResource(connectionOptions.TransportType, fullyQualifiedNamespace, EntityName));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            TransportType = connectionOptions.TransportType;

            _innerClient = CreateTransportClient(tokenCredential, connectionOptions);
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
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusConnection), "", FullyQualifiedNamespace);

            try
            {
                await _innerClient.CloseAsync(cancellationToken).ConfigureAwait(false);
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

        internal TransportSender CreateTransportSender(string entityName, ServiceBusRetryPolicy retryPolicy) =>
            _innerClient.CreateSender(entityName, retryPolicy);

        internal TransportReceiver CreateTransportReceiver(
            string entityName,
            ServiceBusRetryPolicy retryPolicy,
            ReceiveMode receiveMode,
            uint prefetchCount,
            string sessionId = default,
            bool isSessionReceiver = default) =>
                _innerClient.CreateReceiver(
                    entityName,
                    retryPolicy,
                    receiveMode,
                    prefetchCount,
                    sessionId,
                    isSessionReceiver);

        ///// <summary>
        /////   Creates a producer strongly aligned with the active protocol and transport,
        /////   responsible for publishing <see cref="ServiceBusMessage" /> to the Service Bus entity.
        ///// </summary>
        ///// <param name="entityName"></param>
        ///// <param name="entityConnectionString"></param>
        /////
        ///// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /////
        ///// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        /////
        //internal virtual TransportSender CreateTransportProducer(
        //    ServiceBusRetryPolicy retryPolicy,
        //    string entityName = default,
        //    string entityConnectionString = default)
        //{
        //    CreateTransportClient(entityName, entityConnectionString, _connectionOptions);
        //    Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

        //    return InnerClient.CreateSender(retryPolicy);
        //}

        ///// <summary>
        /////   Creates a consumer strongly aligned with the active protocol and transport, responsible
        /////   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        ///// </summary>
        /////
        ///// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        ///// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        ///// <param name="sessionId"></param>
        ///// <param name="isSessionReceiver"></param>
        /////
        ///// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        /////
        //internal virtual TransportConsumer CreateTransportConsumer(
        //    ServiceBusRetryPolicy retryPolicy,
        //    ReceiveMode receiveMode = default,
        //    int? prefetchCount = default,
        //    string sessionId = default,
        //    bool isSessionReceiver = default)
        //{
        //    Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
        //    return InnerClient.CreateConsumer(retryPolicy, receiveMode, prefetchCount, sessionId, isSessionReceiver);
        //}

        /// <summary>
        ///   Builds a Service Bus client specific to the protocol and transport specified by the
        ///   requested connection type of the _connectionOptions />.
        /// </summary>
        ///
        /// <param name="credential">The Azure managed identity credential to use for authorization.</param>
        /// <param name="options"></param>
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
        internal virtual TransportClient CreateTransportClient(ServiceBusTokenCredential credential, ServiceBusClientOptions options)
        {
            switch (TransportType)
            {
                case ServiceBusTransportType.AmqpTcp:
                case ServiceBusTransportType.AmqpWebSockets:
                    return new AmqpClient(FullyQualifiedNamespace, credential, options);

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
        ///   Performs the actions needed to validate the <see cref="ServiceBusClientOptions" /> associated
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
        private static void ValidateConnectionOptions(ServiceBusClientOptions connectionOptions)
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
