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
        private static readonly DateTimeOffset s_now = DateTimeOffset.UtcNow;
        [Test]
        public void PluginSetsReceivedMessageProperties()
        {
            var plugin = new TestPlugin();
            var msg = new ServiceBusReceivedMessage();
            plugin.AfterMessageReceiveAsync(msg);
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

        private class TestPlugin : ServiceBusPlugin
        {
            public override ValueTask AfterMessageReceiveAsync(ServiceBusReceivedMessage message)
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
                return default;
            }
        }
    }
}
