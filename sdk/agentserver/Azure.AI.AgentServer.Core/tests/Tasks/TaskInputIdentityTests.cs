// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public class TaskInputIdentityTests
{
    private const string ActiveInputId = "active_input_id";
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    [TestCase(true)]
    [TestCase(false)]
    public async Task QueuedFollowupChecksLastAcceptedInput(bool latestHead)
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        TaskDefinition<string, string> definition = host.Builder.AddMultiTurnTask<string, string>(
            "chat", execution.RunAsync, steerable: true);
        var runs = new List<TaskRun<string>>();
        try
        {
            runs.Add(await definition.StartAsync("a", Options("a")));
            await execution.Entered("a").WaitAsync(Timeout);
            runs.Add(await definition.StartAsync("b", Options("b", "a")));
            if (latestHead)
            {
                runs.Add(await definition.StartAsync("c", Options("c", "b")));
                Assert.That(runs[2].IsQueued, Is.True);
                Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("c"));
            }
            else
            {
                ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(async () =>
                    runs.Add(await definition.StartAsync("c", Options("c", "a"))));
                Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.PreconditionFailed));
                Assert.That(error.ActualLastInputId, Is.EqualTo("b"));
            }
            Assert.That(Active((await host.Store.GetAsync("identity"))!), Is.EqualTo("a"));
        }
        finally
        {
            execution.ReleaseAll();
            await Settle(runs);
        }
    }

    [Test]
    public async Task PromotionDoesNotRewindAcceptedHeadOrChangeQueuedLookup()
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        TaskDefinition<string, string> definition = host.Builder.AddMultiTurnTask<string, string>(
            "chat", execution.RunAsync, steerable: true);
        var runs = new List<TaskRun<string>>();
        try
        {
            runs.Add(await definition.StartAsync("a", Options("a")));
            await execution.Entered("a").WaitAsync(Timeout);
            runs.Add(await definition.StartAsync("b", Options("b")));
            runs.Add(await definition.StartAsync("c", Options("c")));
            execution.Release("a");
            await execution.Entered("b").WaitAsync(Timeout);
            TaskRecord record = (await host.Store.GetAsync("identity"))!;
            Assert.That(Head(record), Is.EqualTo("c"));
            Assert.That(Active(record), Is.EqualTo("b"));
            Assert.That((await definition.GetActiveRunAsync("identity", "b"))!.InputId, Is.EqualTo("b"));
            Assert.That(await definition.GetActiveRunAsync("identity", "c"), Is.Null);
            execution.Release("b");
            await execution.Entered("c").WaitAsync(Timeout);
            Assert.That(Active((await host.Store.GetAsync("identity"))!), Is.EqualTo("c"));
        }
        finally
        {
            execution.ReleaseAll();
            await Settle(runs);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CancellingAcceptedTailDoesNotRewindHead(bool legacy)
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        TaskDefinition<string, string> definition = host.Builder.AddMultiTurnTask<string, string>(
            "chat", execution.RunAsync, steerable: true);
        var runs = new List<TaskRun<string>>();
        try
        {
            runs.Add(await definition.StartAsync("a", Options("a")));
            await execution.Entered("a").WaitAsync(Timeout);
            runs.Add(await definition.StartAsync("b", Options("b")));
            TaskRun<string> cancelled = await definition.StartAsync("c", Options("c"));
            runs.Add(cancelled);
            if (legacy)
            {
                TaskRecord old = (await host.Store.GetAsync("identity"))!;
                await host.Store.PatchAsync("identity", new TaskPatchRequest
                {
                    Payload = new JsonObject
                    {
                        [ActiveInputId] = null,
                        [TaskWireKeys.PayloadLastInputId] = "a",
                    },
                    PayloadSupplied = true,
                }, old.Etag);
            }
            await cancelled.RequestCancellationAsync().WaitAsync(Timeout);
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("c"));
            runs.Add(await definition.StartAsync("d", Options("d", "c")));
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("d"));
            Assert.That(Active((await host.Store.GetAsync("identity"))!), Is.EqualTo("a"));
        }
        finally
        {
            execution.ReleaseAll();
            await Settle(runs);
        }
        Assert.That(execution.Seen.Select(item => item.Input), Is.EqualTo(new[] { "a", "b", "d" }));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task RecoveryKeepsActiveIdentitySeparateFromAcceptedHead(bool legacy)
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        TaskDefinition<string, string> definition = host.Builder.AddMultiTurnTask<string, string>(
            "chat", execution.RunAsync, steerable: true);
        await Seed(host, legacy);
        try
        {
            TaskRun<string>? recovered = await definition.GetActiveRunAsync("identity", "a");
            await execution.Entered("a").WaitAsync(Timeout);
            Assert.That(recovered, Is.Not.Null);
            Assert.That(recovered!.InputId, Is.EqualTo("a"));
            Assert.That(execution.Seen.Single().InputId, Is.EqualTo("a"));
            TaskRecord record = (await host.Store.GetAsync("identity"))!;
            Assert.That(Head(record), Is.EqualTo("c"));
            Assert.That(Active(record), Is.EqualTo("a"));
            Assert.That(await definition.GetActiveRunAsync("identity", "c"), Is.Null);
            execution.Release("a");
            await execution.Entered("b").WaitAsync(Timeout);
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("c"));
            Assert.That(Active((await host.Store.GetAsync("identity"))!), Is.EqualTo("b"));
        }
        finally
        {
            execution.ReleaseAll();
            await WaitUntilInactive(host.Engine);
        }
        Assert.That(execution.Seen.Select(item => item.InputId), Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [Test]
    public async Task DeleteDiscoversActiveStreamAsWellAsAcceptedHeadAndQueue()
    {
        using var host = TaskTestHost.Create(configureStreams: options => options.UseInMemoryReplay());
        host.Builder.AddMultiTurnTask<string, string>("chat", (context, token) => Task.FromResult(context.Input), steerable: true);
        await Seed(host, legacy: false);
        var streams = (ITaskEventStreamRegistry)host.Streams;
        AgentEventStream[] backings = await Task.WhenAll(new[] { "a", "b", "c" }
            .Select(id => streams.GetOrCreateTaskStreamAsync("identity", id).AsTask()));
        using var stop = new CancellationTokenSource(Timeout);
        Task[] readers = backings.Select(stream => ReadToEnd(stream, stop.Token)).ToArray();
        try
        {
            await host.Engine.DeleteAsync("chat", "identity");
            await Task.WhenAll(readers).WaitAsync(Timeout);
            Assert.That(await host.Store.GetAsync("identity"), Is.Null);
        }
        finally
        {
            stop.Cancel();
            try
            {
                await Task.WhenAll(readers);
            }
            catch (OperationCanceledException) when (stop.IsCancellationRequested)
            {
                TestContext.WriteLine("Stopped diagnostic readers during cleanup.");
            }
        }
    }

    [Test]
    public async Task FailedAppendCannotExecuteAnUnacceptedInput()
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        host.Builder.AddMultiTurnTask<string, string>("chat", execution.RunAsync, steerable: true);
        var store = new GatedStore(host.Store) { PauseAppend = 1, FailPausedAppend = true };
        using var engine = new TaskEngine(store, host.Registry, host.AgentName, host.SessionId, host.Streams);
        TaskRun<string> first = await engine.StartAsync<string, string>("chat", "a", Options("a"));
        Task<TaskRun<string>>? append = null;
        try
        {
            await execution.Entered("a").WaitAsync(Timeout);
            append = engine.StartAsync<string, string>("chat", "b", Options("b"));
            await store.AppendEntered.Task.WaitAsync(Timeout);
            execution.Release("a");
            await WaitForPromotion(engine, "b");
            store.ReleaseAppend.TrySetResult();
            Assert.ThrowsAsync<IOException>(async () => await append.WaitAsync(Timeout));
            execution.ReleaseAll();
            await first.Completion.WaitAsync(Timeout);
            await WaitUntilInactive(engine);
            Assert.That(execution.Seen.Select(item => item.Input), Is.EqualTo(new[] { "a" }));
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("a"));
        }
        finally
        {
            store.ReleaseAppend.TrySetResult();
            execution.ReleaseAll();
            if (append is not null)
            {
                try
                { _ = await append.WaitAsync(Timeout); }
                catch (IOException) { TestContext.WriteLine("Observed rejected append during cleanup."); }
            }
            await WaitUntilInactive(engine);
        }
    }

    [Test]
    public async Task PromotionCannotRepersistAConcurrentRejectedAppend()
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        host.Builder.AddMultiTurnTask<string, string>("chat", execution.RunAsync, steerable: true);
        var store = new GatedStore(host.Store) { PauseAppend = 2, FailPausedAppend = true };
        using var engine = new TaskEngine(store, host.Registry, host.AgentName, host.SessionId, host.Streams);
        TaskRun<string> first = await engine.StartAsync<string, string>("chat", "a", Options("a"));
        TaskRun<string>? second = null;
        Task<TaskRun<string>>? rejected = null;
        try
        {
            await execution.Entered("a").WaitAsync(Timeout);
            second = await engine.StartAsync<string, string>("chat", "b", Options("b"));
            rejected = engine.StartAsync<string, string>("chat", "c", Options("c"));
            await store.AppendEntered.Task.WaitAsync(Timeout);
            execution.Release("a");
            await WaitForPromotion(engine, "b");
            store.ReleaseAppend.TrySetResult();
            Assert.ThrowsAsync<IOException>(async () => await rejected.WaitAsync(Timeout));
            await execution.Entered("b").WaitAsync(Timeout);
            TaskRecord record = (await host.Store.GetAsync("identity"))!;
            Assert.That(record.Payload[TaskWireKeys.PayloadSteering]![TaskWireKeys.SteeringPendingInputIds]!.AsArray(), Is.Empty);
            Assert.That(Head(record), Is.EqualTo("b"));
        }
        finally
        {
            store.ReleaseAppend.TrySetResult();
            execution.ReleaseAll();
            if (rejected is not null)
            {
                try
                { _ = await rejected.WaitAsync(Timeout); }
                catch (IOException) { TestContext.WriteLine("Observed rejected append during cleanup."); }
            }
            await first.Completion.WaitAsync(Timeout);
            if (second is not null)
            { await second.Completion.WaitAsync(Timeout); }
            await WaitUntilInactive(engine);
        }
    }

    [Test]
    public async Task ConcurrentConditionalAppendsHaveOnlyOneWinner()
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        host.Builder.AddMultiTurnTask<string, string>("chat", execution.RunAsync, steerable: true);
        var store = new GatedStore(host.Store) { PauseAppend = 1 };
        using var engine = new TaskEngine(store, host.Registry, host.AgentName, host.SessionId, host.Streams);
        var runs = new List<TaskRun<string>>();
        Task<TaskRun<string>>? firstAppend = null;
        Task<TaskRun<string>>? secondAppend = null;
        try
        {
            runs.Add(await engine.StartAsync<string, string>("chat", "a", Options("a")));
            await execution.Entered("a").WaitAsync(Timeout);
            firstAppend = engine.StartAsync<string, string>("chat", "b", Options("b", "a"));
            await store.AppendEntered.Task.WaitAsync(Timeout);
            secondAppend = engine.StartAsync<string, string>("chat", "c", Options("c", "a"));
            store.ReleaseAppend.TrySetResult();
            runs.Add(await firstAppend.WaitAsync(Timeout));
            ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
                async () => runs.Add(await secondAppend.WaitAsync(Timeout)));
            Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.PreconditionFailed));
            Assert.That(error.ActualLastInputId, Is.EqualTo("b"));
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("b"));
        }
        finally
        {
            store.ReleaseAppend.TrySetResult();
            execution.ReleaseAll();
            if (firstAppend is not null)
            { await firstAppend.WaitAsync(Timeout); }
            if (secondAppend is not null)
            {
                try
                { await secondAppend.WaitAsync(Timeout); }
                catch (ResilientTaskException) { TestContext.WriteLine("Observed stale conditional append during cleanup."); }
            }
            await Settle(runs);
            await WaitUntilInactive(engine);
        }
    }

    [Test]
    public async Task WriterRollbackRunsBeforeTheWriteGateIsReleased()
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        host.Builder.AddMultiTurnTask<string, string>("chat", execution.RunAsync, steerable: true);
        TaskRun<string> run = await host.Engine.StartAsync<string, string>("chat", "a", Options("a"));
        bool rolledBack = false;
        try
        {
            await execution.Entered("a").WaitAsync(Timeout);
            Assert.ThrowsAsync<IOException>(async () =>
                await host.Engine.Serializer.UpdateAndPublishAsync(
                    "identity",
                    _ => throw new IOException("Compute failed."),
                    WriteIntent.SteeringAppend,
                    () => Assert.Fail("A failed write cannot publish acceptance."),
                    () =>
                    {
                        Assert.That(host.Engine.Serializer.GetOrAddEntry("identity").WriteGate.CurrentCount, Is.Zero);
                        rolledBack = true;
                    }));
            Assert.That(rolledBack, Is.True);
            Assert.That(host.Engine.Serializer.GetOrAddEntry("identity").WriteGate.CurrentCount, Is.EqualTo(1));
        }
        finally
        {
            execution.ReleaseAll();
            await run.Completion.WaitAsync(Timeout);
        }
    }

    [Test]
    public async Task LegacyRecordsWithoutInputIdsDoNotInventQueueIdentities()
    {
        using var host = TaskTestHost.Create();
        TaskRecord record = await Seed(host, legacy: true);
        record.Payload[TaskWireKeys.PayloadSteering]!.AsObject().Remove(TaskWireKeys.SteeringPendingInputIds);
        Assert.That(TaskInputIdentity.Active(record, "identity"), Is.EqualTo("a"));
        Assert.That(TaskInputIdentity.Accepted(record), Is.EqualTo("a"));
        var patch = new JsonObject();
        TaskInputIdentity.PreserveLegacy(record, patch, "identity");
        Assert.That((string?)patch[ActiveInputId], Is.EqualTo("a"));
        Assert.That((string?)patch[TaskWireKeys.PayloadLastInputId], Is.EqualTo("a"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task MissingAcceptedHeadSeedsTheChainAsPythonDoes(bool pendingRecord)
    {
        using var host = TaskTestHost.Create();
        var execution = new Execution();
        TaskDefinition<string, string> definition = host.Builder.AddMultiTurnTask<string, string>(
            "chat", execution.RunAsync, steerable: true);
        if (pendingRecord)
        {
            await host.Store.CreateAsync(new TaskCreateRequest
            {
                Id = "identity",
                AgentName = host.AgentName,
                SessionId = host.SessionId,
                Title = "pending identity",
                Status = TaskWireKeys.StatusPending,
                Payload = new JsonObject { [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue },
                Source = new JsonObject { ["type"] = TaskWireKeys.SourceTypeValue, ["name"] = "chat" },
            });
        }
        TaskRun<string>? run = null;
        try
        {
            run = await definition.StartAsync("a", Options("a", "external-predecessor"));
            Assert.That(Head((await host.Store.GetAsync("identity"))!), Is.EqualTo("a"));
            Assert.That(Active((await host.Store.GetAsync("identity"))!), Is.EqualTo("a"));
        }
        finally
        {
            execution.ReleaseAll();
            if (run is not null)
            { await run.Completion.WaitAsync(Timeout); }
        }
    }

    private static RunOptions Options(string input, string? expected = null)
        => new() { TaskId = "identity", InputId = input, IfLastInputId = expected };

    private static string? Head(TaskRecord record) => (string?)record.Payload[TaskWireKeys.PayloadLastInputId];
    private static string? Active(TaskRecord record) => (string?)record.Payload[ActiveInputId];

    private static Task<TaskRecord> Seed(TaskTestHost host, bool legacy)
    {
        var payload = new JsonObject
        {
            [TaskWireKeys.PayloadInput] = "a",
            [TaskWireKeys.PayloadLastInputId] = legacy ? "a" : "c",
            [TaskWireKeys.PayloadTurnStartedAt] = DateTimeOffset.UtcNow.ToString("O"),
            [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
            [TaskWireKeys.PayloadSteering] = new JsonObject
            {
                [TaskWireKeys.SteeringPendingInputs] = new JsonArray("b", "c"),
                [TaskWireKeys.SteeringPendingInputIds] = new JsonArray("b", "c"),
                [TaskWireKeys.SteeringNextInputSeq] = 0,
            },
        };
        if (!legacy)
        { payload[ActiveInputId] = "a"; }
        return host.Store.CreateAsync(new TaskCreateRequest
        {
            Id = "identity",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "recover identity",
            Status = TaskWireKeys.StatusInProgress,
            LeaseOwner = host.Engine.Owner,
            LeaseInstanceId = "previous-instance",
            LeaseDurationSeconds = 60,
            Payload = payload,
            Source = new JsonObject { ["type"] = TaskWireKeys.SourceTypeValue, ["name"] = "chat" },
        });
    }

    private static async Task ReadToEnd(AgentEventStream stream, CancellationToken cancellationToken)
    {
        await foreach (var item in stream.Subscribe(cancellationToken: cancellationToken))
        { _ = item; }
    }

    private static async Task Settle(IEnumerable<TaskRun<string>> runs)
    {
        foreach (TaskRun<string> run in runs)
        {
            try
            { _ = await run.Completion.WaitAsync(Timeout); }
            catch (OperationCanceledException) { TestContext.WriteLine("Observed cancelled queued input during cleanup."); }
        }
    }

    private static async Task WaitUntilInactive(TaskEngine engine)
    {
        using var timeout = new CancellationTokenSource(Timeout);
        while (engine.IsActive("identity"))
        { await Task.Delay(10, timeout.Token); }
    }

    private static async Task WaitForPromotion(TaskEngine engine, string inputId)
    {
        var active = (IDictionary)typeof(TaskEngine).GetField("_activeRuns", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(engine)!;
        using var timeout = new CancellationTokenSource(Timeout);
        while (true)
        {
            object? run = active["identity"];
            if (run?.GetType().GetField("_promoting", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(run)
                is TaskRunState<string> state && state.InputId == inputId)
            {
                return;
            }
            await Task.Delay(10, timeout.Token);
        }
    }

    private sealed class Execution
    {
        private readonly ConcurrentDictionary<string, TaskCompletionSource> _entered = new();
        private readonly ConcurrentDictionary<string, TaskCompletionSource> _release = new();
        private readonly TaskCompletionSource _all = Signal();
        public ConcurrentQueue<(string Input, string InputId)> Seen { get; } = new();
        private static TaskCompletionSource Signal() => new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task Entered(string input) => _entered.GetOrAdd(input, _ => Signal()).Task;
        public void Release(string input) => _release.GetOrAdd(input, _ => Signal()).TrySetResult();
        public void ReleaseAll() => _all.TrySetResult();
        public async Task<string> RunAsync(TaskContext<string> context, CancellationToken cancellationToken)
        {
            Seen.Enqueue((context.Input, context.InputId));
            _entered.GetOrAdd(context.Input, _ => Signal()).TrySetResult();
            await Task.WhenAny(_release.GetOrAdd(context.Input, _ => Signal()).Task, _all.Task);
            return context.Input;
        }
    }

    private sealed class GatedStore(ITaskStore inner) : ITaskStore
    {
        private int _appends;
        public int PauseAppend { get; init; }
        public bool FailPausedAppend { get; init; }
        public TaskCompletionSource AppendEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseAppend { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default) => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default) => inner.GetAsync(taskId, cancellationToken);
        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default) => inner.ListAsync(query, cancellationToken);
        public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (patch.Status is null && patch.Payload?[TaskWireKeys.PayloadSteering] is not null
                && Interlocked.Increment(ref _appends) == PauseAppend)
            {
                AppendEntered.TrySetResult();
                await ReleaseAppend.Task.WaitAsync(Timeout, cancellationToken);
                if (FailPausedAppend)
                { throw new IOException("Rejected steering append."); }
            }
            return await inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
    }
}
