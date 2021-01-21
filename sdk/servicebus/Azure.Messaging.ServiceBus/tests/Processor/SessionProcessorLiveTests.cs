// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
                await using var client = GetClient();

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
                await using var client = GetClient();

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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, byte[]> sessions = new ConcurrentDictionary<string, byte[]>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(GetMessage(sessionId));
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
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.SessionInitializingAsync += SessionInitHandler;
                processor.SessionClosingAsync += SessionCloseHandler;

                await processor.StartProcessingAsync();

                async Task SessionInitHandler(ProcessSessionEventArgs args)
                {
                    Interlocked.Increment(ref sessionOpenEventCt);
                    byte[] state = GetRandomBuffer(100);
                    await args.SetSessionStateAsync(new BinaryData(state));
                    sessions[args.SessionId] = state;
                }

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    Interlocked.Increment(ref sessionCloseEventCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                    sessions.TryRemove(args.SessionId, out byte[] state);
                    BinaryData getState = await args.GetSessionStateAsync();
                    Assert.AreEqual(state, getState.ToArray());
                }

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
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
                await processor.StopProcessingAsync();

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
                await using var client = GetClient();
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(GetMessage(sessionId));
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
                processor.ProcessErrorAsync += ExceptionHandler;
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(GetMessage(sessionId));
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

                await using ServiceBusSessionProcessor processor = GetNoRetryClient().CreateSessionProcessor(scope.QueueName, options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
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
                        await GetNoRetryClient().AcceptNextSessionAsync(scope.QueueName),
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
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

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
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                string sessionId = null;
                for (int i = 0; i < numThreads; i++)
                {
                    sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(GetMessage(sessionId));
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
                processor.ProcessErrorAsync += ExceptionHandler;
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    AddMessages(batch, 1, Guid.NewGuid().ToString());
                }

                await sender.SendMessagesAsync(batch);

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = false,
                    MaxConcurrentCallsPerSession = maxCallsPerSession
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
        [TestCase(1, 0, 1)]
        [TestCase(5, 0, 3)]
        [TestCase(10, 1, 5)]
        [TestCase(20, 1, 10)]
        public async Task MaxAutoLockRenewalDurationRespected(
            int numThreads,
            int autoLockRenewalDuration,
            int maxCallsPerSession)
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    AddMessages(batch, 1, Guid.NewGuid().ToString());
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
                    var message = args.Message;
                    // wait 2x lock duration in case the
                    // lock was renewed already
                    await Task.Delay(lockDuration.Add(lockDuration));
                    var lockedUntil = args.SessionLockedUntil;
                    Assert.AreEqual(lockedUntil, args.SessionLockedUntil);
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
            var lockDuration = TimeSpan.FromSeconds(5);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage("sessionId"));
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
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                Assert.That(
                    async () => await GetNoRetryClient().AcceptNextSessionAsync(scope.QueueName),
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
                lockDuration: TimeSpan.FromSeconds(5)))
            {
                await using var client = GetClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage("sessionId"));
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
                await processor.StopProcessingAsync();

                if (settleMethod == "" || settleMethod == "Abandon")
                {
                    var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                    var msg = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    Assert.IsNotNull(msg);
                }
                else
                {
                    try
                    {
                        await GetNoRetryClient().AcceptNextSessionAsync(scope.QueueName);
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = numThreads,
                    AutoCompleteMessages = autoComplete,
                };
                for (int i = 0; i < specifiedSessionCount; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    options.SessionIds.Add(sessionId);
                    await sender.SendMessageAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                // sending 2 more messages and not specifying these sessionIds when creating a processor,
                // to make sure that these messages will not be received.
                var sessionId1 = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(GetMessage(sessionId1));
                sessions.TryAdd(sessionId1, true);

                var sessionId2 = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(GetMessage(sessionId2));
                sessions.TryAdd(sessionId2, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                int messageCt = 0;
                int sessionCloseEventCt = 0;

                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
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
            var lockDuration = TimeSpan.FromSeconds(5);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
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
                    var messages = GetMessages(messagesPerSession, sessionId);
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
                            await Task.Delay(lockDuration.Add(TimeSpan.FromSeconds(5)));

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
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(GetMessage(sessionId));
                sessions.TryAdd(sessionId, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;
                int sessionErrorEventCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentSessions = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(10),
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
                        await Task.Delay(lockDuration.Add(TimeSpan.FromSeconds(10)));
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
                lockDuration: TimeSpan.FromSeconds(5)))
            {
                var delayDuration = TimeSpan.FromSeconds(10);
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(GetMessage(sessionId));

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
                    try
                    {
                        throw new TestException();
                    }
                    finally
                    {
                        tcs.TrySetResult(true);
                    }
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
                        }
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                    }
                }
                await tcs.Task;
                await processor.StopProcessingAsync();
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
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: lockDuration))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();

                var sessionId = Guid.NewGuid().ToString();
                await sender.SendMessageAsync(GetMessage(sessionId));
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
                processor.ProcessErrorAsync += ExceptionHandler;
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
                        await Task.Delay(lockDuration.Add(TimeSpan.FromSeconds(10)));

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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                int messagesPerSession = 10;
                int totalMessages = messagesPerSession * numSessions;
                for (int i = 0; i < numSessions; i++)
                {
                    await sender.SendMessagesAsync(GetMessages(messagesPerSession, Guid.NewGuid().ToString()));
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
                processor.ProcessErrorAsync += args =>
                {
                    // If the connection drops due to network flakiness
                    // after the message is received but before we
                    // complete it, we will get a session lock
                    // lost exception. We are still able to verify
                    // that the message will be completed eventually.
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
        public async Task StopProcessingDoesNotCloseLink()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = GetClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage("sessionId"));
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
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                Assert.IsFalse(processor.IsClosed);
                Assert.IsFalse(processor.IsProcessing);

                Assert.That(
                    async () => await GetNoRetryClient().AcceptSessionAsync(
                        scope.QueueName,
                        "sessionId"),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).
                    EqualTo(ServiceBusFailureReason.SessionCannotBeLocked));

                // can restart
                tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                await sender.SendMessageAsync(GetMessage("sessionId"));
                await processor.StartProcessingAsync();
                Assert.IsTrue(processor.IsProcessing);

                await tcs.Task;

                // dispose will close the link, so we should be able to receive from this session
                await processor.DisposeAsync();
                Assert.IsTrue(processor.IsClosed);
                await sender.SendMessageAsync(GetMessage("sessionId"));
                var receiver = await client.AcceptSessionAsync(scope.QueueName, "sessionId");
                var msg = await receiver.ReceiveMessageAsync();
                Assert.IsNotNull(msg);

                Assert.That(
                    async () => await processor.StartProcessingAsync(),
                    Throws.InstanceOf<ObjectDisposedException>());
            }
        }
    }
}
