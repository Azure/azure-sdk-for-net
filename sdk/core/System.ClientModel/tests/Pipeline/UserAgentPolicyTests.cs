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

public class UserAgentPolicyTests : SyncAsyncTestBase
{
    public UserAgentPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task UserAgentTelemetryNotIncludedByDefault()
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

        // User-Agent header should not be present when user agent policy is not added
        Assert.IsFalse(message.Request.Headers.TryGetValue("User-Agent", out _));
    }

    [Test]
    public async Task UserAgentTelemetryAddsHeaderWhenPolicyIncluded()
    {
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        // Library author explicitly adds user agent policy when creating pipeline
        var userAgentPolicy = new UserAgentPolicy(Assembly.GetExecutingAssembly());
        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // User-Agent header should be present when user agent policy is included
        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.IsNotNull(userAgent);

        // Should contain assembly name and version
        Assert.That(userAgent, Does.Contain("ClientModel.Tests"));
    }

    [Test]
    public void UserAgentPolicyGeneratesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        UserAgentPolicy userAgentPolicy = new(assembly);

        // Create a mock transport and add user agent policy to verify behavior
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        // Send through pipeline to test user agent functionality
        pipeline.Send(message);

        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
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
    public void UserAgentPolicyWithApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/2.0";
        UserAgentPolicy userAgentPolicy = new(assembly, applicationId);

        // Verify the application ID is used by checking the properties
        Assert.AreEqual(applicationId, userAgentPolicy.ApplicationId);

        // Also verify by processing a message and checking the header through the pipeline
        MockPipelineTransport transport = new("Transport", 200);
        PipelineRequest? capturedRequest = null;

        transport.OnSendingRequest = (message) =>
        {
            capturedRequest = message.Request;
        };

        ClientPipelineOptions options = new()
        {
            Transport = transport
        };

        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://example.com");
        message.Request.Method = "GET";

        pipeline.Send(message);

        Assert.IsNotNull(capturedRequest);
        Assert.IsTrue(capturedRequest!.Headers.TryGetValue("User-Agent", out string? userAgent));
        Assert.That(userAgent, Does.StartWith(applicationId));
    }

    [Test]
    public void UserAgentPolicyThrowsForLongApplicationId()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string longApplicationId = new string('a', 30); // More than 24 characters

        Assert.Throws<ArgumentOutOfRangeException>(() => new UserAgentPolicy(assembly, longApplicationId));
    }

    [Test]
    public void UserAgentPolicyThrowsForNullAssembly()
    {
        Assert.Throws<ArgumentNullException>(() => new UserAgentPolicy(null!));
    }

    [Test]
    public void GenerateUserAgentString_ProducesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Test without application ID
        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly);
        Assert.IsNotNull(userAgent);
        Assert.IsNotEmpty(userAgent);

        // Should contain assembly name and version
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));

        // Should contain framework and OS information in parentheses
        Assert.That(userAgent, Does.Contain("("));
        Assert.That(userAgent, Does.Contain(")"));
    }

    [Test]
    public void GenerateUserAgentString_WithApplicationId_ProducesValidUserAgent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string applicationId = "TestApp/1.0";

        string userAgent = UserAgentPolicy.GenerateUserAgentString(assembly, applicationId);
        Assert.IsNotNull(userAgent);
        Assert.IsNotEmpty(userAgent);

        // Should start with application ID
        Assert.That(userAgent, Does.StartWith(applicationId));

        // Should contain assembly name and version
        string assemblyName = assembly.GetName().Name!;
        Assert.That(userAgent, Does.Contain(assemblyName));
    }
}