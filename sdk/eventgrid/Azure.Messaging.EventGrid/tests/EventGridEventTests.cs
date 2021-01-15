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
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    },
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    "TestPayload",
                    typeof(TestPayload));

            // since the data has not yet been serialized (CloudEvent not constructed from Parse method), GetData returns the passed in instance.
            Assert.AreEqual(5, egEvent.GetData<DerivedTestPayload>().DerivedProperty);

            // GetData returns as BinaryData so it will always serialize first even if cloudEvent was not constructed by calling Parse.
            Assert.IsNull(egEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<EventGridEvent> eventsList = new List<EventGridEvent>()
            {
                egEvent
            };

            await client.SendEventsAsync(eventsList);

            egEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.IsNull(egEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.IsNull(egEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
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
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    },
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    "TestPayload");

            Assert.AreEqual(5, egEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.AreEqual(5, egEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<EventGridEvent> eventsList = new List<EventGridEvent>()
            {
                egEvent
            };

            await client.SendEventsAsync(eventsList);

            egEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.AreEqual(5, egEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.AreEqual(5, egEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
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
