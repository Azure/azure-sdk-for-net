// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    public class TestUtility
    {
        const int MaxAttemptsCount = 5;

        public static void Log(ITestOutputHelper output, string message)
        {
            var formattedMessage = string.Format("{0} {1}", DateTime.Now.TimeOfDay, message);
            output.WriteLine(formattedMessage);
            Debug.WriteLine(formattedMessage);
            Console.WriteLine(formattedMessage);
        }

        public static async Task SendMessagesAsync(MessageSender messageSender, int messageCount, ITestOutputHelper output)
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

            await messageSender.SendAsync(messagesToSend);
            Log(output, string.Format("Sent {0} messages", messageCount));
        }

        public static async Task<IEnumerable<BrokeredMessage>> ReceiveMessagesAsync(MessageReceiver messageReceiver, int messageCount, ITestOutputHelper output)
        {
            int receiveAttempts = 0;
            List<BrokeredMessage> messagesToReturn = new List<BrokeredMessage>();

            while (receiveAttempts++ < TestUtility.MaxAttemptsCount && messagesToReturn.Count < messageCount)
            {
                var messages = await messageReceiver.ReceiveAsync(messageCount);
                if (messages != null)
                {
                    messagesToReturn.AddRange(messages);
                }
            }

            Log(output, string.Format("Received {0} messages", messagesToReturn.Count));
            return messagesToReturn;
        }

        public static async Task CompleteMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages, ITestOutputHelper output)
        {
            await messageReceiver.CompleteAsync(messages.Select(message => message.LockToken));
            Log(output, string.Format("Completed {0} messages", messages.Count()));
        }

        public static async Task AbandonMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages, ITestOutputHelper output)
        {
            await messageReceiver.AbandonAsync(messages.Select(message => message.LockToken));
            Log(output, string.Format("Abandoned {0} messages", messages.Count()));
        }

        public static async Task DeadLetterMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages, ITestOutputHelper output)
        {
            await messageReceiver.DeadLetterAsync(messages.Select(message => message.LockToken));
            Log(output, string.Format("Deadlettered {0} messages", messages.Count()));
        }

        public static async Task DeferMessagesAsync(MessageReceiver messageReceiver, IEnumerable<BrokeredMessage> messages, ITestOutputHelper output)
        {
            await messageReceiver.DeferAsync(messages.Select(message => message.LockToken));
            Log(output, string.Format("Deferred {0} messages", messages.Count()));
        }
    }
}