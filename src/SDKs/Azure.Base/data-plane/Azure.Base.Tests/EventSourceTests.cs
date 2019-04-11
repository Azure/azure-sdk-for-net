// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.Tracing;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;
using Azure.Base.Pipeline;
using Azure.Base.Pipeline.Policies;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests : PipelineTestBase
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
            var handler = new MockHttpClientHandler(httpRequestMessage =>
            {
                var response = new HttpResponseMessage((HttpStatusCode)500);
                response.Content = new ByteArrayContent(new byte[] { 6, 7, 8, 9, 0 });
                response.Headers.Add("Custom-Response-Header", "Improved value");
                return Task.FromResult(response);
            });
            var transport = new HttpClientTransport(new HttpClient(handler));
            var pipeline = new HttpPipeline(transport, new []{ LoggingPolicy.Shared });
            string requestId;

            using (var request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
                request.AddHeader("Date", "3/26/2019");
                request.AddHeader("Custom-Header", "Value");
                request.Content = HttpPipelineRequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.RequestId;

                var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

                Assert.AreEqual(500, response.Status);
            }

            var e = _listener.SingleEventById(1);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("Request", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual("https://contoso.a.io/", e.GetProperty<string>("uri"));
            Assert.AreEqual("GET", e.GetProperty<string>("method"));
            StringAssert.Contains($"Date:3/26/2019{Environment.NewLine}", e.GetProperty<string>("headers"));
            StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(2);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("RequestContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, e.GetProperty<byte[]>("content"));

            e = _listener.SingleEventById(5);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("Response", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual(e.GetProperty<int>("status"), 500);
            StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(6);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("ResponseContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8, 9, 0 }, e.GetProperty<byte[]>("content"));

            e = _listener.SingleEventById(8);
            Assert.AreEqual(EventLevel.Error, e.Level);
            Assert.AreEqual("ErrorResponse", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual(e.GetProperty<int>("status"), 500);
            StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(9);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("ErrorResponseContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8, 9, 0 }, e.GetProperty<byte[]>("content"));
        }
    }
}
