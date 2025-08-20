// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    public class ExpectedMessagingExceptionTests
    {
        [Fact]
        [LiveTest]
        public async Task MessageLockLostExceptionTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                const int messageCount = 2;

                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

                try
                {
                    await TestUtility.SendMessagesAsync(sender, messageCount);
                    var receivedMessages = await TestUtility.ReceiveMessagesAsync(receiver, messageCount);

                    Assert.True(receivedMessages.Count == messageCount);

                    // Let the messages expire
                    await Task.Delay(TimeSpan.FromMinutes(1));

                    // Complete should throw
                    await
                        Assert.ThrowsAsync<MessageLockLostException>(
                            async () => await TestUtility.CompleteMessagesAsync(receiver, receivedMessages));

                    receivedMessages = await TestUtility.ReceiveMessagesAsync(receiver, messageCount);
                    Assert.True(receivedMessages.Count == messageCount);

                    await TestUtility.CompleteMessagesAsync(receiver, receivedMessages);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        public async Task CompleteOnPeekedMessagesShouldThrowTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

                try
                {
                    await TestUtility.SendMessagesAsync(sender, 1);
                    var message = await receiver.PeekAsync();
                    Assert.NotNull(message);
                    await
                        Assert.ThrowsAsync<InvalidOperationException>(
                            async () => await receiver.CompleteAsync(message.SystemProperties.LockToken));

                    message = await receiver.ReceiveAsync();
                    Assert.NotNull(message);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        public async Task SessionLockLostExceptionTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName);

                try
                {
                    var messageId = "test-message1";
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(new Message { MessageId = messageId, SessionId = sessionId });
                    TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                    var sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    Assert.NotNull(sessionReceiver);
                    TestUtility.Log($"Received Session: SessionId: {sessionReceiver.SessionId}: LockedUntilUtc: {sessionReceiver.LockedUntilUtc}");

                    var message = await sessionReceiver.ReceiveAsync();
                    Assert.True(message.MessageId == messageId);
                    TestUtility.Log($"Received Message: MessageId: {message.MessageId}");

                    // Let the Session expire with some buffer time
                    TestUtility.Log($"Waiting for session lock to time out...");
                    await Task.Delay((sessionReceiver.LockedUntilUtc - DateTime.UtcNow) + TimeSpan.FromSeconds(10));

                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await sessionReceiver.ReceiveAsync());
                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await sessionReceiver.RenewSessionLockAsync());
                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await sessionReceiver.GetStateAsync());
                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await sessionReceiver.SetStateAsync(null));
                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken));

                    await sessionReceiver.CloseAsync();
                    TestUtility.Log($"Closed Session Receiver...");

                    //Accept a new Session and Complete the message
                    sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    Assert.NotNull(sessionReceiver);
                    TestUtility.Log($"Received Session: SessionId: {sessionReceiver.SessionId}");
                    message = await sessionReceiver.ReceiveAsync();
                    TestUtility.Log($"Received Message: MessageId: {message.MessageId}");
                    await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    await sessionReceiver.CloseAsync();
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        public async Task OperationsOnMessageSenderReceiverAfterCloseShouldThrowObjectDisposedExceptionTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

                await sender.CloseAsync();
                await receiver.CloseAsync();

                await Assert.ThrowsAsync<ObjectDisposedException>(async () => await sender.SendAsync(new Message(Encoding.UTF8.GetBytes("test"))));
                await Assert.ThrowsAsync<ObjectDisposedException>(async () => await receiver.ReceiveAsync());
                await Assert.ThrowsAsync<ObjectDisposedException>(async () => await receiver.CompleteAsync("blah"));
            });
        }

        [Fact]
        [LiveTest]
        public async Task OperationsOnMessageSessionAfterCloseShouldThrowObjectDisposedExceptionTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName);
                IMessageSession sessionReceiver = null;

                try
                {
                    var messageId = "test-message1";
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(new Message { MessageId = messageId, SessionId = sessionId });
                    TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                    sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    Assert.NotNull(sessionReceiver);
                    TestUtility.Log($"Received Session: SessionId: {sessionReceiver.SessionId}: LockedUntilUtc: {sessionReceiver.LockedUntilUtc}");

                    await sessionReceiver.CloseAsync();
                    await Assert.ThrowsAsync<ObjectDisposedException>(async () => await sessionReceiver.ReceiveAsync());
                    await Assert.ThrowsAsync<ObjectDisposedException>(async () => await sessionReceiver.GetStateAsync());
                    await Assert.ThrowsAsync<ObjectDisposedException>(async () => await sessionReceiver.SetStateAsync(null));

                    sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    Assert.NotNull(sessionReceiver);
                    TestUtility.Log($"Reaccept Session: SessionId: {sessionReceiver.SessionId}: LockedUntilUtc: {sessionReceiver.LockedUntilUtc}");

                    var message = await sessionReceiver.ReceiveAsync();
                    Assert.True(message.MessageId == messageId);
                    TestUtility.Log($"Received Message: MessageId: {message.MessageId}");
                    await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    await sessionReceiver.CloseAsync();
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        public async Task CreatingLinkToNonExistingEntityShouldThrowEntityNotFoundException()
        {
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, "nonExistingEntity"); // Covers queue and topic
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () => await receiver.ReceiveAsync());

            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatSubscriptionPath(topicName, "nonexistingsub"));
                await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () => await receiver.ReceiveAsync());
            });
        }
    }
}