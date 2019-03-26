﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class OnMessageQueueTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            new object[] { TestConstants.NonPartitionedQueueName, 1 },
            new object[] { TestConstants.NonPartitionedQueueName, 10 },
            new object[] { TestConstants.PartitionedQueueName, 1 },
            new object[] { TestConstants.PartitionedQueueName, 10 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        Task OnMessagePeekLockWithAutoCompleteTrue(string queueName, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        Task OnMessagePeekLockWithAutoCompleteFalse(string queueName, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        Task OnMessageReceiveDelete(string queueName, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task OnMessageRegistrationWithoutPendingMessagesReceiveAndDelete(string queueName, int maxConcurrentCalls)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.OnMessageRegistrationWithoutPendingMessagesTestCase(queueClient.InnerSender, queueClient.InnerReceiver, maxConcurrentCalls, true);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task OnMessageExceptionHandlerCalledTest()
        {
            var queueName = "nonexistentqueuename";
            var exceptionReceivedHandlerCalled = false;

            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            queueClient.RegisterMessageHandler(
                (message, token) => throw new Exception("Unexpected exception: Did not expect messages here"),
                (eventArgs) =>
                {
                    Assert.NotNull(eventArgs);
                    Assert.NotNull(eventArgs.Exception);
                    if (eventArgs.Exception is MessagingEntityNotFoundException)
                    {
                        exceptionReceivedHandlerCalled = true;
                    }
                    return Task.CompletedTask;
                });

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
                await queueClient.CloseAsync();
            }
        }

        async Task OnMessageTestAsync(string queueName, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, mode);
            try
            {
                await this.OnMessageAsyncTestCase(
                    queueClient.InnerSender,
                    queueClient.InnerReceiver,
                    maxConcurrentCalls,
                    autoComplete,
                    messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}