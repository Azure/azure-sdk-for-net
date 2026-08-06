// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ServerSentEvents;
using Azure.AI.AgentServer.Core.Streaming.Backings;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Selects and configures the single event-stream backing used for the process.
/// Exactly one backing is chosen at startup; if none is selected the default is
/// the in-memory live backing.
/// </summary>
public sealed class AgentEventStreamOptions
{
    /// <summary>The default per-event retention for the file-backed replay backing (10 minutes).</summary>
    private static readonly TimeSpan DefaultFileBackedTtl = TimeSpan.FromMinutes(10);

    private Func<string, Action, AgentEventStream> _factory = (id, _) => new BroadcastEventStream(id);

    /// <summary>
    /// Selects the in-memory live backing (the default): constant memory, no
    /// replay; late subscribers miss earlier events.
    /// </summary>
    public void UseInMemoryLive()
        => _factory = (id, _) => new BroadcastEventStream(id);

    /// <summary>
    /// Selects the in-memory replay backing: retained history with optional
    /// per-event TTL, supporting late subscribers and reconnect via
    /// <see cref="SseItem{T}.EventId"/>.
    /// </summary>
    /// <param name="ttl">Per-event retention; events become evictable after this duration.</param>
    public void UseInMemoryReplay(TimeSpan? ttl = null)
        => _factory = (id, onDestroy) => new ReplayEventStream(id, ttl, onDestroy);

    /// <summary>
    /// Selects the file-backed replay backing: events persist to
    /// <c>&lt;storageDirectory&gt;/&lt;id&gt;.jsonl</c> and rehydrate on the next
    /// <see cref="AgentEventStreamRegistry.GetOrCreateAsync"/>, surviving a process crash.
    /// The event text (<see cref="SseItem{T}.Data"/>) is already a string, so no payload
    /// codec is required.
    /// </summary>
    /// <param name="storageDirectory">
    /// The directory that holds one file per stream id (created if absent). When omitted, defaults
    /// to a <c>streams</c> directory under the shared agent-server state root
    /// (<c>~/.agentserver/streams</c>, overridable via <c>AGENTSERVER_STATE_ROOT</c>) — the same
    /// root under which tasks are stored.
    /// </param>
    /// <param name="ttl">Per-event retention; events become evictable after this duration. Defaults to 10 minutes.</param>
    public void UseFileBackedReplay(
        string? storageDirectory = null,
        TimeSpan? ttl = null)
    {
        _factory = (id, onDestroy) => new FileBackedReplayEventStream(
            id, ResolveStreamDirectory(storageDirectory), ttl ?? DefaultFileBackedTtl, onDestroy);
    }

    // Defaults an unspecified stream directory to the shared agent-server state root so streams
    // live alongside tasks with no required configuration; callers can still point anywhere.
    private static string ResolveStreamDirectory(string? storageDirectory)
        => string.IsNullOrEmpty(storageDirectory)
            ? AgentServerStatePaths.StreamsRoot()
            : storageDirectory;

    /// <summary>Builds a backing instance for the given id, wiring its self-destroy callback.</summary>
    internal AgentEventStream CreateStream(string id, Action onDestroy) => _factory(id, onDestroy);
}
