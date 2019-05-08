// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Passed to an event processor instance to describe the environment.
    /// </summary>
    public class PartitionContext
    {
        readonly private ICheckpointMananger checkpointMananger;

        /// <summary>
        /// Construct an instance.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken that the event processor should respect. Same as token passed to IEventProcessor methods.</param>
        /// <param name="partitionId">Id of the partition for which the event processor is handling events.</param>
        /// <param name="eventHubPath">Name of the event hub which is the source of events.</param>
        /// <param name="consumerGroupName">Name of the consumer group on the event hub.</param>
        /// <param name="checkpointMananger">The checkpoint manager instance to use.</param>
        public PartitionContext(CancellationToken cancellationToken, string partitionId, string eventHubPath, string consumerGroupName, ICheckpointMananger checkpointMananger)
        {
            this.CancellationToken = cancellationToken;
            this.PartitionId = partitionId;
            this.EventHubPath = eventHubPath;
            this.ConsumerGroupName = consumerGroupName;

            this.RuntimeInformation = new ReceiverRuntimeInformation(this.PartitionId);

            this.checkpointMananger = checkpointMananger;
        }

        /// <summary>
        /// The event processor implementation should respect this CancellationToken. It is the same as the token passed
        /// in to IEventProcessor methods. It is here primarily for compatibility with Event Processor Host.
        /// </summary>
        public CancellationToken CancellationToken { get; private set; }

        /// <summary>
        /// Name of the consumer group on the event hub.
        /// </summary>
        public string ConsumerGroupName { get; private set; }
        
        /// <summary>
        /// Name of the event hub.
        /// </summary>
        public string EventHubPath { get; private set; }

        /// <summary>
        /// Id of the partition.
        /// </summary>
        public string PartitionId { get; private set; }

        /// <summary>
        /// Gets the approximate receiver runtime information for a logical partition of an Event Hub.
        /// To enable the setting, refer to <see cref="EventProcessorOptions.EnableReceiverRuntimeMetric"/>
        /// </summary>
        public ReceiverRuntimeInformation RuntimeInformation
        {
            get;
            internal set;
        }

        internal string Offset { get; set; }

        internal long SequenceNumber { get; set; }

        internal void SetOffsetAndSequenceNumber(EventData eventData)
        {
            this.Offset = eventData.SystemProperties.Offset;
            this.SequenceNumber = eventData.SystemProperties.SequenceNumber;
        }

        /// <summary>
        /// Mark the last event of the current batch and all previous events as processed.
        /// </summary>
        /// <returns></returns>
        public async Task CheckpointAsync()
        {
            await CheckpointAsync(new Checkpoint(this.Offset, this.SequenceNumber));
        }

        /// <summary>
        /// Mark the given event and all previous events as processed.
        /// </summary>
        /// <param name="eventData">Highest-processed event.</param>
        /// <returns></returns>
        public async Task CheckpointAsync(EventData eventData)
        {
            await CheckpointAsync(new Checkpoint(eventData.SystemProperties.Offset, eventData.SystemProperties.SequenceNumber));
        }

        private async Task CheckpointAsync(Checkpoint checkpoint)
        {
            await this.checkpointMananger.UpdateCheckpointAsync(this.PartitionId, checkpoint, this.CancellationToken);
        }
    }
}
