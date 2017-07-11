// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core;

    static class TestUtility
    {
        static TestUtility()
        {
            var envConnectionString = Environment.GetEnvironmentVariable(TestConstants.ConnectionStringEnvironmentVariable);

            if (string.IsNullOrWhiteSpace(envConnectionString))
            {
                throw new InvalidOperationException($"'{TestConstants.ConnectionStringEnvironmentVariable}' environment variable was not found!");
            }

            // Validate the connection string
            NamespaceConnectionString = new ServiceBusConnectionStringBuilder(envConnectionString).ToString();
        }

        internal static string NamespaceConnectionString { get; }

        internal static string GetEntityConnectionString(string entityName)
        {
            // If the entity name is populated in the connection string, it will be overridden.
            var connectionStringBuilder = new ServiceBusConnectionStringBuilder(NamespaceConnectionString)
            {
                EntityPath = entityName
            };
            return connectionStringBuilder.ToString();
        }

        internal static void Log(string message)
        {
            var formattedMessage = $"{DateTime.Now.TimeOfDay}: {message}";
            Debug.WriteLine(formattedMessage);
            Console.WriteLine(formattedMessage);
        }

        internal static async Task SendMessagesAsync(IMessageSender messageSender, int messageCount)
        {
            if (messageCount == 0)
            {
                await Task.FromResult(false);
            }

            var messagesToSend = new List<Message>();
            for (int i = 0; i < messageCount; i++)
            {
                var message = new Message(Encoding.UTF8.GetBytes("test" + i));
                message.Label = "test" + i;
                messagesToSend.Add(message);
            }

            await messageSender.SendAsync(messagesToSend);
            Log($"Sent {messageCount} messages");
        }

        internal static async Task<IEnumerable<Message>> ReceiveMessagesAsync(IMessageReceiver messageReceiver, int messageCount)
        {
            int receiveAttempts = 0;
            var messagesToReturn = new List<Message>();

            while (receiveAttempts++ < TestConstants.MaxAttemptsCount && messagesToReturn.Count < messageCount)
            {
                var messages = await messageReceiver.ReceiveAsync(messageCount - messagesToReturn.Count);
                if (messages != null)
                {
                    messagesToReturn.AddRange(messages);
                }
            }

            VerifyUniqueMessages(messagesToReturn);
            Log($"Received {messagesToReturn.Count} messages");
            return messagesToReturn;
        }

        internal static async Task<Message> PeekMessageAsync(IMessageReceiver messageReceiver)
        {
            var message = await messageReceiver.PeekAsync();
            Log($"Peeked 1 message");
            return message;
        }

        internal static async Task<IEnumerable<Message>> PeekMessagesAsync(IMessageReceiver messageReceiver, int messageCount)
        {
            int receiveAttempts = 0;
            var peekedMessages = new List<Message>();

            while (receiveAttempts++ < TestConstants.MaxAttemptsCount && peekedMessages.Count < messageCount)
            {
                var message = await messageReceiver.PeekAsync(messageCount - peekedMessages.Count);
                if (message != null)
                {
                    peekedMessages.AddRange(message);
                }
            }

            VerifyUniqueMessages(peekedMessages);
            Log($"Peeked {peekedMessages.Count} messages");
            return peekedMessages;
        }

        internal static async Task CompleteMessagesAsync(IMessageReceiver messageReceiver, IEnumerable<Message> messages)
        {
            await messageReceiver.CompleteAsync(messages.Select(message => message.SystemProperties.LockToken));
            Log($"Completed {messages.Count()} messages");
        }

        internal static async Task AbandonMessagesAsync(IMessageReceiver messageReceiver, IEnumerable<Message> messages)
        {
            int count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.AbandonAsync(message.SystemProperties.LockToken);
                count++;
            }
            Log($"Abandoned {count} messages");
        }

        internal static async Task DeadLetterMessagesAsync(IMessageReceiver messageReceiver, IEnumerable<Message> messages)
        {
            int count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.DeadLetterAsync(message.SystemProperties.LockToken);
                count++;
            }
            Log($"Deadlettered {count} messages");
        }

        internal static async Task DeferMessagesAsync(IMessageReceiver messageReceiver, IEnumerable<Message> messages)
        {
            int count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.DeferAsync(message.SystemProperties.LockToken);
                count++;
            }
            Log($"Deferred {count} messages");
        }

        internal static async Task SendSessionMessagesAsync(IMessageSender messageSender, int numberOfSessions, int messagesPerSession)
        {
            if (numberOfSessions == 0 || messagesPerSession == 0)
            {
                await Task.FromResult(false);
            }

            for (int i = 0; i < numberOfSessions; i++)
            {
                var messagesToSend = new List<Message>();
                string sessionId = TestConstants.SessionPrefix + i;
                for (int j = 0; j < messagesPerSession; j++)
                {
                    var message = new Message(Encoding.UTF8.GetBytes("test" + j));
                    message.Label = "test" + j;
                    message.SessionId = sessionId;
                    messagesToSend.Add(message);
                }

                await messageSender.SendAsync(messagesToSend);
            }

            Log($"Sent {messagesPerSession} messages each for {numberOfSessions} sessions.");
        }

        static void VerifyUniqueMessages(List<Message> messages)
        {
            if (messages != null && messages.Count > 1)
            {
                HashSet<long> sequenceNumbers = new HashSet<long>();
                foreach (var message in messages)
                {
                    if (!sequenceNumbers.Add(message.SystemProperties.SequenceNumber))
                    {
                        throw new Exception($"Sequence Number '{message.SystemProperties.SequenceNumber}' was repeated");
                    }
                }
            }
        }
    }
}