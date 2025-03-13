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
public class PipelineRetryLoggerTests : SyncAsyncPolicyTestBase
{
    private const string RetryPolicyCategoryName = "System.ClientModel.Primitives.ClientRetryPolicy";
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

    public PipelineRetryLoggerTests(bool isAsync) : base(isAsync)
    {
    }

    #region Unit tests

    [Test]
    public void RetriesAreLoggedToILoggerAndNotEventSourceWhenILoggerIsProvided()
    {
        using TestClientEventListener listener = new();
        using TestLoggingFactory factory = new(LogLevel.Debug);

        PipelineRetryLogger retryLogger = new(factory);
        retryLogger.LogRequestRetrying("requestId", 1, 1);

        TestLogger logger = factory.GetLogger(RetryPolicyCategoryName);
        logger.SingleEventById(10); // RequestRetrying

        CollectionAssert.IsEmpty(listener.EventData);
    }

    [Test]
    public void RetriesAreLoggedToILoggerAndNotEventSourceWhenILoggerIsProvidedAndLogLevelIsWarning()
    {
        using TestClientEventListener listener = new(); // Verbose listener
        using TestLoggingFactory factory = new(LogLevel.Warning); // Warnings only

        PipelineRetryLogger retryLogger = new(factory);
        retryLogger.LogRequestRetrying("requestId", 1, 1);

        CollectionAssert.IsEmpty(listener.EventData);
        CollectionAssert.IsEmpty(factory.GetLogger(RetryPolicyCategoryName).Logs);
    }

    #endregion

    #region Integration tests

    [Test]
    public async Task SendingRequestThatIsRetriedProducesRequestRetryingEventOnEachRetryEventSource() // RequestRetryingEvent
    {
        using TestClientEventListener listener = new();

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", [429, 429, 200]),
            ClientLoggingOptions = new()
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs args = listener.SingleEventById(LoggingEventIds.RequestRetryingEvent, (i => i.GetProperty<int>("retryNumber") == 1));
        Assert.AreEqual("RequestRetrying", args.EventName);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.Less(args.GetProperty<double>("seconds"), 1);

        args = listener.SingleEventById(LoggingEventIds.RequestRetryingEvent, (i => i.GetProperty<int>("retryNumber") == 2));
        Assert.AreEqual("RequestRetrying", args.EventName);
        Assert.AreEqual(EventLevel.Informational, args.Level);
        Assert.Less(args.GetProperty<double>("seconds"), 1);

        // 2 retry logs + 3 request logs + 3 response logs
        Assert.AreEqual(8, listener.EventData.Count());
    }

    [Test]
    public async Task SendingRequestThatIsRetriedProducesRequestRetryingEventOnEachRetryILogger() // RequestRetryingEvent
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);

        byte[] requestContent = [1, 2, 3, 4, 5];
        byte[] responseContent = [6, 7, 8, 9, 0];

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", [429, 429, 200]),
            ClientLoggingOptions = new()
            {
                LoggerFactory = factory
            }
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);
        TestLogger logger = factory.GetLogger(RetryPolicyCategoryName);

        LoggerEvent log = logger.SingleEventById(LoggingEventIds.RequestRetryingEvent, (i => i.GetValueFromArguments<int>("retryNumber") == 1));
        Assert.AreEqual("RequestRetrying", log.EventId.Name);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.Less(log.GetValueFromArguments<double>("seconds"), 1);

        log = logger.SingleEventById(LoggingEventIds.RequestRetryingEvent, (i => i.GetValueFromArguments<int>("retryNumber") == 2));
        Assert.AreEqual("RequestRetrying", log.EventId.Name);
        Assert.AreEqual(LogLevel.Information, log.LogLevel);
        Assert.Less(log.GetValueFromArguments<double>("seconds"), 1);

        // No other logs should have been written to the retry logger
        Assert.AreEqual(2, logger.Logs.Count());
    }

    #endregion
}
