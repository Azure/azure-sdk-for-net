// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class ProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, true)]
        public async Task ProcessEventNextSession(int numThreads, bool autoComplete)
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

                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
                };
                var processor = client.GetProcessor(scope.QueueName, options);
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
                        var receiver = args.Receiver;
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await receiver.CompleteAsync(message.LockToken);
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
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    ReceiveMode = ReceiveMode.ReceiveAndDelete
                };
                var processor = client.GetProcessor(scope.QueueName, options);
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

                var receiver = GetNoRetryClient().GetReceiver(scope.QueueName);
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
                Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                Assert.AreEqual(ExceptionReceivedEventArgsAction.Receive, args.Action);
                Assert.AreEqual(processor.EntityPath, args.EntityPath);

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
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, false)]
        public async Task ProcessEvent(int numThreads, bool autoComplete)
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
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
                };
                var processor = client.GetSessionProcessor(scope.QueueName, options);
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
                        var receiver = args.Receiver;
                        if (!autoComplete)
                        {
                            await receiver.CompleteAsync(message.LockToken);
                        }
                        Interlocked.Increment(ref messageCt);
                        sessions.TryRemove(message.SessionId, out bool _);
                        var session = receiver.GetSessionManager();
                        Assert.AreEqual(message.SessionId, session.SessionId);
                        Assert.IsNotNull(session.LockedUntil);
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
        [TestCase(1, true)]
        [TestCase(5, false)]
        [TestCase(10, true)]
        [TestCase(20, false)]
        public async Task ProcessEventConsumesAllMessages(int numThreads, bool autoComplete)
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
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
                };

                ServiceBusProcessor processor = GetNoRetryClient().GetSessionProcessor(scope.QueueName, options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await receiver.CompleteAsync(message.LockToken);
                        }
                        sessions.TryRemove(message.SessionId, out bool _);
                        var session = receiver.GetSessionManager();
                        Assert.AreEqual(message.SessionId, session.SessionId);
                        Assert.IsNotNull(session.LockedUntil);
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

                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);

                // try receiving to verify empty
                // since all the messages are gone and we are using sessions, we won't actually
                // be able to open the Receive link
                // only do this assertion when we complete the message ourselves,
                // otherwise the message completion may have been cancelled if it didn't finish
                // before calling StopProcessingAsync.


                if (!autoComplete)
                {
                    Assert.That(async () =>
                        await GetNoRetryClient().GetSessionReceiverAsync(scope.QueueName),
                        Throws.Exception);
                }
            }
        }

        [Test]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulQueue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var exceptionReceivedHandlerCalled = false;
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                var processor = client.GetSessionProcessor(scope.QueueName);
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
                var processor = client.GetSessionProcessor(scope.TopicName, scope.SubscriptionNames.First());
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
        [TestCase(1, true)]
        [TestCase(5, false)]
        [TestCase(10, true)]
        [TestCase(20, false)]
        public async Task Process_Event_SessionId(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                string sessionId = null;
                for (int i = 0; i < numThreads; i++)
                {
                    sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete,
                };

                var processor = client.GetSessionProcessor(
                    scope.QueueName,
                    options,
                    sessionId); // using the last sessionId from the loop

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await receiver.CompleteAsync(message);
                        }
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(sessionId, message.SessionId);
                        var session = receiver.GetSessionManager();
                        Assert.AreEqual(sessionId, session.SessionId);
                        Assert.IsNotNull(session.LockedUntil);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        tcs.SetResult(true);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();

                // only one message has the session id that we
                // configured the processor with
                Assert.AreEqual(1, messageCt);

                // we should have received messages from only the specified session
                Assert.AreEqual(numThreads - 1, sessions.Count);
            }
        }
    }
}
