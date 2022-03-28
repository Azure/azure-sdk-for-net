using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
//using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.StressTests.EventProcessorTest
{
    internal class TestRun
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public bool IsRunning { get; private set; } = false;

        public Metrics Metrics { get; } = new Metrics();

        public ConcurrentBag<Exception> ErrorsObserved { get; } = new ConcurrentBag<Exception>();

        private ConcurrentDictionary<string, EventData> PublishedEvents { get; } = new ConcurrentDictionary<string, EventData>();

        private ConcurrentDictionary<string, EventData> UnexpectedEvents { get; } = new ConcurrentDictionary<string, EventData>();

        private ConcurrentDictionary<string, byte> ReadEvents { get; } = new ConcurrentDictionary<string, byte>();

        private ConcurrentDictionary<string, long> LastReadPartitionSequence { get; } = new ConcurrentDictionary<string, long>();

        private TestConfiguration Configuration { get; }

        public TestRun(TestConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            IsRunning = true;

            using var process = Process.GetCurrentProcess();
            using var publishCancellationSource = new CancellationTokenSource();
            using var processorCancellationSource = new CancellationTokenSource();

            var publishingTask = default(Task);
            var processorTasks = default(IEnumerable<Task>);
            var runDuration = Stopwatch.StartNew();

            try
            {
                // Determine the number of partitions in the Event Hub.

                int partitionCount;

                await using (var producerClient = new EventHubProducerClient(Configuration.EventHubsConnectionString, Configuration.EventHub))
                {
                    partitionCount = (await producerClient.GetEventHubPropertiesAsync()).PartitionIds.Length;
                }

                // Begin publishing events in the background.

                publishingTask = Task.Run(() => new Publisher(Configuration, Metrics, PublishedEvents, ErrorsObserved).Start(publishCancellationSource.Token));

                // Start processing.

                processorTasks = Enumerable
                    .Range(0, Configuration.ProcessorCount)
                    .Select(_ => Task.Run(() => new Processor(Configuration, Metrics, partitionCount, ErrorsObserved, ProcessEventHandler, ProcessErrorHandler).Start(processorCancellationSource.Token)))
                    .ToList();

                // Test for missing events and update metrics.

                var eventDueInterval = TimeSpan.FromMinutes(Configuration.EventReadLimitMinutes);

                while (!cancellationToken.IsCancellationRequested)
                {
                    Metrics.UpdateEnvironmentStatistics(process);
                    Interlocked.Exchange(ref Metrics.RunDurationMilliseconds, runDuration.Elapsed.TotalMilliseconds);
                    ScanForUnreadEvents(PublishedEvents, UnexpectedEvents, ReadEvents, ErrorsObserved, eventDueInterval, Metrics);

                    await Task.Delay(TimeSpan.FromMinutes(5), cancellationToken).ConfigureAwait(false);
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
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
            }

            // The run is ending.  Clean up the outstanding background operations and
            // complete the necessary metrics tracking.

            try
            {
                var publishingStopped = DateTimeOffset.UtcNow;

                publishCancellationSource.Cancel();
                await publishingTask.ConfigureAwait(false);

                // Wait a bit after publishing has completed before signaling for
                // processing to be canceled, to allow the recently published
                // events to be read.

                await Task.Delay(TimeSpan.FromMinutes(5)).ConfigureAwait(false);

                processorCancellationSource.Cancel();
                await Task.WhenAll(processorTasks).ConfigureAwait(false);

                // Wait a bit after processing has completed before and then perform
                // the last bit of bookkeeping, scanning for missing and unexpected events.

                await Task.Delay(TimeSpan.FromMinutes(2)).ConfigureAwait(false);

                ScrubRecentlyPublishedEvents(PublishedEvents, UnexpectedEvents, ReadEvents, publishingStopped.Subtract(TimeSpan.FromMinutes(1)));
                ScanForUnreadEvents(PublishedEvents, UnexpectedEvents, ReadEvents, ErrorsObserved, TimeSpan.FromMinutes(Configuration.EventReadLimitMinutes), Metrics);

                foreach (var unexpectedEvent in UnexpectedEvents.Values)
                {
                    Interlocked.Increment(ref Metrics.UnknownEventsProcessed);
                    ErrorsObserved.Add(new EventHubsException(false, Configuration.EventHub, FormatUnexpectedEvent(unexpectedEvent, false), EventHubsException.FailureReason.GeneralError));
                }
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
            }
            finally
            {
                runDuration.Stop();
                IsRunning = false;
            }
        }

        private async Task ProcessEventHandler(string processorId, ProcessEventArgs args)
        {
            try
            {
                Interlocked.Increment(ref Metrics.TotalServiceOperations);

                // If there was no event then there is nothing to do.

                if (!args.HasEvent)
                {
                    return;
                }

                // Determine if the event has an identifier and has been tracked as published.

                var hasId = args.Data.Properties.TryGetValue(EventGenerator.IdPropertyName, out var id);
                var eventId = (hasId) ? id?.ToString() : null;
                var isTrackedEvent = PublishedEvents.TryRemove(eventId, out var publishedEvent);

                // If the event has an id that has been seen before, track it as a duplicate processing and
                // take no further action.

                if ((hasId) && (ReadEvents.ContainsKey(eventId)))
                {
                    Interlocked.Increment(ref Metrics.DuplicateEventsDiscarded);
                    return;
                }

                // Since this event wasn't a duplicate, consider it read.

                Interlocked.Increment(ref Metrics.EventsRead);

                // If there the event isn't a known and published event, then track it but take no
                // further action.

                if ((!hasId) || (!isTrackedEvent))
                {
                    // If there was an id, then the event wasn't tracked.  This is likely a race condition in tracking;
                    // allow for a small delay and then try to find the event again.

                    if (hasId)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                        isTrackedEvent = PublishedEvents.TryRemove(eventId, out publishedEvent);
                    }
                    else
                    {
                        // If there wasn't an id then consider it an unexpected event failure.

                        Interlocked.Increment(ref Metrics.UnknownEventsProcessed);
                        ErrorsObserved.Add(new EventHubsException(false, Configuration.EventHub, FormatUnexpectedEvent(args.Data, isTrackedEvent), EventHubsException.FailureReason.GeneralError));
                        return;
                    }

                    // If there was an id, but the event wasn't tracked as published or processed, cache it as an
                    // unexpected event for later consideration.  If it cannot be cached, consider it a failure.

                    if ((!isTrackedEvent) && (!ReadEvents.ContainsKey(eventId)))
                    {
                        if (!UnexpectedEvents.TryAdd(eventId, args.Data))
                        {
                            Interlocked.Increment(ref Metrics.UnknownEventsProcessed);
                            ErrorsObserved.Add(new EventHubsException(false, Configuration.EventHub, FormatUnexpectedEvent(args.Data, isTrackedEvent), EventHubsException.FailureReason.GeneralError));
                        }

                        return;
                    }
                }

                // It has been proven that the current event is expected; track it as having been read.

                ReadEvents.TryAdd(eventId, 0);

                // Validate the event against expectations.

                if (!args.Data.IsEquivalentTo(publishedEvent))
                {
                    if (!args.Data.Body.ToArray().SequenceEqual(publishedEvent.Body.ToArray()))
                    {
                        Interlocked.Increment(ref Metrics.InvalidBodies);
                    }
                    else
                    {
                        Interlocked.Increment(ref Metrics.InvalidProperties);
                    }
                }

                // Validate that the intended partition that was sent as a property matches the
                // partition that the handler was triggered for.

                if ((!publishedEvent.Properties.TryGetValue(EventGenerator.PartitionPropertyName, out var publishedPartition))
                    || (args.Partition.PartitionId != publishedPartition.ToString()))
                {
                    Interlocked.Increment(ref Metrics.EventsFromWrongPartition);
                }

                // Validate that the sequence number that was sent as a property is greater than the last read
                // sequence number for the partition; if there hasn't been an event for the partition yet, then
                // there is no validation possible.
                //
                // Track the sequence number for future comparisons.

                var currentSequence = default(object);

                if ((LastReadPartitionSequence.TryGetValue(args.Partition.PartitionId, out var lastReadSequence))
                    && ((!publishedEvent.Properties.TryGetValue(EventGenerator.SequencePropertyName, out currentSequence)) || (lastReadSequence >= (long)currentSequence)))
                {
                    Interlocked.Increment(ref Metrics.EventsOutOfOrder);
                }

                var trackSequence = (currentSequence == default) ? -1 : (long)currentSequence;
                LastReadPartitionSequence.AddOrUpdate(args.Partition.PartitionId, _ => trackSequence, (part, seq) => Math.Max(seq, trackSequence));

                // Create a checkpoint every 100 events for the partition, just to follow expected patterns.

                if (trackSequence % 100 == 0)
                {
                    await args.UpdateCheckpointAsync(args.CancellationToken).ConfigureAwait(false);
                }

                // Mark the event as processed.

                Interlocked.Increment(ref Metrics.EventsProcessed);
            }
            catch (EventHubsException ex)
            {
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.ProcessingExceptions);
                ex.TrackMetrics(Metrics);
                ErrorsObserved.Add(ex);
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.ProcessingExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
            }
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs args)
        {
            try
            {
                var eventHubsException = (args.Exception as EventHubsException);
                eventHubsException?.TrackMetrics(Metrics);

                if (eventHubsException == null)
                {
                    Interlocked.Increment(ref Metrics.GeneralExceptions);
                }

                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.ProcessingExceptions);
                ErrorsObserved.Add(args.Exception);
            }
            catch (EventHubsException ex)
            {
                Interlocked.Increment(ref Metrics.TotalExceptions);
                ex.TrackMetrics(Metrics);
                ErrorsObserved.Add(ex);
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
            }

            return Task.CompletedTask;
        }

        private static void ScanForUnreadEvents(ConcurrentDictionary<string, EventData> publishedEvents,
                                                ConcurrentDictionary<string, EventData> unexpectedEvents,
                                                ConcurrentDictionary<string, byte> readEvents,
                                                ConcurrentBag<Exception> errorsObserved,
                                                TimeSpan eventDueInterval,
                                                Metrics metrics)
        {
            // An event is considered missing if it was published longer ago than the due time and
            // still exists in the set of published events.

            object publishDate;

            var now = DateTimeOffset.UtcNow;

            foreach (var publishedEventId in publishedEvents.Select(item => item.Key).ToList())
            {
                // If the event is no longer in the set, then it was processed since the copy
                // of the keys were made.

                if (!publishedEvents.TryGetValue(publishedEventId, out var publishedEvent))
                {
                    continue;
                }

                // If the event was expected earlier, it may have already been read and tracked as
                // unexpected.

                if ((publishedEvent.Properties.TryGetValue(EventGenerator.PublishTimePropertyName, out publishDate))
                    && (((DateTimeOffset)publishDate).Add(eventDueInterval) < now)
                    && (publishedEvents.TryRemove(publishedEventId, out _)))
                {
                    // Check to see if the event was read and tracked as unexpected.  If so, perform basic validation
                    // and record it.

                    if (unexpectedEvents.TryRemove(publishedEventId, out var readEvent))
                    {
                        Interlocked.Increment(ref metrics.EventsRead);

                         // Validate the event against expectations.

                        if (!readEvent.IsEquivalentTo(publishedEvent))
                        {
                            if (!readEvent.Body.ToArray().SequenceEqual(publishedEvent.Body.ToArray()))
                            {
                                Interlocked.Increment(ref metrics.InvalidBodies);
                            }
                            else
                            {
                                Interlocked.Increment(ref metrics.InvalidProperties);
                            }
                        }

                        if ((!publishedEvent.Properties.TryGetValue(EventGenerator.PartitionPropertyName, out var publishedPartition))
                            ||(!readEvent.Properties.TryGetValue(EventGenerator.PartitionPropertyName, out var readPartition))
                            || (readPartition.ToString() != publishedPartition.ToString()))
                        {
                            Interlocked.Increment(ref metrics.EventsFromWrongPartition);
                        }

                        Interlocked.Increment(ref metrics.EventsProcessed);
                        readEvents.TryAdd(publishedEventId, 0);
                    }
                    else if (!readEvents.ContainsKey(publishedEventId))
                    {
                        // The event wasn't read earlier and tracked as unexpected; it has not been seen.  Track it as missing.

                        Interlocked.Increment(ref metrics.EventsNotReceived);
                        errorsObserved.Add(new EventHubsException(false, string.Empty, FormatMissingEvent(publishedEvent, now), EventHubsException.FailureReason.GeneralError));
                    }
                }
            }
        }

        private static void ScrubRecentlyPublishedEvents(ConcurrentDictionary<string, EventData> publishedEvents,
                                                         ConcurrentDictionary<string, EventData> unexpectedEvents,
                                                         ConcurrentDictionary<string, byte> readEvents,
                                                         DateTimeOffset scrubMoreRecentThan)
        {
            object publishDate;

            foreach (var publishedEventId in publishedEvents.Select(item => item.Key).ToList())
            {
                // If the event is no longer in the set, then it was processed since the copy
                // of the keys were made.

                if (!publishedEvents.TryGetValue(publishedEventId, out var publishedEvent))
                {
                    continue;
                }

                if ((publishedEvent.Properties.TryGetValue(EventGenerator.PublishTimePropertyName, out publishDate))
                    && (((DateTimeOffset)publishDate) >= scrubMoreRecentThan))
                {
                    publishedEvents.TryRemove(publishedEventId, out _);
                    readEvents.TryRemove(publishedEventId, out _);
                }
            }

            foreach (var unexpectedEventId in unexpectedEvents.Select(item => item.Key).ToList())
            {
                // If the event is no longer in the set, then it was processed since the copy
                // of the keys were made.

                if (!unexpectedEvents.TryGetValue(unexpectedEventId, out var unexpectedEvent))
                {
                    continue;
                }

                if ((unexpectedEvent.Properties.TryGetValue(EventGenerator.PublishTimePropertyName, out publishDate))
                    && (((DateTimeOffset)publishDate) >= scrubMoreRecentThan))
                {
                    unexpectedEvents.TryRemove(unexpectedEventId, out _);
                    readEvents.TryRemove(unexpectedEventId, out _);
                }
            }
        }

        private static string FormatMissingEvent(EventData eventData,
                                                 DateTimeOffset markedMissingTime)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Event Not Received:");

            object value;

            if (eventData.Properties.TryGetValue(EventGenerator.IdPropertyName, out value))
            {
                builder.AppendFormat("    Event Id: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.PartitionPropertyName, out value))
            {
                builder.AppendFormat("    Sent To Partition: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.SequencePropertyName, out value))
            {
                builder.AppendFormat("    Artificial Sequence: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.PublishTimePropertyName, out value))
            {
                builder.AppendFormat("    Published: {0} ", ((DateTimeOffset)value).ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss:tt"));
                builder.AppendLine();
            }

            builder.AppendFormat("    Classified Missing: {0} ", markedMissingTime.ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss:tt"));
            builder.AppendLine();

            return builder.ToString();
        }

        private static string FormatUnexpectedEvent(EventData eventData,
                                                    bool wasTrackedAsRead)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Unexpected Event:");

            object value;

            if (eventData.Properties.TryGetValue(EventGenerator.IdPropertyName, out value))
            {
                builder.AppendFormat("    Event Id: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.PartitionPropertyName, out value))
            {
                builder.AppendFormat("    Sent To Partition: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.SequencePropertyName, out value))
            {
                builder.AppendFormat("    Artificial Sequence: {0} ", value);
                builder.AppendLine();
            }

            if (eventData.Properties.TryGetValue(EventGenerator.PublishTimePropertyName, out value))
            {
                builder.AppendFormat("    Published: {0} ", ((DateTimeOffset)value).ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss:tt"));
                builder.AppendLine();
            }

            builder.AppendFormat("    Was in Read Events: {0} ", wasTrackedAsRead);
            builder.AppendLine();

            return builder.ToString();
        }
    }
}