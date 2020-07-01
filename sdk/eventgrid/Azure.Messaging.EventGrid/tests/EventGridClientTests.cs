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
    public class EventGridClientTests : EventGridLiveTestBase
    {
        public EventGridClientTests(bool async)
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
    }
}
