// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class OnSessionQueueTests
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue, maxCurrentCalls }
            new object[] { false, true, 1 },
            new object[] { false, true, 5 },
            new object[] { true, true, 1 },
            new object[] { true, true, 5 },
        };

        public static IEnumerable<object[]> PartitionedNonPartitionedTestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue, maxCurrentCalls }
            new object[] { false, true, 5 },
            new object[] { true, true, 5 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnSessionPeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnSessionTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnSessionPeekLockWithAutoCompleteFalse(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnSessionTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Theory]
        [MemberData(nameof(PartitionedNonPartitionedTestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnSessionReceiveDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnSessionTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task OnSessionCanStartWithNullMessageButReturnSessionLater()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var queueClient = new QueueClient(
                    TestUtility.NamespaceConnectionString,
                    queueName,
                    ReceiveMode.PeekLock);
                try
                {
                    var sessionHandlerOptions =
                        new SessionHandlerOptions(ExceptionReceivedHandler)
                        {
                            MaxConcurrentSessions = 5,
                            MessageWaitTimeout = TimeSpan.FromSeconds(5),
                            AutoComplete = true
                        };

                    var testSessionHandler = new TestSessionHandler(
                        queueClient.ReceiveMode,
                        sessionHandlerOptions,
                        queueClient.InnerSender,
                        queueClient.SessionPumpHost);

                    // Register handler first without any messages
                    testSessionHandler.RegisterSessionHandler(sessionHandlerOptions);

                    // Send messages to Session
                    await testSessionHandler.SendSessionMessages();

                    // Verify messages were received.
                    await testSessionHandler.VerifyRun();

                    // Clear the data and re-run the scenario.
                    testSessionHandler.ClearData();
                    await testSessionHandler.SendSessionMessages();

                    // Verify messages were received.
                    await testSessionHandler.VerifyRun();
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulQueue()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var exceptionReceivedHandlerCalled = false;
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);

                try
                {
                    var sessionHandlerOptions = new SessionHandlerOptions(
                    (eventArgs) =>
                    {
                        Assert.NotNull(eventArgs);
                        Assert.NotNull(eventArgs.Exception);
                        if (eventArgs.Exception is InvalidOperationException)
                        {
                            exceptionReceivedHandlerCalled = true;
                        }
                        return Task.CompletedTask;
                    })
                    { MaxConcurrentSessions = 1 };

                    queueClient.RegisterSessionHandler(
                       (session, message, token) =>
                       {
                           return Task.CompletedTask;
                       },
                       sessionHandlerOptions);

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
                    await queueClient.CloseAsync();
                }
            });
        }

        private async Task OnSessionTestAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                TestUtility.Log($"Queue: {queueName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, mode);
                try
                {
                    var handlerOptions =
                        new SessionHandlerOptions(ExceptionReceivedHandler)
                        {
                            MaxConcurrentSessions = maxConcurrentCalls,
                            MessageWaitTimeout = TimeSpan.FromSeconds(5),
                            AutoComplete = autoComplete
                        };

                    var testSessionHandler = new TestSessionHandler(
                        queueClient.ReceiveMode,
                        handlerOptions,
                        queueClient.InnerSender,
                        queueClient.SessionPumpHost);

                    // Send messages to Session first
                    await testSessionHandler.SendSessionMessages();

                    // Register handler
                    testSessionHandler.RegisterSessionHandler(handlerOptions);

                    // Verify messages were received.
                    await testSessionHandler.VerifyRun();
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            TestUtility.Log($"Exception Received: ClientId: {eventArgs.ExceptionReceivedContext.ClientId}, EntityPath: {eventArgs.ExceptionReceivedContext.EntityPath}, Exception: {eventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}