// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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

                var processor = client.CreateSessionProcessor(scope.QueueName);

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

                var processor = client.CreateSessionProcessor(scope.QueueName);

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
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
                };
                var processor = client.CreateSessionProcessor(scope.QueueName, options);
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
                    await args.SetSessionStateAsync(state);
                    sessions[args.SessionId] = state;
                }

                async Task SessionCloseHandler(ProcessSessionEventArgs args)
                {
                    Interlocked.Increment(ref sessionCloseEventCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].SetResult(true);
                    sessions.TryRemove(args.SessionId, out byte[] state);
                    byte[] getState = await args.GetSessionStateAsync();
                    Assert.AreEqual(state, getState);
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

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendMessageAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }
                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = true
                };
                var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();

                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
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
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, args.SessionId);
                        Assert.IsNotNull(args.SessionLockedUntil);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        if (setIndex < completionSources.Length)
                        {
                            completionSources[setIndex].SetResult(true);
                        }
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
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

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);
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
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
                };

                ServiceBusSessionProcessor processor = GetNoRetryClient().CreateSessionProcessor(scope.QueueName, options);

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
                        await GetNoRetryClient().CreateSessionReceiverAsync(scope.QueueName),
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

                var processor = client.CreateSessionProcessor(scope.QueueName);
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
                var processor = client.CreateSessionProcessor(scope.TopicName, scope.SubscriptionNames.First());
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
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete,
                    // using the last sessionId from the loop
                    SessionIds = new string[] { sessionId }
                };

                var processor = client.CreateSessionProcessor(
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
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task AutoLockRenewalWorks(int numThreads)
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
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = false
                };
                var processor = client.CreateSessionProcessor(scope.QueueName, options);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        var lockedUntil = args.SessionLockedUntil;
                        await Task.Delay(lockDuration);
                        Assert.That(args.SessionLockedUntil > lockedUntil, $"{lockedUntil},{DateTime.UtcNow}");
                        await args.CompleteMessageAsync(message, args.CancellationToken);
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
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = false,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(autoLockRenewalDuration)
                };
                var processor = client.CreateSessionProcessor(scope.QueueName, options);
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
                    if (ServiceBusException.FailureReason.SessionLockLost == exception.Reason)
                    {
                        Assert.AreEqual(ServiceBusErrorSource.Receive, eventArgs.ErrorSource);
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
                    var lockedUntil = args.SessionLockedUntil;
                    // wait 2x lock duration in case the
                    // lock was renewed already
                    await Task.Delay(lockDuration.Add(lockDuration));
                    if (!args.CancellationToken.IsCancellationRequested)
                    {
                        // only do the assertion if cancellation wasn't requested as otherwise
                        // the exception we would get is a TaskCanceledException rather than ServiceBusException
                        Assert.AreEqual(lockedUntil, args.SessionLockedUntil);
                        Assert.That(
                            async () => await args.CompleteMessageAsync(message, args.CancellationToken),
                            Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.SessionLockLost));
                        Interlocked.Increment(ref messageCt);
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        completionSources[setIndex].SetResult(true);
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();
                Assert.AreEqual(numThreads, messageCt);
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
                var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    AutoComplete = true
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
                    async () => await GetNoRetryClient().CreateSessionReceiverAsync(scope.QueueName),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ServiceTimeout));
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
                var processor = client.CreateSessionProcessor(scope.QueueName);
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
                    var receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                    var msg = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    Assert.IsNotNull(msg);
                }
                else
                {
                    Assert.That(
                        async () => await GetNoRetryClient().CreateSessionReceiverAsync(scope.QueueName),
                        Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ServiceTimeout));
                }
            }
        }

        [Test]
        [TestCase(1, 1, false)]
        [TestCase(1, 2, false)]
        [TestCase(5, 3, true)]
        [TestCase(10, 10, false)]
        [TestCase(20, 10, false)]
        [TestCase(20, 40, true)]
        public async Task ProcessMessagesFromMultipleNamedSessions(int numThreads, int specifiedSessionCount, bool autoComplete)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                var sessionIds = new List<string>();
                for (int i = 0; i < specifiedSessionCount; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    sessionIds.Add(sessionId);
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

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete,
                    SessionIds = sessionIds.ToArray()
                };

                var processor = client.CreateSessionProcessor(
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
                    Assert.IsTrue(sessionIds.Contains(args.SessionId));
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
                        Assert.IsTrue(sessionIds.Contains(message.SessionId));
                        Assert.IsTrue(sessionIds.Contains(args.SessionId));
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
                await processor.StopProcessingAsync();

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
                var sessionIds = new List<string>();
                int messagesPerSession = 20;
                for (int i = 0; i < numSessions; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    sessionIds.Add(sessionId);
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

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(1),
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                    SessionIds = sessionIds.ToArray()
                };

                var processor = client.CreateSessionProcessor(
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
                    if (ServiceBusException.FailureReason.SessionLockLost == exception.Reason)
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
                        }
                        else
                        {
                            receivedMessagesAfterLockLost.AddOrUpdate(
                                args.SessionId,
                                1,
                                (key, oldValue) => oldValue + 1);
                        }

                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.IsTrue(sessionIds.Contains(message.SessionId));
                        Assert.IsTrue(sessionIds.Contains(args.SessionId));
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
                await processor.StopProcessingAsync();
                foreach (var sessionId in sessionIds)
                {
                    Assert.True(receivedMessagesAfterLockLost.ContainsKey(sessionId));

                    // asserting that we're recieving all remaining messages from this session after the lock lost
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
        public async Task UserErrorHandlerInvokeOnceIfSessionLockLost()
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
                    MaxConcurrentCalls = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(10),
                    SessionIds = new string[] { sessionId }
                };

                var processor = client.CreateSessionProcessor(
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
                        if (ServiceBusException.FailureReason.SessionLockLost == exception.Reason)
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
        [TestCase(ServiceBusErrorSource.AcceptMessageSession)]
        [TestCase(ServiceBusErrorSource.CloseMessageSession)]
        [TestCase(ServiceBusErrorSource.Complete)]
        [TestCase(ServiceBusErrorSource.Receive)]
        [TestCase(ServiceBusErrorSource.UserCallback)]
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

                if (errorSource == ServiceBusErrorSource.AcceptMessageSession)
                {
                    var receiver = await client.CreateSessionReceiverAsync(
                        scope.QueueName,
                        new ServiceBusSessionReceiverOptions
                        {
                            SessionId = sessionId
                        });
                }

                sessions.TryAdd(sessionId, true);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                int messageCt = 0;
                int sessionErrorEventCt = 0;

                var options = new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCalls = 1,
                    MaxAutoLockRenewalDuration = (errorSource == ServiceBusErrorSource.RenewLock ?
                        TimeSpan.FromSeconds(1) : TimeSpan.FromSeconds(0)),
                    SessionIds = new string[] { sessionId }
                };

                var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options);

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += SessionErrorHandler;
                if (errorSource == ServiceBusErrorSource.CloseMessageSession)
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
                                    Assert.AreEqual(ServiceBusErrorSource.UserCallback, eventArgs.ErrorSource);
                                }
                            }
                            else
                            {
                                Assert.AreEqual(errorSource, eventArgs.ErrorSource);
                            }
                            Interlocked.Increment(ref sessionErrorEventCt);
                        }
                        else if ((eventArgs.Exception is ServiceBusException sbException) &&
                            (sbException.Reason == ServiceBusException.FailureReason.SessionLockLost ||
                                sbException.Reason == ServiceBusException.FailureReason.SessionCannotBeLocked))
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

                        if (eventArgs.ErrorSource != ServiceBusErrorSource.CloseMessageSession)
                        {
                            if (errorSource != ServiceBusErrorSource.Abandon ||
                                sessionErrorEventCt == 2)
                            {
                                tcs.SetResult(true);
                            }
                        }
                        if (eventArgs.ErrorSource == ServiceBusErrorSource.AcceptMessageSession ||
                            eventArgs.ErrorSource == ServiceBusErrorSource.CloseMessageSession)
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
                                break;
                            case ServiceBusErrorSource.UserCallback:
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
                if (errorSource != ServiceBusErrorSource.AcceptMessageSession)
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
                    MaxConcurrentCalls = 1,
                    MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30),
                    SessionIds = new string[] { sessionId }
                };

                var processor = client.CreateSessionProcessor(
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
    }
}
