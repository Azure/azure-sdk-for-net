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
    public class CloudEventTests
    {
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";

        [Test]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task SetsTraceParentExtension(bool inclTraceparent, bool inclTracestate)
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
            var activity = new Activity($"{nameof(EventGridPublisherClient)}.{nameof(EventGridPublisherClient.SendEvents)}");
            activity.SetW3CFormat();
            activity.Start();
            List<CloudEvent> eventsList = new List<CloudEvent>();
            for (int i = 0; i < 10; i++)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    JsonDocument.Parse("{\"property1\": \"abc\",  \"property2\": 123}").RootElement)
                {
                    Id = "id",
                    Subject = $"Subject-{i}",
                    Time = DateTimeOffset.UtcNow
                };
                if (inclTraceparent && i % 2 == 0)
                {
                    cloudEvent.ExtensionAttributes.Add("traceparent", "traceparentValue");
                }
                if (inclTracestate && i % 2 == 0)
                {
                    cloudEvent.ExtensionAttributes.Add("tracestate", "param:value");
                }
                eventsList.Add(cloudEvent);
            }
            await client.SendEventsAsync(eventsList);

            activity.Stop();
            List<CloudEvent> cloudEvents = DeserializeRequest(mockTransport.SingleRequest);
            IEnumerator<CloudEvent> cloudEnum = eventsList.GetEnumerator();
            foreach (CloudEvent cloudEvent in cloudEvents)
            {
                cloudEnum.MoveNext();
                Dictionary<string, object> cloudEventAttr = cloudEnum.Current.ExtensionAttributes;
                if (cloudEventAttr.ContainsKey(TraceParentHeaderName) &&
                    cloudEventAttr.ContainsKey(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                        cloudEventAttr[TraceParentHeaderName],
                        cloudEvent.ExtensionAttributes[TraceParentHeaderName]);

                    Assert.AreEqual(
                        cloudEventAttr[TraceStateHeaderName],
                        cloudEvent.ExtensionAttributes[TraceStateHeaderName]);
                }
                else if (cloudEventAttr.ContainsKey(TraceParentHeaderName))
                {
                    Assert.AreEqual(
                        cloudEventAttr[TraceParentHeaderName],
                        cloudEvent.ExtensionAttributes[TraceParentHeaderName]);
                }
                else if (cloudEventAttr.ContainsKey(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                       cloudEventAttr[TraceStateHeaderName],
                       cloudEvent.ExtensionAttributes[TraceStateHeaderName]);
                }
                else
                {
                    Assert.AreEqual(
                       activity.Id,
                       cloudEvent.ExtensionAttributes[TraceParentHeaderName]);
                }
            }
        }

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
            var cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    },
                    "TestPayload",
                    typeof(TestPayload));

            // since the data has not yet been serialized (CloudEvent not constructed from Parse method), GetData returns the passed in instance.
            Assert.AreEqual(5, cloudEvent.GetData<DerivedTestPayload>().DerivedProperty);

            // GetData returns as BinaryData so it will always serialize first even if cloudEvent was not constructed by calling Parse.
            Assert.IsNull(cloudEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);

            cloudEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.IsNull(cloudEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.IsNull(cloudEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
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
            var cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    new DerivedTestPayload
                    {
                        Name = "name",
                        Age = 10,
                        DerivedProperty = 5
                    },
                    "TestPayload");

            Assert.AreEqual(5, cloudEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.AreEqual(5, cloudEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);

            cloudEvent = DeserializeRequest(mockTransport.SingleRequest).First();
            Assert.AreEqual(5, cloudEvent.GetData<DerivedTestPayload>().DerivedProperty);
            Assert.AreEqual(5, cloudEvent.GetData().ToObjectFromJson<DerivedTestPayload>().DerivedProperty);
        }

        private static List<CloudEvent> DeserializeRequest(Request request)
        {
            var content = request.Content as Utf8JsonRequestContent;
            var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;
            JsonDocument requestDocument = JsonDocument.Parse(stream);
            var cloudEvents = new List<CloudEvent>();
            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEvents.Add(new CloudEvent(CloudEventInternal.DeserializeCloudEventInternal(requestDocument.RootElement)));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEvents.Add(new CloudEvent(CloudEventInternal.DeserializeCloudEventInternal(property)));
                }
            }
            return cloudEvents;
        }
    }
}
