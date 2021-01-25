// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
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

        [Test]
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
                        new Uri("http://localHost"),
                        Recording.Random.NewGuid().ToString(),
                        Recording.Now.DateTime)
                    {
                        Data = new TestPayload("name", i)
                    }
                    );
            }

            await client.SendCloudEventsAsync(eventsList);
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
