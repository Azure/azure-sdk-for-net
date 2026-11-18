// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class RecoveryLeaseReleaseTests
{
    [TestCase(false, false, false)]
    [TestCase(true, false, false)]
    [TestCase(true, false, true)]
    [TestCase(false, true, false)]
    [TestCase(true, true, true)]
    public async Task FailedLeaseReleaseLeavesTaskRecoverable(bool multiTurn, bool canceled, bool queueInput)
    {
        using var host = TaskTestHost.Create();
        var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var exit = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        async Task<string> Handler(TaskContext<string> context, CancellationToken cancellationToken)
        {
            entered.TrySetResult();
            await exit.Task;
            await context.ExitForRecoveryAsync(new CancellationToken(canceled));
            return context.Input;
        }

        if (multiTurn)
        {
            host.Builder.AddMultiTurnTask<string, string>("recovery", Handler, steerable: true);
        }
        else
        {
            host.Builder.AddTask<string, string>("recovery", Handler);
        }

        var store = new RejectReleaseStore(host.Store);
        using var engine = new TaskEngine(store, host.Registry, host.AgentName, host.SessionId, host.Streams);
        TaskRun<string> run = await engine.StartAsync<string, string>(
            "recovery", "first", new RunOptions { TaskId = "recovery-1", InputId = "input-1" });
        await entered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        if (queueInput)
        {
            await engine.StartAsync<string, string>(
                "recovery", "second", new RunOptions { TaskId = "recovery-1", InputId = "input-2" });
        }

        engine.SignalShutdown();
        exit.TrySetResult();
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        while (engine.IsActive(run.TaskId))
        {
            await Task.Delay(20, timeout.Token);
        }

        Assert.That(store.ReleasesRejected, Is.EqualTo(canceled ? 0 : 1));
        TaskRecord? record = await host.Store.GetAsync(run.TaskId);
        Assert.That(record, Is.Not.Null, "a failed release must not delete the task");
        Assert.That(record!.Status, Is.EqualTo("in_progress"), "a failed release must not suspend the task");
        Assert.That(record.Lease, Is.Not.Null);
        Assert.That(DateTimeOffset.Parse(record.Lease!.ExpiresAt), Is.GreaterThan(DateTimeOffset.UtcNow));
        Assert.That(run.Completion.IsCompleted, Is.False);

        using var restarted = host.Restart(new TaskRegistry());
        var observed = new ConcurrentQueue<(string Input, EntryMode Mode)>();
        var allObserved = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Task<string> Recover(TaskContext<string> context, CancellationToken cancellationToken)
        {
            observed.Enqueue((context.Input, context.EntryMode));
            if (observed.Count == (queueInput ? 2 : 1))
            {
                allObserved.TrySetResult();
            }
            return Task.FromResult(context.Input);
        }

        if (multiTurn)
        {
            restarted.Builder.AddMultiTurnTask<string, string>("recovery", Recover, steerable: true);
        }
        else
        {
            restarted.Builder.AddTask<string, string>("recovery", Recover);
        }

        // The store permits a new instance of the same stable owner to take over a live lease.
        Assert.That(await restarted.Engine.ScanAndRecoverAsync(), Is.EqualTo(1));
        await allObserved.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(observed, Is.EqualTo(queueInput
            ? new[] { ("first", EntryMode.Recovered), ("second", EntryMode.Resumed) }
            : new[] { ("first", EntryMode.Recovered) }));
        await restarted.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task HandlerFailureAfterFailedReleaseIsNotHidden()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("recovery", async (context, cancellationToken) =>
        {
            await context.ExitForRecoveryAsync();
            throw new InvalidOperationException("handler failed");
        });
        var store = new RejectReleaseStore(host.Store);
        using var engine = new TaskEngine(store, host.Registry, host.AgentName, host.SessionId, host.Streams);
        engine.SignalShutdown();
        TaskRun<string> run = await engine.StartAsync<string, string>(
            "recovery", "input", new RunOptions { TaskId = "recovery-1" });

        ResilientTaskException failure = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await run.Completion.WaitAsync(TimeSpan.FromSeconds(5)))!;
        Assert.That(store.ReleasesRejected, Is.EqualTo(1));
        Assert.That(failure.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.HandlerError));
        Assert.That(failure.InnerException, Is.TypeOf<InvalidOperationException>());
    }

    private sealed class RejectReleaseStore(ITaskStore inner) : ITaskStore
    {
        public int ReleasesRejected { get; private set; }

        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);

        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);

        public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (patch.LeaseDurationSeconds == 0)
            {
                ReleasesRejected++;
                throw TaskStoreException.InvalidRequest("Injected lease-release failure.", taskId);
            }

            return inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
    }
}
