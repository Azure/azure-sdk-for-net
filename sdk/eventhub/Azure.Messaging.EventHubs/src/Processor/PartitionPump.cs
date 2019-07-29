// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal class PartitionPump
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventHubClient Client { get; }

        /// <summary>
        ///   The name of the consumer group that this partition pump is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionProcessor PartitionProcessor { get; }

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
        private Task RunningTask { get; set; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        internal PartitionPump(EventHubClient eventHubClient,
                               string consumerGroup,
                               string partitionId,
                               IPartitionProcessor partitionProcessor,
                               EventProcessorOptions options)
        {
            Guard.ArgumentNotNull(nameof(eventHubClient), eventHubClient);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNull(nameof(partitionProcessor), partitionProcessor);
            Guard.ArgumentNotNull(nameof(options), options);

            Client = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            PartitionProcessor = partitionProcessor;
            Options = options;
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public async Task Start()
        {
            Consumer = Client.CreateConsumer(ConsumerGroup, PartitionId, Options.InitialEventPosition);

            TokenSource = new CancellationTokenSource();

            // TODO: T1 does it first
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

            await PartitionProcessor.Close("Stop requested.").ConfigureAwait(false);

            // TODO: await running task?
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private async Task Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // TODO: Pass the cancellation token?
                    var receivedEvents = await Consumer.ReceiveAsync(Options.MaximumMessageCount, Options.MaximumReceiveWaitTime);

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
