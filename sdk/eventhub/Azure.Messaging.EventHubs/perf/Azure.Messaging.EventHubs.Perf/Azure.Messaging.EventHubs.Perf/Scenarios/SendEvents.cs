//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Test.Perf;

namespace Azure.Messafging.EventHub.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on sending events to Azure EventHubs.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class SendEvents : PerfTest<EventHubsPerfOptions>
    {
        /// <summary>
        /// The client to interact with an Azure EventHub.
        /// </summary>
        private EventHubProducerClient _eventHubProducerClient;

        #pragma warning disable 0169
        private EventDataBatch _eventDataBatch;
        #pragma warning restore 0169

        /// <summary>
        /// Initializes a new instance of the <see cref="SendEvents"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public SendEvents(EventHubsPerfOptions options) : base(options)
        {
            _eventHubProducerClient = new EventHubProducerClient(PerfTestEnvironment.Instance.EventHubConnectionString, PerfTestEnvironment.Instance.EventHubName);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            CreateBatchOptions batchOptions = new CreateBatchOptions();

            if (Options.BatchSize != null)
            {
                batchOptions.MaximumSizeInBytes = Options.BatchSize;
            }

            _eventDataBatch = await _eventHubProducerClient.CreateBatchAsync(batchOptions);

            for (int i = 0; i < Options.Events; i++)
            {
                if (!_eventDataBatch.TryAdd(new EventData(new BinaryData("Static Event"))))
                {
                    throw new Exception($"Batch can only fit {Options.Events} number of messages with batch size of {Options.BatchSize}");
                }
            }
        }

        public override async Task CleanupAsync()
        {
            await _eventHubProducerClient.CloseAsync();
            await base.CleanupAsync();
        }

        /// <summary>
        /// Method Not Supported
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            throw new Exception("Method not supported");
        }

        /// <summary>
        /// Send Events TO Azure EventHubs by calling <see cref="EventHubProducerClient.SendAsync(EventData, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _eventHubProducerClient.SendAsync(_eventDataBatch, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Sent {Options.Events} Events ina Batch with size: {Options.BatchSize}");
#endif
        }
    }
}
