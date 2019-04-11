// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
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
            var response = new MockResponse(500);
            response.SetContent(new byte[] { 6, 7, 8, 9, 0 });
            response.AddHeader(new HttpHeader("Custom-Response-Header", "Improved value"));

            var mockTransport = new MockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new []{ LoggingPolicy.Shared });
            string requestId;

            using (var request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
                request.AddHeader("Date", "3/26/2019");
                request.AddHeader("Custom-Header", "Value");
                request.Content = HttpPipelineRequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.RequestId;

                await pipeline.SendRequestAsync(request, CancellationToken.None);
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

        [Test]
        public async Task NonSeekableResponsesAreLoggedInBlocks()
        {
            var mockResponse = new MockResponse(500);
            mockResponse.ResponseContentStream = new NonSeekableMemoryStream(new byte[] { 6, 7, 8, 9, 0 });
            var mockTransport = new MockTransport(mockResponse);

            var pipeline = new HttpPipeline(mockTransport, new []{ LoggingPolicy.Shared });
            string requestId;
            var buffer = new byte[10];

            using (var request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
                request.Content = HttpPipelineRequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.RequestId;

                var response = await pipeline.SendRequestAsync(request, CancellationToken.None);


                Assert.AreEqual(3, await response.ContentStream.ReadAsync(buffer, 5, 3));
                Assert.AreEqual(2, await response.ContentStream.ReadAsync(buffer, 8, 2));
                Assert.AreEqual(0, await response.ContentStream.ReadAsync(buffer, 0, 5));
            }

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(11).ToArray();

            Assert.AreEqual(2, contentEvents.Length);

            Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
            Assert.AreEqual("ResponseContentBlock",  contentEvents[0].EventName);
            Assert.AreEqual(requestId,  contentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8 }, contentEvents[0].GetProperty<byte[]>("content"));

            Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
            Assert.AreEqual("ResponseContentBlock",  contentEvents[1].EventName);
            Assert.AreEqual(requestId,  contentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 9, 0 }, contentEvents[1].GetProperty<byte[]>("content"));

            EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(12).ToArray();

            Assert.AreEqual(2, errorContentEvents.Length);

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
            Assert.AreEqual("ErrorResponseContentBlock",  errorContentEvents[0].EventName);
            Assert.AreEqual(requestId,  errorContentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8 }, errorContentEvents[0].GetProperty<byte[]>("content"));

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
            Assert.AreEqual("ErrorResponseContentBlock",  errorContentEvents[1].EventName);
            Assert.AreEqual(requestId,  errorContentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 9, 0 }, errorContentEvents[1].GetProperty<byte[]>("content"));

            // No ResponseContent and ErrorResponseContent events
            CollectionAssert.IsEmpty(_listener.EventsById(6));
            CollectionAssert.IsEmpty(_listener.EventsById(9));
        }

        private class NonSeekableMemoryStream: MemoryStream
        {
            public NonSeekableMemoryStream(byte[] buffer): base(buffer)
            {
            }

            public override bool CanSeek => false;
        }
    }
}
