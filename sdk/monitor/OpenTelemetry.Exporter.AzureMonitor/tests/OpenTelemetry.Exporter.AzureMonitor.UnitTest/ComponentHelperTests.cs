// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class ComponentHelperTests
    {
        [Fact]
        public void PartBTagsAreCollectedProducerKindWithAzNamespaceEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "Microsoft.EventHub"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);

            Assert.Equal("Queue Message | Azure Event Hubs", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedProducerKindWithAzNamespaceEventHubsAndAttributes()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "Microsoft.EventHub",
                ["peer.address"] = "amqps://eventHub.servicebus.windows.net/",
                ["message_bus.destination"] = "queueName",
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);

            Assert.Equal("Queue Message | Azure Event Hubs", type);
            Assert.Equal("amqps://eventHub.servicebus.windows.net/queueName", target);
        }

        [Fact]
        public void PartBTagsAreCollectedInternalKindWithAzNamespaceEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "Microsoft.EventHub"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Internal, out var type, out var target);

            Assert.Equal("InProc | Azure Event Hubs", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreAreCollectedProducerKindWithAzNamespace()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "foo"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);

            Assert.Equal("Queue Message | foo", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedInternalKindWithAzNamespace()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "foo"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Internal, out var type, out var target);

            Assert.Equal("InProc | foo", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedServerKindEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "Microsoft.EventHub",
                ["peer.address"] = "amqps://eventHub.servicebus.windows.net/",
                ["message_bus.destination"] = "queueName",
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Server, out var _, out var source);
            Assert.Equal("amqps://eventHub.servicebus.windows.net/queueName", source);
        }

        [Fact]
        public void PartBTagsAreCollectedConsumerKindEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["az.namespace"] = "Microsoft.EventHub",
                ["peer.address"] = "amqps://eventHub.servicebus.windows.net/",
                ["message_bus.destination"] = "queueName",
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Consumer, out var _, out var source);
            Assert.Equal("amqps://eventHub.servicebus.windows.net/queueName", source);
        }

        [Fact]
        public void PartBTagsAreCollectedProducerKindWithComponentEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["component"] = "eventhubs"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);

            Assert.Equal("Queue Message | Azure Event Hubs", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedProducerKindWithComponent()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["component"] = "foo"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);

            Assert.Equal("Queue Message | foo", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedInternalKindWithComponent()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["component"] = "foo"
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Internal, out var type, out var target);

            Assert.Equal("InProc | foo", type);
            Assert.Null(target);
        }

        [Fact]
        public void PartBTagsAreCollectedForEventHubs()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["component"] = "eventhubs",
                ["peer.address"] = "amqps://eventHub.servicebus.windows.net/",
                ["message_bus.destination"] = "queueName",
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Client, out var type, out var target);

            Assert.Equal("Azure Event Hubs", type);
            Assert.Equal("amqps://eventHub.servicebus.windows.net/queueName", target);
        }

        [Fact]
        public void PartBTagsAreCollectedForEventHubsMessages()
        {
            var partBTags = new Dictionary<string, string>
            {
                ["component"] = "eventhubs",
                ["peer.address"] = "amqps://eventHub.servicebus.windows.net/",
                ["message_bus.destination"] = "queueName",
            };

            ComponentHelper.ExtractComponentProperties(partBTags, ActivityKind.Producer, out var type, out var target);
            Assert.Equal("Queue Message | Azure Event Hubs", type);
            Assert.Equal("amqps://eventHub.servicebus.windows.net/queueName", target);
        }
    }
}
