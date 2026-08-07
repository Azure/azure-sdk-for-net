// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// A task's durable, namespaced key/value metadata. Values are <see cref="BinaryData"/>
/// so the serializable contract is enforced at compile time; JSON-content values map
/// byte-for-byte to Python's JSON-serializable metadata values. Keys beginning with
/// <c>_</c> are reserved for the framework by CONVENTION but not enforced by the primitive
/// (SOT §17; layers built on top may reject them more strictly). The default namespace is
/// exposed directly; call <see cref="GetNamespace(string)"/> for a sibling namespace with the same surface.
/// The values are enumerable as a standard key/value collection.
/// </summary>
public class TaskMetadata : IEnumerable<KeyValuePair<string, BinaryData>>
{
    private readonly ConcurrentDictionary<string, BinaryData> _values;
    private readonly ConcurrentDictionary<string, TaskMetadata> _siblings;
    private readonly Func<TaskMetadata, CancellationToken, Task>? _flush;

    /// <summary>Initializes a new instance of the <see cref="TaskMetadata"/> class for mocking.</summary>
    protected TaskMetadata()
        : this(name: string.Empty, flush: null)
    {
    }

    internal TaskMetadata(string name, Func<TaskMetadata, CancellationToken, Task>? flush)
    {
        Name = name;
        _flush = flush;
        _values = new ConcurrentDictionary<string, BinaryData>(StringComparer.Ordinal);
        _siblings = new ConcurrentDictionary<string, TaskMetadata>(StringComparer.Ordinal);
    }

    /// <summary>The namespace name; the default namespace is the empty string.</summary>
    internal string Name { get; }

    /// <summary>Gets or sets the value for <paramref name="key"/> in this namespace.</summary>
    /// <param name="key">The key; keys beginning with <c>_</c> are reserved by convention (not enforced).</param>
    /// <returns>The stored value, or <see langword="null"/> if absent.</returns>
    public virtual BinaryData? this[string key]
    {
        get
        {
            ValidateKey(key);
            return _values.TryGetValue(key, out BinaryData? value) ? value : null;
        }

        set
        {
            ValidateKey(key);
            if (value is null)
            {
                _values.TryRemove(key, out _);
            }
            else
            {
                _values[key] = value;
            }
        }
    }

    /// <summary>Returns whether <paramref name="key"/> is present in this namespace.</summary>
    /// <param name="key">The key to test.</param>
    /// <returns><see langword="true"/> if present.</returns>
    public virtual bool ContainsKey(string key)
    {
        ValidateKey(key);
        return _values.ContainsKey(key);
    }

    /// <summary>Tries to get the value for <paramref name="key"/>.</summary>
    /// <param name="key">The key to read.</param>
    /// <param name="value">The value when present.</param>
    /// <returns><see langword="true"/> if present.</returns>
    public virtual bool TryGetValue(string key, out BinaryData? value)
    {
        ValidateKey(key);
        return _values.TryGetValue(key, out value);
    }

    /// <summary>Removes <paramref name="key"/> from this namespace.</summary>
    /// <param name="key">The key to remove.</param>
    /// <returns><see langword="true"/> if a value was removed.</returns>
    public virtual bool Remove(string key)
    {
        ValidateKey(key);
        return _values.TryRemove(key, out _);
    }

    /// <summary>The keys present in this namespace.</summary>
    public virtual IEnumerable<string> Keys => _values.Keys;

    /// <summary>The number of key/value pairs in this namespace.</summary>
    public virtual int Count => _values.Count;

    /// <summary>Returns an enumerator over this namespace's key/value pairs.</summary>
    /// <returns>An enumerator over the pairs.</returns>
    public virtual IEnumerator<KeyValuePair<string, BinaryData>> GetEnumerator() => _values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>Returns a sibling namespace with the same surface, creating it on first use.</summary>
    /// <param name="name">The sibling namespace name.</param>
    /// <returns>The sibling <see cref="TaskMetadata"/>.</returns>
    public virtual TaskMetadata GetNamespace(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Namespace name must be non-empty.", nameof(name));
        }

