// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

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
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
        Environment.SetEnvironmentVariable("PORT", null);
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", null);
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", null);
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_INSTANCE_CLIENT_ID", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_TENANT_ID", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT365_TRACING_ENABLED", null);
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
    public void ProjectArmId_ReturnsEnvVar_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.CognitiveServices/accounts/acct1/projects/proj1");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.ProjectArmId, Is.EqualTo("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.CognitiveServices/accounts/acct1/projects/proj1"));
    }

    [Test]
    public void ProjectArmId_ReturnsNull_WhenNotSet()
    {
        Assert.That(FoundryEnvironment.ProjectArmId, Is.Null);
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

    [Test]
    public void SseKeepAliveInterval_ReturnsInfinite_WhenNotSet()
    {
        Assert.That(FoundryEnvironment.SseKeepAliveInterval, Is.EqualTo(Timeout.InfiniteTimeSpan));
    }

    [Test]
    public void SseKeepAliveInterval_ReturnsParsedValue_WhenSet()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "30");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.SseKeepAliveInterval, Is.EqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public void SseKeepAliveInterval_ReturnsInfinite_WhenZero()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "0");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.SseKeepAliveInterval, Is.EqualTo(Timeout.InfiniteTimeSpan));
    }

    [Test]
    public void SseKeepAliveInterval_ReturnsInfinite_WhenNegative()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "-5");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.SseKeepAliveInterval, Is.EqualTo(Timeout.InfiniteTimeSpan));
    }

    [Test]
    public void SseKeepAliveInterval_ReturnsInfinite_WhenUnparseable()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "not-a-number");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.SseKeepAliveInterval, Is.EqualTo(Timeout.InfiniteTimeSpan));
    }

    // ---------------------------------------------------------------
    // IsHosted (driven by FOUNDRY_HOSTING_ENVIRONMENT env var)
    // ---------------------------------------------------------------

    [Test]
    public void IsHosted_ReturnsTrue_WhenFoundryHostingEnvironmentIsSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.True);
    }

    [Test]
    public void IsHosted_ReturnsTrue_WhenAnyNonEmptyValue()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "staging");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.True);
    }

    [Test]
    public void IsHosted_ReturnsFalse_WhenNotSet()
    {
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.False);
    }

    [Test]
    public void IsHosted_ReturnsFalse_WhenEmpty()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.False);
    }

    // ---------------------------------------------------------------
    // AgentInstanceClientId
    // ---------------------------------------------------------------

    [Test]
    public void AgentInstanceClientId_ReturnsValue_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_INSTANCE_CLIENT_ID", "instance-123");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentInstanceClientId, Is.EqualTo("instance-123"));
    }

    [Test]
    public void AgentInstanceClientId_ReturnsNull_WhenNotSet()
    {
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentInstanceClientId, Is.Null);
    }

    // ---------------------------------------------------------------
    // AgentBlueprintClientId
    // ---------------------------------------------------------------

    [Test]
    public void AgentBlueprintClientId_ReturnsValue_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID", "blueprint-456");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentBlueprintClientId, Is.EqualTo("blueprint-456"));
    }

    [Test]
    public void AgentBlueprintClientId_ReturnsNull_WhenNotSet()
    {
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentBlueprintClientId, Is.Null);
    }

    // ---------------------------------------------------------------
    // AgentTenantId
    // ---------------------------------------------------------------

    [Test]
    public void AgentTenantId_ReturnsValue_WhenSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_TENANT_ID", "tenant-789");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentTenantId, Is.EqualTo("tenant-789"));
    }

    [Test]
    public void AgentTenantId_ReturnsNull_WhenNotSet()
    {
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.AgentTenantId, Is.Null);
    }

    // ---------------------------------------------------------------
    // IsAgent365TracingEnabled
    // ---------------------------------------------------------------

    [Test]
    public void IsAgent365TracingEnabled_ReturnsTrue_WhenHostedAndEnvVarSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT365_TRACING_ENABLED", "true");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsAgent365TracingEnabled, Is.True);
    }

    [Test]
    public void IsAgent365TracingEnabled_ReturnsFalse_WhenNotHosted()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT365_TRACING_ENABLED", "true");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsAgent365TracingEnabled, Is.False);
    }

    [Test]
    public void IsAgent365TracingEnabled_ReturnsFalse_WhenEnvVarNotSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsAgent365TracingEnabled, Is.False);
    }

    [Test]
    public void IsAgent365TracingEnabled_ReturnsFalse_WhenEnvVarIsFalse()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "production");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT365_TRACING_ENABLED", "false");
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsAgent365TracingEnabled, Is.False);
    }
}
