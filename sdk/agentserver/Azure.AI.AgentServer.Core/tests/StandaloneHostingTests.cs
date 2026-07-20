// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

/// <summary>
/// Standalone Core tests — verify Core utilities work without any protocol package.
/// </summary>
[TestFixture]
public class StandaloneHostingTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void FoundryEnvironment_WorksStandalone()
    {
        // No protocol packages needed — just Core utilities
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "standalone-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://my-endpoint.com");
        FoundryEnvironment.Reload();

        Assert.That(FoundryEnvironment.AgentName, Is.EqualTo("standalone-agent"));
        Assert.That(FoundryEnvironment.AgentVersion, Is.EqualTo("1.0.0"));
        Assert.That(FoundryEnvironment.ProjectEndpoint, Is.EqualTo("https://my-endpoint.com"));
    }
}
