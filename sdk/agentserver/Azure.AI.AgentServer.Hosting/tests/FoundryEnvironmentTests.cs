// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Hosting.Tests;

[TestFixture]
public class FoundryEnvironmentTests
{
    [TearDown]
    public void TearDown()
    {
        // Clean up env vars after each test
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
        Environment.SetEnvironmentVariable("PORT", null);
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", null);
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void AgentName_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentName, Is.EqualTo("my-agent"));
    }

    [Test]
    public void AgentName_ReturnsNull_WhenNotSet()
    {
        Assert.That(FoundryEnvironment.AgentName, Is.Null);
    }

    [Test]
    public void AgentVersion_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentVersion, Is.EqualTo("1.0.0"));
    }

    [Test]
    public void ProjectEndpoint_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://example.com");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.ProjectEndpoint, Is.EqualTo("https://example.com"));
    }

    [Test]
    public void SessionId_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "session-123");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.SessionId, Is.EqualTo("session-123"));
    }

    [Test]
    public void Port_ReturnsDefault_WhenNotSet()
    {
        Assert.That(FoundryEnvironment.Port, Is.EqualTo(8088));
    }

    [Test]
    public void Port_ReturnsParsedValue_WhenSet()
    {
        Environment.SetEnvironmentVariable("PORT", "9090");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.Port, Is.EqualTo(9090));
    }

    [Test]
    public void Port_ThrowsInvalidOperationException_WhenInvalid()
    {
        Environment.SetEnvironmentVariable("PORT", "not-a-number");
        Assert.Throws<InvalidOperationException>(() => FoundryEnvironment.Reload());
    }

    [Test]
    public void Port_ThrowsInvalidOperationException_WhenZero()
    {
        Environment.SetEnvironmentVariable("PORT", "0");
        Assert.Throws<InvalidOperationException>(() => FoundryEnvironment.Reload());
    }

    [Test]
    public void Port_ThrowsInvalidOperationException_WhenNegative()
    {
        Environment.SetEnvironmentVariable("PORT", "-1");
        Assert.Throws<InvalidOperationException>(() => FoundryEnvironment.Reload());
    }

    [Test]
    public void Port_ThrowsInvalidOperationException_WhenAboveMax()
    {
        Environment.SetEnvironmentVariable("PORT", "65536");
        Assert.Throws<InvalidOperationException>(() => FoundryEnvironment.Reload());
    }

    [Test]
    public void OtlpEndpoint_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.OtlpEndpoint, Is.EqualTo("http://localhost:4317"));
    }

    [Test]
    public void AppInsightsConnectionString_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=abc");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AppInsightsConnectionString, Is.EqualTo("InstrumentationKey=abc"));
    }
}
