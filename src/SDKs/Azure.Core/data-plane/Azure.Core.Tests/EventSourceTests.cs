// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests
    {
        private const int RequestEvent = 1;
        private const int RequestContentEvent = 2;
        private const int RequestContentTextEvent = 17;
        private const int ResponseEvent = 5;
        private const int ResponseContentEvent = 6;
        private const int ResponseContentBlockEvent = 11;
        private const int ErrorResponseEvent = 8;
        private const int ErrorResponseContentEvent = 9;
        private const int ErrorResponseContentBlockEvent = 12;
        private const int ResponseContentTextEvent = 13;
        private const int ResponseContentTextBlockEvent = 15;
        private const int ErrorResponseContentTextEvent = 14;
        private const int ErrorResponseContentTextBlockEvent = 16;

        private TestEventListener _listener;

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(HttpPipelineEventSource.Singleton, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
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

            using (Request request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
                request.AddHeader("Date", "3/26/2019");
                request.AddHeader("Custom-Header", "Value");
                request.Content = HttpPipelineRequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.RequestId;

                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            var e = _listener.SingleEventById(RequestEvent);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("Request", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual("https://contoso.a.io/", e.GetProperty<string>("uri"));
            Assert.AreEqual("GET", e.GetProperty<string>("method"));
            StringAssert.Contains($"Date:3/26/2019{Environment.NewLine}", e.GetProperty<string>("headers"));
            StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(RequestContentEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("RequestContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, e.GetProperty<byte[]>("content"));

            e = _listener.SingleEventById(ResponseEvent);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("Response", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual(e.GetProperty<int>("status"), 500);
            StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(ResponseContentEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("ResponseContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8, 9, 0 }, e.GetProperty<byte[]>("content"));

            e = _listener.SingleEventById(ErrorResponseEvent);
            Assert.AreEqual(EventLevel.Error, e.Level);
            Assert.AreEqual("ErrorResponse", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual(e.GetProperty<int>("status"), 500);
            StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));

            e = _listener.SingleEventById(ErrorResponseContentEvent);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("ErrorResponseContent", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8, 9, 0 }, e.GetProperty<byte[]>("content"));
        }

        [Test]
        public async Task RequestContentIsLoggedAsText()
        {
            var response = new MockResponse(500);
            var mockTransport = new MockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new []{ LoggingPolicy.Shared });
            string requestId;

            using (Request request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
                request.Content = HttpPipelineRequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
                request.Headers.Add("Content-Type", "text/json");
                requestId = request.RequestId;

                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            var e = _listener.SingleEventById(RequestContentTextEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("RequestContentText", e.EventName);
            Assert.AreEqual(requestId, e.GetProperty<string>("requestId"));
            Assert.AreEqual("Hello world", e.GetProperty<string>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesAreLoggedInBlocks()
        {
            Response response = await SendRequest(isSeekable: false);

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentBlockEvent).ToArray();

            Assert.AreEqual(2, contentEvents.Length);

            Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
            Assert.AreEqual("ResponseContentBlock",  contentEvents[0].EventName);
            Assert.AreEqual(response.RequestId,  contentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetProperty<byte[]>("content"));

            Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
            Assert.AreEqual("ResponseContentBlock",  contentEvents[1].EventName);
            Assert.AreEqual(response.RequestId,  contentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetProperty<byte[]>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesErrorsAreLoggedInBlocks()
        {
            Response response = await SendRequest(isSeekable: false);

            EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentBlockEvent).ToArray();

            Assert.AreEqual(2, errorContentEvents.Length);

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
            Assert.AreEqual("ErrorResponseContentBlock",  errorContentEvents[0].EventName);
            Assert.AreEqual(response.RequestId,  errorContentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetProperty<byte[]>("content"));

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
            Assert.AreEqual("ErrorResponseContentBlock",  errorContentEvents[1].EventName);
            Assert.AreEqual(response.RequestId,  errorContentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
            CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetProperty<byte[]>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesAreLoggedInTextBlocks()
        {
            Response response = await SendRequest(
                isSeekable: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentTextBlockEvent).ToArray();

            Assert.AreEqual(2, contentEvents.Length);

            Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
            Assert.AreEqual("ResponseContentTextBlock",  contentEvents[0].EventName);
            Assert.AreEqual(response.RequestId,  contentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
            Assert.AreEqual("Hello ", contentEvents[0].GetProperty<string>("content"));

            Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
            Assert.AreEqual("ResponseContentTextBlock",  contentEvents[1].EventName);
            Assert.AreEqual(response.RequestId,  contentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
            Assert.AreEqual("world", contentEvents[1].GetProperty<string>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks()
        {
            Response response = await SendRequest(
                isSeekable: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentTextBlockEvent).ToArray();

            Assert.AreEqual(2, errorContentEvents.Length);

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
            Assert.AreEqual("ErrorResponseContentTextBlock",  errorContentEvents[0].EventName);
            Assert.AreEqual(response.RequestId,  errorContentEvents[0].GetProperty<string>("requestId"));
            Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
            Assert.AreEqual("Hello ", errorContentEvents[0].GetProperty<string>("content"));

            Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
            Assert.AreEqual("ErrorResponseContentTextBlock",  errorContentEvents[1].EventName);
            Assert.AreEqual(response.RequestId,  errorContentEvents[1].GetProperty<string>("requestId"));
            Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
            Assert.AreEqual("world", errorContentEvents[1].GetProperty<string>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
        }

        [Test]
        public async Task SeekableTextResponsesAreLoggedInText()
        {
            Response response = await SendRequest(
                isSeekable: true,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs contentEvent = _listener.SingleEventById(ResponseContentTextEvent);

            Assert.AreEqual(EventLevel.Verbose, contentEvent.Level);
            Assert.AreEqual("ResponseContentText",  contentEvent.EventName);
            Assert.AreEqual(response.RequestId,  contentEvent.GetProperty<string>("requestId"));
            Assert.AreEqual("Hello world", contentEvent.GetProperty<string>("content"));
        }

        [Test]
        public async Task SeekableTextResponsesErrorsAreLoggedInText()
        {
            Response response = await SendRequest(
                isSeekable: true,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs errorContentEvent = _listener.SingleEventById(ErrorResponseContentTextEvent);

            Assert.AreEqual(EventLevel.Informational, errorContentEvent.Level);
            Assert.AreEqual("ErrorResponseContentText",  errorContentEvent.EventName);
            Assert.AreEqual(response.RequestId,  errorContentEvent.GetProperty<string>("requestId"));
            Assert.AreEqual("Hello world", errorContentEvent.GetProperty<string>("content"));
        }

        private static async Task<Response> SendRequest(bool isSeekable, Action<MockResponse> setupRequest = null)
        {
            var mockResponse = new MockResponse(500);
            byte[] responseContent = Encoding.UTF8.GetBytes("Hello world");
            if (isSeekable)
            {
                mockResponse.ContentStream = new MemoryStream(responseContent);
            }
            else
            {
                mockResponse.ContentStream = new NonSeekableMemoryStream(responseContent);
            }
            setupRequest?.Invoke(mockResponse);

            var mockTransport = new MockTransport(mockResponse);
            var pipeline = new HttpPipeline(mockTransport, new[] { LoggingPolicy.Shared });

            using (Request request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));

                Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

                var buffer = new byte[11];
                Assert.AreEqual(6, await response.ContentStream.ReadAsync(buffer, 5, 6));
                Assert.AreEqual(5, await response.ContentStream.ReadAsync(buffer, 6, 5));
                Assert.AreEqual(0, await response.ContentStream.ReadAsync(buffer, 0, 5));

                return mockResponse;
            }
        }

        private class NonSeekableMemoryStream: MemoryStream
        {
            public NonSeekableMemoryStream(byte[] buffer): base(buffer)
            {
            }

            public override bool CanSeek => false;

            public override long Seek(long offset, SeekOrigin loc)
            {
                throw new NotImplementedException();
            }

            public override long Position
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }
    }
}
