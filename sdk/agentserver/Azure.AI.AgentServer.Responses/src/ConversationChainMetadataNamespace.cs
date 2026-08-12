// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Named namespace facade over <see cref="ConversationChainMetadata"/>.
/// </summary>
public sealed class ConversationChainMetadataNamespace
{
    private readonly ConversationChainMetadata _owner;

    internal ConversationChainMetadataNamespace(ConversationChainMetadata owner, string namespaceName)
    {
        _owner = owner;
        Name = namespaceName;
    }

    /// <summary>Gets the namespace name.</summary>
    public string Name { get; }

    /// <summary>Sets a key/value in this namespace.</summary>
    public void Set(string key, string value) => _owner.Set(Name, key, value);

    /// <summary>Attempts to read a key from this namespace.</summary>
    public bool TryGet(string key, out string? value) => _owner.TryGet(Name, key, out value);

    /// <summary>Returns a snapshot of this namespace.</summary>
    public IReadOnlyDictionary<string, string> Snapshot() => _owner.GetNamespace(Name);

    /// <summary>
    /// Flushes this namespace's buffered values to durable storage. Isolated to this namespace
    /// only (mirrors Python's per-namespace <c>flush()</c>).
    /// </summary>
    public Task FlushAsync(CancellationToken cancellationToken = default)
        => _owner.FlushNamespaceAsync(Name, cancellationToken);
}
