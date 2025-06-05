// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace System.ClientModel.Primitives;

/// <summary>
/// A cache for storing client instances, ensuring efficient reuse.
/// Implements an LRU eviction policy.
/// </summary>
public class ClientCache
{
    private readonly Dictionary<(Type, string), ClientEntry> _clients = new();
    private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.SupportsRecursion);

    private const int MaxCacheSize = 100;

    /// <summary>
    /// Retrieves a client from the cache or creates a new one if it doesn't exist.
    /// Updates the last-used timestamp on every hit.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="createClient">A factory function to create the client if not cached.</param>
    /// <param name="id">An identifier for the client instance.</param>
    /// <returns>The cached or newly created client instance.</returns>
    public T GetClient<T>(Func<T> createClient, string? id) where T : class
    {
        (Type, string) key = (typeof(T), id ?? string.Empty);

        // If the client exists, update its timestamp.
        if (_clients.TryGetValue(key, out var cached))
        {
            cached.LastUsed = Stopwatch.GetTimestamp();
            return (T)cached.Client;
        }

        // Client not found in cache, create a new one.
        _lock.EnterWriteLock();
        try
        {
            T created = createClient();
            _clients[key] = new ClientEntry(created, Stopwatch.GetTimestamp());

            // After insertion, if cache exceeds the limit, perform cleanup.
            if (_clients.Count > MaxCacheSize)
            {
                Cleanup();
            }
            return created;
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    /// <summary>
    /// Removes the least recently used cached clients until the cache size is below the limit.
    /// </summary>
    private void Cleanup()
    {
        int excess = _clients.Count - MaxCacheSize;
        if (excess <= 0)
        {
            return;
        }

        // Remove the 'excess' number of items based on the oldest timestamp.
        foreach (var key in _clients.OrderBy(kvp => kvp.Value.LastUsed).Take(excess).Select(kvp => kvp.Key).ToList())
        {
            if (_clients.TryGetValue(key, out var instance))
            {
                _clients.Remove(key);
                if (instance.Client is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}

/// <summary>
/// Represents a cached client and its last-used timestamp.
/// </summary>
internal class ClientEntry
{
    public object Client { get; }
    public long LastUsed { get; set; }

    public ClientEntry(object client, long lastUsed)
    {
        Client = client;
        LastUsed = lastUsed;
    }
}
