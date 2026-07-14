// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Durable, explicitly-flushed per-conversation-chain metadata exposed to handlers via
/// <see cref="ResponseContext.ConversationChainMetadata"/>.
/// <para>
/// Values are organized into named namespaces and buffered in memory until
/// <see cref="FlushAsync"/> is called. Flushing persists the buffered values into the
/// response snapshot so they survive process crash and recovery. Namespace names and keys
/// beginning with an underscore (<c>_</c>) are reserved for internal use and are rejected.
/// </para>
/// <para>
/// This type is thread-safe for concurrent reads and writes across namespaces.
/// </para>
/// </summary>
public class ConversationChainMetadata
{
    /// <summary>Default namespace name used by the namespace facade helpers.</summary>
    public const string DefaultNamespaceName = "default";

    private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _namespaces;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationChainMetadata"/> class.
    /// </summary>
    public ConversationChainMetadata()
    {
        _namespaces = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>(StringComparer.Ordinal);
    }

    /// <summary>
    /// Gets a shared empty, no-op instance used as the default on a
    /// <see cref="ResponseContext"/> that is not backed by durable persistence
    /// (e.g., a test-constructed context). Flushing this instance is a no-op.
    /// </summary>
    public static ConversationChainMetadata Empty { get; } = new ConversationChainMetadata();

    /// <summary>
    /// Sets a metadata value within the named namespace. The value is buffered until the
    /// next <see cref="FlushAsync"/>.
    /// </summary>
    /// <param name="namespaceName">The metadata namespace. Must not begin with <c>_</c>.</param>
    /// <param name="key">The metadata key. Must not begin with <c>_</c>.</param>
    /// <param name="value">The metadata value.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="namespaceName"/> or <paramref name="key"/> begins with the
    /// reserved <c>_</c> prefix.
    /// </exception>
    public virtual void Set(string namespaceName, string key, string value)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        Argument.AssertNotNullOrEmpty(key, nameof(key));
        Argument.AssertNotNull(value, nameof(value));
        RejectReserved(namespaceName, nameof(namespaceName));
        RejectReserved(key, nameof(key));

        var bucket = _namespaces.GetOrAdd(namespaceName, _ => new ConcurrentDictionary<string, string>(StringComparer.Ordinal));
        bucket[key] = value;
    }

    /// <summary>
    /// Attempts to read a buffered metadata value within the named namespace.
    /// </summary>
    /// <param name="namespaceName">The metadata namespace.</param>
    /// <param name="key">The metadata key.</param>
    /// <param name="value">The value, when present.</param>
    /// <returns><see langword="true"/> when the value is present; otherwise <see langword="false"/>.</returns>
    public virtual bool TryGet(string namespaceName, string key, out string? value)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        Argument.AssertNotNullOrEmpty(key, nameof(key));

        value = null;
        return _namespaces.TryGetValue(namespaceName, out var bucket) && bucket.TryGetValue(key, out value);
    }

    /// <summary>
    /// Returns a read-only snapshot of the buffered values in the named namespace, or an
    /// empty dictionary when the namespace has no buffered values.
    /// </summary>
    /// <param name="namespaceName">The metadata namespace.</param>
    /// <returns>A snapshot of the namespace's buffered key/value pairs.</returns>
    public virtual IReadOnlyDictionary<string, string> GetNamespace(string namespaceName)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        if (_namespaces.TryGetValue(namespaceName, out var bucket))
        {
            return new Dictionary<string, string>(bucket, StringComparer.Ordinal);
        }

        return EmptyNamespace;
    }

    /// <summary>
    /// Returns a named namespace facade over this metadata store.
    /// </summary>
    /// <param name="namespaceName">The namespace name; defaults to <see cref="DefaultNamespaceName"/>.</param>
    /// <returns>A namespace facade bound to <paramref name="namespaceName"/>.</returns>
    public virtual ConversationChainMetadataNamespace ForNamespace(string namespaceName = DefaultNamespaceName)
    {
        Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
        RejectReserved(namespaceName, nameof(namespaceName));
        return new ConversationChainMetadataNamespace(this, namespaceName);
    }

    /// <summary>
    /// Persists the buffered values of the default (root) namespace into the durable response
    /// snapshot so they survive process crash and recovery. Mirrors Python's
    /// <c>context.conversation_chain_metadata.flush()</c>, which flushes only its own (default)
    /// backing. The base implementation is a no-op; the durable-backed implementation persists
    /// only the default namespace's payload.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes once the buffered values have been persisted.</returns>
    public virtual Task FlushAsync(CancellationToken cancellationToken = default)
        => FlushNamespaceAsync(DefaultNamespaceName, cancellationToken);

    /// <summary>
    /// Persists the buffered values of a single named namespace into the durable response
    /// snapshot. Mirrors Python's per-namespace <c>flush()</c> (each namespace facade flushes only
    /// its own backing). The base implementation is a no-op; the durable-backed implementation
    /// flushes only that namespace's payload key.
    /// </summary>
    /// <param name="namespaceName">The namespace to flush.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes once the namespace's buffered values have been persisted.</returns>
    internal virtual Task FlushNamespaceAsync(string namespaceName, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    /// <summary>
    /// Returns a read-only snapshot of all buffered namespaces and their key/value pairs.
    /// Used by the durable implementation to persist metadata on flush.
    /// </summary>
    /// <returns>A snapshot mapping namespace name to its key/value pairs.</returns>
    protected internal IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Snapshot()
    {
        var result = new Dictionary<string, IReadOnlyDictionary<string, string>>(StringComparer.Ordinal);
        foreach (var pair in _namespaces)
        {
            result[pair.Key] = new Dictionary<string, string>(pair.Value, StringComparer.Ordinal);
        }

        return result;
    }

    private static readonly IReadOnlyDictionary<string, string> EmptyNamespace
        = new Dictionary<string, string>(StringComparer.Ordinal);

    private protected static void RejectReserved(string value, string paramName)
    {
        if (value.StartsWith('_'))
        {
            throw new ArgumentException(
                $"Conversation chain metadata {paramName} '{value}' is invalid: names and keys beginning with '_' are reserved for internal use.",
                paramName);
        }
    }
}
