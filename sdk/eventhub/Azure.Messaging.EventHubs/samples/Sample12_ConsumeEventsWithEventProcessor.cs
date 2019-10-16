﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public string Description { get; } = "An example of consuming events from all Event Hub partitions at once, using the Event Processor.";

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
            // We will start by creating a client using its default set of options.  It will be used by the event processor to
            // communicate with the Azure Event Hubs service.

            await using (var client = new EventHubClient(connectionString, eventHubName))
            {
                // An event processor is associated with a specific Event Hub and a consumer group.  It receives events from
                // multiple partitions in the Event Hub, passing them to the user for processing.  It's worth mentioning that
                // an event processor is a generic class, and it takes a partition processor as its underlying type.
                //
                // A partition processor is associated with a specific partition and is responsible for processing events when
                // requested by the event processor.  In order to use it as the event processor's underlying type, two conditions
                // must be met:
                //
                //     - It must be a class derived from BasePartitionProcessor.
                //
                //     - It must have a parameterless constructor.
                //
                // We'll be using a SamplePartitionProcessor, whose implementation can be found at the end of this sample.

                // A partition manager may create checkpoints and list/claim partition ownership.  The user can implement their
                // own partition manager by creating a subclass from the PartitionManager abstract class.  Here we are creating
                // a new instance of an InMemoryPartitionManager, provided by the Azure.Messaging.EventHubs.Processor namespace.
                // This isn't relevant to understanding this sample, but is required by the event processor constructor.

                PartitionManager partitionManager = new InMemoryPartitionManager();

                // It's also possible to specify custom options upon event processor creation.  We want to receive events from
                // the latest available position so older events don't interfere with our sample.  We also don't want to wait
                // more than 1 second for every set of events.

                EventProcessorOptions eventProcessorOptions = new EventProcessorOptions
                {
                    InitialEventPosition = EventPosition.Latest,
                    MaximumReceiveWaitTime = TimeSpan.FromSeconds(1)
                };

                // Let's finally create our event processor.  We're using the default consumer group that was created with the Event Hub.

                var eventProcessor = new EventProcessor<SamplePartitionProcessor>(EventHubConsumer.DefaultConsumerGroupName, client, partitionManager, eventProcessorOptions);

                // Once started, the event processor will start to claim partitions and receive events from them.

                Console.WriteLine("Starting the event processor.");
                Console.WriteLine();

                await eventProcessor.StartAsync();

                Console.WriteLine("Event processor started.");
                Console.WriteLine();

                // Wait until the event processor has claimed ownership of all partitions in the Event Hub.  There should be a single
                // active partition processor per owned partition.  This may take some time as there's a 10 seconds interval between
                // claims.  To be sure that we do not block forever in case the event processor fails, we will specify a fairly long
                // time to wait and then cancel waiting.

                CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(400));

                var partitionsCount = (await client.GetPartitionIdsAsync()).Length;

                while (SamplePartitionProcessor.ActiveInstancesCount < partitionsCount)
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

                await using (EventHubProducer producer = client.CreateProducer())
                {
                    Console.WriteLine("Sending events to the Event Hub.");
                    Console.WriteLine();

                    for (int i = 0; i < amountOfSets; i++)
                    {
                        await producer.SendAsync(eventsToPublish);
                    }
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
                Console.WriteLine($"Amount of events received: { SamplePartitionProcessor.TotalEventsCount }. Expected: { expectedAmountOfEvents }.");
            }

            // At this point, our client and producer have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }

        /// <summary>
        ///   A sample class derived from <see cref="BasePartitionProcessor" />.  It makes use of static integers to count
        ///   the amount of received events across all existing instances of this class, as well as the amount of active
        ///   SamplePartitionProcessors.
        /// </summary>
        ///
        /// <remarks>
        ///   All implemented methods are asynchronous, which means they're expected to return a Task.  This approach is
        ///   specially useful when the processing is done by thread-blocking services.
        ///   The implementations found in this sample are synchronous and simply return a <see cref="Task.CompletedTask" />
        ///   to match the return type.
        /// </remarks>
        ///
        private class SamplePartitionProcessor : BasePartitionProcessor
        {
            /// <summary>Keeps track of the amount of active SamplePartitionProcessors.</summary>
            private static int s_activeInstancesCount = 0;

            /// <summary>Keeps track of the amount of received events across all existing instances of this class.</summary>
            private static int s_totalEventsCount = 0;

            /// <summary>
            ///   Keeps track of the amount of active SamplePartitionProcessors.
            /// </summary>
            ///
            public static int ActiveInstancesCount  => s_activeInstancesCount;

            /// <summary>
            ///   Keeps track of the amount of received events across all existing instances of this class.
            /// </summary>
            ///
            public static int TotalEventsCount => s_totalEventsCount;

            /// <summary>
            ///   Initializes a new instance of the <see cref="SamplePartitionProcessor"/> class.
            /// </summary>
            ///
            public SamplePartitionProcessor()
            {
                Console.WriteLine($"\tPartition processor successfully created.");
            }

            /// <summary>
            ///   Initializes the partition processor.
            /// </summary>
            ///
            /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public override Task InitializeAsync(PartitionContext partitionContext)
            {
                // This is the last piece of code guaranteed to run before event processing, so all initialization
                // must be done by the moment this method returns.

                Interlocked.Increment(ref s_activeInstancesCount);

                Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': partition processor successfully initialized.");
                Console.WriteLine();

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Closes the partition processor.
            /// </summary>
            ///
            /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
            /// <param name="reason">The reason why the partition processor is being closed.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public override Task CloseAsync(PartitionContext partitionContext,
                                            PartitionProcessorCloseReason reason)
            {
                // The code to be run when closing the partition processor.  This is the right place to dispose
                // of objects that will no longer be used.

                Interlocked.Decrement(ref s_activeInstancesCount);

                Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': partition processor successfully closed. Reason: { reason }.");

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes a set of received <see cref="EventData" />.
            /// </summary>
            ///
            /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
            /// <param name="events">The received events to be processed.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public override Task ProcessEventsAsync(PartitionContext partitionContext,
                                                    IEnumerable<EventData> events,
                                                    CancellationToken cancellationToken)
            {
                // Here the user can specify what to do with the events received from the event processor.  We are counting how
                // many events were received across all instances of this class so we can check whether all sent events were received.
                //
                // It's important to notice that this method is called even when no events are received after the maximum wait time, which
                // can be specified by the user in the event processor options.  In this case, the IEnumerable events is empty, but not null.

                int eventsCount = events.Count();

                if (eventsCount > 0)
                {
                    Interlocked.Add(ref s_totalEventsCount, eventsCount);
                    Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': { eventsCount } event(s) received.");
                }

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes an unexpected exception thrown while the associated <see cref="EventProcessor{T}" /> is running.
            /// </summary>
            ///
            /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
            /// <param name="exception">The exception to be processed.  It's not used in this sample.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public override Task ProcessErrorAsync(PartitionContext partitionContext,
                                                   Exception exception,
                                                   CancellationToken cancellationToken)
            {
                // All the unhandled exceptions encountered during the event processor execution are passed to this method so
                // the user can decide how to handle them.
                //
                // This piece of code is not supposed to be reached by this sample.  If the following message has been printed
                // to the Console, then something unexpected has happened.

                Console.WriteLine($"\tPartition '{ partitionContext.PartitionId }': an unhandled exception was encountered. This was not expected to happen.");

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }
        }
    }
}
