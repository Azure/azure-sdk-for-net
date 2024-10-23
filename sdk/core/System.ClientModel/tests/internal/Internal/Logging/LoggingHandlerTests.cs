// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

[NonParallelizable]
public class LoggingHandlerTests : SyncAsyncPolicyTestBase
{
    public LoggingHandlerTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task DoesNotLogToEventSourceWhenILoggerIsConfigured()
    {
        TestLogger logger = new(LogLevel.Debug);
        TestLoggingFactory factory = new(logger);

        TestClientEventListener listener = new();

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
            LoggerFactory = factory
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = uri;
        message.Request.Content = BinaryContent.Create(new BinaryData(requestContent));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(2, logger.Logs.Count());

        LoggerEvent log = logger.SingleEventById(1); // Request event
        Assert.AreEqual("Request", log.EventId.Name);
        Guid requestId = Guid.Parse(log.GetValueFromArguments<string>("requestId"));

        log = logger.SingleEventById(5); // Response event
        Assert.AreEqual("Response", log.EventId.Name);
        Guid responseId = Guid.Parse(log.GetValueFromArguments<string>("requestId"));

        Assert.AreEqual(0, listener.EventData.Count());
    }
}
