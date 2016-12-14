// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class SenderReceiverClientTestBase
    {
        protected SenderReceiverClientTestBase(ITestOutputHelper output)
        {
            this.Output = output;
        }

        protected ITestOutputHelper Output { get; set; }

        public async Task PeekLockTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount, this.Output);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);
        }

        public async Task ReceiveDeleteTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount, this.Output);
            Assert.True(messageCount == receivedMessages.Count());
        }

        public async Task PeekLockWithAbandonTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);

            // Receive 5 messages and Abandon them
            int abandonMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, abandonMessagesCount, this.Output);
            Assert.True(receivedMessages.Count() == abandonMessagesCount);

            await TestUtility.AbandonMessagesAsync(messageReceiver, receivedMessages, this.Output);

            // Receive all 10 messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount, this.Output);
            Assert.True(receivedMessages.Count() == messageCount);

            // TODO: Some reason for partitioned entities the delivery count is incorrect. Investigate and enable
            // 5 of these messages should have deliveryCount = 2
            int messagesWithDeliveryCount2 = receivedMessages.Where(message => message.DeliveryCount == 2).Count();
            TestUtility.Log(this.Output, $"Messages with Delivery Count 2: {messagesWithDeliveryCount2}");
            Assert.True(messagesWithDeliveryCount2 == abandonMessagesCount);

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);
        }

        public async Task PeekLockWithDeadLetterTestCase(MessageSender messageSender, MessageReceiver messageReceiver, MessageReceiver deadLetterReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);

            // Receive 5 messages and Deadletter them
            int deadLetterMessageCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deadLetterMessageCount, this.Output);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);

            await TestUtility.DeadLetterMessagesAsync(messageReceiver, receivedMessages, this.Output);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deadLetterMessageCount, this.Output);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);

            // TODO: After implementing Receive(WithTimeSpan), Add Try another Receive, We should not get anything.
            // IEnumerable<BrokeredMessage> dummyMessages = await this.ReceiveMessagesAsync(queueClient, 10);
            // Assert.True(dummyMessages == null);

            // Receive 5 DLQ messages and Complete them
            receivedMessages = await TestUtility.ReceiveMessagesAsync(deadLetterReceiver, deadLetterMessageCount, this.Output);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);
            await TestUtility.CompleteMessagesAsync(deadLetterReceiver, receivedMessages, this.Output);
        }

        public async Task PeekLockDeferTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);

            // Receive 5 messages And Defer them
            int deferMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deferMessagesCount, this.Output);
            Assert.True(receivedMessages.Count() == deferMessagesCount);
            var sequenceNumbers = receivedMessages.Select(receivedMessage => receivedMessage.SequenceNumber);
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages, this.Output);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deferMessagesCount, this.Output);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);
            Assert.True(receivedMessages.Count() == messageCount - deferMessagesCount);

            // Receive / Abandon deferred messages
            receivedMessages = await messageReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
            Assert.True(receivedMessages.Count() == 5);
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages, this.Output);

            // Receive Again and Check delivery count
            receivedMessages = await messageReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
            int count = receivedMessages.Where((message) => message.DeliveryCount == 3).Count();
            Assert.True(count == receivedMessages.Count());

            // Complete messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);
        }

        public async Task RenewLockTestCase(MessageSender messageSender, MessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount, this.Output);

            // Receive messages
            IEnumerable<BrokeredMessage> receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount, this.Output);

            BrokeredMessage message = receivedMessages.First();
            DateTime firstLockedUntilUtcTime = message.LockedUntilUtc;
            TestUtility.Log(this.Output, $"MessageLockedUntil: {firstLockedUntilUtcTime}");

            TestUtility.Log(this.Output, "Sleeping 10 seconds...");
            Thread.Sleep(TimeSpan.FromSeconds(10));

            DateTime lockedUntilUtcTime = await messageReceiver.RenewLockAsync(receivedMessages.First().LockToken);
            TestUtility.Log(this.Output, $"After First Renewal: {lockedUntilUtcTime}");
            Assert.True(lockedUntilUtcTime >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

            TestUtility.Log(this.Output, "Sleeping 5 seconds...");
            Thread.Sleep(TimeSpan.FromSeconds(5));

            lockedUntilUtcTime = await messageReceiver.RenewLockAsync(receivedMessages.First().LockToken);
            TestUtility.Log(this.Output, $"After Second Renewal: {lockedUntilUtcTime}");
            Assert.True(lockedUntilUtcTime >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(5));

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages, this.Output);

            Assert.True(receivedMessages.Count() == messageCount);
        }
    }
}