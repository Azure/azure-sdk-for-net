// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Tests for the cold-start orphan-stream sweep: it closes persisted task streams whose owning turn
/// has ended, while leaving live/queued streams open, and never enumerates task records.
/// </summary>
[TestFixture]
public class TaskOrphanStreamSweepTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(15);
    private const string Agent = "agent-a";
    private const string Session = "session-a";

    [Test]
    public async Task SweepClosesSelectedStreamsAndLeavesOthersOpen()
    {
        string root = Path.Combine(Path.GetTempPath(), "agentserver-orphan-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                sharedDir: Path.Combine(root, "tasks"),
                configureStreams: o => o.UseFileBackedReplay(Path.Combine(root, "streams"), TimeSpan.FromMinutes(10)));
            var registry = (ITaskEventStreamRegistry)host.Streams;

            // "retired" is an orphan (its turn ended); "live" represents an input still in play.
            AgentEventStream retired = await registry.GetOrCreateTaskStreamAsync("t", "retired");
            await retired.EmitAsync(new SseItem<string>("first") { EventId = "1" });
            AgentEventStream live = await registry.GetOrCreateTaskStreamAsync("t", "live");
            await live.EmitAsync(new SseItem<string>("live-1") { EventId = "1" });

            // Close only the retired input; keep the live one open.
            await registry.CloseOrphanTaskStreamsAsync(
                (taskId, inputId) => new ValueTask<bool>(inputId == "retired"));

            List<string> retiredEvents = await ReadToEndAsync(retired);
            Assert.That(retiredEvents, Is.EqualTo(new[] { "first" }),
                "The swept stream must reach EOF replaying its history.");

            // The live stream is still open: emitting after the sweep succeeds.
            await live.EmitAsync(new SseItem<string>("live-2") { EventId = "2" });
            Assert.That(await live.GetLastEventIdAsync(), Is.EqualTo("2"),
                "A stream the sweep skipped must remain open.");
        }
        finally
        {
            if (Directory.Exists(root))
            { Directory.Delete(root, recursive: true); }
        }
    }

    [Test]
    public void SweepIsNoOpForNonPersistentBacking()
    {
        using TaskTestHost host = TaskTestHost.Create(configureStreams: o => o.UseInMemoryReplay(TimeSpan.FromMinutes(1)));
        var registry = (ITaskEventStreamRegistry)host.Streams;
        Assert.DoesNotThrowAsync(() => registry.CloseOrphanTaskStreamsAsync(
            (_, _) => new ValueTask<bool>(true)));
    }

    [Test]
    public async Task SweepReportsTransientFailuresSoTheCallerCanRetry()
    {
        string root = Path.Combine(Path.GetTempPath(), "agentserver-orphan-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                sharedDir: Path.Combine(root, "tasks"),
                configureStreams: o => o.UseFileBackedReplay(Path.Combine(root, "streams"), TimeSpan.FromMinutes(10)));
            var registry = (ITaskEventStreamRegistry)host.Streams;

            AgentEventStream orphan = await registry.GetOrCreateTaskStreamAsync("t", "orphan");
            await orphan.EmitAsync(new SseItem<string>("first") { EventId = "1" });

            // A transient decision failure for an eligible orphan must be counted (not silently
            // dropped) so the cold-start caller retries it rather than leaving the stream open forever.
            int failures = await registry.CloseOrphanTaskStreamsAsync(
                (_, _) => throw new IOException("transient"));
            Assert.That(failures, Is.EqualTo(1), "A skipped orphan must be reported for retry.");

            // The stream is still open (the failure did not close it): a clean pass then closes it and
            // reports no failures.
            int cleanFailures = await registry.CloseOrphanTaskStreamsAsync(
                (_, inputId) => new ValueTask<bool>(inputId == "orphan"));
            Assert.That(cleanFailures, Is.EqualTo(0), "A pass that closes every candidate reports no failures.");
        }
        finally
        {
            if (Directory.Exists(root))
            { Directory.Delete(root, recursive: true); }
        }
    }

    [Test]
    public async Task EngineSweepCompletesCloseAfterTerminalWriteFlushFails()
    {
        // Engine-level regression for the fail-AFTER-write close: the terminal marker is written and
        // readable, but its durability flush fails once. A single cold-start scan must still complete
        // the close via the bounded in-place retry, not leave the stream half-closed behind a
        // readable-but-unpublished marker that the peek would skip.
        string root = Path.Combine(Path.GetTempPath(), "agentserver-orphan-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                sharedDir: Path.Combine(root, "tasks"),
                configureStreams: o => o.UseFileBackedReplay(Path.Combine(root, "streams"), TimeSpan.FromMinutes(10)));
            var registry = (ITaskEventStreamRegistry)host.Streams;

            var stream = (FileBackedReplayEventStream)await registry.GetOrCreateTaskStreamAsync("t", "orphan");
            await stream.EmitAsync(new SseItem<string>("first") { EventId = "1" });

            // A suspended record whose only input 'orphan' is retired (not queued): the sweep decides
            // to close its stream. Suspended is not a valid create status, so create in_progress then
            // transition (records start life in_progress and are suspended on turn end).
            await host.Store.CreateAsync(new TaskCreateRequest
            {
                Id = "t",
                AgentName = host.AgentName,
                SessionId = host.SessionId,
                Title = "orphaned",
                Status = TaskWireKeys.StatusInProgress,
                Payload = new JsonObject
                {
                    [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
                    [TaskWireKeys.PayloadLastInputId] = "orphan",
                },
                Source = new JsonObject
                {
                    [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
                    [TaskWireKeys.SourceName] = "orphaned",
                    [TaskWireKeys.SourceServerVersion] = "test",
                },
            });
            await host.Store.PatchAsync("t", new TaskPatchRequest { Status = TaskWireKeys.StatusSuspended }, ifMatch: null);

            // Fail the terminal flush on the first close; the engine's bounded retry must complete the
            // close within this single cold-start scan.
            stream.FailNextDurableFlushForTest();
            await host.Engine.ScanAndRecoverAsync();

            // Genuinely closed and published: replay reaches EOF instead of hanging, marker durable.
            List<string> replayed = await ReadToEndAsync(stream);
            Assert.That(replayed, Is.EqualTo(new[] { "first" }));
            Assert.That(
                FileBackedReplayEventStream.IsFileTerminated(Path.Combine(root, "streams", "orphan.jsonl")),
                Is.True);
        }
        finally
        {
            if (Directory.Exists(root))
            { Directory.Delete(root, recursive: true); }
        }
    }

    [TestCase(TaskWireKeys.StatusSuspended, "a", ExpectedResult = true, TestName = "Suspended finished input is closed")]
    [TestCase(TaskWireKeys.StatusCompleted, "a", ExpectedResult = true, TestName = "Completed input is closed")]
    public bool TerminalRecord_ClosesTheInput(string status, string inputId)
        => TaskEngine.ShouldCloseOrphanInput(Record(status, active: "a"), inputId, Agent, Session);

    [Test]
    public void InProgress_KeepsActiveInputOpen()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusInProgress, active: "b"), "b", Agent, Session), Is.False);

    [Test]
    public void InProgress_ClosesRetiredPredecessor()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusInProgress, active: "b"), "a", Agent, Session), Is.True,
            "A promoted-away predecessor of a running turn is orphaned.");

    [Test]
    public void KeepsQueuedInputsOpen_EvenWhenSuspended()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusSuspended, active: "a", queued: new[] { "q1", "q2" }), "q1", Agent, Session), Is.False,
            "A durably-queued input runs on resume; its stream must stay open.");

    [Test]
    public void LeavesMissingRecordUntouched()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(null, "a", Agent, Session), Is.False,
            "A deleted or foreign-scope task's stream must never be sealed.");

    [Test]
    public void LeavesForeignSourceTypeUntouched()
    {
        TaskRecord record = Record(TaskWireKeys.StatusSuspended, active: "a");
        record.Source = new Source { Type = "other.framework" };
        Assert.That(TaskEngine.ShouldCloseOrphanInput(record, "a", Agent, Session), Is.False);
    }

    [Test]
    public void LeavesForeignAgentScopeUntouched()
    {
        // A present, terminal, matching-source record that belongs to ANOTHER agent on the shared
        // store must not be swept: the direct-by-id lookup can see it, but it is out of scope.
        TaskRecord record = Record(TaskWireKeys.StatusSuspended, active: "a");
        record.AgentName = "other-agent";
        Assert.That(TaskEngine.ShouldCloseOrphanInput(record, "a", Agent, Session), Is.False,
            "A record owned by a different agent is outside this engine's recovery scope.");
    }

    [Test]
    public void LeavesForeignSessionScopeUntouched()
    {
        TaskRecord record = Record(TaskWireKeys.StatusSuspended, active: "a");
        record.SessionId = "other-session";
        Assert.That(TaskEngine.ShouldCloseOrphanInput(record, "a", Agent, Session), Is.False,
            "A record owned by a different session is outside this engine's recovery scope.");
    }

    [Test]
    public void LeavesPendingRecordUntouched()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusPending, active: "a"), "a", Agent, Session), Is.False);

    private static TaskRecord Record(string status, string active, string[]? queued = null)
    {
        var payload = new System.Text.Json.Nodes.JsonObject
        {
            [TaskWireKeys.PayloadActiveInputId] = active,
            [TaskWireKeys.PayloadLastInputId] = active,
        };
        if (queued is { Length: > 0 })
        {
            var ids = new System.Text.Json.Nodes.JsonArray();
            foreach (string q in queued)
            { ids.Add(q); }
            payload[TaskWireKeys.PayloadSteering] = new System.Text.Json.Nodes.JsonObject
            {
                [TaskWireKeys.SteeringPendingInputIds] = ids,
            };
        }

        return new TaskRecord
        {
            Id = "t",
            Status = status,
            AgentName = Agent,
            SessionId = Session,
            Source = new Source { Type = TaskWireKeys.SourceTypeValue, Name = "task" },
            Payload = payload,
        };
    }

    private static async Task<List<string>> ReadToEndAsync(AgentEventStream stream)
    {
        var events = new List<string>();
        using var cts = new CancellationTokenSource(Timeout);
        await foreach (SseItem<string> item in stream.Subscribe(cancellationToken: cts.Token))
        {
            events.Add(item.Data);
        }

        return events;
    }
}
