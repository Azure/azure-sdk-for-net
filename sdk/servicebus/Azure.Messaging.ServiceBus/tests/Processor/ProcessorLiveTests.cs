// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task ProcessEventNextSession(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                var messageSendCt = numThreads * 2;
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageSendCt);

                await sender.SendBatchAsync(messageBatch);

                var processor = client.GetProcessor(scope.QueueName);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.MaxConcurrentCalls = numThreads;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        await receiver.CompleteAsync(message);
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
                Assert.IsTrue(messageCt < messageSendCt);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task ReceiveStopProcessing(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                int numMessages = 100;
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, numMessages);

                await sender.SendBatchAsync(messageBatch);

                var processor = client.GetProcessor(scope.QueueName);
                int messageProcessedCt = 0;

                // stop processing halfway through
                int stopAfterMessagesCt = numMessages / 2;

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.MaxConcurrentCalls = numThreads;
                processor.ReceiveMode = ReceiveMode.ReceiveAndDelete;
                await processor.StartProcessingAsync();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    var currentCt = Interlocked.Increment(ref messageProcessedCt);
                    TestContext.Progress.WriteLine(currentCt);
                    if (currentCt == stopAfterMessagesCt)
                    {
                        // awaiting here would cause a deadlock
                        _ = processor.StopProcessingAsync();
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                }
                await tcs.Task;
                var receiver = client.GetReceiver(scope.QueueName, new ServiceBusReceiverOptions
                {
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        TryTimeout = TimeSpan.FromSeconds(5),
                    }
                });

                var receivedMessages = await receiver.ReceiveBatchAsync(numMessages);
                // can't assert on the exact amount processed due to threads that
                // are already in flight when calling StopProcessingAsync, but we can at least verify that there are remaining messages
                Assert.IsTrue(receivedMessages.Count > 0);
                Assert.IsTrue(messageProcessedCt < numMessages);

            }
        }

        [Test]
        public async Task OnMessageExceptionHandlerCalledTest()
        {
            var invalidQueueName = "nonexistentqueuename";
            var exceptionReceivedHandlerCalled = false;
            var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            ServiceBusProcessor processor = client.GetProcessor(invalidQueueName);

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
                Assert.AreEqual(processor.Identifier, args.Identifier);
                Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                Assert.AreEqual(ExceptionReceivedEventArgsAction.Receive, args.Action);
                Assert.AreEqual(processor.EntityName, args.EntityName);

                if (args.Exception is ServiceBusException sbException)
                {
                    if (sbException.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
                    {
                        exceptionReceivedHandlerCalled = true;
                        return Task.CompletedTask;
                    }
                }

                Assert.Fail($"Unexpected exception: {args.Exception}");
                return Task.CompletedTask;
            }

            try
            {
                await processor.StartProcessingAsync();
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed.TotalSeconds <= 10)
                {
                    if (exceptionReceivedHandlerCalled)
                    {
                        break;
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                Assert.True(exceptionReceivedHandlerCalled);
            }
            finally
            {
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task ProcessEvent(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                var processor = client.GetProcessor(scope.QueueName);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();

                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.MaxConcurrentCalls = numThreads;
                processor.UseSessions = true;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        var receiver = args.Receiver;
                        await receiver.CompleteAsync(message);
                        Interlocked.Increment(ref messageCt);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, receiver.SessionManager.SessionId);
                        Assert.IsNotNull(receiver.SessionManager.LockedUntilUtc);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        completionSources[setIndex].SetResult(true);
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();

                // there is only one message for each session, and one
                // thread for each session, so the total messages processed
                // should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task ProcessEventConsumesAllMessages(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var processor = client.GetProcessor(scope.QueueName);

                processor.UseSessions = true;
                processor.RetryOptions = new ServiceBusRetryOptions()
                {
                    // to prevent the receive batch from taking a long time when we
                    // expect it to fail
                    MaximumRetries = 0,
                    TryTimeout = TimeSpan.FromSeconds(5)
                };

                processor.MaxConcurrentCalls = numThreads;
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        await receiver.CompleteAsync(message);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, receiver.SessionManager.SessionId);
                        Assert.IsNotNull(receiver.SessionManager.LockedUntilUtc);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        if (ct == numThreads)
                        {
                            taskCompletionSource.SetResult(true);
                        }
                    }
                }
                await taskCompletionSource.Task;
                await processor.StopProcessingAsync();


                // we only give each thread enough time to process one message, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);

                // try receiving to verify empty
                // since all the messages are gone and we are using sessions, we won't actually
                // be able to open the Receive link
                Assert.That(async () => await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    options: new ServiceBusReceiverOptions
                    {
                        RetryOptions = new ServiceBusRetryOptions
                        {
                            TryTimeout = TimeSpan.FromSeconds(5),
                            MaximumRetries = 0
                        }
                    }), Throws.Exception);
            }
        }

        [Test]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulQueue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var exceptionReceivedHandlerCalled = false;
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var processor = client.GetProcessor(scope.QueueName);
                processor.UseSessions = true;
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                Task MessageHandler(ProcessMessageEventArgs args)
                {
                    return Task.CompletedTask;
                }

                Task ErrorHandler(ProcessErrorEventArgs args)
                {
                    Assert.NotNull(args);
                    Assert.NotNull(args.Exception);
                    if (args.Exception is InvalidOperationException)
                    {
                        exceptionReceivedHandlerCalled = true;
                    }
                    return Task.CompletedTask;
                }
                await processor.StartProcessingAsync();
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed.TotalSeconds <= 10)
                {
                    if (exceptionReceivedHandlerCalled)
                    {
                        break;
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(exceptionReceivedHandlerCalled);
            }
        }

        [Test]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulTopic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var exceptionReceivedHandlerCalled = false;
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var processor = client.GetProcessor(scope.TopicName, scope.SubscriptionNames.First());
                processor.UseSessions = true;
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                Task MessageHandler(ProcessMessageEventArgs args)
                {
                    return Task.CompletedTask;
                }

                Task ErrorHandler(ProcessErrorEventArgs args)
                {
                    Assert.NotNull(args);
                    Assert.NotNull(args.Exception);
                    if (args.Exception is InvalidOperationException)
                    {
                        exceptionReceivedHandlerCalled = true;
                    }
                    return Task.CompletedTask;
                }
                await processor.StartProcessingAsync();
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed.TotalSeconds <= 10)
                {
                    if (exceptionReceivedHandlerCalled)
                    {
                        break;
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(exceptionReceivedHandlerCalled);
            }
        }

        [Test]
        public async Task SettingPropertiesWhileProcessingThrows()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusProcessor processor = client.GetProcessor(scope.QueueName);
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.ProcessMessageAsync += MessageHandler;

                Task MessageHandler(ProcessMessageEventArgs args)
                {
                    return Task.CompletedTask;
                }
                await processor.StartProcessingAsync();

                Assert.That(() => processor.UseSessions = false, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.PrefetchCount = 10, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.SessionId = "sessionId", Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.ReceiveMode = ReceiveMode.PeekLock, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.RetryOptions = new ServiceBusRetryOptions(), Throws.InstanceOf<InvalidOperationException>());

                await processor.StopProcessingAsync();
            }
        }
    }
}
