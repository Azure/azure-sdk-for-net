// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

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
        private bool _closed = false;

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
        ///   Initializes a new instance of the <see cref="AmqpClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
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
        public AmqpClient(string host,
                          ServiceBusTokenCredential credential,
                          ServiceBusClientOptions clientOptions) : this(host, credential, clientOptions, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="connectionScope">The optional scope to use for AMQP connection management.  If <c>null</c>, a new scope will be created.</param>
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
        protected AmqpClient(
            string host,
            ServiceBusTokenCredential credential,
            ServiceBusClientOptions clientOptions,
            AmqpConnectionScope connectionScope)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            try
            {
                //TODO add event ServiceBusEventSource.Log.ClientCreateStart(host, entityName);

                ServiceEndpoint = new UriBuilder
                {
                    Scheme = clientOptions.TransportType.GetUriScheme(),
                    Host = host

                }.Uri;

                Credential = credential;
                ConnectionScope = connectionScope ?? new AmqpConnectionScope(ServiceEndpoint, credential, clientOptions.TransportType, clientOptions.Proxy);
            }
            finally
            {
                // TODO add event  ServiceBusEventSource.Log.ServiceBusClientCreateComplete(host, entityName);
            }
        }

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="ServiceBusMessage" /> to the Service Bus entity.
        /// </summary>
        /// <param name="entityName"></param>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        ///
        public override TransportSender CreateSender(string entityName, ServiceBusRetryPolicy retryPolicy)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpSender
            (
                entityName,
                ConnectionScope,
                retryPolicy
            );
        }

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        /// </summary>
        /// <param name="entityName"></param>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <returns>A <see cref="TransportReceiver" /> configured in the requested manner.</returns>
        ///
        public override TransportReceiver CreateReceiver(
            string entityName,
            ServiceBusRetryPolicy retryPolicy,
            ReceiveMode receiveMode,
            uint prefetchCount,
            string sessionId,
            bool isSessionReceiver)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpReceiver
            (
                entityName,
                receiveMode,
                prefetchCount,
                ConnectionScope,
                retryPolicy,
                sessionId,
                isSessionReceiver
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

            var clientId = GetHashCode().ToString();
            var clientType = GetType();

            try
            {
                //ServiceBusEventSource.Log.ClientCloseStart(clientType, EntityName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                ConnectionScope?.Dispose();
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                _closed = false;
                //ServiceBusEventSource.Log.ClientCloseError(clientType, EntityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                //ServiceBusEventSource.Log.ClientCloseComplete(clientType, EntityName, clientId);
            }
        }

        /// <summary>
        ///   Acquires an access token for authorization with the Service Bus service.
        /// </summary>
        ///
        /// <returns>The token to use for service authorization.</returns>
        ///
        private async Task<string> AquireAccessTokenAsync(CancellationToken cancellationToken)
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
                    throw new AuthenticationException(Resources1.CouldNotAcquireAccessToken);
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
