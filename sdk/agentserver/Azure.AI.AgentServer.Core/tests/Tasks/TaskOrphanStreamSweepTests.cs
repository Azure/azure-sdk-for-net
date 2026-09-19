// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks.Engine;
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

    [TestCase(TaskWireKeys.StatusSuspended, "a", ExpectedResult = true, TestName = "Suspended finished input is closed")]
    [TestCase(TaskWireKeys.StatusCompleted, "a", ExpectedResult = true, TestName = "Completed input is closed")]
    public bool TerminalRecord_ClosesTheInput(string status, string inputId)
        => TaskEngine.ShouldCloseOrphanInput(Record(status, active: "a"), inputId);

    [Test]
    public void InProgress_KeepsActiveInputOpen()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusInProgress, active: "b"), "b"), Is.False);

    [Test]
    public void InProgress_ClosesRetiredPredecessor()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusInProgress, active: "b"), "a"), Is.True,
            "A promoted-away predecessor of a running turn is orphaned.");

    [Test]
    public void KeepsQueuedInputsOpen_EvenWhenSuspended()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusSuspended, active: "a", queued: new[] { "q1", "q2" }), "q1"), Is.False,
            "A durably-queued input runs on resume; its stream must stay open.");

    [Test]
    public void LeavesMissingRecordUntouched()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(null, "a"), Is.False,
            "A deleted or foreign-scope task's stream must never be sealed.");

    [Test]
    public void LeavesForeignSourceTypeUntouched()
    {
        TaskRecord record = Record(TaskWireKeys.StatusSuspended, active: "a");
        record.Source = new Source { Type = "other.framework" };
        Assert.That(TaskEngine.ShouldCloseOrphanInput(record, "a"), Is.False);
    }

    [Test]
    public void LeavesPendingRecordUntouched()
        => Assert.That(TaskEngine.ShouldCloseOrphanInput(
            Record(TaskWireKeys.StatusPending, active: "a"), "a"), Is.False);

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
