// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventGrid.Tests.Samples
{
    public partial class EventGridSamples : SamplesBase<EventGridTestEnvironment>
    {
        // This sample demonstrates how to publish Event Grid schema events to an Event Grid topic.
        [Test]
        public async Task SendEventGridEventsToTopic()
        {
            string topicEndpoint = TestEnvironment.TopicHost;
            string topicAccessKey = TestEnvironment.TopicKey;

            // Create the publisher client using an AzureKeyCredential
            // Custom topic should be configured to accept events of the Event Grid schema
            #region Snippet:CreateClient
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(topicEndpoint),
                new AzureKeyCredential(topicAccessKey));
            #endregion

            #region Snippet:SendEGEventsToTopic
            // Add EventGridEvents to a list to publish to the topic
            List<EventGridEvent> eventsList = new List<EventGridEvent>
            {
                new EventGridEvent(
                    "This is the event data",
                    "ExampleEventSubject",
                    "Example.EventType",
                    "1.0")
            };

            // Send the events
            await client.SendEventsAsync(eventsList);
            #endregion
        }

        // This sample demonstrates how to publish CloudEvents 1.0 schema events to an Event Grid topic.
        [Test]
        public async Task SendCloudEventsToTopic()
        {
            string topicEndpoint = TestEnvironment.CloudEventTopicHost;
            string topicAccessKey = TestEnvironment.CloudEventTopicKey;

            // Example of a custom ObjectSerializer used to serialize the event payload to JSON
            var myCustomDataSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            // Create the publisher client using an AzureKeyCredential
            // Custom topic should be configured to accept events of the CloudEvents 1.0 schema
            #region Snippet:CreateClientWithOptions
            EventGridPublisherClientOptions clientOptions = new EventGridPublisherClientOptions()
            {
                Serializer = myCustomDataSerializer
            };

            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(topicEndpoint),
                new AzureKeyCredential(topicAccessKey),
                clientOptions);
            #endregion

            #region Snippet:SendCloudEventsToTopic
            // Add CloudEvents to a list to publish to the topic
            List<CloudEvent> eventsList = new List<CloudEvent>
            {
                // CloudEvent with populated data
                new CloudEvent(
                    "/cloudevents/example/source",
                    "Example.EventType",
                    "This is the event data"),

                // CloudEvents also supports sending binary-valued data
                new CloudEvent(
                    "/cloudevents/example/binarydata",
                    "Example.EventType",
                    new BinaryData("This is binary data"),
                    "example/binary")};

            // Send the events
            await client.SendEventsAsync(eventsList);
            #endregion
        }

        // This sample demonstrates how to publish Event Grid schema events to a topic within an Event Grid domain.
        [Test]
        public async Task SendEventsToDomain()
        {
            string domainEndpoint = TestEnvironment.DomainHost;
            string domainAccessKey = TestEnvironment.DomainKey;

            #region Snippet:CreateDomainClient
            // Create the publisher client using an AzureKeyCredential
            // Domain should be configured to accept events of the Event Grid schema
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(domainEndpoint),
                new AzureKeyCredential(domainAccessKey));
            #endregion

            #region Snippet:SendEventsToDomain
            // Add EventGridEvents to a list to publish to the domain
            // Don't forget to specify the topic you want the event to be delivered to!
            List<EventGridEvent> eventsList = new List<EventGridEvent>
            {
                new EventGridEvent(
                    "This is the event data",
                    "ExampleEventSubject",
                    "Example.EventType",
                    "1.0")
                {
                    Topic = "MyTopic"
                }
            };

            // Send the events
            await client.SendEventsAsync(eventsList);
            #endregion
        }
    }
}
