// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    public class QueueClientTests
    {
        const int MaxAttemptsCount = 5;
        readonly string connectionString;
        ITestOutputHelper output;

        public QueueClientTests(ITestOutputHelper output)
        {
            this.output = output;
            this.connectionString = Environment.GetEnvironmentVariable("QUEUECLIENTCONNECTIONSTRING");
            
            if (string.IsNullOrWhiteSpace(this.connectionString))
            {
                throw new InvalidOperationException("QUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }
        }

        [Fact]
        async Task BrokeredMessageOperationsTest()
        {
            // Create QueueClient with ReceiveDelete, 
            // Send and Receive a message, Try to Complete/Abandon/Defer/DeadLetter should throw InvalidOperationException()
            QueueClient queueClient = QueueClient.Create(this.connectionString, ReceiveMode.ReceiveAndDelete);
            await this.SendMessagesAsync(queueClient, 1);
            BrokeredMessage message = await queueClient.ReceiveAsync();
            Assert.NotNull(message);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.CompleteAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.AbandonAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeferAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeadLetterAsync());

            // Create a PeekLock queueClient and do rest of the operations
            // Send a Message, Receive/Abandon and Complete it using BrokeredMessage methods
            queueClient = QueueClient.Create(this.connectionString);
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            Assert.NotNull(message);
            await message.AbandonAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            message = await queueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive/DeadLetter using BrokeredMessage methods
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            await message.DeadLetterAsync();
            string entityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.Create(this.connectionString, entityPath);
            message = await deadLetterQueueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive/Defer using BrokeredMessage methods
            await this.SendMessagesAsync(queueClient, 1);
            message = await queueClient.ReceiveAsync();
            await message.DeferAsync();

            // TODO: Once ReceivebySequence is implemented, Receive and Complete this message
        }

        [Fact]
        async Task BasicPeekLockTest()
        {
            const int MessageCount = 10;

            // Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.connectionString);

            // Send messages
            await this.SendMessagesAsync(queueClient, MessageCount);

            // Receive messages
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, MessageCount);

            // Complete Messages
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            Assert.True(receivedMessages.Count() == MessageCount);
        }

        [Fact]
        async Task BasicReceiveDeleteTest()
        {
            const int MessageCount = 10;

            // Create QueueClient With ReceiveAndDelete
            QueueClient queueClient = QueueClient.Create(this.connectionString, ReceiveMode.ReceiveAndDelete);

            // Send messages
            await this.SendMessagesAsync(queueClient, MessageCount);

            // Receive messages
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, MessageCount);

            Assert.True(receivedMessages.Count() == MessageCount);
        }

        [Fact]
        async Task PeekLockWithAbandonTest()
        {
            const int MessageCount = 10;

            // Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.connectionString);

            // Send messages
            await this.SendMessagesAsync(queueClient, MessageCount);

            // Receive 5 messages and Abandon them
            int abandonMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, abandonMessagesCount);
            Assert.True(receivedMessages.Count() == abandonMessagesCount);

            await this.AbandonMessagesAsync(queueClient, receivedMessages);

            // Receive all 10 messages, 5 of them should have DeliveryCount = 2
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, MessageCount);
            Assert.True(receivedMessages.Count() == MessageCount);

            // 5 of these messages should have deliveryCount = 2
            int messagesWithDeliveryCount2 = receivedMessages.Count(message => message.DeliveryCount == 2);
            Assert.True(messagesWithDeliveryCount2 == abandonMessagesCount);

            // Complete Messages
            await this.CompleteMessagesAsync(queueClient, receivedMessages);
        }

        [Fact]
        async Task PeekLockWithDeadLetterTest()
        {
            const int MessageCount = 10;
            IEnumerable<BrokeredMessage> receivedMessages;

            // Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.connectionString);

            // Send messages
            await this.SendMessagesAsync(queueClient, MessageCount);

            // Receive 5 messages and Deadletter them
            int deadLetterMessageCount = 5;
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);

            await this.DeadLetterMessagesAsync(queueClient, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, MessageCount - deadLetterMessageCount);
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            // TODO: After implementing Receive(WithTimeSpan), Add Try another Receive, We should not get anything.
            // IEnumerable<BrokeredMessage> dummyMessages = await this.ReceiveMessagesAsync(queueClient, 10);
            // Assert.True(dummyMessages == null);

            // Create DLQ Client and Receive DeadLetteredMessages
            var entityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.Create(this.connectionString, entityPath);

            // Receive 5 DLQ messages and Complete them
            receivedMessages = await this.ReceiveMessagesAsync(deadLetterQueueClient, deadLetterMessageCount);
            Assert.True(receivedMessages.Count() == deadLetterMessageCount);
            await this.CompleteMessagesAsync(deadLetterQueueClient, receivedMessages);
        }

        [Fact]
        async Task PeekLockDeferTest()
        {
            const int MessageCount = 10;

            // Create QueueClient With PeekLock
            QueueClient queueClient = QueueClient.Create(this.connectionString);

            // Send messages
            await this.SendMessagesAsync(queueClient, MessageCount);

            // Receive 5 messages And Defer them 
            int deferMessagesCount = 5;
            IEnumerable<BrokeredMessage> receivedMessages = await this.ReceiveMessagesAsync(queueClient, deferMessagesCount);
            Assert.True(receivedMessages.Count() == deferMessagesCount);

            await this.DeferMessagesAsync(queueClient, receivedMessages);

            // Receive and Complete 5 other regular messages
            receivedMessages = await this.ReceiveMessagesAsync(queueClient, MessageCount - deferMessagesCount);
            await this.CompleteMessagesAsync(queueClient, receivedMessages);

            Assert.True(receivedMessages.Count() == MessageCount - deferMessagesCount);

            // Once Request response link is implemented,  Call ReceiveBySequenceNumber() here and complete the rest of the 5 messages
        }

        async Task SendMessagesAsync(QueueClient queueClient, int messageCount, [CallerMemberName] string invokingMethod = "")
        {
            if (messageCount == 0)
            {
                await Task.FromResult(false);
            }

            List<BrokeredMessage> messagesToSend = new List<BrokeredMessage>();
            for (int i = 0; i < messageCount; i++)
            {
                BrokeredMessage message = new BrokeredMessage("test" + i);
                message.Label = $"test{i}-{invokingMethod}";
                messagesToSend.Add(message);
            }

            await queueClient.SendAsync(messagesToSend);
            this.Log(string.Format("Sent {0} messages", messageCount));
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

            this.Log(string.Format("Received {0} messages", messagesToReturn.Count));
            
            return messagesToReturn;
        }

        async Task CompleteMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.CompleteAsync(messages.Select(message => message.LockToken));
            this.Log(string.Format("Completed {0} messages", messages.Count()));
        }

        async Task AbandonMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.AbandonAsync(messages.Select(message => message.LockToken));
            this.Log(string.Format("Abandoned {0} messages", messages.Count()));
        }

        async Task DeadLetterMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.DeadLetterAsync(messages.Select(message => message.LockToken));
            this.Log(string.Format("Deadlettered {0} messages", messages.Count()));
        }

        async Task DeferMessagesAsync(QueueClient queueClient, IEnumerable<BrokeredMessage> messages)
        {
            await queueClient.DeferAsync(messages.Select(message => message.LockToken));
            this.Log(string.Format("Deferred {0} messages", messages.Count()));
        }

        void Log(string message)
        {
            var formattedMessage = string.Format("{0} {1}", DateTime.Now.TimeOfDay, message);
            this.output.WriteLine(formattedMessage);
            Debug.WriteLine(formattedMessage);
            Console.WriteLine(formattedMessage);
        }
    }
}
