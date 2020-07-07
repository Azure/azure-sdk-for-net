// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            EventGridClientOptions options = Recording.InstrumentClientOptions(new EventGridClientOptions());
            EventGridClient client = InstrumentClient(
                new EventGridClient(
                    new Uri(TestEnvironment.TopicHost),
                    new AzureKeyCredential(TestEnvironment.TopicKey),
                    options));
            await client.PublishEventsAsync(GetEventsList());
        }

        [Test]
        public async Task CanPublishEventToDomain()
        {
            EventGridClientOptions options = Recording.InstrumentClientOptions(new EventGridClientOptions());
            EventGridClient client = InstrumentClient(
                new EventGridClient(
                    new Uri(TestEnvironment.DomainHost),
                    new AzureKeyCredential(TestEnvironment.DomainKey),
                    options));
            await client.PublishEventsAsync(GetEventsWithTopicsList());

        }

        [Test]
        public async Task CanPublishCloudEvent()
        {
            EventGridClientOptions options = Recording.InstrumentClientOptions(new EventGridClientOptions());
            EventGridClient client = InstrumentClient(
                new EventGridClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));
            await client.PublishCloudEventsAsync(GetCloudEventsList());
        }

        [Test]
        public async Task CanPublishEventUsingSAS()
        {
            EventGridClient client = new EventGridClient(
                new Uri(TestEnvironment.TopicHost),
                new AzureKeyCredential(TestEnvironment.TopicKey));

            string sasToken = client.BuildSharedAccessSignature(DateTimeOffset.UtcNow.AddMinutes(60));

            EventGridClient sasTokenClient = InstrumentClient(
                new EventGridClient(
                    new Uri(TestEnvironment.TopicHost),
                    new SharedAccessSignatureCredential(sasToken),
                    Recording.InstrumentClientOptions(new EventGridClientOptions())));
            await sasTokenClient.PublishEventsAsync(GetEventsList());
        }

        private IList<EventGridEvent> GetEventsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        Recording.Random.NewGuid().ToString(),
                        $"Subject-{i}",
                        "hello",
                        "Microsoft.MockPublisher.TestEvent",
                        Recording.Now,
                        "1.0"));
            }

            return eventsList;
        }

        private IList<EventGridEvent> GetEventsWithTopicsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new EventGridEvent(
                        Recording.Random.NewGuid().ToString(),
                        $"Topic-{i}",
                        $"Subject-{i}",
                        "hello",
                        "Microsoft.MockPublisher.TestEvent",
                        Recording.Now,
                        "1",
                        "1.0"));
            }

            return eventsList;
        }

        private IList<CloudEvent> GetCloudEventsList()
        {
            List<CloudEvent> eventsList = new List<CloudEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(
                    new CloudEvent(
                        Recording.Random.NewGuid().ToString(),
                        $"Subject-{i}",
                        "record",
                        "1.0"));
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
                    dataVersion = "1.0",
                    eventTime = Recording.Now,
                    eventType = "Microsoft.MockPublisher.TestEvent",
                    id = Recording.Random.NewGuid().ToString(),
                    subject = $"Subject-{i}",
                    topic = $"Topic-{i}"
                });
            }

            return eventsList;
        }
    }
}
