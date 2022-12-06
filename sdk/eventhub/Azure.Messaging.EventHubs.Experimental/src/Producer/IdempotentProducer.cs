// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A client responsible for publishing <see cref="EventData" /> to a specific Event Hub,
    ///   grouped together in batches.  Depending on the options specified when sending, events may
    ///   be automatically assigned an available partition or may request a specific partition.
    /// </summary>
    ///
    /// <remarks>
    ///   <list type="bullet">
    ///     <listheader><description>Allowing automatic routing of partitions is recommended when:</description></listheader>
    ///     <item><description>The sending of events needs to be highly available.</description></item>
    ///     <item><description>The event data should be evenly distributed among all available partitions.</description></item>
    ///   </list>
    ///
    ///   <list type="number">
    ///     <listheader><description>If no partition is specified, the following rules are used for automatically selecting one:</description></listheader>
    ///     <item><description>Distribute the events equally amongst all available partitions using a round-robin approach.</description></item>
    ///     <item><description>If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</description></item>
    ///   </list>
    ///
    ///   <para>
    ///     The <see cref="IdempotentProducer" /> is safe to cache and use for the lifetime of an application, and that is best practice when the application
    ///     publishes events regularly or semi-regularly.  The producer holds responsibility for efficient resource management, working to keep resource usage low during
    ///     periods of inactivity and manage health during periods of higher use.  Calling either the <see cref="EventHubProducerClient.CloseAsync" /> or <see cref="EventHubProducerClient.DisposeAsync" />
    ///     method as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.
    ///   </para>
    /// </remarks>
    ///
    public class IdempotentProducer : EventHubProducerClient
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public IdempotentProducer(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public IdempotentProducer(string connectionString,
                                  IdempotentProducerOptions clientOptions) : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public IdempotentProducer(string connectionString,
                                  string eventHubName) : this(connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public IdempotentProducer(string connectionString,
                                  string eventHubName,
                                  IdempotentProducerOptions clientOptions) : base(connectionString, eventHubName, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public IdempotentProducer(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  AzureNamedKeyCredential credential,
                                  IdempotentProducerOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The shared access signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public IdempotentProducer(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  AzureSasCredential credential,
                                  IdempotentProducerOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public IdempotentProducer(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  TokenCredential credential,
                                  IdempotentProducerOptions clientOptions = default): base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public IdempotentProducer(EventHubConnection connection,
                                  IdempotentProducerOptions clientOptions = default) : base(connection, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="IdempotentProducer" /> class.
        /// </summary>
        ///
        protected IdempotentProducer() : base()
        {
        }

        /// <summary>
        ///   A set of information about the state of publishing for a partition, as observed by the <see cref="EventHubProducerClient" />.  This
        ///   data can always be read, but will only be populated with information relevant to the active features for the producer client.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information about the publishing state of the requested partition, within the context of this producer.</returns>
        ///
        /// <remarks>
        ///   The state of a partition is only understood by the <see cref="EventHubProducerClient" /> after events have been published to that
        ///   partition; calling this method for a partition before events have been published to it will return an empty set of properties.
        /// </remarks>
        ///
        public virtual new async Task<PartitionPublishingProperties> GetPartitionPublishingPropertiesAsync(string partitionId,
                                                                                                           CancellationToken cancellationToken = default) =>
            await base.GetPartitionPublishingPropertiesAsync(partitionId, cancellationToken).ConfigureAwait(false);
    }
}
