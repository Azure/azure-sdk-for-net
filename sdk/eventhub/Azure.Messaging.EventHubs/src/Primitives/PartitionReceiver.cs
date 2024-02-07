// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Allows reading events from a specific partition of an Event Hub, and in the context
    ///   of a specific consumer group, to be read with a greater level of control over
    ///   communication with the Event Hubs service than is offered by other event consumers.
    /// </summary>
    ///
    /// <remarks>
    ///   <para>It is recommended that the <c>EventProcessorClient</c> or <see cref="EventHubConsumerClient" />
    ///   be used for reading and processing events for the majority of scenarios.  The partition receiver is
    ///   intended to enable scenarios with special needs which require more direct control.</para>
    ///
    ///   <para>The <see cref="PartitionReceiver" /> is safe to cache and use for the lifetime of an application, and which is the best practice when the application
    ///   reads events regularly or semi-regularly.  The receiver is responsible for ensuring efficient network, CPU, and memory use.  Calling either
    ///   <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> as the application is shutting down will ensure that network resources and other unmanaged
    ///   objects are properly cleaned up.</para>
    /// </remarks>
    ///
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, ReadEventOptions, CancellationToken)"/>
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    public class PartitionReceiver : IAsyncDisposable
    {
        /// <summary>Indicates whether or not the consumer should consider itself invalid when a partition is stolen by another consumer, as determined by the Event Hubs service.</summary>
        private const bool InvalidateConsumerWhenPartitionIsStolen = false;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the client is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that the client is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName => Connection.EventHubName;

        /// <summary>
        ///   The name of the consumer group that this client is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this client is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   A unique name used to identify this receiver.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   The position within the partition where the client begins reading events.
        /// </summary>
        ///
        public EventPosition InitialPosition { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="PartitionReceiver"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed
        {
            get => _closed;
            protected set => _closed = value;
        }

        /// <summary>
        ///   The instance of <see cref="EventHubsEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal EventHubsEventSource Logger { get; set; } = EventHubsEventSource.Log;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The default maximum amount of time to wait to build up the requested message count for the batch.
        /// </summary>
        ///
        private TimeSpan? DefaultMaximumWaitTime { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to transport-aware consumers.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The transport consumer that is used for operations performed against
        ///   the Event Hubs service.
        /// </summary>
        ///
        private TransportConsumer InnerConsumer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
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
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string connectionString,
                                 PartitionReceiverOptions options = default) : this(consumerGroup, partitionId, eventPosition, connectionString, null, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the client with.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string connectionString,
                                 string eventHubName,
                                 PartitionReceiverOptions options = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            options = options?.Clone() ?? new PartitionReceiverOptions();

            Connection = new EventHubConnection(connectionString, eventHubName, options.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            InitialPosition = eventPosition;
            DefaultMaximumWaitTime = options.DefaultMaximumReceiveWaitTime;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(options.Identifier)
                ? Guid.NewGuid().ToString()
                : options.Identifier;

            InnerConsumer = Connection.CreateTransportConsumer(
                consumerGroup,
                partitionId,
                Identifier,
                eventPosition,
                RetryPolicy,
                options.TrackLastEnqueuedEventProperties,
                InvalidateConsumerWhenPartitionIsStolen,
                options.OwnerLevel,
                (uint?)options.PrefetchCount,
                options.PrefetchSizeInBytes);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the client with.</param>
        /// <param name="credential">The shared key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 AzureNamedKeyCredential credential,
                                 PartitionReceiverOptions options = default) : this(consumerGroup, partitionId, eventPosition, fullyQualifiedNamespace, eventHubName, (object)credential, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the client with.</param>
        /// <param name="credential">The shared signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 AzureSasCredential credential,
                                 PartitionReceiverOptions options = default) : this(consumerGroup, partitionId, eventPosition, fullyQualifiedNamespace, eventHubName, (object)credential, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the client with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 TokenCredential credential,
                                 PartitionReceiverOptions options = default) : this(consumerGroup, partitionId, eventPosition, fullyQualifiedNamespace, eventHubName, (object)credential, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 EventHubConnection connection,
                                 PartitionReceiverOptions options = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(connection, nameof(connection));

            options = options?.Clone() ?? new PartitionReceiverOptions();

            OwnsConnection = false;
            Connection = connection;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            InitialPosition = eventPosition;
            DefaultMaximumWaitTime = options.DefaultMaximumReceiveWaitTime;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(options.Identifier)
                ? Guid.NewGuid().ToString()
                : options.Identifier;

            InnerConsumer = Connection.CreateTransportConsumer(
                consumerGroup,
                partitionId,
                Identifier,
                eventPosition,
                RetryPolicy,
                options.TrackLastEnqueuedEventProperties,
                InvalidateConsumerWhenPartitionIsStolen,
                options.OwnerLevel,
                (uint?)options.PrefetchCount,
                options.PrefetchSizeInBytes);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this client is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the client should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the client with.</param>
        /// <param name="credential">The credential to use for authorization.  This may be of any type supported by the public constructors.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        ///
        private PartitionReceiver(string consumerGroup,
                                  string partitionId,
                                  EventPosition eventPosition,
                                  string fullyQualifiedNamespace,
                                  string eventHubName,
                                  object credential,
                                  PartitionReceiverOptions options = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options?.Clone() ?? new PartitionReceiverOptions();

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));

            Connection = EventHubConnection.CreateWithCredential(fullyQualifiedNamespace, eventHubName, credential, options.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            InitialPosition = eventPosition;
            DefaultMaximumWaitTime = options.DefaultMaximumReceiveWaitTime;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(options.Identifier)
                ? Guid.NewGuid().ToString()
                : options.Identifier;

            InnerConsumer = Connection.CreateTransportConsumer(
                consumerGroup,
                partitionId,
                Identifier,
                eventPosition,
                RetryPolicy,
                options.TrackLastEnqueuedEventProperties,
                InvalidateConsumerWhenPartitionIsStolen,
                options.OwnerLevel,
                (uint?)options.PrefetchCount,
                options.PrefetchSizeInBytes);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        protected PartitionReceiver()
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///   Retrieves information about the partition this client is associated to, including elements that describe the
        ///   available events in the partition event stream.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the associated partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual async Task<PartitionProperties> GetPartitionPropertiesAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Argument.AssertNotClosed(IsClosed, nameof(PartitionReceiver));
            return await Connection.GetPartitionPropertiesAsync(PartitionId, RetryPolicy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   A set of information about the last enqueued event of the partition associated with this receiver, observed as events
        ///   are received from the Event Hubs service.  This is only available if the receiver was created with <see cref="PartitionReceiverOptions.TrackLastEnqueuedEventProperties" />
        ///   set.  Otherwise, the properties will contain default values.
        /// </summary>
        ///
        /// <returns>The set of properties for the last event that was enqueued to the partition.  If no events were read or tracking was not set, the properties will be returned with default values.</returns>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using an Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">Occurs when the Event Hubs client needed to read this information is no longer available.</exception>
        ///
        public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties()
        {
            Argument.AssertNotClosed(InnerConsumer.IsClosed, Resources.ClientNeededForThisInformationNotAvailable);
            return new LastEnqueuedEventProperties(InnerConsumer.LastReceivedEvent);
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.
        /// </summary>
        ///
        /// <param name="maximumEventCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        /// <remarks>
        ///   When events are available in the prefetch queue, they will be used to form the batch as quickly as possible without waiting for additional events from the
        ///   Event Hubs service to try and meet the requested <paramref name="maximumEventCount" />.  When no events are available in prefetch, the receiver will wait up
        ///   to the duration specified by the <see cref="EventHubsRetryOptions.TryTimeout" /> in the active retry policy for events to be read from the service.  Once any
        ///   events are available, they will be used to form the batch immediately.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="maximumEventCount" /> is less than 1.</exception>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="PartitionReceiver"/> is unable to read from the requested Event Hub partition due to another reader having
        ///   asserted exclusive ownership.  In this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        public virtual async Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumEventCount,
                                                                            CancellationToken cancellationToken = default) =>
            await ReceiveBatchInternalAsync(maximumEventCount, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.
        /// </summary>
        ///
        /// <param name="maximumEventCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait for events to become available, if no events can be read from the prefetch queue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        /// <remarks>
        ///   When events are available in the prefetch queue, they will be used to form the batch as quickly as possible without waiting for additional events from the
        ///   Event Hubs service to try and meet the requested <paramref name="maximumEventCount" />.  When no events are available in prefetch, the receiver will wait up
        ///   to the <paramref name="maximumWaitTime"/> for events to be read from the service.  Once any events are available, they will be used to form the batch immediately.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="maximumEventCount" /> is less than 1.</exception>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="PartitionReceiver"/> is unable to read from the requested Event Hub partition due to another reader having
        ///   asserted exclusive ownership.  In this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        public virtual async Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumEventCount,
                                                                            TimeSpan maximumWaitTime,
                                                                            CancellationToken cancellationToken = default) =>
            await ReceiveBatchInternalAsync(maximumEventCount, maximumWaitTime, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Closes the client.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (IsClosed)
            {
                return;
            }

            IsClosed = true;
            Logger.ClientCloseStart(nameof(PartitionReceiver), EventHubName, Identifier);

            // Attempt to close the transport consumer.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportConsumerException = default(Exception);

            try
            {
                await InnerConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.ClientCloseError(nameof(PartitionReceiver), EventHubName, Identifier, ex.Message);
                transportConsumerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // transport consumer.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Logger.ClientCloseError(nameof(PartitionReceiver), EventHubName, Identifier, ex.Message);
                throw;
            }
            finally
            {
                Logger.ClientCloseComplete(nameof(PartitionReceiver), EventHubName, Identifier);
            }

            // If there was an active exception pending from closing the transport
            // consumer, surface it now.

            if (transportConsumerException != default)
            {
                ExceptionDispatchInfo.Capture(transportConsumerException).Throw();
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="PartitionReceiver" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
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
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.
        /// </summary>
        ///
        /// <param name="maximumEventCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified by the options when the client was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this client is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        private Task<IReadOnlyList<EventData>> ReceiveBatchInternalAsync(int maximumEventCount,
                                                                         TimeSpan? maximumWaitTime,
                                                                         CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            maximumWaitTime ??= DefaultMaximumWaitTime;

            Argument.AssertNotClosed(IsClosed, nameof(PartitionReceiver));
            Argument.AssertInRange(maximumEventCount, 1, int.MaxValue, nameof(maximumEventCount));
            Argument.AssertNotNegative(maximumWaitTime ?? TimeSpan.Zero, nameof(maximumWaitTime));

            return InnerConsumer.ReceiveAsync(maximumEventCount, maximumWaitTime, cancellationToken);
        }
    }
}
