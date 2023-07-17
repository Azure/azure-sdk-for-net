// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.SystemTextJson;
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
            activity.SetIdFormat(ActivityIdFormat.W3C);
            activity.Start();
            List<CloudEvent> inputEvents = new List<CloudEvent>();
            for (int i = 0; i < 10; i++)
            {
                var cloudEvent =
                    new CloudEvent
                    {
                        Subject = "record",
                        Source = new Uri("http://localHost"),
                        Id = Guid.NewGuid().ToString(),
                        Time = DateTime.Now,
                        Type = "test"
                    };

                if (inclTraceparent && inclTracestate && i % 2 == 0)
                {
                    cloudEvent.SetAttributeFromString("traceparent", "traceparentValue");
                }
                if (inclTracestate && i % 2 == 0)
                {
                    cloudEvent.SetAttributeFromString("tracestate", "param:value");
                }
                inputEvents.Add(cloudEvent);
            }
            await client.SendCloudNativeCloudEventsAsync(inputEvents);

            activity.Stop();
            List<CloudEvent> endEvents = DeserializeRequest(mockTransport.SingleRequest);
            IEnumerator<CloudEvent> inputEnum = inputEvents.GetEnumerator();
            foreach (CloudEvent cloudEvent in endEvents)
            {
                inputEnum.MoveNext();
                var inputAttributes = inputEnum.Current.GetPopulatedAttributes().Select(pair => pair.Key.Name).ToList();
                if (inputAttributes.Contains(TraceParentHeaderName) &&
                    inputAttributes.Contains(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                        inputEnum.Current[TraceParentHeaderName],
                        cloudEvent[TraceParentHeaderName]);

                    Assert.AreEqual(
                        inputEnum.Current[TraceStateHeaderName],
                        cloudEvent[TraceStateHeaderName]);
                }
                else if (inputAttributes.Contains(TraceParentHeaderName))
                {
                    Assert.AreEqual(
                        inputEnum.Current[TraceParentHeaderName],
                        cloudEvent[TraceParentHeaderName]);
                }
                else if (inputAttributes.Contains(TraceStateHeaderName))
                {
                    Assert.AreEqual(
                        inputEnum.Current[TraceStateHeaderName],
                       cloudEvent[TraceStateHeaderName]);
                }
                else
                {
                    Assert.AreEqual(
                       activity.Id,
                       cloudEvent[TraceParentHeaderName]);
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
                cloudEvents.Add(s_eventFormatter.DecodeStructuredModeMessage(bytes, new System.Net.Mime.ContentType("application/json"), null));
            }

            return cloudEvents;
        }
    }
}
