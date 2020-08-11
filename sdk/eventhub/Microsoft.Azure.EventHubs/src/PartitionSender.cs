// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;

    /// <summary>
    /// This sender class is a logical representation of sending events to a specific EventHub partition. Do not use this class
    /// if you do not care about sending events to specific partitions, instead use <see cref="EventHubClient.SendAsync(EventData)"/>.
    /// </summary>
    /// <seealso cref="EventHubClient.CreatePartitionSender(string)"/>
    /// <seealso cref="EventHubClient.CreateFromConnectionString(string)"/>
    public sealed class PartitionSender : ClientEntity
    {
        internal PartitionSender(EventHubClient eventHubClient, string partitionId)
            : base($"{nameof(PartitionSender)}{ClientEntity.GetNextId()}({eventHubClient.EventHubName},{partitionId})")
        {
            this.EventHubClient = eventHubClient;
            this.PartitionId = partitionId;
            this.InnerSender = eventHubClient.CreateEventSender(partitionId);
            eventHubClient.AddChildEntity(this);
            EventHubsEventSource.Log.ClientCreated(this.ClientId, null);
        }

        /// <summary>
        /// Gets the <see cref="EventHubClient"/> associated with this PartitionSender.
        /// </summary>
        public EventHubClient EventHubClient { get; }

        /// <summary>
        /// Gets the partition ID for this <see cref="PartitionSender"/>.
        /// </summary>
        public string PartitionId { get; }

        EventDataSender InnerSender { get; }

        object ThisLock { get; } = new object();


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
            if (!string.IsNullOrWhiteSpace(options.PartitionKey))
            {
                throw Fx.Exception.InvalidOperation(Resources.PartitionSenderInvalidWithPartitionKeyOnBatch);
            }

            return new EventDataBatch(options.MaxMessageSize > 0 ? options.MaxMessageSize : this.InnerSender.MaxMessageSize);
        }

        /// <summary>
        /// Send <see cref="EventData"/> to a specific EventHub partition. The target partition is pre-determined when this PartitionSender was created.
        /// This send pattern emphasizes data correlation over general availability and latency.
        /// <para>There are 3 ways to send to EventHubs, each exposed as a method (along with its sendBatch overload):</para>
        /// <para>i.   <see cref="EventHubClient.SendAsync(EventData)"/> or <see cref="EventHubClient.SendAsync(IEnumerable{EventData})"/></para>
        /// <para>ii.  <see cref="EventHubClient.SendAsync(EventData, string)"/> or <see cref="EventHubClient.SendAsync(IEnumerable{EventData}, string)"/></para>
        /// <para>iii. <see cref="PartitionSender.SendAsync(EventData)"/> or <see cref="PartitionSender.SendAsync(IEnumerable{EventData})"/></para>
        /// Use this type of send if:
        /// <para>a. The client wants to take direct control of distribution of data across partitions. In this case client is responsible for making sure there is at least one sender per event hub partition.</para>
        /// <para>b. User cannot use partition key as a mean to direct events to specific partition, yet there is a need for data correlation with partitioning scheme.</para>
        /// </summary>
        /// <param name="eventData">the <see cref="EventData"/> to be sent.</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        /// <exception cref="MessageSizeExceededException">the total size of the <see cref="EventData"/> exceeds a pre-defined limit set by the service. Default is 256k bytes.</exception>
        /// <exception cref="EventHubsException">Event Hubs service encountered problems during the operation.</exception>
        public Task SendAsync(EventData eventData)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            return this.SendAsync(new[] { eventData });
        }

        /// <summary>
        /// Send <see cref="EventData"/> to a specific EventHub partition. The targeted partition is pre-determined when this PartitionSender was created.
        /// <para>
        /// There are 3 ways to send to EventHubs, to understand this particular type of send refer to the overload <see cref="SendAsync(EventData)"/>, which is the same type of send and is used to send single <see cref="EventData"/>.
        /// </para>
        /// Sending a batch of <see cref="EventData"/>'s is useful in the following cases:
        /// <para>i.    Efficient send - sending a batch of <see cref="EventData"/> maximizes the overall throughput by optimally using the number of sessions created to EventHubs' service.</para>
        /// <para>ii.   Sending multiple <see cref="EventData"/>'s in a Transaction. To acheive ACID properties, the Gateway Service will forward all <see cref="EventData"/>'s in the batch to a single EventHub partition.</para>
        /// </summary>
        /// <example>
        /// Sample code:
        /// <code>
        /// EventHubClient client = EventHubClient.Create("__connectionString__");
        /// PartitionSender senderToPartitionOne = client.CreatePartitionSender("1");
        ///         
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
        ///     await senderToPartitionOne.SendAsync(events);
        ///     Console.WriteLine("Sent Batch... Size: {0}", events.Count);
        ///     
        /// }
        /// </code>
        /// </example>
        /// <param name="eventDatas">batch of events to send to EventHub</param>
        /// <returns>a Task that completes when the send operation is done.</returns>
        /// <exception cref="MessageSizeExceededException">the total size of the <see cref="EventData"/> exceeds a pre-defined limit set by the service. Default is 256k bytes.</exception>
        /// <exception cref="EventHubsException">Event Hubs service encountered problems during the operation.</exception>
        public async Task SendAsync(IEnumerable<EventData> eventDatas)
        {
            Guard.ArgumentNotNull(nameof(eventDatas), eventDatas);
            this.ThrowIfClosed();

            if (eventDatas is EventDataBatch && !string.IsNullOrEmpty(((EventDataBatch)eventDatas).PartitionKey))
            {
                throw Fx.Exception.InvalidOperation(Resources.PartitionSenderInvalidWithPartitionKeyOnBatch);
            }

            // Convert enumerator to a rescannable collection to avoid skipping events if underlying enumerator is not re-scannabled.
            var eventDataList = eventDatas?.ToList();

            int count = EventDataSender.ValidateEvents(eventDataList);
            EventHubsEventSource.Log.EventSendStart(this.ClientId, count, null);
            Activity activity = EventHubsDiagnosticSource.StartSendActivity(this.ClientId, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, eventDataList, count);

            Task sendTask = null;
            try
            {
                sendTask = this.InnerSender.SendAsync(eventDataList, null);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                EventHubsEventSource.Log.EventSendException(this.ClientId, exception.ToString());
                EventHubsDiagnosticSource.FailSendActivity(activity, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, eventDataList, exception);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventSendStop(this.ClientId);
                EventHubsDiagnosticSource.StopSendActivity(activity, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, eventDataList, sendTask);
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

            if (eventDataBatch.PartitionKey != null)
            {
                throw Fx.Exception.InvalidOperation(Resources.PartitionSenderInvalidWithPartitionKeyOnBatch);
            }

            await this.SendAsync(eventDataBatch.ToEnumerable()).ConfigureAwait(false);
        }

        /// <summary>
        /// Closes and releases resources for the <see cref="PartitionSender"/>.
        /// </summary>
        /// <returns>An asynchronous operation</returns>
        public override async Task CloseAsync()
        {
            this.IsClosed = true;

            EventHubsEventSource.Log.ClientCloseStart(this.ClientId);
            try
            {
                await this.InnerSender.CloseAsync().ConfigureAwait(false);
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseStop(this.ClientId);
            }
        }
    }
}
