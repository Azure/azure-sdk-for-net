// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: check if used
using Azure.Messaging.EventHubs.Core;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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
        ///   TODO. (name?)
        /// </summary>
        ///
        private EventHubClient Client { get; }

        /// <summary>
        ///   TODO. (name?)
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
        private CancellationTokenSource TokenSource { get; set; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventHubConsumer Consumer { get; set; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionProcessor PartitionProcessor { get; set; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private Task RunningTask { get; set; }

        /// <summary>
        ///   TODO.
        /// </summary>
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
        /// </summary>
        ///
        public async Task Start()
        {
            var partitionId = (await Client.GetPartitionIdsAsync()).First();
            var partitionContext = new PartitionContext(partitionId, Client.EventHubPath, ConsumerGroup);
            var checkpointManager = new CheckpointManager(partitionContext, PartitionManager);

            TokenSource = new CancellationTokenSource();
            Consumer = Client.CreateConsumer(ConsumerGroup, partitionId, Options?.InitialEventPosition ?? EventPosition.Earliest);
            PartitionProcessor = PartitionProcessorFactory.CreatePartitionProcessor(partitionContext, checkpointManager);

            await PartitionProcessor.Initialize().ConfigureAwait(false);

            RunningTask = Run(TokenSource.Token);
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public async Task Stop()
        {
            TokenSource.Cancel();

            await RunningTask.ConfigureAwait(false);
            await Consumer.CloseAsync();
            await PartitionProcessor.Close("Stop requested.").ConfigureAwait(false);

            TokenSource = null;
            RunningTask = null;
            Consumer = null;
            PartitionProcessor = null;
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private async Task Run(CancellationToken token)
        {
            var maximumMessageCount = Options?.MaximumMessageCount ?? 10;

            while (!token.IsCancellationRequested)
            {
                try
                {
                    // TODO: Pass the cancellation token?
                    var receivedEvents = await Consumer.ReceiveAsync(maximumMessageCount, Options?.MaximumReceiveWaitTime);

                    // TODO: Should we await it?
                    await PartitionProcessor.ProcessEvents(receivedEvents).ConfigureAwait(false);
                }
                catch(Exception exception)
                {
                    await PartitionProcessor.ProcessError(exception);
                }
            }
        }
    }
}
