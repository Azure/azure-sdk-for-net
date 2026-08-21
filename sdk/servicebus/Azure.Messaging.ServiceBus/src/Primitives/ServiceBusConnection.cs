// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A connection to the Azure Service Bus service, enabling client communications with a specific
    ///   Service Bus entity instance within a Service Bus namespace. There is a one-to-one correspondence
    ///   between <see cref="ServiceBusClient"/> and <see cref="ServiceBusConnection"/> instances.
    /// </summary>
    internal class ServiceBusConnection : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the connection is associated with.
        ///   This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusConnection"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the connection is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed => InnerClient.IsClosed;

        /// <summary>
        /// The entity path that the connection is bound to.
        /// </summary>
        public string EntityPath { get; }

        /// <summary>
        ///   The endpoint for the Service Bus service to which the connection is associated.
        ///   This is essentially the <see cref="FullyQualifiedNamespace"/> but with
        ///   the scheme included.
        /// </summary>
        internal Uri ServiceEndpoint => InnerClient.ServiceEndpoint;

        /// <summary>
        /// The transport type used for this connection.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        /// The retry options associated with this connection.
        /// </summary>
        public virtual ServiceBusRetryOptions RetryOptions { get; }

        internal TransportClient InnerClient { get; }

        /// <summary>
        /// Parameterless constructor to allow mocking.
        /// </summary>
        internal ServiceBusConnection() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the  name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        internal ServiceBusConnection(
            string connectionString,
            ServiceBusClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ValidateConnectionOptions(options);

            var connectionStringProperties = ServiceBusConnectionStringProperties.Parse(connectionString);
            ValidateConnectionStringProperties(connectionStringProperties, nameof(connectionString));

            // If the emulator is in use, then unset TLS and set the endpoint as a custom endpoint
            // address, unless one was explicitly provided.

            var useTls = true;

            if (connectionStringProperties.UseDevelopmentEmulator)
            {
                useTls = false;
                options.CustomEndpointAddress ??= connectionStringProperties.Endpoint;
            }

            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            TransportType = options.TransportType;
            EntityPath = connectionStringProperties.EntityPath;
            RetryOptions = options.RetryOptions;

            SharedAccessSignature sharedAccessSignature;

            if (string.IsNullOrEmpty(connectionStringProperties.SharedAccessSignature))
            {
                sharedAccessSignature = new SharedAccessSignature(
                     BuildConnectionResource(options.TransportType, FullyQualifiedNamespace, EntityPath),
                     connectionStringProperties.SharedAccessKeyName,
                     connectionStringProperties.SharedAccessKey);
            }
            else
            {
                sharedAccessSignature = new SharedAccessSignature(connectionStringProperties.SharedAccessSignature);
            }

            var sharedCredential = new SharedAccessCredential(sharedAccessSignature);
            var tokenCredential = new ServiceBusTokenCredential(sharedCredential);
#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            InnerClient = CreateTransportClient(tokenCredential, options, useTls);
#pragma warning restore CA2214 // Do not call overridable methods in constructors
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="AzureNamedKeyCredential"/> credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        internal ServiceBusConnection(
            string fullyQualifiedNamespace,
            AzureNamedKeyCredential credential,
            ServiceBusClientOptions options)
                : this(
                    fullyQualifiedNamespace,
                    TranslateNamedKeyCredential(credential, fullyQualifiedNamespace, null, options.TransportType),
                    options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="AzureSasCredential"/> credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        internal ServiceBusConnection(
            string fullyQualifiedNamespace,
            AzureSasCredential credential,
            ServiceBusClientOptions options)
                : this(
                    fullyQualifiedNamespace,
                    new SharedAccessCredential(credential),
                    options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        internal ServiceBusConnection(
            string fullyQualifiedNamespace,
            TokenCredential credential,
            ServiceBusClientOptions options)
        {
            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));
            ValidateConnectionOptions(options);

            var tokenCredential = new ServiceBusTokenCredential(credential);

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            TransportType = options.TransportType;
            RetryOptions = options.RetryOptions;

#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            InnerClient = CreateTransportClient(tokenCredential, options, useTls: true);
#pragma warning restore CA2214 // Do not call overridable methods in constructors
        }

        /// <summary>
        ///   Closes the connection to the Service Bus namespace and associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default) =>
            await InnerClient.CloseAsync(cancellationToken).ConfigureAwait(false);

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

        internal virtual TransportSender CreateTransportSender(
            string entityPath,
            ServiceBusRetryPolicy retryPolicy,
            string identifier) =>
            InnerClient.CreateSender(entityPath, retryPolicy, identifier);

        internal virtual TransportReceiver CreateTransportReceiver(
            string entityPath,
            ServiceBusRetryPolicy retryPolicy,
            ServiceBusReceiveMode receiveMode,
            uint prefetchCount,
            string identifier,
            string sessionId,
            bool isSessionReceiver,
            bool isProcessor,
            CancellationToken cancellationToken) =>
                InnerClient.CreateReceiver(
                    entityPath,
                    retryPolicy,
                    receiveMode,
                    prefetchCount,
                    identifier,
                    sessionId,
                    isSessionReceiver,
                    isProcessor,
                    cancellationToken);

        internal virtual TransportRuleManager CreateTransportRuleManager(
            string subscriptionPath,
            ServiceBusRetryPolicy retryPolicy,
            string identifier) =>
            InnerClient.CreateRuleManager(subscriptionPath, retryPolicy, identifier);

        /// <summary>
        ///   Builds a Service Bus client specific to the protocol and transport specified by the
        ///   requested connection type of the <see cref="ServiceBusClientOptions"/>.
        /// </summary>
        ///
        /// <param name="credential">The Azure managed identity credential to use for authorization.</param>
        /// <param name="options">The set of options to use for the client.</param>
        /// <param name="useTls"><c>true</c> if the client should secure the connection using TLS; otherwise, <c>false</c>.</param>
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
            ServiceBusTokenCredential credential,
            ServiceBusClientOptions options,
            bool useTls = true)
        {
            switch (TransportType)
            {
                case ServiceBusTransportType.AmqpTcp:
                case ServiceBusTransportType.AmqpWebSockets:
                    return new AmqpClient(FullyQualifiedNamespace, credential, options, useTls);

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, options.TransportType.ToString()), nameof(options));
            }
        }

        /// <summary>
        ///   Builds the audience of the connection for use in the signature.
        /// </summary>
        ///
        /// <param name="transportType">The type of protocol and transport that will be used for communicating with the Service Bus service.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific entity to connect the client to.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        ///
        internal static string BuildConnectionResource(
            ServiceBusTransportType transportType,
            string fullyQualifiedNamespace,
            string entityName)
        {
            // If there is no namespace, there is no basis for a URL and the
            // resource is empty.

            if (string.IsNullOrEmpty(fullyQualifiedNamespace))
            {
                return string.Empty;
            }

            var builder = new UriBuilder(fullyQualifiedNamespace)
            {
                Scheme = transportType.GetUriScheme(),
                Path = entityName,
                Port = -1,
                Fragment = string.Empty,
                Password = string.Empty,
                UserName = string.Empty,
            };

            if (builder.Path.EndsWith("/", StringComparison.Ordinal))
            {
                builder.Path = builder.Path.TrimEnd('/');
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }

        /// <summary>
        /// Throw an ObjectDisposedException if the object is Closing.
        /// </summary>
        internal virtual void ThrowIfClosed() =>
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusConnection));

        /// <summary>
        ///   Creates an <see cref="ServiceBusConnection" /> based on the provided options and credential.
        /// </summary>
        ///
        /// <typeparam name="TCredential">The type of credential being used.</typeparam>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The credential to use for authorization.  This may be of type <see cref="TokenCredential" />, <see cref="AzureSasCredential" />, or <see cref="AzureNamedKeyCredential" />.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        ///
        /// <returns>The connection that was created.</returns>
        ///
        /// <remarks>
        ///   Ownership of the connection is transferred to the caller.  The caller holds responsibility
        ///   for closing the connection and other cleanup activities.
        /// </remarks>
        ///
        internal static ServiceBusConnection CreateWithCredential<TCredential>(
            string fullyQualifiedNamespace,
            TCredential credential,
            ServiceBusClientOptions options) =>
            credential switch
            {
                TokenCredential cred => new ServiceBusConnection(fullyQualifiedNamespace, cred, options),
                AzureSasCredential cred => new ServiceBusConnection(fullyQualifiedNamespace, cred, options),
                AzureNamedKeyCredential cred => new ServiceBusConnection(fullyQualifiedNamespace, cred, options),
                _ => throw new ArgumentException(Resources.UnsupportedCredential, nameof(credential))
            };

        /// <summary>
        ///   Translates an <see cref="AzureNamedKeyCredential"/> into the equivalent shared access signature credential.
        /// </summary>
        ///
        /// <param name="credential">The credential to translate.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace being connected to.</param>
        /// <param name="entityPath">The path of the entity being connected to.</param>
        /// <param name="transportType">The type of transport being used for the connection.</param>
        ///
        /// <returns>The <see cref="SharedAccessCredential" /> which the <paramref name="credential" /> was translated into.</returns>
        ///
        private static SharedAccessCredential TranslateNamedKeyCredential(
            AzureNamedKeyCredential credential,
            string fullyQualifiedNamespace,
            string entityPath,
            ServiceBusTransportType transportType) =>
               new SharedAccessCredential(credential, BuildConnectionResource(transportType, fullyQualifiedNamespace, entityPath));

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

            if ((!connectionOptions.TransportType.IsWebSocketTransport()) && (connectionOptions.WebProxy != null))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ProxyMustUseWebSockets), nameof(connectionOptions));
            }
        }

        /// <summary>
        ///   Performs the actions needed to validate the set of connection string properties for connecting to the
        ///   Service Bus service.
        /// </summary>
        ///
        /// <param name="connectionStringProperties">The set of connection string properties to validate.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <exception cref="ArgumentException">In the case that the properties violate an invariant or otherwise represent a combination that is not permissible, an appropriate exception will be thrown.</exception>
        ///
        private static void ValidateConnectionStringProperties(
            ServiceBusConnectionStringProperties connectionStringProperties,
            string connectionStringArgumentName)
        {
            var hasSharedKey = ((!string.IsNullOrEmpty(connectionStringProperties.SharedAccessKeyName)) && (!string.IsNullOrEmpty(connectionStringProperties.SharedAccessKey)));
            var hasSharedSignature = (!string.IsNullOrEmpty(connectionStringProperties.SharedAccessSignature));

            // Ensure that each of the needed components are present for connecting.

            if ((string.IsNullOrEmpty(connectionStringProperties.Endpoint?.Host))
                || ((!hasSharedKey) && (!hasSharedSignature)))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation, connectionStringArgumentName);
            }

            // The connection string may contain a precomputed shared access signature OR a shared key name and value,
            // but not both.

            if (hasSharedKey && hasSharedSignature)
            {
                throw new ArgumentException(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified, connectionStringArgumentName);
            }
        }
    }
}
