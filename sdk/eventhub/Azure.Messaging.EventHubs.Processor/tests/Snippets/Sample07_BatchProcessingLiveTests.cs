// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample07_BatchProcessing sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample07_BatchProcessingLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessByBatch()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Usage

#if SNIPPET
            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = storageScope.ContainerName;
            var eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = eventHubScope.ConsumerGroups.First();
#endif

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var checkpointStore = new BlobCheckpointStore(storageClient);
            var maximumBatchSize = 100;

            var processor = new SimpleBatchProcessor(
                checkpointStore,
                maximumBatchSize,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // There are no event handlers to set for the processor.  All logic
            // normally associated with the processor event handlers is
            // implemented directly via method override in the custom processor.

            try
            {
                await processor.StartProcessingAsync(cancellationSource.Token);
                await Task.Delay(Timeout.Infinite, cancellationSource.Token);
            }
            catch (TaskCanceledException)
            {
                // This is expected if the cancellation token is
                // signaled.
            }
            finally
            {
                // Stopping may take up to the length of time defined
                // as the TryTimeout configured for the processor;
                // By default, this is 60 seconds.

                await processor.StopProcessingAsync();
            }

            #endregion
        }

        #region Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Processor
        public class SimpleBatchProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
        {
            // This example uses a connection string, so only the single constructor
            // was implemented; applications will need to shadow each constructor of
            // the EventProcessorClient that they are using.

            public SimpleBatchProcessor(CheckpointStore checkpointStore,
                                        int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string connectionString,
                                        string eventHubName,
                                        EventProcessorOptions clientOptions = default)
                : base(
                    checkpointStore,
                    eventBatchMaximumCount,
                    consumerGroup,
                    connectionString,
                    eventHubName,
                    clientOptions)
            {
            }

            protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                                      EventProcessorPartition partition,
                                                                      CancellationToken cancellationToken)
            {
                // Like the event handler, it is very important that you guard
                // against exceptions in this override; the processor does not
                // have enough understanding of your code to determine the correct
                // action to take.  Any exceptions from this method go uncaught by
                // the processor and will NOT be handled.  The partition processing
                // task will fault and be restarted from the last recorded checkpoint.

                try
                {
                    // The implementation of how events are processed is not relevant in
                    // this sample; for illustration, responsibility for managing the processing
                    // of events is being delegated to the application.

                    await Application.DispatchEventsForProcessing(
                            events,
                            partition.PartitionId,
                            cancellationToken);

                    // Create a checkpoint based on the last event in the batch.

                    var lastEvent = events.Last();

                    await UpdateCheckpointAsync(
                        partition.PartitionId,
                        CheckpointPosition.FromEvent(lastEvent),
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    Application.HandleProcessingException(events, partition.PartitionId, ex);
                }

                // Calling the base would only invoke the process event handler and provide no
                // value; we will not call it here.
            }

            protected async override Task OnProcessingErrorAsync(Exception exception,
                                                                 EventProcessorPartition partition,
                                                                 string operationDescription,
                                                                 CancellationToken cancellationToken)
            {
                // Like the event handler, it is very important that you guard
                // against exceptions in this override; the processor does not
                // have enough understanding of your code to determine the correct
                // action to take.  Any exceptions from this method go uncaught by
                // the processor and will NOT be handled.  Unhandled exceptions will
                // not impact the processor operation but will go unobserved, hiding
                // potential application problems.

                try
                {
                    await Application.HandleErrorAsync(
                        exception,
                        partition.PartitionId,
                        operationDescription,
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    Application.LogErrorHandlingFailure(ex);
                }
            }
        }
        #endregion

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
        private static class Application
        {
            /// <summary>
            ///   A simulated method that an application would use to process a batch of events.
            /// </summary>
            ///
            /// <param name="events">The set of events to process.</param>
            /// <param name="partitionId">The identifier of the partition from which the events were read.</param>
            /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
            ///
            public static Task DispatchEventsForProcessing(IEnumerable<EventData> events,
                                                           string partitionId,
                                                           CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   event processing.
            /// </summary>
            ///
            /// <param name="events">The set of events associated with the failed processing.</param>
            /// <param name="partitionId">The identifier of the partition from which the events were read.</param>
            /// <param name="exception">The exception to handle.</param>
            ///
            public static void HandleProcessingException(IEnumerable<EventData> events,
                                                         string partitionId,
                                                         Exception exception)
            {
            }

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   event processing.
            /// </summary>
            ///
            /// <param name="exception">The exception that occurred.</param>
            /// <param name="partitionId">The identifier of the partition from which the events were read.</param>
            /// <param name="operation">The operation being performed when the error was observed.</param>
            ///
            public static Task HandleErrorAsync(Exception exception,
                                                string partitionId,
                                                string operation,
                                                CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method for handling an exception that occurs when handling
            ///   a processor error.
            /// </summary>
            ///
            /// <param name="exception">The exception that occurred.</param>
            ///
            public static void LogErrorHandlingFailure(Exception exception)
            {
            }
        }
    }
}
