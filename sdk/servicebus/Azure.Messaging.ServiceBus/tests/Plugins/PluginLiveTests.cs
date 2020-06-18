// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Plugins;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Plugins
{
    public class PluginLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task OrderOfPluginsRespected()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var client = GetClient();
                client.RegisterPlugin(new FirstPlugin());
                client.RegisterPlugin(new SecondPlugin());
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                var sendMessage = new ServiceBusMessage();
                await sender.SendMessageAsync(sendMessage);

                var receivedMessage = await receiver.ReceiveMessageAsync();
                var firstSendPluginUserProperty = (bool)receivedMessage.Properties["FirstSendPlugin"];
                var secondSendPluginUserProperty = (bool)receivedMessage.Properties["SecondSendPlugin"];

                Assert.True(firstSendPluginUserProperty);
                Assert.True(secondSendPluginUserProperty);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task PluginsCanAlterMessage(bool schedule)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var plugin = new SendReceivePlugin();
                var client = GetClient();
                client.RegisterPlugin(plugin);

                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);

                if (schedule)
                {
                    await sender.ScheduleMessageAsync(new ServiceBusMessage(), DateTimeOffset.UtcNow);
                }
                else
                {
                    await sender.SendMessageAsync(new ServiceBusMessage());
                }

                Assert.True(plugin.WasCalled);
                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("received", receivedMessage.Body.ToString());
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task PluginsCanAlterSetofMessages(bool schedule)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var plugin = new SendReceivePlugin();
                var client = GetClient();
                client.RegisterPlugin(plugin);

                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                int numMessages = 5;
                if (schedule)
                {
                    await sender.ScheduleMessagesAsync(GetMessages(numMessages), DateTimeOffset.UtcNow);
                }
                else
                {
                    await sender.SendMessagesAsync(GetMessages(numMessages));
                }

                Assert.True(plugin.WasCalled);

                var remaining = numMessages;
                while (remaining > 0)
                {
                    var receivedMessages = await receiver.ReceiveMessagesAsync(remaining);
                    remaining = -receivedMessages.Count;
                    foreach (var receivedMessage in receivedMessages)
                    {
                        Assert.AreEqual("received", receivedMessage.Body.ToString());
                    }
                }
            }
        }

        [Test]
        public async Task PluginsCanAlterSessionMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {

                var plugin = new SendReceivePlugin();
                var client = GetClient();
                client.RegisterPlugin(plugin);
                var sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(GetMessage("sessionId"));
                Assert.True(plugin.WasCalled);
                var receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                // this should not impact already created receiver
                client.RegisterPlugin(plugin);
                Assert.AreEqual(1, receiver._plugins.Count);
                var receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.AreEqual("received", receivedMessage.Body.ToString());
            }
        }

        [Test]
        public async Task PluginsCanAlterTopicSessionMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(
                enablePartitioning: false,
                enableSession: true))
            {

                var plugin = new SendReceivePlugin();
                var client = GetClient();
                client.RegisterPlugin(plugin);
                var sender = client.CreateSender(scope.TopicName);

                await sender.SendMessageAsync(GetMessage("sessionId"));
                Assert.True(plugin.WasCalled);
                var receiver = await client.CreateSessionReceiverAsync(scope.TopicName, scope.SubscriptionNames.First());
                // this should not impact already created receiver
                client.RegisterPlugin(plugin);
                Assert.AreEqual(1, receiver._plugins.Count);
                var receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.AreEqual("received", receivedMessage.Body.ToString());
            }
        }

        [Test]
        public async Task PluginsCanAlterMessageUsingProcessor()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var client = GetClient();
                var plugin = new SendReceivePlugin();
                client.RegisterPlugin(plugin);

                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
                Assert.True(plugin.WasCalled);

                var processor = client.CreateProcessor(scope.QueueName);
                processor.ProcessErrorAsync += ExceptionHandler;
                var tcs = new TaskCompletionSource<bool>();
                processor.ProcessMessageAsync += args =>
                {
                    Assert.AreEqual("received", args.Message.Body.ToString());
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                };
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task PluginsCanAlterMessageUsingSessionProcessor()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {

                var plugin = new SendReceivePlugin();
                var client = GetClient();
                client.RegisterPlugin(plugin);
                var sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(GetMessage("sessionId"));
                Assert.True(plugin.WasCalled);
                var processor = client.CreateSessionProcessor(scope.QueueName, new ServiceBusSessionProcessorOptions
                {
                    MaxConcurrentCalls = 1
                });
                processor.ProcessErrorAsync += ExceptionHandler;
                var tcs = new TaskCompletionSource<bool>();
                processor.ProcessMessageAsync += args =>
                {
                    Assert.AreEqual("received", args.Message.Body.ToString());
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                };
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
            }
        }

        [Test]
        public async Task PluginWithoutShouldContinueOnExceptionShouldThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var client = GetClient();
                client.RegisterPlugin(new ExceptionPlugin());

                var sender = client.CreateSender(scope.QueueName);
                Assert.That(
                    async() => await sender.SendMessageAsync(new ServiceBusMessage()),
                    Throws.InstanceOf<NotImplementedException>());

                sender = GetClient().CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage());
                var receiver = client.CreateReceiver(scope.QueueName);
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<NotImplementedException>());
            }
        }

        [Test]
        public async Task PluginWithShouldContinueOnExceptionShouldContinue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                var client = GetClient();
                client.RegisterPlugin(new ShouldContinueOnExceptionPlugin());
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage());
                var receiver = client.CreateReceiver(scope.QueueName);
                var message = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("before exception", message.Body.ToString());
                Assert.AreEqual("received", message.Label);
            }
        }

