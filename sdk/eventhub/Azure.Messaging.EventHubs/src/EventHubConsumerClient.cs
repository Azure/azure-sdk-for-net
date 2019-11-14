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
        private readonly TimeSpan BackgroundPublishingWaitTime = TimeSpan.FromMilliseconds(250);

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
        ///   Indicates whether or not this <see cref="EventHubConsumerClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The set of options used for creation of this consumer.
        /// </summary>
        ///
        private EventHubConsumerClientOptions Options { get; }

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
        public EventHubConsumerClient(string consumerGroup,
                                      string connectionString) : this(consumerGroup, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
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
                                      string connectionString,
                                      EventHubConsumerClientOptions consumerOptions) : this(consumerGroup, connectionString, null, consumerOptions)
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
                                      string connectionString,
                                      string eventHubName,
                                      EventHubConsumerClientOptions consumerOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(connectionString, eventHubName, consumerOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="consumerOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubConsumerClientOptions consumerOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, consumerOptions.ConnectionOptions);
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumerClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="consumerOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public EventHubConsumerClient(string consumerGroup,
                                      EventHubConnection connection,
                                      EventHubConsumerClientOptions consumerOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(connection, nameof(connection));
            consumerOptions = consumerOptions?.Clone() ?? new EventHubConsumerClientOptions();

            OwnsConnection = false;
            Connection = connection;
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            RetryPolicy = consumerOptions.RetryOptions.ToRetryPolicy();
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
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
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

            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
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
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            return Connection.GetPartitionPropertiesAsync(partitionId, RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Reads events from the requested partition as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This version of the enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available
        ///   on the partition, requiring cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.
        ///   It is recommended to call the overload which accepts a maximum wait time for scenarios where a more deterministic wait period is
        ///   desired.
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
        /// <seealso cref="ReadEventsFromPartitionAsync(string, EventPosition, TimeSpan?, CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId,
                                                                                     EventPosition startingPosition,
                                                                                     CancellationToken cancellationToken = default) => ReadEventsFromPartitionAsync(partitionId, startingPosition, null, cancellationToken);

        /// <summary>
        ///   Reads events from the requested partition as an asynchronous enumerable, allowing events to be iterated as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   If the <paramref name="maximumWaitTime" /> is passed, if no events were available before the wait time elapsed, an empty
        ///   item will be sent in the enumerable in order to return control and ensure that <c>await</c> calls do not block for an
        ///   indeterminate length of time.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="startingPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be published.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Each reader of events is presented with an independent iterator; if there are multiple readers, each receive their own copy of an event to
        ///   process, rather than competing for them.
        /// </remarks>
        ///
        /// <seealso cref="ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
        ///
        public virtual async IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId,
                                                                                           EventPosition startingPosition,
                                                                                           TimeSpan? maximumWaitTime,
                                                                                           [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubConsumerClient));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            EventHubsEventSource.Log.ReadEventsFromPartitionStart(EventHubName, partitionId);

            var cancelPublishingAsync = default(Func<Task>);
            var eventChannel = default(Channel<PartitionEvent>);

            using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            try
            {
                eventChannel = CreateEventChannel(Math.Min((Options.PrefetchCount / 4), (BackgroundPublishReceiveBatchSize * 2)));
                cancelPublishingAsync = await PublishPartitionEventsToChannelAsync(partitionId, startingPosition, eventChannel, cancellationSource).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ReadEventsFromPartitionError(EventHubName, partitionId, ex.Message);
                await cancelPublishingAsync().ConfigureAwait(false);

                EventHubsEventSource.Log.ReadEventsFromPartitionComplete(EventHubName, partitionId);
                throw;
            }

            // Iterate the events from the channel.

            try
            {
                await foreach (var partitionEvent in eventChannel.Reader.EnumerateChannel(maximumWaitTime, cancellationToken).ConfigureAwait(false))
                {
                    yield return partitionEvent;
                }
            }
            finally
            {
                cancellationSource?.Cancel();
                await cancelPublishingAsync().ConfigureAwait(false);
                EventHubsEventSource.Log.ReadEventsFromPartitionComplete(EventHubName, partitionId);
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
            IsClosed = true;

            var clientHash = GetHashCode().ToString();
            EventHubsEventSource.Log.ClientCloseStart(typeof(EventHubConsumerClient), EventHubName, clientHash);

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
                EventHubsEventSource.Log.ClientCloseError(typeof(EventHubConsumerClient), EventHubName, clientHash, ex.Message);
                transportConsumerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(typeof(EventHubConsumerClient), EventHubName, clientHash, ex.Message);
                transportConsumerException = null;
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(typeof(EventHubConsumerClient), EventHubName, clientHash);
            }

            // If there was an active exception pending from closing the individual
            // transport consumers, surface it now.

            if (transportConsumerException != default)
            {
                throw transportConsumerException;
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
        ///   Publishes events for the requested <paramref name="partitionId"/> to the provided
        ///   <paramref name="channel" /> in the background, using a dedicated transport consumer
        ///   instance.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition from which events should be read.</param>
        /// <param name="startingPosition">The position within the partition's event stream that reading should begin from.</param>
        /// <param name="channel">The channel to which events should be published.</param>
        /// <param name="publishingCancellationSource">A cancellation source which can be used for signaling publication to stop.</param>
        ///
        /// <returns>A function to invoke when publishing should stop; once complete, background publishing is no longer taking place and the <paramref name="channel"/> has been marked as final.</returns>
        ///
        /// <remarks>
        ///   This method assumes co-ownership of the <paramref name="channel" />, marking its writer as completed
        ///   when publishing is complete or when an exception is encountered.
        ///
        ///   This method also assumes co-ownership of the <paramref name="publishingCancellationSource" /> and will request cancellation
        ///   from it when publishing is complete or when an exception is encountered.
        /// </remarks>
        ///
        private async Task<Func<Task>> PublishPartitionEventsToChannelAsync(string partitionId,
                                                                            EventPosition startingPosition,
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
                    }
                    catch (TaskCanceledException)
                    {
                        // This is an expected scenario; no action is needed.
                    }
                }

                if (transportConsumer != null)
                {
                    await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                    ActiveConsumers.TryRemove(publisherId, out var _);
                }

                publishingCancellationSource?.Dispose();
                channel.Writer.TryComplete();

                try
                {
                    if (observedException != default)
                    {
                        EventHubsEventSource.Log.PublishPartitionEventsToChannelError(EventHubName, partitionId, observedException.Message);
                        throw observedException;
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
                transportConsumer = Connection.CreateTransportConsumer(ConsumerGroup, partitionId, startingPosition, Options);

                if (!ActiveConsumers.TryAdd(publisherId, transportConsumer))
                {
                    await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                    transportConsumer = null;
                    throw new EventHubsException(false, EventHubName, String.Format(CultureInfo.CurrentCulture, Resources.FailedToCreateReader, EventHubName, partitionId, ConsumerGroup));
                }

                publishingTask = StartBackgroundChannelPublishingAsync
                (
                    transportConsumer,
                    channel,
                    new PartitionContext(partitionId, transportConsumer),
                    ex => { observedException = ex; },
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
        /// <param name="notifyException">An action to be invoked when an exception is encountered during publishing.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the background publishing.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private Task StartBackgroundChannelPublishingAsync(TransportConsumer transportConsumer,
                                                           Channel<PartitionEvent> channel,
                                                           PartitionContext partitionContext,
                                                           Action<Exception> notifyException,
                                                           CancellationToken cancellationToken) =>
            Task.Run(async () =>
            {
                var failedAttemptCount = 0;
                var receivedItems = default(IEnumerable<EventData>);
                var retryDelay = default(TimeSpan?);
                var activeException = default(Exception);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        // Receive items in batches and then write them to the subscribed channels.  The channels will naturally
                        // block if they reach their maximum queue size, so there is no need to throttle publishing.

                        receivedItems = await transportConsumer.ReceiveAsync(BackgroundPublishReceiveBatchSize, BackgroundPublishingWaitTime, cancellationToken).ConfigureAwait(false);

                        foreach (EventData item in receivedItems)
                        {
                            await channel.Writer.WriteAsync(new PartitionEvent(partitionContext, item), cancellationToken).ConfigureAwait(false);
                        }

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
                    catch (Exception ex) when
                        (ex is ConsumerDisconnectedException
                        || ex is EventHubsClientClosedException)
                    {
                        // If the consumer was disconnected or closed, it is known to be unrecoverable; do not offer the chance to retry.

                        activeException = ex;
                        break;
                    }
                    catch (Exception ex) when
                        (ex is OutOfMemoryException
                        || ex is StackOverflowException
                        || ex is ThreadAbortException)
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
        private Channel<PartitionEvent> CreateEventChannel(int capacity) =>
            Channel.CreateBounded<PartitionEvent>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = false,
                SingleReader = true
            });
    }
}
