// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests
    {
        private readonly TestEventListener _listener = new TestEventListener();

        public EventSourceTests()
        {
            _listener.EnableEvents(HttpPipelineEventSource.Singleton, EventLevel.Verbose);
        }

        [Test]
        public void MatchesNameAndGuid()
        {
            // Arrange & Act
            var eventSourceType = typeof(HttpPipelineEventSource);

            // Assert
            Assert.NotNull(eventSourceType);
            Assert.AreEqual("AzureSDK", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("1015ab6c-4cd8-53d6-aec3-9b937011fa95"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }

        [Test]
        public async Task SendingRequestProducesEvents()
        {
            var options = new HttpPipelineOptions(new HttpClientTransport(new HttpClient(new MockHttpMessageHandler())));
            options.LoggingPolicy = LoggingPolicy.Shared;

            var pipeline = options.Build("test", "1.0.0");

            using (var message = pipeline.CreateMessage(cancellation: default))
            {
                message.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
                await pipeline.SendMessageAsync(message);

                Assert.AreEqual(500, message.Response.Status);
            }

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 3 &&
                e.EventName == "ProcessingRequest" &&
                GetStringProperty(e, "request").Contains("https://contoso.a.io")));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 4 &&
                e.EventName == "ProcessingResponse" &&
                GetStringProperty(e, "response").Contains("500")));

            Assert.True(_listener.EventData.Any(e =>
                e.EventId == 6 &&
                e.EventName == "ErrorResponse" &&
                (int)GetProperty(e, "status") == 500));
        }

        private object GetProperty(EventWrittenEventArgs data, string propName)
            => data.Payload[data.PayloadNames.IndexOf(propName)];

        private string GetStringProperty(EventWrittenEventArgs data, string propName)
            => data.Payload[data.PayloadNames.IndexOf(propName)] as string;

        private class MockHttpMessageHandler: HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}