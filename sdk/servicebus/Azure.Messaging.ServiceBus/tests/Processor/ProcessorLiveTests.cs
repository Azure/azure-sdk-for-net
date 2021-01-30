// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class ProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, true)]
        public async Task ProcessMessages(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = autoComplete,
                    MaxReceiveWaitTime = TimeSpan.FromSeconds(30),
                    PrefetchCount = 20
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await args.CompleteMessageAsync(message, args.CancellationToken);
                        }
                        Interlocked.Increment(ref messageCt);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        if (setIndex < numThreads)
                        {
                            completionSources[setIndex].SetResult(true);
                        }
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();

                // we complete each task after one message being processed, so the total number of messages
                // processed should equal the number of threads, but it's possible that we may process a few more per thread.
                Assert.IsTrue(messageCt >= numThreads);
                Assert.IsTrue(messageCt <= messageSendCt, messageCt.ToString());
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task UserSettlingWithAutoCompleteDoesNotThrow(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = true,
                    MaxReceiveWaitTime = TimeSpan.FromSeconds(30)
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        switch (numThreads)
                        {
                            case 1:
                                await args.CompleteMessageAsync(message, args.CancellationToken);
                                break;
                            case 5:
                                await args.AbandonMessageAsync(message);
                                break;
                            case 10:
                                await args.DeadLetterMessageAsync(message);
                                break;
                            case 20:
                                await args.DeferMessageAsync(message);
                                break;
                        }
                        Interlocked.Increment(ref messageCt);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        if (setIndex < numThreads)
                        {
                            completionSources[setIndex].SetResult(true);
                        }
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();

                // we complete each task after one message being processed, so the total number of messages
                // processed should equal the number of threads, but it's possible that we may process a few more per thread.
                Assert.IsTrue(messageCt >= numThreads);
                Assert.IsTrue(messageCt <= messageSendCt, messageCt.ToString());
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task AutoLockRenewalWorks(int numThreads)
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = false
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += args =>
                {
                    // If the connection drops due to network flakiness
                    // after the message is received but before we
                    // complete it, we will get a message lock
                    // lost exception. We are still able to verify
                    // that the message will be completed eventually.
                    var exception = (ServiceBusException)args.Exception;
                    if (!(args.Exception is ServiceBusException sbEx) ||
                    sbEx.Reason != ServiceBusFailureReason.MessageLockLost)
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                };
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var message = args.Message;
                    var lockedUntil = message.LockedUntil;
                    await Task.Delay(lockDuration);
                    await args.CompleteMessageAsync(message, args.CancellationToken);
                    Interlocked.Increment(ref messageCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                Assert.IsTrue(processor.IsProcessing);
                await processor.StopProcessingAsync();
                Assert.IsFalse(processor.IsProcessing);
                Assert.AreEqual(numThreads, messageCt);
            }
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(5, 0)]
        [TestCase(10, 1)]
        [TestCase(20, 1)]
        public async Task MaxAutoLockRenewalDurationRespected(int numThreads, int autoLockRenewalDuration)
        {
            var lockDuration = TimeSpan.FromSeconds(5);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = false,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(autoLockRenewalDuration)
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var message = args.Message;
                    // wait 2x lock duration in case the
                    // lock was renewed already
                    await Task.Delay(lockDuration.Add(lockDuration));
                    var lockedUntil = message.LockedUntil;
                    if (!args.CancellationToken.IsCancellationRequested)
                    {
                        // only do the assertion if cancellation wasn't requested as otherwise
                        // the exception we would get is a TaskCanceledException rather than ServiceBusException
                        Assert.AreEqual(lockedUntil, message.LockedUntil);
                        Assert.That(
                            async () => await args.CompleteMessageAsync(message, args.CancellationToken),
                            Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessageLockLost));
                        Interlocked.Increment(ref messageCt);
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        if (setIndex < numThreads)
                        {
                            completionSources[setIndex].SetResult(true);
                        }
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();
                Assert.AreEqual(numThreads, messageCt);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task CanStopProcessingFromHandler(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                int numMessages = 100;
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, numMessages);

                await sender.SendMessagesAsync(messageBatch);
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageProcessedCt = 0;

                // stop processing halfway through
                int stopAfterMessagesCt = numMessages / 2;

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var currentCt = Interlocked.Increment(ref messageProcessedCt);
                    if (currentCt == stopAfterMessagesCt)
                    {
                        // awaiting here would cause a deadlock
                        _ = processor.StopProcessingAsync();
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                }
                await tcs.Task;

                var receiver = GetNoRetryClient().CreateReceiver(scope.QueueName);
                var receivedMessages = await receiver.ReceiveMessagesAsync(numMessages);
                // can't assert on the exact amount processed due to threads that
                // are already in flight when calling StopProcessingAsync, but we can at least verify that there are remaining messages
                Assert.IsTrue(receivedMessages.Count > 0);
                Assert.IsTrue(messageProcessedCt < numMessages);
            }
        }

        [Test]
        public async Task OnMessageExceptionHandlerCalled()
        {
            var invalidQueueName = "nonexistentqueuename";
            var exceptionReceivedHandlerCalled = false;
            var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            ServiceBusProcessor processor = client.CreateProcessor(invalidQueueName);
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            processor.ProcessMessageAsync += ProcessMessage;
            processor.ProcessErrorAsync += ProcessErrors;

            Task ProcessMessage(ProcessMessageEventArgs args)
            {
                Assert.Fail("Unexpected exception: Did not expect messages here");
                return Task.CompletedTask;
            }

            Task ProcessErrors(ProcessErrorEventArgs args)
            {
                Assert.NotNull(args);
                Assert.NotNull(args.Exception);
                Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                Assert.AreEqual(ServiceBusErrorSource.Receive, args.ErrorSource);
                Assert.AreEqual(processor.EntityPath, args.EntityPath);

                if (args.Exception is ServiceBusException sbException)
                {
                    if (sbException.Reason == ServiceBusFailureReason.MessagingEntityNotFound ||
                        // There is a race condition wherein the service closes the connection when getting
                        // the request for the non-existent queue. If the connection is closed by the time
                        // our exception handling kicks in, we throw it as a ServiceCommunicationProblem
                        // as we cannot be sure the error wasn't due to the connection being closed,
                        // as opposed to what we know is the true cause in this case,
                        // MessagingEntityNotFound.
                        sbException.Reason == ServiceBusFailureReason.ServiceCommunicationProblem)
                    {
                        exceptionReceivedHandlerCalled = true;
                        taskCompletionSource.SetResult(true);
                        return Task.CompletedTask;
                    }
                }

                Assert.Fail($"Unexpected exception: {args.Exception}");
                return Task.CompletedTask;
            }
            await processor.StartProcessingAsync();
            await taskCompletionSource.Task;
            Assert.True(exceptionReceivedHandlerCalled);
            await processor.CloseAsync();

            Assert.That(
                async () => await processor.StartProcessingAsync(),
                Throws.InstanceOf<ObjectDisposedException>());
        }

        [Test]
        public async Task StartStopMultipleTimes()
        {
            var invalidQueueName = "nonexistentqueuename";
            var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            await using ServiceBusProcessor processor = client.CreateProcessor(invalidQueueName);
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var startTasks = new List<Task>
            {
                processor.StartProcessingAsync(),
                processor.StartProcessingAsync()
            };
            Assert.That(
                async () => await Task.WhenAll(startTasks),
                Throws.InstanceOf<InvalidOperationException>());

            var stopTasks = new List<Task>()
            {
                processor.StopProcessingAsync(),
                processor.StopProcessingAsync()
            };
            Assert.DoesNotThrowAsync(async () => await Task.WhenAll(stopTasks));
        }

        [Test]
        public async Task CannotAddHandlerWhileProcessorIsRunning()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = GetClient();

                await using var processor = client.CreateProcessor(scope.QueueName);

                Func<ProcessMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
                Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;
                processor.ProcessMessageAsync += eventHandler;
                processor.ProcessErrorAsync += errorHandler;

                await processor.StartProcessingAsync();

                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.InstanceOf<InvalidOperationException>());

                await processor.StopProcessingAsync();

                // Once stopped, the processor should allow handlers to be removed, and re-added.
                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);

                Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
            }
        }

        [Test]
        public async Task StopProcessingDoesNotCancelAutoCompletion()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = GetClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = true
                });
                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync();
                Assert.IsNull(msg);
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("Abandon")]
        [TestCase("Complete")]
        [TestCase("Defer")]
        [TestCase("Deadletter")]
        [TestCase("DeadletterOverload")]
        public async Task UserCallbackThrowingCausesMessageToBeAbandonedIfNotSettled(string settleMethod)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = GetClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = true
                });
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    switch (settleMethod)
                    {
                        case "Abandon":
                            await args.AbandonMessageAsync(args.Message);
                            break;
                        case "Complete":
                            await args.CompleteMessageAsync(args.Message);
                            break;
                        case "Defer":
                            await args.DeferMessageAsync(args.Message);
                            break;
                        case "Deadletter":
                            await args.DeadLetterMessageAsync(args.Message);
                            break;
                        case "DeadletterOverload":
                            await args.DeadLetterMessageAsync(args.Message, "reason");
                            break;
                    }
                    throw new TestException();
                }

                Task ExceptionHandler(ProcessErrorEventArgs args)
                {
                    tcs.SetResult(true);
                    Assert.IsNotNull(args.CancellationToken);
                    if (!(args.Exception is TestException))
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                if (settleMethod == "" || settleMethod == "Abandon")
                {
                    // if the message is abandoned (whether by user callback or
                    // by processor due to call back throwing), the message will
                    // be available to receive again immediately.
                    Assert.IsNotNull(msg);
                }
                else
                {
                    Assert.IsNull(msg);
                }
            }
        }
    }
}
