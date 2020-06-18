// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Plugins;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Plugins
{
    public class PluginTests : ServiceBusTestBase
    {
        private static DateTimeOffset s_now = DateTimeOffset.UtcNow;
        [Test]
        public void PluginSetsReceivedMessageProperties()
        {
            var plugin = new TestPlugin();
            var msg = new ServiceBusReceivedMessage();
            plugin.AfterMessageReceive(msg);
            Assert.AreEqual("body", msg.Body.ToString());
            Assert.AreEqual("contentType", msg.ContentType);
            Assert.AreEqual("propertyValue", msg.Properties["propertyKey"]);
            Assert.AreEqual("deadLetterDescription", msg.DeadLetterErrorDescription);
            Assert.AreEqual("deadLetterReason", msg.DeadLetterReason);
            Assert.AreEqual("label", msg.Label);
            Assert.AreEqual("messageId", msg.MessageId);
            Assert.AreEqual("partitionKey", msg.PartitionKey);
            Assert.AreEqual("replyTo", msg.ReplyTo);
            Assert.AreEqual("replyToSessionId", msg.ReplyToSessionId);
            Assert.AreEqual("partitionKey", msg.PartitionKey);
            Assert.AreEqual(s_now, msg.ScheduledEnqueueTime);
            Assert.AreEqual("sessionId", msg.SessionId);
            Assert.AreEqual(TimeSpan.FromSeconds(60), msg.TimeToLive);
            Assert.AreEqual("to", msg.To);
        }

        [Test]
        public void CanSetAndGetPlugins()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var client = new ServiceBusClient(fakeConnection);
            var plugin = new TestPlugin();
            client.RegisterPlugin(plugin);
            var registered = client.GetPlugins();
            Assert.AreSame(plugin, registered[0]);
            client.ClearPlugins();
            registered = client.GetPlugins();
            Assert.AreEqual(0, registered.Count);
        }

        [Test]
        public void PluginChangesDoNotAffectAlreadyCreatedMembers()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var client = new ServiceBusClient(fakeConnection);
            var plugin = new TestPlugin();
            client.RegisterPlugin(plugin);
            var receiver = client.CreateReceiver("fakeQueue");
            Assert.AreEqual(1, receiver._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(1, receiver._plugins.Count);

            var subscriptionReceiver = client.CreateReceiver("fakeTopic", "fakeSubscription");
            Assert.AreEqual(2, subscriptionReceiver._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(2, subscriptionReceiver._plugins.Count);

            var sender = client.CreateSender("fakeQueue");
            Assert.AreEqual(3, sender._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(3, sender._plugins.Count);

            var dlq = client.CreateDeadLetterReceiver("fakeQueue");
            Assert.AreEqual(4, dlq._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(4, dlq._plugins.Count);

            var subscriptionDlq = client.CreateDeadLetterReceiver("fakeTopic", "fakeSubscription");
            Assert.AreEqual(5, subscriptionDlq._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(5, subscriptionDlq._plugins.Count);

            var processor = client.CreateProcessor("fakeQueue");
            Assert.AreEqual(6, processor._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(6, processor._plugins.Count);

            var subscriptionProcessor = client.CreateProcessor("fakeTopic", "fakeSubscription");
            Assert.AreEqual(7, subscriptionProcessor._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(7, subscriptionProcessor._plugins.Count);

            var sessionProcessor = client.CreateSessionProcessor("fakeQueue");
            Assert.AreEqual(8, sessionProcessor._innerProcessor._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(8, sessionProcessor._innerProcessor._plugins.Count);

            var subscriptionSessionProcessor = client.CreateSessionProcessor("fakeTopic", "fakeSubscription");
            Assert.AreEqual(9, subscriptionSessionProcessor._innerProcessor._plugins.Count);
            client.RegisterPlugin(plugin);
            Assert.AreEqual(9, subscriptionSessionProcessor._innerProcessor._plugins.Count);
        }

        internal class TestPlugin : ServiceBusPlugin
        {
            public override string Name => throw new NotImplementedException();

            public override Task AfterMessageReceive(ServiceBusReceivedMessage message)
            {
                SetBody(message, new BinaryData("body"));
                SetContentType(message, "contentType");
                SetCorrelationId(message, "correlationId");
                SetUserProperty(message, "propertyKey", "propertyValue");
                SetUserProperty(message, ServiceBusReceivedMessage.DeadLetterErrorDescriptionHeader, "deadLetterDescription");
                SetUserProperty(message, ServiceBusReceivedMessage.DeadLetterReasonHeader, "deadLetterReason");
                SetLabel(message, "label");
                SetMessageId(message, "messageId");
                SetPartitionKey(message, "partitionKey");
                SetReplyTo(message, "replyTo");
                SetReplyToSessionId(message, "replyToSessionId");
                SetScheduledEnqueueTime(message, s_now);
                SetSessionId(message, "sessionId");
                SetTimeToLive(message, TimeSpan.FromSeconds(60));
                SetTo(message, "to");
                return Task.CompletedTask;
            }
        }
    }
}
