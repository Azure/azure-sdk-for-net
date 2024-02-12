// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   <para>A client responsible for reading <see cref="EventData" /> from a specific Event Hub
    ///   as a member of a specific consumer group.</para>
    ///
    ///   <para>A consumer may be exclusive, which asserts ownership over associated partitions for the consumer
    ///   group to ensure that only one consumer from that group is reading the from the partition.
    ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."</para>
    ///
    ///   <para>A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
    ///   group to be actively reading events from a given partition.  These non-exclusive consumers are
    ///   sometimes referred to as "Non-Epoch Consumers."</para>
    /// </summary>
    ///
    /// <remarks>
    ///   The <see cref="EventHubConsumerClient" /> is safe to cache and use for the lifetime of an application, which is the best practice when the application
    ///   reads events regularly or semi-regularly.  The consumer is responsible for ensuring efficient network, CPU, and memory use.  Calling either
    ///   <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> as the application is shutting down will ensure that network resources and other
    ///   unmanaged objects are properly cleaned up.
    /// </remarks>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "Event Hubs are AMQP-based services and don't use ClientOptions functionality")]
    public class EventHubConsumerClient : IAsyncDisposable
    {
        /// <summary>The name of the default consumer group in the Event Hubs service.</summary>
        public const string DefaultConsumerGroupName = "$Default";

        /// <summary>Indicates whether or not the consumer should consider itself invalid when a partition is stolen by another consumer, as determined by the Event Hubs service.</summary>
        private const bool InvalidateConsumerWhenPartitionIsStolen = false;

        /// <summary>The maximum wait time for receiving an event batch for the background publishing operation used for subscriptions.</summary>
        private readonly TimeSpan BackgroundPublishingWaitTime = TimeSpan.FromMilliseconds(250);

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

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
        ///   A unique name used to identify this consumer.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubConsumerClient"/> has been closed.
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
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

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
        ///   The set of active Event Hub transport-specific consumers created by this client for use with
        ///   delegated operations.
        /// </summary>
        ///
        private ConcurrentDictionary<string, TransportConsumer> ActiveConsumers { get; } = new ConcurrentDictionary<string, TransportConsumer>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
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
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string connectionString) : this(consumerGroup, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
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
        public EventHubConsumerClient(string consumerGroup,
                                      string connectionString,
                                      EventHubConsumerClientOptions clientOptions) : this(consumerGroup, connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string connectionString,
                                      string eventHubName) : this(consumerGroup, connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string connectionString,
                                      string eventHubName,
                                      EventHubConsumerClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            clientOptions = clientOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(connectionString, eventHubName, clientOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(clientOptions.Identifier)
                ? Guid.NewGuid().ToString()
                : clientOptions.Identifier;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      AzureNamedKeyCredential credential,
                                      EventHubConsumerClientOptions clientOptions = default) : this(consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The shared access signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      AzureSasCredential credential,
                                      EventHubConsumerClientOptions clientOptions = default) : this(consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubConsumerClientOptions clientOptions = default) : this(consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      EventHubConnection connection,
                                      EventHubConsumerClientOptions clientOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(connection, nameof(connection));

            clientOptions = clientOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = false;
            Connection = connection;
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(clientOptions.Identifier)
                ? Guid.NewGuid().ToString()
                : clientOptions.Identifier;
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
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The credential to use for authorization.  This may be of any type supported by the public constructors.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        private EventHubConsumerClient(string consumerGroup,
                                       string fullyQualifiedNamespace,
                                       string eventHubName,
                                       object credential,
                                       EventHubConsumerClientOptions clientOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new EventHubConsumerClientOptions();

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));

            OwnsConnection = true;
            Connection = EventHubConnection.CreateWithCredential(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();

            Identifier = string.IsNullOrEmpty(clientOptions.Identifier)
                ? Guid.NewGuid().ToString()
                : clientOptions.Identifier;
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
        public virtual async Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            return await Connection.GetPropertiesAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            return await Connection.GetPartitionIdsAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                   CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            return await Connection.GetPartitionPropertiesAsync(partitionId, RetryPolicy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Reads events from the requested partition as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available on the partition, requiring
        ///   cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.  It is recommended to call the overload
        ///   which accepts a set of options for configuring read behavior for scenarios where a more deterministic maximum waiting period is desired.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="startingPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="EventHubConsumerClient"/> is unable to read from the requested Event Hub partition due to another reader having
        ///   asserted exclusive ownership.  In this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso cref="ReadEventsFromPartitionAsync(string, EventPosition, ReadEventOptions, CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId,
                                                                                     EventPosition startingPosition,
                                                                                     CancellationToken cancellationToken = default) => ReadEventsFromPartitionAsync(partitionId, startingPosition, null, cancellationToken);

        /// <summary>
        ///   Reads events from the requested partition as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available on the partition, requiring
        ///   cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.  It is recommended to set the
        ///   <see cref="ReadEventOptions.MaximumWaitTime" /> for scenarios where a more deterministic maximum waiting period is desired.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="startingPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="readOptions">The set of options to use for configuring read behavior; if not specified the defaults will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="EventHubConsumerClient"/> is unable to read from the requested Event Hub partition due to another reader having
        ///   asserted exclusive ownership.  In this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso cref="ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
        ///
        public virtual async IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId,
                                                                                           EventPosition startingPosition,
                                                                                           ReadEventOptions readOptions,
                                                                                           [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            EventHubsEventSource.Log.ReadEventsFromPartitionStart(EventHubName, partitionId);
            readOptions = readOptions?.Clone() ?? new ReadEventOptions();

            var transportConsumer = default(TransportConsumer);
            var partitionContext = default(PartitionContext);
            var emptyPartitionEvent = default(PartitionEvent);
            var closeException = default(Exception);

            try
            {
                // Attempt to initialize the common objects. These will be used during the read and emit operations
                // that follow.  Because catch blocks cannot be used when yielding items, this step is wrapped individual
                // to ensure that any exceptions are logged.

                try
                {
                    transportConsumer = Connection.CreateTransportConsumer(ConsumerGroup, partitionId, Identifier, startingPosition, RetryPolicy, readOptions.TrackLastEnqueuedEventProperties, InvalidateConsumerWhenPartitionIsStolen, readOptions.OwnerLevel, (uint)readOptions.PrefetchCount);
                    partitionContext = new PartitionContext(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, transportConsumer);
                    emptyPartitionEvent = new PartitionEvent(partitionContext, null);
                }
                catch (Exception ex)
                {
                    EventHubsEventSource.Log.ReadEventsFromPartitionError(EventHubName, partitionId, ex.Message);
                    throw;
                }

                // Process items.  Because catch blocks cannot be used when yielding items, ensure that any exceptions during
                // the receive operation are caught in an independent try/catch block.

                var emptyBatch = true;
                var eventBatch = default(IReadOnlyList<EventData>);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        emptyBatch = true;
                        eventBatch = await transportConsumer.ReceiveAsync(readOptions.CacheEventCount, readOptions.MaximumWaitTime, cancellationToken).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        throw;
                    }
                    catch (OperationCanceledException ex)
                    {
                        throw new TaskCanceledException(ex.Message, ex);
                    }
                    catch (Exception ex)
                    {
                        EventHubsEventSource.Log.ReadEventsFromPartitionError(EventHubName, partitionId, ex.Message);
                        throw;
                    }

                    // The batch will be available after the receive operation, regardless of whether there were events
                    // available or not; if there are any events in the set to yield, then mark the batch as non-empty.

                    foreach (var eventData in eventBatch)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        emptyBatch = false;
                        yield return new PartitionEvent(partitionContext, eventData);
                    }

                    // If there were no events received, only emit an empty event if there was a maximum wait time
                    // explicitly requested, otherwise, continue attempting to receive without emitting any value
                    // to the enumerable.

                    if ((emptyBatch) && (readOptions.MaximumWaitTime.HasValue))
                    {
                        yield return emptyPartitionEvent;
                    }
                }
            }
            finally
            {
                if (transportConsumer != null)
                {
                    try
                    {
                        await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        EventHubsEventSource.Log.ReadEventsFromPartitionError(EventHubName, partitionId, ex.Message);
                        closeException = ex;
                    }
                }

                EventHubsEventSource.Log.ReadEventsFromPartitionComplete(EventHubName, partitionId);
            }

            // If an exception was captured when closing the transport consumer, surface it.

            if (closeException != default)
            {
                ExceptionDispatchInfo.Capture(closeException).Throw();
            }

            // If cancellation was requested, then surface the expected exception.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
        }

        /// <summary>
        ///   Reads events from all partitions of the event hub as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available on the partition, requiring
        ///   cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.  It is recommended to set the
        ///   <see cref="ReadEventOptions.MaximumWaitTime" /> for scenarios where a more deterministic maximum waiting period is desired.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   This method is not recommended for production use; the <c>EventProcessorClient</c> should be used for reading events from all partitions in a
        ///   production scenario, as it offers a much more robust experience with higher throughput.
        ///
        ///   It is important to note that this method does not guarantee fairness amongst the partitions during iteration; each of the partitions compete to publish
        ///   events to be read by the enumerator.  Depending on service communication, there may be a clustering of events per partition and/or there may be a noticeable
        ///   bias for a given partition or subset of partitions.
        ///
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="EventHubConsumerClient"/> is unable to read from the Event Hub due to another reader having asserted exclusive ownership. In
        ///   this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
        /// <seealso cref="ReadEventsAsync(ReadEventOptions, CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<PartitionEvent> ReadEventsAsync(CancellationToken cancellationToken = default) => ReadEventsAsync(null, cancellationToken);

        /// <summary>
        ///   Reads events from all partitions of the event hub as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available on the partition, requiring
        ///   cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.  It is recommended to set the
        ///   <see cref="ReadEventOptions.MaximumWaitTime" /> for scenarios where a more deterministic maximum waiting period is desired.
        /// </summary>
        ///
        /// <param name="readOptions">The set of options to use for configuring read behavior; if not specified the defaults will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   This method is not recommended for production use; the <c>EventProcessorClient</c> should be used for reading events from all partitions in a
        ///   production scenario, as it offers a much more robust experience with higher throughput.
        ///
        ///   It is important to note that this method does not guarantee fairness amongst the partitions during iteration; each of the partitions compete to publish
        ///   events to be read by the enumerator.  Depending on service communication, there may be a clustering of events per partition and/or there may be a noticeable
        ///   bias for a given partition or subset of partitions.
        ///
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="EventHubConsumerClient"/> is unable to read from the Event Hub due to another reader having asserted exclusive ownership. In
        ///   this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
        /// <seealso cref="ReadEventsAsync(CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<PartitionEvent> ReadEventsAsync(ReadEventOptions readOptions,
                                                                        CancellationToken cancellationToken = default) => ReadEventsAsync(true, readOptions, cancellationToken);

        /// <summary>
        ///   Reads events from all partitions of the event hub as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available on the partition, requiring
        ///   cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.  It is recommended to set the
        ///   <see cref="ReadEventOptions.MaximumWaitTime" /> for scenarios where a more deterministic maximum waiting period is desired.
        /// </summary>
        ///
        /// <param name="startReadingAtEarliestEvent"><c>true</c> to begin reading at the first events available in each partition; otherwise, reading will begin at the end of each partition seeing only new events as they are published.</param>
        /// <param name="readOptions">The set of options to use for configuring read behavior; if not specified the defaults will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   This method is not recommended for production use; the <c>EventProcessorClient</c> should be used for reading events from all partitions in a
        ///   production scenario, as it offers a much more robust experience with higher throughput.
        ///
        ///   It is important to note that this method does not guarantee fairness amongst the partitions during iteration; each of the partitions competes to publish
        ///   events to be read by the enumerator.  Depending on service communication, there may be a clustering of events per partition and/or there may be a noticeable
        ///   bias for a given partition or subset of partitions.
        ///
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when an <see cref="EventHubConsumerClient"/> is unable to read from the Event Hub due to another reader having asserted exclusive ownership. In
        ///   this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
        /// <seealso cref="ReadEventsAsync(CancellationToken)"/>
        /// <seealso cref="ReadEventsAsync(ReadEventOptions, CancellationToken)"/>
        ///
        public virtual async IAsyncEnumerable<PartitionEvent> ReadEventsAsync(bool startReadingAtEarliestEvent,
                                                                              ReadEventOptions readOptions = default,
                                                                              [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            EventHubsEventSource.Log.ReadAllEventsStart(EventHubName);

            var cancelPublishingAsync = default(Func<Task>);
            var eventChannel = default(Channel<PartitionEvent>);
            var options = readOptions?.Clone() ?? new ReadEventOptions();
            var startingPosition = startReadingAtEarliestEvent ? EventPosition.Earliest : EventPosition.Latest;

            using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, CancellationToken.None);

            try
            {
                // Determine the partitions for the Event Hub and create the shared channel.

                var partitions = await GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);

                var channelSize = options.CacheEventCount * partitions.Length * 2L;
                eventChannel = CreateEventChannel((int)Math.Min(channelSize, int.MaxValue));

                // Start publishing for all partitions.

                var publishingTasks = new Task<Func<Task>>[partitions.Length];

                for (var index = 0; index < partitions.Length; ++index)
                {
                    publishingTasks[index] = PublishPartitionEventsToChannelAsync(partitions[index], startingPosition, options.TrackLastEnqueuedEventProperties, options.CacheEventCount, options.OwnerLevel, (uint)options.PrefetchCount, eventChannel, cancellationSource);
                }

                // Capture the callbacks to cancel publishing for all events.

                var cancelPublishingCallbacks = await Task.WhenAll(publishingTasks).ConfigureAwait(false);
                cancelPublishingAsync = () => Task.WhenAll(cancelPublishingCallbacks.Select(cancelCallback => cancelCallback()));
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ReadAllEventsError(EventHubName, ex.Message);
                cancellationSource?.Cancel();

                if (cancelPublishingAsync != null)
                {
                    await cancelPublishingAsync().ConfigureAwait(false);
                }

                EventHubsEventSource.Log.ReadAllEventsComplete(EventHubName);
                throw;
            }

            // Iterate the events from the channel.

            try
            {
                await foreach (var partitionEvent in eventChannel.Reader.EnumerateChannel(options.MaximumWaitTime, cancellationToken).ConfigureAwait(false))
                {
                    yield return partitionEvent;
                }
            }
            finally
            {
                cancellationSource?.Cancel();
                await cancelPublishingAsync().ConfigureAwait(false);
                EventHubsEventSource.Log.ReadAllEventsComplete(EventHubName);
            }

            // If cancellation was requested, then surface the expected exception.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
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
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (IsClosed)
            {
                return;
            }

            IsClosed = true;
            EventHubsEventSource.Log.ClientCloseStart(nameof(EventHubConsumerClient), EventHubName, Identifier);

            // Attempt to close the active transport consumers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportConsumerException = default(Exception);

            try
            {
                var pendingCloses = new List<Task>();

                foreach (var consumer in ActiveConsumers.Values)
                {
                    pendingCloses.Add(consumer.CloseAsync(CancellationToken.None));
                }

                ActiveConsumers.Clear();
                await Task.WhenAll(pendingCloses).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(nameof(EventHubConsumerClient), EventHubName, Identifier, ex.Message);
                transportConsumerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(nameof(EventHubConsumerClient), EventHubName, Identifier, ex.Message);
                transportConsumerException = null;
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(nameof(EventHubConsumerClient), EventHubName, Identifier);
            }

            // If there was an active exception pending from closing the individual
            // transport consumers, surface it now.

            if (transportConsumerException != default)
            {
                ExceptionDispatchInfo.Capture(transportConsumerException).Throw();
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubConsumerClient" />,
        ///   including ensuring that the client itself has been closed.
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
        ///   Publishes events for the requested <paramref name="partitionId"/> to the provided
        ///   <paramref name="channel" /> in the background, using a dedicated transport consumer
        ///   instance.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition from which events should be read.</param>
        /// <param name="startingPosition">The position within the partition's event stream that reading should begin from.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="receiveBatchSize">The batch size to use when receiving events.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="prefetchCount">The count of events requested eagerly and queued without regard to whether a read was requested.</param>
        /// <param name="channel">The channel to which events should be published.</param>
        /// <param name="publishingCancellationSource">A cancellation source which can be used for signaling publication to stop.</param>
        ///
        /// <returns>A function to invoke when publishing should stop; once complete, background publishing is no longer taking place and the <paramref name="channel"/> has been marked as final.</returns>
        ///
        /// <remarks>
        ///   This method assumes co-ownership of the <paramref name="channel" />, marking its writer as completed
        ///   when publishing is complete or when an exception is encountered.
        /// </remarks>
        ///
        private async Task<Func<Task>> PublishPartitionEventsToChannelAsync(string partitionId,
                                                                            EventPosition startingPosition,
                                                                            bool trackLastEnqueuedEventProperties,
                                                                            int receiveBatchSize,
                                                                            long? ownerLevel,
                                                                            uint prefetchCount,
                                                                            Channel<PartitionEvent> channel,
                                                                            CancellationTokenSource publishingCancellationSource)
        {
            publishingCancellationSource.Token.ThrowIfCancellationRequested<TaskCanceledException>();
            EventHubsEventSource.Log.PublishPartitionEventsToChannelStart(EventHubName, partitionId);

            var transportConsumer = default(TransportConsumer);
            var publishingTask = default(Task);
            var observedException = default(Exception);
            var publisherId = Guid.NewGuid().ToString();

            // Termination must take place in multiple places due to the a catch block being
            // disallowed with the use of "yield return".  Create a local function that encapsulates
            // the cleanup tasks needed.

            async Task performCleanup()
            {
                publishingCancellationSource?.Cancel();

                if (publishingTask != null)
                {
                    try
                    {
                        await publishingTask.ConfigureAwait(false);
                        channel.Writer.TryComplete();
                    }
                    catch (Exception ex) when ((ex is TaskCanceledException) || (ex is ChannelClosedException))
                    {
                        // Due to the non-determinism when requesting cancellation of the background
                        // publishing, it may surface as the expected cancellation or may result in
                        // an attempt to write to the shared channel after another publisher has
                        // marked it as final.
                        //
                        // These are expected scenarios; no action is needed.
                    }
                }

                if (transportConsumer != null)
                {
                    ActiveConsumers.TryRemove(publisherId, out var _);
                    await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }

                try
                {
                    if (observedException != default)
                    {
                        EventHubsEventSource.Log.PublishPartitionEventsToChannelError(EventHubName, partitionId, observedException.Message);
                        ExceptionDispatchInfo.Capture(observedException).Throw();
                    }
                }
                finally
                {
                    EventHubsEventSource.Log.PublishPartitionEventsToChannelComplete(EventHubName, partitionId);
                }
            }

            // Setup the publishing context and begin publishing to the channel in the background.

            try
            {
                transportConsumer = Connection.CreateTransportConsumer(ConsumerGroup, partitionId, Identifier, startingPosition, RetryPolicy, trackLastEnqueuedEventProperties, InvalidateConsumerWhenPartitionIsStolen, ownerLevel, prefetchCount);

                if (!ActiveConsumers.TryAdd(publisherId, transportConsumer))
                {
                    await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                    transportConsumer = null;
                    throw new EventHubsException(false, EventHubName, string.Format(CultureInfo.CurrentCulture, Resources.FailedToCreateReader, EventHubName, partitionId, ConsumerGroup));
                }

                void exceptionCallback(Exception ex)
                {
                    // Ignore the known exception cases that present during cancellation across
                    // background publishing for multiple partitions.

                    if ((ex is ChannelClosedException) || (ex is TaskCanceledException))
                    {
                        return;
                    }

                    observedException = ex;
                }

                publishingTask = StartBackgroundChannelPublishingAsync
                (
                    transportConsumer,
                    channel,
                    new PartitionContext(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, transportConsumer),
                    receiveBatchSize,
                    exceptionCallback,
                    publishingCancellationSource.Token
                );
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.PublishPartitionEventsToChannelError(EventHubName, partitionId, ex.Message);
                await performCleanup().ConfigureAwait(false);

                throw;
            }

            return performCleanup;
        }

        /// <summary>
        ///   Begins the background process responsible for receiving from the specified <see cref="TransportConsumer" />
        ///   and publishing to the requested <see cref="Channel{PartitionEvent}" />.
        /// </summary>
        ///
        /// <param name="transportConsumer">The consumer to use for receiving events.</param>
        /// <param name="channel">The channel to which received events should be published.</param>
        /// <param name="partitionContext">The context that represents the partition from which events being received.</param>
        /// <param name="receiveBatchSize">The batch size to use when receiving events.</param>
        /// <param name="notifyException">An action to be invoked when an exception is encountered during publishing.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the background publishing.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private Task StartBackgroundChannelPublishingAsync(TransportConsumer transportConsumer,
                                                           Channel<PartitionEvent> channel,
                                                           PartitionContext partitionContext,
                                                           int receiveBatchSize,
                                                           Action<Exception> notifyException,
                                                           CancellationToken cancellationToken) =>
            Task.Run(async () =>
            {
                var failedAttemptCount = 0;
                var writtenItems = 0;
                var receivedItems = default(IReadOnlyList<EventData>);
                var retryDelay = default(TimeSpan?);
                var activeException = default(Exception);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        // Receive items in batches and then write them to the subscribed channels.  The channels will naturally
                        // block if they reach their maximum queue size, so there is no need to throttle publishing.

                        if (receivedItems == default)
                        {
                            receivedItems = await transportConsumer.ReceiveAsync(receiveBatchSize, BackgroundPublishingWaitTime, cancellationToken).ConfigureAwait(false);
                        }

                        foreach (EventData item in receivedItems)
                        {
                            await channel.Writer.WriteAsync(new PartitionEvent(partitionContext, item), cancellationToken).ConfigureAwait(false);
                            ++writtenItems;
                        }

                        receivedItems = default;
                        writtenItems = 0;
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
                    catch (OperationCanceledException ex)
                    {
                        activeException = new TaskCanceledException(ex.Message, ex);
                        break;
                    }
                    catch (EventHubsException ex) when
                        (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected
                        || ex.Reason == EventHubsException.FailureReason.ClientClosed)
                    {
                        // If the consumer was disconnected or closed, it is known to be unrecoverable; do not offer the chance to retry.

                        activeException = ex;
                        break;
                    }
                    catch (Exception ex) when (ex.IsFatalException())
                    {
                        channel.Writer.TryComplete(ex);
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
                            // If items were being emitted at the time of the exception, skip to the
                            // last active item that was published to the channel so that publishing
                            // resumes at the next event in sequence and duplicates are not written.

                            if ((receivedItems != default) && (writtenItems > 0))
                            {
                                receivedItems = receivedItems.Skip(writtenItems).ToList();
                            }

                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
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
                    channel.Writer.TryComplete(activeException);
                    notifyException(activeException);
                }
            }, cancellationToken);

        /// <summary>
        ///   Creates a channel for publishing events to local subscribers.
        /// </summary>
        ///
        /// <param name="capacity">The maximum amount of events that can be queued in the channel.</param>
        ///
        /// <returns>A bounded channel, configured for 1:many read/write usage.</returns>
        ///
        private static Channel<PartitionEvent> CreateEventChannel(int capacity) =>
            Channel.CreateBounded<PartitionEvent>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = false,
                SingleReader = true
            });
    }
}
