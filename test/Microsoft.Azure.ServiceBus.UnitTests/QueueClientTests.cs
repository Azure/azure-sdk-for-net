// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                await this.PeekLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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
            QueueClient queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                await this.PeekLockWithAbandonTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName));

            // Create DLQ Client To Receive DeadLetteredMessages
            var builder = new ServiceBusConnectionStringBuilder(TestUtility.GetEntityConnectionString(queueName));
            builder.EntityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            var deadLetterQueueClient = QueueClient.CreateFromConnectionString(builder.ToString());

            try
            {
                await this.PeekLockWithDeadLetterTestCase(queueClient.InnerSender, queueClient.InnerReceiver, deadLetterQueueClient.InnerReceiver, messageCount);
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
        async Task PeekLockDeferTest(string queueName, int messageCount = 10)
        {
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                await this.PeekLockDeferTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task BasicRenewLockTest(string queueName, int messageCount = 10)
        {
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                await this.RenewLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekAsyncTest(string queueName, int messageCount = 10)
        {
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.PeekAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTest(string queueName, int messageCount = 1)
        {
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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
            var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.CancelScheduledMessagesAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}