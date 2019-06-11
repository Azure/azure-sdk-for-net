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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public abstract Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                              CancellationToken cancellationToken);

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}
