// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample20_PerformancePatterns : ServiceBusLiveTestBase
    {
        [Test]
        public async Task BatchSend()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusBatchSend
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusSender sender = client.CreateSender(queueName);

                // The Queue is used here for illustration. In practice, you can
                // build the batch incrementally — there is no need to buffer all
                // messages up front before batching.
                var messages = new Queue<ServiceBusMessage>();
#if SNIPPET
                for (int i = 0; i < 1000; i++)
#else
                for (int i = 0; i < 50; i++)
#endif
                {
                    messages.Enqueue(new ServiceBusMessage($"Message {i}"));
                }

                // Send in batches that respect the service's maximum message size.
                while (messages.Count > 0)
                {
                    using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                    while (messages.Count > 0 && batch.TryAddMessage(messages.Peek()))
                    {
                        messages.Dequeue();
                    }

                    if (batch.Count == 0)
                    {
                        throw new InvalidOperationException("Message too large for an empty batch.");
                    }

                    await sender.SendMessagesAsync(batch);
                }
                #endregion
            }
        }

        [Test]
        public async Task ConcurrentSends()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusConcurrentSends
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusSender sender = client.CreateSender(queueName);

                var messages = new List<ServiceBusMessage>();
                for (int i = 0; i < 100; i++)
                {
                    messages.Add(new ServiceBusMessage($"Message {i}"));
                }

                // Send all messages concurrently. Each SendMessageAsync call initiates
                // an independent AMQP transfer, and Task.WhenAll waits for all of them.
                IEnumerable<Task> sendTasks = messages.Select(m => sender.SendMessageAsync(m));
                await Task.WhenAll(sendTasks);
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ProcessorMaxConcurrentCalls()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusProcessorMaxConcurrentCalls
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

                await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
                {
                    // Start with a value close to the processor count and tune based on
                    // testing. High ratios of concurrent tasks to processors cause thread
                    // pool contention and unpredictable stalls.
                    MaxConcurrentCalls = Environment.ProcessorCount,

                    // AutoCompleteMessages is true by default. Messages are completed
                    // automatically after the handler returns without throwing.
                    AutoCompleteMessages = true
                });

                processor.ProcessMessageAsync += async args =>
                {
                    Console.WriteLine($"Received: {args.Message.Body}");

                    // Simulate work.
                    await Task.Delay(TimeSpan.FromMilliseconds(100), args.CancellationToken);
                };

                processor.ProcessErrorAsync += args =>
                {
                    Console.WriteLine($"Error: {args.Exception.Message}");
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();

                try
                {
                    // Let the processor run for a while, then stop.
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
                finally
                {
                    await processor.StopProcessingAsync();
                }
                #endregion
            }
        }

        [Test]
        public async Task PrefetchCount()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusPrefetchCount
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 10);
#endif

                // Prefetch 50 messages. The client fetches the next batch in the
                // background while the application processes the current messages.
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
                {
                    PrefetchCount = 50
                });

                // Each call returns immediately from the local buffer if messages
                // have been prefetched, avoiding a network round-trip.
#if SNIPPET
                for (int i = 0; i < 200; i++)
#else
                for (int i = 0; i < 10; i++)
#endif
                {
                    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    if (message == null)
                    {
                        break;
                    }

                    Console.WriteLine($"Received: {message.Body}");

                    // Completing removes the message from the queue. If the lock expired
                    // while in the prefetch buffer, this call throws and the message is
                    // redelivered — ensure processing logic is idempotent.
                    await receiver.CompleteMessageAsync(message);
                }
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ProcessorPrefetchCount()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusProcessorPrefetchCount
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

                await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = Environment.ProcessorCount,
                    PrefetchCount = Environment.ProcessorCount * 3
                });

                processor.ProcessMessageAsync += async args =>
                {
                    Console.WriteLine($"Received: {args.Message.Body}");
                    await Task.Delay(TimeSpan.FromMilliseconds(100), args.CancellationToken);
                };

                processor.ProcessErrorAsync += args =>
                {
                    Console.WriteLine($"Error: {args.Exception.Message}");
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();

                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
                finally
                {
                    await processor.StopProcessingAsync();
                }
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task HighThroughputProcessor()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusHighThroughputProcessor
#if SNIPPET
                // The fully qualified Service Bus namespace, which is likely to be similar to
                // "{yournamespace}.servicebus.windows.net".
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

                await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
                {
                    // Start with a value close to the processor count. Increase only
                    // after testing confirms the host can sustain the concurrency without
                    // thread pool contention or lock expiration.
                    MaxConcurrentCalls = Environment.ProcessorCount * 2,

                    // Keep prefetch proportional to concurrent calls.
                    PrefetchCount = Environment.ProcessorCount * 4,

                    // Extend auto-lock renewal for long processing times.
                    MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(10)
                });

                processor.ProcessMessageAsync += async args =>
                {
                    Console.WriteLine($"Processing: {args.Message.MessageId}");
                    await Task.Delay(TimeSpan.FromMilliseconds(50), args.CancellationToken);
                };

                processor.ProcessErrorAsync += args =>
                {
                    Console.WriteLine($"Error: {args.Exception.Message}");
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();

                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
                finally
                {
                    await processor.StopProcessingAsync();
                }
                #endregion
            }
        }
    }
}
