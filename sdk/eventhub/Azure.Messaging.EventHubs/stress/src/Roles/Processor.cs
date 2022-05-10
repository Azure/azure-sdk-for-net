// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// using System;
// using System.Collections.Concurrent;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using Azure.Messaging.EventHubs;
// using Azure.Messaging.EventHubs.Consumer;
// using Azure.Messaging.EventHubs.Processor;
// using Azure.Storage.Blobs;
// using Azure.Messaging.EventHubs.Tests;

// namespace Azure.Messaging.EventHubs.Stress
// {
//     internal class Processor
//     {
//         private string _identifier { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=').ToUpperInvariant();

//         private int[] _partitionHandlerCalls { get; }

//         private Metrics _metrics { get; }

//         private ProcessorTestConfig _testConfiguration { get; }

//         private Func<ProcessEventArgs, Task> _processEventHandler { get; }

//         private Func<ProcessErrorEventArgs, Task> _processErrorHandler { get; }

//         public Processor(ProcessorTestConfig configuration,
//                          Metrics metrics,
//                          int partitionCount,
//                          Func<string, ProcessEventArgs, Task> processEventHandler,
//                          Func<ProcessErrorEventArgs, Task> processErrorHandler)
//         {
//             _testConfiguration = configuration;
//             _metrics = metrics;
//             _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();
//             _processErrorHandler = processErrorHandler;

//             _processEventHandler = async args =>
//             {
//                 var partitionIndex = int.Parse(args.Partition.PartitionId);

//                 try
//                 {
//                     // There should only be one active call for a given partition; track any concurrent calls for this partition
//                     // and report them as an error.

//                     var activeCalls = Interlocked.Increment(ref _partitionHandlerCalls[partitionIndex]);

//                     if (activeCalls > 1)
//                     {
//                         if (!args.Data.Properties.TryGetValue(nameof(EventGenerator), out var duplicateId))
//                         {
//                             duplicateId = "(unknown)";
//                         }

//                         //ErrorsObserved.Add(new InvalidOperationException($"The handler for processing events was invoked concurrently for processor: `{ _identifier }`,  partition: `{ args.Partition.PartitionId }`, event: `{ duplicateId }`.  Count: `{ activeCalls }`"));
//                     }

//                     await processEventHandler(_identifier, args).ConfigureAwait(false);
//                 }
//                 finally
//                 {
//                     // TODO: metrics.EventHandlerCalls.AddOrUpdate(Identifier, 1, (id, count) => count + 1);
//                     Interlocked.Decrement(ref _partitionHandlerCalls[partitionIndex]);
//                 }
//             };
//         }

//         public async Task Start(CancellationToken cancellationToken)
//         {
//             while (!cancellationToken.IsCancellationRequested)
//             {
//                 var options = new EventProcessorClientOptions
//                 {
//                     Identifier = _identifier,
//                     LoadBalancingStrategy = LoadBalancingStrategy.Greedy,

//                     RetryOptions = new EventHubsRetryOptions
//                     {
//                         TryTimeout = _testConfiguration.ReadTimeout
//                     }
//                 };

//                 var processor = default(EventProcessorClient);

//                 try
//                 {
//                     var storageClient = new BlobContainerClient(_testConfiguration.StorageConnectionString, _testConfiguration.BlobContainer);
//                     processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, _testConfiguration.EventHubsConnectionString, _testConfiguration.EventHub, options);

//                     processor.ProcessEventAsync += _processEventHandler;
//                     processor.ProcessErrorAsync += _processErrorHandler;

//                     await processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
//                     await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
//                 }
//                 catch (TaskCanceledException)
//                 {
//                     // No action needed.
//                 }
//                 catch (Exception ex) when
//                     (ex is OutOfMemoryException
//                     || ex is StackOverflowException
//                     || ex is ThreadAbortException)
//                 {
//                     throw;
//                 }
//                 catch (Exception)
//                 {
//                     //TODO: Interlocked.Increment(ref Metrics.ProcessorRestarted);
//                     // TODO: ErrorsObserved.Add(ex);
//                 }
//                 finally
//                 {
//                     // Because publishing was canceled at the same time as the processor,
//                     // wait a short bit to allow for time processing the newly published events.

//                     await Task.Delay(TimeSpan.FromMinutes(5)).ConfigureAwait(false);

//                     // Constrain stopping the processor, just in case it has issues.  It should not be allowed
//                     // to hang, it should be abandoned so that processing can restart.

//                     using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(25));

//                     try
//                     {
//                         if (processor != null)
//                         {
//                             await processor.StopProcessingAsync(cancellationSource.Token).ConfigureAwait(false);
//                         }
//                     }
//                     catch (Exception)
//                     {
//                         // TODO
//                         //Interlocked.Increment(ref _metrics.ProcessorRestarted);
//                         //ErrorsObserved.Add(ex);
//                     }

//                     processor.ProcessEventAsync -= _processEventHandler;
//                     processor.ProcessErrorAsync -= _processErrorHandler;
//                 }
//             }
//         }
//     }
// }