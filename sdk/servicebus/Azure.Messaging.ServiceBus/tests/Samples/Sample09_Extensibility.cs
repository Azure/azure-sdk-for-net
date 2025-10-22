// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;
using Plugins;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample09_Extensibility: ServiceBusLiveTestBase
    {
        [Test]
        public async Task Plugins()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:End2EndPluginReceiver
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
                await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
                {
                    message =>
                    {
                        message.Subject = "Updated subject";
#if SNIPPET
                        Console.WriteLine("First send plugin executed!");
#endif
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Updated subject"
                        Console.WriteLine("Second send plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        return Task.CompletedTask;
                    },
                });

                await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                await using ServiceBusReceiver receiver = client.CreatePluginReceiver(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
                {
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine("First receive plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Received subject";
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Received subject"
#else
                        Assert.AreEqual("Received subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Last subject";
                        Console.WriteLine("Second receive plugin executed!");
                        return Task.CompletedTask;
                    },
                });
                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
#if SNIPPET
                Console.WriteLine(message.Subject);
#else
                Assert.AreEqual("Last subject", message.Subject);
#endif
                #endregion
            };
        }

        [Test]
        public async Task PluginsSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
                await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
                {
                    message =>
                    {
                        message.Subject = "Updated subject";
                        message.SessionId = "sessionId";
#if SNIPPET
                        Console.WriteLine("First send plugin executed!");
#endif
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Updated subject"
                        Console.WriteLine("Second send plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        return Task.CompletedTask;
                    },
                });

                await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                await using ServiceBusReceiver receiver = await client.AcceptNextSessionPluginAsync(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
                {
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine("First receive plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Received subject";
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Received subject"
#else
                        Assert.AreEqual("Received subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Last subject";
                        Console.WriteLine("Second receive plugin executed!");
                        return Task.CompletedTask;
                    },
                });
                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
#if SNIPPET
                Console.WriteLine(message.Subject);
#else
                Assert.AreEqual("Last subject", message.Subject);
#endif
            };
        }

        [Test]
        public async Task PluginsProcessor()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:End2EndPluginProcessor
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
                await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
                {
                    message =>
                    {
                        message.Subject = "Updated subject";
#if SNIPPET
                        Console.WriteLine("First send plugin executed!");
#endif
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Updated subject"
                        Console.WriteLine("Second send plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        return Task.CompletedTask;
                    },
                });

                await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                await using ServiceBusProcessor processor = client.CreatePluginProcessor(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
                {
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine("First receive plugin executed!");
                        Console.WriteLine(message.Subject); // prints "Updated subject"
#else
                        Assert.AreEqual("Updated subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Received subject";
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Received subject"
                        Console.WriteLine("Second receive plugin executed!");
#else

                        Assert.AreEqual("Received subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Last subject";
                        return Task.CompletedTask;
                    },
                });
#if !SNIPPET
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
#endif
                processor.ProcessMessageAsync += args =>
                {
#if SNIPPET
                    Console.WriteLine($"Message handler executed. Subject: {args.Message.Subject}");
#else
                    Assert.AreEqual("Last subject", args.Message.Subject);
                    tcs.TrySetResult(true);
#endif
                    return Task.CompletedTask;
                };

                processor.ProcessErrorAsync += args =>
                {
#if SNIPPET
                    Console.WriteLine(args.Exception);
#endif
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();
#if SNIPPET
                Console.ReadKey();
#else
                await tcs.Task;
#endif
                #endregion
            };
        }

        [Test]
        public async Task PluginsSessionProcessor()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                #region Snippet:End2EndPluginSessionProcessor
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
                await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
                {
                    message =>
                    {
                        message.Subject = "Updated subject";
                        message.SessionId = "sessionId";
#if SNIPPET
                        Console.WriteLine("First send plugin executed!");
#endif
                    return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Updated subject"
                        Console.WriteLine(message.SessionId); // prints "sessionId"
                        Console.WriteLine("Second send plugin executed!");
#else
                        Assert.AreEqual("Updated subject", message.Subject);
                        Assert.AreEqual("sessionId", message.SessionId);
#endif
                        return Task.CompletedTask;
                    },
                });

                await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));

#if !SNIPPET
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
#endif
                await using ServiceBusSessionProcessor processor = client.CreatePluginSessionProcessor(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
                {
                    message =>
                    {
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Received subject";
#if SNIPPET
                        Console.WriteLine("First receive plugin executed!");
#endif
                        return Task.CompletedTask;
                    },
                    message =>
                    {
#if SNIPPET
                        Console.WriteLine(message.Subject); // prints "Received subject"
#else
                        Assert.AreEqual("Received subject", message.Subject);
#endif
                        var rawMessage = message.GetRawAmqpMessage();
                        rawMessage.Properties.Subject = "Last subject";
#if SNIPPET
                        Console.WriteLine("Second receive plugin executed!");
#endif
                        return Task.CompletedTask;
                    },
                });

                processor.ProcessMessageAsync += args =>
                {
#if SNIPPET
                    Console.WriteLine(args.Message.Subject);
#else
                    Assert.AreEqual("Last subject", args.Message.Subject);
                    tcs.TrySetResult(true);

#endif
                    return Task.CompletedTask;
                };

                processor.ProcessErrorAsync += args =>
                {
#if SNIPPET
                    Console.WriteLine(args.Exception);
#endif
                    return Task.CompletedTask;
                };

                await processor.StartProcessingAsync();
#if SNIPPET
                Console.ReadKey();
#else
                await tcs.Task;
#endif
                #endregion
            };
        }
    }
}
