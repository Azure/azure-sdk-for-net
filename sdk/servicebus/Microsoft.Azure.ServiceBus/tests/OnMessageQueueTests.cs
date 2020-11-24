// Copyright (c) Microsoft. All rights reserved.
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
            // Expected structure: { usePartitionedQueue, useSessionQueue, maxCurrentCalls }
            new object[] { false, false, 1 },
            new object[] { false, false, 10 },
            new object[] { true, false, 1 },
            new object[] { true, false, 10 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnMessagePeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnMessagePeekLockWithAutoCompleteFalse(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task OnMessageReceiveDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task OnMessageRegistrationWithoutPendingMessagesReceiveAndDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task OnMessageExceptionHandlerCalledTest()
        {
            var invalidQueueName = "nonexistentqueuename";
            var exceptionReceivedHandlerCalled = false;

            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, invalidQueueName, ReceiveMode.ReceiveAndDelete);
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

        private async Task OnMessageTestAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
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
            });

            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, mode);
                try
                {
                    await this.OnMessageAsyncUnregisterHandlerLongTimeoutTestCase(
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
            });

            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, mode);
                try
                {
                    await this.OnMessageAsyncUnregisterHandlerShortTimeoutTestCase(
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
            });
        }
    }
}