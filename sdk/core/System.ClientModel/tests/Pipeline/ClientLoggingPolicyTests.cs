﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Options;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

public class ClientLoggingPolicyTests : SyncAsyncTestBase
{
    public ClientLoggingPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task MultiplePipelinesCanLog()
    {
        using AzureCoreEventListener azureCoreListener = new AzureCoreEventListener();
        string clientIdHeaderName = "Client-ID";

        // Pipeline 1
        MockPipelineResponse response1 = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "client1" } }));
        response1.SetContent("Response from pipeline 1");
        ClientPipelineOptions options1 = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response1),
            LoggingPolicy = new AzureCoreLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK1", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline1 = ClientPipeline.Create(options1);

        // Pipeline 2
        MockPipelineResponse response2 = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "client2" } }));
        response2.SetContent("Response from pipeline 2");
        ClientPipelineOptions options2 = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response2),
            LoggingPolicy = new AzureCoreLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK2", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline2 = ClientPipeline.Create(options2);

        // Send Messages
        PipelineMessage message1 = pipeline1.CreateMessage();
        message1.Request.Uri = new Uri("http://example.com");
        message1.Request.Headers.Add(clientIdHeaderName, "client1");
        message1.Request.Content = BinaryContent.Create(new BinaryData("Request to pipeline 1"));

        PipelineMessage message2 = pipeline2.CreateMessage();
        message2.Request.Uri = new Uri("http://example.com");
        message2.Request.Headers.Add(clientIdHeaderName, "client2");
        message2.Request.Content = BinaryContent.Create(new BinaryData("Request to pipeline 2"));

        List<Task> sendTasks = new()
        {
            pipeline1.SendSyncOrAsync(message1, IsAsync),
            pipeline2.SendSyncOrAsync(message2, IsAsync)
        };
        await Task.WhenAll(sendTasks);
        Assert.AreEqual(4, azureCoreListener.EventData.Count());

        azureCoreListener.SingleEventById(1, e => e.GetProperty<string>("requestId").Equals("client1"));
        azureCoreListener.SingleEventById(1, e => e.GetProperty<string>("requestId").Equals("client2"));
        azureCoreListener.SingleEventById(5, e => e.GetProperty<string>("requestId").Equals("client1"));
        azureCoreListener.SingleEventById(5, e => e.GetProperty<string>("requestId").Equals("client2"));
    }

    [Test]
    public async Task MultiplePipelinesCanLogToDifferentEventSources()
    {
        using AzureCoreEventListener azureCoreListener = new();
        using ClientCustomEventListener clientEventListener = new();
        string clientIdHeaderName = "Client-ID";

        // Pipeline 1
        MockPipelineResponse response1 = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "client1" } }));
        response1.SetContent("Response from pipeline 1");
        ClientPipelineOptions options1 = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response1),
            LoggingPolicy = new AzureCoreLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK1", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline1 = ClientPipeline.Create(options1);

        // Pipeline 2
        MockPipelineResponse response2 = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "client2" } }));
        response2.SetContent("Response from pipeline 2");
        ClientPipelineOptions options2 = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response2),
            LoggingPolicy = new ClientCustomLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK2", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline2 = ClientPipeline.Create(options2);

        // Send Messages
        PipelineMessage message1 = pipeline1.CreateMessage();
        message1.Request.Uri = new Uri("http://example.com");
        message1.Request.Headers.Add(clientIdHeaderName, "client1");
        message1.Request.Content = BinaryContent.Create(new BinaryData("Request to pipeline 1"));

        PipelineMessage message2 = pipeline2.CreateMessage();
        message2.Request.Uri = new Uri("http://example.com");
        message2.Request.Headers.Add(clientIdHeaderName, "client2");
        message2.Request.Content = BinaryContent.Create(new BinaryData("Request to pipeline 2"));

        List<Task> sendTasks = new()
        {
            pipeline1.SendSyncOrAsync(message1, IsAsync),
            pipeline2.SendSyncOrAsync(message2, IsAsync)
        };
        await Task.WhenAll(sendTasks);

        Assert.AreEqual(2, azureCoreListener.EventData.Count());
        azureCoreListener.SingleEventById(1);
        azureCoreListener.SingleEventById(5);

        Assert.AreEqual(2, clientEventListener.EventData.Count());
        clientEventListener.SingleEventById(1);
        clientEventListener.SingleEventById(5);
    }

    [Test]
    public async Task LogsAreNotWrittenWhenLoggingIsDisabled()
    {
        using ClientCustomEventListener clientEventListener = new();
        string clientIdHeaderName = "Client-ID";

        MockPipelineResponse response = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "sample-client" } }));
        response.SetContent("Response");
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingPolicy = new ClientCustomLoggingPolicy(new LoggingOptions() { IsLoggingEnabled = false })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add(clientIdHeaderName, "sample-client");
        message.Request.Content = BinaryContent.Create(new BinaryData("Request"));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(0, clientEventListener.EventData.Count());
    }

    [Test]
    public async Task RequestAndResponseIdsAreUsedFromHeadersFirst()
    {
        using ClientCustomEventListener clientEventListener = new();
        string clientIdHeaderName = "Client-ID";

        MockPipelineResponse response = new(200, mockHeaders: new MockResponseHeaders(new Dictionary<string, string>() { { clientIdHeaderName, "sample-client-B" } }));
        response.SetContent("Response");
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingPolicy = new ClientCustomLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add(clientIdHeaderName, "sample-client-A");
        message.Request.Content = BinaryContent.Create(new BinaryData("Request"));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs requestLog = clientEventListener.SingleEventById(1);
        Assert.AreEqual("sample-client-A", requestLog.GetProperty<string>("requestId"));

        EventWrittenEventArgs responseLog = clientEventListener.SingleEventById(5);
        Assert.AreEqual("sample-client-B", responseLog.GetProperty<string>("requestId"));
    }

    [Test]
    public async Task RandomGuidIsSetForRequestIdWhenNotProvided()
    {
        using ClientCustomEventListener clientEventListener = new();

        MockPipelineResponse response = new(200, mockHeaders: new MockResponseHeaders());
        response.SetContent("Response");
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingPolicy = new ClientCustomLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK" })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Content = BinaryContent.Create(new BinaryData("Request"));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs requestLog = clientEventListener.SingleEventById(1);
        Guid.Parse(requestLog.GetProperty<string>("requestId"));

        EventWrittenEventArgs responseLog = clientEventListener.SingleEventById(5);
        Guid.Parse(responseLog.GetProperty<string>("requestId"));
    }

    [Test]
    public async Task RequestIdIsUsedWhenNoResponseIdIsInHeaders()
    {
        using ClientCustomEventListener clientEventListener = new();
        string clientIdHeaderName = "Client-ID";

        MockPipelineResponse response = new(200, mockHeaders: new MockResponseHeaders());
        response.SetContent("Response");
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", i => response),
            LoggingPolicy = new ClientCustomLoggingPolicy(new LoggingOptions() { LoggedClientAssemblyName = "SampleSDK", RequestIdHeaderName = clientIdHeaderName })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("http://example.com");
        message.Request.Headers.Add(clientIdHeaderName, "sample-client");
        message.Request.Content = BinaryContent.Create(new BinaryData("Request"));

        await pipeline.SendSyncOrAsync(message, IsAsync);

        EventWrittenEventArgs requestLog = clientEventListener.SingleEventById(1);
        Assert.AreEqual("sample-client", requestLog.GetProperty<string>("requestId"));

        EventWrittenEventArgs responseLog = clientEventListener.SingleEventById(5);
        Assert.AreEqual("sample-client", responseLog.GetProperty<string>("requestId"));
    }

    [Test]
    public void ElapsedTimeIsCalculated()
    {
        // TODO
    }

    #region Helpers

    private class AzureCoreLoggingPolicy : ClientLoggingPolicy
    {
        public AzureCoreLoggingPolicy(LoggingOptions options) : base("Azure-Core", new string[] { "Trait", "True" }, options)
        {
        }
    }

    private class ClientCustomLoggingPolicy : ClientLoggingPolicy
    {
        public  ClientCustomLoggingPolicy(LoggingOptions options) : base("My.Client", new string[] { "My.Client.Trait", "True" }, options)
        {
        }
    }

    // In order to test listeners with different event levels and event source names, each case has to has its own listener.
    // This is because the constructor does not necessarily finish before the callbacks are called, meaning that any runtime
    // configurations to event listener classes aren't reliably applied.
    // see: https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventlistener#remarks

    private class ClientCustomEventListener : TestClientEventListener
    {
        public ClientCustomEventListener() { }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "My.Client")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }
    }

    private class AzureCoreEventListener : TestClientEventListener
    {
        public AzureCoreEventListener() { }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Azure-Core")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }
    }

    #endregion
}
