// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The main point of interaction with Azure Event Hubs, the client offers a
    ///   connection to a specific Event Hub within the Event Hubs namespace and offers operations
    ///   for sending event data, receiving events, and inspecting the connected Event Hub.
    /// </summary>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about" />
    ///
    public class EventHubClient
    {
        /// <summary>
        ///   The path of the specific Event Hub that the client is connected to, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; protected set; }

        /// <summary>
        ///   The credential to use for authorization with the Azure Event Hubs connection.  This credential
        ///   will be validated against the Event Hubs namespace and the requested Event Hub for which operations
        ///   will be performed.
        /// </summary>
        ///
        public TokenCredential Credential { get; protected set; }

        /// <summary>
        ///   The set of client options used for creation of this client.
        /// </summary>
        ///
        protected EventHubClientOptions ClientOptions { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub path and SAS token are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the path to the desired Event Hub,
        ///   which is needed.  In this case, the path can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the path.
        /// </remarks>
        ///
        public EventHubClient(string connectionString)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub path and SAS token are contained in this connection string.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the path to the desired Event Hub,
        ///   which is needed.  In this case, the path can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the path.
        /// </remarks>
        ///
        public EventHubClient(string                connectionString,
                              EventHubClientOptions clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        public EventHubClient(string                  host,
                              string                  eventHubPath,
                              TokenCredential         credential,
                              EventHubClientOptions   clientOptions = default)
        {
            Guard.ArgumentNotNull(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(credential), credential);

            EventHubPath = eventHubPath;
            Credential = credential;
            ClientOptions = clientOptions;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        protected EventHubClient()
        {
        }

        /// <summary>
        ///   Retrieves information about an Event Hub, including the number of partitions present
        ///   and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this client is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonomous with invoking <see cref="GetPropertiesAsync(CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds"/>
        ///   property that is returned. It is offered as a convienience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        public virtual Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

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
        public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string            partitionId,
                                                                             CancellationToken cancellationToken = default) => throw new NotImplementedException();

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
        /// <remarks>
        ///   Allowing automatic routing of partitions is recommended when:
        ///   <para>- The sending of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        public virtual EventSender CreateSender(SenderOptions senderOptions = default)
        {
            //TODO: If no options were reeived, create a new set.  Otherwise, copy them.
            //TODO: If options are missing values that the client should default, set them.

            return new EventSender(ClientOptions.ConnectionType, EventHubPath, senderOptions);
        }

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
        /// <remarks>
        ///   If the starting event position is not specified in the <paramref name="receiverOptions"/>, the receiver will
        ///   default to ignoring events in the partition that were queued prior to the receiver being created and read only
        ///   events which appear after that point.
        /// </remarks>
        ///
        public virtual PartitionReceiver CreatePartitionReceiver(string          partitionId,
                                                                 ReceiverOptions receiverOptions = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);

            //TODO: If no options were received, create a new set.
            //TODO: If options are missing values that the client should default, set them.

            return new PartitionReceiver(ClientOptions.ConnectionType,
                                         EventHubPath,
                                         partitionId,
                                         receiverOptions);
        }

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
    }
}

//TODO: Implement the entire class
