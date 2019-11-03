// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of consuming events from all Event Hub partitions at once, using the Event Processor.
    /// </summary>
    ///
    public class Sample12_ConsumeEventsWithEventProcessor : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample12_ConsumeEventsWithEventProcessor);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An example of consuming events from all Event Hub partitions at once, using the Event Processor client.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that she sample should run against.</param>
        ///
        public async Task RunAsync(string connectionString,
                                   string eventHubName)
        {
            // An event processor is associated with a specific Event Hub and a consumer group.  It receives events from
            // multiple partitions in the Event Hub, passing them to a handler delegate for processing using code that you
            // provide.
            //
            // These handler delegates are invoked for each event or error that occurs during operation of the event processor.  For
            // a given partition, only a single event will be dispatched for processing at a time so that the order of events within a
            // partition is preserved.  Partitions, however, are processed concurrently.  As a result, your handlers are potentially processing
            // multiple events or errors at any given time.

            // A partition manager may create checkpoints and list/claim partition ownership.  A developer may implement their
            // own partition manager by creating a subclass from the PartitionManager abstract class.  Here we are creating
            // a new instance of an InMemoryPartitionManager, provided by the Azure.Messaging.EventHubs.Processor namespace.
            // This isn't relevant to understanding this sample, but is required by the event processor constructor.

            var partitionManager = new InMemoryPartitionManager();

            // It's also possible to specify custom options upon event processor creation.  We don't want to wait
            // more than 1 second for every set of events.

            var eventProcessorOptions = new EventProcessorClientOptions
            {
                MaximumReceiveWaitTime = TimeSpan.FromSeconds(1)
            };

            // Let's finally create our event processor.  We're using the default consumer group that was created with the Event Hub.

            await using (var eventProcessor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, partitionManager, connectionString, eventHubName, eventProcessorOptions))
            {
                int totalEventsCount = 0;
                int partitionsBeingProcessedCount = 0;

                // TODO: explain callbacks setup once the public API is finished for the next preview.

                eventProcessor.InitializeProcessingForPartitionAsync = (PartitionContext partitionContext) =>
                {
                    // TODO: Set the default initial position to "Latest" here.


                    // This is the last piece of code guaranteed to run before event processing, so all initialization
                    // must be done by the moment this method returns.

                    Interlocked.Increment(ref partitionsBeingProcessedCount);

                    Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': partition processing has started.");

                    // This method is asynchronous, which means it's expected to return a Task.

                    return Task.CompletedTask;
                };

                eventProcessor.ProcessingForPartitionStoppedAsync = (PartitionContext partitionContext, PartitionProcessorCloseReason reason) =>
                {
                    // The code to be run just before stopping processing events for a partition.  This is the right place to dispose
                    // of objects that will no longer be used.

                    Interlocked.Decrement(ref partitionsBeingProcessedCount);

                    Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': partition processing has stopped. Reason: { reason }.");

                    // This method is asynchronous, which means it's expected to return a Task.

                    return Task.CompletedTask;
                };

                eventProcessor.ProcessEventsAsync = (PartitionContext partitionContext, IEnumerable<EventData> events) =>
                {
                    // Here the user can specify what to do with the events received from the event processor.  We are counting how
                    // many events were received across all partitions so we can check whether all sent events were received.
                    //
                    // It's important to notice that this method is called even when no events are received after the maximum wait time, which
                    // can be specified by the user in the event processor options.  In this case, the IEnumerable events is empty, but not null.

                    int eventsCount = events.Count();

                    if (eventsCount > 0)
                    {
                        Interlocked.Add(ref totalEventsCount, eventsCount);
                        Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': { eventsCount } event(s) received.");
                    }

                    // This method is asynchronous, which means it's expected to return a Task.

                    return Task.CompletedTask;
                };

                eventProcessor.ProcessExceptionAsync = (PartitionContext partitionContext, Exception exception) =>
                {
                    // Any exception which occurs as a result of the event processor itself will be passed to
                    // this delegate so it may be handled.  The processor will continue to process events if
                    // it is able to unless this handler explicitly requests that it stop doing so.
                    //
                    // It is important to note that this does not include exceptions during event processing; those
                    // are considered responsibility of the developer implementing the event processing handler.  It
                    // is, therefore, highly encouraged that best practices for exception handling practices are
                    // followed with that delegate.
                    //
                    // This piece of code is not supposed to be reached by this sample.  If the following message has been printed
                    // to the Console, then something unexpected has happened.

                    Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': an unhandled exception was encountered. This was not expected to happen.");

                    // This method is asynchronous, which means it's expected to return a Task.

                    return Task.CompletedTask;
                };

                // Once started, the event processor will start to claim partitions and receive events from them.

                Console.WriteLine("Starting the event processor.");
                Console.WriteLine();

                await eventProcessor.StartAsync();

                Console.WriteLine("Event processor started.");
                Console.WriteLine();

                // Wait until the event processor has claimed ownership of all partitions in the Event Hub.  This may take some time
                // as there's a 10 seconds interval between claims.  To be sure that we do not block forever in case the event processor
                // fails, we will specify a fairly long time to wait and then cancel waiting.

                CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(400));

                await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
                {
                    var partitionsCount = (await producerClient.GetPartitionIdsAsync()).Length;

                    while (partitionsBeingProcessedCount < partitionsCount)
                    {
                        await Task.Delay(500, cancellationSource.Token);
                    }

                    // To test our event processor, we are publishing 10 sets of events to the Event Hub.  Notice that we are not
                    // specifying a partition to send events to, so these sets may end up in different partitions.

                    EventData[] eventsToPublish = new EventData[]
                    {
                        new EventData(Encoding.UTF8.GetBytes("I am not the second event.")),
                        new EventData(Encoding.UTF8.GetBytes("I am not the first event."))
                    };

                    int amountOfSets = 10;
                    int expectedAmountOfEvents = amountOfSets * eventsToPublish.Length;

                    Console.WriteLine("Sending events to the Event Hub.");
                    Console.WriteLine();

                    for (int i = 0; i < amountOfSets; i++)
                    {
                        await producerClient.SendAsync(eventsToPublish);
                    }

                    // Because there is some non-determinism in the messaging flow, the sent events may not be immediately
                    // available.  For this reason, we wait 500 ms before resuming.

                    await Task.Delay(500);

                    // Once stopped, the event processor won't receive events anymore.  In case there are still events being
                    // processed when the stop method is called, the processing will complete before the corresponding partition
                    // processor is closed.

                    Console.WriteLine();
                    Console.WriteLine("Stopping the event processor.");
                    Console.WriteLine();

                    await eventProcessor.StopAsync();

                    // Print out the amount of events that we received.

                    Console.WriteLine();
                    Console.WriteLine($"Amount of events received: { totalEventsCount }. Expected: { expectedAmountOfEvents }.");
                }
            }

            // At this point, our clients have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
