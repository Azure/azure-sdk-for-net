// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample18_LongRunningProcessing : ServiceBusLiveTestBase
    {
        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task LongRunningProcessing()
        {
            #region Snippet:ServiceBusLongRunningProcessing
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string queueName = "queue";
#endif

            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

            await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
            {
                // The SDK renews the lock in the background for up to this duration.
                // Set it to at least the longest expected processing time, with some margin.
                MaxAutoLockRenewalDuration = TimeSpan.FromHours(2),

                // Disable auto-complete so we settle messages explicitly after processing succeeds.
                AutoCompleteMessages = false,

                // Process one message at a time. Increase for higher throughput
                // if the processing is I/O-bound rather than CPU-bound.
                MaxConcurrentCalls = 1
            });

            processor.ProcessMessageAsync += async args =>
            {
                Console.WriteLine($"Processing message: {args.Message.MessageId}");

                // Simulate long-running work (e.g., video transcoding, report generation).
                await Task.Delay(TimeSpan.FromMinutes(10), args.CancellationToken);

                // Complete the message only after processing succeeds.
                await args.CompleteMessageAsync(args.Message);
                Console.WriteLine($"Completed message: {args.Message.MessageId}");
            };

            processor.ProcessErrorAsync += args =>
            {
                Console.WriteLine($"Error source: {args.ErrorSource}");
                Console.WriteLine($"Error: {args.Exception}");
                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync();

            // Processing runs in the background. Press any key to stop.
            Console.ReadKey();
            await processor.StopProcessingAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task LongRunningWithLockLostHandler()
        {
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";

            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string queueName = "queue";

            await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

            await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
            {
                MaxAutoLockRenewalDuration = TimeSpan.FromHours(2),
                AutoCompleteMessages = false,
            });

            processor.ProcessErrorAsync += args =>
            {
                Console.WriteLine(args.Exception);
                return Task.CompletedTask;
            };

            #region Snippet:ServiceBusLongRunningWithLockLostHandler
            processor.ProcessMessageAsync += async args =>
            {
                // Create a linked token that cancels both when the processor stops
                // and when the message lock is lost.
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

                try
                {
                    args.MessageLockLostAsync += LockLostHandler;

                    // Pass the linked token to your processing logic.
                    // When the lock is lost, the token is cancelled and processing stops cleanly.
                    await ProcessLongRunningJobAsync(args.Message, cts.Token);

                    // If cancellation was requested (lock lost or processor stopping),
                    // skip settlement and let the message be redelivered.
                    if (cts.IsCancellationRequested)
                    {
                        Console.WriteLine($"Skipping completion for message {args.Message.MessageId} " +
                                          "because the lock was lost. Message will be redelivered.");
                        return;
                    }

                    // Only settle if we still own the lock.
                    try
                    {
                        await args.CompleteMessageAsync(args.Message);
                    }
                    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
                    {
                        // The lock was lost between finishing processing and settlement.
                        Console.WriteLine($"Lock lost while completing message {args.Message.MessageId}. " +
                                          "Message will be redelivered.");
                    }
                }
                catch (OperationCanceledException) when (cts.IsCancellationRequested)
                {
                    // Lock was lost or the processor is stopping.
                    // Don't try to settle -- the broker will redeliver after the lock expires.
                    Console.WriteLine($"Processing cancelled for message {args.Message.MessageId}. " +
                                      "Message will be redelivered.");
                }
                finally
                {
                    // Remove the handler to avoid a memory leak.
                    args.MessageLockLostAsync -= LockLostHandler;
                }

                Task LockLostHandler(MessageLockLostEventArgs lockLostArgs)
                {
                    Console.WriteLine($"Lock lost for message {args.Message.MessageId}: {lockLostArgs.Exception}");
                    cts.Cancel();
                    return Task.CompletedTask;
                }
            };

#if SNIPPET
            static async Task ProcessLongRunningJobAsync(ServiceBusReceivedMessage message, CancellationToken cancellationToken)
            {
                // Your processing logic here. Check the token periodically
                // (or use it with async APIs) so cancellation is responsive.
                for (int step = 0; step < 100; step++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Simulate a processing step.
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                    Console.WriteLine($"  Step {step + 1}/100 for message {message.MessageId}");
                }
            }
#endif
            #endregion

            await processor.StartProcessingAsync();
            Console.ReadKey();
            await processor.StopProcessingAsync();
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task LongRunningWithReceiver()
        {
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string queueName = "queue";
#endif

            #region Snippet:ServiceBusLongRunningWithReceiver
#if SNIPPET
            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
            await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif

            await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
            if (message != null)
            {
                using var renewCts = new CancellationTokenSource();

                // Renew the lock in the background while processing.
                Task renewalTask = RenewLockPeriodicallyAsync(receiver, message, renewCts.Token);

                try
                {
                    // Process the message while the background task renews the lock.
                    await ProcessLongRunningJobAsync(message, CancellationToken.None);

                    // Settlement on success.
                    await receiver.CompleteMessageAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");

                    try
                    {
                        // Abandon so the message is available for redelivery immediately.
                        await receiver.AbandonMessageAsync(message);
                    }
                    catch (ServiceBusException sbEx) when (sbEx.Reason == ServiceBusFailureReason.MessageLockLost)
                    {
                        // Lock was lost -- the broker will redeliver automatically after it expires.
                        Console.WriteLine("Could not abandon message because the lock was lost.");
                    }
                }
                finally
                {
                    // Stop the renewal task.
                    renewCts.Cancel();
                    try { await renewalTask; }
                    catch (OperationCanceledException) { }
                    catch (ServiceBusException) { }
                }
            }

#if SNIPPET
            static async Task RenewLockPeriodicallyAsync(
                ServiceBusReceiver receiver,
                ServiceBusReceivedMessage message,
                CancellationToken cancellationToken)
            {
                // Renew before the lock expires. If the lock duration is 5 minutes
                // (the maximum), renew every 4 minutes to leave margin.
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromMinutes(4), cancellationToken);
                        await receiver.RenewMessageLockAsync(message, cancellationToken);
                        Console.WriteLine($"Renewed lock for message {message.MessageId}");
                    }
                    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
                    {
                        // Lock was lost -- stop renewing.
                        Console.WriteLine($"Lock lost for message {message.MessageId}. Stopping renewal.");
                        break;
                    }
                }
            }
#endif
            #endregion
        }

        private static Task ProcessLongRunningJobAsync(ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static Task RenewLockPeriodicallyAsync(ServiceBusReceiver receiver, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
