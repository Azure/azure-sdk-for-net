// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The file-backed replay backing: persists events to
/// <c>&lt;storageDirectory&gt;/&lt;id&gt;.jsonl</c> using the SOT wire format so the
/// on-disk shape is consistent across implementations, and rehydrates on
/// construction so a fresh process resuming the same turn recovers its history.
/// </summary>
internal sealed class FileBackedReplayEventStream : ReplayEventStream, IDisposable
{
    private const string TerminalKey = "__terminal__";
    private const string EmitTimeKey = "emit_time";
    private const string PayloadKey = "payload";
    private const int CompactionThreshold = 1000;

    private readonly object _fileGate = new();
    private readonly string _filePath;
    private readonly string _lockPath;
    private readonly Func<object, byte[]>? _serializer;
    private readonly Func<byte[], object>? _deserializer;
    private FileStream? _lock;
    private int _evictionsSinceCompaction;
    private bool _disposed;

    public FileBackedReplayEventStream(
        string id,
        string storageDirectory,
        Func<object, int>? cursor,
        TimeSpan? ttl,
        Func<object, byte[]>? serializer,
        Func<byte[], object>? deserializer,
        Action onDestroy)
        : base(id, cursor, ttl, onDestroy)
    {
        Directory.CreateDirectory(storageDirectory);
        string stem = ToSafeFileStem(id);
        _filePath = Path.Combine(storageDirectory, stem + ".jsonl");
        _lockPath = Path.Combine(storageDirectory, stem + ".lock");
        _serializer = serializer;
        _deserializer = deserializer;

        AcquireWriterLock();
        Rehydrate();
    }

    // Maps a stream id to a single, safe on-disk filename stem. Well-formed ids (GUIDs and other
    // tokens using [A-Za-z0-9._-], with no "."/".." path segment, that are not already shaped like
    // the reserved "h_<64 lowercase hex>" hash stem) are used verbatim so on-disk names stay
    // readable and match the cross-language wire contract. Any other id — one containing a path
    // separator, a reserved "."/".." segment, a filesystem-invalid character, or the reserved
    // hash shape — is deterministically SHA-256 hash-encoded to an "h_<64 lowercase hex>" stem so
    // it can never escape the storage directory (path traversal) or collide with a sibling stream
    // (the verbatim and hashed namespaces stay disjoint). The hex is lowercase to stay
    // byte-identical with the Python implementation's hexdigest() output.
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
    // produced by the hash-encoding branch), matching Python's ^h_[0-9a-f]{64}$.
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

    protected override void PersistEmit(object payload, double emitTime)
    {
        var line = new JsonObject
        {
            [EmitTimeKey] = emitTime,
            [PayloadKey] = EncodePayload(payload),
        };
        AppendLine(line.ToJsonString());
    }

    protected override void PersistClose()
        => AppendLine(new JsonObject { [TerminalKey] = true }.ToJsonString());

    protected override void PersistEmitAndClose(object payload, double emitTime)
    {
        // Append the event line and the terminal sentinel in a single write+flush so a crash can
        // never leave a durable event without its terminal marker (atomic emit-and-close).
        var eventLine = new JsonObject
        {
            [EmitTimeKey] = emitTime,
            [PayloadKey] = EncodePayload(payload),
        };
        var terminalLine = new JsonObject { [TerminalKey] = true };
        AppendLines(eventLine.ToJsonString(), terminalLine.ToJsonString());
    }

