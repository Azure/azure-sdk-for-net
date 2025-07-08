// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class TelemetryPolicyTests : SyncAsyncTestBase
{
    public TelemetryPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task UserAgentTelemetryDisabledByDefault()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new ObservableTransport("Transport")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // User-Agent header should not be present when telemetry is disabled
        Assert.IsFalse(message.Request.Headers.TryGetValue("User-Agent", out _));
    }

    [Test]
    public async Task UserAgentTelemetryAddsHeaderWhenEnabled()
    {
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            EnableUserAgentTelemetry = true,
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // User-Agent header should be present when telemetry is enabled
        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.IsNotNull(userAgent);

        // Should contain assembly name and version
        Assert.That(userAgent, Does.Contain("System.ClientModel"));
    }

    [Test]
    public async Task UserAgentTelemetryUsesCustomValueWhenSet()
    {
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            EnableUserAgentTelemetry = true,
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        // Set custom user agent
        TelemetryDetails customTelemetry = new(Assembly.GetExecutingAssembly(), "MyApp/1.0");
        customTelemetry.Apply(message);

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Should use the custom user agent value
        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.That(userAgent, Does.Contain("MyApp/1.0"));
    }

    [Test]
    public void TelemetryDetailsGeneratesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        TelemetryDetails telemetryDetails = new(assembly);

        string userAgent = telemetryDetails.ToString();

        Assert.IsNotNull(userAgent);
        Assert.IsNotEmpty(userAgent);

        // Should contain assembly name and version
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));

        // Should contain framework and OS information
        Assert.That(userAgent, Does.Contain("("));
        Assert.That(userAgent, Does.Contain(")"));
    }

    [Test]
    public void TelemetryDetailsWithApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/2.0";
        TelemetryDetails telemetryDetails = new(assembly, applicationId);

        string userAgent = telemetryDetails.ToString();

        Assert.That(userAgent, Does.StartWith(applicationId));
    }

    [Test]
    public void TelemetryDetailsThrowsForLongApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string longApplicationId = new string('a', 30); // More than 24 characters

        Assert.Throws<ArgumentOutOfRangeException>(() => new TelemetryDetails(assembly, longApplicationId));
    }

    [Test]
    public void TelemetryDetailsThrowsForNullAssembly()
    {
        Assert.Throws<ArgumentNullException>(() => new TelemetryDetails(null!));
    }
}