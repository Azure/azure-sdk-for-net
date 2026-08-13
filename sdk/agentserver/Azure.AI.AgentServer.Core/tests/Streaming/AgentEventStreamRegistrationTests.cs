// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.AI.AgentServer.Core.Streaming;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class AgentEventStreamRegistrationTests
{
    [Test]
    public void AddAgentEventStreams_RegistersRegistry()
    {
        var services = new ServiceCollection();

        services.AddAgentEventStreams();

        using var provider = services.BuildServiceProvider();
        Assert.That(provider.GetService<AgentEventStreamRegistry>(), Is.Not.Null);
    }

    [Test]
    public void AddAgentEventStreams_RepeatedRegistration_DoesNotThrow_AndIsFirstWins()
    {
        // A composition where more than one component (e.g. a protocol SDK and a consumer) selects
        // the streams backing must not throw on registration order — it is first-wins (TryAdd).
        var services = new ServiceCollection();

        services.AddAgentEventStreams(o => o.UseInMemoryReplay(ttl: TimeSpan.FromMinutes(5)));

        Assert.DoesNotThrow(() => services.AddAgentEventStreams(o => o.UseFileBackedReplay()));

        // Only one registry descriptor is present (the second call was a harmless no-op).
        Assert.That(services.Count(d => d.ServiceType == typeof(AgentEventStreamRegistry)), Is.EqualTo(1));

        using var provider = services.BuildServiceProvider();
        Assert.That(provider.GetService<AgentEventStreamRegistry>(), Is.Not.Null);
    }
}
