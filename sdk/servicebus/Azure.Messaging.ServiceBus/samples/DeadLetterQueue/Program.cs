using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus;

namespace DeadLetterQueue
{
    // This sample shows how to move messages to the Dead-letter queue, how to retrieve
    // messages from it, and resubmit corrected message back into the main queue.
    public class Program
    {
        private static ServiceBusClient _client;

        public static async Task Main(string[] args)
        {
            var command = new RootCommand("Demonstrates the DeadLetter feature of Azure Service Bus.")
            {
                new Option<string>(
                    alias: "--namespace",
                    description: "Fully qualified Service Bus Queue namespace to use") { Name = "FullyQualifiedNamespace" },
                new Option<string>(
                    alias: "--queue",
                    description: "Service Bus Queue Name to use") { IsRequired = true, Name = "QueueName"},
                new Option<string>(
                    alias: "--connection-variable",
                    description: "The name of an environment variable containing the connection string to use.") { Name = "Connection"},
            };
            command.Handler = CommandHandler.Create<string, string, string>(RunAsync);
            await command.InvokeAsync(args);
        }

        private static async Task RunAsync(string fullyQualifiedNamespace, string queueName, string connection)
        {
            if (!string.IsNullOrEmpty(connection))
            {
                _client = new ServiceBusClient(Environment.GetEnvironmentVariable(connection));
            }
            else if (!string.IsNullOrEmpty(fullyQualifiedNamespace))
            {
                _client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
            }
            else
            {
                throw new ArgumentException(
                    "Either a fully qualified namespace or a connection string environment variable must be specified.");
            }

            var cts = new CancellationTokenSource();
            var sender = _client.CreateSender(queueName);

            // For the delivery count scenario, we first send a single message,
            // and then pick it up and abandon it until is "disappears" from the queue.
            // Then we fetch the message from the dead-letter queue (DLQ) and inspect it.
            await SendMessages(sender, 1);
            await ExceedMaxDeliveryAsync(queueName);

            // For the fix-up scenario, we send a series of messages to a queue, and
            // run a receive loop that explicitly pushes messages into the DLQ when
            // they don't satisfy a processing condition. The fix-up receive loop inspects
            // the DLQ, fixes the "faulty" messages, and resubmits them into processing.
            var sendTask = SendMessages(sender, int.MaxValue);
            var receiveTask = ReceiveMessages(queueName, cts.Token);
            var fixupTask = PickUpAndFixDeadletters(queueName, sender, cts.Token);

            // wait for a key press or 10 seconds
            await Task.WhenAny(
                Task.Run(() => Console.ReadKey()),
                Task.Delay(TimeSpan.FromSeconds(10))
            );

            // end the processing
            cts.Cancel();
            // await shutdown and exit
            await Task.WhenAll(sendTask, receiveTask, fixupTask);
        }

        private static Task SendMessages(ServiceBusSender sender, int maxMessages)
        {
            dynamic data = new[]
            {
                new {name = "Einstein", firstName = "Albert"},
                new {name = "Heisenberg", firstName = "Werner"},
                new {name = "Curie", firstName = "Marie"},
                new {name = "Hawking", firstName = "Steven"},
                new {name = "Newton", firstName = "Isaac"},
                new {name = "Bohr", firstName = "Niels"},
                new {name = "Faraday", firstName = "Michael"},
                new {name = "Galilei", firstName = "Galileo"},
                new {name = "Kepler", firstName = "Johannes"},
                new {name = "Kopernikus", firstName = "Nikolaus"}
            };

            // send a message for each data entry, but at most maxMessages
            // we're sending in a loop, but don't block on each send, but
            // rather collect all sends in a list and then wait for all of
            // them to complete asynchronously, which is much faster
            var tasks = new List<Task>();
            for (int i = 0; i < Math.Min(data.Length, maxMessages); i++)
            {
                // each message has a JSON body with one of the data rows
                var message = new ServiceBusMessage(new BinaryData(jsonSerializable: data[i]))
                {
                    ContentType = "application/json", // JSON data
                    Subject = i % 2 == 0 ? "Scientist" : "Physicist", // random picked header
                    MessageId = i.ToString(), // message-id
                    TimeToLive = TimeSpan.FromMinutes(2) // message expires in 2 minutes
                };

                // start sending this message
                lock (Console.Out)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Message sent: Id = {message.MessageId}");
                    Console.ResetColor();
                }

                // After the send task is complete, output this to the console.
                tasks.Add(sender.SendMessageAsync(message).ContinueWith((t) =>
                {
                    lock (Console.Out)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\tMessage acknowledged: Id = {message.MessageId}");
                        Console.ResetColor();
                    }
                }));
            }

