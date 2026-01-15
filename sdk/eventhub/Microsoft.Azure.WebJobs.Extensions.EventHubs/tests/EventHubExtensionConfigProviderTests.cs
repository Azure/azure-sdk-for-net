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
            Assert.That(bindingData.ContentType, Is.EqualTo("application/octet-stream"));
            Assert.That(bindingData.Version, Is.EqualTo("1.0"));
            Assert.That(bindingData.Source, Is.EqualTo("AzureEventHubsEventData"));

            var output = new EventData(AmqpAnnotatedMessage.FromBytes(bindingData.Content));

            Assert.That(output.Body.ToArray(), Is.EqualTo(input.Body.ToArray()));
            Assert.That(output.MessageId, Is.EqualTo(input.MessageId));
            Assert.That(output.CorrelationId, Is.EqualTo(input.CorrelationId));
            Assert.That(output.Properties["key"], Is.EqualTo(input.Properties["key"]));
        }
    }
}