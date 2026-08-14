// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

/// <summary>
/// Standalone OTel tests — verify telemetry constants usable without protocol packages.
/// </summary>
[TestFixture]
public class StandaloneOTelTests
{
    [Test]
    public void AgentHostTelemetry_ConstantsAvailable()
    {
        // Shared constants accessible directly from Core
        Assert.That(AgentHostTelemetry.ResponsesSourceName, Is.EqualTo("Azure.AI.AgentServer.Responses"));
        Assert.That(AgentHostTelemetry.InvocationsSourceName, Is.EqualTo("Azure.AI.AgentServer.Invocations"));
        Assert.That(AgentHostTelemetry.ResponsesMeterName, Is.EqualTo("Azure.AI.AgentServer.Responses"));
        Assert.That(AgentHostTelemetry.InvocationsMeterName, Is.EqualTo("Azure.AI.AgentServer.Invocations"));
    }
}
