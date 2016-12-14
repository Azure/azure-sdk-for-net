// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class QueueSessionTestBase
    {
        protected QueueSessionTestBase(ITestOutputHelper output)
        {
            this.Output = output;
        }

        protected string ConnectionString { get; set; }

        protected ITestOutputHelper Output { get; set; }

        public async Task SessionTestCase()
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                string messageId1 = "test-message1";
                string sessionId1 = "sessionId1";
                await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId1, SessionId = sessionId1 });
                TestUtility.Log(this.Output, $"Sent Message: {messageId1} to Session: {sessionId1}");

                string messageId2 = "test-message2";
                string sessionId2 = "sessionId2";
                await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId2, SessionId = sessionId2 });
                TestUtility.Log(this.Output, $"Sent Message: {messageId2} to Session: {sessionId2}");

                // Receive Message, Complete and Close with SessionId - sessionId 1
                await this.AcceptAndCompleteSessionsAsync(queueClient, sessionId1, messageId1);

                // Receive Message, Complete and Close with SessionId - sessionId 2
                await this.AcceptAndCompleteSessionsAsync(queueClient, sessionId2, messageId2);

                // Receive Message, Complete and Close - With Null SessionId specified
                string messageId3 = "test-message3";
                string sessionId3 = "sessionId3";
                await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId3, SessionId = sessionId3 });

                await this.AcceptAndCompleteSessionsAsync(queueClient, null, messageId3);
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task GetAndSetSessionStateTestCase()
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                string messageId = "test-message1";
                string sessionId = Guid.NewGuid().ToString();
                await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId, SessionId = sessionId });
                TestUtility.Log(this.Output, $"Sent Message: {messageId} to Session: {sessionId}");

                MessageSession sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
                Assert.NotNull((object)sessionReceiver);
                BrokeredMessage message = await sessionReceiver.ReceiveAsync();
                TestUtility.Log(this.Output, $"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                Assert.True(message.MessageId == messageId);

                string sessionStateString = "Received Message From Session!";
                Stream sessionState = new MemoryStream(Encoding.UTF8.GetBytes(sessionStateString));
                await sessionReceiver.SetStateAsync(sessionState);
                TestUtility.Log(this.Output, $"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                Stream returnedSessionState = await sessionReceiver.GetStateAsync();
                using (StreamReader reader = new StreamReader(returnedSessionState, Encoding.UTF8))
                {
                    string returnedSessionStateString = reader.ReadToEnd();
                    TestUtility.Log(this.Output, $"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);
                }

                // Complete message using Session Receiver
                await sessionReceiver.CompleteAsync(new Guid[] { message.LockToken });
                TestUtility.Log(this.Output, $"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");

                sessionStateString = "Completed Message On Session!";
                sessionState = new MemoryStream(Encoding.UTF8.GetBytes(sessionStateString));
                await sessionReceiver.SetStateAsync(sessionState);
                TestUtility.Log(this.Output, $"Set Session State: {sessionStateString} for Session: {sessionReceiver.SessionId}");

                returnedSessionState = await sessionReceiver.GetStateAsync();
                using (StreamReader reader = new StreamReader(returnedSessionState, Encoding.UTF8))
                {
                    string returnedSessionStateString = reader.ReadToEnd();
                    TestUtility.Log(this.Output, $"Get Session State Returned: {returnedSessionStateString} for Session: {sessionReceiver.SessionId}");
                    Assert.Equal(sessionStateString, returnedSessionStateString);
                }

                await sessionReceiver.CloseAsync();
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task SessionRenewLockTestCase()
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                string messageId = "test-message1";
                string sessionId = Guid.NewGuid().ToString();
                await queueClient.SendAsync(new BrokeredMessage() { MessageId = messageId, SessionId = sessionId });
                TestUtility.Log(this.Output, $"Sent Message: {messageId} to Session: {sessionId}");

                MessageSession sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
                Assert.NotNull((object)sessionReceiver);
                DateTime initialSessionLockedUntilTime = sessionReceiver.LockedUntilUtc;
                TestUtility.Log(this.Output, $"Session LockedUntilUTC: {initialSessionLockedUntilTime} for Session: {sessionReceiver.SessionId}");
                BrokeredMessage message = await sessionReceiver.ReceiveAsync();
                TestUtility.Log(this.Output, $"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                Assert.True(message.MessageId == messageId);

                TestUtility.Log(this.Output, "Sleeping 10 seconds...");
                Thread.Sleep(TimeSpan.FromSeconds(10));

                await sessionReceiver.RenewLockAsync();
                DateTime firstLockedUntilUtcTime = sessionReceiver.LockedUntilUtc;
                TestUtility.Log(this.Output, $"After Renew Session LockedUntilUTC: {firstLockedUntilUtcTime} for Session: {sessionReceiver.SessionId}");
                Assert.True(firstLockedUntilUtcTime >= initialSessionLockedUntilTime + TimeSpan.FromSeconds(10));

                TestUtility.Log(this.Output, "Sleeping 5 seconds...");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                await sessionReceiver.RenewLockAsync();
                TestUtility.Log(this.Output, $"After Second Renew Session LockedUntilUTC: {sessionReceiver.LockedUntilUtc} for Session: {sessionReceiver.SessionId}");
                Assert.True(sessionReceiver.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(5));
                await message.CompleteAsync();
                TestUtility.Log(this.Output, $"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");
                await sessionReceiver.CloseAsync();
            }
            finally
            {
                queueClient.Close();
            }
        }

        // Session Helpers
        async Task AcceptAndCompleteSessionsAsync(QueueClient queueClient, string sessionId, string messageId)
        {
            MessageSession sessionReceiver = await queueClient.AcceptMessageSessionAsync(sessionId);
            {
                if (sessionId != null)
                {
                    Assert.True(sessionReceiver.SessionId == sessionId);
                }
                BrokeredMessage message = await sessionReceiver.ReceiveAsync();
                Assert.True(message.MessageId == messageId);
                TestUtility.Log(this.Output, $"Received Message: {message.MessageId} from Session: {sessionReceiver.SessionId}");
                await message.CompleteAsync();
                TestUtility.Log(this.Output, $"Completed Message: {message.MessageId} for Session: {sessionReceiver.SessionId}");
                await sessionReceiver.CloseAsync();
            }
        }
    }
}