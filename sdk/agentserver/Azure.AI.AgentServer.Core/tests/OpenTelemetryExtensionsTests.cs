// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class OpenTelemetryExtensionsTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", null);
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
    }

    [Test]
    public void AgentHostTelemetry_HasDefaultSourceName()
    {
        Assert.That(AgentHostTelemetry.ResponsesSourceName, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void AgentHostTelemetry_HasDefaultMeterName()
    {
        Assert.That(AgentHostTelemetry.ResponsesMeterName, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void OtlpEndpointDetection_WhenSet_IsNotNull()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        var value = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
        Assert.That(value, Is.Not.Null);
    }

    [Test]
    public void AppInsightsDetection_WhenSet_IsNotNull()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=abc");
        var value = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        Assert.That(value, Is.Not.Null);
    }

    [Test]
    public void BothExporters_CanCoexist()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=abc");

        var otlp = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
        var appInsights = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        Assert.That(otlp, Is.Not.Null);
        Assert.That(appInsights, Is.Not.Null);
    }
}
