// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class OnSessionTopicSubscriptionTests
    {
        const int ExpectedMessageCount = TestSessionHandler.NumberOfSessions * TestSessionHandler.MessagesPerSession;

        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic, maxCurrentCalls }
            new object[] { false, true, 1 },
            new object[] { false, true, 5 },
            new object[] { true, true, 1 },
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

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulSubscription()
        {
            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                var exceptionReceivedHandlerCalled = false;
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicClient.TopicName,
                    subscriptionName,
                    ReceiveMode.PeekLock);

                var sessionHandlerOptions = new SessionHandlerOptions(eventArgs =>
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

                subscriptionClient.RegisterSessionHandler(
                   (session, message, token) => Task.CompletedTask,
                   sessionHandlerOptions);

                try
                {
                    var stopwatch = Stopwatch.StartNew();
                    while (stopwatch.Elapsed.TotalSeconds <= 10)
                    {
                        if (exceptionReceivedHandlerCalled)
                        {
                            break;
                        }

                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }

                    TestUtility.Log($"{DateTime.Now}: ExceptionReceivedHandlerCalled: {exceptionReceivedHandlerCalled}");
                    Assert.True(exceptionReceivedHandlerCalled);
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }

        private async Task OnSessionTestAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                TestUtility.Log($"Topic: {topicName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicClient.TopicName,
                    subscriptionName,
                    ReceiveMode.PeekLock);

                try
                {
                    var sessionHandlerOptions =
                        new SessionHandlerOptions(ExceptionReceivedHandler)
                        {
                            MaxConcurrentSessions = maxConcurrentCalls,
                            MessageWaitTimeout = TimeSpan.FromSeconds(5),
                            AutoComplete = true
                        };

                    var testSessionHandler = new TestSessionHandler(
                        subscriptionClient.ReceiveMode,
                        sessionHandlerOptions,
                        topicClient.InnerSender,
                        subscriptionClient.SessionPumpHost);

                    // Send messages to Session
                    await testSessionHandler.SendSessionMessages();

                    // Register handler
                    testSessionHandler.RegisterSessionHandler(sessionHandlerOptions);

                    // Verify messages were received.
                    await testSessionHandler.VerifyRun();

                    testSessionHandler.ClearData();
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });

            // test UnregisterSessionHandler can wait for message handling upto the timeout user defined. 
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                TestUtility.Log($"Topic: {topicName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicClient.TopicName,
                    subscriptionName,
                    ReceiveMode.PeekLock);

                try
                {
                    var sessionHandlerOptions =
                        new SessionHandlerOptions(ExceptionReceivedHandler)
                        {
                            MaxConcurrentSessions = maxConcurrentCalls,
                            MessageWaitTimeout = TimeSpan.FromSeconds(5),
                            AutoComplete = true
                        };

                    var testSessionHandler = new TestSessionHandler(
                        subscriptionClient.ReceiveMode,
                        sessionHandlerOptions,
                        topicClient.InnerSender,
                        subscriptionClient.SessionPumpHost);

                    // Send messages to Session
                    await testSessionHandler.SendSessionMessages();

                    // Register handler
                    testSessionHandler.RegisterSessionHandlerAndRecordReceivedMessageCount(subscriptionClient.ReceiveMode == ReceiveMode.PeekLock, 8);

                    // Session handler set up has greater latency than message handler. Delay here to enable some processing time of the session pump.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    // UnregisterSessionHandler should wait up to the provided timeout to finish the message handling tasks
                    await testSessionHandler.UnregisterSessionHandler(TimeSpan.FromSeconds(10));
                    Assert.True(testSessionHandler.ReceivedMessageCount == maxConcurrentCalls);

                    // Reregister won't have any problems
                    testSessionHandler.RegisterSessionHandlerAndRecordReceivedMessageCount(subscriptionClient.ReceiveMode == ReceiveMode.PeekLock, 0);
                    await testSessionHandler.WaitForAllMessagesReceived(ExpectedMessageCount);
                    Assert.True(testSessionHandler.ReceivedMessageCount == ExpectedMessageCount);

                    testSessionHandler.ClearData();
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });

            // test UnregisterSessionHandler can close down in time when message handling takes longer than wait timeout user defined. 
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                TestUtility.Log($"Topic: {topicName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicClient.TopicName,
                    subscriptionName,
                    ReceiveMode.PeekLock);

                try
                {
                    var sessionHandlerOptions =
                        new SessionHandlerOptions(ExceptionReceivedHandler)
                        {
                            MaxConcurrentSessions = maxConcurrentCalls,
                            MessageWaitTimeout = TimeSpan.FromSeconds(5),
                            AutoComplete = true
                        };

                    var testSessionHandler = new TestSessionHandler(
                        subscriptionClient.ReceiveMode,
                        sessionHandlerOptions,
                        topicClient.InnerSender,
                        subscriptionClient.SessionPumpHost);

                    // Send messages to Session
                    await testSessionHandler.SendSessionMessages();

                    // Register handler
                    testSessionHandler.RegisterSessionHandlerAndRecordReceivedMessageCount(subscriptionClient.ReceiveMode == ReceiveMode.PeekLock, 8);

                    // UnregisterSessionHandler should wait up to the provided timeout to finish the message handling tasks
                    await testSessionHandler.UnregisterSessionHandler(TimeSpan.FromSeconds(2));
                    Assert.True(testSessionHandler.ReceivedMessageCount == 0);

                    // Reregister won't have any problems
                    testSessionHandler.RegisterSessionHandlerAndRecordReceivedMessageCount(subscriptionClient.ReceiveMode == ReceiveMode.PeekLock, 0);
                    await testSessionHandler.WaitForAllMessagesReceived(ExpectedMessageCount);
                    Assert.True(testSessionHandler.ReceivedMessageCount == ExpectedMessageCount);

                    testSessionHandler.ClearData();
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
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