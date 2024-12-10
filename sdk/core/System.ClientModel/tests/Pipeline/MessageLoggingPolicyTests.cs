// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

public class MessageLoggingPolicyTests(bool isAsync) : SyncAsyncTestBase(isAsync)
{
    private const string LoggingPolicyCategoryName = "System.ClientModel.Primitives.MessageLoggingPolicy";
    private const string PipelineTransportCategoryName = "System.ClientModel.Primitives.PipelineTransport";
    private const string RetryPolicyCategoryName = "System.ClientModel.Primitives.ClientRetryPolicy";
    private const string SystemClientModelEventSourceName = "System-ClientModel";

    [Test]
    public async Task SendingRequestLogsToILoggerAndNotEventSourceWhenILoggerIsProvided()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Debug);

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent("World.");

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response, true, factory, false),
            ClientLoggingOptions = loggingOptions,
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData("Hello"));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        TestLogger logger = factory.GetLogger(LoggingPolicyCategoryName);

        GetSingleEventFromILogger(1, "Request", LogLevel.Information, logger); // RequestEvent
        GetSingleEventFromILogger(5, "Response", LogLevel.Information, logger); // ResponseEvent

        CollectionAssert.IsEmpty(listener.EventData); // Nothing should log to Event Source
    }

    [Test]
    public async Task SendingRequestLogsToILoggerAndNotEventSourceWhenILoggerIsProvidedAndLogLevelIsWarning()
    {
        using TestClientEventListener listener = new(); // Verbose listener
        using TestLoggingFactory factory = new(LogLevel.Warning); // Warnings only

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent("World.");

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response, true, factory, false),
            ClientLoggingOptions = loggingOptions,
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData("Hello "));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        CollectionAssert.IsEmpty(listener.EventData);
        CollectionAssert.IsEmpty(factory.GetLogger(RetryPolicyCategoryName).Logs);
        CollectionAssert.IsEmpty(factory.GetLogger(PipelineTransportCategoryName).Logs);
        CollectionAssert.IsEmpty(factory.GetLogger(LoggingPolicyCategoryName).Logs);
    }

    #region Helpers

    // In order to test listeners with different event levels, each case has to has its own listener.
    // This is because the constructor does not necessarily finish before the callbacks are called, meaning that any runtime
    // configurations to event listener classes aren't reliably applied.
    // see: https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventlistener#remarks

    private class TestEventListenerWarning : TestClientEventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "ClientModel.Tests.TestLoggingEventSource")
            {
                EnableEvents(eventSource, EventLevel.Warning);
            }
        }
    }

    private static LoggerEvent GetSingleEventFromILogger(int id, string expectedEventName, LogLevel expectedLogLevel, TestLogger logger)
    {
        LoggerEvent log = logger.SingleEventById(id);
        Assert.AreEqual(expectedEventName, log.EventId.Name);
        Assert.AreEqual(expectedLogLevel, log.LogLevel);
        Guid.Parse(log.GetValueFromArguments<string>("requestId")); // Request id should be a guid

        return log;
    }

    private static EventWrittenEventArgs GetSingleEventFromEventSource(int id, string expectedEventName, EventLevel expectedLogLevel, TestClientEventListener listener)
    {
        EventWrittenEventArgs e = listener.SingleEventById(id);
        Assert.AreEqual(expectedEventName, e.EventName);
        Assert.AreEqual(expectedLogLevel, e.Level);
        Assert.AreEqual(SystemClientModelEventSourceName, e.EventSource.Name);
        Guid.Parse(e.GetProperty<string>("requestId")); // Request id should be a guid

        return e;
    }

    #endregion
}
