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
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { TestConstants.NonPartitionedSessionTopicName, 1 },
            new object[] { TestConstants.NonPartitionedSessionTopicName, 5 },
            new object[] { TestConstants.PartitionedSessionTopicName, 1 },
            new object[] { TestConstants.PartitionedSessionTopicName, 5 },
        };

        string SubscriptionName => TestConstants.SessionSubscriptionName;

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnSessionPeekLockWithAutoCompleteTrue(string topicName, int maxConcurrentCalls)
        {
            await this.OnSessionTestAsync(topicName, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnSessionPeekLockWithAutoCompleteFalse(string topicName, int maxConcurrentCalls)
        {
            await this.OnSessionTestAsync(topicName, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulSubscription()
        {
            bool exceptionReceivedHandlerCalled = false;
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedTopicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicClient.TopicName,
                TestConstants.SubscriptionName,
                ReceiveMode.PeekLock);

            SessionHandlerOptions sessionHandlerOptions = new SessionHandlerOptions(
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

            subscriptionClient.RegisterSessionHandler(
               (session, message, token) =>
               {
                   return Task.CompletedTask;
               },
               sessionHandlerOptions);

            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
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
        }

        async Task OnSessionTestAsync(string topicName, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            TestUtility.Log($"Topic: {topicName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicClient.TopicName,
                this.SubscriptionName,
                ReceiveMode.PeekLock);

            try
            {
                SessionHandlerOptions handlerOptions =
                    new SessionHandlerOptions(ExceptionReceivedHandler)
                    {
                        MaxConcurrentSessions = 5,
                        MessageWaitTimeout = TimeSpan.FromSeconds(5),
                        AutoComplete = true
                    };

                TestSessionHandler testSessionHandler = new TestSessionHandler(
                    subscriptionClient.ReceiveMode,
                    handlerOptions,
                    topicClient.InnerSender,
                    subscriptionClient.SessionPumpHost);

                // Send messages to Session
                await testSessionHandler.SendSessionMessages();

                // Register handler
                testSessionHandler.RegisterSessionHandler(handlerOptions);

                // Verify messages were received.
                await testSessionHandler.VerifyRun();
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            TestUtility.Log($"Exception Received: ClientId: {eventArgs.ExceptionReceivedContext.ClientId}, EntityPath: {eventArgs.ExceptionReceivedContext.EntityPath}, Exception: {eventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}