// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

// Avoid running these tests in parallel with anything else that's sharing the event source
/// <summary>
/// Tests that the format of events written to the Event Source is as expected, and tests
/// that the logging options are respected.
/// </summary>
[NonParallelizable]
public class ClientModelEventSourceTests : SyncAsyncPolicyTestBase
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
    private const int ExceptionResponseEvent = 18;

    // TODO
    private const int ResponseDelayEvent = 7;
    private const int RequestRetryingEvent = 10;

    private TestClientEventListener _listener;

    private const string SystemClientModelEventSourceName = "System-ClientModel";

    public ClientModelEventSourceTests(bool isAsync) : base(isAsync)
    {
        _listener = new TestClientEventListener();
    }

    [SetUp]
    public void Setup()
    {
        // Each test needs its own listener
        _listener = new TestClientEventListener();
    }

    [TearDown]
    public void TearDown()
    {
        _listener?.Dispose();
    }

    [Test]
    public async Task AllDefaultOptionsWorkAsExpected()
    {
        string requestContent = "Hello";
        string responseContent = "World";
        Uri uri = new("http://example.com/Index.htm?q1=v1&q2=v2");

        Dictionary<string, string> headers = new()
        {
            { "Custom-Response-Header", "Value" },
            { "Date", "4/29/2024" },
            { "ETag", "version1" }
        };
        var mockHeaders = new MockResponseHeaders(headers);
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions()
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = uri;
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("ETag", "version1");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(2, _listener.EventData.Count());

        EventWrittenEventArgs args = _listener.SingleEventById(RequestEvent);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("Request", args.EventName);
        Guid requestId = Guid.Parse(args.GetProperty<string>("requestId"));
        Assert.AreEqual("http://example.com/Index.htm?q1=REDACTED&q2=REDACTED", args.GetProperty<string>("uri"));
        Assert.AreEqual("GET", args.GetProperty<string>("method"));
        StringAssert.Contains($"Date:3/28/2024{Environment.NewLine}", args.GetProperty<string>("headers"));
        StringAssert.Contains($"ETag:version1{Environment.NewLine}", args.GetProperty<string>("headers"));
        StringAssert.Contains($"Custom-Header:REDACTED{Environment.NewLine}", args.GetProperty<string>("headers"));
        Assert.AreEqual("System-ClientModel", args.GetProperty<string>("clientAssembly"));

        args = _listener.SingleEventById(ResponseEvent);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("Response", args.EventName);
        Guid responseId = Guid.Parse(args.GetProperty<string>("requestId"));
        Assert.AreEqual(responseId.ToString(), requestId.ToString());
        Assert.AreEqual(args.GetProperty<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:REDACTED{Environment.NewLine}", args.GetProperty<string>("headers"));
    }

    [Test]
    public async Task SendingRequestProducesEvents()
    {
        string requestContent = "Hello";
        string responseContent = "World";

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs args = _listener.SingleEventById(RequestEvent);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("Request", args.EventName);
        Assert.AreEqual("http://example.com/", args.GetProperty<string>("uri"));
        Assert.AreEqual("GET", args.GetProperty<string>("method"));
        StringAssert.Contains($"Date:3/28/2024{Environment.NewLine}", args.GetProperty<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", args.GetProperty<string>("headers"));

        args = _listener.SingleEventById(RequestContentEvent);
        Assert.AreEqual(EventLevel.Verbose, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("RequestContent", args.EventName);
        CollectionAssert.AreEqual(requestContent, args.GetProperty<byte[]>("content"));

        args = _listener.SingleEventById(ResponseEvent);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("Response", args.EventName);
        Assert.AreEqual(args.GetProperty<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Value{Environment.NewLine}", args.GetProperty<string>("headers"));

        args = _listener.SingleEventById(ResponseContentEvent);
        Assert.AreEqual(EventLevel.Verbose, args.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, args.EventSource.Name);
        Assert.AreEqual("ResponseContent", args.EventName);
        CollectionAssert.AreEqual(responseContent, args.GetProperty<byte[]>("content"));
    }

    [Test]
    public void GettingExceptionResponseProducesEvents()
    {
        var exception = new InvalidOperationException();
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        EventWrittenEventArgs e = _listener.SingleEventById(ExceptionResponseEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual(exception.ToString().Split(Environment.NewLine.ToCharArray())[0],
            e.GetProperty<string>("exception").Split(Environment.NewLine.ToCharArray())[0]);
    }

    [Test]
    public async Task GettingErrorResponseProducesEvents()
    {
        byte[] requestContent = new byte[] { 1, 2, 3, 4, 5 };
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value - 2" } });
        var response = new MockPipelineResponse(500, mockHeaders: headers);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true,
                HttpMessageBodyLogLimit = int.MaxValue,
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Date");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs e = _listener.SingleEventById(ErrorResponseEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Warning, e.Level);
        Assert.AreEqual("ErrorResponse", e.EventName);
        Assert.AreEqual(e.GetProperty<int>("status"), 500);
        StringAssert.Contains($"Custom-Response-Header:Value - 2{Environment.NewLine}", e.GetProperty<string>("headers"));

        e = _listener.SingleEventById(ErrorResponseContentEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual("ErrorResponseContent", e.EventName);
        CollectionAssert.AreEqual(responseContent, e.GetProperty<byte[]>("content"));
    }

    [Test]
    public async Task RequestContentIsLoggedAsText()
    {
        string requestContent = "Hello world";

        var response = new MockPipelineResponse(500);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true,
                HttpMessageBodyLogLimit = int.MaxValue
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes(requestContent)));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs e = _listener.SingleEventById(RequestContentTextEvent);
        Assert.AreEqual(EventLevel.Verbose, e.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual("RequestContentText", e.EventName);
        Assert.AreEqual(requestContent, e.GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task ContentIsNotLoggedAsTextWhenDisabled()
    {
        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Content-Type", "text/json" } });
        var response = new MockPipelineResponse(500);
        response.ContentStream = new MemoryStream(new byte[] { 1, 2, 3 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = false,
                HttpMessageBodyLogLimit = int.MaxValue
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        AssertNoContentLogged();
    }

    [Test]
    public async Task ContentIsNotLoggedWhenDisabled()
    {
        var response = new MockPipelineResponse(500);
        response.ContentStream = new NonSeekableMemoryStream(new byte[] { 1, 2, 3 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response)
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        AssertNoContentLogged();
    }

    [Test]
    public async Task RequestContentIsNotLoggedWhenDisabled()
    {
        var response = new MockPipelineResponse(500);
        response.ContentStream = new MemoryStream(new byte[] { 1, 2, 3 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response)
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));

        await pipeline.SendSyncOrAsync(message, IsAsync);

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
        await SendRequest(isSeekable: false, isError: false);

        EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvents[0].EventSource.Name);
        Assert.AreEqual("ResponseContentBlock", contentEvents[0].EventName);
        Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetProperty<byte[]>("content"));

        Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvents[1].EventSource.Name);
        Assert.AreEqual("ResponseContentBlock", contentEvents[1].EventName);
        Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetProperty<byte[]>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocks()
    {
        await SendRequest(isSeekable: false, isError: true);

        EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, errorContentEvents[0].EventSource.Name);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[0].EventName);
        Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetProperty<byte[]>("content"));

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, errorContentEvents[1].EventSource.Name);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[1].EventName);
        Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetProperty<byte[]>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocks()
    {
        await SendRequest(
            isSeekable: false,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );

        EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvents[0].EventSource.Name);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventName);
        Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
        Assert.AreEqual("Hello ", contentEvents[0].GetProperty<string>("content"));

        Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvents[1].EventSource.Name);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[1].EventName);
        Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
        Assert.AreEqual("world", contentEvents[1].GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks()
    {
        await SendRequest(
            isSeekable: false,
            isError: true,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );

        EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(ErrorResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, errorContentEvents[0].EventSource.Name);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[0].EventName);
        Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
        Assert.AreEqual("Hello ", errorContentEvents[0].GetProperty<string>("content"));

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, errorContentEvents[1].EventSource.Name);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[1].EventName);
        Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
        Assert.AreEqual("world", errorContentEvents[1].GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ErrorResponseContentEvent));
    }

    [Test]
    public async Task SeekableTextResponsesAreLoggedInText()
    {
        await SendRequest(
            isSeekable: true,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );

        EventWrittenEventArgs contentEvent = _listener.SingleEventById(ResponseContentTextEvent);

        Assert.AreEqual(EventLevel.Verbose, contentEvent.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvent.EventSource.Name);
        Assert.AreEqual("ResponseContentText", contentEvent.EventName);
        Assert.AreEqual("Hello world", contentEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task SeekableTextResponsesErrorsAreLoggedInText()
    {
        await SendRequest(
            isSeekable: true,
            isError: true,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } }),
            maxLength: 5
        );

        EventWrittenEventArgs errorContentEvent = _listener.SingleEventById(ErrorResponseContentTextEvent);

        Assert.AreEqual(EventLevel.Informational, errorContentEvent.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, errorContentEvent.EventSource.Name);
        Assert.AreEqual("ErrorResponseContentText", errorContentEvent.EventName);
        Assert.AreEqual("Hello", errorContentEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLength()
    {
        await SendRequest(
            isSeekable: true,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } }),
            maxLength: 5
        );

        EventWrittenEventArgs contentEvent = _listener.SingleEventById(ResponseContentTextEvent);

        Assert.AreEqual(EventLevel.Verbose, contentEvent.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvent.EventSource.Name);
        Assert.AreEqual("ResponseContentText", contentEvent.EventName);
        Assert.AreEqual("Hello", contentEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task RequestContentLogsAreLimitedInLength()
    {
        var response = new MockPipelineResponse(500);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true,
                HttpMessageBodyLogLimit = 5
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));
        message.Request.Headers.Add("Content-Type", "text/json");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs e = _listener.SingleEventById(RequestContentTextEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Verbose, e.Level);
        Assert.AreEqual("RequestContentText", e.EventName);
        Assert.AreEqual("Hello", e.GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLength()
    {
        await SendRequest(
            isSeekable: false,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } }),
            maxLength: 5
        );

        EventWrittenEventArgs[] contentEvents = _listener.EventsById(ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(1, contentEvents.Length);

        Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
        Assert.AreEqual(SystemClientModelEventSourceName, contentEvents[0].EventSource.Name);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventName);
        Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
        Assert.AreEqual("Hello", contentEvents[0].GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitized()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response)
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://contoso.a.io?api-version=5&secret=123");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Headers.Add("Date", "4/18/2024");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Secret-Custom-Header", "Value");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs e = _listener.SingleEventById(RequestEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual("Request", e.EventName);
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=REDACTED", e.GetProperty<string>("uri"));
        Assert.AreEqual("GET", e.GetProperty<string>("method"));
        StringAssert.Contains($"Date:4/18/2024{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:REDACTED{Environment.NewLine}", e.GetProperty<string>("headers"));

        e = _listener.SingleEventById(ResponseEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual("Response", e.EventName);
        Assert.AreEqual(e.GetProperty<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", e.GetProperty<string>("headers"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response)
        };
        options.LoggingOptions.AllowedQueryParameters.Add("*");
        options.LoggingOptions.AllowedHeaderNames.Add("*");

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://contoso.a.io?api-version=5&secret=123");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Headers.Add("Date", "4/18/2024");
        message.Request.Headers.Add("Secret-Custom-Header", "Value");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs e = _listener.SingleEventById(RequestEvent);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual("Request", e.EventName);
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=123", e.GetProperty<string>("uri"));
        Assert.AreEqual("GET", e.GetProperty<string>("method"));
        StringAssert.Contains($"Date:4/18/2024{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:Value{Environment.NewLine}", e.GetProperty<string>("headers"));

        e = _listener.SingleEventById(ResponseEvent);
        Assert.AreEqual(EventLevel.Informational, e.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Assert.AreEqual("Response", e.EventName);
        Assert.AreEqual(e.GetProperty<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", e.GetProperty<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:Very secret{Environment.NewLine}", e.GetProperty<string>("headers"));
    }

    private async Task<MockPipelineResponse> SendRequest(bool isSeekable, bool isError, MockResponseHeaders? mockHeaders = default, int maxLength = int.MaxValue)
    {
        var response = new MockPipelineResponse(isError ? 500 : 200, mockHeaders: mockHeaders);
        byte[] responseContent = Encoding.UTF8.GetBytes("Hello world");
        if (isSeekable)
        {
            response.ContentStream = new MemoryStream(responseContent);
        }
        else
        {
            response.ContentStream = new NonSeekableMemoryStream(responseContent);
        }

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsHttpMessageBodyLoggingEnabled = true,
                HttpMessageBodyLogLimit = maxLength
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        // These tests are essentially testing whether the logging policy works
        // correctly when responses are buffered (memory stream) and unbuffered
        // (non-seekable). In order to validate the intent of the test, we set
        // message.BufferResponse accordingly here.
        message.BufferResponse = isSeekable;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        var buffer = new byte[11];

        if (IsAsync)
        {
            Assert.AreEqual(6, await response.ContentStream.ReadAsync(buffer, 5, 6));
            Assert.AreEqual(5, await response.ContentStream.ReadAsync(buffer, 6, 5));
            Assert.AreEqual(0, await response.ContentStream.ReadAsync(buffer, 0, 5));
        }
        else
        {
            Assert.AreEqual(6, response.ContentStream.Read(buffer, 5, 6));
            Assert.AreEqual(5, response.ContentStream.Read(buffer, 6, 5));
            Assert.AreEqual(0, response.ContentStream.Read(buffer, 0, 5));
        }

        return response;
    }
}
