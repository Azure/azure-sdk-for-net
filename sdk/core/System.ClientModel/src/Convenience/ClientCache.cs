// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// A cache for storing client instances, ensuring efficient reuse.
/// Implements an LRU eviction policy.
/// </summary>
public class ClientCache
{
    private readonly Dictionary<object, ClientEntry> _clients = new();
    private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.SupportsRecursion);

    private readonly int _maxSize;

    /// <summary>
    /// Initializes the ClientCache with a configurable cache size.
    /// </summary>
    /// <param name="maxSize">The maximum number of clients to store in the cache.</param>
    public ClientCache(int maxSize)
    {
        _maxSize = maxSize;
    }

    /// <summary>
    /// Retrieves a client from the cache or creates a new one if it doesn't exist.
    /// Updates the last-used timestamp on every hit.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="clientId">A key representing the client configuration.</param>
    /// <param name="createClient">A factory function to create the client if not cached.</param>
    /// <returns>The cached or newly created client instance.</returns>
    public T GetClient<T>(object clientId, Func<T> createClient) where T : class
    {
        _lock.EnterReadLock();
        try
        {
            // If the client exists, update its timestamp.
            if (_clients.TryGetValue(clientId, out var cached))
            {
                cached.LastUsed = Stopwatch.GetTimestamp();

                if (cached.Client is T typedClient)
                {
                    return typedClient;
                }

                throw new InvalidOperationException($"The clientId is associated with a client of type '{cached.Client.GetType()}', not '{typeof(T)}'.");
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }

        // Client not found, enter write lock
        _lock.EnterWriteLock();
        try
        {
            // Double-check inside write lock to avoid race condition
            if (_clients.TryGetValue(clientId, out var existing))
            {
                existing.LastUsed = Stopwatch.GetTimestamp();

                if (existing.Client is T typedClient)
                {
                    return typedClient;
                }

                throw new InvalidOperationException($"The clientId is associated with a client of type '{existing.Client.GetType()}', not '{typeof(T)}'.");
            }

            // Client not found in cache, create a new one.
            T created = createClient();
            _clients[clientId] = new ClientEntry(created, Stopwatch.GetTimestamp());

            if (_clients.Count > _maxSize)
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
        int excess = _clients.Count - _maxSize;
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
