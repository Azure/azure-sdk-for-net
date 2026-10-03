// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class AgentEventStreamRegistrationTests
{
    [Test]
    public void IdenticalApplicationRegistrationsAreIdempotent()
    {
        var services = new ServiceCollection();

        services.AddAgentEventStreams(options =>
            options.UseInMemoryReplay(TimeSpan.FromMinutes(5)));

        Assert.DoesNotThrow(() =>
            services.AddAgentEventStreams(options =>
                options.UseInMemoryReplay(TimeSpan.FromMinutes(5))));
    }

    [Test]
    public void ConflictingApplicationRegistrationsFailLoudly()
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreams(options => options.UseInMemoryReplay());

        services.AddAgentEventStreams(options => options.UseFileBackedReplay());

        using ServiceProvider provider = services.BuildServiceProvider();
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            provider.GetRequiredService<AgentEventStreamRegistry>())!;

        Assert.That(exception.Message, Does.Contain("application"));
        Assert.That(exception.Message, Does.Contain(nameof(AgentEventStreamRegistrationTests) + ".cs"));
        Assert.That(exception.Message, Does.Contain("InMemoryReplay"));
        Assert.That(exception.Message, Does.Contain("FileBackedReplay"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task ApplicationSelectionOverridesProtocolDefaultRegardlessOfOrder(
        bool applicationFirst)
    {
        var services = new ServiceCollection();

        void AddApplication() =>
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
        void AddProtocol() =>
            services.AddAgentEventStreamsDefault(
                "ResponsesServer",
                options => options.UseInMemoryLive());

        if (applicationFirst)
        {
            AddApplication();
            AddProtocol();
        }
        else
        {
            AddProtocol();
            AddApplication();
        }

        await using ServiceProvider provider = services.BuildServiceProvider();
        AgentEventStreamRegistry registry =
            provider.GetRequiredService<AgentEventStreamRegistry>();
        AgentEventStream stream = await registry.GetOrCreateAsync("override");

        Assert.That(stream, Is.TypeOf<ReplayEventStream>());
    }

    [Test]
    public void ConflictingProtocolDefaultsFailWithBothSources()
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreamsDefault(
            "ResponsesServer",
            options => options.UseInMemoryReplay());

        services.AddAgentEventStreamsDefault(
            "OtherProtocol",
            options => options.UseInMemoryLive());

        using ServiceProvider provider = services.BuildServiceProvider();
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            provider.GetRequiredService<AgentEventStreamRegistry>())!;

        Assert.That(exception.Message, Does.Contain("ResponsesServer"));
        Assert.That(exception.Message, Does.Contain("OtherProtocol"));
    }

    [Test]
    public async Task ApplicationSelectionOverridesConflictingProtocolDefaults()
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreamsDefault(
            "ResponsesServer",
            options => options.UseInMemoryReplay());
        services.AddAgentEventStreamsDefault(
            "OtherProtocol",
            options => options.UseInMemoryLive());
        services.AddAgentEventStreams(options => options.UseInMemoryReplay(TimeSpan.FromMinutes(1)));

        await using ServiceProvider provider = services.BuildServiceProvider();
        AgentEventStreamRegistry registry =
            provider.GetRequiredService<AgentEventStreamRegistry>();
        AgentEventStream stream = await registry.GetOrCreateAsync("application-override");

        Assert.That(stream, Is.TypeOf<ReplayEventStream>());
    }

    [Test]
    public void EquivalentFileBackedSelectionsNormalizePathsAndDefaults()
    {
        var services = new ServiceCollection();
        string relativePath = Path.Combine(".", "streams");
        string absolutePath = Path.GetFullPath(relativePath);

        services.AddAgentEventStreams(options =>
            options.UseFileBackedReplay(relativePath));

        Assert.DoesNotThrow(() =>
            services.AddAgentEventStreams(options =>
                options.UseFileBackedReplay(
                    absolutePath + Path.DirectorySeparatorChar,
                    TimeSpan.FromMinutes(10))));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void CustomRegistryRemainsAuthoritativeRegardlessOfOrder(bool customFirst)
    {
        var services = new ServiceCollection();
        var custom = new TestRegistry();

        if (customFirst)
        {
            services.AddSingleton<AgentEventStreamRegistry>(custom);
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
        }
        else
        {
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
            services.AddSingleton<AgentEventStreamRegistry>(custom);
        }

        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<AgentEventStreamRegistry>(),
            Is.SameAs(custom));
    }

    [Test]
    public async Task HostConfigurationSelectsFileBackedReplay()
    {
        string directory =
            Path.Combine(Path.GetTempPath(), "agent-stream-config-" + Guid.NewGuid().ToString("N"));
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddAgentEventStreams("ResilientTasks:Streams");
            builder.Configuration.AddInMemoryCollection(
                new Dictionary<string, string?>
                {
                    ["ResilientTasks:Streams:Backing"] = "FileBackedReplay",
                    ["ResilientTasks:Streams:StorageDirectory"] = directory,
                    ["ResilientTasks:Streams:Ttl"] = "00:05:00",
                });

            await using ServiceProvider provider = builder.Services.BuildServiceProvider();
            AgentEventStreamRegistry registry =
                provider.GetRequiredService<AgentEventStreamRegistry>();
            AgentEventStream stream = await registry.GetOrCreateAsync("configured");

            Assert.That(stream, Is.TypeOf<FileBackedReplayEventStream>());
            await registry.DeleteAsync("configured");
        }
        finally
        {
            try
            {
                Directory.Delete(directory, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    [Test]
    public void InvalidHostConfigurationBackingFailsWhenRegistryIsResolved()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration["ResilientTasks:Streams:Backing"] = "DatabaseReplay";

        builder.AddAgentEventStreams("ResilientTasks:Streams");
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            provider.GetRequiredService<AgentEventStreamRegistry>())!;

        Assert.That(exception.Message, Does.Contain("DatabaseReplay"));
        Assert.That(exception.Message, Does.Contain("ResilientTasks:Streams"));
    }

    private sealed class TestRegistry : AgentEventStreamRegistry
    {
        public override ValueTask<AgentEventStream> GetAsync(
            string id,
            CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public override ValueTask<AgentEventStream> GetOrCreateAsync(
            string id,
            CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public override ValueTask DeleteAsync(
            string id,
            CancellationToken cancellationToken = default)
            => throw new NotSupportedException();
    }
}
