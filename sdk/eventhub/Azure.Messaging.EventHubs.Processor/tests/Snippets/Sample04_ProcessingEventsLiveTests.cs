// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample04_ProcessingEvents sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample04_ProcessingEventsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task BasicEventProcessing()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample04_BasicEventProcessing

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    string partition = args.Partition.PartitionId;
                    byte[] eventBody = args.Data.EventBody.ToArray();
                    Debug.WriteLine($"Event from partition { partition } with length { eventBody.Length }.");
                }
                catch
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be redirected to
                    // the error handler.
                }

                return Task.CompletedTask;
            }

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be handled in any
                    // way.

                    Application.HandleErrorException(args, ex);
                }

                return Task.CompletedTask;
            }

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

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
                // The processor will automatically attempt to recover from any
                // failures, either transient or fatal, and continue processing.
                // Errors in the processor's operation will be surfaced through
                // its error handler.
                //
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
               // It is encouraged that you unregister your handlers when you have
               // finished using the Event Processor to ensure proper cleanup.  This
               // is especially important when using lambda expressions or handlers
               // in any form that may contain closure scopes or hold other references.

               processor.ProcessEventAsync -= processEventHandler;
               processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointByEventCount()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample04_CheckpointByEventCount

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            const int EventsBeforeCheckpoint = 25;
            var partitionEventCount = new ConcurrentDictionary<string, int>();

            async Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    await Application.ProcessEventAsync(
                        args.Data,
                        args.Partition,
                        args.CancellationToken);

                    // If the number of events that have been processed
                    // since the last checkpoint was created exceeds the
                    // checkpointing threshold, a new checkpoint will be
                    // created and the count reset.

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

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The error handler is not relevant for this sample; for
                // illustration, it is delegating the implementation to the
                // host application.

                processor.ProcessEventAsync += processEventHandler;
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
               // finished using the Event Processor to ensure proper cleanup

               processor.ProcessEventAsync -= processEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task InitializePartition()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample04_InitializePartition

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            Task initializeEventHandler(PartitionInitializingEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    // If no checkpoint was found, start processing
                    // events enqueued now or in the future.

                    EventPosition startPositionWhenNoCheckpoint =
                        EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);

                    args.DefaultStartingPosition = startPositionWhenNoCheckpoint;
                }
                catch (Exception ex)
                {
                    Application.HandleInitializeException(args, ex);
                }

                return Task.CompletedTask;
            }

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The event handlers for processing events and errors are
                // not relevant for this sample; for illustration, they're
                // delegating the implementation to the host application.

                processor.PartitionInitializingAsync += initializeEventHandler;
                processor.ProcessEventAsync += Application.ProcessorEventHandler;
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
               // finished using the Event Processor to ensure proper cleanup

               processor.PartitionInitializingAsync -= initializeEventHandler;
               processor.ProcessEventAsync -= Application.ProcessorEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessByBatch()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample04_ProcessByBatch

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            const int EventsInBatch = 50;
            var partitionEventBatches = new ConcurrentDictionary<string, List<EventData>>();
            var checkpointNeeded = false;

            async Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    string partition = args.Partition.PartitionId;

                    List<EventData> partitionBatch =
                        partitionEventBatches.GetOrAdd(
                            partition,
                            new List<EventData>());

                    partitionBatch.Add(args.Data);

                    if (partitionBatch.Count >= EventsInBatch)
                    {
                        await Application.ProcessEventBatchAsync(
                            partitionBatch,
                            args.Partition,
                            args.CancellationToken);

                        checkpointNeeded = true;
                        partitionBatch.Clear();
                    }

                    if (checkpointNeeded)
                    {
                        await args.UpdateCheckpointAsync();
                        checkpointNeeded = false;
                    }
                }
                catch (Exception ex)
                {
                    Application.HandleProcessingException(args, ex);
                }
            }

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The error handler is not relevant for this sample; for
                // illustration, it is delegating the implementation to the
                // host application.

                processor.ProcessEventAsync += processEventHandler;
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

               processor.ProcessEventAsync -= processEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessWithHeartbeat()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample04_ProcessWithHeartbeat

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processorOptions = new EventProcessorClientOptions
            {
                MaximumWaitTime = TimeSpan.FromMilliseconds(250)
            };

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            async Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.HasEvent)
                    {
                        await Application.ProcessEventAndCheckpointAsync(
                            args.Data,
                            args.Partition,
                            args.CancellationToken);
                    }

                    await Application.SendHeartbeatAsync(args.CancellationToken);
                }
                catch (Exception ex)
                {
                    Application.HandleProcessingException(args, ex);
                }
            }

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The error handler is not relevant for this sample; for
                // illustration, it is delegating the implementation to the
                // host application.

                processor.ProcessEventAsync += processEventHandler;
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
                    // This may take slightly longer than the length of
                    // time defined as part of the MaximumWaitTime configured
                    // for the processor; in this example, 250 milliseconds.

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

               processor.ProcessEventAsync -= processEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Simulated class for illustration in samples.")]
        private static class Application
        {
            /// <summary>
            ///   A simulated method that an application would use to process an event.
            /// </summary>
            ///
            /// <param name="eventData">The event to process.</param>
            /// <param name="partition">The partition from which the event originated.</param>
            /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
            ///
            public static Task ProcessEventAsync(EventData eventData,
                                                 PartitionContext partition,
                                                 CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would use to process an event.
            /// </summary>
            ///
            /// <param name="eventData">The event to process.</param>
            /// <param name="partition">The partition from which the event originated.</param>
            /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
            ///
            public static Task ProcessEventAndCheckpointAsync(EventData eventData,
                                                              PartitionContext partition,
                                                              CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would use to process a batch of events.
            /// </summary>
            ///
            /// <param name="eventData">The event to process.</param>
            /// <param name="partition">The partition from which the event originated.</param>
            /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
            ///
            public static Task ProcessEventBatchAsync(IReadOnlyList<EventData> eventData,
                                                      PartitionContext partition,
                                                      CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   partition initialization.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the failed initialization handling.</param>
            /// <param name="exception">The exception to handle.</param>
            ///
            public static void HandleInitializeException(PartitionInitializingEventArgs eventArgs,
                                                         Exception exception) {}

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   event processing.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the failed processing.</param>
            /// <param name="exception">The exception to handle.</param>
            ///
            public static void HandleProcessingException(ProcessEventArgs eventArgs,
                                                         Exception exception) {}

            /// <summary>
            ///   A simulated method for handling an exception that occurs during
            ///   error processing.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the failed error handling.</param>
            /// <param name="exception">The exception to handle.</param>
            ///
            public static void HandleErrorException(ProcessErrorEventArgs eventArgs,
                                                    Exception exception) {}

            /// <summary>
            ///   A simulated method that an application would register as an event handler.
            /// </summary>
            ///
            /// <param name="errorEventArgs">The arguments associated with the event.</param>
            ///
            public static Task ProcessorEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would register as an error handler.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the error.</param>
            ///
            public static Task ProcessorErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method for sending a heartbeat to an application.
            /// </summary>
            ///
            /// <param name="cancellationToken">The token used to request cancellation of the operation.</param>
            ///
            public static Task SendHeartbeatAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }
    }
}
