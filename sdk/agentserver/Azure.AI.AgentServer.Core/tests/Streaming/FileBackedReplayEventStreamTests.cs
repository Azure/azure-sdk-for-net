// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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

    private EventStreamRegistry NewRegistry()
    {
        var options = new EventStreamOptions();
        options.UseFileBackedReplay(
            _dir,
            cursor: p => (int)p,
            ttl: TimeSpan.FromHours(1),
            serializer: p => Encoding.UTF8.GetBytes(p.ToString()!),
            deserializer: b => int.Parse(Encoding.UTF8.GetString(b)));
        return new EventStreamRegistry(options);
    }

    [Test]
    public async Task TraversalUnsafeStreamIdStaysWithinStorageDirectory()
    {
        // An id containing path-traversal characters must never write outside _dir. The backing
        // hash-encodes such ids to a safe stem, so the file lands in _dir and no parent-escaping
        // path is created.
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("../evil/id");
        await stream.EmitAsync(1);

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
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("unsafe/id");
        await stream.EmitAsync(1);

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
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync(reserved);
        await stream.EmitAsync(1);

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
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("gone-1");
        await registry.DeleteAsync("gone-1");

        Assert.Throws<EventStreamNotFoundException>(() => stream.Subscribe());
    }

    [Test]
    public async Task EmitAndCloseWritesEventThenTerminalAtomically()
    {
        // emit(close: true) must persist the event line immediately followed by the terminal
        // sentinel as one durable unit (a crash can never leave the event without its terminal).
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("atomic-1");
        await stream.EmitAsync(7, close: true);

        string[] lines = File.ReadAllLines(Path.Combine(_dir, "atomic-1.jsonl"));
        Assert.That(lines.Length, Is.EqualTo(2));
        Assert.That(lines[0], Does.Contain("emit_time").And.Contain("payload"));
        Assert.That(lines[1], Does.Contain("__terminal__"));
        ((IDisposable)stream).Dispose();
    }

    [Test]
    public async Task PersistsJsonlWithTerminalSentinel()
    {
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("turn-1");
        await stream.EmitAsync(0);
        await stream.EmitAsync(1, close: true);

        string[] lines = File.ReadAllLines(Path.Combine(_dir, "turn-1.jsonl"));
        Assert.That(lines.Length, Is.EqualTo(3));
        Assert.That(lines[0], Does.Contain("emit_time").And.Contain("payload"));
        Assert.That(lines[2], Does.Contain("__terminal__"));
    }

    [Test]
    public async Task CrashMidStreamRehydratesAndResumesFromNextCursor()
    {
        EventStreamRegistry registry1 = NewRegistry();
        IEventStream stream1 = await registry1.GetOrCreateAsync("turn-2");
        await stream1.EmitAsync(0);
        await stream1.EmitAsync(1);
        await stream1.EmitAsync(2);

        // Simulate a crash: release the writer lock without deleting the log.
        ((IDisposable)stream1).Dispose();

        EventStreamRegistry registry2 = NewRegistry();
        IEventStream stream2 = await registry2.GetOrCreateAsync("turn-2");

        Assert.That(await stream2.GetLastCursorAsync(), Is.EqualTo(2));

        // The rehydrated (non-terminal) stream is Active, so the producer resumes.
        Assert.DoesNotThrowAsync(async () => await stream2.EmitAsync(3));
        Assert.That(await stream2.GetLastCursorAsync(), Is.EqualTo(3));
    }

    [Test]
    public async Task DeleteRemovesBackingFileBeforeTombstoneSoRecreateStartsFresh()
    {
        // C-STR-FBR-4: delete() MUST clean up the file before the registry tombstones the id.
        // A same-id GetOrCreateAsync after delete must therefore start empty rather than
        // rehydrate the deleted stream's events from a lingering .jsonl file.
        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("turn-del");
        await stream.EmitAsync(0);
        await stream.EmitAsync(1);

        string path = Path.Combine(_dir, "turn-del.jsonl");
        Assert.That(File.Exists(path), Is.True);

        await registry.DeleteAsync("turn-del");
        Assert.That(File.Exists(path), Is.False, "delete() must remove the backing file (cleanup-before-tombstone).");

        IEventStream recreated = await registry.GetOrCreateAsync("turn-del");
        Assert.That(await recreated.GetLastCursorAsync(), Is.Null, "recreated stream must not rehydrate deleted events.");
    }

    [Test]
    public async Task RehydratedHistoryIsReplayedToLateSubscriber()
    {
        EventStreamRegistry registry1 = NewRegistry();
        IEventStream stream1 = await registry1.GetOrCreateAsync("turn-3");
        await stream1.EmitAsync(10);
        await stream1.EmitAsync(11);
        ((IDisposable)stream1).Dispose();

        EventStreamRegistry registry2 = NewRegistry();
        IEventStream stream2 = await registry2.GetOrCreateAsync("turn-3");

        var items = new List<object>();
        await stream2.EmitAsync(12, close: true);
        await foreach (object item in stream2.Subscribe())
        {
            items.Add(item);
        }

        Assert.That(items, Is.EqualTo(new object[] { 10, 11, 12 }));
    }

    [Test]
    public void CorruptedMidFileLineRaises()
    {
        File.WriteAllText(
            Path.Combine(_dir, "bad.jsonl"),
            "{\"emit_time\": 1.0, \"payload\": \"0\"}\nnot-json-garbage\n{\"emit_time\": 2.0, \"payload\": \"1\"}\n");

        EventStreamRegistry registry = NewRegistry();
        Assert.ThrowsAsync<EventStreamException>(async () => await registry.GetOrCreateAsync("bad"));
    }

    [Test]
    public async Task TrailingPartialLineIsTruncatedAndIgnored()
    {
        // A valid line followed by a crash mid-write (no trailing newline).
        File.WriteAllText(
            Path.Combine(_dir, "partial.jsonl"),
            "{\"emit_time\": 1.0, \"payload\": \"0\"}\n{\"emit_time\": 2.0, \"payl");

        EventStreamRegistry registry = NewRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("partial");

        Assert.That(await stream.GetLastCursorAsync(), Is.EqualTo(0));
    }

    [Test]
    public async Task SingleWriterPerIdIsEnforced()
    {
        EventStreamRegistry registry1 = NewRegistry();
        await registry1.GetOrCreateAsync("turn-4");

        EventStreamRegistry registry2 = NewRegistry();
        Assert.ThrowsAsync<EventStreamException>(async () => await registry2.GetOrCreateAsync("turn-4"));
    }

    [Test]
    public void PayloadRecordMissingEmitTimeRaises()
    {
        // A payload record without 'emit_time' is structurally malformed. Rehydration must raise
        // rather than silently default to epoch (which would drop the event on the next TTL sweep).
        File.WriteAllText(
            Path.Combine(_dir, "noemit.jsonl"),
            "{\"emit_time\": 1.0, \"payload\": \"0\"}\n{\"payload\": \"1\"}\n");

        EventStreamRegistry registry = NewRegistry();
        Assert.ThrowsAsync<EventStreamException>(async () => await registry.GetOrCreateAsync("noemit"));
    }

    [Test]
    public async Task CompactionSurvivesAndLeavesNoTempFile()
    {
        // Drive enough evictions to trigger compaction, then confirm the log rehydrates cleanly and
        // no ".compact" temp file is left behind (atomic temp+rename, never a truncated log).
        var options = new EventStreamOptions();
        options.UseFileBackedReplay(
            _dir,
            cursor: p => (int)p,
            ttl: TimeSpan.FromMilliseconds(1),
            serializer: p => Encoding.UTF8.GetBytes(p.ToString()!),
            deserializer: b => int.Parse(Encoding.UTF8.GetString(b)));
        var registry = new EventStreamRegistry(options);

        IEventStream stream = await registry.GetOrCreateAsync("compact-1");
        for (int i = 0; i < 1100; i++)
        {
            await stream.EmitAsync(i);
        }

        Assert.That(File.Exists(Path.Combine(_dir, "compact-1.jsonl.compact")), Is.False);
        Assert.That(File.Exists(Path.Combine(_dir, "compact-1.jsonl")), Is.True);

        // The compacted log still rehydrates without error.
        ((IDisposable)stream).Dispose();
        var registry2 = new EventStreamRegistry(options);
        Assert.DoesNotThrowAsync(async () => await registry2.GetOrCreateAsync("compact-1"));
    }

    private sealed record TypedEvent(int Cursor, string Text);

    [Test]
    public async Task GenericOverloadRoundTripsTypedPayloadViaDefaultJson()
    {
        // The typed overload must persist and rehydrate the payload as its CLR type (not a raw
        // JsonNode), so a cursor written against the typed payload keeps working after restart.
        var options = new EventStreamOptions();
        options.UseFileBackedReplay<TypedEvent>(cursor: e => e.Cursor, storageDirectory: _dir);
        var registry = new EventStreamRegistry(options);

        IEventStream stream = await registry.GetOrCreateAsync("typed-1");
        await stream.EmitAsync(new TypedEvent(0, "hello"));
        await stream.EmitAsync(new TypedEvent(1, "world"));
        ((IDisposable)stream).Dispose();

        // Rehydrate in a fresh registry; the cursor runs against the decoded payloads.
        var registry2 = new EventStreamRegistry(options);
        IEventStream rehydrated = await registry2.GetOrCreateAsync("typed-1");
        Assert.That(await rehydrated.GetLastCursorAsync(), Is.EqualTo(1));

        var items = new List<object>();
        await rehydrated.EmitAsync(new TypedEvent(2, "again"), close: true);
        await foreach (object item in rehydrated.Subscribe())
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(3));
        Assert.That(((TypedEvent)items[0]).Text, Is.EqualTo("hello"));
        Assert.That(((TypedEvent)items[2]).Text, Is.EqualTo("again"));
    }

    [Test]
    public async Task GenericOverloadDefaultsStorageDirectoryToStreamsStateRoot()
    {
        // With no storageDirectory the backing must default to <state-root>/streams. Point the
        // state root at a temp dir via AGENTSERVER_STATE_ROOT so the test is hermetic.
        string stateRoot = Path.Combine(Path.GetTempPath(), "agentserver-stateroot-" + Guid.NewGuid().ToString("N"));
        string? previous = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        try
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", stateRoot);

            var options = new EventStreamOptions();
            options.UseFileBackedReplay<TypedEvent>(cursor: e => e.Cursor);
            var registry = new EventStreamRegistry(options);

            IEventStream stream = await registry.GetOrCreateAsync("defaulted");
            await stream.EmitAsync(new TypedEvent(0, "x"));

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
