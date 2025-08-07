// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the sample
    ///   Sample08_CustomEventProcessor sample.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests are primarily intended to ensure that the sample
    ///   is well-formed and compiles.  There are no live tests due to
    ///   the dependency on Azure.Storage.Blobs, which is not part of
    ///   the Event Hubs core package test environment.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample08_CustomEventProcessorLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CustomProcessorUse()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample08_CustomProcessorUse

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = eventHubScope.ConsumerGroups.First();
            var storageClient = Mock.Of<BlobContainerClient>();
#endif

            var maximumBatchSize = 100;

            var processor = new CustomProcessor(
                storageClient,
                maximumBatchSize,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // Starting the processor does not block when starting; delay
            // until the cancellation token is signaled.

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

        #region Snippet:EventHubs_Sample08_CustomProcessor
        public class CustomProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
        {
            // This example uses a connection string, so only the single constructor
            // was implemented; applications will need to shadow each constructor of
            // the PluggableCheckpointStoreEventProcessor that they are using.

            public CustomProcessor(
                BlobContainerClient storageClient,
                int eventBatchMaximumCount,
                string consumerGroup,
                string fullyQualifiedNamespace,
                string eventHubName,
                TokenCredential credential,
                EventProcessorOptions clientOptions = default)
                    : base(
#if SNIPPET
                        new BlobCheckpointStore(storageClient),
#else
                        new InMemoryCheckpointStore(),
#endif
                        eventBatchMaximumCount,
                        consumerGroup,
                        fullyQualifiedNamespace,
                        eventHubName,
                        credential,
                        clientOptions)
            {
            }

            protected async override Task OnProcessingEventBatchAsync(
                IEnumerable<EventData> events,
                EventProcessorPartition partition,
                CancellationToken cancellationToken)
            {
                EventData lastEvent = null;

                try
                {
                    Console.WriteLine($"Received events for partition { partition.PartitionId }");

                    foreach (var currentEvent in events)
                    {
                        Console.WriteLine($"Event: { currentEvent.EventBody }");
                        lastEvent = currentEvent;
                    }

                    if (lastEvent != null)
                    {
                        await UpdateCheckpointAsync(
                            partition.PartitionId,
                            CheckpointPosition.FromEvent(lastEvent),
                            cancellationToken)
                        .ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions in
                    // your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to take.
                    // Any exceptions from your handlers go uncaught by the processor and
                    // will NOT be redirected to the error handler.
                    //
                    // In this case, the partition processing task will fault and be restarted
                    // from the last recorded checkpoint.

                    Console.WriteLine($"Exception while processing events: { ex }");
                }
            }

            protected override Task OnProcessingErrorAsync(
                Exception exception,
                EventProcessorPartition partition,
                string operationDescription,
                CancellationToken cancellationToken)
            {
                try
                {
                    if (partition != null)
                    {
                        Console.Error.WriteLine(
                            $"Exception on partition { partition.PartitionId } while " +
                            $"performing { operationDescription }: {exception}");
                    }
                    else
                    {
                        Console.Error.WriteLine(
                            $"Exception while performing { operationDescription }: { exception }");
                    }
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions
                    // in your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to
                    // take.  Any exceptions from your handlers go uncaught by the
                    // processor and will NOT be handled in any way.
                    //
                    // In this case, unhandled exceptions will not impact the processor
                    // operation but will go unobserved, hiding potential application problems.

                    Console.WriteLine($"Exception while processing events: { ex }");
                }

                return Task.CompletedTask;
            }

            protected override Task OnInitializingPartitionAsync(
                EventProcessorPartition partition,
                CancellationToken cancellationToken)
            {
                try
                {
                    Console.WriteLine($"Initializing partition { partition.PartitionId }");
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions in
                    // your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to take.
                    // Any exceptions from your handlers go uncaught by the processor and
                    // will NOT be redirected to the error handler.
                    //
                    // In this case, the partition processing task will fault and the
                    // partition will be initialized again.

                    Console.WriteLine($"Exception while initializing a partition: { ex }");
                }

                return Task.CompletedTask;
            }

            protected override Task OnPartitionProcessingStoppedAsync(
                EventProcessorPartition partition,
                ProcessingStoppedReason reason,
                CancellationToken cancellationToken)
            {
                try
                {
                    Console.WriteLine(
                        $"No longer processing partition { partition.PartitionId } " +
                        $"because { reason }");
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions in
                    // your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to take.
                    // Any exceptions from your handlers go uncaught by the processor and
                    // will NOT be redirected to the error handler.
                    //
                    // In this case, unhandled exceptions will not impact the processor
                    // operation but will go unobserved, hiding potential application problems.

                    Console.WriteLine($"Exception while stopping processing for a partition: { ex }");
                }

                return Task.CompletedTask;
            }
        }
        #endregion

        #region Snippet:EventHubs_Sample08_CustomCheckpointProcessor
        public class CustomCheckpointProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
        {
            // This example uses a connection string, so only the single constructor
            // was implemented; applications will need to shadow each constructor of
            // the PluggableCheckpointStoreEventProcessor that they are using.

            public CustomCheckpointProcessor(
                BlobContainerClient storageClient,
                int eventBatchMaximumCount,
                string consumerGroup,
                string connectionString,
                string eventHubName,
                EventProcessorOptions clientOptions = default)
                    : base(
#if SNIPPET
                        new BlobCheckpointStore(storageClient),
#else
                        new InMemoryCheckpointStore(),
#endif
                        eventBatchMaximumCount,
                        consumerGroup,
                        connectionString,
                        eventHubName,
                        clientOptions)
            {
            }

            // Any checkpoint returned by GetCheckpointAsync is treated as the authoritative
            // starting point for the partition; if the return value is null, then the
            // global DefaultStartingPosition specified by the options is used.

            protected async override Task<EventProcessorCheckpoint> GetCheckpointAsync(
                string partitionId,
                CancellationToken cancellationToken)
            {
                EventProcessorCheckpoint checkpoint =
                    await base.GetCheckpointAsync(partitionId, cancellationToken);

                // If there was no checkpoint, set the starting point for reading from
                // this specific partition to 5 minutes ago.

                if (checkpoint == null)
                {
                    var startingTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(5));

                    checkpoint = new EventProcessorCheckpoint
                    {
                       FullyQualifiedNamespace = this.FullyQualifiedNamespace,
                       EventHubName = this.EventHubName,
                       ConsumerGroup = this.ConsumerGroup,
                       PartitionId = partitionId,
                       StartingPosition = EventPosition.FromEnqueuedTime(startingTime)
                    };
                }

                return checkpoint;
            }

            // The logic for processing events and handling errors is not
            // interesting for this example; assume that responsibility is
            // delegated to the application.

            protected override Task OnProcessingEventBatchAsync(
                IEnumerable<EventData> events,
                EventProcessorPartition partition,
                CancellationToken cancellationToken) =>
                    Application.DoEventProcessing(events, partition.PartitionId, cancellationToken);

            protected override Task OnProcessingErrorAsync(
                Exception exception,
                EventProcessorPartition partition,
                string operationDescription,
                CancellationToken cancellationToken) =>
                    Application.HandleErrorAsync(exception, partition.PartitionId, operationDescription, cancellationToken);
        }
        #endregion

        #region Snippet:EventHubs_Sample08_StaticPartitionProcessor
        public class StaticPartitionProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
        {
            private readonly string[] _assignedPartitions;

            // This example uses a connection string, so only the single constructor
            // was implemented; applications will need to shadow each constructor of
            // the PluggableCheckpointStoreEventProcessor that they are using.

            public StaticPartitionProcessor(
                BlobContainerClient storageClient,
                string[] assignedPartitions,
                int eventBatchMaximumCount,
                string consumerGroup,
                string connectionString,
                string eventHubName,
                EventProcessorOptions clientOptions = default)
                    : base(
#if SNIPPET
                        new BlobCheckpointStore(storageClient),
#else
                        new InMemoryCheckpointStore(),
#endif
                        eventBatchMaximumCount,
                        consumerGroup,
                        connectionString,
                        eventHubName,
                        clientOptions)
            {
                _assignedPartitions = assignedPartitions
                    ?? throw new ArgumentNullException(nameof(assignedPartitions));
            }

            // To simplify logic, tell the processor that only its assigned
            // partitions exist for the Event Hub.

            protected override Task<string[]> ListPartitionIdsAsync(
                EventHubConnection connection,
                CancellationToken cancellationToken) =>
                    Task.FromResult(_assignedPartitions);

            // Tell the processor that it owns all of the available partitions for the Event Hub.

            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(
                CancellationToken cancellationToken) =>
                    Task.FromResult(
                        _assignedPartitions.Select(partition =>
                            new EventProcessorPartitionOwnership
                            {
                                FullyQualifiedNamespace = this.FullyQualifiedNamespace,
                                EventHubName = this.EventHubName,
                                ConsumerGroup = this.ConsumerGroup,
                                PartitionId = partition,
                                OwnerIdentifier = this.Identifier,
                                LastModifiedTime = DateTimeOffset.UtcNow
                            }));

            // Accept any ownership claims attempted by the processor; this allows the processor to
            // simulate renewing ownership so that it continues to own all of its assigned partitions.

            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(
                IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                CancellationToken cancellationToken) =>
                     Task.FromResult(desiredOwnership.Select(ownership =>
                    {
                        ownership.LastModifiedTime = DateTimeOffset.UtcNow;
                        return ownership;
                    }));

            // The logic for processing events and handling errors is not
            // interesting for this example; assume that responsibility is
            // delegated to the application.

            protected override Task OnProcessingEventBatchAsync(
                IEnumerable<EventData> events,
                EventProcessorPartition partition,
                CancellationToken cancellationToken) =>
                    Application.DoEventProcessing(events, partition.PartitionId, cancellationToken);

            protected override Task OnProcessingErrorAsync(
                Exception exception,
                EventProcessorPartition partition,
                string operationDescription,
                CancellationToken cancellationToken) =>
                    Application.HandleErrorAsync(exception, partition.PartitionId, operationDescription, cancellationToken);
        }
        #endregion

        /// <summary>
        ///   Serves as a stub to illustrate using the BlobCheckpointStore defined
        ///   in the Processor package.
        /// </summary>
        ///
        public class BlobCheckpointStore : CheckpointStore
        {
            public BlobCheckpointStore(BlobContainerClient storageClient) {}
            public override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());

            public override Task<EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, CancellationToken cancellationToken) => Task.FromResult<EventProcessorCheckpoint>(null);

            public override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, CancellationToken cancellationToken) => Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());

            public override Task UpdateCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, string clientIdentifier, CheckpointPosition checkpointPosition, CancellationToken cancellationToken) => Task.CompletedTask;
        }

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
            public static Task DoEventProcessing(IEnumerable<EventData> events,
                                                 string partitionId,
                                                 CancellationToken cancellationToken) => Task.CompletedTask;

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
