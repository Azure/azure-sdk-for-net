// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudEvent = CloudNative.CloudEvents.CloudEvent;

namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents.Tests
{
    public class CloudNativeLiveTests : EventGridLiveTestBase
    {
        public CloudNativeLiveTests(bool async) : base(async)
        {
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
                    new CloudEvent
                    {
                        Type = "record",
                        Source = new Uri("http://localHost"),
                        Id = Recording.Random.NewGuid().ToString(),
                        Time = Recording.Now,
                        Data = new TestPayload("name", i)
                    });
            }

            await client.SendCloudNativeCloudEventsAsync(eventsList);
        }

        [RecordedTest]
        public async Task CanPublishSingleCloudEvent()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey),
                    options));

            CloudEvent cloudEvent =
                new CloudEvent
                {
                    Type = "record",
                    Source = new Uri("http://localHost"),
                    Id = Recording.Random.NewGuid().ToString(),
                    Time = Recording.Now,
                    Data = new TestPayload("name", 0)
                };

            await client.SendCloudNativeCloudEventAsync(cloudEvent);
        }

        [RecordedTest]
        public async Task CanPublishCloudEventToDomain()
        {
            EventGridPublisherClientOptions options = InstrumentClientOptions(new EventGridPublisherClientOptions());
            EventGridPublisherClient client = InstrumentClient(
                new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventDomainHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventDomainKey),
                    options));

            #region Snippet:CloudNativePublishToDomain
            CloudEvent cloudEvent =
                new CloudEvent
                {
                    Type = "record",
                    // Event Grid does not allow absolute URIs as the domain topic
                    Source = new Uri("test", UriKind.Relative),
#if SNIPPET
                    Id = "eventId",
                    Time = DateTimeOffset.Now,
#else
                    Id = Recording.Random.NewGuid().ToString(),
                    Time = Recording.Now,
#endif
                    Data = new TestPayload("name", 0)
                };

            await client.SendCloudNativeCloudEventAsync(cloudEvent);
            #endregion
        }

        private class TestPayload
        {
            public TestPayload(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public TestPayload() { }

            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
