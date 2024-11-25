// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

/// <summary>
/// Tests that messages are written to ILogger when an ILoggerFactory is provided
/// </summary>
[NonParallelizable]
public class ClientModelLoggerTests : SyncAsyncPolicyTestBase
{
    private const string LoggingPolicyCategoryName = "System.ClientModel.Primitives.MessageLoggingPolicy";
    private const string PipelineTransportCategoryName = "System.ClientModel.Primitives.PipelineTransport";
    private const string RetryPolicyCategoryName = "System.ClientModel.Primitives.ClientRetryPolicy";

    private readonly MockResponseHeaders _defaultHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" },
        { "Date", "4/29/2024" },
        { "ETag", "version1" }
    });
    private readonly MockResponseHeaders _defaultTextHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" },
        { "Content-Type", "text/plain" }
    });

    private TestLoggingFactory _factory;
    private ClientLoggingOptions _loggingOptions;

    public ClientModelLoggerTests(bool isAsync) : base(isAsync)
    {
        _factory = new TestLoggingFactory(LogLevel.Debug);
        _loggingOptions = new() { LoggerFactory = _factory };
    }

    [SetUp]
    public void Setup()
    {
        _factory = new TestLoggingFactory(LogLevel.Debug);
        _loggingOptions = new() { LoggerFactory = _factory };
    }

    [TearDown]
    public void TearDown()
    {
        _factory?.Dispose();
    }

    #region Configuration tests

    [Test]
    public async Task NoEventsAreWrittenToEventSourceWhenILoggerIsConfigured()
    {
        TestClientEventListener listener = new();

        string requestContent = "Hello";
        string responseContent = "World";
        Uri uri = new("http://example.com/Index.htm?q1=v1&q2=v2");

        var response = new MockPipelineResponse(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentString: requestContent);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        Assert.AreEqual(2, logger.Logs.Count()); // Request & Response events

        Assert.AreEqual(0, listener.EventData.Count());
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentIsNotLoggedWhenDisabled(bool isError)
    {
        _loggingOptions.EnableMessageContentLogging = false;

        MockPipelineResponse response = new(500, mockHeaders: _defaultHeaders);
        response.SetContent(new byte[] { 1, 2, 3 });

        await CreatePipelineAndSendRequest(response, requestContentBytes: Encoding.UTF8.GetBytes("Hello world"));

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);
        AssertNoContentLogged(logger);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentIsNotLoggedAsTextWhenDisabled(bool isError)
    {
        _loggingOptions.EnableMessageContentLogging = false;

        MockPipelineResponse response = new(500, mockHeaders: _defaultTextHeaders);
        response.SetContent("TextResponseContent");

        await CreatePipelineAndSendRequest(response, requestContentString: "TextRequestContent");

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);
        AssertNoContentLogged(logger);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentLogIsNotWrittenWhenThereIsNoContent(bool isError)
    {
        _loggingOptions.EnableMessageContentLogging = true;

        MockPipelineResponse response = new(200);

        await CreatePipelineAndSendRequest(response);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);
        AssertNoContentLogged(logger);
    }

    [Test]
    public async Task RequestContentLogsAreLimitedInLength()
    {
        var response = new MockPipelineResponse(500);
        byte[] requestContent = [1, 2, 3, 4, 5, 6, 7, 8];
        byte[] requestContentLimited = [1, 2, 3, 4, 5];

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = 5;

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", LogLevel.Debug, logger);
        Assert.AreEqual(requestContentLimited, logEvent.GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentTextEvent));
    }

    [Test]
    public async Task RequestContentTextLogsAreLimitedInLength()
    {
        var response = new MockPipelineResponse(500);

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = 5;

        Dictionary<string, string> requestHeaders = new()
        {
            { "Content-Type", "text/plain" }
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: Encoding.UTF8.GetBytes("Hello world"), requestHeaders: requestHeaders);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", LogLevel.Debug, logger);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, 5);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug, logger);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, 5);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextBlockEvent, "ResponseContentTextBlock", LogLevel.Debug, logger);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInRequestAndResponseEvents() // Request event and response event sanitize headers
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that headers on the request are sanitized

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information, logger);
        string headers = log.GetValueFromArguments<string>("headers");
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", headers);
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Custom-Header:REDACTED{Environment.NewLine}", headers);
        StringAssert.DoesNotContain("secret-value", headers);

        // Assert that headers on the response are sanitized

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information, logger);
        headers = log.GetValueFromArguments<string>("headers");
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", headers);
        StringAssert.DoesNotContain("Very secret", headers);
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInErrorResponseEvent() // Error response event sanitizes headers
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(400, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that headers on the response are sanitized

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", LogLevel.Warning, logger);
        string headers = log.GetValueFromArguments<string>("headers");
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", headers);
        StringAssert.DoesNotContain("Very Secret", headers);
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        _loggingOptions.AllowedQueryParameters.Add("*");
        _loggingOptions.AllowedHeaderNames.Add("*");

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "Value" },
            { "Content-Type", "text/json" }
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information, logger);
        string headers = log.GetValueFromArguments<string>("headers");
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", headers);
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Custom-Header:Value{Environment.NewLine}", headers);

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information, logger);
        headers = log.GetValueFromArguments<string>("headers");
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Response-Header:Very secret{Environment.NewLine}", headers);
    }

    #endregion

    #region Log messages: pipeline message logger

    [Test]
    public async Task SendingARequestProducesRequestAndResponseLogMessages() // RequestEvent, ResponseEvent
    {
        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent);

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request log message is written and formatted correctly

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information, logger);
        Assert.AreEqual("http://example.com/", log.GetValueFromArguments<string>("uri"));
        Assert.AreEqual("GET", log.GetValueFromArguments<string>("method"));
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        // Assert that the response log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information, logger);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        // Assert that no other log messages were written
        Assert.AreEqual(logger.Logs.Count(), 2);
    }

    [Test]
    public async Task ReceivingAnErrorResponseProducesAnErrorResponseLogMessage() // ErrorResponseEvent, ErrorResponseContentEvent
    {
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = int.MaxValue;

        MockPipelineResponse response = new(400, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 });

        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the error response log message is written and formatted correctly

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", LogLevel.Warning, logger);
        Assert.AreEqual(log.GetValueFromArguments<int>("status"), 400);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetValueFromArguments<string>("headers"));

        // Assert that the error response content log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ErrorResponseContentEvent, "ErrorResponseContent", LogLevel.Information, logger);
        CollectionAssert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAndResponseContentLogMessage() // RequestContentEvent, ResponseContentEvent
    {
        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = int.MaxValue;

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request content log message is written and formatted correctly

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", LogLevel.Debug, logger);
        Assert.AreEqual(requestContent, log.GetValueFromArguments<byte[]>("content"));

        // Assert that the response content log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseContentEvent, "ResponseContent", LogLevel.Debug, logger);
        Assert.AreEqual(responseContent, log.GetValueFromArguments<byte[]>("content"));

        // Assert content was not written as text

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.RequestContentTextEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentTextEvent));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAsTextAndResponseContentAsText() // RequestContentTextEvent, ResponseContentTextEvent
    {
        string requestContent = "Hello";
        string responseContent = "World!";

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = int.MaxValue;

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentString: requestContent);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request content text event is written and formatted correctly

        LoggerEvent log = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", LogLevel.Debug, logger);
        Assert.AreEqual(requestContent, log.GetValueFromArguments<string>("content"));

        // Assert that the response content text event is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug, logger);
        Assert.AreEqual(responseContent, log.GetValueFromArguments<string>("content"));

        // Assert content was not written not as text

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.RequestContentEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesResponseContentAsTextWithSeekableTextStream() // ResponseContentTextEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug, logger);
        Assert.AreEqual("Hello world", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesErrorResponseContentAsTextWithSeekableTextStream() // ErrorResponseContentTextEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, true, _defaultTextHeaders, 5);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = GetSingleEvent(LoggingEventIds.ErrorResponseContentTextEvent, "ErrorResponseContentText", LogLevel.Information, logger);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocks() // ResponseContentBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultHeaders);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] contentEvents = logger.EventsById(LoggingEventIds.ResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocks() // ErrorResponseContentBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultHeaders);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] errorContentEvents = logger.EventsById(LoggingEventIds.ErrorResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetValueFromArguments<byte[]>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetValueFromArguments<byte[]>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocks() // ResponseContentTextBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] contentEvents = logger.EventsById(LoggingEventIds.ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(LogLevel.Debug, contentEvents[0].LogLevel);

        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventId.Name);
        Assert.AreEqual(0, contentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", contentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Debug, contentEvents[1].LogLevel);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[1].EventId.Name);
        Assert.AreEqual(1, contentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", contentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks() // ErrorResponseContentTextBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultTextHeaders);
        TestLogger logger = _factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] errorContentEvents = logger.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(LogLevel.Information, errorContentEvents[0].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[0].EventId.Name);
        Assert.AreEqual(0, errorContentEvents[0].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("Hello ", errorContentEvents[0].GetValueFromArguments<string>("content"));

        Assert.AreEqual(LogLevel.Information, errorContentEvents[1].LogLevel);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[1].EventId.Name);
        Assert.AreEqual(1, errorContentEvents[1].GetValueFromArguments<int>("blockNumber"));
        Assert.AreEqual("world", errorContentEvents[1].GetValueFromArguments<string>("content"));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    #endregion

    #region Log messages: pipeline transport logger

    [Test]
    public void GettingExceptionResponseProducesEvents() // ExceptionResponseEvent
    {
        var exception = new InvalidOperationException();

        _loggingOptions.EnableMessageContentLogging = true;
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception, true, _factory),
            ClientLoggingOptions = _loggingOptions
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));
        TestLogger logger = _factory.GetLogger(PipelineTransportCategoryName);

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ExceptionResponseEvent, "ExceptionResponse", LogLevel.Information, logger);
        Assert.AreEqual(exception, log.Exception);
    }

    [Test]
    public async Task ResponseReceivedAfterThreeSecondsProducesResponseDelayEvent() // ResponseDelayEvent
    {
        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response, true, _factory, true),
            ClientLoggingOptions = _loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);
        TestLogger logger = _factory.GetLogger(PipelineTransportCategoryName);

        // Assert that the response log message is written and formatted correctly

        LoggerEvent log = GetSingleEvent(LoggingEventIds.ResponseDelayEvent, "ResponseDelay", LogLevel.Warning, logger);
        Assert.Greater(log.GetValueFromArguments<double>("seconds"), 3);
    }

    #endregion

    #region Log messages: pipeline retry logger

    [Test]
    public async Task SendingRequestThatIsRetriedProducesRequestRetryingEventOnEachRetry() // RequestRetryingEvent
    {
        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", [429, 200]),
            ClientLoggingOptions = new()
            {
                LoggerFactory = _factory
            }
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);
        TestLogger logger = _factory.GetLogger(RetryPolicyCategoryName);

        IEnumerable<LoggerEvent> retryLogs = logger.EventsById(LoggingEventIds.RequestRetryingEvent);

        Assert.AreEqual(200, message.Response!.Status);
    }

    #endregion

    #region Helpers

    private LoggerEvent GetSingleEvent(int id, string expectedEventName, LogLevel expectedLogLevel, TestLogger logger)
    {
        LoggerEvent log = logger.SingleEventById(id);
        Assert.AreEqual(expectedEventName, log.EventId.Name);
        Assert.AreEqual(expectedLogLevel, log.LogLevel);
        // Guid.Parse(log.GetValueFromArguments<string>("requestId")); // Request id should be a guid TODO

        return log;
    }

    private void AssertNoContentLogged(TestLogger logger)
    {
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.RequestContentEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.RequestContentTextEvent));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentBlockEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ResponseContentTextBlockEvent));

        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ErrorResponseContentEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ErrorResponseContentTextEvent));
        CollectionAssert.IsEmpty(logger.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent));
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

        _loggingOptions.EnableMessageContentLogging = true;
        _loggingOptions.MessageContentSizeLimit = maxLength;

        // These tests are essentially testing whether the logging policy works
        // correctly when responses are buffered (memory stream) and unbuffered
        // (non-seekable). In order to validate the intent of the test, we set
        // message.BufferResponse accordingly here.
        await CreatePipelineAndSendRequest(response, bufferResponse: isSeekable);

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
                                                    bool? bufferResponse = default)
    {
        _loggingOptions.AllowedHeaderNames.Add("Custom-Header");
        _loggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = _loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

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
