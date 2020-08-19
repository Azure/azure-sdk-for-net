// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientLiveTests : EventGridLiveTestBase
    {
        public EventGridClientLiveTests(bool async)
            : base(async)
        {
        }

        [Test]
        public async Task CanPublishEvent()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureKeyCredential(TestEnvironment.TopicKey),
                    options));
            await client.SendEventsAsync(GetEventsList());
        }

        [Test]
        public async Task CanPublishEventWithCustomObjectPayload()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureKeyCredential(TestEnvironment.TopicKey),
                    options));

            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        $"Subject-{i}",
                        new TestPayload("name", i),
                        "Microsoft.MockPublisher.TestEvent",
                        "1.0")
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        EventTime = Recording.Now
                    });
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishEventToDomain()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.DomainHost),
                    new AzureKeyCredential(TestEnvironment.DomainKey),
                    options));

            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                EventGridEvent newEGEvent = new EventGridEvent(
                    $"Subject-{i}",
                    "hello",
                    "Microsoft.MockPublisher.TestEvent",
                    "1.0")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    EventTime = Recording.Now
                };
                newEGEvent.Topic = $"Topic-{i}";

                eventsList.Add(newEGEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCloudEvent()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new CloudEvent(
                        "record",
                        "Microsoft.MockPublisher.TestEvent")
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        Subject = $"Subject-{i}",
                        Time = Recording.Now
                    });
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCloudEventWithBinaryData()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 5; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                // testing byte[]
                cloudEvent.Data = Encoding.UTF8.GetBytes("data");
                eventsList.Add(cloudEvent);
            }
            for (int i = 0; i < 5; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                // testing ReadOnlyMemory<byte>
                cloudEvent.Data = new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("data"));
                eventsList.Add(cloudEvent);
            }
            for (int i = 0; i < 5; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                // testing IEnumerable<byte>
                cloudEvent.Data = Enumerable.Repeat((byte) 1, 1);
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCloudEventWithRawJsonData()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                cloudEvent.Data = "{\"property1\": \"abc\",  \"property2\": \"123\"}";
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCloudEventWithCustomObjectPayload()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                cloudEvent.Data = new TestPayload("name", i);
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCloudEventWithExtensionAttributes()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                cloudEvent.Data = "hello";
                cloudEvent.ExtensionAttributes.Add("testattribute1", "test");
                cloudEvent.ExtensionAttributes.Add("testattribute2", new TestPayload("name", i));
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task CanPublishCustomEvent()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CustomEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CustomEventTopicKey),
                    options));
            await client.SendEventsAsync(GetCustomEventsList());
        }

        [Test]
        public async Task CanPublishEventUsingSAS()
        {
            string sasToken = EventGridPublisherClient.BuildSharedAccessSignature(
                new Uri(TestEnvironment.TopicHost),
                DateTimeOffset.UtcNow.AddMinutes(60),
                new AzureKeyCredential(TestEnvironment.TopicKey));

            EventGridPublisherClient sasTokenClient = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new EventGridSharedAccessSignatureCredential(sasToken),
                    Recording.InstrumentClientOptions(new EventGridPublisherClientOptions())));
            await sasTokenClient.SendEventsAsync(GetEventsList());
        }

        [Test]
        public async Task CustomizeSerializedJSONPropertiesToCamelCase()
        {
            EventGridPublisherClientOptions options = Recording.InstrumentClientOptions(new EventGridPublisherClientOptions());
            options.DataSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CustomEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CustomEventTopicKey),
                    options));
            await client.SendEventsAsync(GetCustomEventsList());
        }

        private IList<EventGridEvent> GetEventsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        $"Subject-{i}",
                        "hello",
                        "Microsoft.MockPublisher.TestEvent",
                        "1.0")
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        EventTime = Recording.Now
                    });
            }

            return eventsList;
        }

        private IList<object> GetCustomEventsList()
        {
            List<object> eventsList = new List<object>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new TestEvent()
                {
                    DataVersion = "1.0",
                    EventTime = Recording.Now,
                    EventType = "Microsoft.MockPublisher.TestEvent",
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Topic = $"Topic-{i}"
                });
            }

            return eventsList;
        }
    }
}
