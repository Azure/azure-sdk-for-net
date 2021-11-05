// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Amqp;
    using Microsoft.Azure.EventHubs.Primitives;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Anchor class - all EventHub client operations start here.
    /// See <see cref="EventHubClient.CreateFromConnectionString(string)"/>
    /// </summary>
    public abstract class EventHubClient : ClientEntity
    {
        readonly Lazy<EventDataSender> innerSender;
        readonly List<WeakReference> childEntities;
        readonly AsyncLock asyncLock;

        internal EventHubClient(EventHubsConnectionStringBuilder csb)
            : base($"{nameof(EventHubClient)}{ClientEntity.GetNextId()}({csb.EntityPath})")
        {
            this.innerSender = new Lazy<EventDataSender>(() => this.CreateEventSender());
            this.childEntities = new List<WeakReference>();
            this.asyncLock = new AsyncLock();

            this.ConnectionStringBuilder = csb;
            this.EventHubName = csb.EntityPath;
            this.RetryPolicy = RetryPolicy.Default;
        }

        /// <summary>
        /// Gets the name of the EventHub.
        /// </summary>
        public string EventHubName { get; }

        internal EventHubsConnectionStringBuilder ConnectionStringBuilder { get; }

        EventDataSender InnerSender => this.innerSender.Value;

        /// <summary>
        /// Creates a new instance of the Event Hubs client using the specified connection string. You can populate the EntityPath property with the name of the Event Hub.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static EventHubClient CreateFromConnectionString(string connectionString)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(connectionString), connectionString);

            var csb = new EventHubsConnectionStringBuilder(connectionString);

            return Create(csb);
        }

        /// <summary>
        /// Creates a new instance of the Event Hubs client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Event Hub path</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        /// <returns></returns>
        public static EventHubClient CreateWithTokenProvider(
            Uri endpointAddress,
            string entityPath,
            ITokenProvider tokenProvider,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
        {
            Guard.ArgumentNotNull(nameof(endpointAddress), endpointAddress);
            Guard.ArgumentNotNull(nameof(tokenProvider), tokenProvider);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(entityPath), entityPath);

            EventHubsEventSource.Log.EventHubClientCreateStart(endpointAddress.Host, entityPath);
            EventHubClient eventHubClient = new AmqpEventHubClient(
                endpointAddress,
                entityPath,
                tokenProvider,
                operationTimeout ?? ClientConstants.DefaultOperationTimeout,
                transportType);
            EventHubsEventSource.Log.EventHubClientCreateStop(eventHubClient.ClientId);
            return eventHubClient;
        }

        /// <summary>Creates a new instance of the 
        /// <see cref="EventHubClient" /> by using Azure Active Directory authentication.</summary> 
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="path">The path to the Event Hub.</param>
        /// <param name="authCallback">The authentication callback.</param>
        /// <param name="authority">Address of the authority to issue token.</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        /// <returns>The newly created Event Hub client object.</returns>
        public static EventHubClient CreateWithAzureActiveDirectory(
            Uri endpointAddress,
            string path,
            AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback,
            string authority,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
        {
            TokenProvider tokenProvider = TokenProvider.CreateAzureActiveDirectoryTokenProvider(authCallback, authority);

            return CreateWithTokenProvider(
                endpointAddress,
                path,
                tokenProvider,
                operationTimeout,
                transportType);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EventHubClient" /> by using Azure Managed Identity authentication.
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Event Hub path</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        /// <returns></returns>
        public static EventHubClient CreateWithManagedIdentity(
            Uri endpointAddress,
            string entityPath,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
        {
            return CreateWithTokenProvider(
                endpointAddress,
                entityPath,
                TokenProvider.CreateManagedIdentityTokenProvider(),
                operationTimeout,
                transportType);
        }

        /// <summary>
        /// Creates a new instance of the Event Hubs client using the specified connection string builder.
        /// </summary>
        /// <param name="csb"></param>
        /// <returns></returns>
        public static EventHubClient Create(EventHubsConnectionStringBuilder csb)
        {
            Guard.ArgumentNotNull(nameof(csb), csb);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(csb.EntityPath), csb.EntityPath);

            EventHubsEventSource.Log.EventHubClientCreateStart(csb.Endpoint.Host, csb.EntityPath);
            EventHubClient eventHubClient = new AmqpEventHubClient(csb, null);
            EventHubsEventSource.Log.EventHubClientCreateStop(eventHubClient.ClientId);

            return eventHubClient;
        }

        /// <summary>
        /// Closes and releases resources associated with <see cref="EventHubClient"/>.
        /// </summary>
        /// <returns></returns>
        public sealed override async Task CloseAsync()
        {
            this.IsClosed = true;

            EventHubsEventSource.Log.ClientCloseStart(this.ClientId);
            try
            {
                await this.OnCloseAsync().ConfigureAwait(false);

                using (await this.asyncLock.LockAsync().ConfigureAwait(false))
                {
                    foreach (var reference in this.childEntities)
                    {
                        var clientEntity = reference.Target as ClientEntity;
                        if (clientEntity != null)
                        {
                            await clientEntity.CloseAsync().ConfigureAwait(false);
                        }
                    }
                }
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseStop(this.ClientId);
            }
        }

        /// <summary>
        /// Send <see cref="EventData"/> to EventHub. The sent EventData will land on any arbitrarily chosen EventHubs partition.
        /// <para>There are 3 ways to send to EventHubs, each exposed as a method (along with its sendBatch overload):</para>
        /// <para>i.    <see cref="SendAsync(EventData)"/> or <see cref="SendAsync(IEnumerable{EventData})"/></para>
        /// <para>ii.   <see cref="SendAsync(EventData, string)"/> or <see cref="SendAsync(IEnumerable{EventData}, string)"/></para>
        /// <para>iii.  <see cref="PartitionSender.SendAsync(EventData)"/> or <see cref="PartitionSender.SendAsync(IEnumerable{EventData})"/></para>
        /// Use this method to send if:
        /// <para>a) the <see cref="SendAsync(EventData)"/> operation should be highly available and</para>
        /// <para>b) the data needs to be evenly distributed among all partitions; exception being, when a subset of partitions are unavailable</para>
        /// <see cref="SendAsync(EventData)"/> sends the <see cref="EventData"/> to a Service Gateway, which in-turn will forward the EventData to one of the EventHub's partitions.
        /// Here's the message forwarding algorithm:
        /// <para>i.  Forward the EventDatas to EventHub partitions, by equally distributing the data among all partitions (ex: Round-robin the EventDatas to all EventHub partitions) </para>
        /// <para>ii. If one of the EventHub partitions is unavailable for a moment, the Service Gateway will automatically detect it and forward the message to another available partition - making the send operation highly-available.</para>
        /// </summary>
        /// <param name="eventData">the <see cref="EventData"/> to be sent.</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        /// <seealso cref="SendAsync(EventData, string)"/>
        /// <seealso cref="PartitionSender.SendAsync(EventData)"/>
        public Task SendAsync(EventData eventData)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            return this.SendAsync(new[] { eventData }, null);
        }

        /// <summary>
        /// Send a batch of <see cref="EventData"/> to EventHub. The sent EventData will land on any arbitrarily chosen EventHub partition.
        /// This is the most recommended way to send to EventHub.
        ///
        /// <para>There are 3 ways to send to EventHubs, to understand this particular type of send refer to the overload <see cref="SendAsync(EventData)"/>, which is used to send single <see cref="EventData"/>.
        /// Use this overload if you need to send a batch of <see cref="EventData"/>.</para>
        ///
        /// Sending a batch of <see cref="EventData"/>'s is useful in the following cases:
        /// <para>i.    Efficient send - sending a batch of <see cref="EventData"/> maximizes the overall throughput by optimally using the number of sessions created to EventHub's service.</para>
        /// <para>ii.   Send multiple <see cref="EventData"/>'s in a Transaction. To acheieve ACID properties, the Gateway Service will forward all <see cref="EventData"/>'s in the batch to a single EventHub partition.</para>
        /// </summary>
        /// <example>
        /// Sample code:
        /// <code>
        /// var client = EventHubClient.Create("__connectionString__");
        /// while (true)
        /// {
        ///     var events = new List&lt;EventData&gt;();
        ///     for (int count = 1; count &lt; 11; count++)
        ///     {
        ///         var payload = new PayloadEvent(count);
        ///         byte[] payloadBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));
        ///         var sendEvent = new EventData(payloadBytes);
        ///         var applicationProperties = new Dictionary&lt;string, string&gt;();
        ///         applicationProperties["from"] = "csharpClient";
        ///         sendEvent.Properties = applicationProperties;
        ///         events.Add(sendEvent);
        ///     }
        ///
        ///     await client.SendAsync(events);
        ///     Console.WriteLine("Sent Batch... Size: {0}", events.Count);
        /// }
        /// </code>
        /// </example>
        /// <param name="eventDatas">A batch of events to send to EventHub</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        /// <seealso cref="SendAsync(EventData, string)"/>
        /// <seealso cref="PartitionSender.SendAsync(EventData)"/>
        public Task SendAsync(IEnumerable<EventData> eventDatas)
        {
            // eventDatas null is check inside the following call:
            return this.SendAsync(eventDatas, null);
        }

        /// <summary>
        ///  Sends an '<see cref="EventData"/> with a partitionKey to EventHub. All <see cref="EventData"/>'s with a partitionKey are guaranteed to land on the same partition.
        ///  This send pattern emphasize data correlation over general availability and latency.
        ///  <para>There are 3 ways to send to EventHubs, each exposed as a method (along with its batched overload):</para>
        ///  <para>i.   <see cref="SendAsync(EventData)"/> or <see cref="SendAsync(IEnumerable{EventData})"/></para>
        ///  <para>ii.  <see cref="SendAsync(EventData, string)"/> or <see cref="SendAsync(IEnumerable{EventData}, string)"/></para>
        ///  <para>iii. <see cref="PartitionSender.SendAsync(EventData)"/> or <see cref="PartitionSender.SendAsync(IEnumerable{EventData})"/></para>
        ///  Use this type of send if:
        ///  <para>a)  There is a need for correlation of events based on Sender instance; The sender can generate a UniqueId and set it as partitionKey - which on the received Message can be used for correlation</para>
        ///  <para>b) The client wants to take control of distribution of data across partitions.</para>
        ///  Multiple PartitionKeys could be mapped to one Partition. EventHubs service uses a proprietary Hash algorithm to map the PartitionKey to a PartitionId.
        ///  Using this type of send (Sending using a specific partitionKey) could sometimes result in partitions which are not evenly distributed.
        /// </summary>
        /// <param name="eventData">the <see cref="EventData"/> to be sent.</param>
        /// <param name="partitionKey">the partitionKey will be hashed to determine the partitionId to send the EventData to. On the Received message this can be accessed at <see cref="EventData.SystemPropertiesCollection.PartitionKey"/>.</param>
        /// <returns>A Task that completes when the send operation is done.</returns>
        /// <seealso cref="SendAsync(EventData)"/>
        /// <seealso cref="PartitionSender.SendAsync(EventData)"/>
        public Task SendAsync(EventData eventData, string partitionKey)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(partitionKey), partitionKey);

            return this.SendAsync(new[] { eventData }, partitionKey);
        }

        /// <summary>
        /// Send a 'batch of <see cref="EventData"/> with the same partitionKey' to EventHub. All <see cref="EventData"/>'s with a partitionKey are guaranteed to land on the same partition.
        /// Multiple PartitionKey's will be mapped to one Partition.
        /// <para>
        /// There are 3 ways to send to EventHubs, to understand this particular type of send refer to the overload <see cref="SendAsync(EventData, string)"/>,
        /// which is the same type of send and is used to send single <see cref="EventData"/>.
        /// </para>
        /// Sending a batch of <see cref="EventData"/>'s is useful in the following cases:
        /// <para>i.    Efficient send - sending a batch of <see cref="EventData"/> maximizes the overall throughput by optimally using the number of sessions created to EventHubs service.</para>
        /// <para>ii.   Sending multiple events in One Transaction. This is the reason why all events sent in a batch needs to have same partitionKey (so that they are sent to one partition only).</para>
        /// </summary>
        /// <param name="eventDatas">the batch of events to send to EventHub</param>
        /// <param name="partitionKey">the partitionKey will be hashed to determine the partitionId to send the EventData to. On the Received message this can be accessed at <see cref="EventData.SystemPropertiesCollection.PartitionKey"/>.</param>
        /// <returns>A Task that completes when the send operation is done.</returns>
        /// <seealso cref="SendAsync(EventData)"/>
        /// <see cref="PartitionSender.SendAsync(EventData)"/>
        public async Task SendAsync(IEnumerable<EventData> eventDatas, string partitionKey)
        {
            this.ThrowIfClosed();

            var eventDataList = eventDatas?.ToList();

            // eventDatas null check is inside ValidateEvents
            int count = EventDataSender.ValidateEvents(eventDataList);

            EventHubsEventSource.Log.EventSendStart(this.ClientId, count, partitionKey);
            Activity activity = EventHubsDiagnosticSource.StartSendActivity(this.ClientId, this.ConnectionStringBuilder, partitionKey, eventDataList, count);

            Task sendTask = null;
            try
            {
                sendTask = this.InnerSender.SendAsync(eventDataList, partitionKey);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                EventHubsEventSource.Log.EventSendException(this.ClientId, exception.ToString());
                EventHubsDiagnosticSource.FailSendActivity(activity, this.ConnectionStringBuilder, partitionKey, eventDataList, exception);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventSendStop(this.ClientId);
                EventHubsDiagnosticSource.StopSendActivity(activity, this.ConnectionStringBuilder, partitionKey, eventDataList, sendTask);
            }
        }

        /// <summary>
        /// Send a batch of <see cref="EventData"/> in <see cref="EventDataBatch"/>.
        /// </summary>
        /// <param name="eventDataBatch">the batch of events to send to EventHub</param>
        /// <returns>A Task that completes when the send operation is done.</returns>
        public async Task SendAsync(EventDataBatch eventDataBatch)
        {
            if (eventDataBatch == null)
            {
                throw Fx.Exception.Argument(nameof(eventDataBatch), Resources.EventDataListIsNullOrEmpty);
            }

            await this.SendAsync(eventDataBatch.ToEnumerable(), eventDataBatch.PartitionKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a <see cref="PartitionSender"/> which can publish <see cref="EventData"/>'s directly to a specific EventHub partition (sender type iii. in the below list).
        /// <para/>
        /// There are 3 patterns/ways to send to EventHubs:
        /// <para>i.   <see cref="SendAsync(EventData)"/> or <see cref="SendAsync(IEnumerable{EventData})"/></para>
        /// <para>ii.  <see cref="SendAsync(EventData, string)"/> or <see cref="SendAsync(IEnumerable{EventData}, string)"/></para>
        /// <para>iii. <see cref="PartitionSender.SendAsync(EventData)"/> or <see cref="PartitionSender.SendAsync(IEnumerable{EventData})"/></para>
        /// </summary>
        /// <param name="partitionId">partitionId of EventHub to send the <see cref="EventData"/>'s to.</param>
        /// <returns>The created PartitionSender</returns>
        /// <seealso cref="PartitionSender"/>
        public PartitionSender CreatePartitionSender(string partitionId)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(partitionId), partitionId);
            return new PartitionSender(this, partitionId);
        }

        /// <summary>
        /// Create the EventHub receiver with given <see cref="EventPosition"/>.
        /// The receiver is created for a specific EventHub Partition from the specific consumer group.
        /// </summary>
        /// <param name="consumerGroupName">the consumer group name that this receiver should be grouped under.</param>
        /// <param name="partitionId">the partition Id that the receiver belongs to. All data received will be from this partition only.</param>
        /// <param name="eventPosition">The starting <see cref="EventPosition"/> at which to start receiving messages.</param>
        /// <param name="receiverOptions">Options for a event hub receiver.</param>
        /// <returns>The created PartitionReceiver</returns>
        /// <seealso cref="PartitionReceiver"/>
        public PartitionReceiver CreateReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, ReceiverOptions receiverOptions = null)
        {
            Guard.ArgumentNotNull(nameof(eventPosition), eventPosition);
            return this.OnCreateReceiver(consumerGroupName, partitionId, eventPosition, null, receiverOptions);
        }

        /// <summary>
        /// Create a Epoch based EventHub receiver with given <see cref="EventPosition"/>.
        /// The receiver is created for a specific EventHub Partition from the specific consumer group.
        /// <para/>It is important to pay attention to the following when creating epoch based receiver:
        /// <para/>- Ownership enforcement: Once you created an epoch based receiver, you cannot create a non-epoch receiver to the same consumerGroup-Partition combo until all receivers to the combo are closed.
        /// <para/>- Ownership stealing: If a receiver with higher epoch value is created for a consumerGroup-Partition combo, any older epoch receiver to that combo will be force closed.
        /// <para/>- Any receiver closed due to lost of ownership to a consumerGroup-Partition combo will get ReceiverDisconnectedException for all operations from that receiver.
        /// </summary>
        /// <param name="consumerGroupName">the consumer group name that this receiver should be grouped under.</param>
        /// <param name="partitionId">the partition Id that the receiver belongs to. All data received will be from this partition only.</param>
        /// <param name="eventPosition">The starting <see cref="EventPosition"/> at which to start receiving messages.</param>
        /// <param name="epoch">a unique identifier (epoch value) that the service uses, to enforce partition/lease ownership.</param>
        /// <param name="receiverOptions">Options for a event hub receiver.</param>
        /// <returns>The created PartitionReceiver</returns>
        /// <seealso cref="PartitionReceiver"/>
        public PartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions = null)
        {
            Guard.ArgumentNotNull(nameof(eventPosition), eventPosition);
            return this.OnCreateReceiver(consumerGroupName, partitionId, eventPosition, epoch, receiverOptions);
        }

        /// <summary>
        /// Retrieves EventHub runtime information
        /// </summary>
        public async Task<EventHubRuntimeInformation> GetRuntimeInformationAsync()
        {
            this.ThrowIfClosed();

            EventHubsEventSource.Log.GetEventHubRuntimeInformationStart(this.ClientId);

            try
            {
                return await this.OnGetRuntimeInformationAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                EventHubsEventSource.Log.GetEventHubRuntimeInformationException(this.ClientId, e.ToString());
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.GetEventHubRuntimeInformationStop(this.ClientId);
            }
        }

        /// <summary>Retrieves runtime information for the specified partition of the Event Hub.</summary>
        /// <param name="partitionId">The partition ID.</param>
        /// <returns>Returns <see cref="EventHubPartitionRuntimeInformation" />.</returns>
        public async Task<EventHubPartitionRuntimeInformation> GetPartitionRuntimeInformationAsync(string partitionId)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(partitionId), partitionId);
            this.ThrowIfClosed();

            EventHubsEventSource.Log.GetEventHubPartitionRuntimeInformationStart(this.ClientId, partitionId);

            try
            {
                return await this.OnGetPartitionRuntimeInformationAsync(partitionId).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                EventHubsEventSource.Log.GetEventHubPartitionRuntimeInformationException(this.ClientId, partitionId, e.ToString());
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.GetEventHubPartitionRuntimeInformationStop(this.ClientId, partitionId);
            }
        }

        /// <summary>Creates a batch where event data objects can be added for later SendAsync call.</summary>
        /// <returns>Returns <see cref="EventDataBatch" />.</returns>
        public EventDataBatch CreateBatch()
        {
            return this.CreateBatch(new BatchOptions());
        }

        /// <summary>Creates a batch where event data objects can be added for later SendAsync call.</summary>
        /// <param name="options"><see cref="BatchOptions" /> to define partition key and max message size.</param>
        /// <returns>Returns <see cref="EventDataBatch" />.</returns>
        public EventDataBatch CreateBatch(BatchOptions options)
        {
            return new EventDataBatch(options.MaxMessageSize > 0 ?
                options.MaxMessageSize : this.InnerSender.MaxMessageSize, options.PartitionKey);
        }

        /// <summary> Gets or sets a value indicating whether the runtime metric of a receiver is enabled. </summary>
        /// <value> true if a client wants to access <see cref="ReceiverRuntimeInformation"/> using <see cref="PartitionReceiver"/>. </value>
        public bool EnableReceiverRuntimeMetric { get; set; }

        /// <summary>
        /// Gets or sets the web proxy.
        /// A proxy is applicable only when transport type is set to AmqpWebSockets.
        /// If not set, systemwide proxy settings will be honored.
        /// </summary>
        public IWebProxy WebProxy { get; set; }

        internal EventDataSender CreateEventSender(string partitionId = null)
        {
            return this.OnCreateEventSender(partitionId);
        }

        internal abstract EventDataSender OnCreateEventSender(string partitionId);

        /// <summary></summary>
        /// <param name="consumerGroupName"></param>
        /// <param name="partitionId"></param>
        /// <param name="eventPosition"></param>
        /// <param name="epoch"></param>
        /// <param name="receiverOptions"></param>
        /// <returns></returns>
        protected abstract PartitionReceiver OnCreateReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long? epoch, ReceiverOptions receiverOptions);

        /// <summary></summary>
        /// <returns></returns>
        protected abstract Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync();

        /// <summary></summary>
        /// <param name="partitionId"></param>
        /// <returns></returns>
        protected abstract Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId);

        /// <summary></summary>
        /// <returns></returns>
        protected abstract Task OnCloseAsync();

        /// <summary>
        /// Handle retry policy updates here.
        /// </summary>
        protected override void OnRetryPolicyUpdate()
        {
            if (this.innerSender.IsValueCreated)
            {
                this.innerSender.Value.RetryPolicy = this.RetryPolicy.Clone();
            }
        }

        internal void AddChildEntity(ClientEntity clientEntity)
        {
            using (this.asyncLock.LockSync())
            {
                if (!this.IsClosed)
                {
                    this.childEntities.Add(new WeakReference(clientEntity));
                }
            }
        }
    }
}
