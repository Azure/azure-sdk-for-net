// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace System.ClientModel.Primitives;

/// <summary>
/// A cache for storing client instances, ensuring efficient reuse.
/// Implements an LRU eviction policy.
/// </summary>
public class ClientCache
{
    private readonly ConcurrentDictionary<(Type, string), (object Client, long LastUsed)> _clients = new();

    private const int MaxCacheSize = 100;

    /// <summary>
    /// Retrieves a client from the cache or creates a new one if it doesn't exist.
    /// Updates the last-used timestamp on every hit.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="createClient">A factory function to create the client if not cached.</param>
    /// <param name="id">An optional identifier for the client instance.</param>
    /// <returns>The cached or newly created client instance.</returns>
    public T GetClient<T>(Func<T> createClient, string id = "") where T : class
    {
        (Type, string) key = (typeof(T), id ?? string.Empty);
        lock (_clients)
        {
            // If the client exists, update its timestamp and return it.
            if (_clients.TryGetValue(key, out var cached))
            {
                long now = Stopwatch.GetTimestamp();
                _clients[key] = (cached.Client, now); // update timestamp
                return (T)cached.Client;
            }

            // Create and add the new client.
            T created = createClient();
            long timestamp = Stopwatch.GetTimestamp();
            _clients[key] = (created, timestamp);

            // After insertion, if cache exceeds the limit, perform cleanup.
            if (_clients.Count > MaxCacheSize)
            {
                Cleanup();
            }

            return created;
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
        foreach (var key in _clients.OrderBy(kvp => kvp.Value.LastUsed).Take(excess).Select(kvp => kvp.Key))
        {
            if (_clients.TryRemove(key, out var instance) && instance.Client is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
