// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
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
public class DeletionStreamCoordinationTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    [TestCase(false)]
    [TestCase(true)]
    public async Task ClosureRequiresBothConfirmedDeletionAndProducerUnwind(bool unwindFirst)
    {
        await using var host = new DeletionHost();
        TaskRun<string> active = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        Assert.That(host.Context!.CancelRequested, Is.True);
        Assert.That(queued.Completion.IsCompleted, Is.True);
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);

        if (unwindFirst)
        {
            host.ReleaseHandler.TrySetResult();
            await host.WaitUntilInactive();
            Assert.That(host.Streams["a"].CloseCount, Is.Zero);
            Assert.That(host.Streams["b"].CloseCount, Is.Zero);
            Assert.That(deleting.IsCompleted, Is.False);
            Assert.That(await host.Store.GetAsync("chain"), Is.Not.Null);
            host.Store.ReleaseDelete.TrySetResult();
            await deleting.WaitAsync(Timeout);
        }
        else
        {
            host.Store.ReleaseDelete.TrySetResult();
            await deleting.WaitAsync(Timeout);
            Assert.That(active.Completion.IsCompleted, Is.False);
            Assert.That(host.Streams["a"].CloseCount, Is.Zero);
            Assert.That(host.Streams["b"].CloseCount, Is.EqualTo(1));
            host.ReleaseHandler.TrySetResult();
        }

        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
        await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
        Assert.That(async () => await active.Completion, Throws.InstanceOf<OperationCanceledException>());
        Assert.That(async () => await queued.Completion, Throws.InstanceOf<OperationCanceledException>());
        Assert.That(host.Streams["a"].CloseCount, Is.EqualTo(1));
        Assert.That(host.Streams["b"].CloseCount, Is.EqualTo(1));
        Assert.That(await host.Store.GetAsync("chain"), Is.Null);
        Assert.That(host.Executed, Is.EquivalentTo(new[] { "a" }));
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public async Task FailedDeletionPreservesStreamsAndPublishedCancellationUntilRetry(bool unwindFirst, bool cancelStorage)
    {
        await using var host = new DeletionHost();
        Exception failure = cancelStorage ? new OperationCanceledException("delete cancelled") : new IOException("delete failed");
        host.Store.DeleteFailure = failure;
        TaskRun<string> active = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        if (unwindFirst)
        {
            host.ReleaseHandler.TrySetResult();
            await host.WaitUntilInactive();
        }

        host.Store.ReleaseDelete.TrySetResult();
        Exception? actual = Assert.ThrowsAsync(Is.InstanceOf<Exception>(),
            async () => await deleting.WaitAsync(Timeout), "The storage error must propagate.");
        Assert.That(actual, Is.SameAs(failure));
        if (!unwindFirst)
        {
            host.ReleaseHandler.TrySetResult();
            await host.WaitUntilInactive();
        }
        Assert.That(async () => await active.Completion, Throws.InstanceOf<OperationCanceledException>());
        Assert.That(async () => await queued.Completion, Throws.InstanceOf<OperationCanceledException>());
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);
        TaskRecord record = (await host.Store.GetAsync("chain"))!;
        Assert.That(record.Status, Is.EqualTo(TaskWireKeys.StatusInProgress));
        Assert.That(record.Payload[TaskWireKeys.PayloadSteering]![TaskWireKeys.SteeringPendingInputIds]![0]!.GetValue<string>(),
            Is.EqualTo("b"));

        host.Store.DeleteFailure = null;
        await host.Delete().WaitAsync(Timeout);
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
        await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
        Assert.That(host.Executed, Is.EquivalentTo(new[] { "a" }));
    }

    [Test]
    public async Task NotFoundConfirmsDeletionButStillWaitsForProducerUnwind()
    {
        await using var host = new DeletionHost();
        host.Store.ReturnNotFound = true;
        TaskRun<string> active = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        await deleting.WaitAsync(Timeout);
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(active.Completion.IsCompleted, Is.False);
        host.ReleaseHandler.TrySetResult();
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
    }

    [Test]
    public async Task DetachedProducerDoesNotAllowRecoveryWhileStorageDeletionIsPending()
    {
        await using var host = new DeletionHost();
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();
        Task<TaskRun<string>> successor = host.Start("b");
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await successor.WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.That(host.Executed, Is.EquivalentTo(new[] { "a" }));
        host.Store.ReleaseDelete.TrySetResult();
        await deleting.WaitAsync(Timeout);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task DeletionDuringPromotionNeverExecutesThePromotedInput(bool failDelete)
    {
        await using var host = new DeletionHost();
        host.Store.PausePromotion = true;
        if (failDelete)
        {
            host.Store.DeleteFailure = new IOException("delete failed");
        }
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> promoted = await host.Start("b");
        _ = await promoted.Stream.GetLastEventIdAsync();
        host.ReleaseHandler.TrySetResult();
        await host.Store.PromotionEntered.Task.WaitAsync(Timeout);
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        if (failDelete)
        {
            Assert.ThrowsAsync<IOException>(async () => await deleting.WaitAsync(Timeout));
        }
        else
        {
            await deleting.WaitAsync(Timeout);
        }
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);
        host.Store.ReleasePromotion.TrySetResult();
        await host.WaitUntilInactive();
        Assert.That(host.Executed, Is.EquivalentTo(new[] { "a" }));
        Assert.That(async () => await promoted.Completion, Throws.InstanceOf<OperationCanceledException>());
        if (failDelete)
        {
            Assert.That(host.Streams["b"].CloseCount, Is.Zero);
        }
        else
        {
            await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
        }
    }

    [Test]
    public async Task LateClosureOfDeletedRunDoesNotCloseOrDetachNewRun()
    {
        await using var host = new DeletionHost();
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        host.Streams["a"].PauseClose = true;
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        await deleting.WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        await host.Streams["a"].CloseEntered.Task.WaitAsync(Timeout);
        Assert.That(host.Engine.IsActive("chain"), Is.False);

        var releaseSuccessor = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        host.HandlerReleases["c"] = releaseSuccessor;
        TaskRun<string> successor = await host.Start("c").WaitAsync(Timeout);
        await host.WaitForStarted("c");
        host.Streams["a"].ReleaseClose.TrySetResult();
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
        Assert.That(host.Streams["c"].CloseCount, Is.Zero);
        Assert.That(host.Engine.IsActive("chain"), Is.True);
        Assert.That(successor.Completion.IsCompleted, Is.False);
        releaseSuccessor.TrySetResult();
        Assert.That(await successor.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [Test]
    public async Task PendingQueuedCancellationRemainsPartOfChainDeletion()
    {
        await using var host = new DeletionHost();
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        host.Store.PauseQueueRemoval = true;
        Task cancelling = queued.RequestCancellationAsync();
        host.Operations.Add(cancelling);
        await host.Store.QueueRemovalEntered.Task.WaitAsync(Timeout);
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        Assert.That(queued.Completion.IsCompleted, Is.True,
            "Removing a queue slot must not hide its unresolved handle from chain deletion.");
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);
        host.Store.ReleaseDelete.TrySetResult();
        await deleting.WaitAsync(Timeout);
        await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
        host.Store.ReleaseQueueRemoval.TrySetResult();
        Assert.That(async () => await cancelling.WaitAsync(Timeout), Throws.InstanceOf<TaskStoreException>());
        host.ReleaseHandler.TrySetResult();
    }

    [Test]
    public async Task CancelledStorageTokenDoesNotAuthorizeClosure()
    {
        await using var host = new DeletionHost();
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        using var cancellation = new CancellationTokenSource();
        Task deleting = host.Delete(cancellation.Token);
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        cancellation.Cancel();
        Assert.That(async () => await deleting.WaitAsync(Timeout), Throws.InstanceOf<OperationCanceledException>());
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);
        Assert.That(await host.Store.GetAsync("chain"), Is.Not.Null);
        Assert.That(async () => await queued.Completion, Throws.InstanceOf<OperationCanceledException>());
    }

    [Test]
    public async Task DeleteDoesNotWaitForCancellationCallbackOrProducer()
    {
        await using var host = new DeletionHost();
        using var callbackRelease = new ManualResetEventSlim();
        var callbackEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        using CancellationTokenRegistration registration = host.Context!.Cancellation.Register(() =>
        {
            callbackEntered.TrySetResult();
            Assert.That(callbackRelease.Wait(Timeout), Is.True);
        });
        try
        {
            Task deleting = host.Delete();
            await callbackEntered.Task.WaitAsync(Timeout);
            await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
            host.Store.ReleaseDelete.TrySetResult();
            await deleting.WaitAsync(Timeout);
            Assert.That(host.Streams["a"].CloseCount, Is.Zero);
            Assert.That(host.Engine.IsActive("chain"), Is.True);
        }
        finally
        {
            callbackRelease.Set();
        }
    }

    [Test]
    public async Task DeletionDoesNotMaterializeUnusedStreams()
    {
        await using var host = new DeletionHost(emitEvents: false);
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        _ = await host.Start("b");
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        await deleting.WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();
        Assert.That(host.Streams.Count, Is.Zero);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task RetryAfterLostDeleteAcknowledgementClosesCapturedStreamsOnNotFound(bool cancelled)
    {
        await using var host = new DeletionHost();
        host.Store.DeleteFailure = cancelled
            ? new OperationCanceledException("delete acknowledgement lost")
            : new IOException("delete acknowledgement lost");
        host.Store.FailAfterDelete = true;
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        Assert.ThrowsAsync(Is.SameAs(host.Store.DeleteFailure), async () => await deleting.WaitAsync(Timeout));
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();
        Assert.That(await host.Store.GetAsync("chain"), Is.Null);
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(host.Streams["b"].CloseCount, Is.Zero);

        host.Store.DeleteFailure = null;
        await host.Delete().WaitAsync(Timeout);
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
        await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
    }

    [Test]
    public async Task RetriedDeletionClosesOldInputsWithoutWaitingForUnrelatedNewInput()
    {
        await using var host = new DeletionHost();
        host.Store.DeleteFailure = new IOException("delete acknowledgement lost");
        host.Store.FailAfterDelete = true;
        _ = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        TaskRun<string> queued = await host.Start("b");
        _ = await queued.Stream.GetLastEventIdAsync();
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        Assert.ThrowsAsync<IOException>(async () => await deleting.WaitAsync(Timeout));
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();

        host.Store.DeleteFailure = null;
        var releaseNew = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        host.HandlerReleases["c"] = releaseNew;
        TaskRun<string> newer = await host.Start("c").WaitAsync(Timeout);
        await host.WaitForStarted("c");
        await host.Delete().WaitAsync(Timeout);
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
        await host.Streams["b"].Closed.Task.WaitAsync(Timeout);
        Assert.That(newer.Completion.IsCompleted, Is.False);
        Assert.That(host.Streams["c"].CloseCount, Is.Zero);
        releaseNew.TrySetResult();
        await host.Streams["c"].Closed.Task.WaitAsync(Timeout);
    }

    [Test]
    public async Task RetriedDeletionWaitsForNewProducerReusingTheSameInput()
    {
        await using var host = new DeletionHost(emitEvents: false);
        host.Store.DeleteFailure = new IOException("delete acknowledgement lost");
        host.Store.FailAfterDelete = true;
        TaskRun<string> original = await host.Start("a");
        await host.Started.Task.WaitAsync(Timeout);
        _ = await original.Stream.GetLastEventIdAsync();
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        Assert.ThrowsAsync<IOException>(async () => await deleting.WaitAsync(Timeout));
        host.ReleaseHandler.TrySetResult();
        await host.WaitUntilInactive();

        host.Store.DeleteFailure = null;
        var newProducer = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseNew = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        host.HandlerReleases["a"] = releaseNew;
        host.OnExecute = _ => newProducer.TrySetResult();
        TaskRun<string> newer = await host.Start("a").WaitAsync(Timeout);
        await newProducer.Task.WaitAsync(Timeout);
        await host.Delete().WaitAsync(Timeout);
        Assert.That(host.Streams["a"].CloseCount, Is.Zero);
        Assert.That(newer.Completion.IsCompleted, Is.False);
        releaseNew.TrySetResult();
        await host.Streams["a"].Closed.Task.WaitAsync(Timeout);
    }

    [Test]
    public async Task RetryRetainsPersistedInputIdsWhenThereWasNoInMemoryRun()
    {
        await using var host = new DeletionHost();
        await host.Store.CreateAsync(new TaskCreateRequest
        {
            Id = "chain",
            AgentName = "agent",
            SessionId = "session",
            Title = "pending task",
            Status = TaskWireKeys.StatusPending,
            Source = new JsonObject { ["type"] = TaskWireKeys.SourceTypeValue, ["name"] = "chat" },
            Payload = new JsonObject
            {
                [TaskWireKeys.PayloadLastInputId] = "persisted-a",
                [TaskWireKeys.PayloadSteering] = new JsonObject
                {
                    [TaskWireKeys.SteeringPendingInputs] = new JsonArray("next"),
                    [TaskWireKeys.SteeringPendingInputIds] = new JsonArray("persisted-b"),
                },
            },
        });
        _ = await host.Streams.GetOrCreateAsync("persisted-a");
        _ = await host.Streams.GetOrCreateAsync("persisted-b");
        host.Store.DeleteFailure = new IOException("delete acknowledgement lost");
        host.Store.FailAfterDelete = true;
        Task deleting = host.Delete();
        await host.Store.DeleteEntered.Task.WaitAsync(Timeout);
        host.Store.ReleaseDelete.TrySetResult();
        Assert.ThrowsAsync<IOException>(async () => await deleting.WaitAsync(Timeout));
        Assert.That(await host.Store.GetAsync("chain"), Is.Null);
        Assert.That(host.Streams["persisted-a"].CloseCount, Is.Zero);
        Assert.That(host.Streams["persisted-b"].CloseCount, Is.Zero);

        host.Store.DeleteFailure = null;
        await host.Delete().WaitAsync(Timeout);
        await host.Streams["persisted-a"].Closed.Task.WaitAsync(Timeout);
        await host.Streams["persisted-b"].Closed.Task.WaitAsync(Timeout);
        Assert.That(host.Executed, Is.Empty);
    }

    private sealed class DeletionHost : IAsyncDisposable
    {
        private readonly string _root = Path.Combine(
            Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT") ?? Path.GetTempPath(),
            "delete-coordinate-" + Guid.NewGuid().ToString("N"));
        private readonly List<Task<TaskRun<string>>> _starts = new();
        private readonly List<Task> _deletes = new();

        public DeletionHost(bool emitEvents = true)
        {
            Directory.CreateDirectory(_root);
            Store = new GatedStore(new LocalTaskStore(_root));
            var registry = new TaskRegistry();
            var options = new JsonSerializerOptions { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };
            registry.Add(new TaskRegistration("chat", typeof(string), typeof(string),
                (Func<TaskContext<string>, CancellationToken, Task<string>>)(async (context, token) =>
                {
                    Context = context;
                    Executed.Enqueue(context.Input);
                    OnExecute?.Invoke(context);
                    if (emitEvents)
                    {
                        await context.Stream.EmitAsync(new SseItem<string>("started") { EventId = "1" });
                    }
                    Started.TrySetResult();
                    _startedInputs.GetOrAdd(context.Input, _ => NewSignal()).TrySetResult();
                    TaskCompletionSource release = HandlerReleases.TryGetValue(context.Input, out TaskCompletionSource? perInput)
                        ? perInput : ReleaseHandler;
                    await release.Task.WaitAsync(Timeout);
                    if (emitEvents)
                    {
                        await context.Stream.EmitAsync(new SseItem<string>("terminal") { EventId = "2" });
                    }
                    return context.Input;
                }),
                requiresServiceScope: false, multiTurn: true, () => true, options: null,
                inputTypeInfo: options.GetTypeInfo(typeof(string))));
            Engine = new TaskEngine(Store, registry, "agent", "session", Streams);
        }

        public GatedStore Store { get; }
        public RecordingRegistry Streams { get; } = new();
        public TaskEngine Engine { get; }
        public TaskContext<string>? Context { get; private set; }
        public Action<TaskContext<string>>? OnExecute { get; set; }
        public ConcurrentQueue<string> Executed { get; } = new();
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseHandler { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public ConcurrentDictionary<string, TaskCompletionSource> HandlerReleases { get; } = new();
        private readonly ConcurrentDictionary<string, TaskCompletionSource> _startedInputs = new();
        public List<Task> Operations { get; } = new();
        private static TaskCompletionSource NewSignal() => new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task WaitForStarted(string input) => _startedInputs.GetOrAdd(input, _ => NewSignal()).Task.WaitAsync(Timeout);

        public Task<TaskRun<string>> Start(string input)
        {
            Task<TaskRun<string>> task = Engine.StartAsync<string, string>(
                "chat", input, new RunOptions { TaskId = "chain", InputId = input });
            _starts.Add(task);
            return task;
        }

        public Task Delete(CancellationToken cancellationToken = default)
        {
            Task task = Engine.DeleteAsync("chat", "chain", cancellationToken);
            _deletes.Add(task);
            return task;
        }

        public async Task WaitUntilInactive()
        {
            using var cancellation = new CancellationTokenSource(Timeout);
            while (Engine.IsActive("chain"))
            {
                await Task.Delay(10, cancellation.Token);
            }
        }

        public async ValueTask DisposeAsync()
        {
            ReleaseHandler.TrySetResult();
            Store.ReleaseDelete.TrySetResult();
            Store.ReleasePromotion.TrySetResult();
            Store.ReleaseQueueRemoval.TrySetResult();
            foreach (TaskCompletionSource release in HandlerReleases.Values)
            {
                release.TrySetResult();
            }
            Streams.ReleaseClosures();
            foreach (Task deleting in _deletes)
            {
                await Observe(deleting);
            }
            foreach (Task<TaskRun<string>> start in _starts)
            {
                try
                {
                    TaskRun<string> run = await start.WaitAsync(Timeout);
                    await Observe(run.Completion);
                }
                catch (ResilientTaskException exception)
                {
                    TestContext.WriteLine($"Observed start rejection during cleanup: {exception.ErrorCode}");
                }
            }
            foreach (Task operation in Operations)
            {
                await Observe(operation);
            }
            await WaitUntilInactive();
            Engine.Dispose();
            await Streams.DisposeAsync();
            Directory.Delete(_root, recursive: true);
        }

        private static async Task Observe(Task task)
        {
            try
            {
                await task.WaitAsync(Timeout);
            }
            catch (Exception exception) when (exception is OperationCanceledException or IOException or TaskStoreException)
            {
                TestContext.WriteLine($"Observed failed operation during cleanup: {exception.GetType().Name}");
            }
        }
    }

    private sealed class RecordingRegistry : AgentEventStreamRegistry, IAsyncDisposable
    {
        private readonly ConcurrentDictionary<string, ObservedStream> _streams = new();
        public int Count => _streams.Count;
        public ObservedStream this[string inputId] => _streams[inputId];
        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
            => new(_streams.GetOrAdd(id, value => new ObservedStream(value)));
        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
            => new(_streams.TryGetValue(id, out ObservedStream? stream)
                ? stream : throw new AgentEventStreamNotFoundException("Missing stream."));
        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Task deletion must not delete replay history.");
        public void ReleaseClosures()
        {
            foreach (ObservedStream stream in _streams.Values)
            {
                stream.ReleaseClose.TrySetResult();
            }
        }
        public async ValueTask DisposeAsync()
        {
            foreach (ObservedStream stream in _streams.Values)
            {
                await stream.CloseAsync();
            }
        }
    }

    private sealed class ObservedStream(string id) : ReplayEventStream(id, TimeSpan.FromMinutes(10), () => { })
    {
        private int _closeCount;
        public int CloseCount => Volatile.Read(ref _closeCount);
        public TaskCompletionSource Closed { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public bool PauseClose { get; set; }
        public TaskCompletionSource CloseEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseClose { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public override async ValueTask CloseAsync(CancellationToken cancellationToken = default)
        {
            if (PauseClose)
            {
                CloseEntered.TrySetResult();
                await ReleaseClose.Task.WaitAsync(Timeout, cancellationToken);
            }
            await base.CloseAsync(cancellationToken);
        }
        protected override void PersistClose()
        {
            Interlocked.Increment(ref _closeCount);
            Closed.TrySetResult();
        }
    }

    private sealed class GatedStore(ITaskStore inner) : ITaskStore
    {
        public TaskCompletionSource DeleteEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseDelete { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Exception? DeleteFailure { get; set; }
        public bool FailAfterDelete { get; set; }
        public bool ReturnNotFound { get; set; }
        public bool PausePromotion { get; set; }
        public TaskCompletionSource PromotionEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleasePromotion { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public bool PauseQueueRemoval { get; set; }
        public TaskCompletionSource QueueRemovalEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseQueueRemoval { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);
        public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (PausePromotion && patch.Status == TaskWireKeys.StatusInProgress
                && patch.Payload?[TaskWireKeys.PayloadActiveInputId]?.GetValue<string>() == "b")
            {
                PromotionEntered.TrySetResult();
                await ReleasePromotion.Task.WaitAsync(Timeout, cancellationToken);
            }
            if (PauseQueueRemoval && patch.Status is null
                && patch.Payload?[TaskWireKeys.PayloadSteering]?[TaskWireKeys.SteeringPendingInputs] is System.Text.Json.Nodes.JsonArray pending
                && pending.Count == 0)
            {
                QueueRemovalEntered.TrySetResult();
                await ReleaseQueueRemoval.Task.WaitAsync(Timeout, cancellationToken);
            }
            return await inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
        public async Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
        {
            DeleteEntered.TrySetResult();
            await ReleaseDelete.Task.WaitAsync(Timeout, cancellationToken);
            if (!FailAfterDelete && DeleteFailure is { } failure)
            {
                throw failure;
            }
            await inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
            if (FailAfterDelete && DeleteFailure is { } acknowledgementFailure)
            {
                throw acknowledgementFailure;
            }
            if (ReturnNotFound)
            {
                throw new TaskStoreException(TaskStoreException.CodeTaskNotFound, 404, "Task already absent.", taskId);
            }
        }
    }
}
