// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrackOne
{
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
    internal abstract class PartitionReceiver : ClientEntity
    {
        /// <summary>
        /// The default consumer group name: $Default.
        /// </summary>
        public static readonly string DefaultConsumerGroupName = "$Default";

        internal const long NullEpoch = 0;
        private const int MinPrefetchCount = 10;
        private const int DefaultPrefetchCount = 300;
        private int prefetchCount;

        /// <summary></summary>
        /// <param name="eventHubClient"></param>
        /// <param name="consumerGroupName"></param>
        /// <param name="partitionId"></param>
        /// <param name="eventPosition"></param>
        /// <param name="epoch"></param>
        /// <param name="receiverOptions"></param>
        protected internal PartitionReceiver(
            EventHubClient eventHubClient,
            string consumerGroupName,
            string partitionId,
            EventPosition eventPosition,
            long? epoch,
            ReceiverOptions receiverOptions)
            : base($"{nameof(PartitionReceiver)}{ClientEntity.GetNextId()}({eventHubClient.EventHubName},{consumerGroupName},{partitionId})")
        {
            EventHubClient = eventHubClient;
            ConsumerGroupName = consumerGroupName;
            PartitionId = partitionId;
            EventPosition = eventPosition;
            prefetchCount = DefaultPrefetchCount;
            Epoch = epoch;
            RuntimeInfo = new ReceiverRuntimeInformation(partitionId);
            ReceiverRuntimeMetricEnabled = receiverOptions == null
                ? EventHubClient.EnableReceiverRuntimeMetric
                : receiverOptions.EnableReceiverRuntimeMetric;

            Identifier = receiverOptions != null
                ? receiverOptions.Identifier
                : null;
            RetryPolicy = eventHubClient.RetryPolicy.Clone();

            EventHubsEventSource.Log.ClientCreated(ClientId, FormatTraceDetails());
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
            get => prefetchCount;

            set
            {
                if (value < MinPrefetchCount)
                {
                    throw Fx.Exception.ArgumentOutOfRange(
                        "PrefetchCount",
                        value,
                        Resources.ValueOutOfRange.FormatForUser(MinPrefetchCount, int.MaxValue));
                }

                prefetchCount = value;
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
            return ReceiveAsync(maxMessageCount, EventHubClient.ConnectionStringBuilder.OperationTimeout);
        }

        /// <summary>
        /// Receive a batch of <see cref="EventData"/>'s from an EventHub partition by allowing wait time on each individual call.
        /// </summary>
        /// <returns>A Task that will yield a batch of <see cref="EventData"/> from the partition on which this receiver is created. Returns 'null' if no EventData is present.</returns>
        public async Task<IEnumerable<EventData>> ReceiveAsync(int maxMessageCount, TimeSpan? waitTime = default)
        {
            waitTime ??= EventHubClient.ConnectionStringBuilder.OperationTimeout;

            EventHubsEventSource.Log.EventReceiveStart(ClientId);
            Task<IList<EventData>> receiveTask = null;
            IList<EventData> events = null;
            int count = 0;

            try
            {
                receiveTask = OnReceiveAsync(maxMessageCount, waitTime.Value);
                events = await receiveTask.ConfigureAwait(false);
                count = events?.Count ?? 0;
                EventData lastEvent = events?[count - 1];
                if (lastEvent != null)
                {
                    // Store the current position in the stream of messages
                    EventPosition.Offset = lastEvent.SystemProperties.Offset;
                    EventPosition.EnqueuedTimeUtc = lastEvent.SystemProperties.EnqueuedTimeUtc;
                    EventPosition.SequenceNumber = lastEvent.SystemProperties.SequenceNumber;

                    // Update receiver runtime metrics?
                    if (ReceiverRuntimeMetricEnabled)
                    {
                        RuntimeInfo.Update(lastEvent);
                    }
                }

                return events;
            }
            catch (Exception e)
            {
                EventHubsEventSource.Log.EventReceiveException(ClientId, e.ToString());
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventReceiveStop(ClientId, count);
            }
        }

        /// <summary>
        /// Sets the <see cref="IPartitionReceiveHandler"/> to process events.
        /// </summary>
        /// <param name="receiveHandler">The <see cref="IPartitionReceiveHandler"/> used to process events.</param>
        /// <param name="invokeWhenNoEvents">Flag to indicate whether the handler should be invoked when the receive call times out.</param>
        public void SetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents = false)
        {
            EventHubsEventSource.Log.SetReceiveHandlerStart(ClientId, receiveHandler != null ? receiveHandler.GetType().ToString() : "null");
            OnSetReceiveHandler(receiveHandler, invokeWhenNoEvents);
            EventHubsEventSource.Log.SetReceiveHandlerStop(ClientId);
        }

        /// <summary>
        /// Closes and releases resources associated with <see cref="PartitionReceiver"/>.
        /// </summary>
        /// <returns>An asynchronous operation</returns>
        public sealed override Task CloseAsync()
        {
            EventHubsEventSource.Log.ClientCloseStart(ClientId);
            try
            {
                return OnCloseAsync();
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseStop(ClientId);
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

        private string FormatTraceDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ConsumerGroup:{0}, PartitionId:{1}", ConsumerGroupName, PartitionId);

            if (!string.IsNullOrEmpty(EventPosition.Offset))
            {
                sb.AppendFormat(", StartOffset:{0}, IsInclusive:{1}", EventPosition.Offset, EventPosition.IsInclusive);
            }

            if (EventPosition.SequenceNumber != null)
            {
                sb.AppendFormat(", SequenceNumber:{0}, IsInclusive:{1}", EventPosition.SequenceNumber, EventPosition.IsInclusive);
            }

            if (EventPosition.EnqueuedTimeUtc != null)
            {
                sb.AppendFormat(", StartTime:{0}", EventPosition.EnqueuedTimeUtc);
            }

            if (Epoch.HasValue)
            {
                sb.AppendFormat(", Epoch:{0}", Epoch.Value);
            }

            return sb.ToString();
        }
    }
}
