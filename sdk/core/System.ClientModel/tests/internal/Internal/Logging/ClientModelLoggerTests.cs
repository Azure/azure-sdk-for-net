// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

[NonParallelizable]
public class ClientModelLoggerTests : SyncAsyncPolicyTestBase
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

    private TestLoggingFactory _factory;
    private TestLogger _logger;

    private const string LoggingPolicyCategoryName = "System-ClientModel";
    private const string CorrelationIdHeaderName = "Client-Id";

    public ClientModelLoggerTests(bool isAsync) : base(isAsync)
    {
        _logger = new TestLogger(LogLevel.Debug);
        _factory = new TestLoggingFactory(_logger);
    }

    [SetUp]
    public void Setup()
    {
        // Each test needs its own logger
        _logger = new TestLogger(LogLevel.Debug);
        _factory = new TestLoggingFactory(_logger);
    }

    [TearDown]
    public void TearDown()
    {
        _factory?.Dispose();
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
            {
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = uri;
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("ETag", "version1");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(2, _logger.Logs.Count());

        LoggerEvent log = _logger.SingleEventById(RequestEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual(null, log.Exception);
        Assert.AreEqual("Request", log.EventId.Name);

        Guid requestId = Guid.Parse(log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("http://example.com/Index.htm?q1=REDACTED&q2=REDACTED", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:3/28/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"ETag:version1{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        Assert.AreEqual("System-ClientModel", log.GetValueFromArguments<string>("clientAssembly"));

        log = _logger.SingleEventById(ResponseEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Response", log.EventId.Name);
        Assert.AreEqual(null, log.Exception);
        Guid responseId = Guid.Parse(log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(responseId.ToString(), requestId.ToString());
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
    }

    [Test]
    public async Task SendingRequestProducesEvents()
    {
        string requestContent = "Hello";
        string responseContent = "World";
        string clientId = "client1";

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                IsLoggingContentEnabled = true,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(RequestEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Request", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("http://example.com/", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:3/28/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = _logger.SingleEventById(RequestContentEvent);
        Assert.AreEqual(LogLevel.Debug, log.LogLevel);
        Assert.AreEqual("RequestContent", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        CollectionAssert.AreEqual(requestContent, log.GetValueFromArguments<byte[]>("content"));

        log = _logger.SingleEventById(ResponseEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Response", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = _logger.SingleEventById(ResponseContentEvent);
        Assert.AreEqual(LogLevel.Debug, log.LogLevel);
        Assert.AreEqual("ResponseContent", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        CollectionAssert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));
    }

    [Test]
    public void GettingExceptionResponseProducesEvents()
    {
        string clientId = "client1";

        var exception = new InvalidOperationException();
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception),
            LoggingOptions = new LoggingOptions
            {
                IsLoggingContentEnabled = true,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        LoggerEvent log = _logger.SingleEventById(ExceptionResponseEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(exception, log.Exception);
    }

    [Test]
    public async Task GettingErrorResponseProducesEvents()
    {
        byte[] requestContent = new byte[] { 1, 2, 3, 4, 5 };
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };
        string clientId = "client1";

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value - 2" } });
        var response = new MockPipelineResponse(500, mockHeaders: headers);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsLoggingContentEnabled = true,
                LoggedContentSizeLimit = int.MaxValue,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Date");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add(clientId, clientId);
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(ErrorResponseEvent);
        Assert.AreEqual(LogLevel.Warning, log.LogLevel);
        Assert.AreEqual("ErrorResponse", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 500);
        StringAssert.Contains($"Custom-Response-Header:Value - 2{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = _logger.SingleEventById(ErrorResponseContentEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("ErrorResponseContent", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        CollectionAssert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));
    }

    [Test]
    public async Task RequestContentIsLoggedAsText()
    {
        string clientId = "client1";
        string requestContent = "Hello world";

        var response = new MockPipelineResponse(500);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            LoggingOptions = new LoggingOptions
            {
                IsLoggingContentEnabled = true,
                LoggedContentSizeLimit = int.MaxValue,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes(requestContent)));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(RequestContentTextEvent);
        Assert.AreEqual(LogLevel.Debug, log.LogLevel);
        Assert.AreEqual("RequestContentText", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(requestContent, log.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
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
                IsLoggingContentEnabled = false,
                LoggedContentSizeLimit = int.MaxValue,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Date", "3/28/2024");
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));
        message.Request.Headers.Add(CorrelationIdHeaderName, "client1");

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
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));
        message.Request.Headers.Add(CorrelationIdHeaderName, "client-id");

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
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
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
        CollectionAssert.IsEmpty(_logger.EventsById(RequestContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(RequestContentTextEvent));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentBlockEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentTextBlockEvent));

        CollectionAssert.IsEmpty(_logger.EventsById(ErrorResponseContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(ErrorResponseContentTextEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(ErrorResponseContentTextBlockEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocks()
    {
        await SendRequest(isSeekable: false, isError: false);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent[] contentEvents = _logger.EventsById(ResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual("client-id", contentEvents[0].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual("client-id", contentEvents[1].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocks()
    {
        await SendRequest(isSeekable: false, isError: true);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent[] errorContentEvents = _logger.EventsById(ErrorResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual("client-id", errorContentEvents[0].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual("client-id", errorContentEvents[1].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ErrorResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocks()
    {
        await SendRequest(
            isSeekable: false,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent[] contentEvents = _logger.EventsById(ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);

        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual("client-id", contentEvents[0].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", contentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual("client-id", contentEvents[1].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", contentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks()
    {
        await SendRequest(
            isSeekable: false,
            isError: true,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent[] errorContentEvents = _logger.EventsById(ErrorResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual("client-id", errorContentEvents[0].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", errorContentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual("client-id", errorContentEvents[1].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", errorContentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ErrorResponseContentEvent));
    }

    [Test]
    public async Task SeekableTextResponsesAreLoggedInText()
    {
        await SendRequest(
            isSeekable: true,
            isError: false,
            mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { "Content-Type", "text/xml" } })
        );
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent contentEvent = _logger.SingleEventById(ResponseContentTextEvent);

        Assert.AreEqual(LogLevel.Debug, contentEvent.LogLevel);
        Assert.AreEqual("ResponseContentText", contentEvent.EventId.Name);
        Assert.AreEqual("client-id", contentEvent.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("Hello world", contentEvent.GetValueFromArguments<string>("content"));
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
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent errorContentEvent = _logger.SingleEventById(ErrorResponseContentTextEvent);

        Assert.AreEqual(LogLevel.Information, errorContentEvent.LogLevel);
        Assert.AreEqual("ErrorResponseContentText", errorContentEvent.EventId.Name);
        Assert.AreEqual("client-id", errorContentEvent.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("Hello", errorContentEvent.GetValueFromArguments<string>("content"));
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
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent contentEvent = _logger.SingleEventById(ResponseContentTextEvent);

        Assert.AreEqual(LogLevel.Debug, contentEvent.LogLevel);
        Assert.AreEqual("ResponseContentText", contentEvent.EventId.Name);
        Assert.AreEqual("client-id", contentEvent.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("Hello", contentEvent.GetValueFromArguments<string>("content"));
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
                IsLoggingContentEnabled = true,
                LoggedContentSizeLimit = 5,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Headers.Add(CorrelationIdHeaderName, "client1");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(RequestContentTextEvent);
        Assert.AreEqual(LogLevel.Debug, log.LogLevel);
        Assert.AreEqual("RequestContentText", log.EventId.Name);
        Assert.AreEqual("client1", log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("Hello", log.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
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
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        LoggerEvent[] contentEvents = _logger.EventsById(ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(1, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual("client-id", contentEvents[0].GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello", contentEvents[0].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(ResponseContentEvent));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitized()
    {
        string clientId = "client1";

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        options.LoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://contoso.a.io?api-version=5&secret=123");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);
        message.Request.Headers.Add("Date", "4/18/2024");
        message.Request.Headers.Add("Custom-Header", "Value");
        message.Request.Headers.Add("Secret-Custom-Header", "Value");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(RequestEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Request", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=REDACTED", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:4/18/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = _logger.SingleEventById(ResponseEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Response", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
    {
        string clientId = "client1";
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = new LoggingOptions
            {
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };
        options.LoggingOptions.AllowedQueryParameters.Add("*");
        options.LoggingOptions.AllowedHeaderNames.Add("*");

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://contoso.a.io?api-version=5&secret=123");
        message.Request.Content = BinaryContent.Create(new BinaryData(new byte[] { 1, 2, 3, 4, 5 }));
        message.Request.Headers.Add("Content-Type", "text/json");
        message.Request.Headers.Add(CorrelationIdHeaderName, clientId);
        message.Request.Headers.Add("Date", "4/18/2024");
        message.Request.Headers.Add("Secret-Custom-Header", "Value");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        LoggerEvent log = _logger.SingleEventById(RequestEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Request", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=123", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:4/18/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = _logger.SingleEventById(ResponseEvent);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.AreEqual("Response", log.EventId.Name);
        Assert.AreEqual(clientId, log.GetValueFromArguments<string>("requestId"));
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:Very secret{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
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
                IsLoggingContentEnabled = true,
                LoggedContentSizeLimit = maxLength,
                CorrelationIdHeaderName = CorrelationIdHeaderName,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add(CorrelationIdHeaderName, "client-id");

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
