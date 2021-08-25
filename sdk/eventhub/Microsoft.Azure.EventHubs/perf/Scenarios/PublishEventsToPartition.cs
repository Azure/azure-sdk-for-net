// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Perf;
using Microsoft.Azure.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing events
    ///   to an Event Hubs partition.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public sealed class  PublishEventsToPartition : EventHubsPerfTest
    {
        /// <summary>The Event Hub to publish events to; shared across all concurrent instances of the scenario.</summary>
        private static EventHubScope s_scope;

        /// <summary>The client instance that owns the connection to the Event Hubs namespace; shared across all concurrent instances of the scenario.</summary>
        private static EventHubClient s_client;

        /// <summary>The sender instance for publishing events; shared across all concurrent instances of the scenario.</summary>
        private static PartitionSender s_sender;

        /// <summary>The body to use when creating events; shared across all concurrent instances of the scenario.</summary>
        private static byte[] s_eventBody;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PublishEventsToPartition"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public PublishEventsToPartition(SizeCountOptions options) : base(options)
        {
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the setup will take place once, prior to the
        ///   execution of the first test instance.
        /// </summary>
        ///
        public async override Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync().ConfigureAwait(false);

            s_scope = await EventHubScope.CreateAsync(4).ConfigureAwait(false);
            s_client = EventHubClient.CreateFromConnectionString(TestUtility.BuildEventHubsConnectionString(s_scope.EventHubName));
            s_eventBody = EventGenerator.CreateRandomBody(Options.Size);

            var partition = (await s_client.GetRuntimeInformationAsync().ConfigureAwait(false)).PartitionIds[0];
            s_sender = s_client.CreatePartitionSender(partition);

            // Publish an empty event to force the connection and link to be established.

            await s_sender.SendAsync(new[] { new EventData(Array.Empty<byte>()) }).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the cleanup will take place once,
        ///   after the execution of all test instances.
        /// </summary>
        ///
        public async override Task GlobalCleanupAsync()
        {
            await s_sender.CloseAsync().ConfigureAwait(false);
            await s_client.CloseAsync().ConfigureAwait(false);
            await s_scope.DisposeAsync().ConfigureAwait(false);
            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            // Generate a set of events using the same body.  This will result in publishing a set of events
            // of equal size. The events will only differ by the id property that is assigned to them.

            var events = EventGenerator.CreateEventsFromBody(Options.Count, s_eventBody);

            try
            {
                await s_sender.SendAsync(events).ConfigureAwait(false);
            }
            finally
            {
                foreach (var eventData in events)
                {
                    eventData.Dispose();
                }
            }
        }
    }
}
