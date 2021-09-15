// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample07_MockEventProcessorHandlersTests sample.
    /// </summary>
    ///
    [TestFixture]
    public class Sample07_MockEventProcessorHandlersTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ProcessEventHandlerCheckpoint()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerCheckpoint

            // Example checkpoints store

            var checkpoints = new List<long>();

            const int EventsBeforeCheckpoint = 5;
            const int CheckpointsCount = 5;

            // Example handler uses event's SequenceNumber to decide when to checkpoint

            void processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // Process the event here...

                    if (args.Data.SequenceNumber % EventsBeforeCheckpoint == 0)
                    {
                        checkpoints.Add(args.Data.Offset);
                    }
                }
                catch
                {
                    // Handle the exception...
                }
            }

            var partitionContext = EventHubsModelFactory.PartitionContext("0");

            // Fire (EventsBeforeCheckpoint * CheckpointsCount) number of the events

            for (int eventCount = 1; eventCount <= EventsBeforeCheckpoint * CheckpointsCount; eventCount++)
            {
                // EventData method allows to mock ALL those read-only properties
                // passed over to the event handler in the ProcessEventArgs argument

                var eventData = EventHubsModelFactory.EventData(
                    new BinaryData("This is a sample event body"),
                    null, // The custom event properties can be mocked,
                    null, // as well as the Event Hub's system properties,
                    null, // and the Partition Key.
                    eventCount, // For this demonstration we mock the partition's Sequence Number,
                    eventCount + (1000 * eventCount + new Random().Next(50, 500))); // and the Offset

                var eventArgs = new ProcessEventArgs(
                    partitionContext,
                    eventData,
                    // Do nothing as we use custom checkpoints store
                    _ => Task.CompletedTask);

                // Execute the handler

                processEventHandler(eventArgs);
            }

            // Verify the number of persisted checkpoints

            Assert.IsTrue(checkpoints.Count == CheckpointsCount);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task InitializeEventHandlerCancellationRequest()
        {
            #region Snippet:EventHubs_Processor_Sample07_InitializeEventHandlerCancellationRequest

            // Application handler honors cancellation and doesn't set the
            // default starting postition.

            Task initializeEventHandler(PartitionInitializingEventArgs args)
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                args.DefaultStartingPosition = EventPosition.Latest;
                return Task.CompletedTask;
            }

            // Initialize the args with a cancelled token and a starting position
            // different than what gets set if the handler completes.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            EventPosition defaultStartingPosition = EventPosition.Earliest;
            var eventArgs = new PartitionInitializingEventArgs("0", defaultStartingPosition, cancellationSource.Token);

            // Execute the handler and validate that cancellation was respected.

            await initializeEventHandler(eventArgs);
            Assert.That(eventArgs.DefaultStartingPosition, Is.EqualTo(defaultStartingPosition));

            #endregion
        }
    }
}
