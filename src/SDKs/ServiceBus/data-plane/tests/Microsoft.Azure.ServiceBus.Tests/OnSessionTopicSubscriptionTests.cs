// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class OnSessionTopicSubscriptionTests
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic, maxCurrentCalls }
            new object[] { false, true, 1 },
            new object[] { false, true, 5 },
            new object[] { true, true, 1 },
            new object[] { true, true, 5 },
        };

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        Task OnSessionPeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnSessionTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        Task OnSessionPeekLockWithAutoCompleteFalse(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnSessionTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [LiveFact]
        [DisplayTestMethodName]
        async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulSubscription()
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

        async Task OnSessionTestAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
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
                            MaxConcurrentSessions = 5,
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
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            TestUtility.Log($"Exception Received: ClientId: {eventArgs.ExceptionReceivedContext.ClientId}, EntityPath: {eventArgs.ExceptionReceivedContext.EntityPath}, Exception: {eventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}