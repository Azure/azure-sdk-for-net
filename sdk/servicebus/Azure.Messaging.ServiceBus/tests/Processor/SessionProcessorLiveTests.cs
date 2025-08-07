// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CannotRemoveHandlersWhileProcessorIsRunning()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();

                await using var processor = client.CreateSessionProcessor(scope.QueueName);

                Func<ProcessSessionMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
                Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;
                Func<ProcessSessionEventArgs, Task> sessionhandler = eventArgs => Task.CompletedTask;
                processor.ProcessMessageAsync += eventHandler;
                processor.ProcessErrorAsync += errorHandler;
                processor.SessionInitializingAsync += sessionhandler;
                processor.SessionClosingAsync += sessionhandler;

                await processor.StartProcessingAsync();

                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.SessionInitializingAsync -= sessionhandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.SessionClosingAsync -= sessionhandler, Throws.InstanceOf<InvalidOperationException>());

                await processor.StopProcessingAsync();

                // Once stopped, the processor should allow handlers to be removed, and re-added.
                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);
                Assert.That(() => processor.SessionInitializingAsync -= sessionhandler, Throws.Nothing);
                Assert.That(() => processor.SessionClosingAsync -= sessionhandler, Throws.Nothing);

                Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
                Assert.That(() => processor.SessionInitializingAsync += sessionhandler, Throws.Nothing);
                Assert.That(() => processor.SessionClosingAsync += sessionhandler, Throws.Nothing);
            }
        }

        [Test]
        public async Task CannotAddHandlersWhileProcessorIsRunning()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();

                await using var processor = client.CreateSessionProcessor(scope.QueueName);

                Func<ProcessSessionMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
                Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;
                Func<ProcessSessionEventArgs, Task> sessionhandler = eventArgs => Task.CompletedTask;
                processor.ProcessMessageAsync += eventHandler;
                processor.ProcessErrorAsync += errorHandler;

                await processor.StartProcessingAsync();

                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.SessionInitializingAsync += sessionhandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => processor.SessionClosingAsync += sessionhandler, Throws.InstanceOf<InvalidOperationException>());

                await processor.StopProcessingAsync();

                // Once stopped, the processor should allow handlers to be removed, and re-added.
                Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);

                Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
                Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
                Assert.That(() => processor.SessionInitializingAsync += sessionhandler, Throws.Nothing);
                Assert.That(() => processor.SessionClosingAsync += sessionhandler, Throws.Nothing);
            }
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, false)]
        public async Task ProcessSessionMessage(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient(60);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, byte[]> sessions = new ConcurrentDictionary<string, byte[]>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                    sessions.TryAdd(sessionId, null);
                }
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = autoComplete
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;
                int sessionOpenEventCt = 0;
                int sessionCloseEventCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();

                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionInitializingAsync += SessionInitHandler;
                processor.SessionClosingAsync += SessionCloseHandler;

                await processor.StartProcessingAsync();

                async Task SessionInitHandler(ProcessSessionEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    Interlocked.Increment(ref sessionOpenEventCt);
                    byte[] state = ServiceBusTestUtilities.GetRandomBuffer(100);
                    await args.SetSessionStateAsync(new BinaryData(state));
                    sessions[args.SessionId] = state;
                }

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    Assert.AreEqual(processor.Identifier, args.Identifier);
                    Interlocked.Increment(ref sessionCloseEventCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                    sessions.TryRemove(args.SessionId, out byte[] state);
                    BinaryData getState = await args.GetSessionStateAsync();
                    Assert.AreEqual(state, getState.ToArray());
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.Identifier, args.Identifier);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    var message = args.Message;
                    if (!autoComplete)
                    {
                        await args.CompleteMessageAsync(message);
                    }
                    Interlocked.Increment(ref messageCt);
                    Assert.AreEqual(message.SessionId, args.SessionId);
                    Assert.IsNotNull(args.SessionLockedUntil);
                }

                await Task.WhenAll(completionSources.Select(source => source.Task));
                var start = DateTime.UtcNow;
                await processor.StopProcessingAsync();
                var stop = DateTime.UtcNow;
                Assert.Less(stop - start, TimeSpan.FromSeconds(15));

                // there is only one message for each session, and one
                // thread for each session, so the total messages processed
                // should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);

                Assert.AreEqual(numThreads, sessionOpenEventCt);
                Assert.AreEqual(sessionOpenEventCt, sessionCloseEventCt);
            }
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, false)]
        public async Task CanProcessWithCustomIdentifier(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient(60);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, byte[]> sessions = new ConcurrentDictionary<string, byte[]>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                    sessions.TryAdd(sessionId, null);
                }
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = autoComplete,
                    Identifier = "MySessionProcessor"
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;
                int sessionOpenEventCt = 0;
                int sessionCloseEventCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();

                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionInitializingAsync += SessionInitHandler;
                processor.SessionClosingAsync += SessionCloseHandler;

                await processor.StartProcessingAsync();

                async Task SessionInitHandler(ProcessSessionEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    Interlocked.Increment(ref sessionOpenEventCt);
                    byte[] state = ServiceBusTestUtilities.GetRandomBuffer(100);
                    await args.SetSessionStateAsync(new BinaryData(state));
                    sessions[args.SessionId] = state;
                }

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    Interlocked.Increment(ref sessionCloseEventCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                    sessions.TryRemove(args.SessionId, out byte[] state);
                    BinaryData getState = await args.GetSessionStateAsync();
                    Assert.AreEqual(state, getState.ToArray());
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    Assert.AreEqual(processor.EntityPath, args.EntityPath);
                    Assert.AreEqual(processor.FullyQualifiedNamespace, args.FullyQualifiedNamespace);
                    var message = args.Message;
                    if (!autoComplete)
                    {
                        await args.CompleteMessageAsync(message);
                    }
                    Interlocked.Increment(ref messageCt);
                    Assert.AreEqual(message.SessionId, args.SessionId);
                    Assert.IsNotNull(args.SessionLockedUntil);
                }

                await Task.WhenAll(completionSources.Select(source => source.Task));
                var start = DateTime.UtcNow;
                await processor.StopProcessingAsync();
                var stop = DateTime.UtcNow;
                Assert.Less(stop - start, TimeSpan.FromSeconds(15));

                // there is only one message for each session, and one
                // thread for each session, so the total messages processed
                // should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);

                Assert.AreEqual(numThreads, sessionOpenEventCt);
                Assert.AreEqual(sessionOpenEventCt, sessionCloseEventCt);
            }
        }

        [Test]
        public async Task CanDelayProcessingOfSession()
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, byte[]> sessions = new ConcurrentDictionary<string, byte[]>();
                for (int i = 0; i < 10; i++)
                {
                    var sessionId = "sessionId";
                    await sender.SendMessageAsync(new ServiceBusMessage()
                    {
                        MessageId = i.ToString(),
                        SessionId = sessionId
                    });
                    sessions.TryAdd(sessionId, null);
                }
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = lockDuration,
                    AutoCompleteMessages = false
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                bool receivedDelayMsg = false;
                List<string> receivedMessages = new List<string>();
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += args =>
                {
                    var exception = (ServiceBusException)args.Exception;
                    if (!(args.Exception is ServiceBusException sbEx) ||
                    sbEx.Reason != ServiceBusFailureReason.SessionLockLost)
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();
                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    receivedMessages.Add(args.Message.MessageId);
                    if (args.Message.MessageId == "5" && !receivedDelayMsg)
                    {
                        receivedDelayMsg = true;
                        // Simulate the situation where we need to delay processing on
                        // subsequent messages until this message can be handled.
                        await Task.Delay(lockDuration.Add(lockDuration));
                    }
                    else
                    {
                        await args.CompleteMessageAsync(args.Message);
                    }
                    if (args.Message.MessageId == "9")
                    {
                        tcs.SetResult(true);
                    }
                }

                await tcs.Task;
                Assert.AreEqual(
                    new List<string> { "0", "1", "2", "3", "4", "5", "5", "6", "7", "8", "9" },
                    receivedMessages);
                await processor.StopProcessingAsync();
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
               enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                }
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = true
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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
                    int count = Interlocked.Increment(ref messageCt);
                    Assert.AreEqual(message.SessionId, args.SessionId);
                    Assert.IsNotNull(args.SessionLockedUntil);
                    if (count == numThreads)
                    {
                        tcs.SetResult(true);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();

                // there is only one message for each session, and one
                // thread for each session, so the total messages processed
                // should equal the number of threads
                if (numThreads == 5)
                {
                    // when abandoning, it is possible we could process the same message more than once
                    // since the service will make the message available immediately
                    Assert.LessOrEqual(numThreads, messageCt);
                }
                else
                {
                    Assert.AreEqual(numThreads, messageCt);
                }
            }
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(5, false)]
        [TestCase(10, true)]
        [TestCase(20, false)]
        public async Task ProcessConsumesAllMessages(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = autoComplete,
                    PrefetchCount = 5
                };

                await using ServiceBusSessionProcessor processor = CreateNoRetryClient().CreateSessionProcessor(scope.QueueName, options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await args.CompleteMessageAsync(message);
                        }
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, args.SessionId);
                        Assert.IsNotNull(args.SessionLockedUntil);
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
                await processor.CloseAsync();

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
                        await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName),
                        Throws.Exception);
                }
            }
        }

        [Test]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionfulQueue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var exceptionReceivedHandlerCalled = false;
                await using var client = CreateClient();

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1
                });
                TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                Task MessageHandler(ProcessSessionMessageEventArgs args)
                {
                    return Task.CompletedTask;
                }

                Task ErrorHandler(ProcessErrorEventArgs args)
                {
                    Assert.IsNotNull(args.CancellationToken);
                    Assert.NotNull(args);
                    Assert.NotNull(args.Exception);
                    if (args.Exception is InvalidOperationException)
                    {
                        exceptionReceivedHandlerCalled = true;
                        taskCompletionSource.SetResult(true);
                    }
                    else
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }
                await processor.StartProcessingAsync();
                await taskCompletionSource.Task;
                Assert.True(exceptionReceivedHandlerCalled);
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionfulTopic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var exceptionReceivedHandlerCalled = false;
                await using var client = CreateClient();
                await using var processor = client.CreateSessionProcessor(scope.TopicName, scope.SubscriptionNames.First(), new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1
                });
                TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                Task MessageHandler(ProcessSessionMessageEventArgs args)
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
                        taskCompletionSource.SetResult(true);
                    }
                    else
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }
                await processor.StartProcessingAsync();
                await taskCompletionSource.Task;
                Assert.True(exceptionReceivedHandlerCalled);
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(5, false)]
        [TestCase(10, true)]
        [TestCase(20, false)]
        public async Task ProcessSessionMessageUsingNamedSessionId(int numThreads, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                string sessionId = null;
                for (int i = 0; i < numThreads; i++)
                {
                    sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = autoComplete,
                    // using the last sessionId from the loop
                    SessionIds = { sessionId }
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await args.CompleteMessageAsync(message);
                        }
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(sessionId, message.SessionId);
                        Assert.AreEqual(sessionId, args.SessionId);
                        Assert.IsNotNull(args.SessionLockedUntil);
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

        [Test]
        [TestCase(1, 1)]
        [TestCase(10, 2)]
        [TestCase(20, 3)]
        public async Task AutoLockRenewalWorks(int numThreads, int maxCallsPerSession)
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    ServiceBusTestUtilities.AddMessages(batch, 1, Guid.NewGuid().ToString());
                }

                await sender.SendMessagesAsync(batch);

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = false,
                    MaxConcurrentCallsPerSession = maxCallsPerSession,
                    SessionIdleTimeout = TimeSpan.FromSeconds(30)
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
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
                    // complete it, we will get a session lock
                    // lost exception. We are still able to verify
                    // that the message will be completed eventually.
                    if (!(args.Exception is ServiceBusException sbEx) ||
                        sbEx.Reason != ServiceBusFailureReason.SessionLockLost)
                    {
                        Assert.Fail(args.Exception.ToString());
                    }
                    return Task.CompletedTask;
                };
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var message = args.Message;
                    var lockedUntil = args.SessionLockedUntil;
                    await Task.Delay(lockDuration);
                    await args.CompleteMessageAsync(message, args.CancellationToken);
                    Interlocked.Increment(ref messageCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();
                Assert.AreEqual(numThreads, messageCt);
            }
        }

        [Test]
        public async Task CanManuallyRenewSessionLock()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                for (int i = 0; i < messageCount; i++)
                {
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(Guid.NewGuid().ToString()));
                }

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = messageCount,
                    MaxAutoLockRenewalDuration = TimeSpan.Zero
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    var initialLockedUntil = args.SessionLockedUntil;
                    // introduce a small delay so that the service honors the renewal request
                    await Task.Delay(500);
                    await args.RenewSessionLockAsync();
                    Assert.Greater(args.SessionLockedUntil, initialLockedUntil);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(5, 0)]
        [TestCase(10, 1)]
        [TestCase(20, 1)]
        public async Task MaxAutoLockRenewalDurationRespected(
            int numThreads,
            int autoLockRenewalDuration)
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    ServiceBusTestUtilities.AddMessages(batch, 1, Guid.NewGuid().ToString());
                }

                await sender.SendMessagesAsync(batch);

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = false,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(autoLockRenewalDuration)
                };
                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                await processor.StartProcessingAsync();

                Task SessionErrorHandler(ProcessErrorEventArgs eventArgs)
                {
                    var exception = (ServiceBusException)eventArgs.Exception;
                    if (ServiceBusFailureReason.SessionLockLost == exception.Reason)
                    {
                        if (eventArgs.ErrorSource != ServiceBusErrorSource.Receive &&
                            eventArgs.ErrorSource != ServiceBusErrorSource.Abandon)
                        {
                            Assert.Fail(eventArgs.ErrorSource.ToString());
                        }
                    }
                    else
                    {
                        Assert.Fail(eventArgs.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    bool sessionLockLostEventRaised = false;
                    args.SessionLockLostAsync += (lockLostArgs) =>
                    {
                        sessionLockLostEventRaised = true;
                        return Task.CompletedTask;
                    };

                    var message = args.Message;
                    // wait 2x lock duration in case the
                    // lock was renewed already
                    await Task.Delay(lockDuration.Add(lockDuration));
                    var lockedUntil = args.SessionLockedUntil;
                    Assert.AreEqual(lockedUntil, args.SessionLockedUntil);
                    Assert.IsTrue(sessionLockLostEventRaised);
                    try
                    {
                        await args.CompleteMessageAsync(message, args.CancellationToken);
                        Assert.Fail("No exception");
                    }
                    // this can happen if the session lock was already lost on a different thread
                    catch (TaskCanceledException)
                    {
                    }
                    catch (ServiceBusException ex)
                    when (ex.Reason == ServiceBusFailureReason.SessionLockLost)
                    {
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"Unexpected exception: {ex}");
                    }
                    Interlocked.Increment(ref messageCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    if (setIndex < numThreads)
                    {
                        completionSources[setIndex].SetResult(true);
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task StopProcessingDoesNotCancelAutoCompletion()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    AutoCompleteMessages = true
                });
                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                Assert.That(
                    async () => await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.ServiceTimeout));
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
                enableSession: true,
                lockDuration: ShortLockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                await using var processor = client.CreateSessionProcessor(scope.QueueName);
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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
                await processor.CloseAsync();

                if (settleMethod == "" || settleMethod == "Abandon")
                {
                    var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                    var msg = await receiver.ReceiveMessageAsync(ShortLockDuration);
                    Assert.IsNotNull(msg);
                }
                else
                {
                    try
                    {
                        await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName);
                    }
                    catch (ServiceBusException ex)
                    when (ex.Reason == ServiceBusFailureReason.ServiceTimeout ||
                        ex.Reason == ServiceBusFailureReason.ServiceCommunicationProblem)
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"Unexpected exception: {ex}");
                    }
                    Assert.Fail("No exception!");
                }
            }
        }

        [Test]
        [TestCase(1, 1, 1, false)]
        [TestCase(1, 2, 1, false)]
        [TestCase(5, 3, 2, true)]
        [TestCase(10, 10, 2, false)]
        [TestCase(20, 10, 3, false)]
        [TestCase(20, 40, 5, true)]
        public async Task ProcessMessagesFromMultipleNamedSessions(
            int numThreads,
            int specifiedSessionCount,
            int maxCallsPerSession,
            bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    MaxConcurrentCallsPerSession = maxCallsPerSession,
                    AutoCompleteMessages = autoComplete,
                };
                for (int i = 0; i < specifiedSessionCount; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    options.SessionIds.Add(sessionId);
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                // sending 2 more messages and not specifying these sessionIds when creating a processor,
                // to make sure that these messages will not be received.
                var sessionId1 = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId1));
                sessions.TryAdd(sessionId1, true);

                var sessionId2 = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId2));
                sessions.TryAdd(sessionId2, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                int messageCt = 0;
                int sessionCloseEventCt = 0;

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionClosingAsync += SessionCloseHandler;
                await processor.StartProcessingAsync();

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    Interlocked.Increment(ref sessionCloseEventCt);
                    await args.GetSessionStateAsync();
                    Assert.IsTrue(options.SessionIds.Contains(args.SessionId));
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        if (!autoComplete)
                        {
                            await args.CompleteMessageAsync(message);
                        }
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.IsTrue(options.SessionIds.Contains(message.SessionId));
                        Assert.IsTrue(options.SessionIds.Contains(args.SessionId));
                        Assert.IsNotNull(args.SessionLockedUntil);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        if (ct == specifiedSessionCount)
                        {
                            tcs.SetResult(true);
                        }
                    }
                }
                await tcs.Task;
                await processor.CloseAsync();

                Assert.AreEqual(specifiedSessionCount, messageCt);

                // We should have received messages from only the specified sessions
                Assert.AreEqual(2, sessions.Count);

                // Close event handler should be called on each receiver close
                Assert.AreEqual(specifiedSessionCount, sessionCloseEventCt);
            }
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(4, 2, 2)]
        [TestCase(2, 2, 3)]
        [TestCase(5, 10, 2)]
        [TestCase(10, 10, 3)]
        public async Task SessionLockLostWhenProcessSessionMessages(int numSessions, int numThreads, int lockLostCount)
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(1)
                };
                int messagesPerSession = 20;
                for (int i = 0; i < numSessions; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    options.SessionIds.Add(sessionId);
                    var messages = ServiceBusTestUtilities.GetMessages(messagesPerSession, sessionId);
                    await sender.SendMessagesAsync(messages);
                    sessions.TryAdd(sessionId, true);
                }

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                int messageCt = 0;
                int sessionErrorEventCt = 0;
                ConcurrentDictionary<string, int> receivedMessagesBeforeLockLost = new ConcurrentDictionary<string, int>();
                ConcurrentDictionary<string, int> receivedMessagesAfterLockLost = new ConcurrentDictionary<string, int>();
                ConcurrentDictionary<string, int> sessionClosedEvents = new ConcurrentDictionary<string, int>();
                ConcurrentDictionary<string, int> sessionOpenEvents = new ConcurrentDictionary<string, int>();
                ConcurrentDictionary<string, int> lockLostMap = new ConcurrentDictionary<string, int>();

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionInitializingAsync +=
                    SessionOpenHandler;
                processor.SessionClosingAsync += SessionCloseHandler;
                await processor.StartProcessingAsync();

                Task SessionOpenHandler(ProcessSessionEventArgs args)
                {
                    sessionOpenEvents.AddOrUpdate(
                        args.SessionId,
                        1,
                        (key, oldValue) => oldValue + 1);
                    return Task.CompletedTask;
                }

                Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    sessionClosedEvents.AddOrUpdate(
                        args.SessionId,
                        1,
                        (key, oldValue) => oldValue + 1);
                    return Task.CompletedTask;
                }

                Task SessionErrorHandler(ProcessErrorEventArgs eventArgs)
                {
                    var exception = (ServiceBusException)eventArgs.Exception;
                    if (ServiceBusFailureReason.SessionLockLost == exception.Reason)
                    {
                        Interlocked.Increment(ref sessionErrorEventCt);
                    }
                    else
                    {
                        Assert.Fail(eventArgs.Exception.ToString());
                    }
                    return Task.CompletedTask;
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    if (receivedMessagesBeforeLockLost.ContainsKey(args.SessionId) && receivedMessagesAfterLockLost.ContainsKey(args.SessionId) && receivedMessagesBeforeLockLost[args.SessionId] + receivedMessagesAfterLockLost[args.SessionId] == messagesPerSession)
                    {
                        return;
                    }
                    try
                    {
                        var message = args.Message;
                        lockLostMap.AddOrUpdate(
                            args.SessionId,
                            1,
                            (key, oldValue) => oldValue + 1);

                        if (lockLostMap[args.SessionId] <= lockLostCount)
                        {
                            receivedMessagesBeforeLockLost.AddOrUpdate(
                                args.SessionId,
                                1,
                                (key, oldValue) => oldValue + 1);
                            await Task.Delay(lockDuration.Add(lockDuration));

                            // we expect a lock lost exception
                            // when the message is auto-completed
                        }
                        else
                        {
                            receivedMessagesAfterLockLost.AddOrUpdate(
                                args.SessionId,
                                1,
                                (key, oldValue) => oldValue + 1);
                        }

                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.IsTrue(options.SessionIds.Contains(message.SessionId));
                        Assert.IsTrue(options.SessionIds.Contains(args.SessionId));
                        Assert.IsNotNull(args.SessionLockedUntil);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        if (ct == numSessions * messagesPerSession)
                        {
                            tcs.SetResult(true);
                        }
                    }
                }
                await tcs.Task;
                await processor.CloseAsync();
                foreach (var sessionId in options.SessionIds)
                {
                    Assert.True(receivedMessagesAfterLockLost.ContainsKey(sessionId));

                    // asserting that we're receiving all remaining messages from this session after the lock lost
                    Assert.AreEqual(receivedMessagesAfterLockLost[sessionId], messagesPerSession - receivedMessagesBeforeLockLost[sessionId]);
                    Assert.AreEqual(sessionOpenEvents[sessionId], sessionClosedEvents[sessionId]);

                    // there should either be at least as many session closed events as lock lost count.
                    Assert.GreaterOrEqual(sessionClosedEvents[sessionId], lockLostCount);
                    // greater or equal because there could be multiple threads receiving from the same
                    // session in which chase they would each get the lock lost error
                    Assert.GreaterOrEqual(sessionErrorEventCt, lockLostCount * numSessions);
                }

                Assert.AreEqual(numSessions * messagesPerSession, messageCt);

                // We should have received messages from only the specified sessions
                Assert.AreEqual(0, sessions.Count);
            }
        }

        [Test]
        public async Task UserErrorHandlerInvokedOnceIfSessionLockLost()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                sessions.TryAdd(sessionId, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;
                int sessionErrorEventCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = lockDuration,
                    SessionIds = { sessionId }
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                await processor.StartProcessingAsync();

                Task SessionErrorHandler(ProcessErrorEventArgs eventArgs)
                {
                    try
                    {
                        var exception = (ServiceBusException)eventArgs.Exception;
                        if (ServiceBusFailureReason.SessionLockLost == exception.Reason)
                        {
                            Interlocked.Increment(ref sessionErrorEventCt);
                        }
                        else
                        {
                            Assert.Fail(eventArgs.Exception.ToString());
                        }
                    }
                    finally
                    {
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        sessions.TryRemove(message.SessionId, out bool _);
                        // wait 3x lockduration since to avoid the case where
                        // lock is renewed at the very end of the lock duration delay
                        await Task.Delay(lockDuration.Add(lockDuration).Add(lockDuration));
                        await args.CompleteMessageAsync(message);

                        Assert.IsTrue(sessionId.Contains(message.SessionId));
                        Assert.IsTrue(sessionId.Contains(args.SessionId));
                        Assert.IsNotNull(args.SessionLockedUntil);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();

                Assert.AreEqual(1, messageCt);

                // making sure that session error handler is hitting only once.
                Assert.AreEqual(1, sessionErrorEventCt);

                // We should have received messages from only the specified sessions
                Assert.AreEqual(0, sessions.Count);
            }
        }

        [Test]
        [TestCase(ServiceBusErrorSource.Abandon)]
        [TestCase(ServiceBusErrorSource.AcceptSession)]
        [TestCase(ServiceBusErrorSource.CloseSession)]
        [TestCase(ServiceBusErrorSource.Complete)]
        [TestCase(ServiceBusErrorSource.Receive)]
        [TestCase(ServiceBusErrorSource.ProcessMessageCallback)]
        public async Task ErrorSourceRespected(ServiceBusErrorSource errorSource)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: ShortLockDuration))
            {
                var delayDuration = ShortLockDuration.Add(ShortLockDuration);
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));

                if (errorSource == ServiceBusErrorSource.AcceptSession)
                {
                    var receiver = await client.AcceptSessionAsync(
                        scope.QueueName,
                        sessionId);
                }

                sessions.TryAdd(sessionId, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;
                int sessionErrorEventCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = (errorSource == ServiceBusErrorSource.RenewLock ?
                        TimeSpan.FromSeconds(1) : TimeSpan.FromSeconds(0)),
                    SessionIds = { sessionId }
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                if (errorSource == ServiceBusErrorSource.CloseSession)
                {
                    processor.SessionClosingAsync += CloseSessionHandler;
                }

                await processor.StartProcessingAsync();

                Task CloseSessionHandler(ProcessSessionEventArgs arg)
                {
                    throw new TestException();
                }

                async Task SessionErrorHandler(ProcessErrorEventArgs eventArgs)
                {
                    try
                    {
                        if (eventArgs.Exception is TestException)
                        {
                            if (errorSource == ServiceBusErrorSource.Abandon)
                            {
                                if (sessionErrorEventCt == 1)
                                {
                                    Assert.AreEqual(ServiceBusErrorSource.Abandon, eventArgs.ErrorSource);
                                }
                                else
                                {
                                    Assert.AreEqual(ServiceBusErrorSource.ProcessMessageCallback, eventArgs.ErrorSource);
                                }
                            }
                            else
                            {
                                Assert.AreEqual(errorSource, eventArgs.ErrorSource);
                            }
                            Interlocked.Increment(ref sessionErrorEventCt);
                        }
                        else if ((eventArgs.Exception is ServiceBusException sbException) &&
                            (sbException.Reason == ServiceBusFailureReason.SessionLockLost ||
                                sbException.Reason == ServiceBusFailureReason.SessionCannotBeLocked))
                        {
                            Interlocked.Increment(ref sessionErrorEventCt);
                            Assert.AreEqual(errorSource, eventArgs.ErrorSource);
                        }
                        else
                        {
                            Assert.Fail(eventArgs.Exception.ToString());
                        }
                    }
                    finally
                    {
                        if (eventArgs.ErrorSource != ServiceBusErrorSource.CloseSession)
                        {
                            if (errorSource != ServiceBusErrorSource.Abandon ||
                                sessionErrorEventCt == 2)
                            {
                                tcs.SetResult(true);
                            }
                        }
                        if (eventArgs.ErrorSource == ServiceBusErrorSource.AcceptSession ||
                            eventArgs.ErrorSource == ServiceBusErrorSource.CloseSession ||
                            eventArgs.ErrorSource == ServiceBusErrorSource.Receive)
                        {
                            // add small delay to prevent race condition that can result in error handler
                            // being called twice as the processor will immediately try to accept the session again.
                            await Task.Delay(1000);
                        }
                    }
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.IsTrue(sessionId.Contains(message.SessionId));
                        Assert.IsTrue(sessionId.Contains(args.SessionId));
                        Assert.IsNotNull(args.SessionLockedUntil);
                        switch (errorSource)
                        {
                            case ServiceBusErrorSource.Receive:
                                await args.CompleteMessageAsync(message);
                                await Task.Delay(delayDuration);
                                // lock the session so we can trigger
                                // an error on the processor receive
                                await client.AcceptSessionAsync(
                                    scope.QueueName,
                                    args.SessionId,
                                    cancellationToken: args.CancellationToken);
                                break;
                            case ServiceBusErrorSource.ProcessMessageCallback:
                                await Task.Delay(delayDuration);
                                await args.CompleteMessageAsync(message);
                                break;
                            case ServiceBusErrorSource.Abandon:
                                await Task.Delay(delayDuration);
                                throw new TestException();
                            case ServiceBusErrorSource.Complete:
                                await Task.Delay(delayDuration);
                                break;
                            case ServiceBusErrorSource.CloseSession:
                                tcs.TrySetResult(true);
                                break;
                        }
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                    }
                }
                await tcs.Task;
                await processor.CloseAsync();
                if (errorSource != ServiceBusErrorSource.AcceptSession)
                {
                    Assert.AreEqual(1, messageCt);

                    // We should have received messages from only the specified sessions
                    Assert.AreEqual(0, sessions.Count);
                }
                // Make sure that session error handler is hitting only once, except for Abandon, as that
                // will have a UserCallback error as well.
                if (errorSource == ServiceBusErrorSource.Abandon)
                {
                    Assert.AreEqual(2, sessionErrorEventCt);
                }
                else
                {
                    Assert.AreEqual(1, sessionErrorEventCt);
                }
            }
        }

        [Test]
        public async Task SessionOpenEventDoesNotLoseLock()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage(sessionId));
                sessions.TryAdd(sessionId, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30),
                    SessionIds = { sessionId }
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionInitializingAsync += SessionOpenHandler;
                await processor.StartProcessingAsync();

                async Task SessionOpenHandler(ProcessSessionEventArgs eventArgs)
                {
                    await Task.Delay(lockDuration);
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        await args.CompleteMessageAsync(message);
                        await Task.Delay(lockDuration.Add(lockDuration));

                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.IsTrue(sessionId.Contains(message.SessionId));
                        Assert.IsTrue(sessionId.Contains(args.SessionId));
                        Assert.IsNotNull(args.SessionLockedUntil);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        tcs.SetResult(true);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();

                Assert.AreEqual(1, messageCt);
            }
        }

        [Test]
        [TestCase(10, 10, 1)]
        [TestCase(10, 5, 2)]
        [TestCase(10, 20, 5)]
        public async Task MaxCallsPerSessionRespected(int numSessions, int maxConcurrentSessions, int maxCallsPerSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                int messagesPerSession = 10;
                int totalMessages = messagesPerSession * numSessions;
                for (int i = 0; i < numSessions; i++)
                {
                    await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messagesPerSession, Guid.NewGuid().ToString()));
                }

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = maxConcurrentSessions,
                    MaxConcurrentCallsPerSession = maxCallsPerSession
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);
                ConcurrentDictionary<string, int> sessionDict = new ConcurrentDictionary<string, int>();

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var sessionId = args.SessionId;
                    try
                    {
                        sessionDict.AddOrUpdate(
                            sessionId,
                            1,
                            (key, value) => value + 1);
                        Assert.LessOrEqual(sessionDict[sessionId], maxCallsPerSession);
                        // add a small delay to help verify that no other threads
                        // will be processing this session concurrently.
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        await args.CompleteMessageAsync(args.Message);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        if (ct == totalMessages)
                        {
                            tcs.SetResult(true);
                        }

                        sessionDict.AddOrUpdate(
                            sessionId,
                            0,
                            (key, value) => value - 1);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();

                Assert.AreEqual(totalMessages, messageCt);
            }
        }

        [Test]
        public async Task AdditionalCallsPerSessionDoesNotWaitForOtherSessionsToBeAccepted()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                int totalMessages = 128;
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(totalMessages, "sessionId"));

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    // configuring so that MaxConcurrentCallsPerSession * MaxConcurrentSessions = total messages
                    // this ensures that we are testing the concurrentAcceptSession logic
                    MaxConcurrentSessions = 16,
                    MaxConcurrentCallsPerSession = 8
                };

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var ct = Interlocked.Increment(ref messageCt);
                    if (ct == totalMessages)
                    {
                        tcs.SetResult(true);
                    }

                    // add a delay to simulate processing
                    await Task.Delay(100);
                }

                await tcs.Task;
                await processor.StopProcessingAsync();
                stopWatch.Stop();

                Assert.AreEqual(totalMessages, messageCt);
                Assert.Less(stopWatch.Elapsed, TimeSpan.FromSeconds(10));
            }
        }

        [Test]
        public async Task StopProcessingDoesNotCloseLink()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    AutoCompleteMessages = false,
                    MaxConcurrentSessions = 1
                });
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    tcs.TrySetResult(true);
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                Assert.IsFalse(processor.IsClosed);
                Assert.IsFalse(processor.IsProcessing);

                Assert.That(
                    async () => await CreateNoRetryClient().AcceptSessionAsync(
                        scope.QueueName,
                        "sessionId"),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).
                    EqualTo(ServiceBusFailureReason.SessionCannotBeLocked));

                // can restart
                tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                await processor.StartProcessingAsync();
                Assert.IsTrue(processor.IsProcessing);

                await tcs.Task;

                // dispose will close the link, so we should be able to receive from this session
                await processor.DisposeAsync();
                Assert.IsTrue(processor.IsClosed);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                var receiver = await client.AcceptSessionAsync(scope.QueueName, "sessionId");
                var msg = await receiver.ReceiveMessageAsync();
                Assert.IsNotNull(msg);

                Assert.That(
                    async () => await processor.StartProcessingAsync(),
                    Throws.InstanceOf<ObjectDisposedException>());
            }
        }

        [Test]
        public async Task StopProcessingSessionAdheresToTokenSLA()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                // very long timeout
                await using var client = CreateClient(tryTimeout: 120);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                await using var processor = client.CreateSessionProcessor(scope.QueueName);
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    tcs.TrySetResult(true);
                    return Task.CompletedTask;
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

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
        public async Task StopProcessingAllowsSessionCallbackToComplete()
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
                processor.ProcessErrorAsync += SessionErrorHandler;

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
        public async Task AutoLockRenewalContinuesUntilProcessingCompletes()
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 10
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var ct = Interlocked.Increment(ref receivedCount);
                    if (ct == messageCount)
                    {
                        tcs.SetResult(true);
                    }

                    await Task.Delay(lockDuration.Add(lockDuration));
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(50)]
        public async Task CanReleaseSession(int maxCallsPerSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateNoRetryClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 100;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = maxCallsPerSession
                });

                int receivedCount = 0;
                int sessionCloseCount = 0;
                var tcs = new TaskCompletionSource<bool>();
                int firstCloseCount = 0;

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    var ct = Interlocked.Increment(ref receivedCount);

                    if (ct == messageCount / 2)
                    {
                        args.ReleaseSession();
                    }

                    if (ct == messageCount)
                    {
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                }

                Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    if (firstCloseCount == 0)
                    {
                        firstCloseCount = receivedCount;
                    }
                    Interlocked.Increment(ref sessionCloseCount);
                    return Task.CompletedTask;
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionClosingAsync += SessionCloseHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();

                Assert.AreEqual(messageCount, receivedCount);
                if (firstCloseCount < messageCount)
                {
                    Assert.AreEqual(2, sessionCloseCount);
                }
                else
                {
                    Assert.AreEqual(1, sessionCloseCount);
                }

                // verify all messages were autocompleted
                await AsyncAssert.ThrowsAsync<ServiceBusException>(async () => await client.AcceptNextSessionAsync(scope.QueueName));
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task CanReleaseAndRenewSessionDuringInitializationAndClosing(int maxCallsPerSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = maxCallsPerSession
                });

                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    throw new Exception("Should not be called");
                }

                async Task SessionOpenHandler(ProcessSessionEventArgs args)
                {
                    // verify we can renew the session lock
                    await args.RenewSessionLockAsync();

                    args.ReleaseSession();
                }

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    // verify we can renew the session lock
                    await args.RenewSessionLockAsync();

                    // this is basically a no-op since we are already closing the session. Ideally we wouldn't even have this on the session close handler,
                    // but it is not worth introducing a separate type.
                    args.ReleaseSession();
                    tcs.TrySetResult(true);
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                processor.SessionClosingAsync += SessionCloseHandler;
                processor.SessionInitializingAsync += SessionOpenHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();

                // verify all messages are still present
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                var remaining = messageCount;
                while (remaining > 0)
                {
                    var messages = await receiver.ReceiveMessagesAsync(remaining);
                    remaining -= messages.Count;
                }
            }
        }

        [Test]
        public async Task CanUpdateSessionConcurrency()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 100;

                for (int i = 0; i < messageCount / 2; i++)
                {
                    await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(2, $"session{i}"));
                }

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = 1,
                    SessionIdleTimeout = TimeSpan.FromSeconds(3)
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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

                    if (count == 5)
                    {
                        processor.UpdateConcurrency(20, 2);
                        Assert.AreEqual(20, processor.MaxConcurrentSessions);
                        Assert.AreEqual(2, processor.MaxConcurrentCallsPerSession);

                        // add a small delay to allow concurrency to update
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }

                    if (count == 60)
                    {
                        Assert.GreaterOrEqual(processor.InnerProcessor.TaskTuples.Count, 20);
                    }
                    if (count == 75)
                    {
                        processor.UpdateConcurrency(1, 1);
                        Assert.AreEqual(1, processor.MaxConcurrentSessions);
                        Assert.AreEqual(1, processor.MaxConcurrentCallsPerSession);
                    }
                    if (count == 95)
                    {
                        Assert.LessOrEqual(processor.InnerProcessor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 1);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanUpdateMaxCallsPerSessionConcurrency()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 200;
                int stopCount = 100;
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = 1
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        await args.AbandonMessageAsync(args.Message);
                    }

                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == stopCount)
                    {
                        tcs.SetResult(true);
                    }

                    if (count == 5)
                    {
                        processor.UpdateConcurrency(10, 20);
                        Assert.AreEqual(10, processor.MaxConcurrentSessions);
                        Assert.AreEqual(20, processor.MaxConcurrentCallsPerSession);
                    }

                    if (count == 100)
                    {
                        // at least 10 tasks for the session, plus at least 1 more trying to accept other sessions.
                        Assert.Greater(processor.InnerProcessor.TaskTuples.Count, 10);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;

                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanUpdateMaxCallsPerSessionConcurrencyWithSessionIdsSet()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 200;
                int stopCount = 100;
                string sessionId = "sessionId";
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, sessionId));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = 1,
                    SessionIds = { sessionId }
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        await args.AbandonMessageAsync(args.Message);
                    }

                    var count = Interlocked.Increment(ref receivedCount);
                    if (count == stopCount)
                    {
                        tcs.SetResult(true);
                    }

                    if (count == 5)
                    {
                        processor.UpdateConcurrency(10, 20);
                        Assert.AreEqual(10, processor.MaxConcurrentSessions);
                        Assert.AreEqual(20, processor.MaxConcurrentCallsPerSession);
                    }

                    if (count == 100)
                    {
                        // at least 10 tasks for the session, plus at least 1 more trying to accept other sessions.
                        Assert.Greater(processor.InnerProcessor.TaskTuples.Count, 10);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;

                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task CanUpdateSessionPrefetchCount()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 100;

                for (int i = 0; i < messageCount / 2; i++)
                {
                    await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(2, $"session{i}"));
                }

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = 1,
                    SessionIdleTimeout = TimeSpan.FromSeconds(3)
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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

                    if (count == 5)
                    {
                        processor.UpdatePrefetchCount(2);
                        Assert.AreEqual(2, processor.PrefetchCount);
                        Assert.AreEqual(1, processor.MaxConcurrentSessions);
                        Assert.AreEqual(1, processor.MaxConcurrentCallsPerSession);

                        // add a small delay to allow prefetch to update
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }

                    if (count == 60)
                    {
                        Assert.GreaterOrEqual(processor.InnerProcessor.TaskTuples.Count, 1);
                    }
                    if (count == 75)
                    {
                        processor.UpdatePrefetchCount(1);
                        Assert.AreEqual(1, processor.PrefetchCount);
                        Assert.AreEqual(1, processor.MaxConcurrentSessions);
                        Assert.AreEqual(1, processor.MaxConcurrentCallsPerSession);
                    }
                    if (count == 95)
                    {
                        Assert.LessOrEqual(processor.InnerProcessor.TaskTuples.Where(t => !t.Task.IsCompleted).Count(), 1);
                    }
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanReceiveMessagesFromCallback(bool manualComplete)
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 5,
                    MaxConcurrentSessions = 1
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();

                // verify all messages were completed
                await AsyncAssert.ThrowsAsync<ServiceBusException>(async () => await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanReceiveDeferredMessagesFromCallback(bool manualComplete)
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 10;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 5,
                    MaxConcurrentSessions = 1
                });

                int receivedCount = 0;
                var tcs = new TaskCompletionSource<bool>();
                ProcessSessionMessageEventArgs capturedArgs = null;

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    capturedArgs ??= args;

                    ServiceBusReceivedMessage receivedDeferredMessage = null;
                    var count = Interlocked.Increment(ref receivedCount);

                    // defer first message
                    if (count == 1)
                    {
                        await args.DeferMessageAsync(args.Message);
                        receivedDeferredMessage = (await args.GetReceiveActions().ReceiveDeferredMessagesAsync(new[] {args.Message.SequenceNumber})).Single();
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
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;

                // verify args cannot be used to receive messages outside of callback scope
                await AsyncAssert.ThrowsAsync<InvalidOperationException>(async () => await capturedArgs.GetReceiveActions().ReceiveMessagesAsync(10));

                await processor.CloseAsync();

                // verify all messages were completed
                await AsyncAssert.ThrowsAsync<ServiceBusException>(async () => await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName));
            }
        }

        [Test]
        [NonParallelizable]
        public async Task CanUseMassiveSessionConcurrencyWithoutCausingThreadStarvation()
        {
            var lockDuration = TimeSpan.FromSeconds(30);
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                List<ServiceBusSessionProcessor> processors = new();
                int numProcessors = 10;
                int processedCount = 0;
                int sentCount = 0;
                for (int i = 0; i < numProcessors; i++)
                {
                    ServiceBusSessionProcessorOptions options = new()
                    {
                        AutoCompleteMessages = true,
                        MaxConcurrentSessions = 100,
                        MaxConcurrentCallsPerSession = 1,
                        PrefetchCount = 0,
                        SessionIdleTimeout = TimeSpan.FromSeconds(4),
                        MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(5)
                    };
                    ServiceBusSessionProcessor processor = client.CreateSessionProcessor(scope.QueueName, options);
                    processor.ProcessMessageAsync += ProcessMessageAsync;
                    processor.ProcessErrorAsync += SessionErrorHandler;
                    await processor.StartProcessingAsync();
                    processors.Add(processor);
                }

                var sender = client.CreateSender(scope.QueueName);
                CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromMinutes(3));
                await SendMessagesAsync(cts.Token);
                foreach (var processor in processors)
                {
                    await processor.CloseAsync();
                }
                // add allowance for last few batches of messages that may not be processed in time
                Assert.GreaterOrEqual(processedCount, sentCount - 60);

                async Task SendMessagesAsync(CancellationToken cancellationToken)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            await Task.Delay(10000, cancellationToken);
                        }
                        catch (OperationCanceledException)
                        {
                            return;
                        }

                        Random rnd = new Random();
                        int numSessions = rnd.Next(0, 20);
                        var messages = new List<ServiceBusMessage>();
                        for (int i = 0; i < numSessions; i++)
                        {
                            var sessionId = Guid.NewGuid().ToString();
                            messages.Add(new ServiceBusMessage("Hello World") { SessionId = sessionId });
                            if (i % 2 == 0)
                            {
                                messages.Add(new ServiceBusMessage("Hello World") { SessionId = sessionId });
                            }
                        }

                        sentCount += messages.Count;
                        try
                        {
                            await sender.ScheduleMessagesAsync(messages, DateTimeOffset.Now.AddSeconds(10));
                        }
                        catch (ServiceBusException ex)
                            when (ex.IsTransient)
                        {
                            // ignore transient exceptions
                        }
                    }
                }

                Task ProcessMessageAsync(ProcessSessionMessageEventArgs args)
                {
                    TimeSpan timeOnBus = DateTime.UtcNow - args.Message.EnqueuedTime.UtcDateTime;
                    if (timeOnBus >= lockDuration)
                    {
                        Assert.Fail($"Session '{args.Message.SessionId}' has a time on bus greater than 30 seconds: {timeOnBus}");
                    }
                    Interlocked.Increment(ref processedCount);
                    return Task.CompletedTask;
                }
            }
        }

        [Test]
        public async Task SessionLockLostEventRaisedAfterExpiration()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 1,
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.Zero,
                    AutoCompleteMessages = false
                });

                var tcs = new TaskCompletionSource<bool>();
                bool sessionLockLostEventRaised = false;
                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    args.SessionLockLostAsync += (lockLostArgs) =>
                    {
                        sessionLockLostEventRaised = true;
                        Assert.AreEqual(args.Message.LockToken, lockLostArgs.Message.LockToken);
                        Assert.AreEqual(args.SessionLockedUntil, lockLostArgs.SessionLockedUntil);
                        return Task.CompletedTask;
                    };
                    await args.CompleteMessageAsync(args.Message);
                    await Task.Delay(lockDuration.Add(lockDuration));
                    Assert.IsTrue(sessionLockLostEventRaised);
                    Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    tcs.SetResult(true);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();
            }
        }

        [Test]
        public async Task SessionLockLostEventRaisedAfterConnectionDropped()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 1,
                    MaxConcurrentSessions = 1,
                    AutoCompleteMessages = false
                });

                var tcs = new TaskCompletionSource<bool>();
                bool sessionLockLostEventRaised = false;
                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    args.SessionLockLostAsync += (lockLostArgs) =>
                    {
                        sessionLockLostEventRaised = true;
                        Assert.AreEqual(args.Message.LockToken, lockLostArgs.Message.LockToken);
                        Assert.AreEqual(args.SessionLockedUntil, lockLostArgs.SessionLockedUntil);
                        var lockLostException = lockLostArgs.Exception as ServiceBusException;
                        Assert.IsNotNull(lockLostException);
                        Assert.AreEqual(ServiceBusFailureReason.SessionLockLost, lockLostException.Reason);
                        return Task.CompletedTask;
                    };
                    await args.CompleteMessageAsync(args.Message);
                    SimulateNetworkFailure(client);
                    await Task.Delay(lockDuration.Add(lockDuration));
                    Assert.IsTrue(sessionLockLostEventRaised);
                    Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    tcs.SetResult(true);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.CloseAsync();
            }
        }

        [Test]
        public async Task SessionLockLostHandlerNotRaisedAfterProcessMessageCompletes()
        {
            var lockDuration = ShortLockDuration;
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                int messageCount = 1;

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messageCount, "sessionId"));

                await using var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 1,
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.Zero,
                    AutoCompleteMessages = false
                });

                var tcs = new TaskCompletionSource<bool>();
                bool sessionLockLostEventRaised = false;
                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    args.SessionLockLostAsync += (lockLostArgs) =>
                    {
                        sessionLockLostEventRaised = true;
                        return Task.CompletedTask;
                    };
                    await args.CompleteMessageAsync(args.Message);
                    Assert.IsFalse(sessionLockLostEventRaised);
                    Assert.IsFalse(args.CancellationToken.IsCancellationRequested);
                    tcs.SetResult(true);
                }
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await Task.Delay(lockDuration.Add(lockDuration));
                Assert.IsFalse(sessionLockLostEventRaised);
                await processor.CloseAsync();
            }
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task SessionOrderingIsGuaranteedProcessor(bool prefetch, bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                long lastSequenceNumber = 0;
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCallsPerSession = 1, MaxConcurrentSessions = 1, PrefetchCount = prefetch ? 5 : 0
                };
                if (useSpecificSession)
                {
                    options.SessionIds.Add("session");
                }

                await using var processor = client.CreateSessionProcessor(scope.QueueName, options);
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;

                var sender = client.CreateSender(scope.QueueName);

                CancellationTokenSource cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(60));
                await processor.StartProcessingAsync();
                await SendMessagesAsync();

                await processor.StopProcessingAsync();

                async Task SendMessagesAsync()
                {
                    while (!cts.IsCancellationRequested)
                    {
                        await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                        await Task.Delay(TimeSpan.FromMilliseconds(100));
                    }
                }

                Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    Assert.That(
                        args.Message.SequenceNumber,
                        Is.EqualTo(lastSequenceNumber + 1),
                        $"Last sequence number: {lastSequenceNumber}, current sequence number: {args.Message.SequenceNumber}");

                    lastSequenceNumber = args.Message.SequenceNumber;
                    return Task.CompletedTask;
                }
            }
        }

        private Task SessionErrorHandler(ProcessErrorEventArgs args)
        {
            // If the connection drops due to network flakiness
            // after the message is received but before we
            // complete it, we will get a session lock
            // lost exception. We are still able to verify
            // that the message will be completed eventually.
            if (args.Exception is not ServiceBusException { Reason: ServiceBusFailureReason.SessionLockLost })
            {
                Assert.Fail($"Error source: {args.ErrorSource}, Exception: {args.Exception}");
            }
            return Task.CompletedTask;
        }
    }
}
