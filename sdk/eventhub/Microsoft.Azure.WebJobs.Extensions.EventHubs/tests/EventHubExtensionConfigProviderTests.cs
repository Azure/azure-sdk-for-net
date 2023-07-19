// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests
{
    public class EventHubExtensionConfigProviderTests
    {
        [Test]
        public void ParameterBindingDataTest()
        {
            var input = new EventData(BinaryData.FromString("body"))
            {
                ContentType = "contentType",
                CorrelationId = "correlationId",
                MessageId = "messageId",
                Properties = { { "key", "value" } }
            };

            var bindingData = EventHubExtensionConfigProvider.ConvertEventDataToBindingData(input);
            Assert.AreEqual("application/octet-stream", bindingData.ContentType);
            Assert.AreEqual("1.0", bindingData.Version);
            Assert.AreEqual("AzureEventHubsEventData", bindingData.Source);

            var output = new EventData(AmqpAnnotatedMessage.FromBytes(bindingData.Content));

            Assert.AreEqual(input.Body.ToArray(), output.Body.ToArray());
            Assert.AreEqual(input.MessageId, output.MessageId);
            Assert.AreEqual(input.CorrelationId, output.CorrelationId);
            Assert.AreEqual(input.Properties["key"], output.Properties["key"]);
        }
    }
}