// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridEventTests
    {
        [Test]
        public async Task SerializesExpectedProperties_BaseType()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("http://localHost"),
                   new AzureKeyCredential("fakeKey"),
                   options);
            var egEvent = new EventGridEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    "TestPayload",
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    },
                    typeof(TestPayload));

            // Data is a BinaryData so it will always serialize first even if cloudEvent was not constructed by calling Parse.
            Assert.IsNull(egEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<EventGridEvent> eventsList = new List<EventGridEvent>()
            {
                egEvent
            };

            await client.SendEventsAsync(eventsList);

            egEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.IsNull(egEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
        }

        [Test]
        public async Task SerializesExpectedProperties_DerivedType()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("http://localHost"),
                   new AzureKeyCredential("fakeKey"),
                   options);
            var egEvent = new EventGridEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    "TestPayload",
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    });

            Assert.AreEqual(5, egEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<EventGridEvent> eventsList = new List<EventGridEvent>()
            {
                egEvent
            };

            await client.SendEventsAsync(eventsList);

            egEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.AreEqual(5, egEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
        }

        [Test]
        public void PassingBinaryDataToWrongConstructorThrows()
        {
            Assert.That(
                () => new EventGridEvent("subject", "type", "version", (object) new BinaryData("data")),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public async Task RespectsPortFromUriSendingEventGridEvents()
        {
            var mockTransport = new MockTransport((request) =>
            {
                Assert.AreEqual(100, request.Uri.Port);
                return new MockResponse(200);
            });
            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("https://contoso.com:100/api/events"),
                   new AzureKeyCredential("fakeKey"),
                   options);
            var egEvent = new EventGridEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    "TestPayload",
                    new TestPayload
                    {
                        Name = "name",
                        Age = 10,
                    });

            List<EventGridEvent> eventsList = new List<EventGridEvent>()
            {
                egEvent
            };

            await client.SendEventsAsync(eventsList);
        }

        private static List<EventGridEvent> DeserializeRequest(Request request)
        {
            var content = request.Content as Utf8JsonRequestContent;
            var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;
            JsonDocument requestDocument = JsonDocument.Parse(stream);
            var egEvents = new List<EventGridEvent>();
            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                egEvents.Add(new EventGridEvent(EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement)));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    egEvents.Add(new EventGridEvent(EventGridEventInternal.DeserializeEventGridEventInternal(property)));
                }
            }
            return egEvents;
        }
    }
}
