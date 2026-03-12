// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample21_ExceptionHandling : ServiceBusLiveTestBase
    {
        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task StructuredExceptionHandling()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusStructuredExceptionHandling
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string queueName = scope.QueueName;
                await using var client = CreateClient();
#endif
                ServiceBusSender sender = client.CreateSender(queueName);

                try
                {
                    await sender.SendMessageAsync(new ServiceBusMessage("Hello"));
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceBusy)
                {
                    // Transient: the service is temporarily overloaded. Back off and let the caller decide whether to retry.
                    Console.WriteLine("Service is busy, backing off for 10 seconds...");
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                {
                    // Transient: the operation timed out. Retry with a longer timeout or backoff.
                    Console.WriteLine($"Operation timed out: {ex.Message}");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceCommunicationProblem)
                {
                    // Transient: network-level failure. Check connectivity and retry.
                    Console.WriteLine($"Communication problem: {ex.Message}");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.QuotaExceeded)
                {
                    // Capacity: the namespace or entity has hit its size or throughput limit.
                    // Do not retry immediately — either wait for space to free up or scale the namespace.
                    Console.WriteLine($"Quota exceeded: {ex.Message}");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageSizeExceeded)
                {
                    // Permanent: the message payload is too large for the tier. This will never succeed
                    // without reducing the message size or upgrading to Premium.
                    Console.WriteLine($"Message too large ({ex.Message}). Reduce payload size.");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
                {
                    // Permanent: the queue, topic, or subscription does not exist. Check the entity name
                    // and ensure it has been provisioned.
                    Console.WriteLine($"Entity not found: {ex.Message}");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityDisabled)
                {
                    // Permanent: the entity is disabled in the portal or via management API.
                    Console.WriteLine($"Entity is disabled: {ex.Message}");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
                {
                    // Permanent: attempted to create an entity that already exists.
                    Console.WriteLine($"Entity already exists: {ex.Message}");
                }
                catch (ServiceBusException ex)
                {
                    // Catch-all for any other ServiceBusFailureReason (GeneralError, MessageNotFound, etc.).
                    Console.WriteLine($"Service Bus error ({ex.Reason}): {ex.Message}");
                    Console.WriteLine($"Is transient: {ex.IsTransient}");
                }
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task LockExceptionHandling()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusLockExceptionHandling
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string queueName = scope.QueueName;
                await using var client = CreateClient();
#endif
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();

                try
                {
                    // Simulate slow processing that might exceed the lock duration.
                    // ProcessMessageAsync represents your application logic (defined elsewhere).
                    await ProcessMessageAsync(message);

                    // Ensure processing is idempotent — if the lock expires before settlement,
                    // the message will be redelivered and processed again. Common strategies
                    // include deduplication checks and upsert semantics.
                    // See https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement
                    await receiver.CompleteMessageAsync(message);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
                {
                    // The lock on this specific message has expired. Another receiver may
                    // pick it up and reprocess it. Do not attempt to complete or abandon —
                    // the lock token is no longer valid.
                    Console.WriteLine($"Message lock lost for MessageId={message.MessageId}. " +
                        "The message will be redelivered.");
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.SessionLockLost)
                {
                    // The lock on the entire session has expired. All messages received
                    // under this session lock are now invalid. Close the session receiver
                    // and re-accept the session to continue processing.
                    //
                    // Note: SessionLockLost only applies when using session-enabled receivers
                    // (via AcceptNextSessionAsync). It is shown here alongside MessageLockLost
                    // for completeness.
                    Console.WriteLine($"Session lock lost for SessionId={message.SessionId}. " +
                        "Re-accept the session to continue.");
                }
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task ProcessorErrorHandler()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusProcessorErrorHandler
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string queueName = scope.QueueName;
                await using var client = CreateClient();
#endif

                await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 5,
                    AutoCompleteMessages = false
                });

                // configure the message and error handler to use
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                async Task MessageHandler(ProcessMessageEventArgs args)
                {
                    try
                    {
                        await ProcessMessageAsync(args.Message);
                    }
                    catch (Exception ex)
                    {
                        // Application-level processing failure. Abandon the message so it
                        // can be retried (up to the entity's MaxDeliveryCount).
                        Console.WriteLine($"Processing failed: {ex.Message}");

                        try
                        {
                            await args.AbandonMessageAsync(args.Message);
                        }
                        catch (ServiceBusException abandonEx)
                        {
                            Console.WriteLine($"Abandon failed for {args.Message.MessageId}: {abandonEx.Message}");
                        }

                        return;
                    }

                    // Processing succeeded — settle the message.
                    // Because lock loss causes redelivery, ensure your processing logic is
                    // idempotent — it should produce the same result if a message is processed
                    // more than once. Common strategies include deduplication checks and upsert
                    // semantics.
                    // See https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement
                    try
                    {
                        await args.CompleteMessageAsync(args.Message);
                    }
                    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
                    {
                        // Lock expired before settlement. The message will be redelivered.
                        Console.WriteLine($"Lock lost for {args.Message.MessageId}, will be redelivered.");
                    }
                    catch (ServiceBusException ex)
                    {
                        // Settlement failed for another reason — log for diagnostics.
                        Console.WriteLine($"Settlement failed for {args.Message.MessageId} ({ex.Reason}): {ex.Message}");
                    }
                }

                Task ErrorHandler(ProcessErrorEventArgs args)
                {
                    // Infrastructure-level errors: connection drops, auth failures, etc.
                    Console.WriteLine($"Error source: {args.ErrorSource}");
                    Console.WriteLine($"Entity path: {args.EntityPath}");
                    Console.WriteLine($"Namespace: {args.FullyQualifiedNamespace}");

                    if (args.Exception is ServiceBusException sbEx)
                    {
                        Console.WriteLine($"Reason: {sbEx.Reason}, IsTransient: {sbEx.IsTransient}");

                        if (sbEx.IsTransient)
                        {
                            // The processor retries automatically for transient errors.
                            Console.WriteLine("Transient error — processor will retry automatically.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Non-ServiceBus exception: {args.Exception}");
                    }

                    return Task.CompletedTask;
                }

                await processor.StartProcessingAsync();

                // Let the processor run. It handles retries internally for transient errors.
                await Task.Delay(TimeSpan.FromMinutes(5));
                await processor.StopProcessingAsync();
                #endregion
            }
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task RetryWithIsTransient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusRetryWithIsTransient
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string queueName = scope.QueueName;
                await using var client = CreateClient();
#endif
                ServiceBusSender sender = client.CreateSender(queueName);

                int maxRetries = 3;
                int attempt = 0;

                while (attempt < maxRetries)
                {
                    try
                    {
                        await sender.SendMessageAsync(new ServiceBusMessage("Retry example"));
                        break; // Success — exit the loop.
                    }
                    catch (ServiceBusException ex) when (ex.IsTransient)
                    {
                        attempt++;
                        Console.WriteLine($"Transient error (attempt {attempt}/{maxRetries}): {ex.Message}");

                        if (attempt == maxRetries)
                        {
                            Console.WriteLine("Max retries reached. Giving up.");
                            throw;
                        }

                        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt))); // Exponential backoff.
                    }
                    catch (ServiceBusException ex)
                    {
                        // Non-transient — retrying won't help.
                        Console.WriteLine($"Permanent error ({ex.Reason}): {ex.Message}");
                        throw;
                    }
                }
                #endregion
            }
        }

        private static Task ProcessMessageAsync(ServiceBusReceivedMessage message)
        {
            Console.WriteLine($"Processing message: {message.MessageId}");
            return Task.CompletedTask;
        }
    }
}
