// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    static class TestUtility
    {
        static readonly string ConnectionString;

        static TestUtility()
        {
            var envConnectionString = Environment.GetEnvironmentVariable(Constants.ConnectionStringEnvironmentVariable);
            if (string.IsNullOrWhiteSpace(envConnectionString))
            {
                throw new InvalidOperationException($"'{Constants.ConnectionStringEnvironmentVariable}' environment variable was not found!");
            }

            // Validate the connection string
            ConnectionString = new ServiceBusConnectionStringBuilder(envConnectionString).ToString();
        }

        internal static string GetEntityConnectionString(string entityName)
        {
            // If the entity name is populated in the connection string, it will be overridden.
            var connectionStringBuilder = new ServiceBusConnectionStringBuilder(ConnectionString)
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

        internal static async Task SendMessagesAsync(MessageSender messageSender, int messageCount)
        {
            if (messageCount == 0)
            {
                await Task.FromResult(false);
            }

            var messagesToSend = new List<BrokeredMessage>();
            for (int i = 0; i < messageCount; i++)
            {
                var message = new BrokeredMessage("test" + i);
                message.Label = "test" + i;
                messagesToSend.Add(message);
            }

            await messageSender.SendAsync(messagesToSend);
            Log($"Sent {messageCount} messages");
        }

        internal static async Task<IEnumerable<BrokeredMessage>> ReceiveMessagesAsync(MessageReceiver messageReceiver, int messageCount)
        {
            int receiveAttempts = 0;
            var messagesToReturn = new List<BrokeredMessage>();

            while (receiveAttempts++ < Constants.MaxAttemptsCount && messagesToReturn.Count < messageCount)
            {
                var messages = await messageReceiver.ReceiveAsync(messageCount);
                if (messages != null)
                {
                    messagesToReturn.AddRange(messages);
                }
            }

            Log($"Received {messagesToReturn.Count} messages");
            return messagesToReturn;
        }

        internal static async Task CompleteMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages)
        {
            await messageReceiver.CompleteAsync(messages.Select(message => message.LockToken));
            Log($"Completed {messages.Count()} messages");
        }

        internal static async Task AbandonMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages)
        {
            await messageReceiver.AbandonAsync(messages.Select(message => message.LockToken));
            Log($"Abandoned {messages.Count()} messages");
        }

        internal static async Task DeadLetterMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages)
        {
            await messageReceiver.DeadLetterAsync(messages.Select(message => message.LockToken));
            Log($"Deadlettered {messages.Count()} messages");
        }

        internal static async Task DeferMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages)
        {
            await messageReceiver.DeferAsync(messages.Select(message => message.LockToken));
            Log($"Deferred {messages.Count()} messages");
        }
    }
}