        return _siblings.GetOrAdd(name, n => new TaskMetadata(n, _flush));
    }

    /// <summary>Flushes pending metadata changes for THIS namespace to durable storage.
    /// Sibling namespaces are not touched (mirrors Python <c>flush()</c>).</summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the flush is done.</returns>
    public virtual Task FlushAsync(CancellationToken cancellationToken = default)
        => _flush is null ? Task.CompletedTask : _flush(this, cancellationToken);

    /// <summary>
    /// Framework-internal: flushes this namespace AND every sibling namespace, so all in-memory
    /// mutations land before a lifecycle transition (the auto-flush invariant). Mirrors Python's
    /// internal <c>_flush_all()</c>; developers use per-namespace <see cref="FlushAsync"/>.
    /// </summary>
    internal async Task FlushAllAsync(CancellationToken cancellationToken = default)
    {
        await FlushAsync(cancellationToken).ConfigureAwait(false);
        foreach (KeyValuePair<string, TaskMetadata> sibling in _siblings)
        {
            await sibling.Value.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Collects this namespace and (when this is the root) all sibling namespaces into
    /// <paramref name="destination"/>, keyed by namespace name (the default namespace uses
    /// the empty string). Values are emitted as JSON nodes for wire serialization.
    /// </summary>
    internal void CollectInto(IDictionary<string, JsonObject> destination)
    {
        var values = new JsonObject();
        foreach (KeyValuePair<string, BinaryData> pair in _values)
        {
            values[pair.Key] = JsonNode.Parse(pair.Value.ToMemory().Span);
        }

        destination[Name] = values;

        foreach (KeyValuePair<string, TaskMetadata> sibling in _siblings)
        {
            sibling.Value.CollectInto(destination);
        }
    }

    /// <summary>
    /// Collects ONLY this namespace's key/value pairs into <paramref name="destination"/> (keyed by
    /// this namespace's name; the default namespace uses the empty string). Unlike
    /// <see cref="CollectInto"/>, sibling namespaces are not included — used by the per-namespace
    /// <see cref="FlushAsync"/> so a single flush PATCH touches only its own payload key.
    /// </summary>
    internal void CollectSelfInto(IDictionary<string, JsonObject> destination)
    {
        var values = new JsonObject();
        foreach (KeyValuePair<string, BinaryData> pair in _values)
        {
            values[pair.Key] = JsonNode.Parse(pair.Value.ToMemory().Span);
        }

        destination[Name] = values;
    }

    /// <summary>
    /// Hydrates the namespace named <paramref name="namespaceName"/> (empty for the default)
    /// from a persisted JSON object, replacing any existing values for those keys.
    /// </summary>
    internal void LoadNamespace(string namespaceName, JsonObject values)
    {
        TaskMetadata target = string.IsNullOrEmpty(namespaceName) ? this : GetNamespace(namespaceName);
        foreach (KeyValuePair<string, JsonNode?> pair in values)
        {
            if (pair.Value is null)
            {
                continue;
            }

            target._values[pair.Key] = new BinaryData(pair.Value.ToJsonString());
        }
    }

    private static void ValidateKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Metadata key must be non-empty.", nameof(key));
        }

        // Per the task-and-streaming SOT §17, the leading-underscore reservation is a CONVENTION at
        // the primitive's API surface — the core primitive does NOT enforce it (layers built on top,
        // e.g. a responses framework's `_responses` namespace, MAY reject `_*` more strictly).
        // Matching Python (_metadata.__setitem__ only rejects non-string keys), we allow `_`-prefixed
        // keys here; metadata is namespaced under payload["metadata"], so it cannot collide with the
        // framework's top-level `_`-prefixed payload keys.
    }
}
