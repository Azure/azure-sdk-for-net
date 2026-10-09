// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public class TaskStreamInitializationRegressionTests
{
    [Test]
    public async Task FailedInitializationCanBeRetried()
    {
        var backing = NewBacking();
        var registry = new ControlledRegistry
        {
            Create = call => call == 1
                ? Task.FromException<AgentEventStream>(new IOException("temporary"))
                : Task.FromResult<AgentEventStream>(backing),
        };
        var state = new TaskStreamState(registry, "task", "input");
        Assert.ThrowsAsync<IOException>(async () => await state.GetStreamAsync(CancellationToken.None));
        Assert.That(await state.GetStreamAsync(CancellationToken.None), Is.SameAs(backing));
        Assert.That(registry.Creates, Is.EqualTo(2));
        await state.CloseAsync();
    }

    [Test]
    public async Task CancelledInitializationCanBeRetried()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var backing = NewBacking();
        var registry = new ControlledRegistry
        {
            Create = call => call == 1
                ? Task.FromCanceled<AgentEventStream>(cancellation.Token)
                : Task.FromResult<AgentEventStream>(backing),
        };
        var state = new TaskStreamState(registry, "task", "input");
        Assert.That(async () => await state.GetStreamAsync(CancellationToken.None), Throws.InstanceOf<OperationCanceledException>());
        Assert.That(await state.GetStreamAsync(CancellationToken.None), Is.SameAs(backing));
        Assert.That(registry.Creates, Is.EqualTo(2));
        await state.CloseAsync();
    }

    [Test]
    public async Task CancelledWaiterDoesNotDiscardSharedInitialization()
    {
        var gate = new TaskCompletionSource<AgentEventStream>(TaskCreationOptions.RunContinuationsAsynchronously);
        var registry = new ControlledRegistry { Create = _ => gate.Task };
        var state = new TaskStreamState(registry, "task", "input");
        using var cancellation = new CancellationTokenSource();
        Task<AgentEventStream> first = state.GetStreamAsync(cancellation.Token).AsTask();
        Task<AgentEventStream> second = state.GetStreamAsync(CancellationToken.None).AsTask();
        cancellation.Cancel();
        Assert.That(async () => await first, Throws.InstanceOf<OperationCanceledException>());
        var backing = NewBacking();
        gate.SetResult(backing);
        Assert.That(await second.WaitAsync(TimeSpan.FromSeconds(5)), Is.SameAs(backing));
        Assert.That(await state.GetStreamAsync(CancellationToken.None), Is.SameAs(backing));
        Assert.That(registry.Creates, Is.EqualTo(1));
        await state.CloseAsync();
    }

    [Test]
    public async Task CloseUsesExistingOnlyLookup()
    {
        var backing = NewBacking();
        await backing.EmitAsync(new SseItem<string>("prior") { EventId = "1" });
        var registry = new ControlledRegistry { Existing = backing };
        var state = new TaskStreamState(registry, "task", "input");
        await state.CloseAsync();
        Assert.That(registry.Lookups, Is.EqualTo(1));
        Assert.That(registry.Creates, Is.Zero);
        Assert.That((await ReadAll(backing)).Select(e => e.Data), Is.EqualTo(new[] { "prior" }));
    }

    [Test]
    public async Task CloseDoesNotMaterializeMissingBacking()
    {
        var registry = new ControlledRegistry();
        var state = new TaskStreamState(registry, "task", "input");
        await state.CloseAsync();
        Assert.That(registry.Lookups, Is.EqualTo(1));
        Assert.That(registry.Creates, Is.Zero);
    }

    [Test]
    public async Task FailedExistingLookupCanBeRetriedWithoutCreating()
    {
        var backing = NewBacking();
        var registry = new ControlledRegistry
        {
            Lookup = call => call == 1
                ? Task.FromException<AgentEventStream?>(new IOException("lookup failed"))
                : Task.FromResult<AgentEventStream?>(backing),
        };
        var state = new TaskStreamState(registry, "task", "input");
        Assert.ThrowsAsync<IOException>(async () => await state.CloseAsync());
        await state.CloseAsync();
        Assert.That(registry.Creates, Is.Zero);
        Assert.That(await ReadAll(backing), Is.Empty);
    }

    [Test]
    public async Task CloseRacingInitializationCannotLeaveBackingOpen()
    {
        var gate = new TaskCompletionSource<AgentEventStream>(TaskCreationOptions.RunContinuationsAsynchronously);
        var registry = new ControlledRegistry { Create = _ => gate.Task };
        var state = new TaskStreamState(registry, "task", "input");
        Task<AgentEventStream> creating = state.GetStreamAsync(CancellationToken.None).AsTask();
        Task closing = state.CloseAsync().AsTask();
        var backing = NewBacking();
        gate.SetResult(backing);
        await Task.WhenAll(creating, closing).WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(await ReadAll(backing), Is.Empty);
        Assert.That(registry.Creates, Is.EqualTo(1));
    }

    [Test]
    public async Task CloseBeforeFirstCreationStillClosesLaterExplicitSubscription()
    {
        var backing = NewBacking();
        var registry = new ControlledRegistry { Create = _ => Task.FromResult<AgentEventStream>(backing) };
        var state = new TaskStreamState(registry, "task", "input");
        await state.CloseAsync();
        Assert.That(registry.Creates, Is.Zero);
        AgentEventStream created = await state.GetStreamAsync(CancellationToken.None);
        Assert.That(await ReadAll(created), Is.Empty);
    }

    [Test]
    public async Task CloseRacingFailedCreationRetainsCloseIntentForRetry()
    {
        var gate = new TaskCompletionSource<AgentEventStream>(TaskCreationOptions.RunContinuationsAsynchronously);
        var backing = NewBacking();
        var registry = new ControlledRegistry
        {
            Create = call => call == 1 ? gate.Task : Task.FromResult<AgentEventStream>(backing),
        };
        var state = new TaskStreamState(registry, "task", "input");
        Task<AgentEventStream> creating = state.GetStreamAsync(CancellationToken.None).AsTask();
        Task closing = state.CloseAsync().AsTask();
        gate.SetException(new IOException("temporary"));
        Assert.ThrowsAsync<IOException>(async () => await creating);
        Assert.ThrowsAsync<IOException>(async () => await closing);
        AgentEventStream next = await state.GetStreamAsync(CancellationToken.None);
        Assert.That(await ReadAll(next), Is.Empty);
        Assert.That(registry.Creates, Is.EqualTo(2));
    }

    [Test]
    public async Task RecoveredCheckpointOnlyHandlerClosesPreviousFileStream()
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-init-recovery-" + Guid.NewGuid().ToString("N"));
        try
        {
            using TaskTestHost first = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(directory));
            first.Builder.AddTask<string, string>("recover", async (context, token) =>
            {
                await context.Stream.EmitAsync(new SseItem<string>("before") { EventId = "1" }, token);
                await context.ExitForRecoveryAsync(token);
                return "deferred";
            });
            first.SignalShutdown();
            TaskRun<string> original = await first.Engine.StartAsync<string, string>(
                "recover", "input", new RunOptions { TaskId = "recover", InputId = "turn" });
            await first.WaitUntilInactiveAsync("recover", TimeSpan.FromSeconds(5));
            Assert.That(original.Completion.IsCompleted, Is.False);
            ((IDisposable)await first.Streams.GetAsync("turn")).Dispose();
            using TaskTestHost second = first.Restart(new TaskRegistry());
            int calls = 0;
            second.Builder.AddTask<string, string>("recover", (context, token) =>
            {
                calls++;
                return Task.FromResult("checkpoint-already-complete");
            });
            Assert.That(await second.Engine.ScanAndRecoverAsync(), Is.EqualTo(1));
            await second.WaitUntilInactiveAsync("recover", TimeSpan.FromSeconds(5));
            AgentEventStream? recovered = await ((ITaskEventStreamRegistry)second.Streams).GetTaskStreamAsync("recover", "turn");
            Assert.That(recovered, Is.Not.Null);
            Assert.That((await ReadAll(recovered!)).Select(e => e.Data), Is.EqualTo(new[] { "before" }));
            Assert.That(calls, Is.EqualTo(1));
            await second.Streams.DeleteAsync("turn");
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    [Test]
    public async Task ExistingLookupRacingExplicitCreationStillClosesBacking()
    {
        var lookup = new TaskCompletionSource<AgentEventStream?>(TaskCreationOptions.RunContinuationsAsynchronously);
        var backing = NewBacking();
        var registry = new ControlledRegistry
        {
            Lookup = _ => lookup.Task,
            Create = _ => Task.FromResult<AgentEventStream>(backing),
        };
        var state = new TaskStreamState(registry, "task", "input");
        Task closing = state.CloseAsync().AsTask();
        try
        {
            AgentEventStream created = await state.GetStreamAsync(CancellationToken.None);
            Assert.That(await ReadAll(created), Is.Empty);
            Assert.That(registry.Creates, Is.EqualTo(1));
        }
        finally
        {
            lookup.TrySetResult(null);
            await closing;
        }
    }

    [Test]
    public async Task CloseFailureDoesNotDiscardSuccessfulInitialization()
    {
        var backing = new RetryCloseBacking();
        var registry = new ControlledRegistry { Create = _ => Task.FromResult<AgentEventStream>(backing) };
        var state = new TaskStreamState(registry, "task", "input");
        Assert.That(await state.GetStreamAsync(CancellationToken.None), Is.SameAs(backing));
        Assert.ThrowsAsync<IOException>(async () => await state.CloseAsync());
        Assert.That(await state.GetStreamAsync(CancellationToken.None), Is.SameAs(backing));
        Assert.That(registry.Creates, Is.EqualTo(1));
        Assert.That(backing.CloseAttempts, Is.EqualTo(2));
        Assert.That(await ReadAll(backing), Is.Empty);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CustomRegistryCloseUsesNonCreatingLookup(bool missing)
    {
        var backing = NewBacking();
        var registry = new CustomRegistry { Existing = missing ? null : backing };
        var state = new TaskStreamState(registry, "task", "input");
        await state.CloseAsync();
        Assert.That(registry.Lookups, Is.EqualTo(1));
        if (!missing)
        { Assert.That(await ReadAll(backing), Is.Empty); }
    }

    [Test]
    public async Task CustomRegistryLookupFailureIsNotTreatedAsAbsence()
    {
        var backing = NewBacking();
        var registry = new CustomRegistry { Existing = backing, Failure = new IOException("lookup failed") };
        var state = new TaskStreamState(registry, "task", "input");
        Assert.ThrowsAsync<IOException>(async () => await state.CloseAsync());
        registry.Failure = null;
        await state.CloseAsync();
        Assert.That(registry.Lookups, Is.EqualTo(2));
        Assert.That(await ReadAll(backing), Is.Empty);
    }

    [Test]
    public async Task EngineRetriesTransientFileWriterLockFailure()
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-init-retry-" + Guid.NewGuid().ToString("N"));
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(directory));
            using var held = new FileBackedReplayEventStream("turn", directory, TimeSpan.FromMinutes(5), () => { }, "task");
            int calls = 0;
            host.Builder.AddTask<string, string>("retry", async (context, token) =>
            {
                calls++;
                await context.Stream.EmitAsync(new SseItem<string>("result") { EventId = "1" }, token);
                return "done";
            }, options => options.Retry = new TaskRetryPolicy
            {
                MaxAttempts = 2,
                Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero),
                RetryOn = _ => { held.Dispose(); return true; },
            });
            TaskRun<string> run = await host.Engine.StartAsync<string, string>(
                "retry", "input", new RunOptions { TaskId = "task", InputId = "turn" });
            Assert.That(await run.Completion.WaitAsync(TimeSpan.FromSeconds(5)), Is.EqualTo("done"));
            Assert.That(calls, Is.EqualTo(2));
            AgentEventStream stream = await host.Streams.GetAsync("turn");
            Assert.That((await ReadAll(stream)).Single().Data, Is.EqualTo("result"));
            await host.Streams.DeleteAsync("turn");
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    private static ReplayEventStream NewBacking() => new("input", TimeSpan.FromMinutes(5), () => { });

    private static async Task<List<SseItem<string>>> ReadAll(AgentEventStream stream)
    {
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var events = new List<SseItem<string>>();
        await foreach (SseItem<string> item in stream.Subscribe(cancellationToken: timeout.Token))
        { events.Add(item); }
        return events;
    }

    private sealed class ControlledRegistry : AgentEventStreamRegistry, ITaskEventStreamRegistry
    {
        public int Creates { get; private set; }
        public int Lookups { get; private set; }
        public AgentEventStream? Existing { get; set; }
        public Func<int, Task<AgentEventStream>> Create { get; set; } = _ => Task.FromResult<AgentEventStream>(NewBacking());
        public Func<int, Task<AgentEventStream?>>? Lookup { get; set; }
        public ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(string taskId, string inputId, CancellationToken cancellationToken = default)
        {
            Assert.That(taskId, Is.EqualTo("task"));
            Assert.That(inputId, Is.EqualTo("input"));
            return new(Create(++Creates));
        }
        public ValueTask<AgentEventStream?> GetTaskStreamAsync(string taskId, string inputId, CancellationToken cancellationToken = default)
        {
            Assert.That(taskId, Is.EqualTo("task"));
            Assert.That(inputId, Is.EqualTo("input"));
            Lookups++;
            return Lookup is null ? new(Existing) : new(Lookup(Lookups));
        }
        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Must use task-aware creation.");
        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Must use task-aware lookup.");
        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
        public Task<int> CloseOrphanTaskStreamsAsync(Func<string, string, ValueTask<bool>> shouldClose, CancellationToken cancellationToken = default)
            => Task.FromResult(0);
    }

    private sealed class CustomRegistry : AgentEventStreamRegistry
    {
        public AgentEventStream? Existing { get; set; }
        public Exception? Failure { get; set; }
        public int Lookups { get; private set; }

        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            Lookups++;
            if (Failure is not null)
            { throw Failure; }
            return new(Existing ?? throw new AgentEventStreamNotFoundException("No stream."));
        }
        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Cleanup cannot create a stream.");
        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    private sealed class RetryCloseBacking() : ReplayEventStream("input", TimeSpan.FromMinutes(5), () => { })
    {
        public int CloseAttempts { get; private set; }
        protected override void PersistClose()
        {
            if (++CloseAttempts == 1)
            { throw new IOException("Close failed."); }
        }
    }
}