            return Task.WhenAll(tasks);
        }


        private static async Task ExceedMaxDeliveryAsync(string queueName)
        {
            ServiceBusReceiver receiver = _client.CreateReceiver(queueName);

            while (true)
            {
                // Ask the broker to return any message readily available or return with no
                // result after 2 seconds (allowing for clients with great network latency)
                ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(2));
                if (msg != null)
                {
                    // Now we immediately abandon the message, which increments the DeliveryCount
                    Console.WriteLine($"Picked up message: Id = {msg.MessageId}; DeliveryCount {msg.DeliveryCount}");
                    await receiver.AbandonMessageAsync(msg);
                }
                else
                {
                    // Once the system moves the message to the DLQ, the main queue is empty
                    // and the loop exits as ReceiveAsync returns null.
                    break;
                }
            }

            // For picking up the message from a DLQ, we make a receiver just like for a
            // regular queue. We could also use QueueClient and a registered handler here.
            // The required path is automatically constructed with the help of
            // <see cref="ServiceBusReceiverOptions.SubQueue"/> and <see cref="SubQueue.DeadLetter"/>,
            // and always follows the pattern "{entity}/$DeadLetterQueue",
            // meaning that for a queue "Q1", the path is "Q1/$DeadLetterQueue" and for a
            // topic "T1" and subscription "S1", the path is "T1/Subscriptions/S1/$DeadLetterQueue"
            ServiceBusReceiver deadletterReceiver = _client.CreateReceiver(queueName,
                new ServiceBusReceiverOptions {SubQueue = SubQueue.DeadLetter});
            while (true)
            {
                // receive a message
                ServiceBusReceivedMessage message =
                    await deadletterReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
                if (message != null)
                {
                    // write out the message deadletter information
                    Console.WriteLine("Deadletter message:");
                    Console.WriteLine($"DeadLetterReason = {message.DeadLetterReason}");
                    Console.WriteLine($"DeadLetterErrorDescription = {message.DeadLetterErrorDescription}");

                    // complete and therefore remove the message from the DLQ
                    await deadletterReceiver.CompleteMessageAsync(message);
                }
                else
                {
                    // DLQ was empty on last receive attempt
                    break;
                }
            }
        }

        private static Task ReceiveMessages(string queueName, CancellationToken cancellationToken)
        {
            var doneReceiving = new TaskCompletionSource<bool>();
            ServiceBusProcessor processor = _client.CreateProcessor(queueName);

            // close the receiver and factory when the CancellationToken fires
            cancellationToken.Register(
                async () =>
                {
                    await processor.CloseAsync();
                    doneReceiving.SetResult(true);
                });

            processor.ProcessMessageAsync += async args =>
            {
                ServiceBusReceivedMessage message = args.Message;
                // If the message holds JSON data and the label is set to "Scientist",
                // we accept the message and print it.
                if (message.Subject != null &&
                    message.ContentType != null &&
                    message.Subject.Equals("Scientist", StringComparison.InvariantCultureIgnoreCase) &&
                    message.ContentType.Equals("application/json", StringComparison.InvariantCultureIgnoreCase))
                {
                    var body = message.Body;

                    // System.Text.JSON does not currently support deserializing to dynamic
                    Dictionary<string, string> scientist = body.ToObjectFromJson<Dictionary<string, string>>();

                    lock (Console.Out)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(
                            "\t\t\t\tMessage received: \n\t\t\t\t\t\tMessageId = {0}, \n\t\t\t\t\t\tSequenceNumber = {1}," +
                            " \n\t\t\t\t\t\tEnqueuedTime = {2}," + "\n\t\t\t\t\t\tExpiresAt = {4}, \n\t\t\t\t\t\tContentType = \"{3}\"," +
                            " \n\t\t\t\t\t\tContent: [ firstName = {5}, name = {6} ]",
                            message.MessageId,
                            message.SequenceNumber,
                            message.EnqueuedTime,
                            message.ContentType,
                            message.ExpiresAt,
                            scientist["firstName"],
                            scientist["name"]);
                        Console.ResetColor();
                    }

                    await args.CompleteMessageAsync(message, args.CancellationToken);
                }
                else
                {
                    // if the messages doesn't fit the criteria above, we deadletter it
                    await args.DeadLetterMessageAsync(message, cancellationToken: args.CancellationToken);
                }
            };

            processor.ProcessErrorAsync += LogMessageHandlerException;
            _ = processor.StartProcessingAsync(cancellationToken);
            return doneReceiving.Task;
        }

        private static Task PickUpAndFixDeadletters(string queueName, ServiceBusSender resubmitSender, CancellationToken cancellationToken)
        {
            var doneReceiving = new TaskCompletionSource<bool>();

            // here, we create a receiver on the Deadletter queue
            ServiceBusProcessor dlqProcessor =
                _client.CreateProcessor(queueName, new ServiceBusProcessorOptions {SubQueue = SubQueue.DeadLetter});

            // close the receiver and factory when the CancellationToken fires
            cancellationToken.Register(
                async () =>
                {
                    await dlqProcessor.CloseAsync();
                    doneReceiving.SetResult(true);
                });

            // register the RegisterMessageHandler callback
            dlqProcessor.ProcessMessageAsync += async args =>
            {
                // first, we create a new sendable message of the picked up message
                // that we can resubmit.
                var resubmitMessage = new ServiceBusMessage(args.Message);
                // if the message has an "error" we know the main loop
                // can't handle, let's fix the message
                if (resubmitMessage.Subject != null && resubmitMessage.Subject.Equals("Physicist"))
                {
                    lock (Console.Out)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
                            "\t\tFixing: \n\t\t\tMessageId = {0}, \n\t\t\tSequenceNumber = {1}, \n\t\t\tLabel = {2}",
                            args.Message.MessageId,
                            args.Message.SequenceNumber,
                            args.Message.Subject);
                        Console.ResetColor();
                    }

                    // set the label to "Scientist"
                    resubmitMessage.Subject = "Scientist";
                    // and re-enqueue the cloned message
                    await resubmitSender.SendMessageAsync(resubmitMessage);
                }

                // finally complete the original message and remove it from the DLQ
                await args.CompleteMessageAsync(args.Message);
            };
            dlqProcessor.ProcessErrorAsync += LogMessageHandlerException;
            _ = dlqProcessor.StartProcessingAsync();
            return doneReceiving.Task;
        }

        private static Task LogMessageHandlerException(ProcessErrorEventArgs e)
        {
            Console.WriteLine($"Exception: \"{e.Exception.Message}\" {e.EntityPath}");
            return Task.CompletedTask;
        }
    }
}
