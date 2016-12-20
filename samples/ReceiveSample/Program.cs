// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ReceiveSample
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus;

    public class Program
    {
        private static QueueClient queueClient;
        private const string ServiceBusConnectionString = "{Service Bus connection string}";
        private const string QueueName = "{Queue path/name}";

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            // Creates a ServiceBusConnectionStringBuilder object from the connection string, and sets the EntityPath.
            var connectionStringBuilder = new ServiceBusConnectionStringBuilder(ServiceBusConnectionString)
            {
                EntityPath = QueueName
            };

            // Initializes the static QueueClient variable that will be used in the ReceiveMessages method.
            queueClient = QueueClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await ReceiveMessages();

            // Close the client after the ReceiveMessages method has exited.
            await queueClient.CloseAsync();
        }

        // Receives messages from the queue in a loop
        private static async Task ReceiveMessages()
        {
            Console.WriteLine("Press ctrl-c to exit receive loop.");
            while (true)
            {
                try
                {
                    // Receive the next message from the queue
                    var message = await queueClient.ReceiveAsync();
                    
                    // Write the message body to the console
                    Console.WriteLine($"Received message: {message.GetBody<string>()}");

                    // Complete the message so that it is not received again
                    await message.CompleteAsync();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                // Delay by 10 milliseconds so that the console can keep up
                await Task.Delay(10);
            }
        }
    }
}
