// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

// Avoid running these tests in parallel with anything else that's sharing the event source
[NonParallelizable]
public class MessageLoggingPolicyTests(bool isAsync) : SyncAsyncTestBase(isAsync)
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
    private const string PipelineTransportCategoryName = "System.ClientModel.Primitives.PipelineTransport";
    private const string RetryPolicyCategoryName = "System.ClientModel.Primitives.ClientRetryPolicy";
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

    [Test]
    public async Task OptionsCanBeUpdatedUntilFrozenByPipeline()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        MessageLoggingPolicy loggingPolicy = new(loggingOptions);

        ClientPipelineOptions options = new()
        {
            MessageLoggingPolicy = loggingPolicy,
            Transport = new MockPipelineTransport("Transport", [200])
        };

        loggingOptions.EnableMessageContentLogging = true;

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData([1,2,3]));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.GetAndValidateSingleEvent(RequestContentEvent, "RequestContent", LogLevel.Debug);
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedByDefaultToEventSource(bool isError, bool asText)
    {
        using TestClientEventListener listener = new();
        ClientLoggingOptions loggingOptions = new();

        await SendSimpleRequestResponseSyncOrAsync(isError, loggingOptions, asText, IsAsync);

        listener.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedByDefaultToILogger(bool isError, bool asText)
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        await SendSimpleRequestResponseSyncOrAsync(isError, loggingOptions, asText, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedWhenDisabledToEventSource(bool isError, bool asText)
    {
        using TestClientEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false
        };

        await SendSimpleRequestResponseSyncOrAsync(isError, loggingOptions, asText, IsAsync);

        listener.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedWhenDisabledToILogger(bool isError, bool asText)
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false,
            LoggerFactory = factory
        };

        await SendSimpleRequestResponseSyncOrAsync(isError, loggingOptions, asText, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedInBlocksWhenDisabledToEventSource(bool isError, bool asText)
    {
        using TestClientEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false
        };

        MockPipelineResponse response = new(isError ? 500 : 200, mockHeaders: asText ? _defaultTextHeaders : _defaultHeaders)
        {
            ContentStream = new NonSeekableMemoryStream(Encoding.UTF8.GetBytes("Hello world"))
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        listener.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedInBlocksWhenDisabledToILogger(bool isError, bool asText)
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = false,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(isError ? 500 : 200, mockHeaders: asText ? _defaultTextHeaders : _defaultHeaders)
        {
            ContentStream = new NonSeekableMemoryStream(Encoding.UTF8.GetBytes("Hello world"))
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.AssertNoContentLogged();
    }

    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    [Test]
    public async Task ContentIsNotLoggedWhenEventSourceIsDisabled(bool isError, bool asText)
    {
        using TestEventListenerWarning listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true
        };

        await SendSimpleRequestResponseSyncOrAsync(isError, loggingOptions, asText, IsAsync);

        listener.AssertNoContentLogged();
    }

    [TestCase(true)]
    [TestCase(false)]
    [Test]
    public async Task ContentEventIsNotWrittenWhenThereIsNoContentToEventSource(bool isError)
    {
        using TestClientEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true
        };

        MockPipelineResponse response = new(isError ? 500 : 200);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        listener.AssertNoContentLogged();
    }

    [TestCase(true)]
    [TestCase(false)]
    [Test]
    public async Task ContentEventIsNotWrittenWhenThereIsNoContentToILogger(bool isError)
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(isError ? 500 : 200);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        logger.AssertNoContentLogged();
    }

    [Test]
    public async Task RequestContentLogsAreLimitedInLengthToEventSource()
    {
        using TestClientEventListener listener = new();

        var response = new MockPipelineResponse(500);
        byte[] requestContent = [1, 2, 3, 4, 5, 6, 7, 8];
        byte[] requestContentLimited = [1, 2, 3, 4, 5];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = 5
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs logEvent = listener.GetAndValidateSingleEvent(RequestContentEvent, "RequestContent", EventLevel.Verbose, SystemClientModelEventSourceName); // RequestContentEvent
        Assert.AreEqual(requestContentLimited, logEvent.GetProperty<byte[]>("content"));
        CollectionAssert.IsEmpty(listener.EventsById(RequestContentTextEvent));
    }

    [Test]
    public async Task RequestContentLogsAreLimitedInLengthToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        var response = new MockPipelineResponse(500);
        byte[] requestContent = [1, 2, 3, 4, 5, 6, 7, 8];
        byte[] requestContentLimited = [1, 2, 3, 4, 5];

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = 5,
            LoggerFactory = factory
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory!.GetLogger(LoggingPolicyCategoryName);
        LoggerEvent logEvent = logger.GetAndValidateSingleEvent(RequestContentEvent, "RequestContent", LogLevel.Debug);
        Assert.AreEqual(requestContentLimited, logEvent.GetValueFromArguments<byte[]>("content"));
        CollectionAssert.IsEmpty(logger.EventsById(RequestContentTextEvent));
    }

    [Test]
    public async Task RequestContentTextLogsAreLimitedInLengthToEventSource()
    {
        using TestClientEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = 5
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData("Hello world"));
        message.Request.Headers.Add("Content-Type", "text/plain");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs requestEvent = listener!.GetAndValidateSingleEvent(RequestContentTextEvent, "RequestContentText", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.AreEqual("Hello", requestEvent.GetProperty<string>("content"));

        CollectionAssert.IsEmpty(listener!.EventsById(RequestContentEvent));
    }

    [Test]
    public async Task RequestContentTextLogsAreLimitedInLengthToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            MessageContentSizeLimit = 5,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(500, mockHeaders: _defaultTextHeaders);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData("Hello world"));
        message.Request.Headers.Add("Content-Type", "text/plain");

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        LoggerEvent logEvent = logger.GetAndValidateSingleEvent(RequestContentTextEvent, "RequestContentText", LogLevel.Debug);
        Assert.AreEqual("Hello", logEvent.GetValueFromArguments<string>("content"));
        CollectionAssert.IsEmpty(logger.EventsById(RequestContentEvent)); // RequestContentEvent
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLengthToEventSource()
    {
        using TestClientEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            MessageContentSizeLimit = 5,
            EnableMessageContentLogging = true
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        await SendRequestWithStreamingResponseSyncOrAsync(response, true, loggingOptions);

        EventWrittenEventArgs contentEvent = listener.GetAndValidateSingleEvent(ResponseContentTextEvent, "ResponseContentText", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.AreEqual("Hello", contentEvent.GetProperty<string>("content"));
    }

    [Test]
    public async Task SeekableTextResponsesAreLimitedInLengthToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new()
        {
            MessageContentSizeLimit = 5,
            EnableMessageContentLogging = true,
            LoggerFactory = factory
        };

        MockPipelineResponse response = new(200, mockHeaders: _defaultTextHeaders);
        await SendRequestWithStreamingResponseSyncOrAsync(response, true, loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        LoggerEvent contentEvent = logger.GetAndValidateSingleEvent(13, "ResponseContentText", LogLevel.Debug);
        Assert.AreEqual("Hello", contentEvent.GetValueFromArguments<string>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLengthEventSource()
    {
        using TestClientEventListener listener = new();
        ClientLoggingOptions loggingOptions = new()
        {
            MessageContentSizeLimit = 5,
            EnableMessageContentLogging = true
        };
        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);

        await SendRequestWithStreamingResponseSyncOrAsync(response, false, loggingOptions);

        EventWrittenEventArgs responseEvent = listener.GetAndValidateSingleEvent(11, "ResponseContentBlock", EventLevel.Verbose, SystemClientModelEventSourceName);
        Assert.AreEqual(Encoding.UTF8.GetBytes("Hello"), responseEvent.GetProperty<byte[]>("content"));
    }

    [Test]
    public async Task NonSeekableResponsesAreLimitedInLengthILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientLoggingOptions loggingOptions = new()
        {
            MessageContentSizeLimit = 5,
            EnableMessageContentLogging = true,
            LoggerFactory = factory
        };
        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);

        await SendRequestWithStreamingResponseSyncOrAsync(response, false, loggingOptions);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);
        LoggerEvent responseEvent = logger.GetAndValidateSingleEvent(11, "ResponseContentBlock", LogLevel.Debug);
        Assert.AreEqual(Encoding.UTF8.GetBytes("Hello"), responseEvent.GetValueFromArguments<byte[]>("content"));
    }

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

    private async Task SendRequestWithStreamingResponseSyncOrAsync(MockPipelineResponse response,
                                                                   bool isSeekable,
                                                                   ClientLoggingOptions loggingOptions)
    {
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
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
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
#if NET462
            Assert.AreEqual(6, await response.ContentStream.ReadAsync(buffer, 5, 6));
            Assert.AreEqual(5, await response.ContentStream.ReadAsync(buffer, 6, 5));
            Assert.AreEqual(0, await response.ContentStream.ReadAsync(buffer, 0, 5));
#else
            Assert.AreEqual(6, await response.ContentStream.ReadAsync(buffer.AsMemory(5, 6)));
            Assert.AreEqual(5, await response.ContentStream.ReadAsync(buffer.AsMemory(6, 5)));
            Assert.AreEqual(0, await response.ContentStream.ReadAsync(buffer.AsMemory(0, 5)));
#endif
        }
        else
        {
            Assert.AreEqual(6, response.ContentStream.Read(buffer, 5, 6));
            Assert.AreEqual(5, response.ContentStream.Read(buffer, 6, 5));
            Assert.AreEqual(0, response.ContentStream.Read(buffer, 0, 5));
        }
    }

    private async Task SendSimpleRequestResponseSyncOrAsync(bool isError, ClientLoggingOptions loggingOptions, bool contentAsText, bool isAsync)
    {
        MockPipelineResponse response = new(isError ? 500 : 200);
        response.SetContent([1, 2, 3]);

        loggingOptions.AllowedHeaderNames.Add("Custom-Header");
        loggingOptions.AllowedHeaderNames.Add("Custom-Response-Header");

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("Custom-Header", "custom-header-value");
        message.Request.Headers.Add("Date", "08/16/2024");

        if (contentAsText)
        {
            response.SetContent("ResponseAsText");
            message.Request.Content = BinaryContent.Create(new BinaryData("RequestAsText"));
            message.Request.Headers.Add("Content-Type", "text/plain");
        }
        else
        {
            response.SetContent([1, 2, 3]);
            message.Request.Content = BinaryContent.Create(new BinaryData(Encoding.UTF8.GetBytes("Hello world")));
        }

        await pipeline.SendSyncOrAsync(message, IsAsync);
    }

    #endregion
}
