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
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// In-process regression tests for the durable deletion-close journal and the periodic recovery
/// sweep, covering review findings on live-deletion protection, operation-scoped removal, the
/// captured input set, and retaining the journal when a close fails.
/// </summary>
[TestFixture]
public class TaskStreamDeletionReconciliationTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(15);

    // [P1] The periodic sweep must not close a stream whose producer is still unwinding in-process:
    // a deletion this process is still handling owns its own confirmed-delete/producer-unwind close.
    [Test]
    public async Task PeriodicSweepDoesNotCloseStreamOfRunningDeletion()
    {
        using TaskTestHost host = CreateFileBackedHost(out string root);
        try
        {
            var started = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var emitAfterSweep = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            async Task<string> Handler(TaskContext<string> context, CancellationToken token)
            {
                await context.Stream.EmitAsync(new SseItem<string>("first") { EventId = "1" }, CancellationToken.None);
                started.TrySetResult();
                try
                { await release.Task; }
                catch (Exception) { /* ignore */ }

                // The producer is unwinding after deletion cancelled it. If the sweep wrongly closed
                // the stream, this emit throws; if the deletion's own coordination kept it open, it
                // succeeds. CancellationToken.None isolates the assertion from turn cancellation.
                try
                {
                    await context.Stream.EmitAsync(new SseItem<string>("second") { EventId = "2" }, CancellationToken.None);
                    emitAfterSweep.TrySetResult("ok");
                }
                catch (Exception exception)
                {
                    emitAfterSweep.TrySetResult(exception.GetType().Name);
                }

                throw new OperationCanceledException(token.IsCancellationRequested ? token : CancellationToken.None);
            }

            host.Builder.AddMultiTurnTask<string, string>("del", Handler, steerable: true);
            _ = await host.Engine.StartAsync<string, string>("del", "a",
                new RunOptions { TaskId = "del-task", InputId = "a" });
            await started.Task.WaitAsync(Timeout);

            // Delete: cancels the producer (still gated), commits the provider delete, and defers the
            // stream close until the producer unwinds. The journal is written and registered live.
            await host.Engine.DeleteAsync("del", "del-task").WaitAsync(Timeout);

            var registry = (ITaskEventStreamRegistry)host.Streams;
            Assert.That(registry.ListPendingDeletions().Count, Is.EqualTo(1),
                "The deletion journal should record the still-owed close.");

            // The periodic sweep runs in-process. It must skip this live deletion.
            Assert.That(await host.Engine.ScanAndRecoverAsync(), Is.Zero);
            Assert.That(registry.ListPendingDeletions().Count, Is.EqualTo(1),
                "The sweep must not discard a live in-process deletion's journal entry.");

            release.TrySetResult();
            Assert.That(await emitAfterSweep.Task.WaitAsync(Timeout), Is.EqualTo("ok"),
                "The sweep must not close a stream whose producer is still running.");
        }
        finally
        {
            Cleanup(root);
        }
    }

    // [P5] The journal must name the inputs the deletion actually captured (active + queued), not a
    // pre-freeze record snapshot.
    [Test]
    public async Task JournalCapturesActiveAndQueuedInputs()
    {
        using TaskTestHost host = CreateFileBackedHost(out string root);
        try
        {
            var started = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

            async Task<string> Handler(TaskContext<string> context, CancellationToken token)
            {
                await context.Stream.EmitAsync(new SseItem<string>("first") { EventId = "1" }, CancellationToken.None);
                if (context.Input == "a")
                {
                    started.TrySetResult();
                    try
                    { await release.Task; }
                    catch (Exception) { }
                }
                return context.Input;
            }

            host.Builder.AddMultiTurnTask<string, string>("del", Handler, steerable: true);
            _ = await host.Engine.StartAsync<string, string>("del", "a",
                new RunOptions { TaskId = "del-task", InputId = "a" });
            await started.Task.WaitAsync(Timeout);

            TaskRun<string> b = await host.Engine.StartAsync<string, string>("del", "b",
                new RunOptions { TaskId = "del-task", InputId = "b" });
            _ = await b.Stream.GetLastEventIdAsync();

            await host.Engine.DeleteAsync("del", "del-task").WaitAsync(Timeout);

            var registry = (ITaskEventStreamRegistry)host.Streams;
            PendingStreamDeletion entry = registry.ListPendingDeletions().Single();
            Assert.That(entry.InputIds, Does.Contain("a"));
            Assert.That(entry.InputIds, Does.Contain("b"),
                "A queued input captured for deletion must be journaled, not just the executing input.");

            release.TrySetResult();
        }
        finally
        {
            Cleanup(root);
        }
    }

    // [P4] Journal removal is scoped to the delete operation: a second entry reusing the same task
    // id is distinct, and removing one operation's entry must not remove another's.
    [Test]
    public async Task JournalRemovalIsScopedToTheDeleteOperation()
    {
        using TaskTestHost host = CreateFileBackedHost(out string root);
        try
        {
            var registry = (ITaskEventStreamRegistry)host.Streams;

            // Materialize a backing so the storage directory exists (the journal never fabricates it).
            AgentEventStream stream = await registry.GetOrCreateTaskStreamAsync("reuse-task", "a");
            await stream.EmitAsync(new SseItem<string>("first") { EventId = "1" });

            registry.RecordPendingDeletion("reuse-task", "op-1", new[] { "a" });
            registry.RecordPendingDeletion("reuse-task", "op-2", new[] { "c" });
            Assert.That(registry.ListPendingDeletions().Count, Is.EqualTo(2),
                "Two deletions of the same task id must have distinct journal entries.");

            registry.RemovePendingDeletion("reuse-task", "op-1");

            PendingStreamDeletion remaining = registry.ListPendingDeletions().Single();
            Assert.That(remaining.OperationId, Is.EqualTo("op-2"));
            Assert.That(remaining.InputIds, Does.Contain("c"),
                "Removing one operation's entry must not remove another operation's outstanding intent.");
        }
        finally
        {
            Cleanup(root);
        }
    }

    // [P2] A crash-orphaned journal entry whose stream close fails must be retained for a later scan;
    // it is the only durable reference to the still-open stream once the record is gone. A second
    // host (a restart) over the same storage cannot acquire the writer lock held by the first, so its
    // reconciler close fails.
    [Test]
    public async Task ReconcilerRetainsJournalWhenCloseFails()
    {
        using TaskTestHost host = CreateFileBackedHost(out string root);
        AgentEventStream? held = null;
        try
        {
            var firstRegistry = (ITaskEventStreamRegistry)host.Streams;

            // The first host materializes and keeps the backing open, holding its writer lock.
            held = await firstRegistry.GetOrCreateTaskStreamAsync("orphan-task", "x");
            await held.EmitAsync(new SseItem<string>("first") { EventId = "1" });

            // A crash-orphaned entry (no live in-process operation, no task record in the store).
            firstRegistry.RecordPendingDeletion("orphan-task", "op-1", new[] { "x" });

            using TaskTestHost restart = host.Restart(new TaskRegistry());
            var secondRegistry = (ITaskEventStreamRegistry)restart.Streams;

            Assert.That(await restart.Engine.ScanAndRecoverAsync(), Is.Zero);
            Assert.That(secondRegistry.ListPendingDeletions().Count, Is.EqualTo(1),
                "A failed close (writer lock held by the first host) must retain the journal entry.");

            // Release the lock; the restart host can now close and remove the entry.
            await host.Streams.DeleteAsync("x");
            held = null;
            Assert.That(await restart.Engine.ScanAndRecoverAsync(), Is.Zero);
            Assert.That(secondRegistry.ListPendingDeletions().Count, Is.Zero,
                "Once the stream can be closed, the journal entry is removed.");
        }
        finally
        {
            Cleanup(root);
        }
    }

    private static TaskTestHost CreateFileBackedHost(out string root)
    {
        root = Path.Combine(Path.GetTempPath(), "agentserver-del-recon-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        string streams = Path.Combine(root, "streams");
        return TaskTestHost.Create(
            sharedDir: Path.Combine(root, "tasks"),
            configureStreams: options => options.UseFileBackedReplay(streams, TimeSpan.FromMinutes(10)));
    }

    private static void Cleanup(string root)
    {
        try
        { if (Directory.Exists(root)) { Directory.Delete(root, recursive: true); } }
        catch (IOException) { }
    }
}
