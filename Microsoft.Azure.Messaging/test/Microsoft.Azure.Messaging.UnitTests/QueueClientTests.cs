// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.UnitTests
{
    using System;
    using Microsoft.Azure.Messaging;
    using System.Diagnostics;
    using System.Text;
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
        async Task QueueClientSend()
        {
            WriteLine("Sending single mesage via QueueClient.SendAsync(brokeredMessage)");
            
            for (int i = 0; i < 10; i++)
            {
                BrokeredMessage message = new BrokeredMessage("test" + i);
                message.Label = "test" + i;
                await this.QueueClient.SendAsync(message); 
            }
            WriteLine("Sent 10 messages using QueueClient.SendAsync()");
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
