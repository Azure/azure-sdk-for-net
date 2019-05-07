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
        ///   The proxy to use for communication over web sockets.  If not specified,
        ///   the system-wide proxy settings will be honored.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if websockets are not in
        ///   use, any specified proxy will be ignored.
        /// </remarks>
        ///
        public IWebProxy Proxy { get; protected set; }

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
        public EventHubClient(string connectionString)
        {
            EventHubPath = "THIS WOULD BE PARSED FROM THE CONNECTION STRING";

        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub path and SAS token are contained in this connection string.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        public EventHubClient(string                connectionString,
                              EventHubClientOptions clientOptions)
        {
            EventHubPath = "THIS WOULD BE PARSED FROM THE CONNECTION STRING";
            Proxy = clientOptions?.Proxy;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="address">The fully qualified domain name for the Event Hubs namespace.  This is likely to be <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        public EventHubClient(Uri                     address,
                              string                  eventHubPath,
                              TokenCredential         credential,
                              EventHubClientOptions   clientOptions = default)
        {
            Guard.ArgumentNotNull(nameof(address), address);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(credential), credential);

            EventHubPath = eventHubPath;
            Credential = credential;
            Proxy = clientOptions?.Proxy;
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
        /// <returns>The set of information for the Event Hub this client is associated with.</returns>
        ///
        public virtual Task<EventHubInformation> GetEventHubInformationAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(new EventHubInformation("/sample-path", DateTime.UtcNow.AddDays(-5), 3, new[] { "one", "two", "three" }, DateTime.UtcNow));

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
        public virtual Task<PartitionInformation> GetPartitionInformationAsync(string            partitionId,
                                                                               CancellationToken cancellationToken = default) =>
            Task.FromResult(new PartitionInformation("/sample-path", partitionId, 2, 100, "421", DateTime.UtcNow.AddHours(-1.65), false, DateTime.UtcNow));

        /// <summary>
        ///   Creates an event sender responsible for transmitting <see cref="EventData" /> to the
        ///   Event Hub, indendepently or grouped together as a single batch.  For each send request,
        ///   event data may be sent to a specific partition or allowed to be automatically routed to an
        ///   available partition.
        /// </summary>
        ///
        /// <param name="senderOptions">The set of options to apply when creating the sender.</param>
        ///
        /// <returns>An event sender configured in the requested manner.</returns>
        ///
        public virtual EventSender CreateEventSender(SenderOptions senderOptions = default)
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
        /// <param name="beginRecievingAt">The position of the event where the receiver should begin reading events.</param>
        /// <param name="receiverOptions">The set of options to apply when creating the receiver.</param>
        ///
        /// <returns>An event receiver configured in the requested manner.</returns>
        ///
        public virtual PartitionReceiver CreatePartitionReceiver(string          partitionId,
                                                                 EventPosition   beginRecievingAt,
                                                                 ReceiverOptions receiverOptions = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNull(nameof(beginRecievingAt), beginRecievingAt);

            //TODO: If no options were received, create a new set.
            //TODO: If options are missing values that the client should default, set them.

            return new PartitionReceiver(ClientOptions.ConnectionType,
                                         EventHubPath,
                                         partitionId,
                                         beginRecievingAt,
                                         receiverOptions);
        }

        /// <summary>
        ///   Creates an event receiver responsible for reading <see cref="EventData" /> from a specific Event Hub
        ///   across all available partitions, and as a member of a specific consumer group.
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
        /// <param name="beginReceivingAt">The position of the event where the receiver should begin reading events.</param>
        /// <param name="receiverOptions">The set of options to apply when creating the receiver.</param>
        ///
        /// <returns>An event receiver configured in the requested manner.</returns>
        ///
        public virtual EventReceiver CreateEventReceiver(ReceiverCheckpoint beginReceivingAt,
                                                         ReceiverOptions    receiverOptions = default)
        {
            //TODO: This method is not in scope for the June Preview; remove it.

            Guard.ArgumentNotNull(nameof(beginReceivingAt), beginReceivingAt);

            //TODO: If no options were received, create a new set.
            //TODO: If options are missing values that the client should default, set them.

            return new EventReceiver(ClientOptions.ConnectionType,
                                     EventHubPath,
                                     beginReceivingAt,
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
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

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
