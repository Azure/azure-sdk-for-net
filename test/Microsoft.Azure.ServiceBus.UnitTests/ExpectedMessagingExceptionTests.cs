// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ExpectedMessagingExceptionTests
    {
        [Fact]
        async Task MessageLockLostExceptionTest()
        {
            const int messageCount = 2;
            var queueClient = QueueClient.CreateFromConnectionString(
                TestUtility.GetEntityConnectionString(Constants.NonPartitionedQueueName));

            await TestUtility.SendMessagesAsync(queueClient.InnerSender, messageCount);
            var receivedMessages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, messageCount);

            Assert.True(receivedMessages.Count() == messageCount);

            // Let the messages expire
            await Task.Delay(TimeSpan.FromMinutes(1));

            // Complete should throw
            await Assert.ThrowsAsync<MessageLockLostException>(async () => await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, receivedMessages));

            receivedMessages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, messageCount);
            Assert.True(receivedMessages.Count() == messageCount);

            await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, receivedMessages);
        }

        [Fact]
        async Task SessionLockLostExceptionTest()
        {
            var queueClient = QueueClient.CreateFromConnectionString(
                TestUtility.GetEntityConnectionString(Constants.SessionNonPartitionedQueueName));

            var messageId = "test-message1";
            var sessionId = Guid.NewGuid().ToString();
            await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId, SessionId = sessionId });
            TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

            MessageSession messageSession = await queueClient.AcceptMessageSessionAsync(sessionId);
            Assert.NotNull((object)messageSession);

            var message = await messageSession.ReceiveAsync();
            Assert.True(message.MessageId == messageId);
            TestUtility.Log($"Received Message: SessionId: {messageSession.SessionId}");

            // Let the Session expire
            await Task.Delay(TimeSpan.FromMinutes(1));

            // Complete should throw
            await Assert.ThrowsAsync<SessionLockLostException>(async () => await message.CompleteAsync());
            try
            {
                await messageSession.CloseAsync();
            }
            catch (Exception e)
            {
                TestUtility.Log($"Got Exception on Session Close(): SessionId: {messageSession.SessionId}, Exception: {e.Message}");
            }

            messageSession = await queueClient.AcceptMessageSessionAsync(sessionId);
            Assert.NotNull((object)messageSession);

            message = await messageSession.ReceiveAsync();
            TestUtility.Log($"Received Message: SessionId: {messageSession.SessionId}");

            await message.CompleteAsync();
        }
    }
}