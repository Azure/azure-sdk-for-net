// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// TODO: Commenting the whole file. It will be updated once OnSession() is implemented.
/*
namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class QueueSessionTests
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.SessionNonPartitionedQueueName },
            new object[] { Constants.SessionPartitionedQueueName },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task SessionTest(string queueName)
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient = (QueueClient)messagingFactory.CreateQueueClientFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                var messageId1 = "test-message1";
                var sessionId1 = "sessionId1";
                await queueClient.SendAsync(new Message() { MessageId = messageId1, SessionId = sessionId1 });
                TestUtility.Log($"Sent Message: {messageId1} to Session: {sessionId1}");

                var messageId2 = "test-message2";
                var sessionId2 = "sessionId2";
                await queueClient.SendAsync(new Message() { MessageId = messageId2, SessionId = sessionId2 });
                TestUtility.Log($"Sent Message: {messageId2} to Session: {sessionId2}");

                // Receive Message, Complete and Close with SessionId - sessionId 1
                await this.AcceptAndCompleteSessionsAsync(queueClient, sessionId1, messageId1);

                // Receive Message, Complete and Close with SessionId - sessionId 2
                await this.AcceptAndCompleteSessionsAsync(queueClient, sessionId2, messageId2);

                // Receive Message, Complete and Close - With Null SessionId specified
                var messageId3 = "test-message3";
                var sessionId3 = "sessionId3";
                await queueClient.SendAsync(new Message() { MessageId = messageId3, SessionId = sessionId3 });

                await this.AcceptAndCompleteSessionsAsync(queueClient, null, messageId3);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task GetAndSetSessionStateTest(string queueName)
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient = (QueueClient)messagingFactory.CreateQueueClientFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                var messageId = "test-message1";
                var sessionId = Guid.NewGuid().ToString();
                await queueClient.SendAsync(new Message() { MessageId = messageId, SessionId = sessionId });
                TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                var sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
                Assert.NotNull(sessionReceiver);
                var message = await sessionReceiver.ReceiveAsync();
                TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                Assert.True(message.MessageId == messageId);

                var sessionStateString = "Received Message From Session!";
                var sessionState = new MemoryStream(Encoding.UTF8.GetBytes(sessionStateString));
                await sessionReceiver.SetStateAsync(sessionState);
                TestUtility.Log($"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                var returnedSessionState = await sessionReceiver.GetStateAsync();
                using (var reader = new StreamReader(returnedSessionState, Encoding.UTF8))
                {
                    var returnedSessionStateString = await reader.ReadToEndAsync();
                    TestUtility.Log($"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);
                }

                // Complete message using Session Receiver
                await sessionReceiver.CompleteAsync(new[] { message.LockToken });
                TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");

                sessionStateString = "Completed Message On Session!";
                sessionState = new MemoryStream(Encoding.UTF8.GetBytes(sessionStateString));
                await sessionReceiver.SetStateAsync(sessionState);
                TestUtility.Log($"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                returnedSessionState = await sessionReceiver.GetStateAsync();
                using (var reader = new StreamReader(returnedSessionState, Encoding.UTF8))
                {
                    var returnedSessionStateString = await reader.ReadToEndAsync();
                    TestUtility.Log($"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);
                }

                await sessionReceiver.CloseAsync();
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task SessionRenewLockTest(string queueName)
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient = messagingFactory.CreateQueueClientFromConnectionString(TestUtility.GetEntityConnectionString(queueName));
            try
            {
                var messageId = "test-message1";
                var sessionId = Guid.NewGuid().ToString();
                await queueClient.SendAsync(new Message() { MessageId = messageId, SessionId = sessionId });
                TestUtility.Log($"Sent Message: {messageId} to Session: {sessionId}");

                var sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
                Assert.NotNull(sessionReceiver);
                DateTime initialSessionLockedUntilTime = sessionReceiver.LockedUntilUtc;
                TestUtility.Log($"Session LockedUntilUTC: {initialSessionLockedUntilTime} for Session: {sessionReceiver.SessionId}");
                Message message = await sessionReceiver.ReceiveAsync();
                TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                Assert.True(message.MessageId == messageId);

                TestUtility.Log("Sleeping 10 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(10));

                await sessionReceiver.RenewLockAsync();
                DateTime firstLockedUntilUtcTime = sessionReceiver.LockedUntilUtc;
                TestUtility.Log($"After Renew Session LockedUntilUTC: {firstLockedUntilUtcTime} for Session: {sessionReceiver.SessionId}");
                Assert.True(firstLockedUntilUtcTime >= initialSessionLockedUntilTime + TimeSpan.FromSeconds(10));

                TestUtility.Log("Sleeping 5 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(5));

                await sessionReceiver.RenewLockAsync();
                TestUtility.Log($"After Second Renew Session LockedUntilUTC: {sessionReceiver.LockedUntilUtc} for Session: {sessionReceiver.SessionId}");
                Assert.True(sessionReceiver.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(5));
                await message.CompleteAsync();
                TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");
                await sessionReceiver.CloseAsync();
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekSessionAsyncTest(string queueName, int messageCount = 10)
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient = (QueueClient)messagingFactory.CreateQueueClientFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                var messageId1 = "test-message1";
                var sessionId1 = "sessionId1";
                await queueClient.SendAsync(new Message() { MessageId = messageId1, SessionId = sessionId1 });
                TestUtility.Log($"Sent Message: {messageId1} to Session: {sessionId1}");

                var messageId2 = "test-message2";
                var sessionId2 = "sessionId2";
                await queueClient.SendAsync(new Message() { MessageId = messageId2, SessionId = sessionId2 });
                TestUtility.Log($"Sent Message: {messageId2} to Session: {sessionId2}");

                // Peek Message, Receive and Delete with SessionId - sessionId 1
                await this.PeekAndDeleteMessageAsync(queueClient, sessionId1, messageId1);

                // Peek Message, Receive and Delete with SessionId - sessionId 2
                await this.PeekAndDeleteMessageAsync(queueClient, sessionId2, messageId2);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task AcceptSessionShouldReturnNoLaterThanServerWaitTimeTestCase(string queueName, int messageCount = 1)
        {
            var messagingFactory = new ServiceBusClientFactory();
            var queueClient = (QueueClient)messagingFactory.CreateQueueClientFromConnectionString(TestUtility.GetEntityConnectionString(queueName), ReceiveMode.ReceiveAndDelete);
            try
            {
                Stopwatch timer = Stopwatch.StartNew();

                MessageSession sessionReceiver = null;
                try
                {
                    sessionReceiver = await queueClient.AcceptMessageSessionAsync(TimeSpan.FromSeconds(2));
                }
                catch (TimeoutException)
                {
                }

                timer.Stop();

                // If sessionId is not null, then the queue needs to be cleaned up before running the timeout test.
                Assert.Null(sessionReceiver?.SessionId);

                // Ensuring total time taken is less than 60 seconds, which is the default timeout for AcceptMessageSessionAsync.
                // Keeping the value of 40 to avoid flakiness in test infrastructure which may lead to extended time taken.
                // Todo: Change this value to a lower number once test infra is performant.
                Assert.True(timer.Elapsed.TotalSeconds < 40);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        async Task AcceptAndCompleteSessionsAsync(QueueClient queueClient, string sessionId, string messageId)
        {
            var sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
            if (sessionId != null)
            {
                Assert.True(sessionReceiver.SessionId == sessionId);
            }

            var message = await sessionReceiver.ReceiveAsync();
            Assert.True(message.MessageId == messageId);
            TestUtility.Log($"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");

            await message.CompleteAsync();
            TestUtility.Log($"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");

            await sessionReceiver.CloseAsync();
        }

        async Task PeekAndDeleteMessageAsync(QueueClient queueClient, string sessionId, string messageId)
        {
            var sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
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
*/