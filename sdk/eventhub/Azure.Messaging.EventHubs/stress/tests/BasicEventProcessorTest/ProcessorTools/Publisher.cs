using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.StressTests.EventProcessorTest
{
    internal class Publisher
    {
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref randomSeed)), false);
        private static int randomSeed = Environment.TickCount;

        private long currentSequence = 0;

        private Metrics Metrics { get; }

        private ConcurrentBag<Exception> ErrorsObserved { get; }

        private ConcurrentDictionary<string, EventData> PublishedEvents { get; }

        private TestConfiguration Configuration { get; }

        public Publisher(TestConfiguration configuration,
                         Metrics metrics,
                         ConcurrentDictionary<string, EventData> publishedEvents,
                         ConcurrentBag<Exception> errorsObserved)
        {
            Configuration = configuration;
            Metrics = metrics;
            PublishedEvents = publishedEvents;
            ErrorsObserved = errorsObserved;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var options = new EventHubProducerClientOptions
                    {
                        RetryOptions = new EventHubsRetryOptions
                        {
                           TryTimeout = Configuration.SendTimeout
                        }
                    };

                    var producer = new EventHubProducerClient(Configuration.EventHubsConnectionString, Configuration.EventHub, options);

                    await using (producer.ConfigureAwait(false))
                    {
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            // Query partitions each iteration to allow any new partitions to be discovered. Dynamic upscaling of partitions
                            // is a near-term feature being added to the Event Hubs service.

                            var partitions = await producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);
                            var selectedPartition = partitions[RandomNumberGenerator.Value.Next(0, partitions.Length)];
                            var batchEvents = new List<EventData>();

                            // Create the batch and generate a set of random events, keeping only those that were able to fit into the batch.

                            using var batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = selectedPartition }).ConfigureAwait(false);

                            var events = EventGenerator.CreateEvents(
                                batch.MaximumSizeInBytes,
                                Configuration.PublishBatchSize,
                                Configuration.LargeMessageRandomFactorPercent,
                                Configuration.PublishingBodyMinBytes,
                                Configuration.PublishingBodyRegularMaxBytes,
                                currentSequence,
                                selectedPartition);

                            foreach (var currentEvent in events)
                            {
                                if (!batch.TryAdd(currentEvent))
                                {
                                    break;
                                }

                                batchEvents.Add(currentEvent);
                            }

                            // Publish the events and report them, capturing any failures specific to the send operation.

                            try
                            {
                                if (batch.Count > 0)
                                {
                                    await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);

                                    foreach (var batchEvent in batchEvents)
                                    {
                                        batchEvent.Properties.TryGetValue(EventGenerator.IdPropertyName, out var id);
                                        PublishedEvents[id.ToString()] = batchEvent;
                                    }

                                    Interlocked.Add(ref Metrics.EventsPublished, batch.Count);
                                    Interlocked.Increment(ref Metrics.TotalServiceOperations);
                                }
                            }
                            catch (TaskCanceledException)
                            {
                            }
                            catch (EventHubsException ex)
                            {
                                Interlocked.Increment(ref Metrics.TotalExceptions);
                                Interlocked.Increment(ref Metrics.SendExceptions);
                                ex.TrackMetrics(Metrics);
                                ErrorsObserved.Add(ex);
                            }
                            catch (Exception ex)
                            {
                                Interlocked.Increment(ref Metrics.TotalExceptions);
                                Interlocked.Increment(ref Metrics.SendExceptions);
                                Interlocked.Increment(ref Metrics.GeneralExceptions);
                                ErrorsObserved.Add(ex);
                            }

                            // Honor any requested delays to throttle publishing so that it doesn't overwhelm slower consumers.

                            if ((Configuration.PublishingDelay.HasValue) && (Configuration.PublishingDelay.Value > TimeSpan.Zero))
                            {
                                await Task.Delay(Configuration.PublishingDelay.Value).ConfigureAwait(false);
                            }
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    // No action needed.
                }
                catch (Exception ex) when
                    (ex is OutOfMemoryException
                    || ex is StackOverflowException
                    || ex is ThreadAbortException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Interlocked.Increment(ref Metrics.ProducerRestarted);
                    ErrorsObserved.Add(ex);
                }
            }
        }
    }
}