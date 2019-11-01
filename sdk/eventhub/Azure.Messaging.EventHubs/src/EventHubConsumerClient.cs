// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A client responsible for reading <see cref="EventData" /> from a specific Event Hub
    ///   as a member of a specific consumer group.
    ///
    ///   A consumer may be exclusive, which asserts ownership over associated partitions for the consumer
    ///   group to ensure that only one consumer from that group is reading the from the partition.
    ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
    ///
    ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
    ///   group to be actively reading events from a given partition.  These non-exclusive consumers are
    ///   sometimes referred to as "Non-Epoch Consumers."
    /// </summary>
    ///
    public class EventHubConsumerClient : IAsyncDisposable
    {
        /// <summary>The name of the default consumer group in the Event Hubs service.</summary>
        public const string DefaultConsumerGroupName = "$Default";

        /// <summary>The size of event batch requested by the background publishing operation used for subscriptions.</summary>
        private const int BackgroundPublishReceiveBatchSize = 50;

        /// <summary>The maximum wait time for receiving an event batch for the background publishing operation used for subscriptions.</summary>
        private readonly TimeSpan _backgroundPublishingWaitTime = TimeSpan.FromMilliseconds(250);

        /// <summary>The set of channels for publishing events to local subscribers.</summary>
        private readonly ConcurrentDictionary<Guid, Channel<EventData>> _activeChannels = new ConcurrentDictionary<Guid, Channel<EventData>>();

        /// <summary>The primitive for synchronizing access during subscribe and unsubscribe operations.</summary>
        private readonly SemaphoreSlim _channelSyncRoot = new SemaphoreSlim(1, 1);

        /// <summary>Indicates whether events are actively being published to subscribed channels.</summary>
        private bool _isPublishingActive = false;

        /// <summary>The cancellation token to use for requesting to cancel publishing events to the subscribed channels.</summary>
        private CancellationTokenSource _channelPublishingTokenSource;

        /// <summary>The <see cref="Task"/> associated with publishing events to subscribed channels.</summary>
        private Task _channelPublishingTask;

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that the consumer is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName => Connection.EventHubName;

        /// <summary>
        ///   The name of the consumer group that this consumer is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The position of the event in the partition where the consumer should begin reading.
        /// </summary>
        ///
        public EventPosition StartingPosition { get; }

        /// <summary>
        ///   When populated, the priority indicates that a consumer is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this consumer will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive consumer attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger ownership level value will "win."
        ///
        ///   When an exclusive consumer is used, those consumers which are not exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive consumer; for a non-exclusive consumer, this value will be <c>null</c>.</value>
        ///
        public long? OwnerLevel => Options?.OwnerLevel;

        /// <summary>
        ///   The text-based identifier label that has optionally been assigned to the consumer.
        /// </summary>
        ///
        public string Identifier => Options?.Identifier;

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubConsumerClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool Closed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The set of consumer options used for creation of this consumer.
        /// </summary>
        ///
        private EventHubConsumerClientOptions Options { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to transport-aware consumers.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   An abstracted Event Hub consumer specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportConsumer InnerConsumer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
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
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      string connectionString) : this(consumerGroup, partitionId, eventPosition, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="consumerOptions">The set of options to use for this consumer.</param>
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
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      string connectionString,
                                      EventHubConsumerClientOptions consumerOptions) : this(consumerGroup, partitionId, eventPosition, connectionString, null, consumerOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      string connectionString,
                                      string eventHubName) : this(consumerGroup, partitionId, eventPosition, connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="consumerOptions">A set of options to apply when configuring the consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      string connectionString,
                                      string eventHubName,
                                      EventHubConsumerClientOptions consumerOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(eventPosition, nameof(eventPosition));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(connectionString, eventHubName, consumerOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
            InnerConsumer = Connection.CreateTransportConsumer(consumerGroup, partitionId, eventPosition, consumerOptions);

            PartitionId = partitionId;
            StartingPosition = eventPosition;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="consumerOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubConsumerClientOptions consumerOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(eventPosition, nameof(eventPosition));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, consumerOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
            InnerConsumer = Connection.CreateTransportConsumer(consumerGroup, partitionId, eventPosition, consumerOptions);

            PartitionId = partitionId;
            StartingPosition = eventPosition;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="consumerOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string partitionId,
                                      EventPosition eventPosition,
                                      EventHubConnection connection,
                                      EventHubConsumerClientOptions consumerOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(eventPosition, nameof(eventPosition));
            Argument.AssertNotNull(connection, nameof(connection));
            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = false;
            Connection = connection;
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
            InnerConsumer = Connection.CreateTransportConsumer(consumerGroup, partitionId, eventPosition, consumerOptions);

            PartitionId = partitionId;
            StartingPosition = eventPosition;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        protected EventHubConsumerClient()
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///   Retrieves information about the Event Hub that the connection is associated with, including
        ///   the number of partitions present and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(Closed, nameof(EventHubConsumerClient));
            return Connection.GetPropertiesAsync(RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this client is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonymous with invoking <see cref="GetEventHubPropertiesAsync(CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds"/>
        ///   property that is returned. It is offered as a convenience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        public virtual Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default)
        {

            Argument.AssertNotClosed(Closed, nameof(EventHubConsumerClient));
            return Connection.GetPartitionIdsAsync(RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Retrieves information about a specific partition for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                             CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(Closed, nameof(EventHubConsumerClient));
            return Connection.GetPartitionPropertiesAsync(partitionId, RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   A set of information about the last enqueued event of a partition, as observed by the consumer as
        ///   events are received from the Event Hubs service.  This is only available if the consumer was
        ///   created with <see cref="EventHubConsumerClientOptions.TrackLastEnqueuedEventInformation" /> set.
        /// </summary>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using the Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="EventHubConsumerClientOptions.TrackLastEnqueuedEventInformation" /> set.</exception>
        ///
        public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventInformation()
        {
            if (!Options.TrackLastEnqueuedEventInformation)
            {
                throw new InvalidOperationException(Resources.TrackLastEnqueuedEventInformationNotSet);
            }

            return new LastEnqueuedEventProperties(EventHubName, PartitionId, InnerConsumer.LastReceivedEvent);
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified when the consumer was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public virtual Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                 TimeSpan? maximumWaitTime = default,
                                                                 CancellationToken cancellationToken = default)
        {
            maximumWaitTime ??= Options.DefaultMaximumReceiveWaitTime;

            Argument.AssertInRange(maximumMessageCount, 1, int.MaxValue, nameof(maximumMessageCount));
            Argument.AssertNotNegative(maximumWaitTime.Value, nameof(maximumWaitTime));

            return InnerConsumer.ReceiveAsync(maximumMessageCount, maximumWaitTime.Value, cancellationToken);
        }

        /// <summary>
        ///   Subscribes to events for the associated partition in the form of an asynchronous enumerable that sends events as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This version of the enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available
        ///   on the partition, requiring cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.
        ///   It is recommended to call the overload which accepts a maximum wait time for scenarios where a more deterministic wait period is
        ///   desired.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Unlike calls to <see cref="ReceiveAsync"/>, each subscriber to events is presented with an independent iterator; if there are multiple
        ///   subscribers, they will each receive their own copy of an event to process, rather than competing for them.
        ///
        ///   Subscriptions will still compete with <see cref="ReceiveAsync" /> calls, however.  It is recommended that consumers either subscribe to
        ///   events or explicitly receive batches, but do not use both approaches concurrently.
        /// </remarks>
        ///
        /// <seealso cref="SubscribeToEvents(TimeSpan?, CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<EventData> SubscribeToEvents(CancellationToken cancellationToken = default) => SubscribeToEvents(null, cancellationToken);

        /// <summary>
        ///   Subscribes to events for the associated partition in the form of an asynchronous enumerable that sends events as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   If the <paramref name="maximumWaitTime" /> is passed, if no events were available before the wait time elapsed, an empty
        ///   item will be sent in the enumerable in order to return control and ensure that <c>await</c> calls do not block for an
        ///   indeterminate length of time.
        /// </summary>
        ///
        /// <param name="maximumWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be published.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Unlike calls to <see cref="ReceiveAsync"/>, each subscriber to events is presented with an independent iterator; if there are multiple
        ///   subscribers, they will each receive their own copy of an event to process, rather than competing for them.
        ///
        ///   Subscriptions will still compete with <see cref="ReceiveAsync" /> calls, however.  It is recommended that consumers either subscribe to
        ///   events or explicitly receive batches, but do not use both approaches concurrently.
        /// </remarks>
        ///
        /// <seealso cref="SubscribeToEvents(CancellationToken)"/>
        ///
        public virtual async IAsyncEnumerable<EventData> SubscribeToEvents(TimeSpan? maximumWaitTime,
                                                                           [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            EventHubsEventSource.Log.SubscribeToPartitionStart(EventHubName, PartitionId);

            (Guid Identifier, ChannelReader<EventData> ChannelReader) subscription;

            try
            {
                var maximumQueuedEvents = Math.Min((Options.PrefetchCount / 4), (BackgroundPublishReceiveBatchSize * 2));
                subscription = SubscribeToChannel(EventHubName, PartitionId, ConsumerGroup, maximumQueuedEvents, cancellationToken);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.SubscribeToPartitionError(EventHubName, PartitionId, ex.Message);
                throw;
            }

            try
            {
                await foreach (EventData item in subscription.ChannelReader.EnumerateChannel(maximumWaitTime, cancellationToken).ConfigureAwait(false))
                {
                    yield return item;
                }
            }
            finally
            {
                await UnsubscribeFromChannelAsync(subscription.Identifier).ConfigureAwait(false);
                EventHubsEventSource.Log.SubscribeToPartitionComplete(EventHubName, PartitionId);
            }
        }

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            Closed = true;

            try
            {
                await InnerConsumer.CloseAsync(cancellationToken).ConfigureAwait(false);

                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
            {
                Closed = InnerConsumer.Closed;
                throw;
            }
        }

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubConsumerClient" />,
        ///   including ensuring that the client itself has been closed.
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
        ///   Creates a subscription to events being published to the partition associated with
        ///   the consumer.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the event hub with the subscription; used for informational purposes only.</param>
        /// <param name="partitionId">The identifier for the partition to associate with the subscription; used for informational purposes only.</param>
        /// <param name="consumerGroup">The name of the consumer group to associate with the subscription; used for informational purposes only.</param>
        /// <param name="maximumQueuedEvents">The maximum number of events to queue while waiting for them to be read.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the event enumeration.</param>
        ///
        /// <returns>The elements of a channel subscription, including its identifier and a reader for the subscribed channel.</returns>
        ///
        private (Guid Identifier, ChannelReader<EventData> ChannelReader) SubscribeToChannel(string eventHubName,
                                                                                             string partitionId,
                                                                                             string consumerGroup,
                                                                                             int maximumQueuedEvents,
                                                                                             CancellationToken cancellationToken)
        {
            Channel<EventData> channel = CreateEventChannel(maximumQueuedEvents);
            var identifier = Guid.NewGuid();

            if (!_activeChannels.TryAdd(identifier, channel))
            {
                throw new EventHubsException(true, eventHubName, string.Format(CultureInfo.CurrentCulture, Resources.FailedToCreateEventSubscription, eventHubName, partitionId, consumerGroup));
            }

            // Ensure that publishing is taking place.  To avoid race conditions, always acquire the semaphore and then perform the check.

            _channelSyncRoot.Wait(cancellationToken);

            try
            {
                if (!_isPublishingActive)
                {
                    _channelPublishingTokenSource?.Cancel();
                    _channelPublishingTask?.GetAwaiter().GetResult();
                    _channelPublishingTokenSource?.Dispose();

                    _channelPublishingTokenSource = new CancellationTokenSource();
                    _channelPublishingTask = StartBackgroundChannelPublishingAsync(_channelPublishingTokenSource.Token);
                    _isPublishingActive = true;
                }
            }
            finally
            {
                _channelSyncRoot.Release();
            }

            return (identifier, channel.Reader);
        }

        /// <summary>
        ///   Unsubscribe from a channel subscription.
        /// </summary>
        ///
        /// <param name="identifier">The identifier of the subscription to unsubscribe.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task UnsubscribeFromChannelAsync(Guid identifier)
        {
            if ((_activeChannels.TryRemove(identifier, out Channel<EventData> unsubscribeChannel)) && (_activeChannels.Count == 0))
            {
                await _channelSyncRoot.WaitAsync().ConfigureAwait(false);

                try
                {
                    // If the channel was the last active channel and publishing is still marked as active, take
                    // the necessary steps to stop publishing.

                    if ((_isPublishingActive) && (_activeChannels.Count == 0))
                    {
                        _channelPublishingTokenSource?.Cancel();

                        if (_channelPublishingTask != null)
                        {
                            try
                            {
                                await _channelPublishingTask.ConfigureAwait(false);
                            }
                            catch (TaskCanceledException)
                            {
                                // This is an expected scenario; no action is needed.
                            }
                        }

                        _channelPublishingTokenSource?.Dispose();
                        _isPublishingActive = false;
                    }
                }
                finally
                {
                    _channelSyncRoot.Release();
                }
            }

            // Attempt to finalize the channel, signaling that no more writes should be
            // expected to occur.

            unsubscribeChannel?.Writer.TryComplete();
        }

        /// <summary>
        ///   Begins the background process responsible for receiving from the partition
        ///   and publishing to all subscribed channels.
        /// </summary>
        ///
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the background publishing.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private Task StartBackgroundChannelPublishingAsync(CancellationToken cancellationToken) =>
            Task.Run(async () =>
            {
                var failedAttemptCount = 0;
                var publishTasks = new List<Task>();
                var publishChannels = default(ICollection<Channel<EventData>>);
                var receivedItems = default(IEnumerable<EventData>);
                var retryDelay = default(TimeSpan?);
                var activeException = default(Exception);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        // Receive items in batches and then write them to the subscribed channels.  The channels will naturally
                        // block if they reach their maximum queue size, so there is no need to throttle publishing.

                        receivedItems = await InnerConsumer.ReceiveAsync(BackgroundPublishReceiveBatchSize, _backgroundPublishingWaitTime, cancellationToken).ConfigureAwait(false);
                        publishChannels = _activeChannels.Values;

                        foreach (EventData item in receivedItems)
                        {
                            foreach (Channel<EventData> channel in publishChannels)
                            {
                                publishTasks.Add(channel.Writer.WriteAsync(item, cancellationToken).AsTask());
                            }
                        }

                        await Task.WhenAll(publishTasks).ConfigureAwait(false);

                        publishTasks.Clear();
                        failedAttemptCount = 0;
                    }
                    catch (TaskCanceledException ex)
                    {
                        // In the case that a task was canceled, if cancellation was requested, then publishing should
                        // is already terminating.  Otherwise, something unexpected canceled the operation and it should
                        // be treated as an exception to ensure that the channels are marked final and consumers are made
                        // aware.

                        activeException = (cancellationToken.IsCancellationRequested) ? null : ex;
                        break;
                    }
                    catch (ConsumerDisconnectedException ex)
                    {
                        // If the consumer was disconnected, it is known to be unrecoverable; do not offer the chance to retry.

                        activeException = ex;
                        break;
                    }
                    catch (Exception ex) when
                        (ex is OutOfMemoryException
                        || ex is StackOverflowException
                        || ex is ThreadAbortException)
                    {
                        // These exceptions are known to be unrecoverable and there should be no attempts at further processing.
                        // The environment is in a bad state and is likely to fail.
                        //
                        // Attempt to clean up, which may or may not fail due to resource constraints,
                        // then let the exception bubble.

                        _isPublishingActive = false;

                        foreach (Channel<EventData> channel in _activeChannels.Values)
                        {
                            channel.Writer.TryComplete(ex);
                        }

                        throw;
                    }
                    catch (Exception ex)
                    {
                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = RetryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                        if (retryDelay.HasValue)
                        {
                            await Task.Delay(retryDelay.Value).ConfigureAwait(false);
                            activeException = null;
                        }
                        else
                        {
                            activeException = ex;
                            break;
                        }
                    }
                }

                // Publishing has terminated; if there was an active exception, then take the necessary steps to mark publishing as aborted rather
                // than completed normally.

                if (activeException != null)
                {
                    await AbortBackgroundChannelPublishingAsync(activeException).ConfigureAwait(false);
                }

            }, cancellationToken);

        /// <summary>
        ///   Creates a channel for publishing events to local subscribers.
        /// </summary>
        ///
        /// <param name="capacity">The maximum amount of events that can be queued in the channel.</param>
        ///
        /// <returns>A bounded channel, configured for 1:1 read/write usage.</returns>
        ///
        private Channel<EventData> CreateEventChannel(int capacity) =>
            Channel.CreateBounded<EventData>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = true,
                SingleReader = true
            });

        /// <summary>
        ///   Aborts the background channel publishing in the case of an exception that it was
        ///   unable to recover from.
        /// </summary>
        ///
        /// <param name="exception">The exception that triggered publishing to terminate.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task AbortBackgroundChannelPublishingAsync(Exception exception)
        {
            // Though state is normally managed through subscribe and unsubscribe, in the case of aborting,
            // forcefully clear the subscription and reset publishing state.

            await _channelSyncRoot.WaitAsync().ConfigureAwait(false);

            try
            {
                foreach (Channel<EventData> channel in _activeChannels.Values)
                {
                    channel.Writer.TryComplete(exception);
                }

                _activeChannels.Clear();
                _channelPublishingTokenSource.Dispose();
                _isPublishingActive = false;
            }
            finally
            {
                _channelSyncRoot.Release();
            }
        }
    }
}
