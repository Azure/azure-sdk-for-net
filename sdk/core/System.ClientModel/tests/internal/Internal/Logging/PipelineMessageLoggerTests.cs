// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Bson;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

// Avoid running these tests in parallel with anything else that's sharing the event source
[NonParallelizable]
public class PipelineMessageLoggerTests : SyncAsyncPolicyTestBase
{
    private const int RequestEvent = 1;
    private const int RequestContentEvent = 2;
    private const int ResponseEvent = 5;
    private const int ResponseContentEvent = 6;
    private const int ErrorResponseEvent = 8;
    private const int ErrorResponseContentEvent = 9;
    private const int ResponseContentBlockEvent = 11;
    private const int ErrorResponseContentBlockEvent = 12;
    private const int ResponseContentTextEvent = 13;
    private const int ErrorResponseContentTextEvent = 14;
    private const int ResponseContentTextBlockEvent = 15;
    private const int ErrorResponseContentTextBlockEvent = 16;
    private const int RequestContentTextEvent = 17;

    private const string LoggingPolicyCategoryName = "System.ClientModel.Primitives.MessageLoggingPolicy";
    private const string SystemClientModelEventSourceName = "System.ClientModel";
    private readonly MockResponseHeaders _defaultHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" },
        { "Date", "4/29/2024" },
        { "ETag", "version1" }
    });
    private readonly MockResponseHeaders _defaultTextHeaders = new(new Dictionary<string, string>()
    {
        { "Custom-Response-Header", "custom-response-header-value" },
        { "Content-Type", "text/plain" },
        { "Date", "4/29/2024" },
        { "ETag", "version1" }
    });

    public PipelineMessageLoggerTests(bool isAsync) : base(isAsync)
    {
    }

    #region Unit tests

    [Test]
    public void LogsAreLoggedToILoggerAndNotEventSourceWhenILoggerIsProvided()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Debug);

        PipelineMessageLogger messageLogger = new(new PipelineMessageSanitizer([], []), factory);

        MockPipelineRequest request = new()
        {
            Uri = new Uri("http://example.com/")
        };
        MockPipelineResponse response = new(500);

        messageLogger.LogRequest("requestId", request, "assembly");
        messageLogger.LogRequestContent("requestId", [1,2,3], null);
        messageLogger.LogRequestContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponse("requestId", response, 1);
        messageLogger.LogResponseContent("requestId", [1,2,3], null);
        messageLogger.LogResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponseContentBlock("requestId", 1, [1,2,3], null);
        messageLogger.LogResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponse("requestId", response, 1);
        messageLogger.LogErrorResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogErrorResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogErrorResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        logger.SingleEventById(RequestEvent);
        logger.SingleEventById(RequestContentEvent);
        logger.SingleEventById(RequestContentTextEvent);
        logger.SingleEventById(ResponseEvent);
        logger.SingleEventById(ResponseContentEvent);
        logger.SingleEventById(ResponseContentTextEvent);
        logger.SingleEventById(ResponseContentBlockEvent);
        logger.SingleEventById(ResponseContentTextBlockEvent);
        logger.SingleEventById(ErrorResponseEvent);
        logger.SingleEventById(ErrorResponseContentEvent);
        logger.SingleEventById(ErrorResponseContentBlockEvent);
        logger.SingleEventById(ErrorResponseContentTextBlockEvent);

        Assert.That(listener.EventData, Is.Empty); // Nothing should log to Event Source
    }

    [Test]
    public void LogsAreNotWrittenToEventSourceWhenILoggerIsProvidedAndLogLevelIsWarning()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Warning);

        PipelineMessageLogger messageLogger = new(new PipelineMessageSanitizer([], []), factory);

        MockPipelineRequest request = new()
        {
            Uri = new Uri("http://example.com/")
        };
        MockPipelineResponse response = new(500);

        messageLogger.LogRequest("requestId", request, "assembly");
        messageLogger.LogRequestContent("requestId", [1, 2, 3], null);
        messageLogger.LogRequestContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponse("requestId", response, 1);
        messageLogger.LogResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponse("requestId", response, 1);
        messageLogger.LogErrorResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogErrorResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogErrorResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text

        Assert.That(listener.EventData, Is.Empty); // Nothing should log to Event Source
    }

    [Test]
    public void IsEnabledILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        PipelineMessageLogger messageLogger = new(new PipelineMessageSanitizer([], []), factory);

        Assert.That(messageLogger.IsEnabled(LogLevel.Debug, EventLevel.Verbose), Is.True);
        Assert.That(messageLogger.IsEnabled(LogLevel.Critical, EventLevel.Verbose), Is.True);
        Assert.That(messageLogger.IsEnabled(LogLevel.Trace, EventLevel.Warning), Is.False);
    }

    [Test]
    public void EventsAreNotLoggedIfDisabledEventSource()
    {
        using TestEventListenerWarning listener = new();
        PipelineMessageLogger messageLogger = new(new PipelineMessageSanitizer([], []), null);
        MockPipelineRequest request = new()
        {
            Uri = new Uri("http://example.com/")
        };
        MockPipelineResponse response = new(500);

        messageLogger.LogRequest("requestId", request, "assembly");
        messageLogger.LogRequestContent("requestId", [1, 2, 3], null);
        messageLogger.LogRequestContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponse("requestId", response, 1);
        messageLogger.LogResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponse("requestId", response, 1);
        messageLogger.LogErrorResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogErrorResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogErrorResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text

        listener.SingleEventById(ErrorResponseEvent);
        Assert.That(listener.EventData.Count(), Is.EqualTo(1));
    }

    [Test]
    public void EventsAreNotLoggedIfDisabledILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Warning);
        PipelineMessageLogger messageLogger = new(new PipelineMessageSanitizer([], []), factory);
        MockPipelineRequest request = new()
        {
            Uri = new Uri("http://example.com/")
        };
        MockPipelineResponse response = new(500);

        messageLogger.LogRequest("requestId", request, "assembly");
        messageLogger.LogRequestContent("requestId", [1, 2, 3], null);
        messageLogger.LogRequestContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponse("requestId", response, 1);
        messageLogger.LogResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponse("requestId", response, 1);
        messageLogger.LogErrorResponseContent("requestId", [1, 2, 3], null);
        messageLogger.LogErrorResponseContent("requestId", "Hello"u8.ToArray(), Encoding.UTF8); // text
        messageLogger.LogErrorResponseContentBlock("requestId", 1, [1, 2, 3], null);
        messageLogger.LogErrorResponseContentBlock("requestId", 1, "Hello"u8.ToArray(), Encoding.UTF8); // text

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.SingleEventById(ErrorResponseEvent);
        Assert.That(logger.Logs.Count(), Is.EqualTo(1));
    }

    #endregion

    #region Integration tests

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInRequestAndResponseEventsEventSource() // Request event and response event sanitize headers
    {
        using TestClientEventListener listener = new();

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

        // Assert that headers on the request are sanitized

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational, SystemClientModelEventSourceName);
        string headers = log.GetProperty<string>("headers");
        Assert.That(headers, Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Custom-Header:custom-header-value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Custom-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("secret-value"));

        // Assert that headers on the response are sanitized

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational, SystemClientModelEventSourceName);
        headers = log.GetProperty<string>("headers");
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("Very secret"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInRequestAndResponseEventsILogger() // Request event and response event sanitize headers
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri, loggingOptions: loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that headers on the request are sanitized

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        string headers = (log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString();
        Assert.That(headers, Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Custom-Header:custom-header-value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Custom-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("secret-value"));

        // Assert that headers on the response are sanitized

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        headers = (log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString();
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("Very secret"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInErrorResponseEventEventSource() // Error response event sanitizes headers
    {
        using TestClientEventListener listener = new();

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(400, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri);

        // Assert that headers on the response are sanitized

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", EventLevel.Warning, SystemClientModelEventSourceName);
        string headers = log.GetProperty<string>("headers");
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("Very Secret"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInErrorResponseEventILogger() // Error response event sanitizes headers
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(400, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "secret-value" },
            { "Content-Type", "text/json" }
        };

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri, loggingOptions: loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that headers on the response are sanitized

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", LogLevel.Warning);
        string headers = (log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString();
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:REDACTED{Environment.NewLine}"));
        Assert.That(headers, Does.Not.Contain("Very Secret"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStarsEventSource()
    {
        using TestClientEventListener listener = new();

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        ClientLoggingOptions loggingOptions = new();
        loggingOptions.AllowedQueryParameters.Add("*");
        loggingOptions.AllowedHeaderNames.Add("*");

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "Value" },
            { "Content-Type", "text/json" }
        };

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri);

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational, SystemClientModelEventSourceName);
        string headers = log.GetProperty<string>("headers");
        Assert.That(headers, Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Custom-Header:Value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Custom-Header:Value{Environment.NewLine}"));

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational, SystemClientModelEventSourceName);
        headers = log.GetProperty<string>("headers");
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:Very secret{Environment.NewLine}"));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStarsILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent([6, 7, 8, 9, 0]);

        loggingOptions.AllowedQueryParameters.Add("*");
        loggingOptions.AllowedHeaderNames.Add("*");

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "Value" },
            { "Content-Type", "text/json" }
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], requestHeaders: requestHeaders, requestUri: requestUri, loggingOptions: loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        string headers = (log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString();
        Assert.That(headers, Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Custom-Header:Value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Custom-Header:Value{Environment.NewLine}"));

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        headers = (log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString();
        Assert.That(headers, Does.Contain($"Custom-Response-Header:Improved value{Environment.NewLine}"));
        Assert.That(headers, Does.Contain($"Secret-Response-Header:Very secret{Environment.NewLine}"));
    }

    [Test]
    public async Task SendingARequestProducesRequestAndResponseLogMessagesEventSource() // RequestEvent, ResponseEvent
    {
        using TestClientEventListener listener = new();

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent);

        // Assert that the request log message is written and formatted correctly

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<string>("uri"), Is.EqualTo("http://example.com/"));
        Assert.That(log.GetProperty<string>("method"), Is.EqualTo("GET"));
        Assert.That(log.GetProperty<string>("headers"), Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That(log.GetProperty<string>("headers"), Does.Contain($"Custom-Header:custom-header-value{Environment.NewLine}"));

        // Assert that the response log message is written and formatted correctly

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<int>("status"), Is.EqualTo(200));
        Assert.That(log.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}"));

        // Assert that no other log messages were written
        Assert.That(listener.EventData.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task SendingARequestProducesRequestAndResponseLogMessagesILogger() // RequestEvent, ResponseEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent, loggingOptions: loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request log message is written and formatted correctly

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.RequestEvent, "Request", LogLevel.Information);
        Assert.That(log.GetValueFromArguments<string>("uri"), Is.EqualTo("http://example.com/"));
        Assert.That(log.GetValueFromArguments<string>("method"), Is.EqualTo("GET"));
        Assert.That((log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString(), Does.Contain($"Date:08/16/2024{Environment.NewLine}"));
        Assert.That((log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString(), Does.Contain($"Custom-Header:custom-header-value{Environment.NewLine}"));

        // Assert that the response log message is written and formatted correctly

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseEvent, "Response", LogLevel.Information);
        Assert.That(log.GetValueFromArguments<int>("status"), Is.EqualTo(200));
        Assert.That((log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString(), Does.Contain($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}"));

        // Assert that no other log messages were written
        Assert.That(logger.Logs.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task ReceivingAnErrorResponseProducesAnErrorResponseLogMessageEventSource() // ErrorResponseEvent, ErrorResponseContentEvent
    {
        using TestClientEventListener listener = new();

        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue
        };

        MockPipelineResponse response = new(400, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: [1, 2, 3, 4, 5]);

        // Assert that the error response log message is written and formatted correctly

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", EventLevel.Warning, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<int>("status"), Is.EqualTo(400));
        Assert.That(log.GetProperty<string>("headers"), Does.Contain($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}"));

        // Assert that the error response content log message is written and formatted correctly

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseContentEvent, "ErrorResponseContent", EventLevel.Informational, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<byte[]>("content"), Is.EqualTo(responseContent));
    }

    [Test]
    public async Task ReceivingAnErrorResponseProducesAnErrorResponseLogMessageILogger() // ErrorResponseEvent, ErrorResponseContentEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(400, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: [1, 2, 3, 4, 5], loggingOptions: loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the error response log message is written and formatted correctly

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", LogLevel.Warning);
        Assert.That(log.GetValueFromArguments<int>("status"), Is.EqualTo(400));
        Assert.That((log.GetValueFromArguments<PipelineMessageHeadersLogValue>("headers")).ToString(), Does.Contain($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}"));

        // Assert that the error response content log message is written and formatted correctly

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseContentEvent, "ErrorResponseContent", LogLevel.Information);
        Assert.That(log.GetValueFromArguments<byte[]>("content"), Is.EqualTo(responseContent));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAndResponseContentLogMessageEventSource() // RequestContentEvent, ResponseContentEvent
    {
        using TestClientEventListener listener = new();

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: requestContent);

        // Assert that the request content log message is written and formatted correctly

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<byte[]>("content"), Is.EqualTo(requestContent));

        // Assert that the response content log message is written and formatted correctly

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentEvent, "ResponseContent", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<byte[]>("content"), Is.EqualTo(responseContent));

        // Assert content was not written as text

        Assert.That(listener.EventsById(LoggingEventIds.RequestContentTextEvent), Is.Empty);
        Assert.That(listener.EventsById(LoggingEventIds.ResponseContentTextEvent), Is.Empty);
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAndResponseContentLogMessageILogger() // RequestContentEvent, ResponseContentEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent, loggingOptions: loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request content log message is written and formatted correctly

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", LogLevel.Debug);
        Assert.That(log.GetValueFromArguments<byte[]>("content"), Is.EqualTo(requestContent));

        // Assert that the response content log message is written and formatted correctly

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentEvent, "ResponseContent", LogLevel.Debug);
        Assert.That(log.GetValueFromArguments<byte[]>("content"), Is.EqualTo(responseContent));

        // Assert content was not written as text

        Assert.That(logger.EventsById(LoggingEventIds.RequestContentTextEvent), Is.Empty);
        Assert.That(logger.EventsById(LoggingEventIds.ResponseContentTextEvent), Is.Empty);
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAsTextAndResponseContentAsTextEventSource() // RequestContentTextEvent, ResponseContentTextEvent
    {
        using TestClientEventListener listener = new();

        string requestContent = "Hello";
        string responseContent = "World!";

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentString: requestContent);

        // Assert that the request content text event is written and formatted correctly

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<string>("content"), Is.EqualTo(requestContent));

        // Assert that the response content text event is written and formatted correctly

        log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.That(log.GetProperty<string>("content"), Is.EqualTo(responseContent));

        // Assert content was not written not as text

        Assert.That(listener.EventsById(LoggingEventIds.RequestContentEvent), Is.Empty);
        Assert.That(listener.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAsTextAndResponseContentAsTextILogger() // RequestContentTextEvent, ResponseContentTextEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        string requestContent = "Hello";
        string responseContent = "World!";

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentString: requestContent, loggingOptions: loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        // Assert that the request content text event is written and formatted correctly

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", LogLevel.Debug);
        Assert.That(log.GetValueFromArguments<string>("content"), Is.EqualTo(requestContent));

        // Assert that the response content text event is written and formatted correctly

        log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug);
        Assert.That(log.GetValueFromArguments<string>("content"), Is.EqualTo(responseContent));

        // Assert content was not written not as text

        Assert.That(logger.EventsById(LoggingEventIds.RequestContentEvent), Is.Empty);
        Assert.That(logger.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task ContentLoggingEnabledProducesResponseContentAsTextWithSeekableTextStreamEventSource() // ResponseContentTextEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, new ClientLoggingOptions(), int.MaxValue);

        EventWrittenEventArgs logEvent = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.That(logEvent.GetProperty<string>("content"), Is.EqualTo("Hello world"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesResponseContentAsTextWithSeekableTextStreamILogger() // ResponseContentTextEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, loggingOptions, int.MaxValue);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", LogLevel.Debug);
        Assert.That(logEvent.GetValueFromArguments<string>("content"), Is.EqualTo("Hello world"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesErrorResponseContentAsTextWithSeekableTextStreamEventSource() // ErrorResponseContentTextEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(500, true, _defaultTextHeaders, new ClientLoggingOptions(), 5);

        EventWrittenEventArgs logEvent = listener.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseContentTextEvent, "ErrorResponseContentText", EventLevel.Informational, SystemClientModelEventSourceName);
        Assert.That(logEvent.GetProperty<string>("content"), Is.EqualTo("Hello"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesErrorResponseContentAsTextWithSeekableTextStreamILogger() // ErrorResponseContentTextEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(500, true, _defaultTextHeaders, loggingOptions, 5);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent logEvent = logger.GetAndValidateSingleEvent(LoggingEventIds.ErrorResponseContentTextEvent, "ErrorResponseContentText", LogLevel.Information);
        Assert.That(logEvent.GetValueFromArguments<string>("content"), Is.EqualTo("Hello"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocksEventSource() // ResponseContentBlockEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] contentEvents = listener.EventsById(LoggingEventIds.ResponseContentBlockEvent).ToArray();

        Assert.That(contentEvents.Length, Is.EqualTo(2));

        Assert.That(contentEvents[0].Level, Is.EqualTo(EventLevel.Verbose));
        Assert.That(contentEvents[0].EventName, Is.EqualTo("ResponseContentBlock"));
        Assert.That(contentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(contentEvents[0].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));
        Assert.That(contentEvents[0].GetProperty<byte[]>("content"), Is.EqualTo("Hello "u8.ToArray()));

        Assert.That(contentEvents[1].Level, Is.EqualTo(EventLevel.Verbose));
        Assert.That(contentEvents[1].EventName, Is.EqualTo("ResponseContentBlock"));
        Assert.That(contentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(contentEvents[1].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));
        Assert.That(contentEvents[1].GetProperty<byte[]>("content"), Is.EqualTo("world"u8.ToArray()));

        Assert.That(listener.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocksILogger() // ResponseContentBlockEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultHeaders, loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] contentEvents = logger.EventsById(LoggingEventIds.ResponseContentBlockEvent).ToArray();

        Assert.That(contentEvents.Length, Is.EqualTo(2));

        Assert.That(contentEvents[0].LogLevel, Is.EqualTo(LogLevel.Debug));
        Assert.That(contentEvents[0].EventId.Name, Is.EqualTo("ResponseContentBlock"));
        Assert.That(contentEvents[0].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(contentEvents[0].GetValueFromArguments<byte[]>("content"), Is.EqualTo("Hello "u8.ToArray()));

        Assert.That(contentEvents[1].LogLevel, Is.EqualTo(LogLevel.Debug));
        Assert.That(contentEvents[1].EventId.Name, Is.EqualTo("ResponseContentBlock"));
        Assert.That(contentEvents[1].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(contentEvents[1].GetValueFromArguments<byte[]>("content"), Is.EqualTo("world"u8.ToArray()));

        Assert.That(logger.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponseErrorsAreLoggedInBlocksEventSource() // ErrorResponseContentBlockEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] errorContentEvents = listener.EventsById(LoggingEventIds.ErrorResponseContentBlockEvent).ToArray();

        Assert.That(errorContentEvents.Length, Is.EqualTo(2));

        Assert.That(errorContentEvents[0].Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(errorContentEvents[0].EventName, Is.EqualTo("ErrorResponseContentBlock"));
        Assert.That(errorContentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(errorContentEvents[0].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));
        Assert.That(errorContentEvents[0].GetProperty<byte[]>("content"), Is.EqualTo("Hello "u8.ToArray()));

        Assert.That(errorContentEvents[1].Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(errorContentEvents[1].EventName, Is.EqualTo("ErrorResponseContentBlock"));
        Assert.That(errorContentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(errorContentEvents[1].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));
        Assert.That(errorContentEvents[1].GetProperty<byte[]>("content"), Is.EqualTo("world"u8.ToArray()));

        Assert.That(listener.EventsById(LoggingEventIds.ErrorResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocksILogger() // ErrorResponseContentBlockEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultHeaders, loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] errorContentEvents = logger.EventsById(LoggingEventIds.ErrorResponseContentBlockEvent).ToArray();

        Assert.That(errorContentEvents.Length, Is.EqualTo(2));

        Assert.That(errorContentEvents[0].LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(errorContentEvents[0].EventId.Name, Is.EqualTo("ErrorResponseContentBlock"));
        Assert.That(errorContentEvents[0].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(errorContentEvents[0].GetValueFromArguments<byte[]>("content"), Is.EqualTo("Hello "u8.ToArray()));

        Assert.That(errorContentEvents[1].LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(errorContentEvents[1].EventId.Name, Is.EqualTo("ErrorResponseContentBlock"));
        Assert.That(errorContentEvents[1].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(errorContentEvents[1].GetValueFromArguments<byte[]>("content"), Is.EqualTo("world"u8.ToArray()));

        Assert.That(logger.EventsById(LoggingEventIds.ErrorResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocksEventSource() // ResponseContentTextBlockEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] contentEvents = listener.EventsById(LoggingEventIds.ResponseContentTextBlockEvent).ToArray();

        Assert.That(contentEvents.Length, Is.EqualTo(2));

        Assert.That(contentEvents[0].Level, Is.EqualTo(EventLevel.Verbose));

        Assert.That(contentEvents[0].EventName, Is.EqualTo("ResponseContentTextBlock"));
        Assert.That(contentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(contentEvents[0].GetProperty<string>("content"), Is.EqualTo("Hello "));
        Assert.That(contentEvents[0].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));

        Assert.That(contentEvents[1].Level, Is.EqualTo(EventLevel.Verbose));
        Assert.That(contentEvents[1].EventName, Is.EqualTo("ResponseContentTextBlock"));
        Assert.That(contentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(contentEvents[1].GetProperty<string>("content"), Is.EqualTo("world"));
        Assert.That(contentEvents[1].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));

        Assert.That(listener.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocksILogger() // ResponseContentTextBlockEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] contentEvents = logger.EventsById(LoggingEventIds.ResponseContentTextBlockEvent).ToArray();

        Assert.That(contentEvents.Length, Is.EqualTo(2));

        Assert.That(contentEvents[0].LogLevel, Is.EqualTo(LogLevel.Debug));

        Assert.That(contentEvents[0].EventId.Name, Is.EqualTo("ResponseContentTextBlock"));
        Assert.That(contentEvents[0].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(contentEvents[0].GetValueFromArguments<string>("content"), Is.EqualTo("Hello "));

        Assert.That(contentEvents[1].LogLevel, Is.EqualTo(LogLevel.Debug));
        Assert.That(contentEvents[1].EventId.Name, Is.EqualTo("ResponseContentTextBlock"));
        Assert.That(contentEvents[1].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(contentEvents[1].GetValueFromArguments<string>("content"), Is.EqualTo("world"));

        Assert.That(logger.EventsById(LoggingEventIds.ResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocksEventSource() // ErrorResponseContentTextBlockEvent
    {
        using TestClientEventListener listener = new();

        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultTextHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] errorContentEvents = listener.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent).ToArray();

        Assert.That(errorContentEvents.Length, Is.EqualTo(2));

        Assert.That(errorContentEvents[0].Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(errorContentEvents[0].EventName, Is.EqualTo("ErrorResponseContentTextBlock"));
        Assert.That(errorContentEvents[0].GetProperty<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(errorContentEvents[0].GetProperty<string>("content"), Is.EqualTo("Hello "));
        Assert.That(errorContentEvents[0].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));

        Assert.That(errorContentEvents[1].Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(errorContentEvents[1].EventName, Is.EqualTo("ErrorResponseContentTextBlock"));
        Assert.That(errorContentEvents[1].GetProperty<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(errorContentEvents[1].GetProperty<string>("content"), Is.EqualTo("world"));
        Assert.That(errorContentEvents[1].EventSource.Name, Is.EqualTo(SystemClientModelEventSourceName));

        Assert.That(listener.EventsById(LoggingEventIds.ErrorResponseContentEvent), Is.Empty);
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocksILogger() // ErrorResponseContentTextBlockEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new() { LoggerFactory = factory };

        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultTextHeaders, loggingOptions);
        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        LoggerEvent[] errorContentEvents = logger.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent).ToArray();

        Assert.That(errorContentEvents.Length, Is.EqualTo(2));

        Assert.That(errorContentEvents[0].LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(errorContentEvents[0].EventId.Name, Is.EqualTo("ErrorResponseContentTextBlock"));
        Assert.That(errorContentEvents[0].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(0));
        Assert.That(errorContentEvents[0].GetValueFromArguments<string>("content"), Is.EqualTo("Hello "));

        Assert.That(errorContentEvents[1].LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(errorContentEvents[1].EventId.Name, Is.EqualTo("ErrorResponseContentTextBlock"));
        Assert.That(errorContentEvents[1].GetValueFromArguments<int>("blockNumber"), Is.EqualTo(1));
        Assert.That(errorContentEvents[1].GetValueFromArguments<string>("content"), Is.EqualTo("world"));

        Assert.That(logger.EventsById(LoggingEventIds.ErrorResponseContentEvent), Is.Empty);
    }

    #endregion

    #region Helpers

    private class TestEventListenerWarning : TestClientEventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "System.ClientModel")
            {
                Console.WriteLine("Warning");
                EnableEvents(eventSource, EventLevel.Warning);
            }
        }
    }

    private async Task CreatePipelineAndSendRequestWithStreamingResponse(int statusCode,
                                                                         bool isSeekable,
                                                                         MockResponseHeaders responseHeaders,
                                                                         ClientLoggingOptions loggingOptions,
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

        loggingOptions.EnableMessageContentLogging = true;
        loggingOptions.MessageContentSizeLimit = maxLength;

        // These tests are essentially testing whether the logging policy works
        // correctly when responses are buffered (memory stream) and unbuffered
        // (non-seekable). In order to validate the intent of the test, we set
        // message.BufferResponse accordingly here.
        await CreatePipelineAndSendRequest(response, loggingOptions, bufferResponse: isSeekable);

        var buffer = new byte[11];

        if (IsAsync)
        {
#if NET462
            Assert.That(await response.ContentStream.ReadAsync(buffer, 5, 6), Is.EqualTo(6));
            Assert.That(await response.ContentStream.ReadAsync(buffer, 6, 5), Is.EqualTo(5));
            Assert.That(await response.ContentStream.ReadAsync(buffer, 0, 5), Is.EqualTo(0));
#else
            Assert.That(await response.ContentStream.ReadAsync(buffer.AsMemory(5, 6)), Is.EqualTo(6));
            Assert.That(await response.ContentStream.ReadAsync(buffer.AsMemory(6, 5)), Is.EqualTo(5));
            Assert.That(await response.ContentStream.ReadAsync(buffer.AsMemory(0, 5)), Is.EqualTo(0));
#endif
        }
        else
        {
            Assert.That(response.ContentStream.Read(buffer, 5, 6), Is.EqualTo(6));
            Assert.That(response.ContentStream.Read(buffer, 6, 5), Is.EqualTo(5));
            Assert.That(response.ContentStream.Read(buffer, 0, 5), Is.EqualTo(0));
        }
    }

    private async Task CreatePipelineAndSendRequest(MockPipelineResponse response,
                                                    ClientLoggingOptions? loggingOptions = default,
                                                    string? requestContentString = default,
                                                    byte[]? requestContentBytes = default,
                                                    Dictionary<string, string>? requestHeaders = default,
                                                    Uri? requestUri = default,
                                                    bool? bufferResponse = default)
    {
        ClientLoggingOptions clientLoggingOptions = loggingOptions ?? new ClientLoggingOptions();
        clientLoggingOptions.AllowedHeaderNames.Add("Custom-Header");
        clientLoggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = clientLoggingOptions,
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
