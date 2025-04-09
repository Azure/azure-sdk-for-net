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

    private readonly int _maxCacheSize;

    /// <summary>
    /// Initializes the ClientCache with a configurable cache size.
    /// </summary>
    /// <param name="maxCacheSize">The maximum number of clients to store in the cache.</param>
    public ClientCache(int maxCacheSize = 100)
    {
        _maxCacheSize = maxCacheSize;
    }

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
            if (_clients.Count > _maxCacheSize)
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
        int excess = _clients.Count - _maxCacheSize;
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

[Fact]
    public void ClientCache_Respects_MaxCacheSize()
    {
        // Arrange: Create a cache with a small max size
        int maxSize = 3;
        var cache = new ClientCache(maxSize);

        int createCount = 0;
        Func<DummyClient> factory = () =>
        {
            createCount++;
            return new DummyClient();
        };

        // Act: Add more clients than the cache size allows
        for (int i = 0; i < 5; i++)
        {
            cache.GetClient(factory, $"client-{i}");
        }

        // Assert: Only maxSize clients should remain in the cache
        // Since we can't directly inspect _clients, re-access clients and count how many were re-created
        for (int i = 0; i < 5; i++)
        {
            cache.GetClient(factory, $"client-{i}");
        }

        // The original 5 created, and at most 3 of them are reused. So up to 2 are re-created
        // Meaning createCount should be between 5 (if all were reused) and 7 (if 2 were evicted and re-added)
        Assert.True(createCount > maxSize, "Some clients should have been evicted and re-created.");
        Assert.True(createCount <= 5 + (5 - maxSize), "Too many clients were re-created, cache size not enforced.");
    }

    private class DummyClient { }

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
