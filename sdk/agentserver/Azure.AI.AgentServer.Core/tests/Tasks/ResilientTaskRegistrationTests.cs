// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Verifies that <c>AddResilientTasks</c> wires the FR-022 durability background service into the
/// host lifespan. Without this the cold-start recovery scan (SOT §49) and the periodic reclaim
/// sweep never run, so crashed/interrupted tasks are never auto-recovered.
/// </summary>
[TestFixture]
public sealed class ResilientTaskRegistrationTests
{
    [Test]
    public async Task AddResilientTasksRegistersDurabilityHostedService()
    {
        var services = new ServiceCollection();
        services.AddResilientTasks();

        // The durability service must be registered as an IHostedService so the host drives its
        // StartAsync (blocking cold-start scan) and StopAsync (graceful loop teardown).
        bool hostedServiceRegistered = services.Any(d =>
            d.ServiceType == typeof(IHostedService) &&
            (d.ImplementationType == typeof(TaskDurabilityService) ||
             d.ImplementationFactory is not null));

        Assert.That(hostedServiceRegistered, Is.True, "TaskDurabilityService must be an IHostedService");

        await using var provider = services.BuildServiceProvider();
        var hosted = provider.GetServices<IHostedService>().OfType<TaskDurabilityService>().ToList();
        Assert.That(hosted, Is.Not.Empty, "resolved IHostedService set must contain TaskDurabilityService");
    }

    [Test]
    public void RepeatedAddResilientTasksDoesNotDuplicateHostedServiceAndSharesRegistry()
    {
        var services = new ServiceCollection();
        ResilientTaskBuilder first = services.AddResilientTasks();
        ResilientTaskBuilder second = services.AddResilientTasks();

        // The second call registers nothing further (AddHostedService is not idempotent), so the
        // durability service is registered exactly once — no duplicate recovery scan.
        int hostedServiceCount = services.Count(d => d.ServiceType == typeof(IHostedService));
        Assert.That(hostedServiceCount, Is.EqualTo(1), "durability hosted service must be registered once");

        // Both builders must target the SAME registry instance the engine will use; otherwise a
        // task registered via the second builder would be invisible to the engine.
        first.AddTask<string, string>("via-first", (ctx, ct) => Task.FromResult(ctx.Input));
        second.AddTask<string, string>("via-second", (ctx, ct) => Task.FromResult(ctx.Input));

        using var provider = services.BuildServiceProvider();
        TaskRegistry registry = provider.GetRequiredService<TaskRegistry>();
        Assert.That(registry.TryGet("via-first", out _), Is.True, "task from the first builder must be registered");
        Assert.That(registry.TryGet("via-second", out _), Is.True, "task from the second builder must be registered");
    }

    [Test]
    public void RepeatedAddResilientTasksWithCredentialThrows()
    {
        var services = new ServiceCollection();
        services.AddResilientTasks();

        Assert.Throws<System.InvalidOperationException>(() =>
            services.AddResilientTasks(new Azure.Core.TestFramework.MockCredential()));
    }

    [Test]
    public void AddResilientTasksThrowsWhenEngineRegisteredButRegistryMissing()
    {
        // Simulate an inconsistent state: a TaskEngine service exists but its TaskRegistry does not
        // (e.g. someone wired the services piecemeal). The repeat-call path must fail fast rather
        // than fabricate a fresh registry and silently orphan every subsequent registration.
        var services = new ServiceCollection();
        services.AddSingleton<TaskEngine>(_ => throw new System.NotSupportedException("never built"));

        Assert.Throws<System.InvalidOperationException>(() => services.AddResilientTasks());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    public void EmptyOrWhitespaceTaskNameThrows(string name)
    {
        using var host = TaskTestHost.Create();
        Assert.Throws<System.ArgumentException>(() =>
            host.Builder.AddTask<string, string>(name, (ctx, ct) => Task.FromResult(ctx.Input)));
    }

    [Test]
    public void NegativeTimeoutIsRejectedAtRegistration()
    {
        using var host = TaskTestHost.Create();
        Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            host.Builder.AddTask<string, string>(
                "neg-timeout",
                (ctx, ct) => Task.FromResult(ctx.Input),
                o => o.Timeout = System.TimeSpan.FromSeconds(-1)));
    }

    [Test]
    public void TimeoutAboveOneDayCapIsRejectedAtRegistration()
    {
        using var host = TaskTestHost.Create();
        Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            host.Builder.AddTask<string, string>(
                "big-timeout",
                (ctx, ct) => Task.FromResult(ctx.Input),
                o => o.Timeout = System.TimeSpan.FromDays(2)));
    }

    [TestCase("has space")]
    [TestCase("bad/slash")]
    [TestCase(" ")]
    public void InvalidExplicitInputIdIsRejected(string inputId)
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("echo", (ctx, ct) => Task.FromResult(ctx.Input));

        Assert.ThrowsAsync<TaskStoreException>(async () =>
            await host.Invoker.RunAsync<string, string>(
                "echo", "hi", new RunOptions { InputId = inputId }));
    }
}
