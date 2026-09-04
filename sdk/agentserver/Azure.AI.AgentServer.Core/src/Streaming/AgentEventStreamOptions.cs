// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
    /// <summary>The default per-event retention for replay backings (10 minutes).</summary>
    private static readonly TimeSpan DefaultReplayTtl = TimeSpan.FromMinutes(10);

    private AgentEventStreamConfiguration _configuration =
        AgentEventStreamConfiguration.InMemoryLive;

    /// <summary>Initializes options with the in-memory live backing.</summary>
    public AgentEventStreamOptions()
    {
    }

    internal AgentEventStreamOptions(AgentEventStreamConfiguration configuration)
        => _configuration = configuration;

    /// <summary>
    /// Selects the in-memory live backing (the default): constant memory, no
    /// replay; late subscribers miss earlier events.
    /// </summary>
    public void UseInMemoryLive()
        => _configuration = AgentEventStreamConfiguration.InMemoryLive;

    /// <summary>
    /// Selects the in-memory replay backing: retained history with bounded
    /// per-event TTL, supporting late subscribers and reconnect via
    /// <see cref="SseItem{T}.EventId"/>.
    /// </summary>
    /// <param name="ttl">Per-event retention; defaults to 10 minutes.</param>
    public void UseInMemoryReplay(TimeSpan? ttl = null)
        => _configuration = AgentEventStreamConfiguration.InMemoryReplay(
            ValidateTtl(ttl ?? DefaultReplayTtl));

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
        _configuration = AgentEventStreamConfiguration.FileBackedReplay(
            ResolveStreamDirectory(storageDirectory),
            ValidateTtl(ttl ?? DefaultReplayTtl));
    }

    // Defaults an unspecified stream directory to the shared agent-server state root so streams
    // live alongside tasks with no required configuration; callers can still point anywhere.
    private static string ResolveStreamDirectory(string? storageDirectory)
        => string.IsNullOrEmpty(storageDirectory)
            ? AgentServerStatePaths.StreamsRoot()
            : storageDirectory;

    private static TimeSpan ValidateTtl(TimeSpan ttl)
    {
        if (ttl < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(ttl), "Replay retention must be non-negative.");
        }

        return ttl;
    }

    /// <summary>Builds a backing instance for the given id, wiring its self-destroy callback.</summary>
    internal AgentEventStreamConfiguration Configuration => _configuration;

    /// <summary>Builds a backing instance for the given id, wiring its self-destroy callback.</summary>
    internal AgentEventStream CreateStream(
        string id,
        Action onDestroy,
        string? taskId = null)
        => _configuration.CreateStream(id, onDestroy, taskId);

    internal AgentEventStream? CreateExistingTaskStream(
        string id,
        Action onDestroy,
        string taskId)
        => _configuration.CreateExistingTaskStream(id, onDestroy, taskId);
}

internal enum AgentEventStreamBackingKind
{
    InMemoryLive,
    InMemoryReplay,
    FileBackedReplay,
}

internal sealed class AgentEventStreamConfiguration : IEquatable<AgentEventStreamConfiguration>
{
    private static readonly StringComparer PathComparer =
        OperatingSystem.IsWindows() ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;

    private AgentEventStreamConfiguration(
        AgentEventStreamBackingKind backing,
        TimeSpan? ttl,
        string? storageDirectory)
    {
        Backing = backing;
        Ttl = ttl;
        StorageDirectory = storageDirectory;
    }

    public static AgentEventStreamConfiguration InMemoryLive { get; } =
        new(AgentEventStreamBackingKind.InMemoryLive, ttl: null, storageDirectory: null);

    public AgentEventStreamBackingKind Backing { get; }

    public TimeSpan? Ttl { get; }

    public string? StorageDirectory { get; }

    public static AgentEventStreamConfiguration InMemoryReplay(TimeSpan ttl)
        => new(AgentEventStreamBackingKind.InMemoryReplay, ttl, storageDirectory: null);

    public static AgentEventStreamConfiguration FileBackedReplay(
        string storageDirectory,
        TimeSpan ttl)
        => new(
            AgentEventStreamBackingKind.FileBackedReplay,
            ttl,
            Path.TrimEndingDirectorySeparator(Path.GetFullPath(storageDirectory)));

    public AgentEventStream CreateStream(
        string id,
        Action onDestroy,
        string? taskId)
        => Backing switch
        {
            AgentEventStreamBackingKind.InMemoryLive => new BroadcastEventStream(id, onDestroy),
            AgentEventStreamBackingKind.InMemoryReplay => new ReplayEventStream(id, Ttl, onDestroy),
            AgentEventStreamBackingKind.FileBackedReplay => new FileBackedReplayEventStream(
                id,
                StorageDirectory!,
                Ttl!.Value,
                onDestroy,
                taskId),
            _ => throw new InvalidOperationException(
                $"Unsupported AgentEventStream backing '{Backing}'."),
        };

    public AgentEventStream? CreateExistingTaskStream(
        string id,
        Action onDestroy,
        string taskId)
    {
        if (Backing != AgentEventStreamBackingKind.FileBackedReplay
            || !FileBackedReplayEventStream.Exists(id, StorageDirectory!))
        {
            return null;
        }

        return new FileBackedReplayEventStream(
            id,
            StorageDirectory!,
            Ttl!.Value,
            onDestroy,
            taskId);
    }

    public bool Equals(AgentEventStreamConfiguration? other)
        => other is not null
        && Backing == other.Backing
        && Ttl == other.Ttl
        && PathComparer.Equals(StorageDirectory, other.StorageDirectory);

    public override bool Equals(object? obj)
        => obj is AgentEventStreamConfiguration other && Equals(other);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Backing);
        hash.Add(Ttl);
        hash.Add(StorageDirectory, PathComparer);
        return hash.ToHashCode();
    }

    public override string ToString()
        => Backing switch
        {
            AgentEventStreamBackingKind.InMemoryLive => nameof(AgentEventStreamBackingKind.InMemoryLive),
            AgentEventStreamBackingKind.InMemoryReplay =>
                $"{nameof(AgentEventStreamBackingKind.InMemoryReplay)}(ttl='{FormatTtl(Ttl)}')",
            AgentEventStreamBackingKind.FileBackedReplay =>
                $"{nameof(AgentEventStreamBackingKind.FileBackedReplay)}" +
                $"(path='{StorageDirectory}', ttl='{FormatTtl(Ttl)}')",
            _ => Backing.ToString(),
        };

    private static string FormatTtl(TimeSpan? ttl)
        => ttl?.ToString("c", System.Globalization.CultureInfo.InvariantCulture) ?? "none";
}
