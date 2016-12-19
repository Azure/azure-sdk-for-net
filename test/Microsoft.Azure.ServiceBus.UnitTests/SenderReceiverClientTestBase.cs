// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public abstract class SenderReceiverClientTestBase
    {
        protected async Task PeekLockTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        protected async Task ReceiveDeleteTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
            Assert.True(messageCount == receivedMessages.Count());
        }

        protected async Task PeekLockWithAbandonTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages and Abandon them
            int abandonMessagesCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, abandonMessagesCount);
            Assert.True(receivedMessages.Count() == abandonMessagesCount);

            await TestUtility.AbandonMessagesAsync(messageReceiver, receivedMessages);

            // Receive all 10 messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
            Assert.True(receivedMessages.Count() == messageCount);

            // TODO: Some reason for partitioned entities the delivery count is incorrect. Investigate and enable
            // 5 of these messages should have deliveryCount = 2
            int messagesWithDeliveryCount2 = receivedMessages.Where(message => message.DeliveryCount == 2).Count();
            TestUtility.Log($"Messages with Delivery Count 2: {messagesWithDeliveryCount2}");
            Assert.True(messagesWithDeliveryCount2 == abandonMessagesCount);

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        protected async Task PeekLockWithDeadLetterTestCase(MessageSender messageSender, MessageReceiver messageReceiver, MessageReceiver deadLetterReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages and Deadletter them
            int deadLetterMessageCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);

            await TestUtility.DeadLetterMessagesAsync(messageReceiver, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deadLetterMessageCount);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);

            // TODO: After implementing Receive(WithTimeSpan), Add Try another Receive, We should not get anything.
            // IEnumerable<BrokeredMessage> dummyMessages = await this.ReceiveMessagesAsync(queueClient, 10);
            // Assert.True(dummyMessages == null);

            // Receive 5 DLQ messages and Complete them
            receivedMessages = await TestUtility.ReceiveMessagesAsync(deadLetterReceiver, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);
            await TestUtility.CompleteMessagesAsync(deadLetterReceiver, receivedMessages);
        }

        protected async Task PeekLockDeferTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages And Defer them
            int deferMessagesCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deferMessagesCount);
            Assert.True(receivedMessages.Count() == deferMessagesCount);
            var sequenceNumbers = receivedMessages.Select(receivedMessage => receivedMessage.SequenceNumber);
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deferMessagesCount);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
            Assert.True(receivedMessages.Count() == messageCount - deferMessagesCount);

            // Receive / Abandon deferred messages
            receivedMessages = await messageReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
            Assert.True(receivedMessages.Count() == 5);
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages);

            // Receive Again and Check delivery count
            receivedMessages = await messageReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
            int count = receivedMessages.Where((message) => message.DeliveryCount == 3).Count();
            Assert.True(count == receivedMessages.Count());

            // Complete messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        protected async Task RenewLockTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive messages
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);

            BrokeredMessage message = receivedMessages.First();
            DateTime firstLockedUntilUtcTime = message.LockedUntilUtc;
            TestUtility.Log($"MessageLockedUntil: {firstLockedUntilUtcTime}");

            TestUtility.Log("Sleeping 10 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(10));

            DateTime lockedUntilUtcTime = await messageReceiver.RenewLockAsync(receivedMessages.First().LockToken);
            TestUtility.Log($"After First Renewal: {lockedUntilUtcTime}");
            Assert.True(lockedUntilUtcTime >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

            TestUtility.Log("Sleeping 5 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(5));

            lockedUntilUtcTime = await messageReceiver.RenewLockAsync(receivedMessages.First().LockToken);
            TestUtility.Log($"After Second Renewal: {lockedUntilUtcTime}");
            Assert.True(lockedUntilUtcTime >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(5));

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);

            Assert.True(receivedMessages.Count() == messageCount);
        }
    }
}