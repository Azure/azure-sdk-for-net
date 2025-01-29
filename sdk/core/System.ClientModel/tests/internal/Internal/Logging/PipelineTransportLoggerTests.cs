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
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

// Avoid running these tests in parallel with anything else that's sharing the event source
[NonParallelizable]
public class PipelineTransportLoggerTests : SyncAsyncPolicyTestBase
{
    private const string PipelineTransportCategoryName = "System.ClientModel.Primitives.PipelineTransport";
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

    public PipelineTransportLoggerTests(bool isAsync) : base(isAsync)
    {
    }

    #region Unit tests

    [Test]
    public void LogsAreLoggedToILoggerAndNotEventSourceWhenILoggerIsProvided()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Debug);

        PipelineTransportLogger transportLogger = new(factory);

        transportLogger.LogExceptionResponse("requestId", new InvalidOperationException());
        transportLogger.LogResponseDelay("requestId", 1);

        TestLogger logger = factory.GetLogger(PipelineTransportCategoryName);
        logger.SingleEventById(7); // ResponseDelay
        logger.SingleEventById(18); // ExceptionResponse

        CollectionAssert.IsEmpty(listener.EventData);
    }

    [Test]
    public void LogsAreLoggedToILoggerAndNotEventSourceWhenILoggerIsProvidedAndLogLevelIsWarning()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Warning);

        PipelineTransportLogger transportLogger = new(factory);

        transportLogger.LogExceptionResponse("requestId", new InvalidOperationException());
        transportLogger.LogResponseDelay("requestId", 1);

        TestLogger logger = factory.GetLogger(PipelineTransportCategoryName);
        logger.SingleEventById(7); // ResponseDelay

        CollectionAssert.IsEmpty(listener.EventData);
    }

    #endregion

    #region Integration tests

    [Test]
    public void GettingExceptionResponseProducesEventsEventSource() // ExceptionResponseEvent
    {
        using TestClientEventListener listener = new();

        var exception = new InvalidOperationException();

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception, true, null, false),
            ClientLoggingOptions = new()
            {
                EnableMessageContentLogging = true
            }
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.ExceptionResponseEvent, "ExceptionResponse", EventLevel.Informational, SystemClientModelEventSourceName);
        Assert.AreEqual(exception.ToString().Split(Environment.NewLine.ToCharArray())[0], log.GetProperty<string>("exception").Split(Environment.NewLine.ToCharArray())[0]);
    }

    [Test]
    public void GettingExceptionResponseProducesEventsILogger() // ExceptionResponseEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        var exception = new InvalidOperationException();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            LoggerFactory = factory
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", (PipelineMessage i) => throw exception, true, factory),
            ClientLoggingOptions = loggingOptions
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add("User-Agent", "agent");

        Assert.ThrowsAsync<InvalidOperationException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));
        TestLogger logger = factory.GetLogger(PipelineTransportCategoryName);

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.ExceptionResponseEvent, "ExceptionResponse", LogLevel.Information);
        Assert.AreEqual(exception, log.Exception);
    }

    [Test]
    public async Task ResponseReceivedAfterThreeSecondsProducesResponseDelayEventEventSource() // ResponseDelayEvent
    {
        using TestClientEventListener listener = new();

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response, true, null, true),
            ClientLoggingOptions = new(),
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Assert that the response delay log message is written and formatted correctly

        EventWrittenEventArgs log = listener.GetAndValidateSingleEvent(LoggingEventIds.ResponseDelayEvent, "ResponseDelay", EventLevel.Warning, SystemClientModelEventSourceName);
        Assert.Greater(log.GetProperty<double>("seconds"), 3);
    }

    [Test]
    public async Task ResponseReceivedAfterThreeSecondsProducesResponseDelayEventILogger() // ResponseDelayEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        MockPipelineResponse response = new(200, mockHeaders: _defaultHeaders);
        response.SetContent(responseContent);

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true,
            LoggerFactory = factory
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response, true, factory, true),
            ClientLoggingOptions = loggingOptions,
            RetryPolicy = new ObservablePolicy("RetryPolicy")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);
        TestLogger logger = factory.GetLogger(PipelineTransportCategoryName);

        // Assert that the response log message is written and formatted correctly

        LoggerEvent log = logger.GetAndValidateSingleEvent(LoggingEventIds.ResponseDelayEvent, "ResponseDelay", LogLevel.Warning);
        Assert.Greater(log.GetValueFromArguments<double>("seconds"), 3);
    }

    #endregion
}
