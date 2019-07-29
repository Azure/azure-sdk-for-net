// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessor
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string Name { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventHubClient Client { get; }

        /// <summary>
        ///   The name of the consumer group that this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionProcessorFactory PartitionProcessorFactory { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionManager PartitionManager { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private Dictionary<string, PartitionPump> Pumps { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor"/> class.
        /// </summary>
        ///
        /// <param name="eventHubClient">TODO.</param>
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionProcessorFactory">TODO.</param>
        /// <param name="partitionManager">TODO.</param>
        ///
        public EventProcessor(EventHubClient eventHubClient,
                              string consumerGroup,
                              IPartitionProcessorFactory partitionProcessorFactory,
                              IPartitionManager partitionManager) : this(eventHubClient, consumerGroup, partitionProcessorFactory, partitionManager, null)
        {
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public EventProcessor(EventHubClient eventHubClient,
                              string consumerGroup,
                              IPartitionProcessorFactory partitionProcessorFactory,
                              IPartitionManager partitionManager,
                              EventProcessorOptions options)
        {
            Guard.ArgumentNotNull(nameof(eventHubClient), eventHubClient);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNull(nameof(partitionProcessorFactory), partitionProcessorFactory);
            Guard.ArgumentNotNull(nameof(partitionManager), partitionManager);

            Client = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            PartitionManager = partitionManager;
            Options = options?.Clone() ?? new EventProcessorOptions();

            Name = "event-processor-" + Guid.NewGuid().ToString();
        }

        /// <summary>
        ///   TODO.
        ///   What to do in case of exception? T1 logs it and sets processor to null.
        ///   T1 logs it and does some retries on Consumer failure. If it still fails, report it to Processor.
        /// </summary>
        ///
        public async Task Start()
        {
            var partitionIds = await Client.GetPartitionIdsAsync();
            Pumps = new Dictionary<string, PartitionPump>();

            foreach(var partitionId in partitionIds)
            {
                var partitionContext = new PartitionContext(partitionId, Client.EventHubPath, ConsumerGroup);
                var checkpointManager = new CheckpointManager(partitionContext, PartitionManager);

                var partitionProcessor = PartitionProcessorFactory.CreatePartitionProcessor(partitionContext, checkpointManager);

                var partitionPump = new PartitionPump(Client, ConsumerGroup, partitionId, partitionProcessor, Options);

                Pumps.Add(partitionId, partitionPump);

                await partitionPump.Start();
            }
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public async Task Stop()
        {
            foreach (var partitionPump in Pumps)
            {
                await partitionPump.Value.Stop();
            }
        }
    }
}
