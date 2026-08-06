// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The file-backed replay backing: persists events to
/// <c>&lt;storageDirectory&gt;/&lt;id&gt;.jsonl</c> and rehydrates on construction so a fresh
/// process resuming the same turn recovers its history. Each line records the emitted
/// <see cref="SseItem{T}"/> (its <see cref="SseItem{T}.Data"/>, opaque
/// <see cref="SseItem{T}.EventId"/>, and <see cref="SseItem{T}.EventType"/>); the data is already a
/// string, so no payload codec is required.
/// </summary>
internal sealed class FileBackedReplayEventStream : ReplayEventStream, IDisposable
{
    private const string TerminalKey = "__terminal__";
    private const string EmitTimeKey = "emit_time";
    private const string DataKey = "data";
    private const string IdKey = "id";
    private const string EventKey = "event";
    private const string RetryKey = "retry";
    private const int CompactionThreshold = 1000;

    private readonly object _fileGate = new();
    private readonly string _filePath;
    private readonly string _lockPath;
    private FileStream? _lock;
    private FileStream? _data;
    private int _evictionsSinceCompaction;
    private bool _disposed;

    public FileBackedReplayEventStream(
        string id,
        string storageDirectory,
        TimeSpan? ttl,
        Action onDestroy)
        : base(id, ttl, onDestroy)
    {
        Directory.CreateDirectory(storageDirectory);
        string stem = ToSafeFileStem(id);
        _filePath = Path.Combine(storageDirectory, stem + ".jsonl");
        _lockPath = Path.Combine(storageDirectory, stem + ".lock");

        AcquireWriterLock();
        try
        {
            Rehydrate();

            // Open ONE long-lived append handle after any rehydrate-time truncation rewrite, and
            // reuse it for every emit (write + fsync) instead of opening/closing a fresh handle per
            // event. The per-event fsync durability contract (persist-before-fan-out) is preserved;
            // only the redundant open/close syscalls per event are removed. The separate `_lock`
            // file keeps the single-writer guarantee independent of this data handle, so compaction
            // can freely close and reopen it across the atomic replace without releasing exclusivity.
            _data = OpenAppendHandle();
        }
        catch
        {
            _data?.Dispose();
            _data = null;
            ReleaseWriterLock();
            throw;
        }
    }

    private FileStream OpenAppendHandle()
        => new FileStream(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read);

