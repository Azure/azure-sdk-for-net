// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;

    public class ExpectedMessagingExceptionTests
    {
        [Fact]
        async Task MessageLockLostExceptionTest()
        {
            const int messageCount = 2;
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);

            var sender = new MessageSender(TestConstants.NonPartitionedQueueName, connection);
            var receiver = new MessageReceiver(TestConstants.NonPartitionedQueueName, connection, receiveMode: ReceiveMode.PeekLock);

            try
            {
                await TestUtility.SendMessagesAsync(sender, messageCount);
                var receivedMessages = await TestUtility.ReceiveMessagesAsync(receiver, messageCount);

                Assert.True(receivedMessages.Count() == messageCount);

                // Let the messages expire
                await Task.Delay(TimeSpan.FromMinutes(1));

                // Complete should throw
                await
                    Assert.ThrowsAsync<MessageLockLostException>(
                        async () => await TestUtility.CompleteMessagesAsync(receiver, receivedMessages));

                receivedMessages = await TestUtility.ReceiveMessagesAsync(receiver, messageCount);
                Assert.True(receivedMessages.Count() == messageCount);

                await TestUtility.CompleteMessagesAsync(receiver, receivedMessages);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        // TODO: Update this when Session is implemented
        /*
        [Fact]
        async Task SessionLockLostExceptionTest()
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient =
                (QueueClient)messagingFactory.CreateQueueClientFromConnectionString(
                    TestUtility.GetEntityConnectionString(TestConstants.SessionNonPartitionedQueueName));

            try
            {
                var messageId = "test-message1";
                var sessionId = Guid.NewGuid().ToString();
            await queueClient.SendAsync(new Message
                { MessageId = messageId, SessionId = sessionId });
                TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                MessageSession messageSession = await queueClient.AcceptMessageSessionAsync(sessionId);
            Assert.NotNull(messageSession);

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
            Assert.NotNull(messageSession);

                message = await messageSession.ReceiveAsync();
                TestUtility.Log($"Received Message: SessionId: {messageSession.SessionId}");

                await message.CompleteAsync();
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
        */

        [Fact]
        async Task CompleteOnPeekedMessagesShouldThrowTest()
        {
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);
            var sender = new MessageSender(TestConstants.NonPartitionedQueueName, connection);
            var receiver = new MessageReceiver(TestConstants.NonPartitionedQueueName, connection, receiveMode: ReceiveMode.ReceiveAndDelete);

            try
            {
                await TestUtility.SendMessagesAsync(sender, 1);
                var message = await receiver.PeekAsync();
                Assert.NotNull(message);
                await
                    Assert.ThrowsAsync<InvalidOperationException>(
                        async () => await receiver.CompleteAsync(message.SystemProperties.LockToken));

                message = await receiver.ReceiveAsync();
                Assert.NotNull((object)message);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}