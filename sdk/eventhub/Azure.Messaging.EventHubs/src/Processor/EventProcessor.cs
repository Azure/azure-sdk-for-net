// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: check if used
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using System;
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
        ///   What to do in case of exception? T1 logs it and sets processor to null.
        ///   T1 logs it and does some retries on Consumer failure. If it still fails, report it to Processor.
        /// </summary>
        ///
        public async Task Start()
        {
            TokenSource = new CancellationTokenSource();

            var partitionId = (await Client.GetPartitionIdsAsync()).First();

            Consumer = Client.CreateConsumer(ConsumerGroup, partitionId, Options?.InitialEventPosition ?? EventPosition.Earliest);

            var partitionContext = new PartitionContext(partitionId, Client.EventHubPath, ConsumerGroup);
            var checkpointManager = new CheckpointManager(partitionContext, PartitionManager);

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
            // TODO: check if running before stopping it

            TokenSource.Cancel();

            // TODO: create lock with Run (on Processor and Consumer)

            // TODO: in case of error, T1 logs it.

            await Consumer.CloseAsync();
            Consumer = null;

            await PartitionProcessor.Close("Stop requested.").ConfigureAwait(false);
            PartitionProcessor = null;

            // TODO: await running task?
            RunningTask = null;

            TokenSource = null;
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

                    // TODO: should we lock it with close?
                    await PartitionProcessor.ProcessEvents(receivedEvents).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    try
                    {
                        await PartitionProcessor.ProcessError(exception).ConfigureAwait(false);
                    }
                    catch { }

                    if (exception is ConsumerDisconnectedException)
                    {
                        // TODO: should we use a cancellation token?
                        // TODO: should we call stop?
                        break;
                    }
                }
            }
        }
    }
}
