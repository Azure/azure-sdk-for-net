// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class EventSourceTests : SyncAsyncPolicyTestBase
    {
        private const int BackgroundRefreshFailedEvent = 19;
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
        private const int ExceptionResponseEvent = 18;

        private TestEventListener _listener;

        private static string[] s_allowedHeaders = new[] { "Date", "Custom-Header", "Custom-Response-Header" };
        private static string[] s_allowedQueryParameters = new[] { "api-version" };
        private static HttpMessageSanitizer _sanitizer = new HttpMessageSanitizer(s_allowedQueryParameters, s_allowedHeaders);

        public EventSourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);
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
            Type eventSourceType = typeof(AzureCoreEventSource);

            // Assert
            Assert.That(eventSourceType, Is.Not.Null);
            Assert.That(EventSource.GetName(eventSourceType), Is.EqualTo("Azure-Core"));
            Assert.That(EventSource.GetGuid(eventSourceType), Is.EqualTo(Guid.Parse("44cbc7c6-6776-5f3c-36c1-75cd3ef19ea9")));
            Assert.That(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"), Is.Not.Empty);
        }

        [Test]
        public async Task SendingRequestProducesEvents()
        {
            var response = new MockResponse(200);
            response.SetContent(new byte[] { 6, 7, 8, 9, 0 });
            response.AddHeader(new HttpHeader("Custom-Response-Header", "Improved value"));

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, int.MaxValue, _sanitizer, "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io/api-version=5"));
                request.Headers.Add("Date", "3/26/2019");
                request.Headers.Add("Custom-Header", "Value");
                request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(RequestEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Request"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("uri"), Is.EqualTo("https://contoso.a.io/api-version=5"));
            Assert.That(e.GetProperty<string>("method"), Is.EqualTo("GET"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Date:3/26/2019{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Header:Value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("clientAssembly"), Is.EqualTo("Test-SDK"));

            e = _listener.SingleEventById(RequestContentEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(e.EventName, Is.EqualTo("RequestContent"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<byte[]>("content"), Is.EqualTo(new byte[] { 1, 2, 3, 4, 5 }).AsCollection);

            e = _listener.SingleEventById(ResponseEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Response"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(200));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));

            e = _listener.SingleEventById(ResponseContentEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(e.EventName, Is.EqualTo("ResponseContent"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<byte[]>("content"), Is.EqualTo(new byte[] { 6, 7, 8, 9, 0 }).AsCollection);
        }

        [Test]
        public void GettingExceptionResponseProducesEvents()
        {
            var exception = new InvalidOperationException();
            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                throw exception;
            });

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, int.MaxValue, _sanitizer, "Test-SDK") });
            string requestId = null;

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("User-Agent", "agent");
                requestId = request.ClientRequestId;
            }));

            EventWrittenEventArgs e = _listener.SingleEventById(ExceptionResponseEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("exception").Split(Environment.NewLine.ToCharArray())[0],
                Is.EqualTo(exception.ToString().Split(Environment.NewLine.ToCharArray())[0]));
        }

        [Test]
        public async Task FailingAccessTokenBackgroundRefreshProducesEvents()
        {
            var credentialMre = new ManualResetEventSlim(true);

            var currentTime = DateTimeOffset.UtcNow;
            var callCount = 0;
            var exception = new InvalidOperationException();

            var credential = new TokenCredentialStub((r, c) =>
            {
                callCount++;
                credentialMre.Set();
                return callCount == 1 ? new AccessToken(Guid.NewGuid().ToString(), currentTime.AddMinutes(2)) : throw exception;
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport mockTransport = CreateMockTransport(r =>
            {
                credentialMre.Wait();
                return new MockResponse(200);
            });

            var pipeline = new HttpPipeline(mockTransport, new HttpPipelinePolicy[] { policy, new LoggingPolicy(logContent: true, int.MaxValue, _sanitizer, "Test-SDK") });
            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://example.com/1"));
                request.Headers.Add("User-Agent", "agent");
            });

            credentialMre.Reset();
            string requestId = null;
            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://example.com/2"));
                request.Headers.Add("User-Agent", "agent");
                requestId = request.ClientRequestId;
            });

            await Task.Delay(1_000);

            EventWrittenEventArgs e = _listener.SingleEventById(BackgroundRefreshFailedEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("exception").Split(Environment.NewLine.ToCharArray())[0], Is.EqualTo(exception.ToString().Split(Environment.NewLine.ToCharArray())[0]));
        }

        [Test]
        public async Task GettingErrorResponseProducesEvents()
        {
            var response = new MockResponse(500);
            response.SetContent(new byte[] { 6, 7, 8, 9, 0 });
            response.AddHeader(new HttpHeader("Custom-Response-Header", "Improved value"));

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, int.MaxValue, _sanitizer, "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Headers.Add("Date", "3/26/2019");
                request.Headers.Add("Custom-Header", "Value");
                request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(ErrorResponseEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Warning));
            Assert.That(e.EventName, Is.EqualTo("ErrorResponse"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(500));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));

            e = _listener.SingleEventById(ErrorResponseContentEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("ErrorResponseContent"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            CollectionAssert.AreEqual(new byte[] { 6, 7, 8, 9, 0 }, e.GetProperty<byte[]>("content"));
        }

        [Test]
        public async Task RequestContentIsLoggedAsText()
        {
            var response = new MockResponse(500);
            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, int.MaxValue, _sanitizer, "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
                request.Headers.Add("Content-Type", "text/json");
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(RequestContentTextEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(e.EventName, Is.EqualTo("RequestContentText"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("content"), Is.EqualTo("Hello world"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task ContentIsNotLoggedAsTextWhenDisabled()
        {
            var response = new MockResponse(500);
            response.ContentStream = new MemoryStream(new byte[] { 1, 2, 3 });
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: false, int.MaxValue, _sanitizer, "Test-SDK") });

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
                request.Headers.Add("Content-Type", "text/json");
            });

            AssertNoContentLogged();
        }

        [Test]
        public async Task ContentIsNotLoggedWhenDisabled()
        {
            var response = new MockResponse(500);
            response.ContentStream = new NonSeekableMemoryStream(new byte[] { 1, 2, 3 });

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: false, int.MaxValue, _sanitizer, "Test-SDK") });

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
            });

            AssertNoContentLogged();
        }

        [Test]
        public async Task RequestContentIsNotLoggedWhenDisabled()
        {
            var response = new MockResponse(500);
            response.ContentStream = new MemoryStream(new byte[] { 1, 2, 3 });

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: false, int.MaxValue, _sanitizer, "Test-SDK") });

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
            });

            AssertNoContentLogged();
        }

        private void AssertNoContentLogged()
        {
            CollectionAssert.IsEmpty(_listener.EventsById(RequestContentEvent));
            CollectionAssert.IsEmpty(_listener.EventsById(RequestContentTextEvent));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentBlockEvent));
            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentTextBlockEvent));

            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentTextEvent));
            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentTextBlockEvent));
        }

        [Test]
        public async Task NonSeekableResponsesAreLoggedInBlocks()
        {
            Response response = await SendRequest(isSeekable: false, isError: false);

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentBlockEvent).ToArray();

            Assert.That(contentEvents.Length, Is.EqualTo(2));

            Assert.That(contentEvents[0].Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvents[0].EventName, Is.EqualTo("ResponseContentBlock"));
            Assert.That(contentEvents[0].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
            CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetProperty<byte[]>("content"));

            Assert.That(contentEvents[1].Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvents[1].EventName, Is.EqualTo("ResponseContentBlock"));
            Assert.That(contentEvents[1].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
            CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetProperty<byte[]>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesErrorsAreLoggedInBlocks()
        {
            Response response = await SendRequest(isSeekable: false, isError: true);

            EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentBlockEvent).ToArray();

            Assert.That(errorContentEvents.Length, Is.EqualTo(2));

            Assert.That(errorContentEvents[0].Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(errorContentEvents[0].EventName, Is.EqualTo("ErrorResponseContentBlock"));
            Assert.That(errorContentEvents[0].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(errorContentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
            CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetProperty<byte[]>("content"));

            Assert.That(errorContentEvents[1].Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(errorContentEvents[1].EventName, Is.EqualTo("ErrorResponseContentBlock"));
            Assert.That(errorContentEvents[1].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(errorContentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
            CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetProperty<byte[]>("content"));

            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesAreLoggedInTextBlocks()
        {
            Response response = await SendRequest(
                isSeekable: false,
                isError: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentTextBlockEvent).ToArray();

            Assert.That(contentEvents.Length, Is.EqualTo(2));

            Assert.That(contentEvents[0].Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvents[0].EventName, Is.EqualTo("ResponseContentTextBlock"));
            Assert.That(contentEvents[0].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
            Assert.That(contentEvents[0].GetProperty<string>("content"), Is.EqualTo("Hello "));

            Assert.That(contentEvents[1].Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvents[1].EventName, Is.EqualTo("ResponseContentTextBlock"));
            Assert.That(contentEvents[1].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
            Assert.That(contentEvents[1].GetProperty<string>("content"), Is.EqualTo("world"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks()
        {
            Response response = await SendRequest(
                isSeekable: false,
                isError: true,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentTextBlockEvent).ToArray();

            Assert.That(errorContentEvents.Length, Is.EqualTo(2));

            Assert.That(errorContentEvents[0].Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(errorContentEvents[0].EventName, Is.EqualTo("ErrorResponseContentTextBlock"));
            Assert.That(errorContentEvents[0].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(errorContentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
            Assert.That(errorContentEvents[0].GetProperty<string>("content"), Is.EqualTo("Hello "));

            Assert.That(errorContentEvents[1].Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(errorContentEvents[1].EventName, Is.EqualTo("ErrorResponseContentTextBlock"));
            Assert.That(errorContentEvents[1].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(errorContentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
            Assert.That(errorContentEvents[1].GetProperty<string>("content"), Is.EqualTo("world"));

            CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
        }

        [Test]
        public async Task SeekableTextResponsesAreLoggedInText()
        {
            Response response = await SendRequest(
                isSeekable: true,
                isError: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"))
            );

            EventWrittenEventArgs contentEvent = _listener.SingleEventById(ResponseContentTextEvent);

            Assert.That(contentEvent.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvent.EventName, Is.EqualTo("ResponseContentText"));
            Assert.That(contentEvent.GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvent.GetProperty<string>("content"), Is.EqualTo("Hello world"));
        }

        [Test]
        public async Task SeekableTextResponsesErrorsAreLoggedInText()
        {
            Response response = await SendRequest(
                isSeekable: true,
                isError: true,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml")),
                maxLength: 5
            );

            EventWrittenEventArgs errorContentEvent = _listener.SingleEventById(ErrorResponseContentTextEvent);

            Assert.That(errorContentEvent.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(errorContentEvent.EventName, Is.EqualTo("ErrorResponseContentText"));
            Assert.That(errorContentEvent.GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(errorContentEvent.GetProperty<string>("content"), Is.EqualTo("Hello"));
        }

        [Test]
        public async Task SeekableTextResponsesAreLimitedInLength()
        {
            Response response = await SendRequest(
                isSeekable: true,
                isError: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml")),
                maxLength: 5
            );

            EventWrittenEventArgs contentEvent = _listener.SingleEventById(ResponseContentTextEvent);

            Assert.That(contentEvent.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvent.EventName, Is.EqualTo("ResponseContentText"));
            Assert.That(contentEvent.GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvent.GetProperty<string>("content"), Is.EqualTo("Hello"));
        }

        [Test]
        public async Task RequestContentLogsAreLimitedInLength()
        {
            var response = new MockResponse(500);
            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, 5, _sanitizer, "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
                request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("Hello world"));
                request.Headers.Add("Content-Type", "text/json");
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(RequestContentTextEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(e.EventName, Is.EqualTo("RequestContentText"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("content"), Is.EqualTo("Hello"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task NonSeekableResponsesAreLimitedInLength()
        {
            Response response = await SendRequest(
                isSeekable: false,
                isError: false,
                mockResponse => mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml")),
                maxLength: 5
            );

            EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentTextBlockEvent).ToArray();

            Assert.That(contentEvents.Length, Is.EqualTo(1));

            Assert.That(contentEvents[0].Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(contentEvents[0].EventName, Is.EqualTo("ResponseContentTextBlock"));
            Assert.That(contentEvents[0].GetProperty<string>("requestId"), Is.EqualTo(response.ClientRequestId));
            Assert.That(contentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
            Assert.That(contentEvents[0].GetProperty<string>("content"), Is.EqualTo("Hello"));

            CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
        }

        [Test]
        public async Task HeadersAndQueryParametersAreSanitized()
        {
            var response = new MockResponse(200);
            response.SetContent(new byte[] { 6, 7, 8, 9, 0 });
            response.AddHeader(new HttpHeader("Custom-Response-Header", "Improved value"));
            response.AddHeader(new HttpHeader("Secret-Response-Header", "Very secret"));

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: false, int.MaxValue, _sanitizer, "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io?api-version=5&secret=123"));
                request.Headers.Add("Date", "3/26/2019");
                request.Headers.Add("Custom-Header", "Value");
                request.Headers.Add("Secret-Custom-Header", "Value");
                request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(RequestEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Request"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("uri"), Is.EqualTo("https://contoso.a.io/?api-version=5&secret=REDACTED"));
            Assert.That(e.GetProperty<string>("method"), Is.EqualTo("GET"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Date:3/26/2019{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Header:Value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Secret-Custom-Header:REDACTED{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("clientAssembly"), Is.EqualTo("Test-SDK"));

            e = _listener.SingleEventById(ResponseEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Response"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(200));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Secret-Response-Header:REDACTED{Environment.NewLine}"));
        }

        [Test]
        public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
        {
            var response = new MockResponse(200);
            response.SetContent(new byte[] { 6, 7, 8, 9, 0 });
            response.AddHeader(new HttpHeader("Custom-Response-Header", "Improved value"));
            response.AddHeader(new HttpHeader("Secret-Response-Header", "Very secret"));

            MockTransport mockTransport = CreateMockTransport(response);

            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: false, int.MaxValue, new HttpMessageSanitizer(new[] { "*" }, new[] { "*" }), "Test-SDK") });
            string requestId = null;

            await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io?api-version=5&secret=123"));
                request.Headers.Add("Date", "3/26/2019");
                request.Headers.Add("Custom-Header", "Value");
                request.Headers.Add("Secret-Custom-Header", "Value");
                request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                requestId = request.ClientRequestId;
            });

            EventWrittenEventArgs e = _listener.SingleEventById(RequestEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Request"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<string>("uri"), Is.EqualTo("https://contoso.a.io/?api-version=5&secret=123"));
            Assert.That(e.GetProperty<string>("method"), Is.EqualTo("GET"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Date:3/26/2019{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Header:Value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Secret-Custom-Header:Value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("clientAssembly"), Is.EqualTo("Test-SDK"));

            e = _listener.SingleEventById(ResponseEvent);
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.EventName, Is.EqualTo("Response"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(requestId));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(200));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
            Assert.That(e.GetProperty<string>("headers"), Does.Contain($"Secret-Response-Header:Very secret{Environment.NewLine}"));
        }

        private async Task<Response> SendRequest(bool isSeekable, bool isError, Action<MockResponse> setupRequest = null, int maxLength = int.MaxValue)
        {
            var mockResponse = new MockResponse(isError ? 500 : 200);
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

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, maxLength, _sanitizer, "Test-SDK") });

            Response response = await SendRequestAsync(pipeline, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://contoso.a.io"));
            },
            // These tests are essentially testing whether the logging policy works
            // correctly when responses are buffered (memory stream) and unbuffered
            // (non-seekable). In order to validate the intent of the test, we set
            // message.BufferResponse accordingly here.
            bufferResponse: isSeekable);

            var buffer = new byte[11];

            if (IsAsync)
            {
                Assert.That(await response.ContentStream.ReadAsync(buffer, 5, 6), Is.EqualTo(6));
                Assert.That(await response.ContentStream.ReadAsync(buffer, 6, 5), Is.EqualTo(5));
                Assert.That(await response.ContentStream.ReadAsync(buffer, 0, 5), Is.EqualTo(0));
            }
            else
            {
                Assert.That(response.ContentStream.Read(buffer, 5, 6), Is.EqualTo(6));
                Assert.That(response.ContentStream.Read(buffer, 6, 5), Is.EqualTo(5));
                Assert.That(response.ContentStream.Read(buffer, 0, 5), Is.EqualTo(0));
            }

            return mockResponse;
        }

        private class TokenCredentialStub : TokenCredential
        {
            public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
            {
                if (isAsync)
                {
#pragma warning disable 1998
                    _getTokenAsyncHandler = async (r, c) => handler(r, c);
#pragma warning restore 1998
                }
                else
                {
                    _getTokenHandler = handler;
                }
            }

            private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(requestContext, cancellationToken);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(requestContext, cancellationToken);
        }
    }
}
