// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
    private const string SystemClientModelEventSourceName = "System-ClientModel";
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

    private TestClientEventListener _listener;

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

    #region Configuration tests

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentIsNotLoggedWhenDisabled(bool isError)
    {
        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false
        };

        var response = new MockPipelineResponse(isError ? 500 : 200);
        response.SetContent(new byte[] { 1, 2, 3 });

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: Encoding.UTF8.GetBytes(("Hello world")));

        AssertNoContentLogged();
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentIsNotLoggedAsTextWhenDisabled(bool isError)
    {
        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false,
            MessageContentSizeLimit = int.MaxValue // TODO - should this config throw
        };

        MockPipelineResponse response = new(isError ? 500 : 200, mockHeaders: _defaultTextHeaders)
        {
            ContentStream = new MemoryStream(new byte[] { 1, 2, 3 })
        };

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentString: "TextRequestContent");

        AssertNoContentLogged();
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ContentIsNotLoggedInBlocksWhenDisabled(bool isError)
    {
        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false
        };

        MockPipelineResponse response = new(isError ? 500 : 200)
        {
            ContentStream = new NonSeekableMemoryStream(new byte[] { 1, 2, 3 })
        };

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: Encoding.UTF8.GetBytes("Hello world"));

        AssertNoContentLogged();
    }

    [Test]
    public Task RequestContentLogsAreLimitedInLength()
    {
        throw new NotImplementedException();
    }

    [Test]
    public async Task RequestContentTextLogsAreLimitedInLength()
    {
        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = 5
        };
        MockPipelineResponse response = new(500, mockHeaders: _defaultTextHeaders);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentString: "Hello world");

        EventWrittenEventArgs requestEvent = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", EventLevel.Verbose);
        Assert.AreEqual("Hello", requestEvent.GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, new ClientLoggingOptions(), 5);

        EventWrittenEventArgs contentEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose);
        Assert.AreEqual("Hello", contentEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLength()
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, new ClientLoggingOptions(), 5);

        EventWrittenEventArgs responseEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextBlockEvent, "ResponseContentTextBlock", EventLevel.Verbose);
        Assert.AreEqual("Hello", responseEvent.GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task HeadersAndQueryParametersAreSanitizedInRequestAndResponseEvents() // Request event and response event sanitize headers
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

        // Assert that headers on the request are sanitized

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational);
        string headers = log.GetProperty<string>("headers");
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", headers);
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Custom-Header:REDACTED{Environment.NewLine}", headers);
        StringAssert.DoesNotContain("secret-value", headers);

        // Assert that headers on the response are sanitized

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational);
        headers = log.GetProperty<string>("headers");
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

        await CreatePipelineAndSendRequest(response, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 }, requestHeaders: requestHeaders, requestUri: requestUri);

        // Assert that headers on the response are sanitized

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", EventLevel.Informational);
        string headers = log.GetProperty<string>("headers");
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Response-Header:REDACTED{Environment.NewLine}", headers);
        StringAssert.DoesNotContain("Very Secret", headers);
    }

    [Test]
    public async Task HeadersAndQueryParametersAreNotSanitizedWhenStars()
    {
        var mockHeaders = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Improved value" }, { "Secret-Response-Header", "Very secret" } });
        var response = new MockPipelineResponse(200, mockHeaders: mockHeaders);
        response.SetContent(new byte[] { 6, 7, 8, 9, 0 });

        ClientLoggingOptions loggingOptions = new();
        loggingOptions.AllowedQueryParameters.Add("*");
        loggingOptions.AllowedHeaderNames.Add("*");

        Uri requestUri = new("https://contoso.a.io?api-version=5&secret=123");

        Dictionary<string, string> requestHeaders = new()
        {
            { "Secret-Custom-Header", "Value" },
            { "Content-Type", "text/json" }
        };

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 }, requestHeaders: requestHeaders, requestUri: requestUri);

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational);
        string headers = log.GetProperty<string>("headers");
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", headers);
        StringAssert.Contains($"Custom-Header:Value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Custom-Header:Value{Environment.NewLine}", headers);

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational);
        headers = log.GetProperty<string>("headers");
        StringAssert.Contains($"Custom-Response-Header:Improved value{Environment.NewLine}", headers);
        StringAssert.Contains($"Secret-Response-Header:Very secret{Environment.NewLine}", headers);
    }

    #endregion

    #region Log messages: pipeline message logger

    [Test]
    public async Task SendingARequestProducesRequestAndResponseLogMessages() // RequestEvent, ResponseEvent
    {
        byte[] requestContent = new byte[] { 1, 2, 3, 4, 5 };
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, requestContentBytes: requestContent);

        // Assert that the request log message is written and formatted correctly

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.RequestEvent, "Request", EventLevel.Informational);
        Assert.AreEqual("http://example.com/", log.GetProperty<string>("uri"));
        Assert.AreEqual("GET", log.GetProperty<string>("method"));
        StringAssert.Contains($"Date:08/16/2024{Environment.NewLine}", log.GetProperty<string>("headers"));
        StringAssert.Contains($"Custom-Header:custom-header-value{Environment.NewLine}", log.GetProperty<string>("headers"));

        // Assert that the response log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseEvent, "Response", EventLevel.Informational);
        Assert.AreEqual(log.GetProperty<int>("status"), 200);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetProperty<string>("headers"));

        // Assert that no other log messages were written
        Assert.AreEqual(_listener.EventData.Count(), 2);
    }

    [Test]
    public async Task ReceivingAnErrorResponseProducesAnErrorResponseLogMessage() // ErrorResponseEvent, ErrorResponseContentEvent
    {
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue
        };

        MockPipelineResponse response = new(400, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: new byte[] { 1, 2, 3, 4, 5 });

        // Assert that the error response log message is written and formatted correctly

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.ErrorResponseEvent, "ErrorResponse", EventLevel.Warning);
        Assert.AreEqual(log.GetProperty<int>("status"), 400);
        StringAssert.Contains($"Custom-Response-Header:custom-response-header-value{Environment.NewLine}", log.GetProperty<string>("headers"));

        // Assert that the error response content log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ErrorResponseContentEvent, "ErrorResponseContent", EventLevel.Informational);
        CollectionAssert.AreEqual(responseContent, log.GetProperty<byte[]>("content"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAndResponseContentLogMessage() // RequestContentEvent, ResponseContentEvent
    {
        byte[] requestContent = new byte[] { 1, 2, 3, 4, 5 };
        byte[] responseContent = new byte[] { 6, 7, 8, 9, 0 };

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = int.MaxValue
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        await CreatePipelineAndSendRequest(response, loggingOptions, requestContentBytes: requestContent);

        // Assert that the request content log message is written and formatted correctly

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.RequestContentEvent, "RequestContent", EventLevel.Verbose);
        Assert.AreEqual(requestContent, log.GetProperty<byte[]>("content"));

        // Assert that the response content log message is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseContentEvent, "ResponseContent", EventLevel.Verbose);
        Assert.AreEqual(responseContent, log.GetProperty<byte[]>("content"));

        // Assert content was not written as text

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.RequestContentTextEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentTextEvent));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesRequestContentAsTextAndResponseContentAsText() // RequestContentTextEvent, ResponseContentTextEvent
    {
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

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.RequestContentTextEvent, "RequestContentText", EventLevel.Verbose);
        Assert.AreEqual(requestContent, log.GetProperty<string>("content"));

        // Assert that the response content text event is written and formatted correctly

        log = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose);
        Assert.AreEqual(responseContent, log.GetProperty<string>("content"));

        // Assert content was not written not as text

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.RequestContentEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesResponseContentAsTextWithSeekableTextStream() // ResponseContentTextEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, true, _defaultTextHeaders, new ClientLoggingOptions(), int.MaxValue);

        EventWrittenEventArgs logEvent = GetSingleEvent(LoggingEventIds.ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose);
        Assert.AreEqual("Hello world", logEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task ContentLoggingEnabledProducesErrorResponseContentAsTextWithSeekableTextStream() // ErrorResponseContentTextEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, true, _defaultTextHeaders, new ClientLoggingOptions(), 5);

        EventWrittenEventArgs logEvent = GetSingleEvent(LoggingEventIds.ErrorResponseContentTextEvent, "ErrorResponseContentText", EventLevel.Informational);
        Assert.AreEqual("Hello", logEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInBlocks() // ResponseContentBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] contentEvents = _listener.EventsById(LoggingEventIds.ResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);
        Assert.AreEqual("ResponseContentBlock", contentEvents[0].EventName);
        Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, contentEvents[0].GetProperty<byte[]>("content"));

        Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
        Assert.AreEqual("ResponseContentBlock", contentEvents[1].EventName);
        Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, contentEvents[1].GetProperty<byte[]>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInBlocks() // ErrorResponseContentBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(LoggingEventIds.ErrorResponseContentBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[0].EventName);
        Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111, 32 }, errorContentEvents[0].GetProperty<byte[]>("content"));

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
        Assert.AreEqual("ErrorResponseContentBlock", errorContentEvents[1].EventName);
        Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
        CollectionAssert.AreEqual(new byte[] { 119, 111, 114, 108, 100 }, errorContentEvents[1].GetProperty<byte[]>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesAreLoggedInTextBlocks() // ResponseContentTextBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(200, false, _defaultTextHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] contentEvents = _listener.EventsById(LoggingEventIds.ResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, contentEvents.Length);

        Assert.AreEqual(EventLevel.Verbose, contentEvents[0].Level);

        Assert.AreEqual("ResponseContentTextBlock", contentEvents[0].EventName);
        Assert.AreEqual(0, contentEvents[0].GetProperty<int>("blockNumber"));
        Assert.AreEqual("Hello ", contentEvents[0].GetProperty<string>("content"));

        Assert.AreEqual(EventLevel.Verbose, contentEvents[1].Level);
        Assert.AreEqual("ResponseContentTextBlock", contentEvents[1].EventName);
        Assert.AreEqual(1, contentEvents[1].GetProperty<int>("blockNumber"));
        Assert.AreEqual("world", contentEvents[1].GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
    }

    [Test]
    public async Task NonSeekableResponsesErrorsAreLoggedInTextBlocks() // ErrorResponseContentTextBlockEvent
    {
        await CreatePipelineAndSendRequestWithStreamingResponse(500, false, _defaultTextHeaders, new ClientLoggingOptions());

        EventWrittenEventArgs[] errorContentEvents = _listener.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent).ToArray();

        Assert.AreEqual(2, errorContentEvents.Length);

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[0].Level);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[0].EventName);
        Assert.AreEqual(0, errorContentEvents[0].GetProperty<int>("blockNumber"));
        Assert.AreEqual("Hello ", errorContentEvents[0].GetProperty<string>("content"));

        Assert.AreEqual(EventLevel.Informational, errorContentEvents[1].Level);
        Assert.AreEqual("ErrorResponseContentTextBlock", errorContentEvents[1].EventName);
        Assert.AreEqual(1, errorContentEvents[1].GetProperty<int>("blockNumber"));
        Assert.AreEqual("world", errorContentEvents[1].GetProperty<string>("content"));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ErrorResponseContentEvent));
    }

    #endregion

    #region Log messages: pipeline transport logger

    [Test]
    public void GettingExceptionResponseProducesEvents() // ExceptionResponseEvent
    {
        var exception = new InvalidOperationException();

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception),
            ClientLoggingOptions = new()
            {
                EnableMessageContentLogging = true
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        //Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        EventWrittenEventArgs log = GetSingleEvent(LoggingEventIds.ExceptionResponseEvent, "ExceptionResponse", EventLevel.Informational);
        Assert.AreEqual(exception.ToString(), log.GetProperty<string>("exception"));
    }

    [Test]
    public Task ResponseReceivedAfterThreeSecondsProducesResponseDelayEvent() // ResponseDelayEvent
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Log messages: pipeline retry logger

    [Test]
    public Task SendingRequestThatIsRetriedProducesRequestRetryingEventOnEachRetry() // RequestRetryingEvent
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Helpers

    private EventWrittenEventArgs GetSingleEvent(int id, string expectedEventName, EventLevel expectedLogLevel)
    {
        EventWrittenEventArgs e = _listener.SingleEventById(id);
        Assert.AreEqual(expectedEventName, e.EventName);
        Assert.AreEqual(expectedLogLevel, e.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Guid.Parse(e.GetProperty<string>("requestId")); // Request id should be a guid

        return e;
    }

    private void AssertNoContentLogged()
    {
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.RequestContentEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.RequestContentTextEvent));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentBlockEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ResponseContentTextBlockEvent));

        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ErrorResponseContentEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ErrorResponseContentTextEvent));
        CollectionAssert.IsEmpty(_listener.EventsById(LoggingEventIds.ErrorResponseContentTextBlockEvent));
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
        //Assert.AreEqual(LoggingPolicyCategoryName, _logger.Name);

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