    protected override void PersistDelete()
    {
        lock (_fileGate)
        {
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
                throw new EventStreamException($"Corrupted line {i + 1} in stream log '{_filePath}'.");
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
                // A payload record without 'emit_time' is structurally malformed (the wire format
                // requires {"emit_time": <float>, "payload": ...}). Raising is a corruption signal —
                // silently defaulting to epoch would either drop the event on the next TTL sweep or
                // resurrect it with a wildly wrong timestamp (matches Python's rehydrate contract).
                throw new EventStreamException(
                    $"Record at line {i + 1} of stream log '{_filePath}' is missing the 'emit_time' field.");
            }

            object payload = DecodePayload(obj[PayloadKey]);
            SeedHistory(payload, emitTime);
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
            IReadOnlyList<KeyValuePair<object, double>> retained = RetainedForCompaction();
            var sb = new StringBuilder();
            foreach (KeyValuePair<object, double> entry in retained)
            {
                var line = new JsonObject
                {
                    [EmitTimeKey] = entry.Value,
                    [PayloadKey] = EncodePayload(entry.Key),
                };
                sb.Append(line.ToJsonString()).Append('\n');
            }

            // Preserve the terminal marker across compaction when the stream is closed, so a future
            // process rehydrating the compacted file still recognizes it as closed (matches Python).
            if (IsClosedSnapshot)
            {
                sb.Append(new JsonObject { [TerminalKey] = true }.ToJsonString()).Append('\n');
            }

            AtomicOverwrite(sb.ToString());
        }
    }

    // Rewrites the log via a temp-file + atomic rename so a crash mid-rewrite can never leave a
    // truncated/empty file (a plain File.WriteAllText truncates in place first — the window between
    // truncate and write would permanently destroy the event history). Mirrors Python's
    // os.replace()-based compaction (crash-recovery friendly, C-STR-FBR-2).
    private void AtomicOverwrite(string content)
    {
        string tempPath = _filePath + ".compact";
        var bytes = Encoding.UTF8.GetBytes(content);
        using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush(flushToDisk: true);
        }

        File.Move(tempPath, _filePath, overwrite: true);
    }

    // Custom-serializer payloads are stored as a UTF-8 JSON string (NOT base64) so the on-disk
    // format is byte-compatible with the Python file-backed replay backing and the two runtimes
    // can read each other's stream files.
    private JsonNode? EncodePayload(object payload)
    {
        if (_serializer is not null)
        {
            return Encoding.UTF8.GetString(_serializer(payload));
        }

        return JsonSerializer.SerializeToNode(payload);
    }

    private object DecodePayload(JsonNode? node)
    {
        if (_deserializer is not null)
        {
            string serialized = node is JsonValue value && value.TryGetValue(out string? s)
                ? s
                : node?.ToJsonString() ?? string.Empty;
            return _deserializer(Encoding.UTF8.GetBytes(serialized));
        }

        return Normalize(node);
    }

    // Maps a parsed JSON node back to a CLR value: scalars become primitives so a
    // cursor function written against the live payload keeps working after rehydration;
    // objects and arrays stay as JsonNode.
    private static object Normalize(JsonNode? node)
    {
        if (node is JsonValue value)
        {
            if (value.TryGetValue(out long l))
            {
                return l <= int.MaxValue && l >= int.MinValue ? (int)l : l;
            }

            if (value.TryGetValue(out double d))
            {
                return d;
            }

            if (value.TryGetValue(out bool b))
            {
                return b;
            }

            if (value.TryGetValue(out string? s) && s is not null)
            {
                return s;
            }
        }

        return node ?? (object)string.Empty;
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
                // Persist-before-fan-out durability (C-STR-FBR-5): flush the OS buffer to disk so a
                // crash after emit() returns cannot silently lose an event that a subscriber already
                // observed. File.AppendAllText only reaches the OS cache. Mirrors Python's fsync.
                // Multiple lines are written under a single open+flush so an emit-and-close pair is
                // an atomic durable unit.
                var sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.Append(line).Append('\n');
                }

                var bytes = Encoding.UTF8.GetBytes(sb.ToString());
                using var fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush(flushToDisk: true);
            }
            catch (IOException ex)
            {
                throw new EventStreamException($"Failed to persist event for stream '{Id}'.", ex);
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
            throw new EventStreamException(
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
