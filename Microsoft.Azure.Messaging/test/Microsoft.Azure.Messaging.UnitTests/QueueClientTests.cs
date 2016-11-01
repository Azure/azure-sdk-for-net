// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Linq;
    using Xunit;

    public class QueueClientTests
    {
        const int MaxAttemptsCount = 5;
        public QueueClientTests()
        {
            ConnectionString = Environment.GetEnvironmentVariable("QUEUECLIENTCONNECTIONSTRING");
            
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new InvalidOperationException("QUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }
        }

        String ConnectionString { get; }

        [Fact]
        async Task BrokeredMessageOperationsTest()
        {
            //Create QueueClient with ReceiveDelete, 
            //Send and Receive a message, Try to Complete/Abandon/Defer/DeadLetter should throw InvalidOperationException()
            QueueClient queueClient = QueueClient.Create(this.ConnectionString, ReceiveMode.ReceiveAndDelete);
            await this.SendMessagesAsync(queueClient, 1);
            BrokeredMessage message = await queueClient.ReceiveAsync();
            Assert.NotNull((object)message);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.CompleteAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.AbandonAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeferAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeadLetterAsync());

            //Create a PeekLock queueClient and do rest of the operations
            //Send a Message, Receive/ Abandon and Complete it using BrokeredMessage methods
            queueClient = QueueClient.Create(this.ConnectionString);
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            Assert.NotNull((object)message);
            await message.AbandonAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            message = await queueClient.ReceiveAsync();
            await message.CompleteAsync();

            //Send a Message, Receive/DeadLetter using BrokeredMessage methods
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            await message.DeadLetterAsync();
            string entityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.Create(this.ConnectionString, entityPath);
            message = await deadLetterQueueClient.ReceiveAsync();
            await message.CompleteAsync();

            //Send a Message, Receive/Defer using BrokeredMessage methods
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            await message.DeferAsync();

            //TODO: Once ReceivebySequence is implemented, Receive and Complete this message
        }

        [Fact]
        async Task QueueClientBasicPeekLockTest()
        {
            const int messageCount = 10;

            //Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.ConnectionString);

            //Send messages
            await this.SendMessagesAsync(queueClient, messageCount);

            //Receive messages
            IEnumerable<BrokeredMessage> receivedMessages = await ReceiveMessagesAsync(queueClient, messageCount);

            //Complete Messages
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            Assert.True(receivedMessages.Count() == messageCount);
        }

        [Fact]
        async Task QueueClientBasicReceiveDeleteTest()
        {
            const int messageCount = 10;

            //Create QueueClient With ReceiveAndDelete
            QueueClient queueClient = QueueClient.Create(this.ConnectionString, ReceiveMode.ReceiveAndDelete);

            //Send messages
            await this.SendMessagesAsync(queueClient, messageCount);

            //Receive messages
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, messageCount);

            Assert.True(receivedMessages.Count() == messageCount);
        }

        [Fact]
        async Task QueueClientPeekLockWithAbandonTest()
        {
            const int messageCount = 10;

            //Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.ConnectionString);

            //Send messages
            await this.SendMessagesAsync(queueClient, messageCount);

            //Receive 5 messages and Abandon them
            int abandonMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await ReceiveMessagesAsync(queueClient, abandonMessagesCount);
            Assert.True(receivedMessages.Count() == abandonMessagesCount);

            await this.AbandonMessagesAsync(queueClient, receivedMessages);

            //Receive all 10 messages, 5 of them should have DeliveryCount = 2
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, messageCount);
            Assert.True(receivedMessages.Count() == messageCount);

            // 5 of these messages should have deliveryCount = 2
            int messagesWithDeliveryCount2 = receivedMessages.Where((message) => message.DeliveryCount == 2).Count();
            Assert.True(messagesWithDeliveryCount2 == abandonMessagesCount);

            //Complete Messages
            await this.CompleteMessagesAsync(queueClient, receivedMessages);
        }


        [Fact]
        async Task QueueClientPeekLockWithDeadLetterTest()
        {
            const int messageCount = 10;
            IEnumerable<BrokeredMessage> receivedMessages = null;

            //Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.ConnectionString);

            //Send messages
            await this.SendMessagesAsync(queueClient, messageCount);

            //Receive 5 messages and Deadletter them
            int deadLetterMessageCount = 5;
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);

            await this.DeadLetterMessagesAsync(queueClient, receivedMessages);

            //Receive and Complete 5 other regular messages
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, messageCount - deadLetterMessageCount);
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            ////TODO: After implementing Receive(WithTimeSpan), Add Try another Receive, We should not get anything.
            //IEnumerable<BrokeredMessage> dummyMessages = await this.ReceiveMessagesAsync(queueClient, 10);
            //Assert.True(dummyMessages == null);

            //Create DLQ Client and Receive DeadLetteredMessages
            string entityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.Create(this.ConnectionString, entityPath);

            //Receive 5 DLQ messages and Complete them
            receivedMessages = await this.ReceiveMessagesAsync(deadLetterQueueClient, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);
            await this.CompleteMessagesAsync(deadLetterQueueClient, receivedMessages);
        }

        [Fact]
        async Task QueueClientPeekLockDeferTest()
        {
            const int messageCount = 10;

            //Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.ConnectionString);

            //Send messages
            await this.SendMessagesAsync(queueClient, messageCount);

            //Receive 5 messages And Defer them 
            int deferMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, deferMessagesCount);
            Assert.True(receivedMessages.Count() == deferMessagesCount);

            await this.DeferMessagesAsync(queueClient, receivedMessages);

            //Receive and Complete 5 other regular messages
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, messageCount - deferMessagesCount);
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            Assert.True(receivedMessages.Count() == messageCount - deferMessagesCount);

            //Once Request response link is implemented,  Call ReceiveBySequenceNumber() here and complete the rest of the 5 messages
        }

        async Task SendMessagesAsync(QueueClient queueClient, int messageCount)
        {
            if (messageCount == 0)
            {
                await Task.FromResult(false);
            }

            List<BrokeredMessage> messagesToSend = new List<BrokeredMessage>();
            for (int i = 0; i < messageCount; i++)
            {
                BrokeredMessage message = new BrokeredMessage("test" + i);
                message.Label = "test" + i;
                messagesToSend.Add(message);
            }

            await queueClient.SendAsync(messagesToSend);
            WriteLine(string.Format("Sent {0} messages", messageCount));
        }

        async Task<IEnumerable<BrokeredMessage>> ReceiveMessagesAsync(QueueClient queueClient, int messageCount)
        {
            int receiveAttempts = 0;
            List<BrokeredMessage> messagesToReturn = new List<BrokeredMessage>(); 

            while (receiveAttempts++ < QueueClientTests.MaxAttemptsCount && messagesToReturn.Count < messageCount)
            {
                var messages = await queueClient.ReceiveAsync(messageCount);
                if (messages != null)
                {
                    messagesToReturn.AddRange(messages); 
                }
            }

            WriteLine(string.Format("Received {0} messages", messagesToReturn.Count));
            
            return messagesToReturn;
        }

        async Task CompleteMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.CompleteAsync(messages.Select(message => message.LockToken));
            WriteLine(string.Format("Completed {0} messages", messages.Count()));
        }

        async Task AbandonMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.AbandonAsync(messages.Select(message => message.LockToken));
            WriteLine(string.Format("Abandoned {0} messages", messages.Count()));
        }

        async Task DeadLetterMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.DeadLetterAsync(messages.Select(message => message.LockToken));
            WriteLine(string.Format("Deadlettered {0} messages", messages.Count()));
        }

        async Task DeferMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.DeferAsync(messages.Select(message => message.LockToken));
            WriteLine(string.Format("Deferred {0} messages", messages.Count()));
        }

        static void WriteLine(string message)
        {
            // Currently xunit2 for .net core doesn't seem to have any output mechanism.  If we find one, replace these here:
            message = DateTime.Now.TimeOfDay + " " + message;
            Debug.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
