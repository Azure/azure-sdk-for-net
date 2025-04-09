// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample04_Processor : ServiceBusLiveTestBase
    {
        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task ProcessMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusProcessMessages
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string queueName = scope.QueueName;
                await using ServiceBusClient client = CreateClient();
#endif

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a set of messages that we can send
                ServiceBusMessage[] messages = new ServiceBusMessage[]
                {
                    new ServiceBusMessage("First"),
                    new ServiceBusMessage("Second")
                };

                // send the message batch
                await sender.SendMessagesAsync(messages);

                #region Snippet:ServiceBusConfigureProcessor
                // create the options to use for configuring the processor
                ServiceBusProcessorOptions options = new()
                {
                    // By default or when AutoCompleteMessages is set to true, the processor will complete the message after executing the message handler
                    // Set AutoCompleteMessages to false to [settle messages](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
                    // In both cases, if the message handler throws an exception without settling the message, the processor will abandon the message.
                    AutoCompleteMessages = false,

                    // I can also allow for multi-threading
                    MaxConcurrentCalls = 2
                };

                // create a processor that we can use to process the messages
                await using ServiceBusProcessor processor = client.CreateProcessor(queueName, options);

                // configure the message and error handler to use
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                async Task MessageHandler(ProcessMessageEventArgs args)
                {
                    string body = args.Message.Body.ToString();
                    Console.WriteLine(body);

                    // we can evaluate application logic and use that to determine how to settle the message.
                    await args.CompleteMessageAsync(args.Message);
                }

                Task ErrorHandler(ProcessErrorEventArgs args)
                {
                    // the error source tells me at what point in the processing an error occurred
                    Console.WriteLine(args.ErrorSource);
                    // the fully qualified namespace is available
                    Console.WriteLine(args.FullyQualifiedNamespace);
                    // as well as the entity path
                    Console.WriteLine(args.EntityPath);
                    Console.WriteLine(args.Exception.ToString());
                    return Task.CompletedTask;
                }

                // start processing
                await processor.StartProcessingAsync();

                // since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
                Console.ReadKey();
                #endregion
                #endregion
            }
        }
    }
}
