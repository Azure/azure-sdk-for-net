using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.StressTests.EventProcessorTest
{
    internal class Processor
    {
        private string Identifier { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=').ToUpperInvariant();

        private int[] PartitionHandlerCalls { get; }

        private Metrics Metrics { get; }

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
                var partitionIndex = int.Parse(args.Partition.PartitionId);

                try
                {
                    // There should only be one active call for a given partition; track any concurrent calls for this partition
                    // and report them as an error.

                    var activeCalls = Interlocked.Increment(ref PartitionHandlerCalls[partitionIndex]);

                    if (activeCalls > 1)
                    {
                        if (!args.Data.Properties.TryGetValue(EventGenerator.IdPropertyName, out var duplicateId))
                        {
                            duplicateId = "(unknown)";
                        }

                        ErrorsObserved.Add(new InvalidOperationException($"The handler for processing events was invoked concurrently for processor: `{ Identifier }`,  partition: `{ args.Partition.PartitionId }`, event: `{ duplicateId }`.  Count: `{ activeCalls }`"));
                    }

                    await processEventHandler(Identifier, args).ConfigureAwait(false);
                }
                finally
                {
                    metrics.EventHandlerCalls.AddOrUpdate(Identifier, 1, (id, count) => count + 1);
                    Interlocked.Decrement(ref PartitionHandlerCalls[partitionIndex]);
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
                    LoadBalancingStrategy = LoadBalancingStrategy.Greedy,

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
                    // Because publishing was canceled at the same time as the processor,
                    // wait a short bit to allow for time processing the newly published events.

                    await Task.Delay(TimeSpan.FromMinutes(5)).ConfigureAwait(false);

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