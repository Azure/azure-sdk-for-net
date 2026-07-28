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

    private sealed class Dependency
    {
        public string Value => "resolved-from-di";
    }

    [Test]
    public async Task ProviderAwareHandlerResolvesServicesWithoutBuildServiceProvider()
    {
        // The provider-aware overload must let a handler resolve a DI-registered dependency at
        // invocation time — no caller-side BuildServiceProvider() hack, no forward-declared
        // captured IServiceProvider.
        var services = new ServiceCollection();
        services.AddSingleton<Dependency>();

        IResilientTaskBuilder tasks = services.AddResilientTasks();
        tasks.AddTask<string, string>(
            "echo-dep",
            (provider, ctx, ct) =>
            {
                Dependency dep = provider.GetRequiredService<Dependency>();
                return Task.FromResult($"{ctx.Input}:{dep.Value}");
            });

        await using var sp = services.BuildServiceProvider();
        var invoker = sp.GetRequiredService<ITaskInvoker>();

        string result = await invoker.RunAsync<string, string>("echo-dep", "hello");

        Assert.That(result, Is.EqualTo("hello:resolved-from-di"));
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
