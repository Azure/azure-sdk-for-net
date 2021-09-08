// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample07_MockEventProcessorHandlersTests sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample07_MockEventProcessorHandlersTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerCheckpoint()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerCheckpoint

            // Application handler checkpoints after processing defined number of events.

            const int EventsBeforeCheckpoint = 2;
            var partitionEventCount = new ConcurrentDictionary<string, int>();
            bool checkpointUpdated = false;

            async Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    checkpointUpdated = false;

                    await Application.ProcessEventAsync(args);

                    string partition = args.Partition.PartitionId;

                    int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
                        key: partition,
                        addValue: 1,
                        updateValueFactory: (_, currentCount) => currentCount + 1);

                    if (eventsSinceLastCheckpoint >= EventsBeforeCheckpoint)
                    {
                        await args.UpdateCheckpointAsync();
                        partitionEventCount[partition] = 0;
                    }
                }
                catch (Exception ex)
                {
                    Application.HandleProcessingException(args, ex);
                }
            }

            // Initialize the args and simulate checkpoint update method.

            var partitionId = "0";
            var eventBody = new BinaryData("This is a sample event body");
            var eventData = EventHubsModelFactory.EventData(eventBody);
            var partitionContext = EventHubsModelFactory.PartitionContext(partitionId);
            var eventArgs = new ProcessEventArgs(partitionContext, eventData, _ => { checkpointUpdated = true; return Task.CompletedTask; });

            for (int i = 1; i <= EventsBeforeCheckpoint; i++)
            {
                // Execute the handler and validate that the event handling has been checkpointed.

                await processEventHandler(eventArgs);

                if (i % EventsBeforeCheckpoint == 0)
                    Assert.IsTrue(checkpointUpdated);
                else
                    Assert.IsFalse(checkpointUpdated);

                Assert.That(partitionEventCount[partitionId], Is.EqualTo(i % EventsBeforeCheckpoint));
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorHandlerCancellationTrigger()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessErrorHandlerCancellationTrigger

            using var cancellationSource = new CancellationTokenSource();

            // Applicaition handler cancels events processing after detection of the
            // exact error with exact operation.

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                if (args.Exception.Message.Equals("Example exception") && args.Operation.Equals("Example operation"))
                {
                    cancellationSource.Cancel();
                }

                return Task.CompletedTask;
            }

            // Initialize the args with the specific operation name and exception message.

            var exception = new Exception("Example exception");
            var eventArgs = new ProcessErrorEventArgs("0", "Example operation", exception);

            // Execute the handler and validate that the specific event arguments were detected
            // and the cancellation has been triggered.

            await processErrorHandler(eventArgs);
            Assert.IsTrue(cancellationSource.IsCancellationRequested);

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

            var defaultStartingPosition = EventPosition.Earliest;
            var eventArgs = new PartitionInitializingEventArgs("0", defaultStartingPosition, cancellationSource.Token);

            // Execute the handler and validate that cancellation was respected.

            await initializeEventHandler(eventArgs);
            Assert.That(eventArgs.DefaultStartingPosition, Is.EqualTo(defaultStartingPosition));

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CloseEventHandlerOwnershipLostReason()
        {
            #region Snippet:EventHubs_Processor_Sample07_CloseEventHandlerOwnershipLostReason

            // Partition close event handler responsible for the detection and processing
            // of the lost ownership reason example scenario.

            bool ownershipLostDetected = false;

            Task closeEventHandler(PartitionClosingEventArgs args)
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                if (args.Reason == ProcessingStoppedReason.OwnershipLost)
                {
                    ownershipLostDetected = true;
                }

                return Task.CompletedTask;
            }

            // Initialize the args with lost ownership reason.

            var eventArgs = new PartitionClosingEventArgs("0", ProcessingStoppedReason.OwnershipLost);

            // Execute handler then validate that partion's lost ownership has been detected.

            await closeEventHandler(eventArgs);
            Assert.IsTrue(ownershipLostDetected);

            #endregion
        }

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
        private static class Application
        {
            /// <summary>
            ///   A simulated method that an application would register as an event handler.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the event.</param>
            ///
            public static Task ProcessEventAsync(ProcessEventArgs eventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   event processing.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the failed processing.</param>
            /// <param name="exception">The exception to handle.</param>
            ///
            public static void HandleProcessingException(ProcessEventArgs eventArgs,
                                                         Exception exception)
            { }
        }
    }
}
