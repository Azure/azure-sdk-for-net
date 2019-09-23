// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Polly;

    internal static class TestUtility
    {
        private static readonly Lazy<string> NamespaceConnectionStringInstance =
            new Lazy<string>(() => new ServiceBusConnectionStringBuilder(ReadEnvironmentConnectionString()).ToString(), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> SocketNamespaceConnectionStringInstance =
            new Lazy<string>(() => new ServiceBusConnectionStringBuilder(ReadEnvironmentConnectionString()) { TransportType = TransportType.AmqpWebSockets }.ToString(), LazyThreadSafetyMode.PublicationOnly);

        internal static string NamespaceConnectionString => NamespaceConnectionStringInstance.Value;

        internal static string WebSocketsNamespaceConnectionString => SocketNamespaceConnectionStringInstance.Value;

        internal static string GetEntityConnectionString(string entityName) =>
            new ServiceBusConnectionStringBuilder(NamespaceConnectionString) { EntityPath = entityName }.ToString();

        internal static void Log(string message)
        {
            try
            {
                var formattedMessage = $"{DateTime.Now.TimeOfDay}: {message}";
                Debug.WriteLine(formattedMessage);
                Console.WriteLine(formattedMessage);
            }
            catch
            {
                // Consider a logging exception non-fatal.  Fail silently.
            }
        }

        internal static async Task SendMessagesAsync(MessageSender messageSender, int messageCount)
        {
            if (messageCount == 0)
            {
                await Task.FromResult(false);
            }

            var messagesToSend = new List<Message>();
            for (var i = 0; i < messageCount; i++)
            {
                var message = new Message(Encoding.UTF8.GetBytes("test" + i));
                message.Label = "test" + i;
                messagesToSend.Add(message);
            }

            await messageSender.SendAsync(messagesToSend);
            Log($"Sent {messageCount} messages");
        }

        internal static async Task<IList<ReceivedMessage>> ReceiveMessagesAsync(MessageReceiver messageReceiver, int messageCount, TimeSpan timeout = default)
        {
            var receiveAttempts = 0;
            var messagesToReturn = new List<ReceivedMessage>();
            var stopwatch = Stopwatch.StartNew();

            if (timeout == default)
            {
                timeout = TimeSpan.Zero;
            }

            while (messagesToReturn.Count < messageCount && (receiveAttempts++ < TestConstants.MaxAttemptsCount || stopwatch.Elapsed < timeout))
            {
                var messages = await messageReceiver.ReceiveAsync(messageCount - messagesToReturn.Count);
                if (messages == null)
                {
                    await Task.Delay(TestConstants.WaitTimeBetweenAttempts);
                    continue;
                }

                messagesToReturn.AddRange(messages);
            }

            VerifyUniqueMessages(messagesToReturn);
            Log($"Received {messagesToReturn.Count} messages");
            return messagesToReturn;
        }

        /// <summary>
        /// This utility method is required since for a partitioned entity, the messages could have been received from different partitions,
        /// and we cannot receive all the deferred messages from different partitions in a single call.
        /// </summary>
        internal static async Task<IList<ReceivedMessage>> ReceiveDeferredMessagesAsync(MessageReceiver messageReceiver, IEnumerable<long> sequenceNumbers)
        {
            var messagesToReturn = new List<ReceivedMessage>();
            foreach (var sequenceNumber in sequenceNumbers)
            {
                var msg = await messageReceiver.ReceiveDeferredMessageAsync(sequenceNumber);
                if (msg != null)
                {
                    messagesToReturn.Add(msg);
                }
            }

            return messagesToReturn;
        }

        internal static async Task<ReceivedMessage> PeekMessageAsync(MessageReceiver messageReceiver)
        {
            var message = await messageReceiver.PeekAsync();
            Log($"Peeked 1 message");
            return message;
        }

        internal static async Task<IEnumerable<ReceivedMessage>> PeekMessagesAsync(MessageReceiver messageReceiver, int messageCount)
        {
            var receiveAttempts = 0;
            var peekedMessages = new List<ReceivedMessage>();

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

        internal static async Task CompleteMessagesAsync(MessageReceiver messageReceiver, IList<ReceivedMessage> messages)
        {
            await messageReceiver.CompleteAsync(messages.Select(message => message.LockToken));
            Log($"Completed {messages.Count} messages");
        }

        internal static async Task AbandonMessagesAsync(MessageReceiver messageReceiver, IEnumerable<ReceivedMessage> messages)
        {
            var count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.AbandonAsync(message.LockToken);
                count++;
            }
            Log($"Abandoned {count} messages");
        }

        internal static async Task DeadLetterMessagesAsync(MessageReceiver messageReceiver, IEnumerable<ReceivedMessage> messages)
        {
            var count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.DeadLetterAsync(message.LockToken);
                count++;
            }
            Log($"Deadlettered {count} messages");
        }

        internal static async Task DeferMessagesAsync(MessageReceiver messageReceiver, IEnumerable<ReceivedMessage> messages)
        {
            var count = 0;
            foreach (var message in messages)
            {
                await messageReceiver.DeferAsync(message.LockToken);
                count++;
            }
            Log($"Deferred {count} messages");
        }

        internal static async Task SendSessionMessagesAsync(MessageSender messageSender, int numberOfSessions, int messagesPerSession)
        {
            if (numberOfSessions == 0 || messagesPerSession == 0)
            {
                await Task.FromResult(false);
            }

            for (var i = 0; i < numberOfSessions; i++)
            {
                var messagesToSend = new List<Message>();
                var sessionId = TestConstants.SessionPrefix + i;
                for (var j = 0; j < messagesPerSession; j++)
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

        private static void VerifyUniqueMessages(List<ReceivedMessage> messages)
        {
            if (messages != null && messages.Count > 1)
            {
                var sequenceNumbers = new HashSet<long>();
                foreach (var message in messages)
                {
                    if (!sequenceNumbers.Add(message.SequenceNumber))
                    {
                        throw new Exception($"Sequence Number '{message.SequenceNumber}' was repeated");
                    }
                }
            }
        }

        private static string ReadEnvironmentConnectionString()
        {
            var envConnectionString = Environment.GetEnvironmentVariable(TestConstants.ConnectionStringEnvironmentVariable);

            if (string.IsNullOrWhiteSpace(envConnectionString))
            {
                throw new InvalidOperationException($"'{TestConstants.ConnectionStringEnvironmentVariable}' environment variable was not found!");
            }

            return envConnectionString;
        }

        // String extension methods

        internal static string GetString(this ReadOnlyMemory<byte> bytes)
        {
            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        internal static byte[] GetBytes(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}