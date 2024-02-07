// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A connection to the Azure Event Hubs service, enabling client communications with a specific
    ///   Event Hub instance within an Event Hubs namespace.  A single connection may be shared among multiple
    ///   Event Hub producers and/or consumers, or may be used as a dedicated connection for a single
    ///   producer or consumer client.
    /// </summary>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/Azure/event-hubs/event-hubs-about">About Azure Event Hubs</seealso>
    ///
    public class EventHubConnection : IAsyncDisposable
    {
        /// <summary>
        ///   The default transport type to assume when forming credentials, when no
        ///   transport type was specified.
        /// </summary>
        ///
        private static EventHubsTransportType DefaultCredentialTransportType { get; } = new EventHubConnectionOptions().TransportType;

        /// <summary>
        ///   The default retry policy to use when no explicit retry policy is specified.
        /// </summary>
        ///
        private static EventHubsRetryPolicy DefaultRetryPolicy { get; } = new BasicRetryPolicy(new EventHubsRetryOptions());

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the connection is associated with, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubConnection"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the connection is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed => InnerClient.IsClosed;

        /// <summary>
        ///   The endpoint for the Event Hubs service to which the connection is associated.
        /// </summary>
        ///
        internal Uri ServiceEndpoint => InnerClient.ServiceEndpoint;

        /// <summary>
        ///   The set of client options used for creation of this client.
        /// </summary>
        ///
        private EventHubConnectionOptions Options { get; set; }

        /// <summary>
        ///   An abstracted Event Hub Client specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportClient InnerClient { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventHubConnection(string connectionString) : this(connectionString, null, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventHubConnection(string connectionString,
                                  EventHubConnectionOptions connectionOptions) : this(connectionString, null, connectionOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConnection(string connectionString,
                                  string eventHubName) : this(connectionString, eventHubName, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConnection(string connectionString,
                                  string eventHubName,
                                  EventHubConnectionOptions connectionOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            connectionOptions = connectionOptions?.Clone() ?? new EventHubConnectionOptions();
            ValidateConnectionOptions(connectionOptions);

            var connectionStringProperties = EventHubsConnectionStringProperties.Parse(connectionString);
            connectionStringProperties.Validate(eventHubName, nameof(connectionString));

            var fullyQualifiedNamespace = connectionStringProperties.FullyQualifiedNamespace;

            if (string.IsNullOrEmpty(eventHubName))
            {
                eventHubName = connectionStringProperties.EventHubName;
            }

            SharedAccessSignature sharedAccessSignature;

            if (string.IsNullOrEmpty(connectionStringProperties.SharedAccessSignature))
            {
                sharedAccessSignature = new SharedAccessSignature(
                     BuildConnectionSignatureAuthorizationResource(connectionOptions.TransportType, fullyQualifiedNamespace, eventHubName),
                     connectionStringProperties.SharedAccessKeyName,
                     connectionStringProperties.SharedAccessKey);
            }
            else
            {
                sharedAccessSignature = new SharedAccessSignature(connectionStringProperties.SharedAccessSignature);
            }

            var tokenCredentials = new EventHubTokenCredential(new SharedAccessCredential(sharedAccessSignature));

            // If the emulator is in use, then unset TLS and set the endpoint as a custom endpoint
            // address, unless one was explicitly provided.

            var useTls = true;

            if (connectionStringProperties.UseDevelopmentEmulator)
            {
                useTls = false;
                connectionOptions.CustomEndpointAddress ??= connectionStringProperties.Endpoint;
            }

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            Options = connectionOptions;

#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            InnerClient = CreateTransportClient(fullyQualifiedNamespace, eventHubName, DefaultRetryPolicy.CalculateTryTimeout(0), tokenCredentials, connectionOptions, useTls);
#pragma warning restore CA2214 // Do not call overridable methods in constructors.
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="credential">The <see cref="AzureNamedKeyCredential"/> to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        public EventHubConnection(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  AzureNamedKeyCredential credential,
                                  EventHubConnectionOptions connectionOptions = default) : this(fullyQualifiedNamespace,
                                                                                                eventHubName,
                                                                                                TranslateNamedKeyCredential(credential, fullyQualifiedNamespace, eventHubName, connectionOptions?.TransportType),
                                                                                                connectionOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="credential">The <see cref="AzureSasCredential"/> to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        public EventHubConnection(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  AzureSasCredential credential,
                                  EventHubConnectionOptions connectionOptions = default) : this(fullyQualifiedNamespace,
                                                                                                eventHubName,
                                                                                                new SharedAccessCredential(credential),
                                                                                                connectionOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        public EventHubConnection(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  TokenCredential credential,
                                  EventHubConnectionOptions connectionOptions = default)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            connectionOptions = connectionOptions?.Clone() ?? new EventHubConnectionOptions();
            ValidateConnectionOptions(connectionOptions);

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));

            var tokenCredential = new EventHubTokenCredential(credential);

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            Options = connectionOptions;

#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            InnerClient = CreateTransportClient(fullyQualifiedNamespace, eventHubName, DefaultRetryPolicy.CalculateTryTimeout(0), tokenCredential, connectionOptions);
#pragma warning restore CA2214 // Do not call overridable methods in constructors.
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnection"/> class.
        /// </summary>
        ///
        protected EventHubConnection()
        {
        }

        /// <summary>
        ///   Closes the connection to the Event Hubs namespace and associated Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            EventHubsEventSource.Log.ClientCloseStart(nameof(EventHubConnection), EventHubName, FullyQualifiedNamespace);

            try
            {
                await InnerClient.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(nameof(EventHubConnection), EventHubName, FullyQualifiedNamespace, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(nameof(EventHubConnection), EventHubName, FullyQualifiedNamespace);
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubConnection" />,
        ///   including ensuring that the connection itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

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
        ///   Retrieves information about the Event Hub that the connection is associated with, including
        ///   the number of partitions present and their identifiers.
        /// </summary>
        ///
        /// <param name="retryPolicy">The retry policy to use as the basis for retrieving the information.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this connection is associated with.</returns>
        ///
        internal virtual async Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                           CancellationToken cancellationToken = default) => await InnerClient.GetPropertiesAsync(retryPolicy, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="retryPolicy">The retry policy to use as the basis for retrieving the information.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this connection is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonymous with invoking <see cref="GetPropertiesAsync(EventHubsRetryPolicy, CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds"/>
        ///   property that is returned. It is offered as a convenience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        internal virtual async Task<string[]> GetPartitionIdsAsync(EventHubsRetryPolicy retryPolicy,
                                                                   CancellationToken cancellationToken = default) =>
            (await GetPropertiesAsync(retryPolicy, cancellationToken).ConfigureAwait(false)).PartitionIds;

        /// <summary>
        ///   Retrieves information about a specific partition for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="retryPolicy">The retry policy to use as the basis for retrieving the information.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this connection is associated with.</returns>
        ///
        internal virtual async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                     EventHubsRetryPolicy retryPolicy,
                                                                                     CancellationToken cancellationToken = default) => await InnerClient.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="EventData" /> to the Event Hub.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the transport producer should be bound; if <c>null</c>, the producer is unbound.</param>
        /// <param name="producerIdentifier">The identifier to associate with the consumer; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="requestedFeatures">The flags specifying the set of special transport features that should be opted-into.</param>
        /// <param name="partitionOptions">The set of options, if any, that should be considered when initializing the producer.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportProducer"/> configured in the requested manner.</returns>
        ///
        internal virtual TransportProducer CreateTransportProducer(string partitionId,
                                                                   string producerIdentifier,
                                                                   TransportProducerFeatures requestedFeatures,
                                                                   PartitionPublishingOptions partitionOptions,
                                                                   EventHubsRetryPolicy retryPolicy)
        {
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
            return InnerClient.CreateProducer(partitionId, producerIdentifier, requestedFeatures, partitionOptions, retryPolicy);
        }

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="EventData" /> from a specific Event Hub partition, in the context
        ///   of a specific consumer group.
        ///
        ///   A consumer may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one consumer from that group is reading the from the partition.
        ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
        ///
        ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive consumers are
        ///   sometimes referred to as "Non-epoch Consumers."
        ///
        ///   Designating a consumer as exclusive may be specified by setting the <paramref name="ownerLevel" />.
        ///   When <c>null</c>, consumers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="consumerIdentifier">The identifier to associate with the consumer; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="invalidateConsumerWhenPartitionStolen">Indicates whether or not the consumer should consider itself invalid when a partition is stolen.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="prefetchSizeInBytes">The cache size of the prefetch queue. When set, the link makes a best effort to ensure prefetched messages fit into the specified size.</param>
        ///
        /// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        ///
        internal virtual TransportConsumer CreateTransportConsumer(string consumerGroup,
                                                                   string partitionId,
                                                                   string consumerIdentifier,
                                                                   EventPosition eventPosition,
                                                                   EventHubsRetryPolicy retryPolicy,
                                                                   bool trackLastEnqueuedEventProperties = true,
                                                                   bool invalidateConsumerWhenPartitionStolen = false,
                                                                   long? ownerLevel = default,
                                                                   uint? prefetchCount = default,
                                                                   long? prefetchSizeInBytes = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            return InnerClient.CreateConsumer(consumerGroup, partitionId, consumerIdentifier, eventPosition, retryPolicy, trackLastEnqueuedEventProperties, invalidateConsumerWhenPartitionStolen, ownerLevel, prefetchCount, prefetchSizeInBytes);
        }

        /// <summary>
        ///   Builds an Event Hub client specific to the protocol and transport specified by the
        ///   requested connection type of the <paramref name="options" />.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of a specific Event Hub.</param>
        /// <param name="operationTimeout">The amount of time to allow for an AMQP operation using the link to complete before attempting to cancel it.</param>
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
        [SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "`TransportType` is a reasonable name.  It's the property on the options argument which is invalid.")]
        internal virtual TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                               string eventHubName,
                                                               TimeSpan operationTimeout,
                                                               EventHubTokenCredential credential,
                                                               EventHubConnectionOptions options,
                                                               bool useTls = true)
        {
            switch (options.TransportType)
            {
                case EventHubsTransportType.AmqpTcp:
                case EventHubsTransportType.AmqpWebSockets:
                    return new AmqpClient(fullyQualifiedNamespace, eventHubName, operationTimeout, credential, options, useTls);

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, options.TransportType.ToString()), nameof(options.TransportType));
            }
        }

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> based on the provided options and credential.
        /// </summary>
        ///
        /// <typeparam name="TCredential">The type of credential being used.</typeparam>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
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
        internal static EventHubConnection CreateWithCredential<TCredential>(string fullyQualifiedNamespace,
                                                                             string eventHubName,
                                                                             TCredential credential,
                                                                             EventHubConnectionOptions options) =>
            credential switch
            {
                TokenCredential cred => new EventHubConnection(fullyQualifiedNamespace, eventHubName, cred, options),
                AzureSasCredential cred => new EventHubConnection(fullyQualifiedNamespace, eventHubName, cred, options),
                AzureNamedKeyCredential cred => new EventHubConnection(fullyQualifiedNamespace, eventHubName, cred, options),
                _ => throw new ArgumentException(Resources.UnsupportedCredential, nameof(credential))
            };

        /// <summary>
        ///   Builds the fully-qualified identifier for the connection, for use with signature-based authorization.
        /// </summary>
        ///
        /// <param name="transportType">The type of protocol and transport that will be used for communicating with the Event Hubs service.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        ///
        /// <returns>The value to use as the resource for the signature.</returns>
        ///
        internal static string BuildConnectionSignatureAuthorizationResource(EventHubsTransportType transportType,
                                                                             string fullyQualifiedNamespace,
                                                                             string eventHubName)
        {
            // If there is no namespace or the namespace is not a valid host, there is no basis for a URL and the
            // resource is empty.

            if (string.IsNullOrEmpty(fullyQualifiedNamespace))
            {
                return string.Empty;
            }

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            if (Uri.CheckHostName(fullyQualifiedNamespace) == UriHostNameType.Unknown)
            {
                return string.Empty;
            }

            // Form a normalized URI to identify the resource.

            var builder = new UriBuilder(fullyQualifiedNamespace)
            {
                Scheme = transportType.GetUriScheme(),
                Path = eventHubName,
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
        ///   Translates an <see cref="AzureNamedKeyCredential"/> into the equivalent shared access signature credential.
        /// </summary>
        ///
        /// <param name="credential">The credential to translate.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace being connected to.</param>
        /// <param name="eventHubName">The name of the Event Hub being connected to.</param>
        /// <param name="transportType">The type of transport being used for the connection.</param>
        ///
        /// <returns>The <see cref="SharedAccessCredential" /> which the <paramref name="credential" /> was translated to.</returns>
        ///
        private static SharedAccessCredential TranslateNamedKeyCredential(AzureNamedKeyCredential credential,
                                                                          string fullyQualifiedNamespace,
                                                                          string eventHubName,
                                                                          EventHubsTransportType? transportType) =>
            new SharedAccessCredential(credential, BuildConnectionSignatureAuthorizationResource(transportType ?? DefaultCredentialTransportType, fullyQualifiedNamespace, eventHubName));

        /// <summary>
        ///   Performs the actions needed to validate the <see cref="EventHubConnectionOptions" /> associated
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
        private static void ValidateConnectionOptions(EventHubConnectionOptions connectionOptions)
        {
            // If there were no options passed, they cannot be in an invalid state.

            if (connectionOptions == null)
            {
                return;
            }

            // A proxy is only valid when web sockets is used as the transport.

            if ((!connectionOptions.TransportType.IsWebSocketTransport()) && (connectionOptions.Proxy != null))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ProxyMustUseWebSockets), nameof(connectionOptions));
            }
        }
    }
}
