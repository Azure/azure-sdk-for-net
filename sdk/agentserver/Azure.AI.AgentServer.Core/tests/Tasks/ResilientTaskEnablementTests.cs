// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class ResilientTaskEnablementTests
{
    [Test]
    public async Task RegisteredTask_DefaultsDisabled_AndDoesNotResolveStoreAtStartup()
    {
        int storeResolutions = 0;
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<ITaskStore>(_ =>
        {
            Interlocked.Increment(ref storeResolutions);
            throw new InvalidOperationException("The disabled task store must not resolve.");
        });
        TaskDefinition<string, string> task = builder.Services.AddResilientTask<string, string>(
            "disabled",
            (ctx, ct) => Task.FromResult(ctx.Input));

        using IHost host = builder.Build();
        await host.StartAsync();

        Assert.Multiple(() =>
        {
            Assert.That(
                host.Services.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.False);
            Assert.That(storeResolutions, Is.Zero);
        });

        TaskDefinition<string, string> resolved =
            host.Services.GetResilientTask<string, string>("disabled");
        Assert.That(resolved, Is.SameAs(task));
        Assert.That(storeResolutions, Is.Zero);

        ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
            () => resolved.RunAsync("payload"))!;
        Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
        Assert.That(storeResolutions, Is.Zero);

        await host.StopAsync();
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task ExplicitEnablement_RunsTask_RegardlessOfRegistrationOrder(bool enableFirst)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(root));
            TaskDefinition<string, string> task;
            if (enableFirst)
            {
                builder.SetResilientTasksEnabled();
                task = builder.Services.AddResilientTask<string, string>(
                    "enabled",
                    (ctx, ct) => Task.FromResult("done:" + ctx.Input));
            }
            else
            {
                task = builder.Services.AddResilientTask<string, string>(
                    "enabled",
                    (ctx, ct) => Task.FromResult("done:" + ctx.Input));
                builder.SetResilientTasksEnabled();
            }

            using IHost host = builder.Build();
            await host.StartAsync();

            Assert.That(
                host.Services.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.True);
            Assert.That(await task.RunAsync("payload"), Is.EqualTo("done:payload"));

            await host.StopAsync();
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task SetResilientTasksEnabled_DefaultArgumentEnablesServiceCollection()
    {
        var services = new ServiceCollection();

        services.SetResilientTasksEnabled();

        await using ServiceProvider provider = services.BuildServiceProvider();
        Assert.Multiple(() =>
        {
            Assert.That(
                provider.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.True);
            Assert.That(
                provider.GetServices<IHostedService>().OfType<TaskDurabilityService>(),
                Is.Not.Empty,
                "Opting in without declaring a task must still prepare the manager/recovery service.");
        });
    }

    [Test]
    public async Task EnabledStartup_RecoveryInitializationFailureFailsHost()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-failure-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            builder.Services.AddSingleton<ITaskStore>(
                new FailingListStore(new LocalTaskStore(root)));
            builder.Services.AddResilientTask<string, string>(
                "enabled",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            IOException exception = Assert.ThrowsAsync<IOException>(
                () => host.StartAsync())!;
            Assert.That(exception.Message, Does.Contain("startup recovery"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task EnabledStartup_TaskStoreTimeoutFailsHost()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-timeout-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            builder.Services.AddSingleton<ITaskStore>(
                new FailingListStore(
                    new LocalTaskStore(root),
                    new TaskCanceledException("Injected task-store timeout.")));
            builder.Services.AddResilientTask<string, string>(
                "enabled",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            TaskCanceledException exception = Assert.ThrowsAsync<TaskCanceledException>(
                () => host.StartAsync())!;
            Assert.That(exception.Message, Does.Contain("task-store timeout"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task OptInWithoutTaskDeclaration_StillRunsStartupRecovery()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-switch-only-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            var store = new CountingListStore(new LocalTaskStore(root));
            builder.Services.AddSingleton<ITaskStore>(store);

            using IHost host = builder.Build();
            await host.StartAsync();

            Assert.That(store.ListCalls, Is.GreaterThan(0));
            await host.StopAsync();
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task EnabledDefinition_IsCallableOnlyWhileRuntimeIsReady()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-readiness-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(root));
            TaskDefinition<string, string> task = builder.Services.AddResilientTask<string, string>(
                "ready",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            Assert.ThrowsAsync<InvalidOperationException>(() => task.RunAsync("before-start"));

            await host.StartAsync();
            Assert.That(await task.RunAsync("running"), Is.EqualTo("running"));

            await host.StopAsync();
            Assert.ThrowsAsync<InvalidOperationException>(() => task.RunAsync("after-stop"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task HostedServiceRegisteredBeforeCore_CannotRunTaskBeforeRecovery()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-order-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            var holder = new TaskDefinitionHolder();
            builder.Services.AddSingleton(holder);
            builder.Services.AddSingleton<IHostedService, EarlyTaskProbe>();
            builder.SetResilientTasksEnabled();
            builder.Services.AddSingleton<ITaskStore>(new LocalTaskStore(root));
            holder.Definition = builder.Services.AddResilientTask<string, string>(
                "ordered",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            await host.StartAsync();

            var probe = (EarlyTaskProbe)host.Services
                .GetServices<IHostedService>()
                .Single(service => service is EarlyTaskProbe);
            Assert.That(probe.StartException, Is.InstanceOf<InvalidOperationException>());
            Assert.That(await holder.Definition.RunAsync("after-start"), Is.EqualTo("after-start"));

            await host.StopAsync();
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task Shutdown_CancelsAdmittedStartBeforeItCanBecomeActive()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-start-race-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            var store = new GatedCreateStore(new LocalTaskStore(root));
            builder.Services.AddSingleton<ITaskStore>(store);
            TaskDefinition<string, string> task = builder.Services.AddResilientTask<string, string>(
                "race",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            await host.StartAsync();

            Task<TaskRun<string>> start = task.StartAsync(
                "payload",
                new RunOptions { TaskId = "shutdown-race" });
            await store.CreateEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

            Task stop = host.StopAsync();
            ResilientTaskEnablementState enablement =
                host.Services.GetRequiredService<ResilientTaskEnablementState>();
            var timeout = System.Diagnostics.Stopwatch.StartNew();
            while (enablement.IsReady && timeout.Elapsed < TimeSpan.FromSeconds(5))
            {
                await Task.Delay(10);
            }

            Assert.That(enablement.IsReady, Is.False, "shutdown must revoke readiness first");
            store.ReleaseCreate.TrySetResult();

            Assert.ThrowsAsync<OperationCanceledException>(async () => await start);
            await stop.WaitAsync(TimeSpan.FromSeconds(5));
            Assert.That(
                host.Services.GetRequiredService<TaskEngine>().IsActive("shutdown-race"),
                Is.False);
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task ShutdownDeadline_DoesNotPermitLateActiveRunPublication()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-start-timeout-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            var store = new GatedCreateStore(new LocalTaskStore(root));
            builder.Services.AddSingleton<ITaskStore>(store);
            TaskDefinition<string, string> task = builder.Services.AddResilientTask<string, string>(
                "race",
                (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            await host.StartAsync();

            Task<TaskRun<string>> start = task.StartAsync(
                "payload",
                new RunOptions { TaskId = "shutdown-timeout-race" });
            await store.CreateEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

            var expiredDeadline = new CancellationTokenSource();
            expiredDeadline.Cancel();
            TaskEngine engine = host.Services.GetRequiredService<TaskEngine>();
            await engine.ShutdownAsync(TimeSpan.Zero, expiredDeadline.Token);

            Assert.That(start.IsCompleted, Is.False);
            store.ReleaseCreate.TrySetResult();

            Assert.ThrowsAsync<OperationCanceledException>(async () => await start);
            Assert.That(engine.IsActive("shutdown-timeout-race"), Is.False);
            await host.StopAsync().WaitAsync(TimeSpan.FromSeconds(5));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task AmbiguousCreateFailure_ExpiresCommittedLease(bool multiTurn)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-task-optin-create-failure-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.SetResilientTasksEnabled();
            var store = new CommitThenFailCreateStore(new LocalTaskStore(root));
            builder.Services.AddSingleton<ITaskStore>(store);
            TaskDefinition<string, string> task = multiTurn
                ? builder.Services.AddResilientMultiTurnTask<string, string>(
                    "create-failure",
                    (ctx, ct) => Task.FromResult(ctx.Input))
                : builder.Services.AddResilientTask<string, string>(
                    "create-failure",
                    (ctx, ct) => Task.FromResult(ctx.Input));

            using IHost host = builder.Build();
            await host.StartAsync();

            Assert.ThrowsAsync<IOException>(async () =>
                await task.StartAsync(
                    "payload",
                    new RunOptions { TaskId = "ambiguous-create" }));

            TaskRecord? record = await store.GetAsync("ambiguous-create");
            Assert.That(record, Is.Not.Null);
            Assert.That(record!.Status, Is.EqualTo(TaskWireKeys.StatusInProgress));
            Assert.That(record.Lease, Is.Not.Null);
            Assert.That(
                DateTimeOffset.Parse(record.Lease!.ExpiresAt),
                Is.LessThanOrEqualTo(DateTimeOffset.UtcNow));
            Assert.That(
                host.Services.GetRequiredService<TaskEngine>().IsActive("ambiguous-create"),
                Is.False);

            await host.StopAsync();
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public void Enablement_IsIsolatedPerServiceProvider()
    {
        var enabledServices = new ServiceCollection();
        enabledServices.SetResilientTasksEnabled();
        var disabledServices = new ServiceCollection();
        disabledServices.AddResilientTask<string, string>(
            "disabled",
            (ctx, ct) => Task.FromResult(ctx.Input));

        using ServiceProvider enabledProvider = enabledServices.BuildServiceProvider();
        using ServiceProvider disabledProvider = disabledServices.BuildServiceProvider();

        Assert.Multiple(() =>
        {
            Assert.That(
                enabledProvider.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.True);
            Assert.That(
                disabledProvider.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
                Is.False);
        });
    }

    [Test]
    public void LaterExplicitDisableWinsBeforeStartup()
    {
        var services = new ServiceCollection();
        services.SetResilientTasksEnabled();
        services.SetResilientTasksEnabled(false);
        TaskDefinition<string, string> task = services.AddResilientTask<string, string>(
            "disabled",
            (ctx, ct) => Task.FromResult(ctx.Input));

        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
            Is.False);
        Assert.That(
            Assert.ThrowsAsync<ResilientTaskException>(() => task.RunAsync("payload"))!.ErrorCode,
            Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
    }

    [Test]
    public void AgentHostBuilderOptInConfiguresItsServiceCollection()
    {
        AgentHostBuilder builder = AgentHost.CreateBuilder();

        Assert.That(builder.SetResilientTasksEnabled(), Is.SameAs(builder));

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<IOptions<ResilientTaskOptions>>().Value.Enabled,
            Is.True);
    }

    private sealed class FailingListStore(
        ITaskStore inner,
        Exception? failure = null) : ITaskStore
    {
        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default)
            => inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
            => Task.FromException<TaskListResult>(
                failure ?? new IOException("Injected startup recovery failure."));
    }

    private sealed class CountingListStore(ITaskStore inner) : ITaskStore
    {
        private int _listCalls;

        public int ListCalls => Volatile.Read(ref _listCalls);

        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default)
            => inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _listCalls);
            return inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class GatedCreateStore(ITaskStore inner) : ITaskStore
    {
        public TaskCompletionSource CreateEntered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseCreate { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            CreateEntered.TrySetResult();
            await ReleaseCreate.Task.ConfigureAwait(false);
            // Deliberately ignore cancellation to model a provider that commits after shutdown.
            return await inner.CreateAsync(request, CancellationToken.None).ConfigureAwait(false);
        }

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default)
            => inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
    }

    private sealed class CommitThenFailCreateStore(ITaskStore inner) : ITaskStore
    {
        private int _failCreate = 1;

        public async Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            TaskRecord record = await inner.CreateAsync(request, CancellationToken.None);
            if (Interlocked.Exchange(ref _failCreate, 0) == 1)
            {
                throw new IOException("Simulated transport failure after create commit.");
            }

            return record;
        }

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default)
            => inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
    }

    private sealed class TaskDefinitionHolder
    {
        public TaskDefinition<string, string> Definition { get; set; } = null!;
    }

    private sealed class EarlyTaskProbe(TaskDefinitionHolder holder) : IHostedService
    {
        public Exception? StartException { get; private set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await holder.Definition.RunAsync("too-early", cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                StartException = ex;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
