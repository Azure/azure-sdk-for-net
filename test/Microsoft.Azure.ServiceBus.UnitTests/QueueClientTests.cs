// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    public sealed class QueueClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.NonPartitionedQueueName },
            new object[] { Constants.PartitionedQueueName }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.PeekLockTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveDeleteTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockWithAbandonTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.PeekLockWithAbandonTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockWithDeadLetterTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);

            // Create DLQ Client To Receive DeadLetteredMessages
            var deadLetterQueueClient = new QueueClient(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName));

            try
            {
                await
                    this.PeekLockWithDeadLetterTestCase(
                        queueClient.InnerClient.InnerSender,
                        queueClient.InnerClient.InnerReceiver,
                        deadLetterQueueClient.InnerClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await deadLetterQueueClient.CloseAsync();
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task BasicRenewLockTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.RenewLockTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(string queueName, int messageCount = 1)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task CancelScheduledMessagesAsyncTest(string queueName, int messageCount = 1)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.CancelScheduledMessagesAsyncTestCase(queueClient.InnerClient.InnerSender, queueClient.InnerClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}