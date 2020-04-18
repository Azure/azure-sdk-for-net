// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CannotAddHandlerWhileProcessorIsRunning()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = GetClient();

                var processor = client.CreateSessionProcessor(scope.QueueName);

                Func<ProcessSessionMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
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
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(20, false)]
        public async Task ProcessSessionEvent(int numThreads, bool autoComplete)
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
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }
                var options = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = numThreads,
                    AutoComplete = autoComplete
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
                        if (!autoComplete)
                        {
                            await args.CompleteAsync(message);
                        }
                        Interlocked.Increment(ref messageCt);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, args.SessionId);
                        Assert.IsNotNull(args.SessionLockedUntil);
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

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
                            await args.CompleteAsync(message);
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
                await using var client = GetClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

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

                var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    options,
                    sessionId); // using the last sessionId from the loop

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
                            await args.CompleteAsync(message);
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

                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    AddMessages(batch, 1, Guid.NewGuid().ToString());
                }

                await sender.SendBatchAsync(batch);

                var options = new ServiceBusProcessorOptions
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
                        await args.CompleteAsync(message, args.CancellationToken);
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

                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                var messageSendCt = numThreads;
                for (int i = 0; i < numThreads; i++)
                {
                    AddMessages(batch, 1, Guid.NewGuid().ToString());
                }

                await sender.SendBatchAsync(batch);

                var options = new ServiceBusProcessorOptions
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
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessSessionMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        var lockedUntil = args.SessionLockedUntil;
                        await Task.Delay(lockDuration.Add(TimeSpan.FromSeconds(1)));
                        if (!args.CancellationToken.IsCancellationRequested)
                        {
                            // only do the assertion if cancellation wasn't requested as otherwise
                            // the exception we would get is a TaskCanceledException rather than ServiceBusException
                            Assert.AreEqual(lockedUntil, args.SessionLockedUntil);
                            Assert.That(
                                async () => await args.CompleteAsync(message, args.CancellationToken),
                                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.SessionLockLost));
                            Interlocked.Increment(ref messageCt);
                        }
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
                await sender.SendAsync(GetMessage("sessionId"));
                var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusProcessorOptions
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
                    async() => await GetNoRetryClient().CreateSessionReceiverAsync(scope.QueueName),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ServiceTimeout));
            }
        }

    }
}
