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
using Azure.Messaging.EventHubs.StressTests;

namespace ProcessorEmptyReadTest
{
    internal class TestRun
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public bool IsRunning { get; private set; } = false;

        public Metrics Metrics { get; } = new Metrics();

        public ConcurrentBag<Exception> ErrorsObserved { get; } = new ConcurrentBag<Exception>();

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
                publishCancellationSource.Cancel();
                await publishingTask.ConfigureAwait(false);

                // Wait a bit after publishing has completed before signaling for
                // processing to be canceled, to allow any recently published
                // events to be read.

                await Task.Delay(TimeSpan.FromMinutes(2)).ConfigureAwait(false);

                processorCancellationSource.Cancel();
                await Task.WhenAll(processorTasks).ConfigureAwait(false);
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

        private Task ProcessEventHandler(string processorId, ProcessEventArgs args)
        {
            try
            {
                Interlocked.Increment(ref Metrics.TotalServiceOperations);
                Interlocked.Increment(ref Metrics.EventHandlerCalls);

                // If there was no event then there is nothing to do.

                if (!args.HasEvent)
                {
                    return Task.CompletedTask;
                }

                // We're not expecting any events; capture it as unexpected.

                Interlocked.Increment(ref Metrics.EventsRead);
                ErrorsObserved.Add(new EventHubsException(false, Configuration.EventHub, FormatUnexpectedEvent(args.Data, false), EventHubsException.FailureReason.GeneralError));
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

            return Task.CompletedTask;
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