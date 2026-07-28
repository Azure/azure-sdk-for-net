// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming.Backings;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Selects and configures the single event-stream backing used for the process.
/// Exactly one backing is chosen at startup; if none is selected the default is
/// the in-memory live backing. Mirrors Python's <c>streams.use_*</c> configurators.
/// </summary>
public sealed class EventStreamOptions
{
    /// <summary>The default per-event retention for the file-backed replay backing (10 minutes).</summary>
    private static readonly TimeSpan DefaultFileBackedTtl = TimeSpan.FromMinutes(10);

    private Func<string, Action, IEventStream> _factory = (id, _) => new BroadcastEventStream(id);

    /// <summary>
    /// Selects the in-memory live backing (the default): constant memory, no
    /// replay; late subscribers miss earlier events.
    /// </summary>
    public void UseInMemoryLive()
        => _factory = (id, _) => new BroadcastEventStream(id);

    /// <summary>
    /// Selects the in-memory replay backing: retained history with optional
    /// per-event TTL, supporting late subscribers and cursored reconnect.
    /// </summary>
    /// <param name="cursor">
    /// A function that maps a payload to its integer cursor; required for
    /// <c>Subscribe(after)</c> and a usable <c>GetLastCursorAsync</c>.
    /// </param>
    /// <param name="ttl">Per-event retention; events become evictable after this duration.</param>
    public void UseInMemoryReplay(Func<object, int>? cursor = null, TimeSpan? ttl = null)
        => _factory = (id, onDestroy) => new ReplayEventStream(id, cursor, ttl, onDestroy);

    /// <summary>
    /// Selects the file-backed replay backing with typed JSON persistence: events are serialized
    /// as JSON to <c>&lt;storageDirectory&gt;/&lt;id&gt;.jsonl</c> and rehydrated back to
    /// <typeparamref name="TPayload"/> on the next
    /// <see cref="IEventStreamRegistry.GetOrCreateAsync"/>, surviving a process crash. This is the
    /// low-ceremony form: the storage directory, retention, and JSON serialization all have
    /// sensible defaults, so most callers only supply a <paramref name="cursor"/>.
    /// </summary>
    /// <typeparam name="TPayload">The event payload type; used for the default JSON round-trip.</typeparam>
    /// <param name="cursor">A function that maps a payload to its integer cursor.</param>
    /// <param name="ttl">Per-event retention; events become evictable after this duration. Defaults to 10 minutes.</param>
    /// <param name="storageDirectory">
    /// The directory that holds one file per stream id (created if absent). When omitted, defaults
    /// to <c>~/.agentserver/streams</c> (overridable via <c>AGENTSERVER_STATE_ROOT</c>) — the same
    /// state root under which tasks are stored.
    /// </param>
    public void UseFileBackedReplay<TPayload>(
        Func<TPayload, int>? cursor = null,
        TimeSpan? ttl = null,
        string? storageDirectory = null)
    {
        Func<object, int>? objectCursor = cursor is null ? null : payload => cursor((TPayload)payload);
        Func<object, byte[]> serializer = payload => JsonSerializer.SerializeToUtf8Bytes((TPayload)payload);
        Func<byte[], object> deserializer = bytes => JsonSerializer.Deserialize<TPayload>(bytes)!;

        _factory = (id, onDestroy) => new FileBackedReplayEventStream(
            id, ResolveStreamDirectory(storageDirectory), objectCursor, ttl ?? DefaultFileBackedTtl,
            serializer, deserializer, onDestroy);
    }

    /// <summary>
    /// Selects the file-backed replay backing: events persist to
    /// <c>&lt;storageDirectory&gt;/&lt;id&gt;.jsonl</c> and rehydrate on the next
    /// <see cref="IEventStreamRegistry.GetOrCreateAsync"/>, surviving a process crash. This
    /// overload accepts custom (non-JSON) serialization; for typed JSON persistence prefer
    /// <see cref="UseFileBackedReplay{TPayload}(System.Func{TPayload,int}?,System.TimeSpan?,string?)"/>.
    /// </summary>
    /// <param name="storageDirectory">
    /// The directory that holds one file per stream id (created if absent). When omitted, defaults
    /// to a <c>streams</c> directory under the shared agent-server state root
    /// (<c>~/.agentserver/streams</c>, overridable via <c>AGENTSERVER_STATE_ROOT</c>) — the same
    /// root under which tasks are stored.
    /// </param>
    /// <param name="cursor">A function that maps a payload to its integer cursor.</param>
    /// <param name="ttl">Per-event retention; events become evictable after this duration. Defaults to 10 minutes.</param>
    /// <param name="serializer">An optional payload serializer (defaults to JSON).</param>
    /// <param name="deserializer">An optional payload deserializer (defaults to JSON).</param>
    public void UseFileBackedReplay(
        string? storageDirectory = null,
        Func<object, int>? cursor = null,
        TimeSpan? ttl = null,
        Func<object, byte[]>? serializer = null,
        Func<byte[], object>? deserializer = null)
    {
        // The encode/decode paths assume a matched pair: a custom serializer without a matching
        // deserializer (or vice versa) silently corrupts payloads on rehydrate, and the failure
        // only surfaces after a crash/restart — far from this misconfiguration. Reject it here.
        if (serializer is null != (deserializer is null))
        {
            throw new ArgumentException(
                "The file-backed replay backing requires both a serializer and a deserializer, or neither (defaults to JSON).",
                serializer is null ? nameof(serializer) : nameof(deserializer));
        }

        _factory = (id, onDestroy) => new FileBackedReplayEventStream(
            id, ResolveStreamDirectory(storageDirectory), cursor, ttl ?? DefaultFileBackedTtl,
            serializer, deserializer, onDestroy);
    }

    // Defaults an unspecified stream directory to the shared agent-server state root so streams
    // live alongside tasks with no required configuration; callers can still point anywhere.
    private static string ResolveStreamDirectory(string? storageDirectory)
        => string.IsNullOrEmpty(storageDirectory)
            ? AgentServerStatePaths.StreamsRoot()
            : storageDirectory;

    /// <summary>Builds a backing instance for the given id, wiring its self-destroy callback.</summary>
    internal IEventStream CreateStream(string id, Action onDestroy) => _factory(id, onDestroy);
}