#pragma warning disable SA1402 // File may only contain a single type
        internal class FirstPlugin : ServiceBusPlugin
#pragma warning restore SA1402 // File may only contain a single type
        {
            public override string Name => nameof(FirstPlugin);

            public override Task BeforeMessageSend(ServiceBusMessage message)
            {
                message.Properties.Add("FirstSendPlugin", true);
                return Task.FromResult(message);
            }
        }

#pragma warning disable SA1402 // File may only contain a single type
        internal class SecondPlugin : ServiceBusPlugin
#pragma warning restore SA1402 // File may only contain a single type
        {
            public override string Name => nameof(SecondPlugin);

            public override Task BeforeMessageSend(ServiceBusMessage message)
            {
                // Ensure that the first plugin actually ran first
                Assert.True((bool)message.Properties["FirstSendPlugin"]);
                message.Properties.Add("SecondSendPlugin", true);
                return Task.FromResult(message);
            }
        }

        internal class SendReceivePlugin : ServiceBusPlugin
        {
            public override string Name => nameof(SendReceivePlugin);

            public bool WasCalled;

            public override Task BeforeMessageSend(ServiceBusMessage message)
            {
                WasCalled = true;
                message.Body = new BinaryData("sent");
                return Task.CompletedTask;
            }

            public override Task AfterMessageReceive(ServiceBusReceivedMessage message)
            {
                Assert.AreEqual("sent", message.Body.ToString());
                SetBody(message, new BinaryData("received"));
                return Task.FromResult(message);
            }
        }

        internal class ExceptionPlugin : ServiceBusPlugin
        {
            public override string Name => nameof(ExceptionPlugin);

            public override Task BeforeMessageSend(ServiceBusMessage message)
            {
                throw new NotImplementedException();
            }

            public override Task AfterMessageReceive(ServiceBusReceivedMessage message)
            {
                throw new NotImplementedException();
            }
        }

        internal class ShouldContinueOnExceptionPlugin : ServiceBusPlugin
        {
            public override bool ShouldContinueOnException => true;

            public override string Name => nameof(ShouldContinueOnExceptionPlugin);

            public override async Task BeforeMessageSend(ServiceBusMessage message)
            {
                message.Body = new BinaryData("before exception");
                await Task.Delay(1);
                throw new NotImplementedException();
            }

            public override Task AfterMessageReceive(ServiceBusReceivedMessage message)
            {
                SetLabel(message, "received");
                throw new NotImplementedException();
            }
        }
    }
}
