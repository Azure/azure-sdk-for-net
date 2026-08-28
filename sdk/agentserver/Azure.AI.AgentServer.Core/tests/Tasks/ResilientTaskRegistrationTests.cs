// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
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
        services.AddResilientTasks();
        services.AddResilientTasks();

        // The second call registers nothing further (AddHostedService is not idempotent), so the
        // durability service is registered exactly once — no duplicate recovery scan.
        int hostedServiceCount = services.Count(d => d.ServiceType == typeof(IHostedService));
        Assert.That(hostedServiceCount, Is.EqualTo(1), "durability hosted service must be registered once");

        // Both calls must target the SAME registry instance the engine will use; otherwise a task
        // registered after the second call would be invisible to the engine.
        services.AddResilientTask<string, string>("via-first", (ctx, ct) => Task.FromResult(ctx.Input));
        services.AddResilientTask<string, string>("via-second", (ctx, ct) => Task.FromResult(ctx.Input));

        using var provider = services.BuildServiceProvider();
        TaskRegistry registry = provider.GetRequiredService<TaskRegistry>();
        Assert.That(registry.TryGet("via-first", out _), Is.True, "task registered after the first AddResilientTasks call must be registered");
        Assert.That(registry.TryGet("via-second", out _), Is.True, "task registered after the second AddResilientTasks call must be registered");
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

    [Test]
    public void AddResilientTaskSelfInitializesCoreServicesOnFirstCall()
    {
        // AddResilientTask is a flat entry point: it must not require a prior AddResilientTasks()
        // call to set up the durability hosted service and the rest of the core services.
        var services = new ServiceCollection();
        services.AddResilientTask<string, string>("solo", (ctx, ct) => Task.FromResult(ctx.Input));

        bool hostedServiceRegistered = services.Any(d => d.ServiceType == typeof(IHostedService));
        Assert.That(hostedServiceRegistered, Is.True, "the first AddResilientTask call must self-initialize the core services");

        using var provider = services.BuildServiceProvider();
        Assert.That(provider.GetRequiredService<TaskRegistry>().TryGet("solo", out _), Is.True);
    }

    [Test]
    public void AddResilientTaskRegistersTheDefinitionAsAKeyedSingleton()
    {
        var services = new ServiceCollection();
        TaskDefinition<string, string> registered = services.AddResilientTask<string, string>(
            "keyed-one-shot", (ctx, ct) => Task.FromResult(ctx.Input));

        using var provider = services.BuildServiceProvider();
        TaskDefinition<string, string> resolved =
            provider.GetRequiredKeyedService<TaskDefinition<string, string>>("keyed-one-shot");

        Assert.That(resolved, Is.SameAs(registered), "the keyed registration must be the same instance AddResilientTask returned");
    }

    [Test]
    public async Task KeyedDefinitionResolutionInitializesTheTaskEngine()
    {
        string root = Path.Combine(Path.GetTempPath(), "agentserver-keyed-definition-" + System.Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITaskStore>(new LocalTaskStore(root));
            TaskDefinition<string, string> registered = services.AddResilientTask<string, string>(
                "keyed-runnable", (ctx, ct) => Task.FromResult(ctx.Input));

            await using var provider = services.BuildServiceProvider();
            TaskDefinition<string, string> resolved =
                provider.GetRequiredKeyedService<TaskDefinition<string, string>>("keyed-runnable");

            Assert.That(resolved, Is.SameAs(registered));
            Assert.That(await resolved.RunAsync("ready"), Is.EqualTo("ready"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public void AddResilientMultiTurnTaskRegistersTheDefinitionAsAKeyedSingleton()
    {
        var services = new ServiceCollection();
        TaskDefinition<string, string> registered = services.AddResilientMultiTurnTask<string, string>(
            "keyed-multi-turn", (ctx, ct) => Task.FromResult(ctx.Input), steerable: true);

        using var provider = services.BuildServiceProvider();
        TaskDefinition<string, string> resolved =
            provider.GetRequiredKeyedService<TaskDefinition<string, string>>("keyed-multi-turn");

        Assert.That(resolved, Is.SameAs(registered));
    }

    [Test]
    public async Task GetResilientTaskResolvesRunnableDefinition()
    {
        string root = Path.Combine(Path.GetTempPath(), "agentserver-resolved-definition-" + System.Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITaskStore>(new LocalTaskStore(root));
            TaskDefinition<string, int> registered = services.AddResilientTask<string, int>(
                "len", (ctx, ct) => Task.FromResult(ctx.Input.Length));

            await using var provider = services.BuildServiceProvider();
            TaskDefinition<string, int> resolved = provider.GetResilientTask<string, int>("len");

            Assert.That(resolved, Is.SameAs(registered));
            Assert.That(await resolved.RunAsync("hello"), Is.EqualTo(5));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public void TaskEngineAccessorRejectsASecondEngine()
    {
        using var first = TaskTestHost.Create();
        using var second = TaskTestHost.Create();
        var accessor = new TaskEngineAccessor();

        accessor.Bind(first.Engine);

        Assert.Throws<System.InvalidOperationException>(() => accessor.Bind(second.Engine));
        Assert.That(accessor.Require(), Is.SameAs(first.Engine));
    }

    [Test]
    public void TwoTasksSharingTheSameTypesResolveIndependentlyByName()
    {
        // The whole point of keyed-by-name registration: two tasks with the identical
        // <TInput,TOutput> pair must not collide or shadow one another.
        var services = new ServiceCollection();
        TaskDefinition<string, string> a = services.AddResilientTask<string, string>(
            "task-a", (ctx, ct) => Task.FromResult("a:" + ctx.Input));
        TaskDefinition<string, string> b = services.AddResilientTask<string, string>(
            "task-b", (ctx, ct) => Task.FromResult("b:" + ctx.Input));

        using var provider = services.BuildServiceProvider();
        TaskDefinition<string, string> resolvedA = provider.GetResilientTask<string, string>("task-a");
        TaskDefinition<string, string> resolvedB = provider.GetResilientTask<string, string>("task-b");

        Assert.That(resolvedA, Is.SameAs(a));
        Assert.That(resolvedB, Is.SameAs(b));
        Assert.That(resolvedA, Is.Not.SameAs(resolvedB));
        Assert.That(resolvedA.Name, Is.EqualTo("task-a"));
        Assert.That(resolvedB.Name, Is.EqualTo("task-b"));
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
    public void InvalidFlatRegistrationDoesNotMutateServices()
    {
        var services = new ServiceCollection();

        Assert.Throws<System.ArgumentException>(() =>
            services.AddResilientTask<string, string>(
                string.Empty,
                (ctx, ct) => Task.FromResult(ctx.Input)));

        Assert.That(services, Is.Empty);
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
