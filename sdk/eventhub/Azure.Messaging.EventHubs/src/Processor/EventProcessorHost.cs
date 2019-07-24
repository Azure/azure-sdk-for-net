// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessorHost
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
        private IEventProcessorFactory EventProcessorFactory { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventProcessorHostOptions Options { get; }

        /// <summary>
        ///   TODO. (null at first?)
        /// </summary>
        ///
        private EventHubConsumer Consumer { get; set; }

        /// <summary>
        ///   TODO. (other name?)
        /// </summary>
        ///
        private CancellationTokenSource CancellationTokenSrc { get; }

        /// <summary>
        ///   TODO. (client? CG? options optional)
        /// </summary>
        ///
        public EventProcessorHost(EventHubClient eventHubClient,
                                  string consumerGroupName,
                                  IEventProcessorFactory eventProcessorFactory,
                                  CheckpointManager checkpointManager,
                                  EventProcessorHostOptions options)
        {
            Client = eventHubClient;
            ConsumerGroup = consumerGroupName;
            EventProcessorFactory = eventProcessorFactory;
            Options = options; // TODO: clone

            Name = "I am unique";
            CancellationTokenSrc = new CancellationTokenSource();
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public async Task Start()
        {
            var firstPartition = (await Client.GetPartitionIdsAsync()).First();
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void Stop() { }

        /// <summary>
        ///   TODO. (make it async, name?)
        /// </summary>
        ///
        private void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
            }
        }
    }
}
