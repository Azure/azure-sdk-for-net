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
                // all partitions in the Event Hub, passing them to the user for processing.
                //
                // A partition processor is associated with a specific partition and is responsible for processing events when
                // requested by the event processor.  An instance is provided to the event processor when requested from a
                // factory function, and takes the form of a class which implements the IPartitionProcessor interface.
                //
                // The factory function is provided to the event processor when it is created.  The factory is responsible for
                // creating a partition processor based on a single argument:
                //
                //   A partition context: contains information about the partition the partition processor will be processing
                //   events from.  It's also responsible for the creation of checkpoints.  In this sample, we are only interested
                //   in its partition id.
                //
                // We'll be using a SamplePartitionProcessor, whose implementation can be found at the end of this sample.  Its
                // constructor takes the associated partition id so it can provide useful log messages.

                Func<PartitionContext, IPartitionProcessor> partitionProcessorFactory =
                    partitionContext => new SamplePartitionProcessor(partitionContext.PartitionId);

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

                EventProcessor eventProcessor = new EventProcessor(EventHubConsumer.DefaultConsumerGroupName, client, partitionProcessorFactory, partitionManager, eventProcessorOptions);

                // Once started, the event processor will start to receive events from all partitions.

                Console.WriteLine("Starting the event processor.");
                Console.WriteLine();

                await eventProcessor.StartAsync();

                Console.WriteLine();
                Console.WriteLine("Event processor started.");

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
                    Console.WriteLine();
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
        ///   A sample implementation of <see cref="IPartitionProcessor" />.  It makes use of a static integer to count
        ///   the amount of received events across all existing instances of this class.
        /// </summary>
        ///
        /// <remarks>
        ///   All implemented methods are asynchronous, which means they're expected to return a Task.  This approach is
        ///   specially useful when the processing is done by thread-blocking services.
        ///   
        ///   The implementations found in this sample are synchronous and simply return a <see cref="Task.CompletedTask" />
        ///   to match the return type.
        /// </remarks>
        /// 
        private class SamplePartitionProcessor : IPartitionProcessor
        {
            /// <summary>Keeps track of the amount of received events across all existing instances of this class.</summary>
            private static int s_totalEventsCount = 0;

            /// <summary>
            ///   Keeps track of the amount of received events across all existing instances of this class.
            /// </summary>
            ///
            public static int TotalEventsCount { get => s_totalEventsCount; }

            /// <summary>
            ///   The identifier of the Event Hub partition this partition processor is associated with.  Used in
            ///   log messages.
            /// </summary>
            ///
            private readonly string PartitionId;

            /// <summary>
            ///   Initializes a new instance of the <see cref="SamplePartitionProcessor"/> class.
            /// </summary>
            ///
            /// <param name="partitionId">The identifier of the Event Hub partition this partition processor is associated with.</param>
            ///
            public SamplePartitionProcessor(string partitionId)
            {
                PartitionId = partitionId;

                Console.WriteLine($"\tPartition '{ PartitionId }': partition processor successfully created.");
            }

            /// <summary>
            ///   Initializes the partition processor.
            /// </summary>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task InitializeAsync()
            {
                // This is the last piece of code guaranteed to run before event processing, so all initialization
                // must be done by the moment this method returns.

                Console.WriteLine($"\tPartition '{ PartitionId }': partition processor successfully initialized.");

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Closes the partition processor.
            /// </summary>
            ///
            /// <param name="reason">The reason why the partition processor is being closed.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task CloseAsync(PartitionProcessorCloseReason reason)
            {
                // The code to be run when closing the partition processor.  This is the right place to dispose
                // of objects that will no longer be used.

                Console.WriteLine($"\tPartition '{ PartitionId }': partition processor successfully closed. Reason: { reason }.");

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes a set of received <see cref="EventData" />.
            /// </summary>
            ///
            /// <param name="events">The received events to be processed.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task ProcessEventsAsync(IEnumerable<EventData> events, CancellationToken cancellationToken)
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
                    Console.WriteLine($"\tPartition '{ PartitionId }': { eventsCount } event(s) received.");
                }

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes an unexpected exception thrown when <see cref="EventProcessor" /> is running.
            /// </summary>
            ///
            /// <param name="exception">The exception to be processed.  It's not used in this sample.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task ProcessErrorAsync(Exception exception, CancellationToken cancellationToken)
            {
                // All the unhandled exceptions encountered during the event processor execution are passed to this method so
                // the user can decide how to handle them.
                //
                // This piece of code is not supposed to be reached by this sample.  If the following message has been printed
                // to the Console, then something unexpected has happened.

                Console.WriteLine($"\tPartition '{ PartitionId }': an unhandled exception was encountered. This was not expected to happen.");

                // This method is asynchronous, which means it's expected to return a Task.

                return Task.CompletedTask;
            }
        }
    }
}
