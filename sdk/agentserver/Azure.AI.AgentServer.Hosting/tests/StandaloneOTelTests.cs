// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Hosting.Tests;

/// <summary>
/// Standalone OTel tests — verify telemetry constants usable without protocol packages.
/// </summary>
[TestFixture]
public class StandaloneOTelTests
{
    [Test]
    public void AgentServerTelemetry_ConstantsAvailable()
    {
        // Shared constants accessible directly from Hosting
        Assert.That(AgentServerTelemetry.ResponsesSourceName, Is.EqualTo("Azure.AI.AgentServer.Responses"));
        Assert.That(AgentServerTelemetry.InvocationsSourceName, Is.EqualTo("Azure.AI.AgentServer.Invocations"));
        Assert.That(AgentServerTelemetry.ResponsesMeterName, Is.EqualTo("Azure.AI.AgentServer.Responses"));
        Assert.That(AgentServerTelemetry.InvocationsMeterName, Is.EqualTo("Azure.AI.AgentServer.Invocations"));
    }
}
