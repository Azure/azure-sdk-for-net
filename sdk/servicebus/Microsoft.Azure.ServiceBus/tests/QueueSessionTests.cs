// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    public sealed class QueueSessionTests
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue }
            new object[] { false, true },
            new object[] { true, true }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task GetAndSetSessionStateTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName);

                try
                {
                    var messageId = "test-message1";
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(new Message
                    {
                        MessageId = messageId,
                        SessionId = sessionId
                    });
                    TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                    var sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    Assert.NotNull(sessionReceiver);
                    var message = await sessionReceiver.ReceiveAsync();
                    TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                    Assert.True(message.MessageId == messageId);

                    var sessionStateString = "Received Message From Session!";
                    var sessionState = Encoding.UTF8.GetBytes(sessionStateString);
                    await sessionReceiver.SetStateAsync(sessionState);
                    TestUtility.Log($"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                    var returnedSessionState = await sessionReceiver.GetStateAsync();
                    var returnedSessionStateString = Encoding.UTF8.GetString(returnedSessionState);
                    TestUtility.Log($"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);

                    // Complete message using Session Receiver
                    await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");

                    sessionStateString = "Completed Message On Session!";
                    sessionState = Encoding.UTF8.GetBytes(sessionStateString);
                    await sessionReceiver.SetStateAsync(sessionState);
                    TestUtility.Log($"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                    returnedSessionState = await sessionReceiver.GetStateAsync();
                    returnedSessionStateString = Encoding.UTF8.GetString(returnedSessionState);
                    TestUtility.Log($"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);

                    await sessionReceiver.CloseAsync();
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SessionRenewLockTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
                    TestUtility.Log($"Session LockedUntilUTC: {sessionReceiver.LockedUntilUtc} for Session: {sessionReceiver.SessionId}");
                    var message = await sessionReceiver.ReceiveAsync();
                    TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                    Assert.True(message.MessageId == messageId);

                    TestUtility.Log("Sleeping 10 seconds...");
                    await Task.Delay(TimeSpan.FromSeconds(10));

                    // For session it looks like when the session is received, sometimes the session LockedUntil UTC
                    // is turning out slightly more than the Default Lock Duration(lock is for 1 minute, but the session was locked
                    // for 1 min and 2 seconds. We will need to look at if this is an issue on service or some kind of time skew.
                    // Temporarily changing this test to look at the renew request time instead.
                    var renewRequestTime = DateTime.UtcNow;
                    await sessionReceiver.RenewSessionLockAsync();
                    var firstLockedUntilUtcTime = sessionReceiver.LockedUntilUtc;
                    TestUtility.Log($"After Renew Session LockedUntilUTC: {firstLockedUntilUtcTime} for Session: {sessionReceiver.SessionId}");
                    Assert.True(firstLockedUntilUtcTime >= renewRequestTime + TimeSpan.FromSeconds(10));

                    TestUtility.Log("Sleeping 5 seconds...");
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    renewRequestTime = DateTime.UtcNow;
                    await sessionReceiver.RenewSessionLockAsync();
                    TestUtility.Log($"After Second Renew Session LockedUntilUTC: {sessionReceiver.LockedUntilUtc} for Session: {sessionReceiver.SessionId}");
                    Assert.True(sessionReceiver.LockedUntilUtc >= renewRequestTime + TimeSpan.FromSeconds(5));
                    await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
                    TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");
                    await sessionReceiver.CloseAsync();
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekSessionAsyncTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                try
                {
                    var messageId1 = "test-message1";
                    var sessionId1 = "sessionId1";
                    await sender.SendAsync(new Message { MessageId = messageId1, SessionId = sessionId1 });
                    TestUtility.Log($"Sent Message: {messageId1} to Session: {sessionId1}");

                    var messageId2 = "test-message2";
                    var sessionId2 = "sessionId2";
                    await sender.SendAsync(new Message { MessageId = messageId2, SessionId = sessionId2 });
                    TestUtility.Log($"Sent Message: {messageId2} to Session: {sessionId2}");

                    // Peek Message, Receive and Delete with SessionId - sessionId 1
                    await this.PeekAndDeleteMessageAsync(sessionClient, sessionId1, messageId1);

                    // Peek Message, Receive and Delete with SessionId - sessionId 2
                    await this.PeekAndDeleteMessageAsync(sessionClient, sessionId2, messageId2);
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveDeferredMessageForSessionTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sessionId = Guid.NewGuid().ToString("N").Substring(0, 8);
                var messageId = Guid.NewGuid().ToString("N").Substring(0, 8);
                var sender = default(MessageSender);
                var sessionClient = default(SessionClient);
                var messageSession = default(IMessageSession);

                try
                {
                    sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                    await sender.SendAsync(new Message() { SessionId = sessionId, MessageId = messageId });

                    sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName);
                    messageSession = await sessionClient.AcceptMessageSessionAsync(sessionId);
                    var msg = await messageSession.ReceiveAsync();
                    var seqNum = msg.SystemProperties.SequenceNumber;
                    await messageSession.DeferAsync(msg.SystemProperties.LockToken);
                    var msg2 = await messageSession.ReceiveDeferredMessageAsync(seqNum);

                    Assert.Equal(seqNum, msg2.SystemProperties.SequenceNumber);
                    Assert.Equal(messageId, msg2.MessageId);
                }
                finally
                {
                    await sender?.CloseAsync();
                    await sessionClient?.CloseAsync();
                    await messageSession?.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task AcceptSessionThrowsSessionCannotBeLockedException()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: true, sessionEnabled: true, async queueName =>
            {
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName);
                var someSessionId = "someSessionId";
                IMessageSession session = null;

                try
                {
                    session = await sessionClient.AcceptMessageSessionAsync(someSessionId);
                    await Assert.ThrowsAsync<SessionCannotBeLockedException>(async () =>
                        session = await sessionClient.AcceptMessageSessionAsync(someSessionId));
                }
                finally
                {
                    await sessionClient.CloseAsync();
                    await session?.CloseAsync();
                }
            });
        }

        private async Task AcceptAndCompleteSessionsAsync(SessionClient sessionClient, string sessionId, string messageId)
        {
            var sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
            if (sessionId != null)
            {
                Assert.True(sessionReceiver.SessionId == sessionId);
            }

            var message = await sessionReceiver.ReceiveAsync();
            Assert.True(message.MessageId == messageId);
            TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");

            await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
            await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);
            TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");

            await sessionReceiver.CloseAsync();
        }

        private async Task PeekAndDeleteMessageAsync(SessionClient sessionClient, string sessionId, string messageId)
        {
            var sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
            if (sessionId != null)
            {
                Assert.True(sessionReceiver.SessionId == sessionId);
            }

            var message = await sessionReceiver.PeekAsync();
            Assert.True(message.MessageId == messageId);
            TestUtility.Log($"Peeked Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");

            message = await sessionReceiver.ReceiveAsync();
            Assert.True(message.MessageId == messageId);
            TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");

            await sessionReceiver.CloseAsync();
        }
    }
}
