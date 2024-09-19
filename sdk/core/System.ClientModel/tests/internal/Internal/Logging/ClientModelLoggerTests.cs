// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
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
    // TODO
    private const int ResponseDelayEvent = 7;

    private TestLoggingFactory _factory;
    private TestLogger _logger;

    private const string LoggingPolicyCategoryName = "System.ClientModel";

    private readonly MockResponseHeaders _defaultHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" }
    });

    private readonly MockResponseHeaders _defaultTextHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" },
        { "Content-Type", "text/plain" }
    });

    public ClientModelLoggerTests(bool isAsync) : base(isAsync)
    {
        _logger = new TestLogger(LogLevel.Debug);
        _factory = new TestLoggingFactory(_logger);
    }

    [SetUp]
    public void Setup()
    {
        _logger = new TestLogger(LogLevel.Debug);
        _factory = new TestLoggingFactory(_logger);
    }

    [TearDown]
    public void TearDown()
    {
        _factory?.Dispose();
    }

    [Test]
    public async Task RequestAndResponseProduceLogs()
    {
        byte[] requestContent = new byte[] { 1, 2, 3, 4, 5 };
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = true,
            HttpMessageBodyLogLimit = int.MaxValue,
            LoggerFactory = _factory
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent, loggingOptions: loggingOptions);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        Assert.AreEqual("http://example.com/", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = GetSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", LogLevel.Debug);
        CollectionAssert.AreEqual(requestContent, log.GetValueFromArguments<byte[]>("content"));

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = GetSingleEvent(LoggingEventIds.ResponseContentEvent, "ResponseContent", LogLevel.Debug);
        CollectionAssert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));
    }

    [Test]
    public async Task ErrorResponseProducesLogs()
    {
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = true,
            HttpMessageBodyLogLimit = int.MaxValue,
            LoggerFactory = _factory
        };

        MockPipelineResponse response = new(500, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 }, loggingOptions: loggingOptions);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", LogLevel.Warning);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 500);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = GetSingleEvent(LoggingEventIds.ErrorResponseContentEvent, "ErrorResponseContent", LogLevel.Information);
        CollectionAssert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));

        // TODO - add retry checks
    }

    [Test]
    public async Task RequestAndResponseContentIsLoggedAsText()
    {
        string requestContent = "Hello";
        string responseContent = "World!";

        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = true,
            HttpMessageBodyLogLimit = int.MaxValue,
            LoggerFactory = _factory
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentString: requestContent, loggingOptions: loggingOptions);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", LogLevel.Debug);
        Assert.AreEqual(requestContent, log.GetValueFromArguments<string>("content"));

        log = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug);
        Assert.AreEqual(responseContent, log.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task ContentIsNotLoggedAsTextWhenDisabled()
    {
        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = false,
            HttpMessageBodyLogLimit = int.MaxValue,
            LoggerFactory = _factory
        };

        MockPipelineResponse response = new(500, mockHeaders: _defaultTextHeaders);
        response.SetContent("TextResponseContent");

        await CreatePipelineAndSendRequest(response, requestContentString: "TextRequestContent", loggingOptions: loggingOptions);

        AssertNoContentLogged();
    }

    [Test]
    public async Task ContentIsNotLoggedWhenDisabled()
    {
        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = false,
            HttpMessageBodyLogLimit = int.MaxValue,
            LoggerFactory = _factory
        };

        MockPipelineResponse response = new(500, mockHeaders: _defaultHeaders);
        response.SetContent(new byte[] { 1, 2, 3 });

        await CreatePipelineAndSendRequest(response, requestContentBytes: Encoding.UTF8.GetBytes("Hello world"), loggingOptions: loggingOptions);

        AssertNoContentLogged();
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocks()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultHeaders);

        LoggerEvent[] contentEvents = _logger.EventsById(LoggingEventIds.ResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocks()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultHeaders);

        LoggerEvent[] errorContentEvents = _logger.EventsById(LoggingEventIds.ErrorResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocks()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders);

        LoggerEvent[] contentEvents = _logger.EventsById(LoggingEventIds.ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);

        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", contentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", contentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultTextHeaders);

        LoggerEvent[] errorContentEvents = _logger.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", errorContentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", errorContentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    [Test]
    public async Task SeekableTextResponsesAreLoggedInText()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug);
        Assert.AreEqual("Hello world", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task SeekableTextResponsesErrorsAreLoggedInText()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, true, _defaultTextHeaders, 5);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ErrorResponseContentTextEvent, "ErrorResponseContentText", LogLevel.Information);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, 5);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task RequestContentLogsAreLimitedInLength()
    {
        var response = new MockPipelineResponse(500);

        LoggingOptions loggingOptions = new LoggingOptions
        {
            IsHttpMessageBodyLoggingEnabled = true,
            HttpMessageBodyLogLimit = 5,
            LoggerFactory = _factory
        };

        Dictionary<string, string> requestHeaders = new()
        {
            { "Content-Type", "text/plain" }
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: Encoding.UTF8.GetBytes("Hello world"), requestHeaders: requestHeaders, loggingOptions: loggingOptions);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", LogLevel.Debug);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, 5);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextBlockEvent, "ResponseContentTextBlock", LogLevel.Debug);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitized()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 }, requestHeaders: requestHeaders, requestUri: requestUri);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=REDACTED", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        LoggingOptions loggingOptions = new()
        {
            LoggerFactory = _factory
        };
        loggingOptions.AllowedQueryParameters.Add("*");
        loggingOptions.AllowedHeaderNames.Add("*");

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "Value" },
            { "Content-Type", "text/json" }
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 }, requestHeaders: requestHeaders, requestUri: requestUri, loggingOptions: loggingOptions);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        Assert.AreEqual("https://contoso.a.io/?api-version=5&secret=123", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Custom-Header:Value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Secret-Response-Header:Very secret{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
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
                IsHttpMessageBodyLoggingEnabled = true,
                LoggerFactory = _factory
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ExceptionResponseEvent, "ExceptionResponse", LogLevel.Information);
        Assert.AreEqual(exception, log.Exception);
    }

    #region Helpers

    private LoggerEvent GetSingleEvent(int id, string expectedEventName, LogLevel expectedLogLevel)
    {
        LoggerEvent log = _logger.SingleEventById(id);
        Assert.AreEqual(expectedEventName, log.EventId.Name);
        Assert.AreEqual(expectedLogLevel, log.LogLevel);
        Guid.Parse(log.GetValueFromArguments<string>("requestId"));

        return log;
    }

    private void AssertNoContentLogged()
    {
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.RequestContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.RequestContentTextEvent));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentBlockEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ResponseContentTextBlockEvent));

        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ErrorResponseContentTextEvent));
        CollectionAssert.IsEmpty(_logger.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent));
    }

    private async Task CreatePipelineAndSendRequestWithStreamingResponse(int statusCode,
                                                                         bool isSeekable,
                                                                         MockResponseHeaders responseHeaders,
                                                                         int maxLength = int.MaxValue)
    {
        MockPipelineResponse response = new(status: statusCode, mockHeaders: responseHeaders);

        byte[] responseContent = Encoding.UTF8.GetBytes("Hello world");
        if (isSeekable)
        {
            response.ContentStream = new MemoryStream(responseContent);
        }
        else
        {
            response.ContentStream = new NonSeekableMemoryStream(responseContent);
        }

        LoggingOptions loggingOptions = new()
        {
            IsHttpMessageBodyLoggingEnabled = true,
            HttpMessageBodyLogLimit = maxLength,
            LoggerFactory = _factory
        };

        // These tests are essentially testing whether the logging policy works
        // correctly when responses are buffered (memory stream) and unbuffered
        // (non-seekable). In order to validate the intent of the test, we set
        // message.BufferResponse accordingly here.
        await CreatePipelineAndSendRequest(response, loggingOptions: loggingOptions, bufferResponse: isSeekable);

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
    }

    private async Task CreatePipelineAndSendRequest(MockPipelineResponse response,
                                                    string? requestContentString = default,
                                                    byte[]? requestContentBytes = default,
                                                    Dictionary<string, string>? requestHeaders = default,
                                                    Uri? requestUri = default,
                                                    LoggingOptions? loggingOptions = default,
                                                    bool? bufferResponse = default)
    {
        loggingOptions ??= new LoggingOptions
        {
            LoggerFactory = _factory
        };
        loggingOptions.AllowedHeaderNames.Add("Custom-Header");
        loggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = requestUri ?? new Uri("http://example.com");

        if (requestHeaders != null)
        {
            foreach (KeyValuePair<string, string> header in requestHeaders)
            {
                message.Request.Headers.Add(header.Key, header.Value);
            }
        }

        message.Request.Headers.Add("Custom-Header", "custom-header-value");
        message.Request.Headers.Add("Date", "08/16/2024");

        if (bufferResponse != null)
        {
            message.BufferResponse = bufferResponse.Value;
        }

        if (requestContentBytes != null)
        {
            message.Request.Content = BinaryContent.Create(new BinaryData(requestContentBytes));
        }
        else if (requestContentString != null)
        {
            message.Request.Headers.Add("Content-Type", "text/plain");
            message.Request.Content = BinaryContent.Create(new BinaryData(requestContentString));
        }

        await pipeline.SendSyncOrAsync(message, IsAsync);
    }

    #endregion
}
