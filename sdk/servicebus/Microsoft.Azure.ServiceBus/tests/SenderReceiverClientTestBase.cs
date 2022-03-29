// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    public abstract class SenderReceiverClientTestBase
    {
        internal async Task PeekLockTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
            TestUtility.VaidateMessageState(receivedMessages, MessageState.Active);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        internal async Task ReceiveDeleteTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount, TimeSpan timeout)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount, timeout);
            TestUtility.VaidateMessageState(receivedMessages, MessageState.Active);
            Assert.Equal(messageCount, receivedMessages.Count);
        }

        internal async Task PeekLockWithAbandonTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages and Abandon them
            var abandonMessagesCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, abandonMessagesCount);
            Assert.True(receivedMessages.Count == abandonMessagesCount);

            await TestUtility.AbandonMessagesAsync(messageReceiver, receivedMessages);

            // Receive all 10 messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
            Assert.True(receivedMessages.Count == messageCount);

            // TODO: Some reason for partitioned entities the delivery count is incorrect. Investigate and enable
            // 5 of these messages should have deliveryCount = 2
            var messagesWithDeliveryCount2 = receivedMessages.Where(message => message.SystemProperties.DeliveryCount == 2).Count();
            TestUtility.Log($"Messages with Delivery Count 2: {messagesWithDeliveryCount2}");
            Assert.True(messagesWithDeliveryCount2 == abandonMessagesCount);

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        internal async Task PeekLockWithDeadLetterTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, IMessageReceiver deadLetterReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages and Deadletter them
            var deadLetterMessageCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deadLetterMessageCount);
            Assert.True(receivedMessages.Count == deadLetterMessageCount);

            await TestUtility.DeadLetterMessagesAsync(messageReceiver, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deadLetterMessageCount);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);

            // TODO: After implementing Receive(WithTimeSpan), Add Try another Receive, We should not get anything.
            // IEnumerable<Message> dummyMessages = await this.ReceiveMessagesAsync(queueClient, 10);
            // Assert.True(dummyMessages == null);

            // Receive 5 DLQ messages and Complete them
            receivedMessages = await TestUtility.ReceiveMessagesAsync(deadLetterReceiver, deadLetterMessageCount);
            Assert.True(receivedMessages.Count == deadLetterMessageCount);
            await TestUtility.CompleteMessagesAsync(deadLetterReceiver, receivedMessages);
        }

        internal async Task PeekLockDeferTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive 5 messages And Defer them
            var deferMessagesCount = 5;
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, deferMessagesCount);
            Assert.True(receivedMessages.Count == deferMessagesCount);
            var sequenceNumbers = receivedMessages.Select(receivedMessage => receivedMessage.SystemProperties.SequenceNumber).ToList();
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount - deferMessagesCount);
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
            Assert.True(receivedMessages.Count == messageCount - deferMessagesCount);

            // Receive / Abandon deferred messages
            receivedMessages = await TestUtility.ReceiveDeferredMessagesAsync(messageReceiver, sequenceNumbers);
            Assert.True(receivedMessages.Count == 5);
            TestUtility.VaidateMessageState(receivedMessages, MessageState.Deferred);
            await TestUtility.DeferMessagesAsync(messageReceiver, receivedMessages);

            // Receive Again and Check delivery count
            receivedMessages = await TestUtility.ReceiveDeferredMessagesAsync(messageReceiver, sequenceNumbers);
            var count = receivedMessages.Count(message => message.SystemProperties.DeliveryCount == 3);
            TestUtility.VaidateMessageState(receivedMessages, MessageState.Deferred);
            Assert.True(count == receivedMessages.Count);

            // Complete messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);
        }

        internal async Task RenewLockTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            // Send messages
            await TestUtility.SendMessagesAsync(messageSender, messageCount);

            // Receive messages
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);

            var message = receivedMessages.First();
            var firstLockedUntilUtcTime = message.SystemProperties.LockedUntilUtc;
            TestUtility.Log($"MessageLockedUntil: {firstLockedUntilUtcTime}");

            TestUtility.Log("Sleeping 10 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(10));


            await messageReceiver.RenewLockAsync(message);
            TestUtility.Log($"After First Renewal: {message.SystemProperties.LockedUntilUtc}");
            Assert.True(message.SystemProperties.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

            TestUtility.Log("Sleeping 5 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(5));

            await messageReceiver.RenewLockAsync(message.SystemProperties.LockToken);
            TestUtility.Log($"After Second Renewal: {message.SystemProperties.LockedUntilUtc}");
            Assert.True(message.SystemProperties.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(5));

            // Complete Messages
            await TestUtility.CompleteMessagesAsync(messageReceiver, receivedMessages);

            Assert.True(receivedMessages.Count == messageCount);
        }

        internal async Task PeekAsyncTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            var peekedMessages = new List<Message>();
            peekedMessages.Add(await TestUtility.PeekMessageAsync(messageReceiver));
            peekedMessages.AddRange(await TestUtility.PeekMessagesAsync(messageReceiver, messageCount - 1));

            Assert.True(messageCount == peekedMessages.Count);
            long lastSequenceNumber = -1;
            foreach (var message in peekedMessages)
            {
                Assert.True(message.SystemProperties.SequenceNumber != lastSequenceNumber);
                lastSequenceNumber = message.SystemProperties.SequenceNumber;
            }

            await TestUtility.ReceiveMessagesAsync(messageReceiver, messageCount);
        }

        internal async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            var timer = Stopwatch.StartNew();
            TestUtility.Log($"starting Receive");
            var message = await messageReceiver.ReceiveAsync(TimeSpan.FromSeconds(2));
            timer.Stop();

            // If message is not null, then the queue needs to be cleaned up before running the timeout test.
            Assert.Null(message);

            // Ensuring total time taken is less than 60 seconds, which is the default timeout for receive.
            // Keeping the value of 40 to avoid flakiness in test infrastructure which may lead to extended time taken.
            // Todo: Change this value to a lower number once test infra is performant.
            TestUtility.Log($"Elapsed Milliseconds: {timer.Elapsed.TotalMilliseconds}");
            Assert.True(timer.Elapsed.TotalSeconds < 40);
        }

        internal async Task ReceiveShouldThrowForServerTimeoutZero(IMessageReceiver messageReceiver)
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => messageReceiver.ReceiveAsync(TimeSpan.Zero));
        }

        internal async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            var startTime = DateTime.UtcNow;
            var scheduleTime = new DateTimeOffset(DateTime.UtcNow).AddSeconds(5);
            TestUtility.Log($"Sending message with schedule time: {scheduleTime.UtcDateTime}");

            var sequenceNumber =
                await
                    messageSender.ScheduleMessageAsync(
                        new Message(Encoding.UTF8.GetBytes("Test")) { MessageId = "randomId", Label = "randomLabel" }, scheduleTime);
            TestUtility.Log($"Received sequence number: {sequenceNumber}");
            Assert.True(sequenceNumber > 0);

            TestUtility.Log("Sleeping for 5 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(5));

            var message = await messageReceiver.ReceiveAsync();

            // Asserting using Math.Ceiling since TotalSeconds usually ends up being around 4.999 due to precision of
            // the scheduleTime in requestMessage and responseMessage.
            Assert.True(Math.Ceiling(message.ScheduledEnqueueTimeUtc.Subtract(startTime).TotalSeconds) >= 5);
        }

        internal async Task CancelScheduledMessagesAsyncTestCase(IMessageSender messageSender, IMessageReceiver messageReceiver, int messageCount)
        {
            var scheduleTime = new DateTimeOffset(DateTime.UtcNow).AddSeconds(30);
            var brokeredMessage = new Message(Encoding.UTF8.GetBytes("Test1")) { MessageId = Guid.NewGuid().ToString() };
            TestUtility.Log(
                $"Sending message with schedule time: {scheduleTime.UtcDateTime} and messageID {brokeredMessage.MessageId}");

            var sequenceNumber = await messageSender.ScheduleMessageAsync(brokeredMessage, scheduleTime);
            TestUtility.Log($"Received sequence number: {sequenceNumber}");
            Assert.True(sequenceNumber > 0);

            TestUtility.Log("Cancelling scheduled message");
            await messageSender.CancelScheduledMessageAsync(sequenceNumber);

            TestUtility.Log("Sleeping for 30 seconds...");
            await Task.Delay(TimeSpan.FromSeconds(30));

            // Sending a dummy message so that ReceiveAsync(2) returns immediately after getting 1 message
            // instead of waiting for connection timeout on a single message.
            await messageSender.SendAsync(new Message(Encoding.UTF8.GetBytes(("Dummy"))) { MessageId = "Dummy" });
            IList<Message> messages = null;
            var retryCount = 5;
            while (messages == null && --retryCount > 0)
            {
                messages = await messageReceiver.ReceiveAsync(2);
            }

            Assert.NotNull(messages);
            Assert.True(messages.Count == 1);
            Assert.True(messages.First().MessageId == "Dummy");
        }

        internal async Task OnMessageAsyncTestCase(
            IMessageSender messageSender,
            IMessageReceiver messageReceiver,
            int maxConcurrentCalls,
            bool autoComplete,
            int messageCount)
        {
            var count = 0;
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock && !autoComplete)
                    {
                        await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    Interlocked.Increment(ref count);
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });

            // Wait for the OnMessage Tasks to finish
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 60)
            {
                if (count == messageCount)
                {
                    TestUtility.Log($"All '{messageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            Assert.True(count == messageCount);
        }

        internal async Task OnMessageAsyncUnregisterHandlerLongTimeoutTestCase(
            IMessageSender messageSender,
            IMessageReceiver messageReceiver,
            int maxConcurrentCalls,
            bool autoComplete,
            int messageCount)
        {
            var count = 0;
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    await Task.Delay(TimeSpan.FromSeconds(8));
                    if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock && !autoComplete)
                    {
                        await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    Interlocked.Increment(ref count);

                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });

            // UnregisterMessageHandlerAsync should wait up to the provided timeout to finish the message handling tasks
            await messageReceiver.UnregisterMessageHandlerAsync(TimeSpan.FromSeconds(10)); 
            Assert.True(count == maxConcurrentCalls);

            // Reregister won't have any problems
            count = 0;
            var remainingMessageCount = messageCount - maxConcurrentCalls;
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock && !autoComplete)
                    {
                        await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    Interlocked.Increment(ref count);
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });


            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 60)
            {
                if (count == remainingMessageCount)
                {
                    TestUtility.Log($"All '{remainingMessageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            Assert.True(count == remainingMessageCount);
        }

        internal async Task OnMessageAsyncUnregisterHandlerShortTimeoutTestCase(
            IMessageSender messageSender,
            IMessageReceiver messageReceiver,
            int maxConcurrentCalls,
            bool autoComplete,
            int messageCount)
        {
            var count = 0;
            await TestUtility.SendMessagesAsync(messageSender, messageCount);
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    await Task.Delay(TimeSpan.FromSeconds(8));
                    if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock && !autoComplete)
                    {
                        await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    Interlocked.Increment(ref count);
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });

            await messageReceiver.UnregisterMessageHandlerAsync(TimeSpan.FromSeconds(2));
            Assert.True(count == 0);

            // Reregister won't have any problems
            count = 0;
            var remainingMessageCount = messageCount - maxConcurrentCalls;
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock && !autoComplete)
                    {
                        await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    Interlocked.Increment(ref count);
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });
            
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 60)
            {
                if (count == remainingMessageCount)
                {
                    TestUtility.Log($"All '{remainingMessageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            Assert.True(count == remainingMessageCount);
        }
        
        internal async Task OnMessageRegistrationWithoutPendingMessagesTestCase(
            IMessageSender messageSender,
            IMessageReceiver messageReceiver,
            int maxConcurrentCalls,
            bool autoComplete)
        {
            var count = 0;
            messageReceiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    TestUtility.Log($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}");
                    Interlocked.Increment(ref count);
                    await Task.CompletedTask;
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = maxConcurrentCalls, AutoComplete = autoComplete });

            await TestUtility.SendMessagesAsync(messageSender, 1);

            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 20)
            {
                if (count == 1)
                {
                    TestUtility.Log($"All messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            TestUtility.Log($"{DateTime.Now}: MessagesReceived: {count}");
            Assert.True(count == 1);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            TestUtility.Log($"Exception Received: ClientId: {eventArgs.ExceptionReceivedContext.ClientId}, EntityPath: {eventArgs.ExceptionReceivedContext.EntityPath}, Exception: {eventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}