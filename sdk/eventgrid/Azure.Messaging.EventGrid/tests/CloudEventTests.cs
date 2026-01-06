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
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
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
            MockTransport mockTransport = CreateMockTransport();

            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("http://localHost"),
                   new AzureKeyCredential("fakeKey"),
                   options);

            using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."), asyncLocal: true);

            // simulating some other activity already being started before doing operations with the client
            var activity = new Activity("ParentEvent");
            activity.SetIdFormat(ActivityIdFormat.W3C);
            activity.Start();
            activity.TraceStateString = "tracestatevalue";
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

            // stop activity after extracting the events from the request as this is where the cloudEvents would actually
            // be serialized
            activity.Stop();

            IEnumerator<CloudEvent> cloudEnum = eventsList.GetEnumerator();
            for (int i = 0; i < 10; i++)
            {
                cloudEnum.MoveNext();
                IDictionary<string, object> cloudEventAttr = cloudEnum.Current.ExtensionAttributes;
                if (inclTraceparent && inclTracestate && i % 2 == 0)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(
                                            cloudEventAttr[TraceParentHeaderName],
                                            Is.EqualTo("traceparentValue"));

                        Assert.That(
                            cloudEventAttr[TraceStateHeaderName],
                            Is.EqualTo("param:value"));
                    });
                }
                else if (inclTraceparent && i % 2 == 0)
                {
                    Assert.That(
                        cloudEventAttr[TraceParentHeaderName],
                        Is.EqualTo("traceparentValue"));
                }
                else if (inclTracestate && i % 2 == 0)
                {
                    Assert.That(
                       cloudEventAttr[TraceStateHeaderName],
                       Is.EqualTo("param:value"));
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(mockTransport.SingleRequest.Headers.TryGetValue(TraceParentHeaderName, out string requestHeader), Is.True);

                        Assert.That(
                            cloudEventAttr[TraceParentHeaderName],
                            Is.EqualTo(requestHeader));
                    });
                }
            }
        }

        [Test]
        public async Task DoesNotSetTraceParentExtensionWhenTracingIsDisabled()
        {
            MockTransport mockTransport = CreateMockTransport();

            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };

            options.Diagnostics.IsDistributedTracingEnabled = false;

            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("http://localHost"),
                   new AzureKeyCredential("fakeKey"),
                   options);

            using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."), asyncLocal: true);

            // simulating some other activity already being started before doing operations with the client
            var activity = new Activity("ParentEvent");
            activity.SetIdFormat(ActivityIdFormat.W3C);
            activity.Start();

            CloudEvent cloudEvent = new CloudEvent(
                "record",
                "Microsoft.MockPublisher.TestEvent",
                JsonDocument.Parse("{\"property1\": \"abc\",  \"property2\": 123}").RootElement);

            await client.SendEventAsync(cloudEvent);
            activity.Stop();

            Assert.Multiple(() =>
            {
                Assert.That(cloudEvent.ExtensionAttributes.ContainsKey("traceparent"), Is.False);
                Assert.That(cloudEvent.ExtensionAttributes.ContainsKey("tracestate"), Is.False);
            });
        }

        private static MockTransport CreateMockTransport()
        {
            return new MockTransport((request) =>
            {
                var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                return new MockResponse(200);
            });
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task SetsTraceParentExtensionRetries(bool inclTraceparent, bool inclTracestate)
        {
            int requestCt = 0;
            var mockTransport = new MockTransport((request) =>
            {
                var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                if (requestCt++ == 0)
                {
                    return new MockResponse(500);
                }
                else
                {
                    return new MockResponse(200);
                }
            });

            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("http://localHost"),
                   new AzureKeyCredential("fakeKey"),
                   options);
            using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."), asyncLocal: true);

            // simulating some other activity already being started before doing operations with the client
            var activity = new Activity("ParentEvent");
            activity.SetIdFormat(ActivityIdFormat.W3C);
            activity.Start();
            activity.TraceStateString = "tracestatevalue";
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

            // stop activity after extracting the events from the request as this is where the cloudEvents would actually
            // be serialized
            activity.Stop();

            IEnumerator<CloudEvent> cloudEnum = eventsList.GetEnumerator();
            for (int i = 0; i < 10; i++)
            {
                cloudEnum.MoveNext();
                IDictionary<string, object> cloudEventAttr = cloudEnum.Current.ExtensionAttributes;
                if (inclTraceparent && inclTracestate && i % 2 == 0)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(
                                            cloudEventAttr[TraceParentHeaderName],
                                            Is.EqualTo("traceparentValue"));

                        Assert.That(
                            cloudEventAttr[TraceStateHeaderName],
                            Is.EqualTo("param:value"));
                    });
                }
                else if (inclTraceparent && i % 2 == 0)
                {
                    Assert.That(
                        cloudEventAttr[TraceParentHeaderName],
                        Is.EqualTo("traceparentValue"));
                }
                else if (inclTracestate && i % 2 == 0)
                {
                    Assert.That(
                       cloudEventAttr[TraceStateHeaderName],
                       Is.EqualTo("param:value"));
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(mockTransport.Requests[1].Headers.TryGetValue(TraceParentHeaderName, out string traceParent), Is.True);
                        Assert.That(
                            cloudEventAttr[TraceParentHeaderName],
                            Is.EqualTo(traceParent));

                        Assert.That(mockTransport.Requests[1].Headers.TryGetValue(TraceStateHeaderName, out string traceState), Is.True);
                        Assert.That(
                            cloudEventAttr[TraceStateHeaderName],
                            Is.EqualTo(traceState));
                    });
                }
            }
        }

        [Test]
        public async Task SerializesExpectedProperties_BaseType()
        {
            var mockTransport = CreateMockTransport();
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
                    typeof(TestPayload));

            Assert.That(cloudEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty, Is.Null);

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);

            Assert.That(cloudEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty, Is.Null);
        }

        [Test]
        public async Task SerializesExpectedProperties_DerivedType()
        {
            var mockTransport = CreateMockTransport();
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
                    });

            Assert.That(cloudEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty, Is.EqualTo(5));

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);

            Assert.That(cloudEvent.Data.ToObjectFromJson<DerivedTestPayload>().DerivedProperty, Is.EqualTo(5));
        }

        [Test]
        public async Task RespectsPortFromUriSendingCloudEvents()
        {
            var mockTransport = new MockTransport((request) =>
            {
                Assert.That(request.Uri.Port, Is.EqualTo(100));
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
            var cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    new TestPayload
                    {
                        Name = "name",
                        Age = 10,
                    });

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);
        }

        [Test]
        public async Task DoesNotSetCredentialForSystemPublisher()
        {
            var mockTransport = new MockTransport((request) =>
            {
                Assert.That(request.Headers.TryGetValue(Constants.SasKeyName, out var _), Is.False);
                return new MockResponse(200);
            });
            var options = new EventGridPublisherClientOptions
            {
                Transport = mockTransport
            };
            EventGridPublisherClient client =
               new EventGridPublisherClient(
                   new Uri("https://contoso.com:100/api/events"),
                   new AzureKeyCredential(EventGridKeyCredentialPolicy.SystemPublisherKey),
                   options);
            var cloudEvent = new CloudEvent(
                    "record",
                    "Microsoft.MockPublisher.TestEvent",
                    null);

            List<CloudEvent> eventsList = new List<CloudEvent>()
            {
                cloudEvent
            };

            await client.SendEventsAsync(eventsList);
        }
    }
}
