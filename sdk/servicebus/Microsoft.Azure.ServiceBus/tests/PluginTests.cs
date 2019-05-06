// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    public class PluginTests
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Registering_plugin_multiple_times_should_throw()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    var firstPlugin = new FirstSendPlugin();
                    var secondPlugin = new FirstSendPlugin();

                    messageReceiver.RegisterPlugin(firstPlugin);
                    Assert.Throws<ArgumentException>(() => messageReceiver.RegisterPlugin(secondPlugin));
                }
                finally
                {
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Unregistering_plugin_should_complete_with_plugin_set()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    var firstPlugin = new FirstSendPlugin();

                    messageReceiver.RegisterPlugin(firstPlugin);
                    messageReceiver.UnregisterPlugin(firstPlugin.Name);
                }
                finally
                {
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Unregistering_plugin_should_complete_without_plugin_set()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    messageReceiver.UnregisterPlugin("Non-existant plugin");
                }
                finally
                {
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Multiple_plugins_should_run_in_order()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    var firstPlugin = new FirstSendPlugin();
                    var secondPlugin = new SecondSendPlugin();

                    messageSender.RegisterPlugin(firstPlugin);
                    messageSender.RegisterPlugin(secondPlugin);

                    var sendMessage = new Message(Encoding.UTF8.GetBytes("Test message"));
                    await messageSender.SendAsync(sendMessage);

                    var receivedMessage = await messageReceiver.ReceiveAsync(1, TimeSpan.FromMinutes(1));
                    var firstSendPluginUserProperty = receivedMessage.First().UserProperties["FirstSendPlugin"];
                    var secondSendPluginUserProperty = receivedMessage.First().UserProperties["SecondSendPlugin"];

                    Assert.True((bool)firstSendPluginUserProperty);
                    Assert.True((bool)secondSendPluginUserProperty);
                }
                finally
                {
                    await messageSender.CloseAsync();
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Multiple_plugins_should_be_able_to_manipulate_message()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    var sendReceivePlugin = new SendReceivePlugin();
                    messageSender.RegisterPlugin(sendReceivePlugin);
                    messageReceiver.RegisterPlugin(sendReceivePlugin);

                    var sendMessage = new Message(Encoding.UTF8.GetBytes("Test message"))
                    {
                        MessageId = Guid.NewGuid().ToString()
                    };
                    await messageSender.SendAsync(sendMessage);

                    // Ensure the plugin is called.
                    Assert.True(sendReceivePlugin.MessageBodies.ContainsKey(sendMessage.MessageId));

                    var receivedMessage = await messageReceiver.ReceiveAsync(TimeSpan.FromMinutes(1));

                    Assert.Equal(sendMessage.Body, receivedMessage.Body);
                }

                finally
                {
                    await messageSender.CloseAsync();
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Plugin_without_ShouldContinueOnException_should_throw()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                try
                {
                    var plugin = new ExceptionPlugin();

                    messageSender.RegisterPlugin(plugin);

                    var sendMessage = new Message(Encoding.UTF8.GetBytes("Test message"));
                    await Assert.ThrowsAsync<NotImplementedException>(() => messageSender.SendAsync(sendMessage));
                }
                finally
                {
                    await messageSender.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task Plugin_with_ShouldContinueOnException_should_continue()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                try
                {
                    var plugin = new ShouldCompleteAnywayExceptionPlugin();

                    messageSender.RegisterPlugin(plugin);

                    var sendMessage = new Message(Encoding.UTF8.GetBytes("Test message"));
                    await messageSender.SendAsync(sendMessage);
                }
                finally
                {
                    await messageSender.CloseAsync();
                }

                var messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    await messageReceiver.ReceiveAsync();
                }
                finally
                {
                    await messageReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueClientShouldPassPluginsToMessageSession()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                try
                {
                    var messageReceived = false;
                    var sendReceivePlugin = new SendReceivePlugin();
                    queueClient.RegisterPlugin(sendReceivePlugin);

                    var sendMessage = new Message(Encoding.UTF8.GetBytes("Test message"))
                    {
                        MessageId = Guid.NewGuid().ToString(),
                        SessionId = Guid.NewGuid().ToString()
                    };
                    await queueClient.SendAsync(sendMessage);

                    // Ensure the plugin is called.
                    Assert.True(sendReceivePlugin.MessageBodies.ContainsKey(sendMessage.MessageId));

                    queueClient.RegisterSessionHandler(
                        (session, message, cancellationToken) =>
                        {
                            Assert.Equal(sendMessage.SessionId, session.SessionId);
                            Assert.True(session.RegisteredPlugins.Contains(sendReceivePlugin));
                            Assert.Equal(sendMessage.Body, message.Body);

                            messageReceived = true;
                            return Task.CompletedTask;
                        },
                        exceptionArgs => Task.CompletedTask);

                    for (var i = 0; i < 20; i++)
                    {
                        if (messageReceived)
                        {
                            break;
                        }
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }

                    Assert.True(messageReceived);
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }
    }

    internal class FirstSendPlugin : ServiceBusPlugin
    {
        public override string Name => nameof(SendReceivePlugin);

        public override Task<Message> BeforeMessageSend(Message message)
        {
            message.UserProperties.Add("FirstSendPlugin", true);
            return Task.FromResult(message);
        }
    }

    internal class SecondSendPlugin : ServiceBusPlugin
    {
        public override string Name => nameof(SendReceivePlugin);

        public override Task<Message> BeforeMessageSend(Message message)
        {
            // Ensure that the first plugin actually ran first
            Assert.True((bool)message.UserProperties["FirstSendPlugin"]);
            message.UserProperties.Add("SecondSendPlugin", true);
            return Task.FromResult(message);
        }
    }

    internal class SendReceivePlugin : ServiceBusPlugin
    {
        // Null the body on send, and replace it when received.
        public Dictionary<string, byte[]> MessageBodies = new Dictionary<string,byte[]>();

        public override string Name => nameof(SendReceivePlugin);

        public override Task<Message> BeforeMessageSend(Message message)
        {
            this.MessageBodies.Add(message.MessageId, message.Body);
            var clonedMessage = message.Clone();
            clonedMessage.Body = null;
            return Task.FromResult(clonedMessage);
        }

        public override Task<Message> AfterMessageReceive(Message message)
        {
            Assert.Null(message.Body);
            message.Body = this.MessageBodies[message.MessageId];
            return Task.FromResult(message);
        }
    }

    internal class ExceptionPlugin : ServiceBusPlugin
    {
        public override string Name => nameof(ExceptionPlugin);

        public override Task<Message> BeforeMessageSend(Message message)
        {
            throw new NotImplementedException();
        }
    }

    internal class ShouldCompleteAnywayExceptionPlugin : ServiceBusPlugin
    {
        public override bool ShouldContinueOnException => true;

        public override string Name => nameof(ShouldCompleteAnywayExceptionPlugin);

        public override Task<Message> BeforeMessageSend(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
