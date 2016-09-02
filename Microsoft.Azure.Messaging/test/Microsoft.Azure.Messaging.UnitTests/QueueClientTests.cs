// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.UnitTests
{
    using System;
    using Microsoft.Azure.Messaging;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class QueueClientTests
    {
        public QueueClientTests()
        {
            string connectionString = Environment.GetEnvironmentVariable("QUEUECLIENTCONNECTIONSTRING");
            connectionString =
                "Endpoint=sb://testvinsustandard924.servicebus.windows.net/;EntityPath=testq;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+nCcyesi2Vdw5eAQeJvR85XMwpj46o2gvxmdizbqXoY=";
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("QUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }

            this.QueueClient = QueueClient.Create(connectionString);
        }

        QueueClient QueueClient { get; }

        [Fact]
        async Task QueueClientBasicSendReceiveTest()
        {
            const int messageCount = 10;
            //Send 10 messages
            WriteLine("Sending single mesage via QueueClient.SendAsync(brokeredMessage)");
            for (int i = 0; i < messageCount; i++)
            {
                BrokeredMessage message = new BrokeredMessage("test" + i);
                message.Label = "test" + i;
                await this.QueueClient.SendAsync(message); 
            }
            WriteLine(string.Format("Sent {0} messages using QueueClient.SendAsync()", messageCount));

            //Receive 10 messages
            WriteLine(string.Format("Receiving {0} messages via QueueClient.ReceiveAsync()", messageCount));
            var receivedMessages =  await this.QueueClient.ReceiveAsync(messageCount);
            Assert.True(receivedMessages.Count == messageCount);
            WriteLine(string.Format("Received {0} messages via QueueClient.ReceiveAsync()", messageCount));
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
