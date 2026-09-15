// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public class TaskSuspensionAdmissionTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    [TestCase("completed")]
    [TestCase("failed")]
    [TestCase("cancelled")]
    public async Task GateDelayedInputExecutesInsteadOfBeingErasedBySuspension(string outcome)
    {
        await using var host = new Host(outcome);
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.Start("b");
        host.Store.BlockTrim = true;
        Task cancelling = b.RequestCancellationAsync();
        host.Operations.Add(cancelling);
        await host.Store.TrimEntered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> startingC = host.Start("c");
        if (outcome == "cancelled")
        {
            await a.RequestCancellationAsync().WaitAsync(Timeout);
        }
        host.ReleaseA.TrySetResult();
        await host.WaitForWriters(3);
        host.Store.ReleaseTrim.TrySetResult();

        await cancelling.WaitAsync(Timeout);
        TaskRun<string> c = await startingC.WaitAsync(Timeout);
        Assert.That(c.IsQueued, Is.True);
        Assert.That(c.InputId, Is.EqualTo("c"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
        if (outcome == "completed")
        {
            Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        }
        else if (outcome == "cancelled")
        {
            Assert.That(async () => await a.Completion, Throws.InstanceOf<OperationCanceledException>());
        }
        else
        {
            Assert.ThrowsAsync<ResilientTaskException>(async () => await a.Completion);
        }
        Assert.That(async () => await b.Completion, Throws.InstanceOf<OperationCanceledException>());
        Assert.That(host.Executed, Is.EqualTo(new[] { "a", "c" }));
        TaskRecord record = (await host.Store.GetAsync("suspend-admission"))!;
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo("c"));
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadActiveInputId], Is.EqualTo("c"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task InputBehindCommittedSuspensionResumesWithItsOwnIdentity(bool automaticId)
    {
        await using var host = new Host("completed");
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        host.Store.BlockSuspend = true;
        host.ReleaseA.TrySetResult();
        await host.Store.SuspendEntered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> startingC = host.Start("c", automaticId: automaticId, expected: "a");
        await host.WaitForWriters(2);
        host.Store.ReleaseSuspend.TrySetResult();
        TaskRun<string> c = await startingC.WaitAsync(Timeout);
        Assert.That(c.IsQueued, Is.False);
        Assert.That(c.InputId, Is.Not.EqualTo("a"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
        Assert.That(host.Identities["c"], Is.EqualTo(c.InputId));
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a", "c" }));
    }

    [Test]
    public async Task ReroutedInputStillEnforcesItsPrecondition()
    {
        await using var host = new Host("completed");
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        host.Store.BlockSuspend = true;
        host.ReleaseA.TrySetResult();
        await host.Store.SuspendEntered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> startingC = host.Start("c", expected: "wrong");
        await host.WaitForWriters(2);
        host.Store.ReleaseSuspend.TrySetResult();
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await startingC.WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.PreconditionFailed));
        Assert.That(error.ActualLastInputId, Is.EqualTo("a"));
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task FailedSuspensionDoesNotAcceptAWaitingInputIntoAnAbandonedRun()
    {
        await using var host = new Host("completed");
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        host.Store.BlockSuspend = true;
        host.Store.FailSuspend = true;
        host.ReleaseA.TrySetResult();
        await host.Store.SuspendEntered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> startingC = host.Start("c");
        await host.WaitForWriters(2);
        host.Store.ReleaseSuspend.TrySetResult();
        ResilientTaskException? rejected = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await startingC.WaitAsync(Timeout));
        Assert.That(rejected!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.ThrowsAsync<ResilientTaskException>(async () => await a.Completion.WaitAsync(Timeout));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
        Assert.That((await host.Store.GetAsync("suspend-admission"))!.Status, Is.EqualTo(TaskWireKeys.StatusInProgress));
    }

    [Test]
    public async Task CancelledWaiterDoesNotResumeAfterSuspension()
    {
        await using var host = new Host("completed");
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        host.Store.BlockSuspend = true;
        host.ReleaseA.TrySetResult();
        await host.Store.SuspendEntered.Task.WaitAsync(Timeout);
        using var cancellation = new CancellationTokenSource();
        Task<TaskRun<string>> startingC = host.Start("c", cancellationToken: cancellation.Token);
        await host.WaitForWriters(2);
        cancellation.Cancel();
        Assert.That(async () => await startingC.WaitAsync(Timeout), Throws.InstanceOf<OperationCanceledException>());
        host.Store.ReleaseSuspend.TrySetResult();
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task OldStreamClosureDoesNotBlockOrDetachResumedInput()
    {
        await using var host = new Host("completed");
        host.Streams.BlockA = true;
        host.BlockC = true;
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        host.ReleaseA.TrySetResult();
        await host.Streams.CloseEntered.Task.WaitAsync(Timeout);
        TaskRun<string> c = await host.Start("c").WaitAsync(Timeout);
        await host.EnteredC.Task.WaitAsync(Timeout);
        Assert.That(c.IsQueued, Is.False);
        host.Streams.ReleaseClose.TrySetResult();
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Engine.IsActive("suspend-admission"), Is.True);
        Assert.That(c.Completion.IsCompleted, Is.False);
        host.ReleaseC.TrySetResult();
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [Test]
    public async Task DeletionWinsWhileSuspensionAndAppendWaitForTheGate()
    {
        await using var host = new Host("completed");
        TaskRun<string> a = await host.Start("a");
        await host.EnteredA.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.Start("b");
        host.Store.BlockTrim = true;
        Task cancelling = b.RequestCancellationAsync();
        host.Operations.Add(cancelling);
        await host.Store.TrimEntered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> startingC = host.Start("c");
        host.ReleaseA.TrySetResult();
        await host.WaitForWriters(3);
        await host.Engine.DeleteAsync("chat", "suspend-admission").WaitAsync(Timeout);
        host.Store.ReleaseTrim.TrySetResult();
        Assert.ThrowsAsync<TaskStoreException>(async () => await cancelling.WaitAsync(Timeout));
        Assert.That(async () => await startingC.WaitAsync(Timeout),
            Throws.InstanceOf<TaskStoreException>().Or.InstanceOf<ResilientTaskException>());
        Assert.That(async () => await a.Completion.WaitAsync(Timeout), Throws.InstanceOf<OperationCanceledException>());
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
        Assert.That(await host.Store.GetAsync("suspend-admission"), Is.Null);
    }

    private sealed class Host : IAsyncDisposable
    {
        private readonly TaskTestHost _host = TaskTestHost.Create();
        private readonly List<Task<TaskRun<string>>> _starts = new();
        public Host(string outcome)
        {
            Store = new Store(_host.Store);
            Engine = new TaskEngine(Store, _host.Registry, _host.AgentName, _host.SessionId, Streams);
            _host.Builder.AddMultiTurnTask<string, string>("chat", async (context, token) =>
            {
                Executed.Enqueue(context.Input);
                Identities[context.Input] = context.InputId;
                await context.Stream.EmitAsync(new SseItem<string>(context.Input) { EventId = "1" });
                if (context.Input == "a")
                {
                    EnteredA.TrySetResult();
                    await ReleaseA.Task;
                    if (outcome == "failed")
                    { throw new InvalidOperationException("Handler failed."); }
                    if (outcome == "cancelled")
                    { throw new OperationCanceledException(context.Cancellation); }
                }
                if (context.Input == "c")
                {
                    EnteredC.TrySetResult();
                    if (BlockC)
                    { await ReleaseC.Task; }
                }
                return context.Input;
            }, steerable: true);
        }

        public Store Store { get; }
        public TaskEngine Engine { get; }
        public BlockingStreams Streams { get; } = new();
        public bool BlockC { get; set; }
        public ConcurrentQueue<string> Executed { get; } = new();
        public ConcurrentDictionary<string, string> Identities { get; } = new();
        public List<Task> Operations { get; } = new();
        public TaskCompletionSource EnteredA { get; } = Signal();
        public TaskCompletionSource EnteredC { get; } = Signal();
        public TaskCompletionSource ReleaseA { get; } = Signal();
        public TaskCompletionSource ReleaseC { get; } = Signal();
        private static TaskCompletionSource Signal() => new(TaskCreationOptions.RunContinuationsAsynchronously);

        public Task<TaskRun<string>> Start(string input, bool automaticId = false, string? expected = null, CancellationToken cancellationToken = default)
        {
            Task<TaskRun<string>> start = Engine.StartAsync<string, string>("chat", input,
                new RunOptions { TaskId = "suspend-admission", InputId = automaticId ? null : input, IfLastInputId = automaticId ? null : expected },
                cancellationToken);
            _starts.Add(start);
            return start;
        }

        public async Task WaitForWriters(int count)
        {
            ActiveTaskEntry entry = Engine.Serializer.GetOrAddEntry("suspend-admission");
            using var timeout = new CancellationTokenSource(Timeout);
            while (true)
            {
                lock (entry.ReapLock)
                {
                    if (entry.RefCount >= count)
                    { return; }
                }
                await Task.Delay(10, timeout.Token);
            }
        }

        public async ValueTask DisposeAsync()
        {
            ReleaseA.TrySetResult();
            ReleaseC.TrySetResult();
            Store.ReleaseTrim.TrySetResult();
            Store.ReleaseSuspend.TrySetResult();
            Streams.ReleaseClose.TrySetResult();
            foreach (Task operation in Operations)
            { await Observe(operation); }
            foreach (Task<TaskRun<string>> start in _starts)
            {
                await Observe(start);
                if (start.IsCompletedSuccessfully)
                {
                    TaskRun<string> run = await start;
                    if (run.Completion.IsCompleted)
                    { await Observe(run.Completion); }
                }
            }
            using var timeout = new CancellationTokenSource(Timeout);
            while (Engine.IsActive("suspend-admission"))
            { await Task.Delay(10, timeout.Token); }
            Engine.Dispose();
            await Streams.DisposeAsync();
            _host.Dispose();
        }

        private static async Task Observe(Task task)
        {
            try
            { await task.WaitAsync(Timeout); }
            catch (Exception exception) when (exception is ResilientTaskException or OperationCanceledException or TaskStoreException)
            {
                TestContext.WriteLine($"Observed test outcome during cleanup: {exception.GetType().Name}");
            }
        }
    }

    private sealed class BlockingStreams : AgentEventStreamRegistry, IAsyncDisposable
    {
        private readonly ConcurrentDictionary<string, AgentEventStream> _streams = new();
        public bool BlockA { get; set; }
        public TaskCompletionSource CloseEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseClose { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
            => new(_streams.GetOrAdd(id, key => new Backing(key, this)));
        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
            => new(_streams.TryGetValue(id, out AgentEventStream? stream) ? stream : throw new AgentEventStreamNotFoundException("No backing."));
        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Replay must not be deleted.");
        public async ValueTask DisposeAsync()
        {
            ReleaseClose.TrySetResult();
            foreach (AgentEventStream stream in _streams.Values)
            { await stream.CloseAsync(); }
        }
        private sealed class Backing(string id, BlockingStreams owner) : ReplayEventStream(id, TimeSpan.FromMinutes(10), () => { })
        {
            public override async ValueTask CloseAsync(CancellationToken cancellationToken = default)
            {
                if (Id == "a" && owner.BlockA)
                {
                    owner.CloseEntered.TrySetResult();
                    await owner.ReleaseClose.Task.WaitAsync(Timeout, cancellationToken);
                }
                await base.CloseAsync(cancellationToken);
            }
        }
    }

    private sealed class Store(ITaskStore inner) : ITaskStore
    {
        public bool BlockTrim { get; set; }
        public bool BlockSuspend { get; set; }
        public bool FailSuspend { get; set; }
        public TaskCompletionSource TrimEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseTrim { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource SuspendEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseSuspend { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default) => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default) => inner.GetAsync(taskId, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default) => inner.ListAsync(query, cancellationToken);
        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
        public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (BlockTrim && patch.Status is null
                && patch.Payload?[TaskWireKeys.PayloadSteering]?[TaskWireKeys.SteeringPendingInputs] is System.Text.Json.Nodes.JsonArray pending
                && pending.Count == 0)
            {
                TrimEntered.TrySetResult();
                await ReleaseTrim.Task.WaitAsync(Timeout, cancellationToken);
            }
            if (BlockSuspend && patch.Status == TaskWireKeys.StatusSuspended)
            {
                SuspendEntered.TrySetResult();
                await ReleaseSuspend.Task.WaitAsync(Timeout, cancellationToken);
                if (FailSuspend)
                { throw new IOException("Suspension failed."); }
            }
            return await inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
    }
}