    // Maps a stream id to a single, safe on-disk filename stem. Well-formed ids (GUIDs and other
    // tokens using [A-Za-z0-9._-], with no "."/".." path segment, that are not already shaped like
    // the reserved "h_<64 lowercase hex>" hash stem) are used verbatim so on-disk names stay
    // readable. Any other id — one containing a path separator, a reserved "."/".." segment, a
    // filesystem-invalid character, or the reserved hash shape — is deterministically SHA-256
    // hash-encoded to an "h_<64 lowercase hex>" stem so it can never escape the storage directory
    // (path traversal) or collide with a sibling stream (the verbatim and hashed namespaces stay
    // disjoint).
    private static string ToSafeFileStem(string id)
    {
        bool safe = id.Length > 0 && id != "." && id != "..";
        if (safe)
        {
            foreach (char c in id)
            {
                if (!(char.IsAsciiLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
                {
                    safe = false;
                    break;
                }
            }
        }

        if (safe && IsReservedHashStem(id))
        {
            // A verbatim id of the exact reserved shape could alias the hash-encoding of a
            // different, unsafe id — so it is itself hash-encoded to keep the namespaces disjoint.
            safe = false;
        }

        if (safe)
        {
            return id;
        }

        byte[] hash = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(id));
        return "h_" + Convert.ToHexString(hash).ToLowerInvariant();
    }

    // True when the id is exactly "h_" followed by 64 lowercase hex characters (the reserved shape
    // produced by the hash-encoding branch).
    private static bool IsReservedHashStem(string id)
    {
        if (id.Length != 66 || id[0] != 'h' || id[1] != '_')
        {
            return false;
        }

        for (int i = 2; i < id.Length; i++)
        {
            char c = id[i];
            bool hex = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f');
            if (!hex)
            {
                return false;
            }
        }

        return true;
    }

    protected override void PersistEmit(SseItem<string> item, double emitTime)
        => AppendLine(EncodeItemLine(item, emitTime));

    protected override void PersistClose()
        => AppendLine(new JsonObject { [TerminalKey] = true }.ToJsonString());

    protected override void PersistEmitAndClose(SseItem<string> item, double emitTime)
    {
        // Append the event line and the terminal sentinel in a single write+flush so a crash can
        // never leave a durable event without its terminal marker (atomic emit-and-close).
        var terminalLine = new JsonObject { [TerminalKey] = true };
        AppendLines(EncodeItemLine(item, emitTime), terminalLine.ToJsonString());
    }

    protected override void PersistDelete()
    {
        lock (_fileGate)
        {
            _data?.Dispose();
            _data = null;
            TryDeleteFile(_filePath);
            ReleaseWriterLock();
        }
    }

    protected override void OnEvicted(int count)
    {
        _evictionsSinceCompaction += count;
        if (_evictionsSinceCompaction >= CompactionThreshold)
        {
            _evictionsSinceCompaction = 0;
            Compact();
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        lock (_fileGate)
        {
            _data?.Dispose();
            _data = null;
            ReleaseWriterLock();
        }
    }

    private void Rehydrate()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        byte[] bytes = File.ReadAllBytes(_filePath);
        bool endsWithNewline = bytes.Length > 0 && bytes[bytes.Length - 1] == (byte)'\n';
        string text = Encoding.UTF8.GetString(bytes);
        string[] rawLines = text.Split('\n');

        // A final empty element appears when the file ends with '\n'. Collect the
        // non-empty lines; the last one is a partial write only if the file did NOT
        // end with a newline.
        var lines = new List<string>();
        foreach (string raw in rawLines)
        {
            if (raw.Length > 0)
            {
                lines.Add(raw);
            }
        }

        int completeCount = lines.Count;
        bool hadPartialTail = false;
        if (!endsWithNewline && lines.Count > 0)
        {
            // The trailing line is a crash mid-write: truncate and ignore it.
            completeCount = lines.Count - 1;
            hadPartialTail = true;
        }

        bool terminalAtEnd = false;
        for (int i = 0; i < completeCount; i++)
        {
            JsonNode? node = TryParse(lines[i]);
            if (node is not JsonObject obj)
            {
                throw new AgentEventStreamException($"Corrupted line {i + 1} in stream log '{_filePath}'.");
            }

            if (obj.TryGetPropertyValue(TerminalKey, out JsonNode? terminal) && terminal is JsonValue tv && tv.GetValue<bool>())
            {
                // A terminal sentinel is only honored as the final complete line.
                terminalAtEnd = i == completeCount - 1;
                continue;
            }

            double emitTime;
            if (obj.TryGetPropertyValue(EmitTimeKey, out JsonNode? et) && et is JsonValue ev)
            {
                emitTime = ev.GetValue<double>();
            }
            else
            {
                // A record without 'emit_time' is structurally malformed (the wire format requires
                // {"emit_time": <float>, "data": <string>, ...}). Raising is a corruption signal —
                // silently defaulting to epoch would either drop the event on the next TTL sweep or
                // resurrect it with a wildly wrong timestamp.
                throw new AgentEventStreamException(
                    $"Record at line {i + 1} of stream log '{_filePath}' is missing the 'emit_time' field.");
            }

            SseItem<string> item = DecodeItem(obj, i + 1);
            SeedHistory(item, emitTime);
        }

        if (hadPartialTail)
        {
            RewritePartialTruncation(lines, completeCount);
        }

        if (terminalAtEnd)
        {
            SeedClosed();
        }
    }

    private void RewritePartialTruncation(List<string> lines, int completeCount)
    {
        lock (_fileGate)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < completeCount; i++)
            {
                sb.Append(lines[i]).Append('\n');
            }

            AtomicOverwrite(sb.ToString());
        }
    }

    private void Compact()
    {
        lock (_fileGate)
        {
            IReadOnlyList<KeyValuePair<SseItem<string>, double>> retained = RetainedForCompaction();
            var sb = new StringBuilder();
            foreach (KeyValuePair<SseItem<string>, double> entry in retained)
            {
                sb.Append(EncodeItemLine(entry.Key, entry.Value)).Append('\n');
            }

            // Preserve the terminal marker across compaction when the stream is closed, so a future
            // process rehydrating the compacted file still recognizes it as closed.
            if (IsClosedSnapshot)
            {
                sb.Append(new JsonObject { [TerminalKey] = true }.ToJsonString()).Append('\n');
            }

            AtomicOverwrite(sb.ToString());
        }
    }

    // Rewrites the log via a temp-file + atomic rename so a crash mid-rewrite can never leave a
    // truncated/empty file (a plain File.WriteAllText truncates in place first — the window between
    // truncate and write would permanently destroy the event history).
    private void AtomicOverwrite(string content)
    {
        string tempPath = _filePath + ".compact";
        var bytes = Encoding.UTF8.GetBytes(content);
        using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush(flushToDisk: true);
        }

        // The atomic replace swaps _filePath to a brand-new file. The long-lived append handle
        // (if open) still points at the old, now-replaced file, so every subsequent emit would land
        // in the orphaned file and be lost on the next process lifetime. Close it before the replace
        // (Windows also forbids File.Move over an open handle) and reopen against the live path after
        // — the single-writer `_lock` file stays held throughout, so exclusivity is never released
        // across the swap.
        bool reopen = _data is not null;
        if (reopen)
        {
            _data!.Dispose();
            _data = null;
        }

        try
        {
            File.Move(tempPath, _filePath, overwrite: true);
        }
        finally
        {
            // Always restore a usable writer, even if the move threw (e.g. a transient sharing
            // failure): on success the reopened handle points at the compacted file; on a failed
            // move the original log is left intact, so it points at that. Without this a transient
            // compaction failure would permanently disable the stream. Also delete any leftover
            // temp file so a failed move can't orphan it (a successful move already consumed it).
            if (reopen)
            {
                _data = OpenAppendHandle();
            }

            TryDeleteFile(tempPath);
        }
    }

    // Encodes one emitted item as a JSON-object line: the event text ('data'), the opaque event id
    // ('id', omitted when null), the SSE event type ('event'), and the SSE reconnection interval
    // ('retry', in whole milliseconds, omitted when unset), plus the emit time used for TTL.
    private static string EncodeItemLine(SseItem<string> item, double emitTime)
    {
        var line = new JsonObject
        {
            [EmitTimeKey] = emitTime,
            [DataKey] = item.Data,
            [EventKey] = item.EventType,
        };
        if (item.EventId is not null)
        {
            line[IdKey] = item.EventId;
        }

        if (item.ReconnectionInterval is { } retry)
        {
            line[RetryKey] = (long)retry.TotalMilliseconds;
        }

        return line.ToJsonString();
    }

    private SseItem<string> DecodeItem(JsonObject obj, int lineNumber)
    {
        if (!obj.TryGetPropertyValue(DataKey, out JsonNode? dataNode) || dataNode is not JsonValue dataValue
            || !dataValue.TryGetValue(out string? data) || data is null)
        {
            throw new AgentEventStreamException(
                $"Record at line {lineNumber} of stream log '{_filePath}' is missing the 'data' field.");
        }

        string? eventType = null;
        if (obj.TryGetPropertyValue(EventKey, out JsonNode? eventNode) && eventNode is JsonValue eventValue)
        {
            eventValue.TryGetValue(out eventType);
        }

        string? eventId = null;
        if (obj.TryGetPropertyValue(IdKey, out JsonNode? idNode) && idNode is JsonValue idValue)
        {
            idValue.TryGetValue(out eventId);
        }

        TimeSpan? reconnectionInterval = null;
        if (obj.TryGetPropertyValue(RetryKey, out JsonNode? retryNode) && retryNode is JsonValue retryValue
            && retryValue.TryGetValue(out long retryMs))
        {
            reconnectionInterval = TimeSpan.FromMilliseconds(retryMs);
        }

        return new SseItem<string>(data, eventType) { EventId = eventId, ReconnectionInterval = reconnectionInterval };
    }

    private void AppendLine(string line) => AppendLines(line);

    private void AppendLines(params string[] lines)
    {
        lock (_fileGate)
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                // Persist-before-fan-out durability: flush the OS buffer to disk so a crash after
                // emit() returns cannot silently lose an event that a subscriber already observed.
                // Write through the single long-lived append handle and fsync per event. Multiple
                // lines are written under a single flush so an emit-and-close pair is an atomic
                // durable unit.
                var sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.Append(line).Append('\n');
                }

                var bytes = Encoding.UTF8.GetBytes(sb.ToString());

                // Self-heal: if a prior compaction's atomic replace failed to restore the writer,
                // reopen it here (the single-writer lock is still held) rather than failing every
                // subsequent emit. A null handle with no lock means the stream was deleted, so it
                // stays null and the write below fails loud instead of resurrecting the file.
                if (_data is null && _lock is not null)
                {
                    _data = OpenAppendHandle();
                }

                FileStream fs = _data
                    ?? throw new AgentEventStreamException($"The write handle for stream '{Id}' is not open.");
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush(flushToDisk: true);
            }
            catch (IOException ex)
            {
                throw new AgentEventStreamException($"Failed to persist event for stream '{Id}'.", ex);
            }
        }
    }

    private void AcquireWriterLock()
    {
        try
        {
            _lock = new FileStream(_lockPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException ex)
        {
            throw new AgentEventStreamException(
                $"Stream log '{_filePath}' is already opened by another writer.", ex);
        }
    }

    private void ReleaseWriterLock()
    {
        _lock?.Dispose();
        _lock = null;
        TryDeleteFile(_lockPath);
    }

    private static JsonNode? TryParse(string line)
    {
        try
        {
            return JsonNode.Parse(line);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static void TryDeleteFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        catch (IOException)
        {
        }
    }
}
