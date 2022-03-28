using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs.StressTests;

namespace ProcessorEmptyReadTest
{
    internal class Processor
    {
        private string Identifier { get; } = Guid.NewGuid().ToString();

        private Metrics Metrics { get; }

        private int[] PartitionHandlerCalls { get; }

        private ConcurrentBag<Exception> ErrorsObserved { get; }

        private TestConfiguration Configuration { get; }

        private Func<ProcessEventArgs, Task> ProcessEventHandler { get; }

        private Func<ProcessErrorEventArgs, Task> ProcessErrorHandler { get; }

        public Processor(TestConfiguration configuration,
                         Metrics metrics,
                         int partitionCount,
                         ConcurrentBag<Exception> errorsObserved,
                         Func<string, ProcessEventArgs, Task> processEventHandler,
                         Func<ProcessErrorEventArgs, Task> processErrorHandler)
        {
            Configuration = configuration;
            Metrics = metrics;
            PartitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();
            ErrorsObserved = errorsObserved;
            ProcessErrorHandler = processErrorHandler;

            ProcessEventHandler = async args =>
            {
                try
                {
                    var count = Interlocked.Increment(ref PartitionHandlerCalls[int.Parse(args.Partition.PartitionId)]);

                    if (count > 1)
                    {
                        if (!args.Data.Properties.TryGetValue(EventGenerator.IdPropertyName, out var duplicateId))
                        {
                            duplicateId = "(unknown)";
                        }

                        ErrorsObserved.Add(new InvalidOperationException($"The handler for processing events was invoked concurrently for processor: `{ Identifier }`,  partition: `{ args.Partition.PartitionId }`, event: `{ duplicateId }`.  Count: `{ count }`"));
                    }

                    await processEventHandler(Identifier, args);
                }
                finally
                {
                    Interlocked.Decrement(ref PartitionHandlerCalls[int.Parse(args.Partition.PartitionId)]);
                }
            };
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var options = new EventProcessorClientOptions
                {
                    Identifier = Identifier,
                    MaximumWaitTime = Configuration.ReadWaitTime,

                    RetryOptions = new EventHubsRetryOptions
                    {
                        TryTimeout = Configuration.ReadTimeout
                    }
                };

                var processor = default(EventProcessorClient);

                try
                {
                    var storageClient = new BlobContainerClient(Configuration.StorageConnectionString, Configuration.BlobContainer);
                    processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, Configuration.EventHubsConnectionString, Configuration.EventHub, options);

                    processor.ProcessEventAsync += ProcessEventHandler;
                    processor.ProcessErrorAsync += ProcessErrorHandler;

                    await processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                    await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
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
                    Interlocked.Increment(ref Metrics.ProcessorRestarted);
                    ErrorsObserved.Add(ex);
                }
                finally
                {
                    // Wait a short bit to allow for time processing the newly published events.

                    await Task.Delay(TimeSpan.FromMinutes(2)).ConfigureAwait(false);

                    // Constrain stopping the processor, just in case it has issues.  It should not be allowed
                    // to hang, it should be abandoned so that processing can restart.

                    using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(25));

                    try
                    {
                        if (processor != null)
                        {
                            await processor.StopProcessingAsync(cancellationSource.Token).ConfigureAwait(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Interlocked.Increment(ref Metrics.ProcessorRestarted);
                        ErrorsObserved.Add(ex);
                    }

                    processor.ProcessEventAsync -= ProcessEventHandler;
                    processor.ProcessErrorAsync -= ProcessErrorHandler;
                }
            }
        }
    }
}