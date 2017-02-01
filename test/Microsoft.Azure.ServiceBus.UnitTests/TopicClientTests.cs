// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class TopicClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.NonPartitionedTopicName },
            new object[] { Constants.PartitionedTopicName }
        };

        string SubscriptionName => Constants.SubscriptionName;

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockTest(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientReceiveDeleteTestCase(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithAbandonTestCase(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockWithAbandonTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithDeadLetterTestCase(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName);

            // Create DLQ Client To Receive DeadLetteredMessages
            var builder = new ServiceBusConnectionStringBuilder(TestUtility.GetEntityConnectionString(topicName));
            var subscriptionDeadletterPath = EntityNameHelper.FormatDeadLetterPath(this.SubscriptionName);
            var deadLetterSubscriptionClient = SubscriptionClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(topicName), subscriptionDeadletterPath);

            try
            {
                await this.PeekLockWithDeadLetterTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, deadLetterSubscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await deadLetterSubscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
                await subscriptionClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockDeferTestCase(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockDeferTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientRenewLockTestCase(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName);
            try
            {
                await this.RenewLockTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekAsyncTest(string topicName, int messageCount = 10)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.PeekAsyncTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTest(string topicName, int messageCount = 1)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(string topicName, int messageCount = 1)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task CancelScheduledMessagesAsyncTest(string topicName, int messageCount = 1)
        {
            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.CancelScheduledMessagesAsyncTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }
    }
}