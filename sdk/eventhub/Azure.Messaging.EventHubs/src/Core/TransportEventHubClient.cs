using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Event Hub client so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="EventHubClient" /> employ
    ///   a transport client via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportEventHubClient
    {
        /// <summary>
        ///   Retrieves information about an Event Hub, including the number of partitions present
        ///   and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public abstract Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken);

        /// <summary>
        ///   Retrieves information about a specific partiton for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public abstract Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                              CancellationToken cancellationToken);

        /// <summary>
        ///   Creates an Event Hub producer responsible for transmitting <see cref="EventData" /> to the
        ///   Event Hub, grouped together in batches.  Depending on the <paramref name="producerOptions"/>
        ///   specified, the producer may be created to allow event data to be automatically routed to an available
        ///   partition or specific to a partition.
        /// </summary>
        ///
        /// <param name="producerOptions">The set of options to apply when creating the producer.</param>
        ///
        /// <returns>An Event Hub producer configured in the requested manner.</returns>
        ///
        public abstract EventHubProducer CreateProducer(EventHubProducerOptions producerOptions);

        /// <summary>
        ///   Creates an Event Hub consumer responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
        ///   and as a member of a specific consumer group.
        ///
        ///   A consumer may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one consumer from that group is reading the from the partition.
        ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
        ///
        ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive consumers are
        ///   sometimes referred to as "Non-epoch Consumers."
        ///
        ///   Designating a consumer as exclusive may be specified in the <paramref name="consumerOptions" />.
        ///   By default, consumers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="consumerOptions">The set of options to apply when creating the consumer.</param>
        ///
        /// <returns>An Event Hub consumer configured in the requested manner.</returns>
        ///
        public abstract EventHubConsumer CreateConsumer(string consumerGroup,
                                                        string partitionId,
                                                        EventPosition eventPosition,
                                                        EventHubConsumerOptions consumerOptions);

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}
