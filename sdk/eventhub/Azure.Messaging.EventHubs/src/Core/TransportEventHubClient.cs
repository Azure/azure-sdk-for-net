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
        ///   Creates an event sender responsible for transmitting <see cref="EventData" /> to the
        ///   Event Hub, grouped together in batches.  Depending on the <paramref name="senderOptions"/>
        ///   specified, the sender may be created to allow event data to be automatically routed to an available
        ///   partition or specific to a partition.
        /// </summary>
        ///
        /// <param name="senderOptions">The set of options to apply when creating the sender.</param>
        ///
        /// <returns>An event sender configured in the requested manner.</returns>
        ///
        public abstract EventSender CreateSender(EventSenderOptions senderOptions);

        /// <summary>
        ///   Creates an event receiver responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
        ///   and as a member of a specific consumer group.
        ///
        ///   A receiver may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one receiver from that group is reading the from the partition.
        ///   These exclusive receivers are sometimes referred to as "Epoch Receivers."
        ///
        ///   A receiver may also be non-exclusive, allowing multiple receivers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive receivers are
        ///   sometimes referred to as "Non-epoch Receivers."
        ///
        ///   Designating a receiver as exclusive may be specified in the <paramref name="receiverOptions" />.
        ///   By default, receivers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="receiverOptions">The set of options to apply when creating the receiver.</param>
        ///
        /// <returns>An event receiver configured in the requested manner.</returns>
        ///
        public abstract EventReceiver CreateReceiver(string partitionId,
                                                     EventReceiverOptions receiverOptions);

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}
