// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public class DeferredStreamConfigurationTests
{
    [Test]
    public void ApplicationDoesNotInvokeOverriddenFactory(
        [Values(false, true)] bool applicationFirst,
        [Values(false, true)] bool recursive)
    {
        var services = new ServiceCollection();
        int calls = 0;
        void Application() => services.AddAgentEventStreams(o => o.UseInMemoryReplay());
        void Protocol() => services.AddAgentEventStreamsDefault("protocol", provider =>
        {
            calls++;
            if (!recursive || calls > 1)
            {
                throw new InvalidOperationException("An overridden factory was invoked.");
            }
            _ = provider.GetRequiredService<AgentEventStreamRegistry>();
            return new AgentEventStreamOptions();
        });

        if (applicationFirst)
        { Application(); Protocol(); }
        else
        { Protocol(); Application(); }
        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(provider.GetRequiredService<AgentEventStreamRegistry>(), Is.TypeOf<InMemoryEventStreamRegistry>());
        Assert.That(calls, Is.Zero);
    }

    [Test]
    public void ApplicationConflictIsNotMaskedByUnusedDefault()
    {
        var services = new ServiceCollection();
        int calls = 0;
        services.AddAgentEventStreamsDefault("unused", _ =>
        {
            calls++;
            throw new InvalidOperationException("Unused default");
        });
        services.AddAgentEventStreams(o => o.UseInMemoryReplay());
        services.AddAgentEventStreams(o => o.UseInMemoryLive());
        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(() => provider.GetRequiredService<AgentEventStreamRegistry>(),
            Throws.InvalidOperationException.With.Message.Contains("application"));
        Assert.That(calls, Is.Zero);
    }

    [Test]
    public async Task EmptyApplicationSectionAllowsProtocolSelection()
    {
        var builder = Host.CreateApplicationBuilder();
        int calls = 0;
        builder.AddAgentEventStreams("empty");
        builder.Services.AddAgentEventStreamsDefault("used", _ =>
        {
            calls++;
            var options = new AgentEventStreamOptions();
            options.UseInMemoryReplay();
            return options;
        });
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        AgentEventStreamRegistry registry = provider.GetRequiredService<AgentEventStreamRegistry>();
        Assert.That(calls, Is.EqualTo(1));
        Assert.That(await registry.GetOrCreateAsync("input"), Is.TypeOf<ReplayEventStream>());
    }

    [Test]
    public void InvalidApplicationDoesNotFallBackToProtocol()
    {
        var builder = Host.CreateApplicationBuilder();
        int calls = 0;
        builder.Services.AddAgentEventStreamsDefault("unused", _ =>
        {
            calls++;
            throw new InvalidOperationException("Unused default");
        });
        builder.Configuration["streams:Backing"] = "invalid";
        builder.AddAgentEventStreams("streams");
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        Assert.That(() => provider.GetRequiredService<AgentEventStreamRegistry>(),
            Throws.InvalidOperationException.With.Message.Contains("streams"));
        Assert.That(calls, Is.Zero);
    }
}
