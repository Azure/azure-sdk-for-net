// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests.Samples
{
    public partial class EventGridSamples : EventGridLiveTestBase
    {
        public EventGridSamples(bool async)
            : base(async)
        {
        }

        [Test]
        public async Task SendEventGridEventsToTopic()
        {
            string topicEndpoint = TestEnvironment.TopicHost;
            string topicAccessKey = TestEnvironment.TopicKey;

            #region Snippet:SendEGEventsToTopic
            // Create the publisher client using an AzureKeyCredential
            // Custom topic should be configured to accept events of the Event Grid schema
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(topicEndpoint),
                new AzureKeyCredential(topicAccessKey));

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

        [Test]
        public async Task SendCloudEventsToTopic()
        {
            string topicEndpoint = TestEnvironment.CloudEventTopicHost;
            string topicAccessKey = TestEnvironment.CloudEventTopicKey;

            #region Snippet:SendCloudEventsToTopic
            // Create the publisher client using an AzureKeyCredential
            // Custom topic should be configured to accept events of the CloudEvents 1.0 schema
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(topicEndpoint),
                new AzureKeyCredential(topicAccessKey));

            // Add CloudEvents to a list to publish to the topic
            List<CloudEvent> eventsList = new List<CloudEvent>
            {
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

        [Test]
        public async Task SendEventsToDomain()
        {
            string domainEndpoint = TestEnvironment.DomainHost;
            string domainAccessKey = TestEnvironment.DomainKey;

            #region Snippet:SendEventsToDomain
            // Create the publisher client using an AzureKeyCredential
            // Domain should be configured to accept events of the Event Grid schema
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri(domainEndpoint),
                new AzureKeyCredential(domainAccessKey));

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
