// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
                await using var client = CreateClient(60);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = autoComplete,
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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
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
                var start = DateTime.UtcNow;
                await processor.StopProcessingAsync();
                var stop = DateTime.UtcNow;
                Assert.Less(stop - start, TimeSpan.FromSeconds(10));

                // we complete each task after one message being processed, so the total number of messages
                // processed should equal the number of threads, but it's possible that we may process a few more per thread.
                Assert.IsTrue(messageCt >= numThreads);
                Assert.IsTrue(messageCt <= messageSendCt, messageCt.ToString());
            }
        }

        [Test]
        [TestCase(1, false)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, true)]
        public async Task ProcessMessagesWithCustomIdentifier(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = CreateClient(60);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageSendCt);

                await sender.SendMessagesAsync(messageBatch);

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoCompleteMessages = autoComplete,
                    PrefetchCount = 20,
                    Identifier = "MyServiceBusProcessor"
                };
                await using var processor = client.CreateProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.Identifier, args.Identifier);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
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
                var start = DateTime.UtcNow;
                await processor.StopProcessingAsync();
                var stop = DateTime.UtcNow;
                Assert.Less(stop - start, TimeSpan.FromSeconds(10));

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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageSendCt);

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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageSendCt);

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
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageSendCt);

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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    bool messageLockLostRaised = false;
                    args.MessageLockLostAsync += (lockLostArgs) =>
                    {
                        messageLockLostRaised = true;
                        // no exception expected as we have stopped renewing the lock once the max duration has passed
                        Assert.IsNull(lockLostArgs.Exception);
                        return Task.CompletedTask;
                    };
                    var message = args.Message;
                    // wait until 5 seconds past the locked until time
                    await Task.Delay(message.LockedUntil.Subtract(DateTimeOffset.UtcNow).Add(TimeSpan.FromSeconds(5)));
                    var lockedUntil = message.LockedUntil;
                    if (!args.CancellationToken.IsCancellationRequested)
                    {
                        // only do the assertion if cancellation wasn't requested as otherwise
                        // the exception we would get is a TaskCanceledException rather than ServiceBusException
                        Assert.AreEqual(lockedUntil, message.LockedUntil);
                        Assert.IsTrue(args.MessageLockCancellationToken.IsCancellationRequested);
                        Assert.IsTrue(messageLockLostRaised);
                        ServiceBusException exception = await AsyncAssert.ThrowsAsync<ServiceBusException>(
                            async () => await args.CompleteMessageAsync(message, args.CancellationToken));
                        Assert.AreEqual(ServiceBusFailureReason.MessageLockLost, exception.Reason);
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
                // greater or equal because the same message may be received multiple times
                Assert.GreaterOrEqual(messageCt, numThreads);
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                int numMessages = 100;
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, numMessages);

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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

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

                var receiver = CreateNoRetryClient().CreateReceiver(scope.QueueName);
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
            await using var client = CreateClient();
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
            await using var client = CreateClient();
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
                await using var client = CreateClient();

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
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync();
                Assert.IsNull(msg);
            }
        }

        [Test]
        public async Task StopProcessingAdheresToTokenSLA()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                // very long timeout
                await using var client = CreateClient(tryTimeout: 120);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = true,
                });
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    tcs.TrySetResult(true);
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await Task.Delay(10000); // wait long enough to be hanging in the next receive on the empty queue

                using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                var start = DateTime.UtcNow;
                await processor.StopProcessingAsync(cancellationTokenSource.Token);
                var stop = DateTime.UtcNow;

                Assert.That(stop - start, Is.EqualTo(TimeSpan.FromSeconds(3)).Within(TimeSpan.FromSeconds(3)));
            }
        }

        [Test]
        public async Task StopProcessingAllowsCallbackToComplete()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(10));
                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = true,
                    MaxConcurrentCalls = 10
                });
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                int messageCount = 0;
                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref messageCount);
                    if (count == 10)
                    {
                        tcs.TrySetResult(true);
                    }

                    await Task.Delay(TimeSpan.FromSeconds(10));
                    await args.CompleteMessageAsync(args.Message);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                // call stop processing as soon as the callback is invoked but before it is done processing
                await processor.StopProcessingAsync();

                var receiver = client.CreateReceiver(scope.QueueName);
                // poll for the lock duration to make sure that messages are actually gone rather than just locked
                var msg = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(30));
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
                enableSession: false,
                lockDuration: ShortLockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
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
                var msg = await receiver.ReceiveMessageAsync(ShortLockDuration);
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

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task ProcessorStopsWhenClientIsClosed(int maxConcurrent)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var errorCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                // Create the client and seed the queue with some messages to process.

                await using var client = CreateClient(60);
                await SendMessagesAsync(client, scope.QueueName, 100);

                // Create the processor and define the message handlers.

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = maxConcurrent,
                    AutoCompleteMessages = true,
                    PrefetchCount = 20
                });

                Task processMessageAsync(ProcessMessageEventArgs args)
                {
                    // If any message is dispatched for processing, then the
                    // processor is actively reading from the Service Bus
                    // service and should react to the client being closed.

                    messageCompletionSource.TrySetResult(true);
                    return Task.CompletedTask;
                }

                Task processErrorAsync(ProcessErrorEventArgs args)
                {
                    // If the client is closed, an exception should be thrown
                    // for the disposed connection.  This is the condition that
                    // should set the completion source.

                    if ((args.Exception is ObjectDisposedException ex)
                        && ex.ObjectName == nameof(ServiceBusConnection)
                        && ex.Message.StartsWith(Resources.DisposedConnectionMessageProcessorMustStop))
                    {
                        errorCompletionSource.TrySetResult(true);
                    }

                    return Task.CompletedTask;
                }

                try
                {
                    processor.ProcessMessageAsync += processMessageAsync;
                    processor.ProcessErrorAsync += processErrorAsync;

                    // Set a cancellation source to use as a safety timer to prevent a
                    // potential test hang; this should not trigger if things are
                    // working correctly.

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(10));

                    // Start processing and wait for a message.

                    await processor.StartProcessingAsync(cancellationSource.Token);
                    await messageCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                    // Now that it's been confirmed that the processor is interacting with the
                    // Service Bus service close the client.

                    await client.DisposeAsync();
                    await errorCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                    // The processor surfaced the expected exception.  Verify that it has stopped
                    // processing and cancellation wasn't triggered.  This is a non-deterministic
                    // operation, so allow for a few attempts.

                    var attemptsRemaining = 5;

                    while ((attemptsRemaining > 0) && (processor.IsProcessing))
                    {
                        --attemptsRemaining;
                        await Task.Delay(500, cancellationSource.Token);
                    }

                    Assert.IsFalse(processor.IsProcessing, "The processor should have stopped when the client was closed.");
                }
                catch (OperationCanceledException)
                {
                    Assert.Fail("The cancellation token should not have been triggered.");
                }
                finally
                {
                    if (processor.IsProcessing)
                    {
                        await processor.StopProcessingAsync();
                    }

                    processor.ProcessMessageAsync -= processMessageAsync;
                    processor.ProcessErrorAsync -= processErrorAsync;
                }
            }
        }

        [Test]
        public async Task ProcessDlq()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                // send some messages
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                // receive the messages
                var receiver = client.CreateReceiver(scope.QueueName);
                int remaining = messageCount;

                // move the messages to the DLQ
                while (remaining > 0)
                {
                    var messages = await receiver.ReceiveMessagesAsync(remaining);
                    remaining -= messages.Count;
                    foreach (ServiceBusReceivedMessage message in messages)
                    {
                        await receiver.DeadLetterMessageAsync(message);
                    }
                }

                // process the DLQ
                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    SubQueue = SubQueue.DeadLetter
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var ct = Interlocked.Increment(ref receivedCount);
                    if (ct == messageCount)
                    {
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task AutoLockRenewalContinuesUntilProcessingCompletes()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 10
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    await Task.Delay(lockDuration.Add(lockDuration));
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanManuallyRenewMessageLock()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 10,
                    MaxAutoLockRenewalDuration = TimeSpan.Zero
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    var initialLockedUntil = args.Message.LockedUntil;
                    // introduce a small delay so that the service honors the renewal request
                    await Task.Delay(500);
                    await args.RenewMessageLockAsync(args.Message);
                    Assert.Greater(args.Message.LockedUntil, initialLockedUntil);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanUpdateConcurrency()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 200;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 20
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        await args.AbandonMessageAsync(args.Message);
                    }

                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    // decrease concurrency
                    if (count == 100)
                    {
                        processor.UpdateConcurrency(1);
                        Assert.AreEqual(1, processor.MaxConcurrentCalls);
                    }

                    // increase concurrency
                    if (count == 150)
                    {
                        Assert.LessOrEqual(processor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 1);
                        processor.UpdateConcurrency(10);
                        Assert.AreEqual(10, processor.MaxConcurrentCalls);
                    }
                    if (count == 175)
                    {
                        Assert.GreaterOrEqual(processor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 5);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanUpdatePrefetchCount()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 200;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 20
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        await args.AbandonMessageAsync(args.Message);
                    }

                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    // decrease prefetch
                    if (count == 100)
                    {
                        processor.UpdatePrefetchCount(1);
                        Assert.AreEqual(20, processor.MaxConcurrentCalls);
                        Assert.AreEqual(1, processor.PrefetchCount);
                    }

                    // increase prefetch
                    if (count == 150)
                    {
                        Assert.LessOrEqual(processor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 20);
                        processor.UpdatePrefetchCount(10);
                        Assert.AreEqual(20, processor.MaxConcurrentCalls);
                        Assert.AreEqual(10, processor.PrefetchCount);
                    }
                    if (count == 175)
                    {
                        Assert.GreaterOrEqual(processor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 15);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task StopProcessingDoesNotResultInRedeliveredMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                await using var sender = client.CreateSender(scope.QueueName);

                int receivedCount = 0;
                int messageCount = 10;

                var sendTask = SendMessages();
                await ReceiveMessages(true);
                await ReceiveMessages(false);
                await sendTask;
                Assert.AreEqual(messageCount, receivedCount);

                async Task SendMessages()
                {
                    for (int i = 0; i < messageCount; i++)
                    {
                        await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
                        // send in 1 sec increments to intersperse receives and sends
                        await Task.Delay(1000);
                    }
                }

                async Task ReceiveMessages(bool first)
                {
                    bool received = false;
                    await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                    {
                        MaxConcurrentCalls = 5,
                    });
                    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                    processor.ProcessMessageAsync += async args =>
                    {
                        await args.CompleteMessageAsync(args.Message);

                        // add a 2 second delay to give the receive link more time to have messages delivered
                        await Task.Delay(2000);

                        try
                        {
                            Assert.AreEqual(1, args.Message.DeliveryCount);
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }

                        int count = Interlocked.Increment(ref receivedCount);
                        received = true;
                        if (first || count == messageCount)
                        {
                            tcs.TrySetResult(true);
                        }
                    };

                    await processor.StartProcessingAsync();
                    await tcs.Task;
                    Assert.IsTrue(received);
                    await processor.StopProcessingAsync();
                }
            }
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public async Task CanReceiveMessagesFromCallback(bool manualComplete, bool manualRenew)
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 5
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref receivedCount);

                    if (count == 1)
                    {
                        ProcessorReceiveActions receiveActions = args.GetReceiveActions();
                        var received = await receiveActions.ReceiveMessagesAsync(messageCount);
                        Assert.IsNotEmpty(received);
                        count = Interlocked.Add(ref receivedCount, received.Count);

                        var peeked = await receiveActions.PeekMessagesAsync(2);
                        Assert.AreEqual(2, peeked.Count);
                        var lastSeq = peeked[1].SequenceNumber;
                        var nextPeek = await receiveActions.PeekMessagesAsync(1);
                        Assert.Greater(nextPeek.Single().SequenceNumber, lastSeq);

                        var peekWithSeq = await receiveActions.PeekMessagesAsync(1, fromSequenceNumber: lastSeq);
                        Assert.AreEqual(lastSeq, peekWithSeq.Single().SequenceNumber);
                    }

                    if (manualRenew)
                    {
                        await args.RenewMessageLockAsync(args.Message);
                    }

                    // lock renewal should happen for messages received in callback
                    await Task.Delay(lockDuration.Add(lockDuration));

                    if (manualComplete)
                    {
                        await args.CompleteMessageAsync(args.Message);
                    }

                    if (count == messageCount)
                    {
                        tcs.TrySetResult(true);
                    }
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync();
                // all messages should have been completed
                Assert.IsNull(msg);
            }
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public async Task CanReceiveDeferredMessagesFromCallback(bool manualComplete, bool manualRenew)
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 5
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();
                ProcessMessageEventArgs capturedArgs = null;
                ServiceBusReceivedMessage receivedDeferredMessage = null;

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    capturedArgs ??= args;

                    var count = Interlocked.Increment(ref receivedCount);

                    // defer first message
                    if (count == 1)
                    {
                        await args.DeferMessageAsync(args.Message);
                        receivedDeferredMessage = (await args.GetReceiveActions().ReceiveDeferredMessagesAsync(new[] {args.Message.SequenceNumber})).Single();
                    }
                    else if (manualRenew)
                    {
                        await args.RenewMessageLockAsync(args.Message);
                    }

                    // lock renewal should happen for messages received in callback
                    await Task.Delay(lockDuration.Add(lockDuration));

                    if (manualComplete)
                    {
                        // do not attempt to complete the deferred message as we will only be able to complete it
                        // after receiving using ReceiveDeferredMessageAsync
                        if (count > 1)
                        {
                            await args.CompleteMessageAsync(args.Message);
                        }
                        else
                        {
                            await args.CompleteMessageAsync(receivedDeferredMessage);
                        }
                    }

                    if (count == messageCount)
                    {
                        tcs.TrySetResult(true);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;

                // verify args cannot be used to receive messages outside of callback scope
                await AsyncAssert.ThrowsAsync<InvalidOperationException>(async () => await capturedArgs.GetReceiveActions().ReceiveMessagesAsync(10));

                await processor.CloseAsync();

                // all messages should have been completed
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync();
                Assert.IsNull(msg);

                Assert.That(
                    async () => await receiver.ReceiveDeferredMessagesAsync(new[] {receivedDeferredMessage.SequenceNumber}),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                        .EqualTo(ServiceBusFailureReason.MessageNotFound));
            }
        }

        [Test]
        public async Task MessagesReceivedFromCallbackAbandonedWhenException()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;
                ConcurrentDictionary<long, byte> sequenceNumbers = new();

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 1
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref receivedCount);

                    // defer first two messages
                    if (count <= 2)
                    {
                        await args.DeferMessageAsync(args.Message);
                        sequenceNumbers[args.Message.SequenceNumber] = default;
                    }

                    if (count == 2)
                    {
                        var additionalMessages = await args.GetReceiveActions().ReceiveMessagesAsync(2);
                        Interlocked.Add(ref receivedCount, additionalMessages.Count);
                    }

                    if (count == messageCount)
                    {
                        tcs.TrySetResult(true);
                    }

                    throw new Exception("User exception message");
                }

                Task ProcessError(ProcessErrorEventArgs eventArgs)
                {
                    if (!eventArgs.Exception.Message.Contains("User exception message"))
                    {
                        Assert.Fail(eventArgs.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ProcessError;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();

                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions {ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});
                int remaining = messageCount;

                // all messages should have been abandoned, so we should be able to receive them right away
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                tokenSource.CancelAfter(TimeSpan.FromSeconds(5));

                while (!tokenSource.IsCancellationRequested && remaining > 0)
                {
                    try
                    {
                        var receivedMessages = await receiver.ReceiveMessagesAsync(remaining, TimeSpan.FromSeconds(5), tokenSource.Token);
                        remaining -= receivedMessages.Count;

                        if (sequenceNumbers.Keys.Count > 0)
                        {
                            receivedMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers.Keys, tokenSource.Token);
                            sequenceNumbers.Clear();
                            remaining -= receivedMessages.Count;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }
                Assert.AreEqual(0, remaining);
            }
        }

        [Test]
        public async Task MessageLockLostEventRaisedAfterExpiration()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxAutoLockRenewalDuration = TimeSpan.Zero,
                    AutoCompleteMessages = false
                });

                var tcs = new TaskCompletionSource<bool>();
                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    bool messageLockLostRaised = false;
                    args.MessageLockLostAsync += (lockLostArgs) =>
                    {
                        Assert.AreEqual(args.Message.LockToken, lockLostArgs.Message.LockToken);
                        messageLockLostRaised = true;
                        return Task.CompletedTask;
                    };
                    await args.CompleteMessageAsync(args.Message);
                    await Task.Delay(lockDuration.Add(lockDuration));
                    try
                    {
                        Assert.IsTrue(messageLockLostRaised);
                        Assert.IsTrue(args.MessageLockCancellationToken.IsCancellationRequested);
                        Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    }
                    finally
                    {
                        tcs.SetResult(true);
                    }
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();
            }
        }

        /// <summary>
        /// Because the message lock renewal occurs on the mgmt link, even when the connection drops, message lock renewal continues
        /// successfully. This is in contrast to session messages where the lock renewal requires the session to be locked,
        /// so when the connection drops, the session is lost and the lock renewal fails.
        /// </summary>
        [Test]
        public async Task MessageLockLostEventNotRaisedAfterConnectionDropped()
        {
            var lockDuration = TimeSpan.FromSeconds(30);
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName);

                var tcs = new TaskCompletionSource<bool>();
                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    bool messageLockLostRaised = false;
                    args.MessageLockLostAsync += (lockLostArgs) =>
                    {
                        messageLockLostRaised = true;
                        Assert.AreEqual(args.Message.LockToken, lockLostArgs.Message.LockToken);
                        var lockLostException = lockLostArgs.Exception as ServiceBusException;
                        Assert.IsNotNull(lockLostException);
                        Assert.AreEqual(ServiceBusFailureReason.MessageLockLost, lockLostException.Reason);
                        return Task.CompletedTask;
                    };
                    SimulateNetworkFailure(client);
                    await Task.Delay(lockDuration.Add(lockDuration));
                    try
                    {
                        Assert.IsFalse(messageLockLostRaised);
                        Assert.IsFalse(args.MessageLockCancellationToken.IsCancellationRequested);
                        Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    }
                    finally
                    {
                        tcs.SetResult(true);
                    }
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();
            }
        }

        [Test]
        public async Task MessageLockLostEventNotRaisedAfterProcessMessageCompletes()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount));

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    MaxAutoLockRenewalDuration = TimeSpan.Zero,
                    AutoCompleteMessages = false
                });

                var tcs = new TaskCompletionSource<bool>();
                bool messageLockLostRaised = false;
                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    args.MessageLockLostAsync += (lockLostArgs) =>
                    {
                        messageLockLostRaised = true;
                        return Task.CompletedTask;
                    };
                    await args.CompleteMessageAsync(args.Message);
                    Assert.IsFalse(messageLockLostRaised);
                    Assert.IsFalse(args.MessageLockCancellationToken.IsCancellationRequested);
                    Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    tcs.SetResult(true);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await Task.Delay(lockDuration.Add(lockDuration));
                Assert.IsFalse(messageLockLostRaised);
                await processor.CloseAsync();
            }
        }
    }
}
