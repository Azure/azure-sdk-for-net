// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class FileBackedReplayEventStreamTests
{
    private string _dir = null!;

    [SetUp]
    public void SetUp()
    {
        _dir = Path.Combine(Path.GetTempPath(), "agentserver-fbr-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_dir);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            Directory.Delete(_dir, recursive: true);
        }
        catch (IOException)
        {
        }
    }

    private AgentEventStreamRegistry NewRegistry()
    {
        var options = new AgentEventStreamOptions();
        options.UseFileBackedReplay(storageDirectory: _dir, ttl: TimeSpan.FromHours(1));
        return new InMemoryEventStreamRegistry(options);
    }

    [Test]
    public async Task ReconnectionIntervalSurvivesRestart()
    {
        // The SSE `retry` field (SseItem.ReconnectionInterval) must be persisted and rehydrated
        // alongside data/event/id so a reconnecting client still receives the reconnection hint
        // after a process restart.
        AgentEventStreamRegistry registry1 = NewRegistry();
        AgentEventStream stream1 = await registry1.GetOrCreateAsync("retry");
        await stream1.EmitAsync(new SseItem<string>("data")
        {
            EventId = "1",
            ReconnectionInterval = TimeSpan.FromSeconds(7),
        });
        ((IDisposable)stream1).Dispose();

        AgentEventStreamRegistry registry2 = NewRegistry();
        AgentEventStream stream2 = await registry2.GetOrCreateAsync("retry");
        await foreach (SseItem<string> item in stream2.Subscribe())
        {
            Assert.That(item.ReconnectionInterval, Is.EqualTo(TimeSpan.FromSeconds(7)));
            break;
        }

        ((IDisposable)stream2).Dispose();
    }

    [Test]
    public async Task TraversalUnsafeStreamIdStaysWithinStorageDirectory()
    {
        // An id containing path-traversal characters must never write outside _dir. The backing
        // hash-encodes such ids to a safe stem, so the file lands in _dir and no parent-escaping
        // path is created.
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("../evil/id");
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });

        Assert.That(File.Exists(Path.Combine(_dir, "../evil/id.jsonl")), Is.False,
            "the raw traversal id must not be used as a path");
        string[] jsonl = Directory.GetFiles(_dir, "*.jsonl");
        Assert.That(jsonl, Has.Length.EqualTo(1), "exactly one safe backing file must exist inside the storage dir");
        Assert.That(Path.GetFileName(jsonl[0]), Does.StartWith("h_"), "the unsafe id must be hash-encoded");
        ((IDisposable)stream).Dispose();
    }

    [Test]
    public async Task HashEncodedFilenameUsesLowercaseHexForCrossLanguageParity()
    {
        // Python's hexdigest() emits lowercase hex; the .NET stem must match byte-for-byte so a
        // file written by one language is found by the other.
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("unsafe/id");
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });

        string[] jsonl = Directory.GetFiles(_dir, "*.jsonl");
        Assert.That(jsonl, Has.Length.EqualTo(1));
        string name = Path.GetFileNameWithoutExtension(jsonl[0]);

        byte[] expected = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes("unsafe/id"));
        string expectedStem = "h_" + Convert.ToHexString(expected).ToLowerInvariant();
        Assert.That(name, Is.EqualTo(expectedStem));
        ((IDisposable)stream).Dispose();
    }

    [Test]
    public async Task ReservedHashShapedIdIsItselfRehashed()
    {
        // An id that already looks exactly like the reserved "h_<64 lowercase hex>" stem must NOT be
        // used verbatim (it could alias the hash-encoding of a different, unsafe id); it is rehashed.
        string reserved = "h_" + new string('a', 64);
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync(reserved);
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });

        Assert.That(File.Exists(Path.Combine(_dir, reserved + ".jsonl")), Is.False,
            "the reserved-shaped id must not be used verbatim");
        string[] jsonl = Directory.GetFiles(_dir, "*.jsonl");
        Assert.That(jsonl, Has.Length.EqualTo(1));

        byte[] expected = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(reserved));
        string expectedStem = "h_" + Convert.ToHexString(expected).ToLowerInvariant();
        Assert.That(Path.GetFileNameWithoutExtension(jsonl[0]), Is.EqualTo(expectedStem));
        ((IDisposable)stream).Dispose();
    }

    [Test]
    public async Task SubscribeOnDestroyedStreamThrowsSynchronously()
    {
        // Mirroring Python's synchronous `subscribe`, a NotFound for a destroyed stream must surface
        // at the call site — not be deferred until the caller starts enumerating the iterator.
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("gone-1");
        await registry.DeleteAsync("gone-1");

        Assert.Throws<AgentEventStreamNotFoundException>(() => stream.Subscribe());
    }

    [Test]
    public async Task EmitAndCloseWritesEventThenTerminalAtomically()
    {
        // emit(close: true) must persist the event line immediately followed by the terminal
        // sentinel as one durable unit (a crash can never leave the event without its terminal).
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("atomic-1");
        await stream.EmitAsync(new SseItem<string>("7") { EventId = "7" }, close: true);

        // Release the exclusive writer handle before inspecting the file: the stream holds a single
        // long-lived append handle while active (production never reads a live stream's file — replay
        // is served from the in-memory buffer), so on-disk assertions read after the handle closes.
        ((IDisposable)stream).Dispose();

        string[] lines = File.ReadAllLines(Path.Combine(_dir, "atomic-1.jsonl"));
        Assert.That(lines.Length, Is.EqualTo(2));
        Assert.That(lines[0], Does.Contain("emit_time").And.Contain("data").And.Contain("event").And.Contain("id"));
        Assert.That(lines[1], Does.Contain("__terminal__"));
    }

    [Test]
    public async Task PersistsJsonlWithTerminalSentinel()
    {
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("turn-1");
        await stream.EmitAsync(new SseItem<string>("0") { EventId = "0" });
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" }, close: true);

        // Release the exclusive writer handle before inspecting the file (see note above).
        ((IDisposable)stream).Dispose();

        string[] lines = File.ReadAllLines(Path.Combine(_dir, "turn-1.jsonl"));
        Assert.That(lines.Length, Is.EqualTo(3));
        Assert.That(lines[0], Does.Contain("emit_time").And.Contain("data").And.Contain("event").And.Contain("id"));
        Assert.That(lines[2], Does.Contain("__terminal__"));
    }

    [Test]
    public async Task CrashMidStreamRehydratesAndResumesFromNextCursor()
    {
        AgentEventStreamRegistry registry1 = NewRegistry();
        AgentEventStream stream1 = await registry1.GetOrCreateAsync("turn-2");
        await stream1.EmitAsync(new SseItem<string>("0") { EventId = "0" });
        await stream1.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await stream1.EmitAsync(new SseItem<string>("2") { EventId = "2" });

        // Simulate a crash: release the writer lock without deleting the log.
        ((IDisposable)stream1).Dispose();

        AgentEventStreamRegistry registry2 = NewRegistry();
        AgentEventStream stream2 = await registry2.GetOrCreateAsync("turn-2");

        Assert.That(await stream2.GetLastEventIdAsync(), Is.EqualTo("2"));

        // The rehydrated (non-terminal) stream is Active, so the producer resumes.
        Assert.DoesNotThrowAsync(async () => await stream2.EmitAsync(new SseItem<string>("3") { EventId = "3" }));
        Assert.That(await stream2.GetLastEventIdAsync(), Is.EqualTo("3"));
    }

    [Test]
    public async Task DeleteRemovesBackingFileBeforeTombstoneSoRecreateStartsFresh()
    {
        // C-STR-FBR-4: delete() MUST clean up the file before the registry tombstones the id.
        // A same-id GetOrCreateAsync after delete must therefore start empty rather than
        // rehydrate the deleted stream's events from a lingering .jsonl file.
        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("turn-del");
        await stream.EmitAsync(new SseItem<string>("0") { EventId = "0" });
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });

        string path = Path.Combine(_dir, "turn-del.jsonl");
        Assert.That(File.Exists(path), Is.True);

        await registry.DeleteAsync("turn-del");
        Assert.That(File.Exists(path), Is.False, "delete() must remove the backing file (cleanup-before-tombstone).");

        AgentEventStream recreated = await registry.GetOrCreateAsync("turn-del");
        Assert.That(await recreated.GetLastEventIdAsync(), Is.Null, "recreated stream must not rehydrate deleted events.");
    }

    [Test]
    public async Task RehydratedHistoryIsReplayedToLateSubscriber()
    {
        AgentEventStreamRegistry registry1 = NewRegistry();
        AgentEventStream stream1 = await registry1.GetOrCreateAsync("turn-3");
        await stream1.EmitAsync(new SseItem<string>("10") { EventId = "10" });
        await stream1.EmitAsync(new SseItem<string>("11") { EventId = "11" });
        ((IDisposable)stream1).Dispose();

        AgentEventStreamRegistry registry2 = NewRegistry();
        AgentEventStream stream2 = await registry2.GetOrCreateAsync("turn-3");

        var items = new List<string>();
        await stream2.EmitAsync(new SseItem<string>("12") { EventId = "12" }, close: true);
        await foreach (SseItem<string> item in stream2.Subscribe())
        {
            items.Add(item.Data);
        }

        Assert.That(items, Is.EqualTo(new[] { "10", "11", "12" }));
    }

    [Test]
    public void CorruptedMidFileLineRaises()
    {
        File.WriteAllText(
            Path.Combine(_dir, "bad.jsonl"),
            "{\"emit_time\": 1.0, \"data\": \"0\", \"event\": \"message\", \"id\": \"0\"}\nnot-json-garbage\n{\"emit_time\": 2.0, \"data\": \"1\", \"event\": \"message\", \"id\": \"1\"}\n");

        AgentEventStreamRegistry registry = NewRegistry();
        Assert.ThrowsAsync<AgentEventStreamException>(async () => await registry.GetOrCreateAsync("bad"));
    }

    [Test]
    public async Task FailedRehydrateReleasesWriterLock()
    {
        string path = Path.Combine(_dir, "bad-lock.jsonl");
        File.WriteAllText(path, "not-json-garbage\n");

        AgentEventStreamRegistry registry1 = NewRegistry();
        Assert.ThrowsAsync<AgentEventStreamException>(async () => await registry1.GetOrCreateAsync("bad-lock"));

        File.WriteAllText(path, "{\"emit_time\": 1.0, \"data\": \"0\", \"event\": \"message\", \"id\": \"0\"}\n");

        AgentEventStreamRegistry registry2 = NewRegistry();
        AgentEventStream stream = await registry2.GetOrCreateAsync("bad-lock");

        Assert.That(await stream.GetLastEventIdAsync(), Is.EqualTo("0"));
    }

    [Test]
    public async Task TrailingPartialLineIsTruncatedAndIgnored()
    {
        // A valid line followed by a crash mid-write (no trailing newline).
        File.WriteAllText(
            Path.Combine(_dir, "partial.jsonl"),
            "{\"emit_time\": 1.0, \"data\": \"0\", \"event\": \"message\", \"id\": \"0\"}\n{\"emit_time\": 2.0, \"dat");

        AgentEventStreamRegistry registry = NewRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("partial");

        Assert.That(await stream.GetLastEventIdAsync(), Is.EqualTo("0"));
    }

    [Test]
    public async Task SingleWriterPerIdIsEnforced()
    {
        AgentEventStreamRegistry registry1 = NewRegistry();
        await registry1.GetOrCreateAsync("turn-4");

        AgentEventStreamRegistry registry2 = NewRegistry();
        Assert.ThrowsAsync<AgentEventStreamException>(async () => await registry2.GetOrCreateAsync("turn-4"));
    }

    [Test]
    public void EventRecordMissingEmitTimeRaises()
    {
        // An event record without 'emit_time' is structurally malformed. Rehydration must raise
        // rather than silently default to epoch (which would drop the event on the next TTL sweep).
        File.WriteAllText(
            Path.Combine(_dir, "noemit.jsonl"),
            "{\"emit_time\": 1.0, \"data\": \"0\", \"event\": \"message\", \"id\": \"0\"}\n{\"data\": \"1\", \"event\": \"message\", \"id\": \"1\"}\n");

        AgentEventStreamRegistry registry = NewRegistry();
        Assert.ThrowsAsync<AgentEventStreamException>(async () => await registry.GetOrCreateAsync("noemit"));
    }

    [Test]
    public async Task CompactionSurvivesAndLeavesNoTempFile()
    {
        // Drive enough evictions to trigger compaction, then confirm the log rehydrates cleanly and
        // no ".compact" temp file is left behind (atomic temp+rename, never a truncated log).
        var options = new AgentEventStreamOptions();
        options.UseFileBackedReplay(storageDirectory: _dir, ttl: TimeSpan.FromMilliseconds(1));
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("compact-1");
        for (int i = 0; i < 1100; i++)
        {
            string value = i.ToString();
            await stream.EmitAsync(new SseItem<string>(value) { EventId = value });
        }

        Assert.That(File.Exists(Path.Combine(_dir, "compact-1.jsonl.compact")), Is.False);
        Assert.That(File.Exists(Path.Combine(_dir, "compact-1.jsonl")), Is.True);

        // The compacted log still rehydrates without error.
        ((IDisposable)stream).Dispose();
        var registry2 = new InMemoryEventStreamRegistry(options);
        Assert.DoesNotThrowAsync(async () => await registry2.GetOrCreateAsync("compact-1"));
    }

    [Test]
    public async Task PostCompactionWritesLandInLiveFileAndRehydrate()
    {
        // Regression guard for the long-lived append handle: after an on-disk compaction performs
        // an atomic replace, the reused write handle must be reopened against the LIVE file. If it
        // kept pointing at the pre-replace (orphaned) file, post-compaction emits would be written
        // to a file nobody rehydrates from and would be silently lost on the next process lifetime.
        var options = new AgentEventStreamOptions();
        options.UseFileBackedReplay(storageDirectory: _dir, ttl: TimeSpan.FromMilliseconds(1));
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("compact-live");

        // Drive past the compaction threshold, then emit a few more AFTER the compaction.
        for (int i = 0; i < 1100; i++)
        {
            string value = i.ToString();
            await stream.EmitAsync(new SseItem<string>(value) { EventId = value });
        }

        await stream.EmitAsync(new SseItem<string>("9001") { EventId = "9001" });
        await stream.EmitAsync(new SseItem<string>("9002") { EventId = "9002" }, close: true);
        ((IDisposable)stream).Dispose();

        // The post-compaction emits must be present in the LIVE on-disk file. If the reused write
        // handle had stayed bound to the pre-replace (orphaned) file, these values would be missing
        // from the live file and lost on the next process lifetime. Reading the file directly keeps
        // the assertion deterministic (a 1 ms TTL would evict them from any rehydrated buffer).
        string liveFile = File.ReadAllText(Path.Combine(_dir, "compact-live.jsonl"));
        Assert.That(liveFile, Does.Contain("9001"));
        Assert.That(liveFile, Does.Contain("9002"));

        // And the log still rehydrates cleanly from the live file.
        var registry2 = new InMemoryEventStreamRegistry(options);
        Assert.DoesNotThrowAsync(async () => await registry2.GetOrCreateAsync("compact-live"));
    }

    [Test]
    public async Task WriterSelfHealsWhenCompactionLeftTheHandleClosed()
    {
        // Models the compaction move-failure: AtomicOverwrite disposes the long-lived append handle
        // before the atomic replace, so if the move throws the handle is left closed. A subsequent
        // emit must reopen it (the single-writer lock is still held) rather than permanently failing
        // the stream. A real move failure can't be induced deterministically on Windows (the open
        // write handle blocks any external move-blocking handle), so the post-failure state is
        // reproduced directly by disposing and nulling the private handle.
        var options = new AgentEventStreamOptions();
        options.UseFileBackedReplay(storageDirectory: _dir);
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("selfheal");
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });

        System.Reflection.FieldInfo field = stream.GetType().GetField(
            "_data",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
        Assert.That(field, Is.Not.Null, "expected private _data append handle field");
        ((IDisposable)field.GetValue(stream)!).Dispose();
        field.SetValue(stream, null);

        // Without the self-heal this throws "The write handle for stream 'selfheal' is not open."
        Assert.DoesNotThrowAsync(async () => await stream.EmitAsync(new SseItem<string>("2") { EventId = "2" }, close: true));
        ((IDisposable)stream).Dispose();

        // Both events survived to disk and rehydrate.
        var registry2 = new InMemoryEventStreamRegistry(options);
        AgentEventStream rehydrated = await registry2.GetOrCreateAsync("selfheal");
        Assert.That(await rehydrated.GetLastEventIdAsync(), Is.EqualTo("2"));
    }

    [Test]
    public async Task FileBackedReplayRoundTripsCallerSerializedPayloadData()
    {
        // Callers now own serialization; the backing persists and rehydrates the serialized data
        // string while tracking resume by SseItem.EventId.
        var options = new AgentEventStreamOptions();
        options.UseFileBackedReplay(storageDirectory: _dir);
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("typed-1");
        await stream.EmitAsync(new SseItem<string>("{\"cursor\":0,\"text\":\"hello\"}") { EventId = "0" });
        await stream.EmitAsync(new SseItem<string>("{\"cursor\":1,\"text\":\"world\"}") { EventId = "1" });
        ((IDisposable)stream).Dispose();

        // Rehydrate in a fresh registry; the last event id is restored from the decoded items.
        var registry2 = new InMemoryEventStreamRegistry(options);
        AgentEventStream rehydrated = await registry2.GetOrCreateAsync("typed-1");
        Assert.That(await rehydrated.GetLastEventIdAsync(), Is.EqualTo("1"));

        var items = new List<string>();
        await rehydrated.EmitAsync(new SseItem<string>("{\"cursor\":2,\"text\":\"again\"}") { EventId = "2" }, close: true);
        await foreach (SseItem<string> item in rehydrated.Subscribe())
        {
            items.Add(item.Data);
        }

        Assert.That(items, Has.Count.EqualTo(3));
        Assert.That(items[0], Is.EqualTo("{\"cursor\":0,\"text\":\"hello\"}"));
        Assert.That(items[2], Is.EqualTo("{\"cursor\":2,\"text\":\"again\"}"));
    }

    [Test]
    public async Task FileBackedReplayDefaultsStorageDirectoryToStreamsStateRoot()
    {
        // With no storageDirectory the backing must default to <state-root>/streams. Point the
        // state root at a temp dir via AGENTSERVER_STATE_ROOT so the test is hermetic.
        string stateRoot = Path.Combine(Path.GetTempPath(), "agentserver-stateroot-" + Guid.NewGuid().ToString("N"));
        string? previous = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        try
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", stateRoot);

            var options = new AgentEventStreamOptions();
            options.UseFileBackedReplay();
            var registry = new InMemoryEventStreamRegistry(options);

            AgentEventStream stream = await registry.GetOrCreateAsync("defaulted");
            await stream.EmitAsync(new SseItem<string>("{\"cursor\":0,\"text\":\"x\"}") { EventId = "0" });

            string expected = Path.Combine(stateRoot, "streams", "defaulted.jsonl");
            Assert.That(File.Exists(expected), Is.True, $"expected the backing file at {expected}");
            ((IDisposable)stream).Dispose();
        }
        finally
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previous);
            try
            {
                Directory.Delete(stateRoot, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }
}
