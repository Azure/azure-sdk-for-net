﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientLiveTests : EventGridLiveTestBase
    {
        public EventGridClientLiveTests(bool async)
            : base(async)
        {
        }

        [RecordedTest]
        public async Task CanPublishEvent()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureKeyCredential(TestEnvironment.TopicKey),
                    options));
            await client.SendEventsAsync(GetEventsList());
        }

        [RecordedTest]
        public async Task CanPublishEventWithCustomObjectPayload()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                        "Microsoft.MockPublisher.TestEvent",
                        "1.0",
                        new TestPayload("name", i))
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        EventTime = Recording.Now
                    });
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishEventWithCustomObjectPayloadAndCustomSerializer()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureKeyCredential(TestEnvironment.TopicKey),
                    options));
            var serializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        $"Subject-{i}",
                        "Microsoft.MockPublisher.TestEvent",
                        "1.0",
                        serializer.Serialize(new TestPayload("name", i)))
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        EventTime = Recording.Now
                    });
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishEventToDomain()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                    "Microsoft.MockPublisher.TestEvent",
                    "1.0",
                    "hello")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    EventTime = Recording.Now
                };
                newEGEvent.Topic = $"Topic-{i}";

                eventsList.Add(newEGEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEvent()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                        "Microsoft.MockPublisher.TestEvent",
                        null)
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        Subject = $"Subject-{i}",
                        Time = Recording.Now
                    });
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventWithBinaryData()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                    "Microsoft.MockPublisher.TestEvent",
                    // testing byte[]
                    new BinaryData(Encoding.UTF8.GetBytes("data")),
                    "test/binary")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }
            for (int i = 0; i < 5; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    // testing ReadOnlyMemory<byte>
                    new BinaryData(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("data"))),
                    "test/binary")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }
            for (int i = 0; i < 5; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    // testing IEnumerable<byte>
                    new BinaryData(Enumerable.Repeat((byte)1, 1).ToArray()),
                    "test/binary")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }
            for (int i = 0; i < 5; i++)
            {
                // testing BinaryData
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    new BinaryData(Encoding.UTF8.GetBytes("data")),
                    "test/binary")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventWithRawJsonData()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                    "Microsoft.MockPublisher.TestEvent",
                    new BinaryData("{\"property1\": \"abc\",  \"property2\": 123}"),
                    null,
                    CloudEventDataFormat.Json)
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventWithCustomObjectPayload()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                    "Microsoft.MockPublisher.TestEvent",
                    new TestPayload("name", i))
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventWithCustomObjectPayloadAndCustomSerializer()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));
            var serializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    serializer.Serialize(new TestPayload("name", i)),
                    "application/json",
                    dataFormat: CloudEventDataFormat.Json)
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventWithExtensionAttributes()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
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
                    "Microsoft.MockPublisher.TestEvent",
                    "hello")
                {
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Time = Recording.Now
                };
                cloudEvent.ExtensionAttributes.Add("testattribute1", "test");
                eventsList.Add(cloudEvent);
            }

            await client.SendEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishCustomEvent()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CustomEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CustomEventTopicKey),
                    options));
            await client.SendEventsAsync(GetCustomEventsList());
        }

        [RecordedTest]
        public async Task CanPublishEventUsingSAS()
        {
            var builder = new EventGridSasBuilder(
                new Uri(TestEnvironment.TopicHost),
                DateTimeOffset.UtcNow.AddMinutes(60));
            string sasToken = builder.GenerateSas(new AzureKeyCredential(TestEnvironment.TopicKey));

            EventGridPublisherClient sasTokenClient = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureSasCredential(sasToken),
                    InstrumentClientOptions(new EventGridPublisherClientOptions())));
            await sasTokenClient.SendEventsAsync(GetEventsList());
        }

        [RecordedTest]
        public async Task CustomizeSerializedJSONPropertiesToCamelCase()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            var serializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CustomEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CustomEventTopicKey),
                    options));
            List<BinaryData> eventsList = new List<BinaryData>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(serializer.Serialize(
                    new TestEvent()
                    {
                        DataVersion = "1.0",
                        EventTime = Recording.Now,
                        EventType = "Microsoft.MockPublisher.TestEvent",
                        Id = Recording.Random.NewGuid().ToString(),
                        Subject = $"Subject-{i}",
                        Topic = $"Topic-{i}"
                    }));
            }
            await client.SendEventsAsync(eventsList);
        }

        private IList<EventGridEvent> GetEventsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        $"Subject-{i}",
                        "Microsoft.MockPublisher.TestEvent",
                        "1.0",
                        "hello")
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        EventTime = Recording.Now
                    });
            }

            return eventsList;
        }

        private IList<BinaryData> GetCustomEventsList()
        {
            List<BinaryData> eventsList = new List<BinaryData>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new BinaryData(new TestEvent()
                {
                    DataVersion = "1.0",
                    EventTime = Recording.Now,
                    EventType = "Microsoft.MockPublisher.TestEvent",
                    Id = Recording.Random.NewGuid().ToString(),
                    Subject = $"Subject-{i}",
                    Topic = $"Topic-{i}"
                }));
            }

            return eventsList;
        }
    }
}
