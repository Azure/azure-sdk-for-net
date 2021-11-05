// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is a logical representation of receiving from a EventHub partition.
    /// <para>
    /// A PartitionReceiver is tied to a ConsumerGroup + Partition combination. If you are creating an epoch based
    /// PartitionReceiver (i.e. PartitionReceiver.Epoch != 0) you cannot have more than one active receiver per
    /// ConsumerGroup + Partition combo. You can have multiple receivers per ConsumerGroup + Partition combination with 
    /// non-epoch receivers.
    /// </para>
    /// </summary>
    /// <seealso cref="EventHubClient.CreateReceiver(string, string, EventPosition, ReceiverOptions)"/>
    /// <seealso cref="EventHubClient.CreateEpochReceiver(string, string, EventPosition, long, ReceiverOptions)"/>
    public abstract class PartitionReceiver : ClientEntity
    {
        /// <summary>
        /// The default consumer group name: $Default.
        /// </summary>
        public static readonly string DefaultConsumerGroupName = "$Default";

        internal const long NullEpoch = 0;

        const int MinPrefetchCount = 10;
        const int DefaultPrefetchCount = 300;
        int prefetchCount;

        /// <summary></summary>
        /// <param name="eventHubClient"></param>
        /// <param name="consumerGroupName"></param>
        /// <param name="partitionId"></param>
        /// <param name="eventPosition"></param>
        /// <param name="epoch"></param>
        /// <param name="receiverOptions"></param>
        protected PartitionReceiver(
            EventHubClient eventHubClient,
            string consumerGroupName,
            string partitionId,
            EventPosition eventPosition,
            long? epoch,
            ReceiverOptions receiverOptions)
            : base($"{nameof(PartitionReceiver)}{ClientEntity.GetNextId()}({eventHubClient.EventHubName},{consumerGroupName},{partitionId})")
        {
            this.EventHubClient = eventHubClient;
            this.ConsumerGroupName = consumerGroupName;
            this.PartitionId = partitionId;
            this.EventPosition = eventPosition;
            this.prefetchCount = DefaultPrefetchCount;
            this.Epoch = epoch;
            this.RuntimeInfo = new ReceiverRuntimeInformation(partitionId);
            this.ReceiverRuntimeMetricEnabled = receiverOptions == null
                ? this.EventHubClient.EnableReceiverRuntimeMetric
                : receiverOptions.EnableReceiverRuntimeMetric;

            this.Identifier = receiverOptions != null
                ? receiverOptions.Identifier
                : null;
            this.RetryPolicy = eventHubClient.RetryPolicy.Clone();
            eventHubClient.AddChildEntity(this);

            EventHubsEventSource.Log.ClientCreated(this.ClientId, this.FormatTraceDetails());
        }

        /// <summary>
        /// The EventHubClient this PartitionReceiver was created from.
        /// </summary>
        public EventHubClient EventHubClient { get; }

        /// <summary>
        /// The Consumer Group Name
        /// </summary>
        public string ConsumerGroupName { get; }

        /// <summary>
        /// Get the EventHub partition identifier.
        /// </summary>
        /// <value>The identifier representing the partition from which this receiver is fetching data</value>
        public string PartitionId { get; }

        /// <summary>
        /// Get Prefetch Count configured on the Receiver.
        /// </summary>
        /// <value>The upper limit of events this receiver will actively receive regardless of whether a receive operation is pending.</value>
        public int PrefetchCount
        {
            get => this.prefetchCount;

            set
            {
                if (value < MinPrefetchCount)
                {
                    throw Fx.Exception.ArgumentOutOfRange(
                        "PrefetchCount",
                        value,
                        Resources.ValueOutOfRange.FormatForUser(MinPrefetchCount, int.MaxValue));
                }

                this.prefetchCount = value;
            }
        }

        /// <summary>
        /// Get the epoch value that this receiver is currently using for partition ownership.
        /// <para>A value of null means this receiver is not an epoch-based receiver.</para>
        /// </summary>
        /// <value>the epoch value that this receiver is currently using for partition ownership.</value>
        public long? Epoch { get; }

        /// <summary></summary>
        protected EventPosition EventPosition { get; set; }

        /// <summary>Gets the identifier of a receiver which was set during the creation of the receiver.</summary> 
        /// <value>A string representing the identifier of a receiver. It will return null if the identifier is not set.</value>
        public string Identifier { get; private set; }

        /// <summary>
        /// Receive a batch of <see cref="EventData"/>'s from an EventHub partition
        /// </summary>
        /// <example>
        /// Sample code:
        /// <code>
        /// EventHubClient client = EventHubClient.Create("__connectionString__");
        /// PartitionReceiver receiver = client.CreateReceiver("ConsumerGroup1", "1");
        /// IEnumerable&lt;EventData&gt; receivedEvents = await receiver.ReceiveAsync(BatchSize);
        ///      
        /// while (true)
        /// {
        ///     int batchSize = 0;
        ///     if (receivedEvents != null)
        ///     {
        ///         foreach (EventData receivedEvent in receivedEvents)
        ///         {
        ///             Console.WriteLine("Message Payload: {0}", Encoding.UTF8.GetString(receivedEvent.Body));
        ///             Console.WriteLine("Offset: {0}, SeqNo: {1}, EnqueueTime: {2}", 
        ///                 receivedEvent.SystemProperties.Offset, 
        ///                 receivedEvent.SystemProperties.SequenceNumber, 
        ///                 receivedEvent.SystemProperties.EnqueuedTime);
        ///             batchSize++;
        ///         }
        ///     }
        ///          
        ///     Console.WriteLine("ReceivedBatch Size: {0}", batchSize);
        ///     receivedEvents = await receiver.ReceiveAsync();
        /// }
        /// </code>
        /// </example>
        /// <returns>A Task that will yield a batch of <see cref="EventData"/> from the partition on which this receiver is created. Returns 'null' if no EventData is present.</returns>
        public Task<IEnumerable<EventData>> ReceiveAsync(int maxMessageCount)
        {
            return this.ReceiveAsync(maxMessageCount, this.EventHubClient.ConnectionStringBuilder.OperationTimeout);
        }

        /// <summary>
        /// Receive a batch of <see cref="EventData"/>'s from an EventHub partition by allowing wait time on each individual call.
        /// </summary>
        /// <returns>A Task that will yield a batch of <see cref="EventData"/> from the partition on which this receiver is created. Returns 'null' if no EventData is present.</returns>
        public async Task<IEnumerable<EventData>> ReceiveAsync(int maxMessageCount, TimeSpan waitTime)
        {
            this.ThrowIfClosed();

            EventHubsEventSource.Log.EventReceiveStart(this.ClientId);
            Activity activity = EventHubsDiagnosticSource.StartReceiveActivity(this.ClientId, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, this.ConsumerGroupName, this.EventPosition);

            Task<IList<EventData>> receiveTask = null;
            IList<EventData> events = null;
            int count = 0;

            try
            {
                receiveTask = this.OnReceiveAsync(maxMessageCount, waitTime);
                events = await receiveTask.ConfigureAwait(false);
                count = events?.Count ?? 0;
                EventData lastEvent = events?[count - 1];
                if (lastEvent != null)
                {
                    // Store the current position in the stream of messages
                    this.EventPosition.Offset = lastEvent.SystemProperties.Offset;
                    this.EventPosition.EnqueuedTimeUtc = lastEvent.SystemProperties.EnqueuedTimeUtc;
                    this.EventPosition.SequenceNumber = lastEvent.SystemProperties.SequenceNumber;

                    // Update receiver runtime metrics?
                    if (this.ReceiverRuntimeMetricEnabled)
                    {
                        this.RuntimeInfo.Update(lastEvent);
                    }
                }

                return events;
            }
            catch (Exception e)
            {
                EventHubsEventSource.Log.EventReceiveException(this.ClientId, e.ToString());
                EventHubsDiagnosticSource.FailReceiveActivity(activity, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, this.ConsumerGroupName, e);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventReceiveStop(this.ClientId, count);
                EventHubsDiagnosticSource.StopReceiveActivity(activity, this.EventHubClient.ConnectionStringBuilder, this.PartitionId, this.ConsumerGroupName, events, receiveTask);
            }
        }

        /// <summary>
        /// Sets the <see cref="IPartitionReceiveHandler"/> to process events.
        /// </summary>
        /// <param name="receiveHandler">The <see cref="IPartitionReceiveHandler"/> used to process events.</param>
        /// <param name="invokeWhenNoEvents">Flag to indicate whether the handler should be invoked when the receive call times out.</param>
        public void SetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents = false)
        {
            this.ThrowIfClosed();

            EventHubsEventSource.Log.SetReceiveHandlerStart(this.ClientId, receiveHandler != null ? receiveHandler.GetType().ToString() : "null");
            this.OnSetReceiveHandler(receiveHandler, invokeWhenNoEvents);
            EventHubsEventSource.Log.SetReceiveHandlerStop(this.ClientId);
        }

        /// <summary>
        /// Closes and releases resources associated with <see cref="PartitionReceiver"/>.
        /// </summary>
        /// <returns>An asynchronous operation</returns>
        public sealed override Task CloseAsync()
        {
            this.IsClosed = true;

            EventHubsEventSource.Log.ClientCloseStart(this.ClientId);
            try
            {
                return this.OnCloseAsync();
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseStop(this.ClientId);
            }
        }

        /// <summary></summary>
        /// <param name="maxMessageCount"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        protected abstract Task<IList<EventData>> OnReceiveAsync(int maxMessageCount, TimeSpan waitTime);

        /// <summary></summary>
        /// <param name="receiveHandler"></param>
        /// <param name="invokeWhenNoEvents"></param>
        protected abstract void OnSetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents);

        /// <summary>
        /// Gets the approximate receiver runtime information for a logical partition of an Event Hub.
        /// To enable the setting, refer to <see cref="ReceiverOptions"/> and <see cref="EventHubClient.EnableReceiverRuntimeMetric"/>
        /// </summary>
        public ReceiverRuntimeInformation RuntimeInfo { get; private set; }

        /// <summary> Gets a value indicating whether the runtime metric of a receiver is enabled. </summary>
        public bool ReceiverRuntimeMetricEnabled { get; private set; }

        /// <summary></summary>
        /// <returns></returns>
        protected abstract Task OnCloseAsync();

        string FormatTraceDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ConsumerGroup:{0}, PartitionId:{1}", this.ConsumerGroupName, PartitionId);

            if (!string.IsNullOrEmpty(this.EventPosition.Offset))
            {
                sb.AppendFormat(", StartOffset:{0}, IsInclusive:{1}", this.EventPosition.Offset, this.EventPosition.IsInclusive);
            }

            if (this.EventPosition.SequenceNumber != null)
            {
                sb.AppendFormat(", SequenceNumber:{0}, IsInclusive:{1}", this.EventPosition.SequenceNumber, this.EventPosition.IsInclusive);
            }

            if (this.EventPosition.EnqueuedTimeUtc != null)
            {
                sb.AppendFormat(", StartTime:{0}", this.EventPosition.EnqueuedTimeUtc);
            }

            if (this.Epoch.HasValue)
            {
                sb.AppendFormat(", Epoch:{0}", this.Epoch.Value);
            }

            return sb.ToString();
        }
    }
}
