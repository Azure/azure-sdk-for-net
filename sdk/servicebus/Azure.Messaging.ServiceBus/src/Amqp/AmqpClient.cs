// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusConnection" /> make use of an instance via containment
    ///   and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportClient" />
    ///
    internal class AmqpClient : TransportClient
    {
        /// <summary>
        ///   The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.
        /// </summary>
        ///
        private static TimeSpan CredentialRefreshBuffer { get; } = TimeSpan.FromMinutes(5);

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed;

        /// <summary>The currently active token to use for authorization with the Service Bus service.</summary>
        private AccessToken _accessToken;

        /// <summary>
        ///   Indicates whether or not this client has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The endpoint for the Service Bus service to which the client is associated.
        /// </summary>
        ///
        public override Uri ServiceEndpoint { get; }

        /// <summary>
        ///   The endpoint for the Service Bus service to be used when establishing the connection.
        /// </summary>
        ///
        public Uri ConnectionEndpoint { get; }

        /// <summary>
        ///   Gets the credential to use for authorization with the Service Bus service.
        /// </summary>
        ///
        private ServiceBusTokenCredential Credential { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///    The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.
        /// </summary>
        private readonly AmqpMessageConverter _messageConverter;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <param name="useTls"><c>true</c> if the client should secure the connection using TLS; otherwise, <c>false</c>.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        internal AmqpClient(
            string host,
            ServiceBusTokenCredential credential,
            ServiceBusClientOptions options,
            bool useTls)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _messageConverter = AmqpMessageConverter.Default;

            ServiceEndpoint = new UriBuilder
            {
                Scheme = options.TransportType.GetUriScheme(useTls),
                Host = host
            }.Uri;

            ConnectionEndpoint = (options.CustomEndpointAddress == null) ? ServiceEndpoint : new UriBuilder
            {
                Scheme = ServiceEndpoint.Scheme,
                Host = options.CustomEndpointAddress.Host,
                Port = options.CustomEndpointAddress.IsDefaultPort ? -1 : options.CustomEndpointAddress.Port
            }.Uri;

            Credential = credential;

            ConnectionScope = new AmqpConnectionScope(
                ServiceEndpoint,
                ConnectionEndpoint,
                credential,
                options.TransportType,
                options.WebProxy,
                options.EnableCrossEntityTransactions,
                options.RetryOptions.TryTimeout,
                options.ConnectionIdleTimeout,
                options.CertificateValidationCallback);
        }

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="ServiceBusMessage" /> to the Service Bus entity.
        /// </summary>
        ///
        /// <param name="entityPath">The entity path to send the message to.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="identifier">The identifier for the sender.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        public override TransportSender CreateSender(
            string entityPath,
            ServiceBusRetryPolicy retryPolicy,
            string identifier)
        {
            Argument.AssertNotDisposed(_closed, nameof(AmqpClient));

            return new AmqpSender
            (
                entityPath,
                ConnectionScope,
                retryPolicy,
                identifier,
                _messageConverter
            );
        }

        /// <summary>
        ///   Creates a receiver strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        /// </summary>
        /// <param name="entityPath">The entity path to receive from.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="identifier">The identifier for the sender.</param>
        /// <param name="sessionId">The session ID to receive messages for.</param>
        /// <param name="isSessionReceiver">Whether or not this is a sessionful receiver link.</param>
        /// <param name="isProcessor">Whether or not the receiver is being created for a processor.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the
        ///     open link operation. Only applicable for session receivers.</param>
        /// <returns>A <see cref="TransportReceiver" /> configured in the requested manner.</returns>
        public override TransportReceiver CreateReceiver(
            string entityPath,
            ServiceBusRetryPolicy retryPolicy,
            ServiceBusReceiveMode receiveMode,
            uint prefetchCount,
            string identifier,
            string sessionId,
            bool isSessionReceiver,
            bool isProcessor,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_closed, nameof(AmqpClient));

            return new AmqpReceiver
            (
                entityPath,
                receiveMode,
                prefetchCount,
                ConnectionScope,
                retryPolicy,
                identifier,
                sessionId,
                isSessionReceiver,
                isProcessor,
                _messageConverter,
                cancellationToken
            );
        }

        /// <summary>
        ///   Creates a rule manager strongly aligned with the active protocol and transport,
        ///   responsible for adding, removing and getting rules from the Service Bus subscription.
        /// </summary>
        ///
        /// <param name="subscriptionPath">The path of the Service Bus subscription to which the rule manager is bound.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="identifier">The identifier for the rule manager.</param>
        ///
        /// <returns>A <see cref="TransportRuleManager"/> configured in the requested manner.</returns>
        public override TransportRuleManager CreateRuleManager(
            string subscriptionPath,
            ServiceBusRetryPolicy retryPolicy,
            string identifier)
        {
            Argument.AssertNotDisposed(_closed, nameof(AmqpClient));

            return new AmqpRuleManager
            (
                subscriptionPath,
                ConnectionScope,
                retryPolicy,
                identifier
            );
        }

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return Task.CompletedTask;
            }

            _closed = true;

            try
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                ConnectionScope?.Dispose();
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                _closed = false;
                throw;
            }
        }

        /// <summary>
        ///   Acquires an access token for authorization with the Service Bus service.
        /// </summary>
        ///
        /// <returns>The token to use for service authorization.</returns>
        ///
        private async Task<string> AcquireAccessTokenAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            AccessToken activeToken = _accessToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // overlapping requests should be within a small window, allow the acquired token to replace the current one without
            // attempting to coordinate or ensure that the most recent is kept.

            if ((string.IsNullOrEmpty(activeToken.Token)) || (activeToken.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                activeToken = await Credential.GetTokenUsingDefaultScopeAsync(cancellationToken).ConfigureAwait(false);

                if ((string.IsNullOrEmpty(activeToken.Token)))
                {
                    throw new AuthenticationException(Resources.CouldNotAcquireAccessToken);
                }

                _accessToken = activeToken;
            }

            return activeToken.Token;
        }

        /// <summary>
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns></returns>
        ///
        private static TimeSpan UseMinimum(TimeSpan firstOption,
                                           TimeSpan secondOption) => (firstOption < secondOption) ? firstOption : secondOption;
    }
}
