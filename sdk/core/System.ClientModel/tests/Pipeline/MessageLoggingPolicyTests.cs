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
        using TestEventListenerVerbose listener = new();
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

        GetSingleEventFromILogger(1, "Request", LogLevel.Debug, logger); // RequestEvent
        GetSingleEventFromILogger(5, "Response", LogLevel.Debug, logger); // ResponseEvent

        CollectionAssert.IsEmpty(listener.EventData); // Nothing should log to Event Source
    }

    [Test]
    public async Task SendingRequestLogsToILoggerAndNotEventSourceWhenILoggerIsProvidedAndLogLevelIsWarning()
    {
        using TestEventListenerVerbose listener = new(); // Verbose listener
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

    [Test]
    public async Task DefaultValuesAreRespectedWhenNoOptionsArePassed()
    {
        using TestEventListenerVerbose listener = new();

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent("World.");

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response)
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        int responseNum = 0;

        using TestServer testServer = new(
            async context =>
            {
                switch (responseNum)
                {
                    case 1:
                        context.Response.StatusCode = 429;
                        await context.Response.WriteAsync("Try again");
                        break;
                    case 3:
                        await context.Response.WriteAsync("Exception");
                        throw new Exception("Error");
                    default:
                        context.Response.StatusCode = 201;
                        await context.Response.WriteAsync("Success");
                        break;
                }
                responseNum++;
            });

        // Simple request and response

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "GET";
        message.Request.Content = BinaryContent.Create(new BinaryData("Request 1"));
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        GetSingleEventFromEventSource(1, "Request", EventLevel.Informational, listener); // RequestEvent
        GetSingleEventFromEventSource(5, "Response", EventLevel.Informational, listener); // ResponseEvent
        AssertNoContentLoggedByEventSource(listener);

        // Retry request and response

        message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "GET";
        message.Request.Content = BinaryContent.Create(new BinaryData("Request 2"));
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        GetSingleEventFromEventSource(1, "Request", EventLevel.Informational, listener); // RequestEvent
        GetSingleEventFromEventSource(5, "Response", EventLevel.Informational, listener); // ResponseEvent

        message.Dispose();
    }

    [Test]
    public Task DefaultValuesAreRespectedWhenEmptyOptionsArePassed()
    {
        using TestEventListenerVerbose listener = new();

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent("World.");

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = new TestLoggingFactory(LogLevel.Debug)
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        throw new NotImplementedException();
    }

    [Test]
    public Task ClientLoggingOptionsAreRespectedWhenPassed()
    {
        using TestEventListenerVerbose listener = new();

        var headers = new MockResponseHeaders(new Dictionary<string, string> { { "Custom-Response-Header", "Value" } });
        var response = new MockPipelineResponse(200, mockHeaders: headers);
        response.SetContent("World.");

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = new TestLoggingFactory(LogLevel.Debug)
        };

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            ClientLoggingOptions = loggingOptions,
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        throw new NotImplementedException();
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

    private class TestEventListenerVerbose : TestClientEventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "ClientModel.Tests.TestLoggingEventSource")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
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

    private void AssertNoContentLoggedByEventSource(TestClientEventListener listener)
    {
        CollectionAssert.IsEmpty(listener.EventsById(2)); // RequestContentEvent
        CollectionAssert.IsEmpty(listener.EventsById(17)); // RequestContentTextEvent

        CollectionAssert.IsEmpty(listener.EventsById(6)); // ResponseContentEvent
        CollectionAssert.IsEmpty(listener.EventsById(13)); // ResponseContentTextEvent
        CollectionAssert.IsEmpty(listener.EventsById(11)); // ResponseContentBlockEvent
        CollectionAssert.IsEmpty(listener.EventsById(15)); // ResponseContentTextBlockEvent

        CollectionAssert.IsEmpty(listener.EventsById(9)); // ErrorResponseContentEvent
        CollectionAssert.IsEmpty(listener.EventsById(14)); // ErrorResponseContentTextEvent
        CollectionAssert.IsEmpty(listener.EventsById(12)); // ErrorResponseContentBlockEvent
        CollectionAssert.IsEmpty(listener.EventsById(16)); // ErrorResponseContentTextBlockEvent
    }
    #endregion
}
