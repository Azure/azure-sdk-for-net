// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample04_Processor : ServiceBusLiveTestBase
    {
        [Test]
        public async Task ProcessMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                await using var client = GetClient();

                #region Snippet:ServiceBusProcessMessages
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                //@@ await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message batch that we can send
                ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
                messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

                // send the message batch
                await sender.SendMessagesAsync(messageBatch);

                // get the options to use for configuring the processor
                var options = new ServiceBusProcessorOptions
                {
                    // By default after the message handler returns, the processor will complete the message
                    // If I want more fine-grained control over settlement, I can set this to false.
                    AutoComplete = false,

                    // I can also allow for multi-threading
                    MaxConcurrentCalls = 2
                };

                // create a processor that we can use to process the messages
                ServiceBusProcessor processor = client.CreateProcessor(queueName, options);

                // since the message handler will run in a background thread, in order to prevent
                // this sample from terminating immediately, we can use a task completion source that
                // we complete from within the message handler.
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                async Task MessageHandler(ProcessMessageEventArgs args)
                {
                    string body = args.Message.Body.ToString();
                    Console.WriteLine(body);

                    // we can evaluate application logic and use that to determine how to settle the message.
                    await args.CompleteAsync(args.Message);
                    tcs.SetResult(true);
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
                await processor.StartProcessingAsync();

                // await our task completion source task so that the message handler will be invoked at least once.
                await tcs.Task;

                // stop processing once the task completion source was completed.
                await processor.StopProcessingAsync();
                #endregion
            }
        }
    }
}
