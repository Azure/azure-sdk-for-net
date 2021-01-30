// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    ///   Sample03_EventProcessorHandlers sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample03_EventProcessorHandlersLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void EventHandlerExceptionHandling()
        {
            #region Snippet:EventHubs_Processor_Sample03_EventHandlerExceptionHandling

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

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
                    // Process the event.
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessEventAsync -= processEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void EventHandlerCancellation()
        {
            #region Snippet:EventHubs_Processor_Sample03_EventHandlerCancellation

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

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

                    // Process the event.
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessEventAsync -= processEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task EventHandlerStopOnException()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample03_EventHandlerStopOnException

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

            // This token is used to control processing,
            // if signaled, then processing will be stopped.

            using var cancellationSource = new CancellationTokenSource();
            /*@@*/ cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    // Process the event.
                }
                catch
                {
                    // Handle the exception.  If fatal,
                    // signal for cancellation.

                    cancellationSource.Cancel();
                }

                return Task.CompletedTask;
            }

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                // Process the error, as appropriate for the
                // application.

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    // Once processing has started, the delay will
                    // block to allow processing until cancellation
                    // is requested.

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
            finally
            {
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
        public void ErrorHandlerExceptionHandling()
        {
            #region Snippet:EventHubs_Processor_Sample03_ErrorHandlerExceptionHandling

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    // Process the error and take the appropriate
                    // action for the application.
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessErrorAsync += processErrorHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ErrorHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_ErrorHandlerArgs

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
                    Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessErrorAsync += processErrorHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ErrorHandlerCancellationRecovery()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample03_ErrorHandlerCancellationRecovery

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

            // This token is used to control processing,
            // if signaled, then processing will be stopped.

            using var cancellationSource = new CancellationTokenSource();
            /*@@*/ cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // Process the event.
                }
                catch
                {
                    // Handle the exception.
                }

                return Task.CompletedTask;
            }

            async Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    // Always log the exception.

                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
                    Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");

                    // If cancellation was requested, assume that
                    // it was in response to an application request
                    // and take no action.

                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    // If out of memory, signal for cancellation.

                    if (args.Exception is OutOfMemoryException)
                    {
                        cancellationSource.Cancel();
                        return;
                    }

                    // If processing stopped and this handler determined
                    // the error to be non-fatal, restart processing.

                    if ((!processor.IsRunning)
                        && (!cancellationSource.IsCancellationRequested))
                    {
                        // To be safe, request that processing stop before
                        // requesting the start; this will ensure that any
                        // processor state is fully reset.

                        await processor.StopProcessingAsync();
                        await processor.StartProcessingAsync(cancellationSource.Token);
                    }
                }
                catch
                {
                    // Handle the exception.  If fatal, signal
                    // for cancellation.
                }
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    // Once processing has started, the delay will
                    // block to allow processing until cancellation
                    // is requested.

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
            finally
            {
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
        public void InitializeHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_InitializeHandlerArgs

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

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

                    Debug.WriteLine($"Initialize partition: { args.PartitionId }");

                    // If no checkpoint was found, start processing
                    // events enqueued now or in the future.

                    EventPosition startPositionWhenNoCheckpoint =
                        EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);

                    args.DefaultStartingPosition = startPositionWhenNoCheckpoint;
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.PartitionInitializingAsync += initializeEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.PartitionInitializingAsync -= initializeEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CloseHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_CloseHandlerArgs

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            Task closeEventHandler(PartitionClosingEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    string description = args.Reason switch
                    {
                        ProcessingStoppedReason.OwnershipLost =>
                            "Another processor claimed ownership",

                        ProcessingStoppedReason.Shutdown =>
                            "The processor is shutting down",

                        _ => args.Reason.ToString()
                    };

                    Debug.WriteLine($"Closing partition: { args.PartitionId }");
                    Debug.WriteLine($"\tReason: { description }");
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.PartitionClosingAsync += closeEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.PartitionClosingAsync -= closeEventHandler;
            }

            #endregion
        }
    }
}
