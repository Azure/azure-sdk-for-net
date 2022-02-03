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

            var processor = new SimpleBatchProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The error handler implementation is not relevant in this sample;
                // for illustration, it is delegating the implementation to the
                // host application.

                processor.ProcessErrorAsync += Application.ProcessorErrorHandler;

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
                    // This may take up to the length of time defined
                    // as part of the configured TryTimeout of the processor;
                    // by default, this is 60 seconds.

                    await processor.StopProcessingAsync();
                }
            }
            catch
            {
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
                // It is encouraged that you unregister your handlers when you have
                // finished using the Event Processor to ensure proper cleanup.

                processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        #region Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Processor
        public class SimpleBatchProcessorClient : EventProcessorClient
        {
            // This example uses a connection string, so only the single constructor
            // was implemented; applications will need to shadow each constructor of
            // the EventProcessorClient that they are using.

            public SimpleBatchProcessorClient(BlobContainerClient checkpointStore,
                                              string consumerGroup,
                                              string connectionString,
                                              string eventHubName,
                                              EventProcessorClientOptions clientOptions = default)
                : base(checkpointStore, consumerGroup, connectionString, eventHubName, clientOptions)
            {
                // Though it will not be called, the EventProcessorClient requires an
                // assigned process event handler to start processing.  Assign a no-op here
                // to satisfy validation.

                ProcessEventAsync += _ => Task.CompletedTask;
            }

            protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                                      EventProcessorPartition partition,
                                                                      CancellationToken cancellationToken)
            {
                // Like the event handler, it is very important that you guard
                // against exceptions in this override; the processor does not
                // have enough understanding of your code to determine the correct
                // action to take.  Any exceptions from this method go uncaught by
                // the processor and will NOT be handled and will fault the partition
                // processing task.

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

                    await UpdateCheckpointAsync(partition.PartitionId, events.Last(), cancellationToken);
                }
                catch (Exception ex)
                {
                    Application.HandleProcessingException(events, partition.PartitionId, ex);
                }

                // Calling the base would only invoke the process event handler and provide no
                // value; we will not call it here.
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
            { }

            /// <summary>
            ///   A simulated method that an application would register as an error handler.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the error.</param>
            ///
            public static Task ProcessorErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;
        }
    }
}
