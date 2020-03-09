// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Allows reading events from a specific partition of an Event Hub, and in the context
    ///   of a specific consumer group, to be read with a greater level of control over
    ///   communication with the Event Hubs service than is offered by other event consumers.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that the <c>EventProcessorClient</c> or <see cref="EventHubConsumerClient" />
    ///   be used for reading and processing events for the majority of scenarios.  The partition receiver is
    ///   intended to enable scenarios with special needs which require more direct control.
    /// </remarks>
    ///
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, ReadEventOptions, CancellationToken)"/>
    ///
    internal class PartitionReceiver
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the receiver should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="options">A set of options to apply when configuring the receiver.</param>
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
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
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the receiver should begin reading events.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the receiver with.</param>
        /// <param name="options">A set of options to apply when configuring the receiver.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string connectionString,
                                 string eventHubName,
                                 PartitionReceiverOptions options = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the receiver should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the receiver with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the receiver.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 TokenCredential credential,
                                 PartitionReceiverOptions options = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the receiver should begin reading events.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="options">A set of options to apply when configuring the receiver.</param>
        ///
        public PartitionReceiver(string consumerGroup,
                                 string partitionId,
                                 EventPosition eventPosition,
                                 EventHubConnection connection,
                                 PartitionReceiverOptions options = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        protected PartitionReceiver()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the receiver should begin reading events.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the receiver with.</param>
        ///
        protected PartitionReceiver(string consumerGroup,
                                    string partitionId,
                                    EventPosition eventPosition,
                                    string fullyQualifiedNamespace,
                                    string eventHubName)
        {
            throw new NotImplementedException();
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
    }
}
