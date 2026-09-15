// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
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
public sealed class ExactInputCancellationTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    [TestCase(false)]
    [TestCase(true)]
    public async Task CompletedQueuedHandleIsInertEvenBeforeSuccessorIsPublished(bool beforeSetCurrent)
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate successor = host.Gate();
        Gate deserialize = host.Gate();
        TaskContext<string>? successorContext = null;
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                await first.WaitAsync();
            }
            else if (ctx.Input == "c")
            {
                successorContext = ctx;
                await successor.WaitAsync();
            }
            return ctx.Input;
        }, beforeSetCurrent ? value =>
        {
            if (value == "c")
            {
                // DeserializeInput runs after ResolveOutcome(b), before SetCurrent(c).
                deserialize.Wait();
            }
        }
        : null);

        TaskRun<string> a = await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        first.Release();
        if (beforeSetCurrent)
        {
            await deserialize.Entered.Task.WaitAsync(Timeout);
        }
        else
        {
            await successor.Entered.Task.WaitAsync(Timeout);
        }

        Assert.That(await b.Completion.WaitAsync(Timeout), Is.EqualTo("b"));
        Assert.That(b.IsQueued, Is.True, "IsQueued is historical, not cancellation authority");
        var retainedLookup = new Dictionary<string, TaskRun<string>> { [b.InputId] = b };
        await retainedLookup[b.InputId].RequestCancellationAsync().WaitAsync(Timeout);
        await retainedLookup[b.InputId].RequestCancellationAsync().WaitAsync(Timeout);
        deserialize.Release();
        await successor.Entered.Task.WaitAsync(Timeout);
        Assert.That(successorContext!.CancelRequested, Is.False);
        Assert.That(successorContext.Cancellation.IsCancellationRequested, Is.False);
        successor.Release();
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [Test]
    public async Task CapturedCancellationDoesNotChaseSuccessorOrDisposeItsSourceDuringCallback()
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate middle = host.Gate();
        Gate successor = host.Gate();
        Gate callback = host.Gate();
        TaskContext<string>? middleContext = null;
        TaskContext<string>? successorContext = null;
        CancellationTokenSource? capturedSource = null;
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                await first.WaitAsync();
            }
            else if (ctx.Input == "b")
            {
                middleContext = ctx;
                capturedSource = (CancellationTokenSource)typeof(CancellationToken)
                    .GetField("_source", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(ct)!;
                ct.Register(callback.Wait);
                await middle.WaitAsync();
            }
            else
            {
                successorContext = ctx;
                await successor.WaitAsync();
            }
            return ctx.Input;
        });

        await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        first.Release();
        await middle.Entered.Task.WaitAsync(Timeout);
        Task cancel = host.Observe(b.RequestCancellationAsync());
        await callback.Entered.Task.WaitAsync(Timeout);
        Assert.That(middleContext!.CancelRequested, Is.True, "cause must precede the signal");
        middle.Release();
        await successor.Entered.Task.WaitAsync(Timeout);
        Assert.That(await b.Completion.WaitAsync(Timeout), Is.EqualTo("b"));
        Assert.DoesNotThrow(() => _ = capturedSource!.Token,
            "a signal user must pin the retired source until its callbacks finish");
        callback.Release();
        await cancel.WaitAsync(Timeout);
        Assert.That(successorContext!.CancelRequested, Is.False);
        Assert.That(successorContext.Cancellation.IsCancellationRequested, Is.False,
            "an exact-input cancellation must not follow a replacement CTS like a steering nudge");
        Assert.Throws<ObjectDisposedException>(() => _ = capturedSource!.Token);
        successor.Release();
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task PromotedHandleCancellationBelongsOnlyToThatInput(bool inPromotionWindow)
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate promotion = host.Gate();
        Gate middle = host.Gate();
        Gate successor = host.Gate();
        TaskContext<string>? middleContext = null;
        TaskContext<string>? successorContext = null;
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                await first.WaitAsync();
            }
            else if (ctx.Input == "b")
            {
                middleContext = ctx;
                await middle.WaitAsync();
                ct.ThrowIfCancellationRequested();
            }
            else
            {
                successorContext = ctx;
                await successor.WaitAsync();
            }
            return ctx.Input;
        });
        if (inPromotionWindow)
        {
            host.Store.BeforePatch = patch => patch.Payload?["input"]?.GetValue<string>() == "b"
                ? promotion.WaitAsync() : Task.CompletedTask;
        }

        TaskRun<string> a = await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        first.Release();
        await (inPromotionWindow ? promotion : middle).Entered.Task.WaitAsync(Timeout);
        await b.RequestCancellationAsync().WaitAsync(Timeout);
        await b.RequestCancellationAsync().WaitAsync(Timeout);
        promotion.Release();
        await middle.Entered.Task.WaitAsync(Timeout);
        Assert.That(middleContext!.CancelRequested, Is.True);
        Assert.That(middleContext.Cancellation.IsCancellationRequested, Is.True);
        middle.Release();
        Assert.ThrowsAsync<OperationCanceledException>(async () => await b.Completion.WaitAsync(Timeout));
        await successor.Entered.Task.WaitAsync(Timeout);
        Assert.That(successorContext!.CancelRequested, Is.False);
        Assert.That(successorContext.Cancellation.IsCancellationRequested, Is.False);
        successor.Release();
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [Test]
    public async Task QueuedCancellationTwiceDuringRemovalDoesNotReenterOrCancelAnotherInput()
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate removal = host.Gate();
        TaskContext<string>? firstContext = null;
        int middleCalls = 0;
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                firstContext = ctx;
                await first.WaitAsync();
            }
            if (ctx.Input == "b")
            {
                Interlocked.Increment(ref middleCalls);
            }
            Assert.That(ctx.CancelRequested, Is.False);
            return ctx.Input;
        });
        TaskRun<string> a = await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        host.Store.BeforePatch = _ => removal.WaitAsync();
        Task cancel1 = host.Observe(b.RequestCancellationAsync());
        await removal.Entered.Task.WaitAsync(Timeout);
        Task cancel2 = host.Observe(b.RequestCancellationAsync());
        Assert.That(cancel2.IsCompleted, Is.False, "a second removal request must share the pending durable operation");
        removal.Release();
        await Task.WhenAll(cancel1, cancel2).WaitAsync(Timeout);
        Assert.ThrowsAsync<OperationCanceledException>(async () => await b.Completion.WaitAsync(Timeout));
        await b.RequestCancellationAsync().WaitAsync(Timeout);
        Assert.That(firstContext!.CancelRequested, Is.False);
        first.Release();
        Assert.That(await a.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
        Assert.That(middleCalls, Is.Zero);
    }

    [Test]
    public async Task SealedOutcomeRejectsCancellationBeforeCompletionPublication()
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate publication = host.Gate();
        TaskContext<string>? middleContext = null;
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                await first.WaitAsync();
            }
            else if (ctx.Input == "b")
            {
                middleContext = ctx;
            }
            return ctx.Input;
        });
        host.Store.BeforePatch = patch => patch.Payload?["input"]?.GetValue<string>() == "c"
            ? publication.WaitAsync() : Task.CompletedTask;
        await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        first.Release();
        await publication.Entered.Task.WaitAsync(Timeout);
        Assert.That(b.Completion.IsCompleted, Is.False);
        await b.RequestCancellationAsync().WaitAsync(Timeout);
        Assert.That(middleContext!.CancelRequested, Is.False);
        Assert.That(middleContext.Cancellation.IsCancellationRequested, Is.False,
            "outcome eligibility must be sealed even while durable promotion delays publication");
        publication.Release();
        Assert.That(await b.Completion.WaitAsync(Timeout), Is.EqualTo("b"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"));
    }

    [Test]
    public async Task PreDispatchCancellationIsReconciledWithItsOwnContext()
    {
        await using var host = new CancellationHost();
        Gate dispatch = host.Gate();
        host.Register((ctx, ct) =>
        {
            Assert.That(ctx.CancelRequested, Is.EqualTo(ctx.Input == "b"));
            if (ctx.Input == "b")
            {
                Assert.That(ct.IsCancellationRequested, Is.True);
                ct.ThrowIfCancellationRequested();
            }
            return Task.FromResult(ctx.Input);
        });
        TaskRun<string> a = await host.StartAsync("a");
        await a.Completion.WaitAsync(Timeout);
        host.Store.BeforePatch = patch => patch.Payload?["input"]?.GetValue<string>() == "b"
            ? dispatch.WaitAsync() : Task.CompletedTask;
        Task<TaskRun<string>> starting = host.StartAsync("b");
        await dispatch.Entered.Task.WaitAsync(Timeout);
        TaskRun<string>? b = await host.Engine.GetActiveRunAsync<string>("chat", "t", "b");
        Assert.That(b, Is.Not.Null);
        await b!.RequestCancellationAsync().WaitAsync(Timeout);
        dispatch.Release();
        await starting.WaitAsync(Timeout);
        Assert.ThrowsAsync<OperationCanceledException>(async () => await b.Completion.WaitAsync(Timeout));
    }

    [Test]
    public async Task ReentrantCancellationCallbackDoesNotAwaitItselfOrHoldUpPromotion()
    {
        await using var host = new CancellationHost();
        Gate first = host.Gate();
        Gate middle = host.Gate();
        Gate callback = host.Gate();
        TaskRun<string>? b = null;
        var reentered = new TaskCompletionSource<Task>(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Register(async (ctx, ct) =>
        {
            if (ctx.Input == "a")
            {
                await first.WaitAsync();
            }
            else if (ctx.Input == "b")
            {
                ct.Register(() =>
                {
                    Task nested = b!.RequestCancellationAsync();
                    reentered.TrySetResult(nested);
                    callback.Wait();
                });
                await middle.WaitAsync();
            }
            return ctx.Input;
        });
        await host.StartAsync("a");
        await first.Entered.Task.WaitAsync(Timeout);
        b = await host.StartAsync("b");
        TaskRun<string> c = await host.StartAsync("c");
        first.Release();
        await middle.Entered.Task.WaitAsync(Timeout);
        Task cancellation = host.Observe(b.RequestCancellationAsync());
        Task nested = await reentered.Task.WaitAsync(Timeout);
        await nested.WaitAsync(Timeout);
        middle.Release();
        Assert.That(await b.Completion.WaitAsync(Timeout), Is.EqualTo("b"));
        Assert.That(await c.Completion.WaitAsync(Timeout), Is.EqualTo("c"),
            "promotion cannot wait for callbacks that may themselves await completion");
        callback.Release();
        await cancellation.WaitAsync(Timeout);
    }

    private sealed class Gate : IDisposable
    {
        public TaskCompletionSource Entered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly TaskCompletionSource _release = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly ManualResetEventSlim _released = new(false);

        public async Task WaitAsync()
        {
            Entered.TrySetResult();
            await _release.Task.WaitAsync(Timeout);
        }

        // JsonConverter and CancellationToken callbacks are synchronous boundaries.
        public void Wait()
        {
            Entered.TrySetResult();
            Assert.That(_released.Wait(Timeout), Is.True, "synchronous gate timed out");
        }

        public void Release()
        {
            _release.TrySetResult();
            _released.Set();
        }

        public void Dispose() => _released.Dispose();
    }

    private sealed class GatedConverter(Action<string> onRead) : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString()!;
            onRead(value);
            return value;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            => writer.WriteStringValue(value);
    }

    private sealed class CancellationHost : IAsyncDisposable
    {
        private readonly string _root = Path.Combine(
            Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT") ?? Path.GetTempPath(),
            "exact-cancel-" + Guid.NewGuid().ToString("N"));
        private readonly List<Gate> _gates = new();
        private readonly List<Task<Exception?>> _observed = new();
        private readonly TaskRegistry _registry = new();
        private readonly InMemoryEventStreamRegistry _streams = new(new AgentEventStreamOptions());

        public CancellationHost()
        {
            Directory.CreateDirectory(_root);
            Store = new GatedStore(new LocalTaskStore(_root));
            Engine = new TaskEngine(Store, _registry, "agent", "session", _streams);
        }

        public GatedStore Store { get; }
        public TaskEngine Engine { get; }

        public Gate Gate()
        {
            var gate = new Gate();
            _gates.Add(gate);
            return gate;
        }

        public void Register(Func<TaskContext<string>, CancellationToken, Task<string>> handler, Action<string>? onRead = null)
        {
            var options = new JsonSerializerOptions { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };
            if (onRead is not null)
            {
                options.Converters.Add(new GatedConverter(onRead));
            }
            _registry.Add(new TaskRegistration("chat", typeof(string), typeof(string), handler,
                requiresServiceScope: false, multiTurn: true, () => true, options: null,
                inputTypeInfo: options.GetTypeInfo(typeof(string))));
        }

        public Task<TaskRun<string>> StartAsync(string input)
        {
            Task<TaskRun<string>> start = Engine.StartAsync<string, string>(
                "chat", input, new RunOptions { TaskId = "t", InputId = input });
            Task<TaskRun<string>> tracked = TrackRunAsync(start);
            _ = Observe(tracked);
            return tracked.WaitAsync(Timeout);
        }

        private async Task<TaskRun<string>> TrackRunAsync(Task<TaskRun<string>> start)
        {
            TaskRun<string> run = await start;
            _ = Observe(run.Completion);
            return run;
        }

        public Task Observe(Task task)
        {
            lock (_observed)
            {
                _observed.Add(ObserveFailureAsync(task));
            }
            return task;
        }

        private static async Task<Exception?> ObserveFailureAsync(Task task)
        {
            try
            {
                await task;
                return null;
            }
            catch (Exception exception)
            {
                // Cleanup observes expected cancellation and red-test failures, never discards tasks.
                return exception;
            }
        }

        public async ValueTask DisposeAsync()
        {
            foreach (Gate gate in _gates)
            {
                gate.Release();
            }
            Exception?[] failures;
            while (true)
            {
                Task<Exception?>[] observed;
                lock (_observed)
                {
                    observed = _observed.ToArray();
                }
                failures = await Task.WhenAll(observed).WaitAsync(Timeout);
                lock (_observed)
                {
                    if (_observed.Count == observed.Length)
                    {
                        break;
                    }
                }
            }
            Engine.Dispose();
            _streams.Dispose();
            foreach (Gate gate in _gates)
            {
                gate.Dispose();
            }
            Directory.Delete(_root, recursive: true);
            Assert.That(Array.Find(failures, failure => failure is not null and not OperationCanceledException),
                Is.Null, "unexpected background task failure");
        }
    }

    private sealed class GatedStore(ITaskStore inner) : ITaskStore
    {
        public Func<TaskPatchRequest, Task>? BeforePatch { get; set; }
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);
        public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (BeforePatch is { } before)
            {
                await before(patch);
            }
            return await inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
    }
}
