// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample01_HelloWorld sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample01_HelloWorldLiveTests
    {
        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        private EventHubScope _eventHubScope;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [OneTimeSetUp]
        public async Task FixtureSetUp()
        {
            _eventHubScope = await EventHubScope.CreateAsync(2);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [OneTimeTearDown]
        public async Task FixtureTearDown()
        {
            await _eventHubScope.DisposeAsync();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishEvents()
        {
            #region Snippet:EventHubs_Processor_Sample01_PublishEvents

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _eventHubScope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                for (var counter = 0; counter < int.MaxValue; ++counter)
                {
                    var eventBody = new BinaryData($"Event Number: { counter }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        // At this point, the batch is full but our last event was not
                        // accepted.  For our purposes, the event is unimportant so we
                        // will intentionally ignore it.  In a real-world scenario, a
                        // decision would have to be made as to whether the event should
                        // be dropped or published on its own.

                        break;
                    }
                }

                // When the producer publishes the event, it will receive an
                // acknowledgment from the Event Hubs service; so long as there is no
                // exception thrown by this call, the service assumes responsibility for
                // delivery.  Your event data will be published to one of the Event Hub
                // partitions, though there may be a (very) slight delay until it is
                // available to be consumed.

                await producer.SendAsync(eventBatch);
            }
            catch
            {
                // Transient failures will be automatically retried as part of the
                // operation. If this block is invoked, then the exception was either
                // fatal or all retries were exhausted without a successful publish.
            }
            finally
            {
               await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEvents()
        {
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample01_ProcessEvents

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
            /*@@*/ eventHubName = _eventHubScope.EventHubName;
            /*@@*/ consumerGroup = _eventHubScope.ConsumerGroups.First();

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName);

            var partitionEventCount = new ConcurrentDictionary<string, int>();

            async Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // If the cancellation token is signaled, then the
                    // processor has been asked to stop.  It will invoke
                    // this handler with any events that were in flight;
                    // these will not be lost if not processed.
                    //
                    // It is up to the handler to decide whether to take
                    // action to process the event or to cancel immediately.

                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    string partition = args.Partition.PartitionId;
                    byte[] eventBody = args.Data.EventBody.ToArray();
                    Debug.WriteLine($"Event from partition { partition } with length { eventBody.Length }.");

                    int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
                        key: partition,
                        addValue: 1,
                        updateValueFactory: (_, currentCount) => currentCount + 1);

                    if (eventsSinceLastCheckpoint >= 50)
                    {
                        await args.UpdateCheckpointAsync();
                        partitionEventCount[partition] = 0;
                    }
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
                catch
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be handled in any
                    // way.
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
    }
}
