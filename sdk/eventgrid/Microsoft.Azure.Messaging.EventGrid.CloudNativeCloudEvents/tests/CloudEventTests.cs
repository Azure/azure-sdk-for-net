// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using CloudNative.CloudEvents;
using NUnit.Framework;
using CloudEvent = CloudNative.CloudEvents.CloudEvent;

namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents.Tests
{
    public class CloudEventTests
    {
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";

        private static readonly JsonEventFormatter s_eventFormatter = new JsonEventFormatter();

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
                var cloudEvent =
                    new CloudEvent(
                        "record",
                        new Uri("http://localHost"),
                        Guid.NewGuid().ToString(),
                        DateTime.Now);

                if (inclTraceparent && inclTracestate && i % 2 == 0)
                {
                    cloudEvent.GetAttributes().Add("traceparent", "traceparentValue");
                }
                if (inclTracestate && i % 2 == 0)
                {
                    cloudEvent.GetAttributes().Add("tracestate", "param:value");
                }
                eventsList.Add(cloudEvent);
            }
            await client.SendCloudEventsAsync(eventsList);

            activity.Stop();
            List<CloudEvent> cloudEvents = DeserializeRequest(mockTransport.SingleRequest);
            IEnumerator<CloudEvent> cloudEnum = eventsList.GetEnumerator();
            foreach (CloudEvent cloudEvent in cloudEvents)
            {
                cloudEnum.MoveNext();
                IDictionary<string, object> cloudEventAttr = cloudEnum.Current.GetAttributes();
                if (cloudEventAttr.ContainsKey(TraceParentHeaderName) &&
                    cloudEventAttr.ContainsKey(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                        cloudEventAttr[TraceParentHeaderName],
                        cloudEvent.GetAttributes()[TraceParentHeaderName]);

                    Assert.AreEqual(
                        cloudEventAttr[TraceStateHeaderName],
                        cloudEvent.GetAttributes()[TraceStateHeaderName]);
                }
                else if (cloudEventAttr.ContainsKey(TraceParentHeaderName))
                {
                    Assert.AreEqual(
                        cloudEventAttr[TraceParentHeaderName],
                        cloudEvent.GetAttributes()[TraceParentHeaderName]);
                }
                else if (cloudEventAttr.ContainsKey(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                       cloudEventAttr[TraceStateHeaderName],
                       cloudEvent.GetAttributes()[TraceStateHeaderName]);
                }
                else
                {
                    Assert.AreEqual(
                       activity.Id,
                       cloudEvent.GetAttributes()[TraceParentHeaderName]);
                }
            }
        }

        private static List<CloudEvent> DeserializeRequest(Request request)
        {
            var content = request.Content;
            var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;
            JsonDocument requestDocument = JsonDocument.Parse(stream);
            var cloudEvents = new List<CloudEvent>();

            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                var bytes = JsonSerializer.SerializeToUtf8Bytes(property, typeof(JsonElement));
                cloudEvents.Add(s_eventFormatter.DecodeStructuredEvent(bytes));
            }

            return cloudEvents;
        }
    }
}
